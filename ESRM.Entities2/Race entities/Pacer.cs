using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    enum _BoostSequenceEnum
    {
        None = 0,
        ASAP = 1,
        ReadyToGo = 2,
        InProgress = 3,
        Passed = 4,
    }

    [DataContract]
    public class Pacer
    {
        int _countDownConstantPacerLaps;
        int _countTHInfosInCurrentLap;
        int _countTHInfosInLap;
        int _idxForInconstantBoost;
        int _THCountBeforeBoost; // doit obligatoirement être initialisé en amont
        _BoostSequenceEnum _boostPacer;
        int? _boostPower;
        
        int _pacerPowerThrottle;

        [DataMember]
        public int PacerPowerPercent
        {
            get;set;
        }

        [IgnoreDataMember]
        private bool ForceConstantPacer
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public bool IsRecordingLapThrothlesInfo
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan LapTarget
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public double ThrotthleAdjustCoef
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public List<HandSetThrotthleInfo> LapThrotlesInfos_Initial
        {
            get;
            set;
        }

        public List<HandSetThrotthleInfo> LapThrotlesInfos_FirstLap
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TeamInRace ParentTeam
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public int LapThrotlesInfosCurrentIdx
        {
            get;
            set;
        }

        public int? StartPower
        {
            get;set;
        }


        public Pacer(TeamInRace team)
        {
            ParentTeam = team;
            Reset();
        }

        public void Reset()
        {
            _boostPacer = _BoostSequenceEnum.None;
            _countDownConstantPacerLaps = 2;
            _countTHInfosInCurrentLap = 0;
            _idxForInconstantBoost = 0;
            if (!_boostPower.HasValue)
                _boostPower = StartPower;
            LapThrotlesInfosCurrentIdx = 0;
            _countTHInfosInLap = 0;
            ForceConstantPacer = false;
        }

        public void SetPacerPowerThrottle(int PowerBaseMaxThrottleValue)
        {
            _pacerPowerThrottle = (int)(((PacerPowerPercent * PowerBaseMaxThrottleValue) / 100));
        }

        public void GetThrottleValue(out int resultThrottle, out CantBrakeEnum needBraking)
        {
            resultThrottle = _pacerPowerThrottle;
            needBraking = CantBrakeEnum.NoBrakeWanted;

            if (ParentTeam == null || ParentTeam.Race == null)
                return;


            //si la course est en drapeau jaune et qu'un YF signifie un arrêt total des voitures, il faut aussi l'appliquer au pacers
            if (ParentTeam.Race.YellowFlag)
            {
                if (ParentTeam.Race.RaceParams.DigitalParams.MaxPowerOnYellowFlag == 0)
                    resultThrottle = 0;
                else
                    resultThrottle = (int)((double)_pacerPowerThrottle * 0.8); // pour ne pas risquer d'avoir un pacer immobile on va juste le pénaliser de 20 % pendant un drapeau jaune.
            }
            else
            {
                    _countTHInfosInCurrentLap++;

                // PACER à "tour variable" et que le mode constant n'est pas forcé on va chercher la bonne information de TH
                if (LapThrotlesInfos_Initial != null && LapThrotlesInfos_Initial.Count > 0 && !ForceConstantPacer)
                {
                    // on a pas encore passé la ligne de départ donc pas encore entamé l'utilisation des bonnes infos de TH
                    if (StartPower.HasValue && !ParentTeam.PassedFirstTime)
                    {
                        resultThrottle = StartPower.Value;
                    }
                    // pour le moment l'algo de création d'infos de premier tour n'est pas super fiable.
                    // du coup on commente tout ça le temps de le mettre au point, si nécesaire.
                    //
                    //else if(ParentTeam.PassedFirstTime && ParentTeam.IsInFirstLap && LapThrotlesInfos_FirstLap != null)
                    //{
                    //    if (LapThrotlesInfos_FirstLap.Count > LapThrotlesInfosCurrentIdx) // si on dispose toujours d'une info de TH on l'utilise
                    //    {
                    //        resultThrottle = LapThrotlesInfos_FirstLap[LapThrotlesInfosCurrentIdx].ThrotthleValue;
                    //        needBraking = LapThrotlesInfos_FirstLap[LapThrotlesInfosCurrentIdx].Braking;
                    //        LapThrotlesInfosCurrentIdx++;
                    //    }
                    //    else // Si on a terminé l'utilisation des infos dispo on passe temporairement en mode constant
                    //        resultThrottle = _pacerPowerThrottle;
                    //}
                    else
                    {
                        if (LapThrotlesInfos_Initial.Count > LapThrotlesInfosCurrentIdx) // si on dispose toujours d'une info de TH on l'utilise
                        {
                            resultThrottle = LapThrotlesInfos_Initial[LapThrotlesInfosCurrentIdx].ThrotthleValue;

                            // ajustement de la vitesse, on n'applique le coeficient que sur les valeurs non extrèmes
                            if (resultThrottle > 5 && resultThrottle < 55)
                                resultThrottle = (int)(resultThrottle * ThrotthleAdjustCoef);
                            needBraking = LapThrotlesInfos_Initial[LapThrotlesInfosCurrentIdx].Braking ? CantBrakeEnum.CanBrake : CantBrakeEnum.NoBrakeWanted;
                            LapThrotlesInfosCurrentIdx++;
                        }
                        else // Si on a terminé l'utilisation des infos dispo on passe temporairement en mode constant
                        {
                            // ici on pourrait essayer de faire un truc plus intelligent en utilisant par exemple une prolongation des dernières infos du tour
                            resultThrottle = _pacerPowerThrottle;
                        }
                    }
                }
                else // mode constant
                {
                    // si on est en fin de tour de pacer constant forcé, on lance le boost pour relancer le pacer sur son tour variable
                    if ((_boostPacer == _BoostSequenceEnum.ReadyToGo && _idxForInconstantBoost > 0 && _idxForInconstantBoost <= _countTHInfosInCurrentLap ) || _boostPacer == _BoostSequenceEnum.InProgress)
                    {
                        _boostPacer = _BoostSequenceEnum.InProgress;
                        resultThrottle = _boostPower.HasValue ? _boostPower.Value : _pacerPowerThrottle;
                    }
                    else   // mode constant
                        resultThrottle = _pacerPowerThrottle;
                }
            }
        }

        #region GESTION DU PASSAGE EN MODE CONSTANT PUIS REPASSAGE EN VARIABLE

        public void TestBoostPacer(int THCountBeforeBoost, int boostPower)
        {
            _THCountBeforeBoost = THCountBeforeBoost;
            _boostPower = boostPower;
        }

        public void BeginConstantPacer()
        {
            ForceConstantPacer =  true;
            // il y a eu un incident sur la course (accident du pacer ou d'une autre team, pause etc.)
            // on va passer en mode pacer constant le temps d'avoir suffisament d'information pour relancer le pacer en mode variable.
            // le principe est de faire au moins un tour complet en mode pacer constant afin de déterminer le nombre de TH que l'on va consommer.
            // une fois que l'on a ce nombre, on attend d'etre X TH avant pour remplacer la valeur constante
            // par une valeur proche de celle de StartPower qui va permettre de relancer un vrai tour variable

            _boostPacer = _BoostSequenceEnum.None;
            _countDownConstantPacerLaps = 2;
            _countTHInfosInCurrentLap = 0;
            _idxForInconstantBoost = 0;
            if (!_boostPower.HasValue)
                _boostPower = StartPower;

            LapThrotlesInfosCurrentIdx = 0;

            // pour le moment on refait le calcul à chaque nouvel incident, mais on pourrait éventuellement
            // partir du principe qu'une fois l'info calculée on peut la conserver et l'utiliser ultérieurement
            _countTHInfosInLap = 0;
        }

        public void CanStopConstantPacer()
        {
            // a partir du moment ou on donne le feu vert pour repasser en mode variable on va positionner le flag nécesaire
            if (_idxForInconstantBoost > 0)
                _boostPacer = _BoostSequenceEnum.ReadyToGo;
            else
                _boostPacer = _BoostSequenceEnum.ASAP;
        }

        public void EndOfLap(TimeSpan lapTime)
        {
            // supprimé car désormais le laptarget est obligatoirement fixé par UI 
            //if (LapTarget.TotalMilliseconds == 0)
            //    LapTarget = lapTime;

            ThrotthleAdjustCoef = 1;
            // si le pacer est en mode enregistrement de tour, ou qu'on est en mode constant forcé on ne calcule pas le coef d'ajustement
            if(!IsRecordingLapThrothlesInfo && !ForceConstantPacer)
              UpdateThrottleAdjustCoef(lapTime);

            // si on est en mode pacer constant forcé mais que l'on est un pacer variable
            if(ForceConstantPacer && LapThrotlesInfos_Initial != null && LapThrotlesInfos_Initial.Count > 0)
            {
                 // si on a terminé un tour complet (on est passé au moins deux fois sur la ligne depuis le forceConstant)
                // on mémorise le nombre de TH nécessaire pour boucler un tour.
                _countDownConstantPacerLaps--;
                if (_countDownConstantPacerLaps == 0)
                {
                    _countTHInfosInLap = _countTHInfosInCurrentLap;
                    _idxForInconstantBoost = _countTHInfosInLap - _THCountBeforeBoost;
                    _boostPacer = _BoostSequenceEnum.ReadyToGo;
                }

                _countTHInfosInCurrentLap = 0;
            }
            // si on est un pacer constant, on ajuste pas en fonction du coef mais simplement en ajoutant ou retirant a la consigne
            else if(LapThrotlesInfos_Initial == null || LapThrotlesInfos_Initial.Count == 0)
            {
                if (lapTime.TotalMilliseconds > LapTarget.TotalMilliseconds * 1.02)
                    _pacerPowerThrottle++;
                else if (lapTime.TotalMilliseconds < LapTarget.TotalMilliseconds * 0.98)
                    _pacerPowerThrottle--;
            }

            // si on passe sur la ligne alors qu'on était en mode boost (redémarrage de tour variable)
            // on va sortir du mode pacer constant et initialiser toutes les variables liées au pacer constant
            if (_boostPacer == _BoostSequenceEnum.InProgress) 
            {
                _boostPacer = _BoostSequenceEnum.Passed;
                ForceConstantPacer = false;
                _idxForInconstantBoost = 0;
                _countTHInfosInLap = 0;
                _countTHInfosInCurrentLap = 0;
                _countDownConstantPacerLaps = 2;
            }
        }

        #endregion GESTION DU PASSAGE EN MODE CONSTANT PUIS REPASSAGE EN VARIABLE



        public void UpdateThrottleAdjustCoef(TimeSpan lapTime)
        {
            if (LapTarget.TotalMilliseconds == 0)
                return;

            // Attention, si le tour que l'on vient de terminer à été touché par une pause ou un YF le coef ne doit pas être ajusté sinon on va se retrouver avec une valeur de ouf 
            ThrotthleAdjustCoef = Math.Round((double)lapTime.TotalMilliseconds / LapTarget.TotalMilliseconds, 3);
            if (ThrotthleAdjustCoef > 1.1) //  pas d'accélération démesurée. (pas plus de 10%)..
                ThrotthleAdjustCoef = 1.1;
            else if (ThrotthleAdjustCoef < 0.9) //  pas d'accélération démesurée. (pas plus de 10%)..
                ThrotthleAdjustCoef = 0.9;
            else
                ThrotthleAdjustCoef = 1;

        }


        #region TRAITEMENT POUR LA GESTION DU TOUR VARIABLE

        public static void ClearBeginOfLap(List<HandSetThrotthleInfo> originalsThInfos, int minValue)
        {
            while (originalsThInfos[0].ThrotthleValue <= minValue)
            {
                originalsThInfos.RemoveAt(0);
            }
        }

        public static void ClearEndOfLap(List<HandSetThrotthleInfo> originalsThInfos, int minValue)
        {
            while (originalsThInfos[originalsThInfos.Count - 1].ThrotthleValue <= minValue)
            {
                originalsThInfos.RemoveAt(originalsThInfos.Count - 1);
            }
        }

        public static int CalculStartPowerFromLastMaxTh(List<HandSetThrotthleInfo> originalsThInfos,int lastCount)
        {
            if (originalsThInfos != null && originalsThInfos.Count > lastCount)
            {
                List<HandSetThrotthleInfo> tmp = originalsThInfos.GetRange(originalsThInfos.Count - lastCount - 1, lastCount);
                return tmp.Max(th => th.ThrotthleValue);
            }
            else
                return 0;
        }

        public static int CalculStartPowerFromLastAverageTh(List<HandSetThrotthleInfo> originalsThInfos,int lastCount)
        {
            if (originalsThInfos != null && originalsThInfos.Count > lastCount)
            {
                List<HandSetThrotthleInfo> tmp = originalsThInfos.GetRange(originalsThInfos.Count - lastCount - 1, lastCount);
                return (int)tmp.Average(th => th.ThrotthleValue);
            }
            else
                return 0;
        }

        public static List<HandSetThrotthleInfo> TestLissageLapThrottleInfos(List<HandSetThrotthleInfo> originalsThInfos,int startPower)
        {
            // si on considère ou déclare que la ligne n'est pas sur une zone de freinage il n'y a pas de raison
            // surtout au premier tour, pour que les valeurs de départ soient moint importantes que les valeurs de fin.
            // si on rencontre ce cas c'est lié au fait que le tour lancé est très différent d'un tour départ arrété
            // donc on va calculer des infos de TH pour le premier tour qui seront un peu différentes par rapport à celles d'un tour lancé
            List<HandSetThrotthleInfo>  newThsInfos = new List<HandSetThrotthleInfo>();
            newThsInfos.AddRange(originalsThInfos);
            int lastValueBeforeLane = newThsInfos[newThsInfos.Count - 1].ThrotthleValue;

            int i = 0;
            while (newThsInfos[i].ThrotthleValue < lastValueBeforeLane)
            {
                newThsInfos[i] = newThsInfos[newThsInfos.Count - 1];
                i++;
            }

            for(int i2 = newThsInfos.Count - 1; i2 > newThsInfos.Count - 11;i--)
            {
                newThsInfos[i].ThrotthleValue = startPower;
            }

            return newThsInfos;

        }
        #endregion TRAITEMENT POUR LA GESTION DU TOUR VARIABLE

    }
}
