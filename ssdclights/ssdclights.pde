// define which pins are to be used for the various light functions
#define GREEN	13
#define RED1	12
#define RED2	11
#define RED3	10
#define RED4	9
#define RED5	8
#define AMBER1	7
#define AMBER2	6

// setup the pins for output and open the serial port
void setup()
{
	pinMode(GREEN, OUTPUT);
	pinMode(RED1, OUTPUT);
	pinMode(RED2, OUTPUT);
	pinMode(RED3, OUTPUT);
	pinMode(RED4, OUTPUT);
	pinMode(RED5, OUTPUT);
	pinMode(AMBER1, OUTPUT);
	pinMode(AMBER2, OUTPUT);
	Serial.begin(9600);
}

// look for data on the serial port and turn on/off the lights
// data is a single byte with the bits set to 1=light on and 0=light off
// bits are 0=green, 1=red1, 2=red2, 3=red3, 4=red4, 5=red5, 6=amber1, 7=amber2
void loop()
{
	byte b;
	if ( Serial.available() )
	{
		b = Serial.read();
		if ( b & 0b00000001 ) { digitalWrite(GREEN, HIGH);	} else { digitalWrite(GREEN, LOW); }
		if ( b & 0b00000010 ) { digitalWrite(RED1, HIGH);	} else { digitalWrite(RED1, LOW); }
		if ( b & 0b00000100 ) { digitalWrite(RED2, HIGH);	} else { digitalWrite(RED2, LOW); }
		if ( b & 0b00001000 ) { digitalWrite(RED3, HIGH);	} else { digitalWrite(RED3, LOW); }
		if ( b & 0b00010000 ) { digitalWrite(RED4, HIGH);	} else { digitalWrite(RED4, LOW); }
		if ( b & 0b00100000 ) { digitalWrite(RED5, HIGH);	} else { digitalWrite(RED5, LOW); }
		if ( b & 0b01000000 ) { digitalWrite(AMBER1, HIGH);	} else { digitalWrite(AMBER1, LOW); }
		if ( b & 0b10000000 ) { digitalWrite(AMBER2, HIGH);	} else { digitalWrite(AMBER2, LOW); }
	}
}
