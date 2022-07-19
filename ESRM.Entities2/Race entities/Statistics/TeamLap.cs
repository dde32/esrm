using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.Entities
{
    public class TeamLap
    {
        public string TeamName
        {
            get;
            set;
        }
        public string Pilot
        {
            get;
            set;
        }

        public string TeamAndPilotName
        {
            get;
            set;
        }

        public int PilotNumber
        {
            get;
            set;
        }

        public int LapNumber
        {
            get;
            set;
        }

        public TimeSpan LapTime
        {
            get;
            set;
        }

        public int Color
        {
            get;
            set;
        }
        public double FuelPercent
        {
            get;
            set;
        }
        public double FuelConso
        {
            get;
            set;
        }
        public double TiresPercent
        {
            get;
            set;
        }
        public int Position
        {
            get;
            set;
        }

    }

}
