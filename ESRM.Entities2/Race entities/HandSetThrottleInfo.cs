using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class HandSetThrotthleInfo
    {
        public int ThrotthleValue { get; set; }
        public bool Braking { get; set; }
        public float BrakingAdhesionLoss { get; set; }
        public float AccelerationAdhesionLoss { get; set; }

        public HandSetThrotthleInfo(int throtthleValue)
        {
            ThrotthleValue = throtthleValue;
            Braking = false;
            BrakingAdhesionLoss = 0;
            AccelerationAdhesionLoss = 0;
        }
        public HandSetThrotthleInfo(int throtthleValue, bool braking)
        {
            ThrotthleValue = throtthleValue;
            Braking = braking;
            BrakingAdhesionLoss = 0;
            AccelerationAdhesionLoss = 0;
        }
        public HandSetThrotthleInfo(int throtthleValue, bool braking, float brakingAdhesionLoss, float accelerationAdhesionLoss)
        {
            ThrotthleValue = throtthleValue;
            Braking = braking;
            BrakingAdhesionLoss = brakingAdhesionLoss;
            AccelerationAdhesionLoss = accelerationAdhesionLoss;
        }
    }
}
