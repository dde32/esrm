using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class OperationMode
    {
        public bool Success { get; set; }
        public bool IsDrivePacket { get; set; }

        public OperationMode(byte data)
        {
            if (data == 255)
            {
                Success = true;
                IsDrivePacket = true;
            }
            else if (data == 127)
            {
                Success = false;
                IsDrivePacket = false;
            }
            else if (data == 191)
            {
                Success = true;
                IsDrivePacket = false;
            }
            else
                throw new Exception();
        }

        public byte ToByte()
        {
            if (Success && IsDrivePacket)
                return 255; //or byte version
            else if (Success && !IsDrivePacket)
                return 191; //or byte version
            else
                return 127; //or byte version
        }
    }
}
