using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class TireTypeParams
    {
        public int MaxPerformanceTreshold { get; set; }

        public double MaxAcceleration_DryAndFreshTemp { get; set; }
        public double MaxAcceleration_DryAndMediumTemp { get; set; }
        public double MaxAcceleration_DryAndHotTemp { get; set; }
        public double MaxAcceleration_Damp { get; set; }
        public double MaxAcceleration_Wet { get; set; }
        public int BrakingDelai_DryAndFreshTemp { get; set; }
        public int BrakingDelai_DryAndMediumTemp { get; set; }
        public int BrakingDelai_DryAndHotTemp { get; set; }
        public int BrakingDelai_Damp { get; set; }
        public int BrakingDelai_Wet { get; set; }

        public int WearDelta_DryAndFreshTemp { get; set; }
        public int WearDelta_DryAndMediumTemp { get; set; }
        public int WearDelta_DryAndHotTemp { get; set; }
        public int WearDelta_Damp { get; set; }
        public int WearDelta_Wet { get; set; }
    }
}
