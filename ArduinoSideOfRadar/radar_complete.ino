#include <NewPing.h>
#include <Servo.h> 

#define TRIGGER_PIN  12  // Arduino pin tied to trigger pin on ping sensor.
#define ECHO_PIN     11  // Arduino pin tied to echo pin on ping sensor.
#define MAX_DISTANCE 400 // Maximum distance we want to ping for (in centimeters). Maximum sensor distance is rated at 400-500cm.

#define ACTIVATED_LED 2
#define PAUSE_LED 3
#define DEACTIVATED_LED 4
#define SERVO_PIN 9

NewPing sonar(TRIGGER_PIN, ECHO_PIN, MAX_DISTANCE); // NewPing setup of pins and maximum distance.

unsigned int pingSpeed = 50; // Koliko cesto cemo da pozivamo ping u milisekundama
unsigned long pingTimer, lastPing, pingMax = 100;
Servo myservo;
int pos, inc=1, pos_1, del;
int d1,d2, j=0;
boolean active = false;

void setup() {
  Serial.begin(115200); // Open serial monitor at 115200 baud to see ping results.

  pinMode(ACTIVATED_LED,OUTPUT);
  pinMode(DEACTIVATED_LED,OUTPUT);  
  pinMode(PAUSE_LED,OUTPUT);  
  digitalWrite(ACTIVATED_LED,LOW);
  digitalWrite(PAUSE_LED,LOW);
  digitalWrite(DEACTIVATED_LED,HIGH);
  
  while (Serial.available() || !active) {
    char inChar = (char)Serial.read(); 
    if( inChar == 48 )
      break;
  }
  active = true;
    
  myservo.attach(SERVO_PIN);
  myservo.write(0);
  pos = 0;
  pos_1 = 0;

  del = (int)(inc/5);
  
  IndicateActivation();  
  pingTimer = millis();
}

void loop() {
  if(active)
  {
    unsigned long m = millis();  
    if (m >= pingTimer) {
      lastPing = pingTimer;
      pingTimer += pingSpeed;      
      sonar.ping_timer(echoCheck); 
      }
    if( m >= lastPing+pingMax )
    {
        pos = ReturnNewPos(pos);      
    }
    if(pos != pos_1)
    {
      myservo.write(pos);
      delay(del);
    }
  }
}

void echoCheck() { // Timer2 interrupt poziva echoCheck() svakih 24uS da bi se proverio status EchoPin-a
  
  if (sonar.check_timer()) { 
    int dist = sonar.ping_result / US_ROUNDTRIP_CM;
    j++;
    if(j==1) d1 = dist;
    if(j==2)
    { 
     dist = (dist+d1)/2;
     j=0;
     pos_1 = pos;
     Serial.print(dist);
     Serial.print(" ");
     Serial.println(pos_1);
     pos = ReturnNewPos(pos);
    }
  }

}

int ReturnNewPos(int pos_prev)
{
  if(pos_prev+inc>180 || pos_prev+inc<0)
  {
    inc = -inc;
  }
  return  pos_prev+inc;
}

void IndicateActivation()
{
  digitalWrite(DEACTIVATED_LED,LOW);
  digitalWrite(PAUSE_LED,HIGH);
  delay(250);
  digitalWrite(DEACTIVATED_LED,HIGH);
  digitalWrite(PAUSE_LED,LOW);
  delay(250);
  digitalWrite(DEACTIVATED_LED,LOW);
  digitalWrite(PAUSE_LED,HIGH);
  digitalWrite(ACTIVATED_LED,LOW);
  delay(250);
  digitalWrite(PAUSE_LED,LOW);
  digitalWrite(ACTIVATED_LED,HIGH);
  delay(250);
  digitalWrite(PAUSE_LED,LOW);
}
void IndicateDeactivation()
{
  digitalWrite(ACTIVATED_LED,LOW);
  digitalWrite(PAUSE_LED,HIGH);
  delay(250);
  digitalWrite(ACTIVATED_LED,HIGH);
  digitalWrite(PAUSE_LED,LOW);
  delay(250);
  digitalWrite(ACTIVATED_LED,LOW);
  digitalWrite(PAUSE_LED,HIGH);
  digitalWrite(DEACTIVATED_LED,LOW);
  delay(250);
  digitalWrite(PAUSE_LED,LOW);
  digitalWrite(DEACTIVATED_LED,HIGH);
  delay(250);
  digitalWrite(PAUSE_LED,LOW);
}

void serialEvent() {
  while (Serial.available()) {

    char inChar = (char)Serial.read(); 

    if(inChar == 49)
    {
      active = false;
      IndicateDeactivation();
      softReset();     
    }
  }
}
void softReset(){
asm volatile ("  jmp 0");
}

