using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public interface IESRMViewModel
    {
        IESRMPageViewModel CurrentPageModel { get; set; }
        object CurrentPage { get; set; }
        void Close(bool isClosing);
        void ActivatePage(string pageName);

        // persistent Datas
        DigitalParamsBase DigitalParams { get; set; }
        Dictionary<TireType, TireTypeParams> TiresParams { get; set; }
        List<Car> Cars { get; set; }
        List<Team> Teams { get; set; }
        List<Pilot> Pilots { get; set; }
        List<Track> Tracks { get; set; }
        SoundSettings SoundSettings { get; set; }
        List<HandsetThrottleCurve> HandsetThrottleCurves { get; set; }
        List<GamePadThrottleCurve> GamePadThrottleCurves { get; set; }
        List<GamePadThrottleCurve> GamePadICPBrakesCurves { get; set; }
        List<GamePadThrottleCurve> GamePadBrakeCurves { get; set; }
        RecordList Records { get; set; }
        RaceParameters LastPracticeParameters { get; set; }
        RaceParameters LastGPParameters { get; set; }
        RaceParameters LastEnduranceParameters { get; set; }
        RaceParameters LastTimeAttackParameters { get; set; }
        RaceParameters LastRallyCrossParameters { get; set; }



        // volatiles
        RaceParameters CurrentRaceParameters { get; set; }
        Race CurrentRace { get; set; }

        void InitRaceParameters(RaceType raceType);
        void CreateRaceFromParameters();

       void  LoadPilots();
        void SavePilots();



        #region CARS

         void LoadCars();

          void SaveCars();
        #endregion

        #region TRACKS

         void LoadTracks()        ;

          void SaveTracks();
        #endregion TRACKS

        #region RECORDS

        void LoadRecords();

        void SaveRecords();
        #endregion RECORDS  
        
        #region Curves

        void LoadCurves();

        void SaveCurves();
        #endregion Curves

        #region DigitalParams

        void LoadDigitalParams();
          void SaveDigitalParams();
        void SaveTiresParams();

        void SaveSoundSettings();
        #endregion

        #region LAST RACE PARAMS

        void LoadLastEnduranceParameters();
          void SaveLastEnduranceParameters();
         //void EnsureTeamsLoaded(RaceParameters parameters);

         void LoadLastGPParameters();
          void SaveLastGPParameters();
         void LoadLastTimeAttackParameters();
          void SaveLLastTimeAttackParameters();
        void LoadLastPracticeParameters();
        void SaveLastPracticeParameters();

        void LoadLastRallyCrossParameters();
        void SaveLastRallyCrossParameters();

        
        #endregion LAST RACE PARAMS


    }

    public interface IESRMPageViewModel
    {
        bool IsComplete { get; }
        bool CanReturn { get; }
    }


}

