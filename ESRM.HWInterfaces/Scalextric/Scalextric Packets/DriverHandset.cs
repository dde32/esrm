using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class DriverPacket
    {
        public int Power { get; set; }
        public bool ChangeLane { get; set; }
        public bool Brake { get; set; }

        public DriverPacket() //assumes 8 bits NOT 10
        {
            Power = 0;
            ChangeLane = false;
            Brake = false;
        }

        public DriverPacket(byte data) //assumes 8 bits NOT 10
        {
            BitArray bData = new BitArray(new byte[] { data }).Not();

            if (bData.Count != 8)
                throw new Exception();
            Brake = bData[7];
            ChangeLane = bData[6];
            bool[] pBools = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                pBools[i] = bData[i];
            }
            BitArray pData = new BitArray(pBools);
            Power = getIntFromBitArray(pData);
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }

        public byte ToByte() //complete
        {
            int result = 255 - Power - (ChangeLane ? 64 : 0) - (Brake ? 128 : 0);
            return (byte)result;
        }
    }

    public class DriverAuxPacket

    {
        public bool Lights { get; set; }
        public bool SP { get; set; }
        public bool RC1 { get; set; }
        private int NotUsed { get; set; }

        public DriverAuxPacket() //assumes 8 bits NOT 10
        {
            Lights = false;
            SP = false;
            RC1 = false;
            NotUsed = 255; // 5 bits
        }

        public DriverAuxPacket(byte data) //assumes 8 bits NOT 10
        {
            BitArray bData = new BitArray(new byte[] { data }).Not();

            if (bData.Count != 8)
                throw new Exception();
            Lights = bData[7];
            SP = bData[6];
            RC1 = bData[5];
            NotUsed = 255; // 5 bits
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }

        public byte ToByte() //complete
        {
            int result = 255 - NotUsed - (RC1 ? 32 : 0) - (SP ? 64 : 0) - (Lights ? 128 : 0);
            return (byte)result;
        }
    }

}
