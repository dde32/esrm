using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class GameTime
    {
        public int TimerValue { get; set; }
        public TimeSpan GameTimeSpan { get; set; }

        public GameTime(byte[] data)
        {
            if (data.Length != 4)
                throw new Exception();
            //convert to counter
            BitArray bData = new BitArray(data);
            TimerValue = getIntFromBitArray(bData);
            //calculate time
            //6.4uSec x value = seoncs
            GameTimeSpan = new TimeSpan(0, 0, 0, 0, (int)Math.Round((0.0064 * TimerValue), 0));
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
