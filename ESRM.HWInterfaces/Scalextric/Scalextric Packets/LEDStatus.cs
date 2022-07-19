using System;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class LEDStatus
    {
        public bool LED1 { get; set; }
        public bool LED2 { get; set; }
        public bool LED3 { get; set; }
        public bool LED4 { get; set; }
        public bool LED5 { get; set; }
        public bool LED6 { get; set; }
        public bool RedLED { get; set; }
        public bool GreenLED { get; set; }

        public LEDStatus(bool l1, bool l2, bool l3, bool l4, bool l5, bool l6, bool lRed, bool lGreen)
        {
            LED1 = l1;
            LED2 = l2;
            LED3 = l3;
            LED4 = l4;
            LED5 = l5;
            LED6 = l6;
            RedLED = lRed;
            GreenLED = lGreen;
        }

        public LEDStatus()
        {
            LED1 = false;
            LED2 = false;
            LED3 = false;
            LED4 = false;
            LED5 = false;
            LED6 = false;
            RedLED = false;
            GreenLED = true;
        }

        public LEDStatus(byte data)
        {
            BitArray bData = new BitArray(new byte[] { data });
            if (bData.Count != 8)
                throw new Exception();
            LED1 = bData[0];
            LED2 = bData[1];
            LED3 = bData[2];
            LED4 = bData[3];
            LED5 = bData[4];
            LED6 = bData[5];
            RedLED = bData[6];
            GreenLED = bData[7];
        }

        public byte ToByte()
        {
            BitArray allBits = new BitArray(8);
            allBits[0] = LED1;
            allBits[1] = LED2;
            allBits[2] = LED3;
            allBits[3] = LED4;
            allBits[4] = LED5;
            allBits[5] = LED6;
            allBits[6] = RedLED;
            allBits[7] = GreenLED;

            return BinaryTools.ToByte(allBits);
        }

        public void SetId(int idToSet)
        {
            LED1 = false;
            LED2 = false;
            LED3 = false;
            LED4 = false;
            LED5 = false;
            LED6 = false;

            if (idToSet == 1)
                LED1 = true;
            else if (idToSet == 2)
                LED2 = true;
            else if (idToSet == 3)
                LED3 = true;
            else if (idToSet == 4)
                LED4 = true;
            else if (idToSet == 5)
                LED5 = true;
            else if (idToSet == 6)
                LED6 = true;

        }

        public void AuxData()
        {
            LED1 = true;
            LED2 = true;
            LED3 = true;
            LED4 = true;
            LED5 = true;
            LED6 = true;
            RedLED = true;
            GreenLED = false;

        }
    }
}
