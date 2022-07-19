using ESRM.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public  class Tires
    {
        int _powerBaseMaxThrottleValue;
        public TireType Type { get; set; }

        protected int? _maxhealthValue;
        protected int? _healthValue;
        protected int _healthPercent;
        // santé du pneu en pourcentage
        public int Health
        {
            get { return _healthPercent; }
        }

        double? _currentWeather_MaxAcceleration;
        double? _currentWeather_BrakingDelai;
        double? _currentWeather_WearCoef;
        int? _currentWeather_BrakingInterval;

        public double CurrentWeather_MaxAcceleration
        {
            get { return _currentWeather_MaxAcceleration.HasValue ? _currentWeather_MaxAcceleration.Value : GlobalDatas.MAXACCELERATIONDELTA;  }
            set { _currentWeather_MaxAcceleration = value; }
        }
        public double CurrentWeather_BrakingDelai
        {
            get { return _currentWeather_BrakingDelai.HasValue ? _currentWeather_BrakingDelai.Value : 0; }
            set
            {
                _currentWeather_BrakingDelai = value;
                CalculateBrakingIntervalFromDelay();
            }
        }

        public double CurrentWeather_WearCoef
        {
            get { return _currentWeather_WearCoef.HasValue ? _currentWeather_WearCoef.Value : 1; }
            set { _currentWeather_WearCoef = value; }
        }

        public int CurrentWeather_BrakingInterval
        {
            get
            {
                return _currentWeather_BrakingInterval.HasValue ? _currentWeather_BrakingInterval.Value : 0;
            }
        }

        private void CalculateBrakingIntervalFromDelay()
        {
            // en mode normal on a un freinage toutes les 25 ms (latence de 16 = 40 echanges par secondes soit un échange toutes les 25 ms)
            // si on a 
            _currentWeather_BrakingInterval = (int)_currentWeather_BrakingDelai / (GlobalDatas.MAXBRAKEINTERVAL * GlobalDatas.INTERVALBETWEENTWOSIGNALS);
            if (_currentWeather_BrakingInterval > GlobalDatas.MAXBRAKEINTERVALFORTIRES)
                _currentWeather_BrakingInterval = GlobalDatas.MAXBRAKEINTERVALFORTIRES;
        }


        // valeur max de delta entre deux accélérations, modifié au fil de l'eau
        // valeur de l'accélération maximale entre deux informations envoyées à la PB.
        // exemple pour Scalex 100 % throttle = valeur de 63.
        // Quand on accélère fort on prend une valeur d'accélération de 20 environ, parfois plus (30 max d'après mes mesures) --> Avec une latency standard sur le sérial port
        // si la latency est au minimum alors on a plus d'information par secondes, dans ce cas la valeur max d'accélération entre deux infos TH est plus faible.
        // Il faudrait donc récupérer ce valleur de latency pour l'inclure dans les calculs
        // Pour le délai de freinage qui est calculé en intervalles de TH c'est pareil, plus la latence est faible plus on peut avoir d'intervalles de freinage
        // MaxAcceleration représente la valeur maximale qui sera prise en compte 
        public double MaxAcceleration { get; internal set; }
        // intervalle de temps pour appliquer un dynamic breaking
        public int BrakingIntervall { get; internal set; }
        // délai initial avant d'appliquer un dynamic braking
        public double BrakingDelai { get; set; }

        public TireTypeParams TiresParams { get; set; }



        public Tires(TireType tireType, TireTypeParams tireParams)
        {
            Type = tireType;
            TiresParams = tireParams;
            InitInstance();
            _powerBaseMaxThrottleValue = GlobalDatas.POWERBASEMAXTHROTTLEVALUE;
            MaxAcceleration = GlobalDatas.MAXACCELERATIONDELTA;
        }

        public virtual void SetPowerBaseMaxThrottleValue(int value)
        {
            _powerBaseMaxThrottleValue = value;
        }


        public void InitInstance()
        {
            if(TiresParams == null)
                TiresParams = new TireTypeParams();

            //_initialHealthValue = null;
            _healthValue = null;
            _healthPercent = 100;
            MaxAcceleration = 100;
            BrakingIntervall = 0;
            BrakingDelai = 0;
            _currentWeather_MaxAcceleration = null;
            _currentWeather_BrakingDelai = null;
            _currentWeather_WearCoef = 1;


        }

        public void ResetToInitialValue(int? initialHealthValue)
        {
            _maxhealthValue = initialHealthValue;
            _healthValue = initialHealthValue;
            _healthPercent = 100;

            _currentWeather_MaxAcceleration = null;
            _currentWeather_BrakingDelai = null;
            _currentWeather_WearCoef = 1;
            
        }

        public void InitTiresMaxHealthValueIfNeeded(int totalValue)
        {
           // if ( CurrentWeather_MaxAcceleration.HasValue && CurrentWeather_WearCoef.HasValue && CurrentWeather_BrakingDelai.HasValue)
            {
                _maxhealthValue = totalValue;
                _healthValue = totalValue;
            }
        }

        public virtual void SetCurrentWeatherConditions(WeatherConditions newWeatherConditions)
        {
            BrakingDelai = 0;
            BrakingIntervall = 0;
            MaxAcceleration = GlobalDatas.MAXACCELERATIONDELTA;

            if (newWeatherConditions == null)
            {
                CurrentWeather_MaxAcceleration = GlobalDatas.MAXACCELERATIONDELTA;
                CurrentWeather_BrakingDelai = 0;
                CurrentWeather_WearCoef = 1;
            }
            else
            {
                // Conditions humides
                if (newWeatherConditions.WetConditions)
                {
                    CurrentWeather_MaxAcceleration = TiresParams.MaxAcceleration_Wet;
                    CurrentWeather_BrakingDelai = TiresParams.BrakingDelai_Wet;
                    CurrentWeather_WearCoef = 1 + (double)TiresParams.WearDelta_Wet / 100;
                }
                // piste mouillée
                else if (newWeatherConditions.DampConditions)
                {
                    CurrentWeather_MaxAcceleration = TiresParams.MaxAcceleration_Damp;
                    CurrentWeather_BrakingDelai = TiresParams.BrakingDelai_Damp;
                    CurrentWeather_WearCoef = 1 + (double)TiresParams.WearDelta_Damp / 100;
                }
                else // conditions sèches
                {
                    // température piste froide
                    if (newWeatherConditions.TrackTemperature <= WeatherConditionsConstants.MinTemperature)
                    {
                        CurrentWeather_MaxAcceleration = TiresParams.MaxAcceleration_DryAndFreshTemp;
                        CurrentWeather_BrakingDelai = TiresParams.BrakingDelai_DryAndFreshTemp;
                        CurrentWeather_WearCoef = 1 + (double)TiresParams.WearDelta_DryAndFreshTemp / 100;

                    }
                    // température piste moyenne
                    else if (newWeatherConditions.TrackTemperature > WeatherConditionsConstants.MinTemperature &&
                             newWeatherConditions.TrackTemperature <= WeatherConditionsConstants.IntermediateTemperature)
                    {
                        CurrentWeather_MaxAcceleration = TiresParams.MaxAcceleration_DryAndMediumTemp;
                        CurrentWeather_BrakingDelai = TiresParams.BrakingDelai_DryAndMediumTemp;
                        CurrentWeather_WearCoef = 1+ (double)TiresParams.WearDelta_DryAndMediumTemp / 100;
                    }
                    // température piste chaude
                    else
                    {
                        CurrentWeather_MaxAcceleration = TiresParams.MaxAcceleration_DryAndHotTemp;
                        CurrentWeather_BrakingDelai = TiresParams.BrakingDelai_DryAndHotTemp;
                        CurrentWeather_WearCoef = 1+ (double)TiresParams.WearDelta_DryAndHotTemp / 100;
                    }
                }

                MaxAcceleration = CurrentWeather_MaxAcceleration;
                BrakingDelai = CurrentWeather_BrakingDelai;
                BrakingIntervall = CurrentWeather_BrakingInterval;
            }

        }


        public int CalculWearTotalValue(List<HandSetThrotthleInfo> throttleInfos, int startIndex, int endIndex, double fuelPercent)
        {
            int totalValue = 0;
            if (startIndex < 0 || endIndex == startIndex)
                return 0;

            // on va parcourir l'ensemble des informations en provenance du handset sur un tour pour déterminer la valeur totale des points a retrancher a l'état des pneus
            for (int i = startIndex; i < endIndex; i++)
            {
                if (i > 0)
                {
                    totalValue += CalculTiresWearValue(throttleInfos[i - 1].ThrotthleValue, throttleInfos[i - 1].Braking, throttleInfos[i].ThrotthleValue, throttleInfos[i].Braking, throttleInfos[i].AccelerationAdhesionLoss, throttleInfos[i].BrakingAdhesionLoss);
                }
                else
                    totalValue += throttleInfos[i].ThrotthleValue;
            }

            if (totalValue != 0 && _healthValue.HasValue && _maxhealthValue.HasValue && _maxhealthValue.Value > 0)
            {
                // calcul du coefficient d'usure des pneus en fonction du poids du véhicule donc en fonction du contenu du réservoir.
                // si le réservoir est à 30 % ou moins l'usure descend à 75% (usure minimale).  Il reste donc 25 % à répartir
                double weightWearCoef = fuelPercent >= 30 ? (((fuelPercent - 30) * 0.35) + 75) / 100 : 0.75;

                totalValue = (int) ((double)totalValue * CurrentWeather_WearCoef);
                _healthValue -= (int)(totalValue * weightWearCoef); // plus on est lourd plus on use le pneu

                // calcul du pourcentage d'état du pneu
                _healthPercent = (int)((double)(((double)_healthValue.Value / (double)_maxhealthValue.Value) * 100));

                // si  le pneu est en négatif, on passe tout au minimum. --> crevaison
                if (_healthPercent <= 0)
                    DoPuncture();
                else // sinon on calcule l'impact de l'usure en fonction des paramètres
                {
                    CalculMaxAccelerationAndBrakingForce();
                }
            }

            return totalValue;
        }

        private int CalculTiresWearValue(int? previousThrottle, bool previousBraking, int currentThrottle, bool braking, float accelerationAdhesionLoss, float brakeAdhesionLoss)
        {
            // a minima on ajoute au total le total TH
            int result = currentThrottle;

            // est ce qu'il y a freinage ? Un gros freinage est plus impactant qu'un roue libre ...
            // si on déclenche un gros freinage on use fort
            // si on freine on use a 
            if (brakeAdhesionLoss > 0)
                result += (int)((double)GlobalDatas.POWERBASEMAXTHROTTLEVALUE * (1 + brakeAdhesionLoss));
            else if (braking && previousThrottle.HasValue)
            {
                if (previousThrottle - currentThrottle >= GlobalDatas.DELTAFORBIGBRAKINGDETECT)
                    result = previousThrottle.Value;
            }
            else // ca roule normal
            {
                if (currentThrottle > 0 && !braking && previousThrottle.HasValue)
                {
                    // est ce qu'il y a grosse décélération si oui on use 15% de plus
                    if (previousThrottle - currentThrottle >= GlobalDatas.DELTAFORBIGBRAKINGDETECT)
                        result = (int)((double)currentThrottle * 1.15);
                    // est ce qu'il y a perte d'adhérence à l'accélération, si oui on use le pneu en proportion de la perte d'adhérence
                    else if (accelerationAdhesionLoss > 0)
                        result = (int)((double)currentThrottle * (1 + accelerationAdhesionLoss));
                    // est ce qu'il y a grosse accélération
                    else if (currentThrottle - previousThrottle >= GlobalDatas.DELTAFORBIGACCELERATIONDETECT)
                        result = (int)((double)currentThrottle * 1.15);
                }
            }

            // maintenant qu'on connait l'usure en cours on peut appliquer le coef lié au poids de l'auto via le FuelPercent
            return result;
        }

        //protected abstract double GetWeatherWearCoef(WeatherConditions weather);

        protected virtual void CalculMaxAccelerationAndBrakingForce()
        {
            int maxPerfDelta = _healthPercent - TiresParams.MaxPerformanceTreshold;

            // si on a une usure du pneu significative on va calculer l'impact sur les performances de l'auto
            if (maxPerfDelta <= 0)
            {
                // combien de pourcents d'usure en dessous du seuil avant d'appliquer une réduction d'accélération ?
                // exemple pour une accélération initiale max de 10 et un pourcentage perf max a 70
                // on fait une diminution tous les 7 pourcents d'usure au dela du seuil
                //int wearReductionInterval_Acceleration = (int)((MaxPerformanceTreshold / InitialMaxAcceleration));
                double wearReductionInterval_Acceleration = ((TiresParams.MaxPerformanceTreshold / CurrentWeather_MaxAcceleration ));
                double wearReductionInterval_BrakeForce = ((TiresParams.MaxPerformanceTreshold / GlobalDatas.MAXBRAKEINTERVAL));

                // combien d'unités d'accélération à retirer de l'accélération max
                int accelerationReduction = (int)((double)maxPerfDelta / wearReductionInterval_Acceleration) * -1;
                int brakeForceReduction = (int)((double)maxPerfDelta / wearReductionInterval_BrakeForce) * -1;

                MaxAcceleration = CurrentWeather_MaxAcceleration  - accelerationReduction; // accélération Max = Initiale - la réduction a appliquer en fonction de l'usure

                if (MaxAcceleration <= 0)
                    MaxAcceleration = 1;

                BrakingIntervall = CurrentWeather_BrakingInterval + brakeForceReduction;
            }
        }




        public void DoPuncture()
        {
            _healthValue = 0;
            _healthPercent = 0;
            BrakingIntervall = GlobalDatas.MAXBRAKEINTERVAL;
            MaxAcceleration = 1;
        }

        public void AddTireHealth(int value)
        {
            _healthPercent += value;
            if (_healthPercent > 100)
                _healthPercent = 100;
        }
        public void SetHealthToZeroForPitStop()
        {
            _healthPercent = 0;
        }

    }


    //#region TIRES TYPES

    //public class WetTires : Tires
    //{
    //    public override TireType Type
    //    {
    //        get { return TireType.Wet; }
    //    }
    //}

    //public class IntermediateTires : Tires
    //{
    //    public override TireType Type
    //    {
    //        get { return TireType.Intermediate; }
    //    }
    //}

    //public class HardTires : Tires
    //{
    //    public override TireType Type
    //    {
    //        get { return TireType.Hard; }
    //    }
    //    //protected override double GetWeatherWearCoef(WeatherConditions weather)
    //    //{
    //    //    return 1;
    //    //}
    //}

    //public class MediumTires : Tires
    //{
    //    public override TireType Type
    //    {
    //        get { return TireType.Medium; }
    //    }
    //}

    //public class SoftTires : Tires
    //{
    //    public override TireType Type
    //    {
    //        get { return TireType.Soft; }
    //    }
    //}

    //#endregion TIRES TYPES

    public class TiresManager
    {
        Dictionary<TireType, TireTypeParams> _paramsByType;
        bool _isInit;

        private static TiresManager instance;

        private TiresManager()
        {
            _isInit = false;
            _paramsByType = null;
        }

        public static TiresManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TiresManager();
                }
                return instance;
            }
        }

        public void InitParameters(Dictionary<TireType, TireTypeParams> paramsByType)
        {
            _isInit = true;
            _paramsByType = paramsByType;
        }
      

        public Tires GetNewtTires(TireType type)
        {
            if (!_isInit)
                throw new Exception("Tires Manager Not initialised");

            return new Tires(type, _paramsByType[type]);
        }

        public Tires GetNextTires(TireType currentType)
        {
            if (!_isInit)
                throw new Exception("Tires Manager Not initialised");


            int nextcurrentType = (int)currentType + 1;
            if (nextcurrentType > (int)TireType.Wet)
                nextcurrentType = 0;

            return new Tires((TireType)nextcurrentType, _paramsByType[(TireType)nextcurrentType]);
        }

        //public static Tires GetNextTires(TireType currentType,TireTypeParams tireParams)
        //{
        //    int nextcurrentType = (int)currentType + 1;
        //    if (nextcurrentType > (int)TireType.Wet)
        //        nextcurrentType = 0;

        //    switch((TireType)nextcurrentType)
        //    {
        //        case TireType.Hard:
        //            return new HardTires(tireParams);
        //        case TireType.Medium:
        //            return new MediumTires(tireParams);
        //        case TireType.Soft:
        //            return new SoftTires(tireParams);
        //        case TireType.Intermediate:
        //            return new IntermediateTires(tireParams);
        //        case TireType.Wet:
        //            return new WetTires();
        //        default: return new MediumTires(tireParams);
        //    }
        //}

        //public static Tires GetNewTires(TireType currentType)
        //{
        //    switch ((TireType)currentType)
        //    {
        //        case TireType.Hard:
        //            return new HardTires(tireParams);
        //        case TireType.Medium:
        //            return new MediumTires(tireParams);
        //        case TireType.Soft:
        //            return new SoftTires();
        //        case TireType.Intermediate:
        //            return new IntermediateTires(tireParams);
        //        case TireType.Wet:
        //            return new WetTires(tireParams);
        //        default: return new MediumTires(tireParams);
        //    }
        //}
    }
}
