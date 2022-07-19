using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class AuxPortCurrent
    {
        public int Current { get; set; }

        public AuxPortCurrent(byte data)
        {
            Current = data;
        }
    }
}
