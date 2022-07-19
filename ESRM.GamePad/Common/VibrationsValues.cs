using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.GamePads.Common
{
    public class VibrationValues
    {
        public double LeftValue { get; set; }
        public double RightValue { get; set; }
        public double LeftTriggerValue { get; set; }
        public double RightTriggerValue { get; set; }
        public int Duration { get; set; }
        public int RepeatCount { get; set; }
        public bool HasOnePositive
        {
            get { return LeftValue > 0 || RightValue > 0 || LeftTriggerValue > 0 || RightTriggerValue > 0; }
        }

        public VibrationValues()
        {
            LeftValue = 0;
            RightValue = 0;
            LeftTriggerValue = 0;
            RightTriggerValue = 0;
            Duration = 1000;
            RepeatCount = 0;
        }
        public VibrationValues(double leftValue, double rightValue, double leftTriggerValue, double rightTriggerValue)
        {
            LeftValue = leftValue;
            RightValue = rightValue;
            LeftTriggerValue = leftTriggerValue;
            RightTriggerValue = rightTriggerValue;
        }

        public VibrationValues(double leftValue, double rightValue, double leftTriggerValue, double rightTriggerValue, int duration)
        {
            LeftValue = leftValue;
            RightValue = rightValue;
            LeftTriggerValue = leftTriggerValue;
            RightTriggerValue = rightTriggerValue;
            Duration = duration;
        }

        public void Normalize(double level, double triggerLevel)
        {
            LeftValue = LeftValue <= 1 ? LeftValue  * (level/100) : 1 * (level/100);
            RightValue = RightValue <= 1 ? RightValue * (level / 100) : 1 * (level / 100);
            LeftTriggerValue = LeftTriggerValue <= 1 ? LeftTriggerValue * (triggerLevel/100) : 1 * (triggerLevel / 100);
            RightTriggerValue = RightTriggerValue <= 1 ? RightTriggerValue * (triggerLevel / 100) : 1 * (triggerLevel / 100);
        }
    }
}
