using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
   
    public class Pilot
    {
        public string Name
        {
            get;
            set;
        }

        public string Group
        {
            get;
            set;
        }

        public int MaxPowerPercent
        {
            get;
            set;
        }

        public double FuelHandicap
        {
            get;
            set;
        }

        public double DamagesHandicap
        {
            get;
            set;
        }

        public bool UseDynamicBrake
        {
            get;
            set;
        }
        public int BrakeLimitation
        {
            get;
            set;
        }

        public int Color
        {
            get;
            set;
        }

        public double VibrationLevel
        {
            get;
            set;
        }
        public double VibrationTriggerLevel
        {
            get;
            set;
        }

        public List<string> FavoriteHandSetCurvesTitles
        {
            get;
            set;
        }

        public List<string> FavoriteGamePadBrakeCurvesTitles
        {
            get;
            set;
        }
        public List<string> FavoriteGamePadThrottleCurveTitles
        {
            get;
            set;
        }
        public List<string> FavoriteGamePadInCarProBrakeCurveTitles
        {
            get;
            set;
        }

        public int Brake
        {
            get { return 6 - BrakeLimitation; }
            set { BrakeLimitation = 6 - value; }
        }
        
        public string FuelHandicapForUI
        {
            get { return string.Format("{0}%", (FuelHandicap) * 100); }
        }

        public string DamagesHandicapForUI
        {
            get { return string.Format("{0}%", (DamagesHandicap) * 100); }
        }


        public double ConsommationForUI
        {
            get { return (1 - FuelHandicap) * 100; }
            set { FuelHandicap = (1 - value) / 100; }
        }


        public Byte[] Image
        {
            get;
            set;
        }

        public HandsetThrottleCurve HandsetThrottleCurve { get; set; }
        public GamePadThrottleCurve GamePadThrottleCurve { get; set; }
        public GamePadThrottleCurve GamePadBrakeCurve { get; set; }
        public GamePadThrottleCurve GamePadInCarProBrakeCurve { get; set; }

        [IgnoreDataMember]
        public List<HandsetThrottleCurve> FavoriteHandsetThrottleCurve
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public List<GamePadThrottleCurve> FavoriteGamePadBrakeCurves
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public List<GamePadThrottleCurve> FavoriteGamePadThrottleCurve
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public List<GamePadThrottleCurve> FavoriteGamePadInCarProBrakeCurve
        {
            get;
            set;
        }


        [IgnoreDataMember]
        public string MaxPowerText
        {
            get { return Textes.MaxPower; }
        }

        [IgnoreDataMember]
        public string BrakeSoftText
        {
            get { return Textes.Brake; }
        }

        [IgnoreDataMember]
        public string UseDynamicBrakeText
        {
            get { return Textes.DynamicBrake; }
        }
        [IgnoreDataMember]
        public string VibrationText
        {
            get { return Textes.Vibrations; }
        }

        [IgnoreDataMember]
        public string TriggerVibrationText
        {
            get { return Textes.TriggerVibrations; }
        }

        public Pilot()
        {
            Name = "Pilote";
            FuelHandicap = 0;
            DamagesHandicap = 0;
            MaxPowerPercent = 100;
            BrakeLimitation = 0;
            Color = 0xFFFFFF;
            UseDynamicBrake = false;
            VibrationLevel = 100;
            VibrationTriggerLevel = 100;

            FavoriteGamePadBrakeCurvesTitles = new List<string>();
            FavoriteGamePadInCarProBrakeCurveTitles = new List<string>();
            FavoriteGamePadThrottleCurveTitles = new List<string>();
            FavoriteHandSetCurvesTitles = new List<string>();

            FavoriteGamePadBrakeCurves = new List<GamePadThrottleCurve>();
            FavoriteGamePadInCarProBrakeCurve = new List<GamePadThrottleCurve>();
            FavoriteGamePadThrottleCurve = new List<Entities.GamePadThrottleCurve>();
            FavoriteHandsetThrottleCurve = new List<HandsetThrottleCurve>();
        }
    }
}
