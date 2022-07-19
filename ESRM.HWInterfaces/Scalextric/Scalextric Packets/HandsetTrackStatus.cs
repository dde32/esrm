using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class HandsetTrackStatus
    {
        public bool Power { get; set; }
        public bool Handset1 { get; set; }
        public bool Handset2 { get; set; }
        public bool Handset3 { get; set; }
        public bool Handset4 { get; set; }
        public bool Handset5 { get; set; }
        public bool Handset6 { get; set; }

        public HandsetTrackStatus(byte data)
        {
            BitArray bData = new BitArray(new byte[] { data });
            if (bData.Count != 8)
                throw new Exception();
            Power = bData[0];
            Handset1 = bData[1];
            Handset2 = bData[2];
            Handset3 = bData[3];
            Handset4 = bData[4];
            Handset5 = bData[5];
            Handset6 = bData[6];
        }
    }
}
