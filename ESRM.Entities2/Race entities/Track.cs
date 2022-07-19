using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class Track
    {
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public double Length
        {
            get;
            set;
        }
    }
}
