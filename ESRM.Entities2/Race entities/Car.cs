using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    public class Car
    {
        protected int? _initialTiresHealthValue; // Total d'unité de vie du pneu, valeur initialisée lors du premier tour de course

        public string Name
        {
            get; set;
        }

        public int Number
        {
            get;
            set;
        }

         public Byte[] Image
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

        public int BrakeLimitation
        {
            get;
            set;
        }
        public string Group
        {
            get;
            set;
        }

        public int Color
        {
            get;
            set;
        }

        public bool InCarPro
        {
            get; set;
        }

        public string DescriptionForUI
         {
             get { return string.Format("{0} #{1}", Name, Number); }
         }

        public int Brake
        {
            get { return 6 - BrakeLimitation; }
            set { BrakeLimitation = 6 - value; }
        }

        //public double BrakeForUI
        //{
        //    get { return 100 - (15 * BrakeLimitation); }
        //    set { BrakeLimitation = (int)((100 - value) / 15); }
        //}

        public double ConsommationForUI
         {
            get { return (1 - FuelHandicap) * 100; }
            set { FuelHandicap = (100 - value) / 100; }
        }

        public double ResistanceForUI
        {
            get { return (1 - DamagesHandicap) * 100; }
            set { DamagesHandicap = (100 - value) / 100; }
        }

        public int? InitialTiresHealthValue
        {
            get { return _initialTiresHealthValue; } 
        }


        [IgnoreDataMember]
        public Tires Tires
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public bool IsBreakDown
        {
            get { return OutOfFuel || OutOfHealth || OutOfTires; }
        }

        [IgnoreDataMember]
        public bool LowTires
        {
            get { return Tires.Health <= GlobalDatas.LOWTIRESLEVEL; }
        }

        [IgnoreDataMember]
        public bool OutOfTires
        {
            get { return Tires.Health == 0; }
        }


        [IgnoreDataMember]
        public bool LowFuel
        {
            get { return FuelPercent <= GlobalDatas.LOWFUELLEVEL; }
        }

        [IgnoreDataMember]
        public bool OutOfFuel
        {
            get { return FuelPercent <= 0; }
        }

        [IgnoreDataMember]
        public bool LowHealth
        {
            get { return CarHealthPercent <= GlobalDatas.LOWHEALTHLEVEL; }
        }

        [IgnoreDataMember]
        public bool OutOfHealth
        {
            get { return CarHealthPercent <= 0; }
        }


        [IgnoreDataMember]
        public double TiresWearPercent
        {
            get { return Tires.Health; }
        }

        [IgnoreDataMember]
        public double FuelTank
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public double FuelPercent
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public double CarHealthPercent
        {
            get;
            set;
        }

        public Car() 
        {
            FuelHandicap = 0;
            DamagesHandicap = 0;
            MaxPowerPercent = 100;
            BrakeLimitation = 0;
            Tires = TiresManager.Instance.GetNewtTires(TireType.Medium);
            Name = string.Empty;
            _initialTiresHealthValue = null;
            Color = 0xFFFFFF;
        }

        public Car(TireType newTireType)
        {
            FuelHandicap = 0;
            DamagesHandicap = 0;
            MaxPowerPercent = 100;
            BrakeLimitation = 0;
            Tires = TiresManager.Instance.GetNewtTires(newTireType);
            Name = string.Empty;
            _initialTiresHealthValue = null;
            Color = 0xFFFFFF;
        }

        public void Reset()
        {
            _initialTiresHealthValue = null;
            Tires.ResetToInitialValue(_initialTiresHealthValue);
        }


        public void InitTiresPotentielIfNeeded(int totalValue)
        {
            if (! InitialTiresHealthValue.HasValue )
            {
                // valeur de référence pour un tour
                _initialTiresHealthValue = totalValue;

                Tires.InitTiresMaxHealthValueIfNeeded(totalValue);
            }
        }

        public void ChangeTires(TireType newTireType,WeatherConditions weatherConditions)
        {
            Tires = TiresManager.Instance.GetNewtTires(newTireType);

            if(_initialTiresHealthValue.HasValue)
                Tires.InitTiresMaxHealthValueIfNeeded(_initialTiresHealthValue.Value);

            Tires.SetCurrentWeatherConditions(weatherConditions);
        }

        public void GetThrottleValue(double maxPowerCoef, int throtlleValue, int previousThrottleInfo, out int resultThrottle,out float adhesionLossLevel, bool checkForAdhesionLoss)
        {
            resultThrottle = (int)(throtlleValue * maxPowerCoef);
            adhesionLossLevel = 0;

            // on regarde si l'accélération Max des pneus n'est pas dépassée
            // si c'est le cas on limite l'accélération
            int delta = resultThrottle - previousThrottleInfo;

            if (checkForAdhesionLoss && delta > 0 && delta > Tires.MaxAcceleration)
            {
                adhesionLossLevel = (float) (((double)delta / (double)Tires.MaxAcceleration) -1);
                if (adhesionLossLevel > 0)
                {
                    // si c'est le cas on limite la vitesse a cause de la perte d'adhérence
                    if (adhesionLossLevel >= 1)
                    {
                        adhesionLossLevel = 1;
                        // si on a une perte d"adhérence max, on accélère au minimum.
                        resultThrottle = previousThrottleInfo + 1;
                    }
                    else
                    {
                        // sinon on a une perte d'adhésion partielle, du coup le resultat de l'accélération 
                        // est calcula par rapport l'accélération max et au pourcentade de perte d'adhérence.
                        resultThrottle = (int)(previousThrottleInfo + ((1- adhesionLossLevel)*Tires.MaxAcceleration));
                    }
                }
                else
                    resultThrottle = (int)(previousThrottleInfo + Tires.MaxAcceleration);
            }

        }
    }
}
