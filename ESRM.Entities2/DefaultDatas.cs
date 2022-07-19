using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public static class DefaultDatas
    {

        static public RaceParameters GetDefaultRaceParameters(RaceType raceType,Track track,IDigitalParamsBase digitalParams)
        {
            RaceParameters result = new RaceParameters(digitalParams);
            if (track == null)
            {
                result.Track = new Track();
                result.Track.Name = Textes.DefaultTrack;
            }
            else
                result.Track = track;

            //result.PilotPerTeam = 1;
            result.RaceType = raceType;
            result.FuelImpact = true;
            result.Damages = DamagesEnum.Both;

            if (result.RaceType == RaceType.GP)
            {
                result.Title = Textes.GrandPrix;
                result.LapCount = 20;
                result.TimeLimit = null;

            }
            else if (result.RaceType == RaceType.Endurance)
            {
                result.Title = Textes.Endurance;
                result.LapCount = null;
                result.TimeLimit = new TimeSpan(0,2,0); // 2 minutes
            }
            else if (result.RaceType == RaceType.Practice)
            {
                result.Title = Textes.Practice;
                result.LapCount = 20;
                result.TimeLimit = null;
            }
            else if (result.RaceType == RaceType.TimeAttack)
            {
                result.Title ="Time Attack";
            }
            else if (result.RaceType == RaceType.Qualification)
            {
                result.Title = "Qualification";
                result.LapCount = null;
            }
            result.RollingStart = false;
            result.RollingStartLapCount = 0;
            result.MandatoryPitStopCount = 0;
            result.MinLapTimeSeconds = 2;
            result.MaxRepairPercent = 100;
            result.DeSlotAutoDetectDelay= 0;
            result.RefuelSpeed = 15;
            result.RepairSpeed = 15;

            return result;

        }

        static public Race GetDefaultRaceFromParameters(RaceParameters parameters, List<TeamInRace> defaultTeams = null)
        {
            Race Race = null;

            if (parameters.RaceType == RaceType.GP)
                Race = new GPRace(parameters);
            else if (parameters.RaceType == RaceType.Endurance)
                Race = new EnduranceRace(parameters);
            else if (parameters.RaceType == RaceType.Practice)
                Race = new PracticeRace(parameters);
            else if (parameters.RaceType == RaceType.TimeAttack)
                Race = new TimeAttackRace(parameters);
            else if (parameters.RaceType == RaceType.Qualification)
                Race = new Qualification(parameters);
            else if (parameters.RaceType == RaceType.RallyCross)
                Race = new RallyCrossRace(parameters);

            //Race.RaceParams = parameters;
   
            return Race;
        }

        static public TeamInRace  GetDefaultTeamInRace(int teamId,int pilotPerTeam)
        {
            TeamInRace newTeam = new TeamInRace();
            newTeam.Id = teamId;
            newTeam.SetName(string.Format("Team {0}", teamId));
            newTeam.Pilot1 = new Pilot();
            newTeam.Pilot1.Name = "Pilot 1";
            if (pilotPerTeam > 1)
            {
                newTeam.Pilot2 = new Pilot();
                newTeam.Pilot2.Name = "Pilot 2";
            }
            if (pilotPerTeam == 3)
            {
                newTeam.Pilot3 = new Pilot();
                newTeam.Pilot3.Name = "Pilot 3";
            }
            newTeam.CurrentPilot = newTeam.Pilot1;
            return newTeam;
        }


        static public GamePadThrottleCurve GetDefaultGamepadThrottleCurve()
        {
            GamePadThrottleCurve thCurve = new GamePadThrottleCurve();
            thCurve.Title = "Default";
            thCurve.InitDefaultValues(false);
            return thCurve;
        }

        static public HandsetThrottleCurve GetDefaultHandsetThrottleCurve()
        {
            HandsetThrottleCurve thCurve = new HandsetThrottleCurve();
            thCurve.Title = "Default";
            thCurve.InitDefaultValues(false);
            return thCurve;
        }

        static public SoundSettings GetDefaultSoundsSettings(string soundDefaultPath)
        {
            SoundSettings result = new SoundSettings();
            result.InitDefaultValues(soundDefaultPath);
            return result;
        }

        

        static public GamePadThrottleCurve GetDefaultGamepadBrakeCurve()
        {
            GamePadThrottleCurve brakeCurve = new GamePadThrottleCurve();
            brakeCurve.Title = "Default";
            brakeCurve.InitDefaultValues(true);
            return brakeCurve;
        }

        static public Dictionary<TireType, TireTypeParams> GetDefaultTireTypeParams()
        {
            Dictionary<TireType, TireTypeParams> result = new Dictionary<TireType, TireTypeParams>();

            #region WET
            TireTypeParams wetParams = new TireTypeParams();

            wetParams.MaxPerformanceTreshold = 50;
            // accélération max par type de météo
            wetParams.MaxAcceleration_DryAndFreshTemp = 7;
            wetParams.MaxAcceleration_DryAndMediumTemp = 7;
            wetParams.MaxAcceleration_DryAndHotTemp = 7;
            wetParams.MaxAcceleration_Damp = 12;
            wetParams.MaxAcceleration_Wet = 12;
            // délai de freinage par type de météo
            wetParams.BrakingDelai_DryAndFreshTemp = 100;
            wetParams.BrakingDelai_DryAndMediumTemp = 100;
            wetParams.BrakingDelai_DryAndHotTemp = 100;
            wetParams.BrakingDelai_Damp = 60;
            wetParams.BrakingDelai_Wet = 60;
            // delta d'usure par rapport à un pneu de référence par météo
            wetParams.WearDelta_DryAndFreshTemp = 50;
            wetParams.WearDelta_DryAndMediumTemp = 60;
            wetParams.WearDelta_DryAndHotTemp = 70;
            wetParams.WearDelta_Damp = 15;
            wetParams.WearDelta_Wet = 0;

            result.Add(TireType.Wet, wetParams);
            #endregion


            #region INTERMEDIATE
            TireTypeParams interParams = new TireTypeParams();

            interParams.MaxPerformanceTreshold = 50;
            // accélération max par type de météo
            interParams.MaxAcceleration_DryAndFreshTemp = 7;
            interParams.MaxAcceleration_DryAndMediumTemp = 7;
            interParams.MaxAcceleration_DryAndHotTemp = 7;
            interParams.MaxAcceleration_Damp = 12;
            interParams.MaxAcceleration_Wet = 9;
            // délai de freinage par type de météo
            interParams.BrakingDelai_DryAndFreshTemp = 100;
            interParams.BrakingDelai_DryAndMediumTemp = 100;
            interParams.BrakingDelai_DryAndHotTemp = 100;
            interParams.BrakingDelai_Damp = 60;
            interParams.BrakingDelai_Wet = 100;
            // delta d'usure par rapport à un pneu de référence par météo
            interParams.WearDelta_DryAndFreshTemp = 40;
            interParams.WearDelta_DryAndMediumTemp = 50;
            interParams.WearDelta_DryAndHotTemp = 60;
            interParams.WearDelta_Damp = 0;
            interParams.WearDelta_Wet = 0;

            result.Add(TireType.Intermediate, interParams);
            #endregion


            #region HARD
            TireTypeParams hardParams = new TireTypeParams();

            hardParams.MaxPerformanceTreshold = 25;
            // accélération max par type de météo
            hardParams.MaxAcceleration_DryAndFreshTemp = 10;
            hardParams.MaxAcceleration_DryAndMediumTemp = 15;
            hardParams.MaxAcceleration_DryAndHotTemp = 20;
            hardParams.MaxAcceleration_Damp = 4;
            hardParams.MaxAcceleration_Wet = 3;
            // délai de freinage par type de météo
            hardParams.BrakingDelai_DryAndFreshTemp = 100;
            hardParams.BrakingDelai_DryAndMediumTemp = 50;
            hardParams.BrakingDelai_DryAndHotTemp = 0;
            hardParams.BrakingDelai_Damp = 350;
            hardParams.BrakingDelai_Wet = 500;
            // delta d'usure par rapport à un pneu de référence par météo
            hardParams.WearDelta_DryAndFreshTemp = -15;
            hardParams.WearDelta_DryAndMediumTemp = -20;
            hardParams.WearDelta_DryAndHotTemp = -35;
            hardParams.WearDelta_Damp = 0;
            hardParams.WearDelta_Wet = 0;

            result.Add(TireType.Hard, hardParams);
            #endregion


            #region MEDIUM
            TireTypeParams mediumParams = new TireTypeParams();

            mediumParams.MaxPerformanceTreshold = 35;
            // accélération max par type de météo
            mediumParams.MaxAcceleration_DryAndFreshTemp = 15;
            mediumParams.MaxAcceleration_DryAndMediumTemp = 40;
            mediumParams.MaxAcceleration_DryAndHotTemp = 15;
            mediumParams.MaxAcceleration_Damp = 4;
            mediumParams.MaxAcceleration_Wet = 3;
            // délai de freinage par type de météo
            mediumParams.BrakingDelai_DryAndFreshTemp = 75;
            mediumParams.BrakingDelai_DryAndMediumTemp = 0;
            mediumParams.BrakingDelai_DryAndHotTemp = 0;
            mediumParams.BrakingDelai_Damp = 250;
            mediumParams.BrakingDelai_Wet = 400;
            // delta d'usure par rapport à un pneu de référence par météo
            mediumParams.WearDelta_DryAndFreshTemp = 5;
            mediumParams.WearDelta_DryAndMediumTemp = 0;
            mediumParams.WearDelta_DryAndHotTemp = 10;
            mediumParams.WearDelta_Damp = 0;
            mediumParams.WearDelta_Wet = 0;

            result.Add(TireType.Medium, mediumParams);
            #endregion

            #region SOFT
            TireTypeParams softParams = new TireTypeParams();

            softParams.MaxPerformanceTreshold = 35;
            // accélération max par type de météo
            softParams.MaxAcceleration_DryAndFreshTemp = 40;
            softParams.MaxAcceleration_DryAndMediumTemp = 40;
            softParams.MaxAcceleration_DryAndHotTemp = 40;
            softParams.MaxAcceleration_Damp = 4;
            softParams.MaxAcceleration_Wet = 3;
            // délai de freinage par type de météo
            softParams.BrakingDelai_DryAndFreshTemp = 0;
            softParams.BrakingDelai_DryAndMediumTemp = 0;
            softParams.BrakingDelai_DryAndHotTemp = 0;
            softParams.BrakingDelai_Damp = 200;
            softParams.BrakingDelai_Wet = 300;
            // delta d'usure par rapport à un pneu de référence par météo
            softParams.WearDelta_DryAndFreshTemp = 15;
            softParams.WearDelta_DryAndMediumTemp = 20;
            softParams.WearDelta_DryAndHotTemp = 35;
            softParams.WearDelta_Damp = 0;
            softParams.WearDelta_Wet = 0;

            result.Add(TireType.Soft, softParams);
            #endregion


            return result;
        }
    }
}
