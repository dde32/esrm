using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class Team
    {
        private Pilot _p1;
        private Pilot _p2;
        private Pilot _p3;
        private string _name;


        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public virtual Pilot Pilot1
        {
            get { return _p1; }
            set
            {
                _p1  =  value;
                PilotsChanged();              
            }

        }

        [DataMember]
        public virtual Pilot Pilot2
        {
            get { return _p2; }
            set
            {
                _p2 = value;
                PilotsChanged();
            }
        }

        [DataMember]
        public virtual Pilot Pilot3
        {
            get { return _p3; }
            set
            {
                _p3 = value;
                PilotsChanged();
            }
        }

        [DataMember]
        public int Color
        {
            get;
            set;
        }

        [DataMember]
        public int Id
        {
            get; set;
        }

        [DataMember]
        public EsrmPlayerIndex? UseGamePadPlayerIndex
        {
            get; set;
        }
        

        public Team()
        {
            _name = "Team";
        }

        public virtual void PilotsChanged()
        {
        }

        public virtual void SetName(string name)
        {
            _name = name;

        }
    }
}
