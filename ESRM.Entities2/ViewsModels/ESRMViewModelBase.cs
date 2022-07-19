using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ESRM.Entities;
using Newtonsoft.Json;

namespace ESRM.Entities.ViewsModels
{
    public class ESRMViewModelBase : IESRMViewModel
    {
        public string modelRootPath;
        public string soundsRootPath;
        
        public string PilotsFile = "Pilots.esr";
        public string DigitalParamsFile = "DigitalParamsv2.esr";
        public string CarsFile = "Cars.esr";
        public string TracksFile = "Tracks.esr";
        public string RecordsFile = "Records.esr";
        public string LastPracticeParametersFile = "LastPracticeParameters.esr";
        public string LastGPParametersFile = "LastGPParameters.esr";
        public string LastEnduranceParametersFile = "LastEnduranceParameters.esr";
        public string LastTimeAttackParametersFile = "LastTimeAttackParameters.esr";
        public string LastTeamsFile = "LastTeams.esr";
        public string TiresParamsFile = "TiresParams.esr";
        public string LastQualificationParametersFilePath = "LastQualification.esr";
        public string LastRallyCrossParametersFile = "LastRallyCross.esr";
        
        public string HandsetThrottleCurvesFile = "HandsetThrottleCurves.esr";
        public string GamepadThrottleCurvesFile = "GamepagThrottleCurves.esr";
        public string GamePadICPBrakesCurvesFile = "GamepagICPBrakeCurves.esr";
        public string GamepagBrakeCurvesFile = "GamepagBrakeCurves.esr";
        public string SoundSettingsFile = "SoundSettings.esr";

        protected string PilotsFilePath;
        protected string DigitalParamsFilePath;
        protected string CarsFilePath;
        protected string TracksFilePath;
        protected string RecordsFilePath;
        protected string LastPracticeParametersFilePath;
        protected string LastGPParametersFilePath;
        protected string LastEnduranceParametersFilePath;
        protected string LastTimeAttackParametersFilePath;
        protected string LastRallyCrossParametersFilePath;
        protected string LastTeamsFilePath;
        protected string TiresParamsFilePath;
        protected string GamepagBrakeCurvesFilePath;
        protected string GamepadThrottleCurvesFilePath;
        protected string GamePadICPBrakesCurvesFilePath;
        protected string HandsetThrottleCurvesFilePath;
        protected string SoundSettingsFilePath;
        protected string DefaultSoundPath;


        


        // persistent Datas
        public List<Car> Cars { get; set; }
        public List<Team> Teams { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Track> Tracks { get; set; }
        public Dictionary<TireType, TireTypeParams> TiresParams { get; set; }
        public List<HandsetThrottleCurve> HandsetThrottleCurves { get; set; }
        public List<GamePadThrottleCurve> GamePadThrottleCurves { get; set; }
        public List<GamePadThrottleCurve> GamePadBrakeCurves { get; set; }
        public List<GamePadThrottleCurve> GamePadICPBrakesCurves { get; set; }

        public RecordList Records { get; set; }

        public DigitalParamsBase DigitalParams { get; set; }
        public SoundSettings SoundSettings { get; set; }
        public RaceParameters LastPracticeParameters { get; set; }
        public RaceParameters LastGPParameters { get; set; }
        public RaceParameters LastEnduranceParameters { get; set; }
        public RaceParameters LastTimeAttackParameters { get; set; }
        public RaceParameters LastQualificationParameters { get; set; }
        public RaceParameters LastRallyCrossParameters { get; set; }
        
        //public Dictionary<int,TeamInRace> LastTeams{ get; set; }


        // volatiles
        public Race CurrentRace { get; set; }
        public RaceParameters CurrentRaceParameters { get; set; }
        Track defaultTrack = null;

        public object CurrentPage { get; set; }

        public ESRMViewModelBase()
        {

        }

        protected virtual void FillDefaultRaceParameters()
        {
            if (Tracks != null && Tracks.Count > 0)
                defaultTrack = Tracks[0];

            if(LastEnduranceParameters  == null)
                LastEnduranceParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Endurance, defaultTrack, DigitalParams);
            if (LastGPParameters == null)
                LastGPParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.GP, defaultTrack, DigitalParams);
            if (LastPracticeParameters == null)
                LastPracticeParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Practice, defaultTrack, DigitalParams);
            if (LastTimeAttackParameters == null)
                LastTimeAttackParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.TimeAttack, defaultTrack, DigitalParams);
            if (LastQualificationParameters == null)
                LastQualificationParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Qualification, defaultTrack, DigitalParams);
            if (TiresParams == null)
                TiresParams = DefaultDatas.GetDefaultTireTypeParams();

            if (GamePadBrakeCurves == null || GamePadBrakeCurves.Count == 0)
            {
                GamePadBrakeCurves = new List<GamePadThrottleCurve>();
                GamePadBrakeCurves.Add(DefaultDatas.GetDefaultGamepadBrakeCurve());
            }

            if (GamePadICPBrakesCurves == null || GamePadICPBrakesCurves.Count == 0)
            {
                GamePadICPBrakesCurves = new List<GamePadThrottleCurve>();
                GamePadICPBrakesCurves.Add(DefaultDatas.GetDefaultGamepadThrottleCurve());
            }
            
            if (GamePadThrottleCurves == null || GamePadThrottleCurves.Count == 0)
            {
                GamePadThrottleCurves = new List<GamePadThrottleCurve>();
                GamePadThrottleCurves.Add(DefaultDatas.GetDefaultGamepadThrottleCurve());
            }
            if (HandsetThrottleCurves == null || HandsetThrottleCurves.Count == 0)
            {
                HandsetThrottleCurves = new List<HandsetThrottleCurve>();
                HandsetThrottleCurves.Add(DefaultDatas.GetDefaultHandsetThrottleCurve());
            }
            if(SoundSettings == null)
            {
                  SoundSettings = DefaultDatas.GetDefaultSoundsSettings(soundsRootPath);
            }
            //CurrentRaceParameters = LastGPParameters;
        }

        public virtual void InitRaceParameters(RaceType raceType)
        {
            if (CurrentRaceParameters != null && raceType == CurrentRaceParameters.RaceType)
            {
                // le type de course n'a pas changé, on ne fait rien de spécial.
            }
            else
            {
                List<TeamInRace> tmp = new List<TeamInRace>();
                // on conserve les anciens params
                if (CurrentRaceParameters != null)
                {
                    tmp.AddRange(CurrentRaceParameters.Teams.Values);
                    if (CurrentRaceParameters.RaceType == RaceType.Endurance)
                        LastEnduranceParameters = CurrentRaceParameters;
                    if (CurrentRaceParameters.RaceType == RaceType.GP)
                        LastGPParameters = CurrentRaceParameters;
                    if (CurrentRaceParameters.RaceType == RaceType.Practice)
                        LastPracticeParameters = CurrentRaceParameters;
                    if (CurrentRaceParameters.RaceType == RaceType.TimeAttack)
                        LastTimeAttackParameters = CurrentRaceParameters;
                    if (CurrentRaceParameters.RaceType == RaceType.Qualification)
                        LastQualificationParameters = CurrentRaceParameters;
                    if (CurrentRaceParameters.RaceType == RaceType.RallyCross)
                        LastRallyCrossParameters = CurrentRaceParameters;
                }

                if (raceType == RaceType.Endurance)
                    CurrentRaceParameters = LastEnduranceParameters;
                if (raceType == RaceType.GP)
                {
                    CurrentRaceParameters = LastGPParameters;
                    CurrentRaceParameters.RaceType = RaceType.GP;
                }
                if (raceType == RaceType.Practice)
                    CurrentRaceParameters = LastPracticeParameters;
                if (raceType == RaceType.TimeAttack)
                    CurrentRaceParameters = LastTimeAttackParameters;
                if (raceType == RaceType.Qualification)
                    CurrentRaceParameters = LastQualificationParameters;
                if (raceType == RaceType.RallyCross)
                {
                    CurrentRaceParameters = LastRallyCrossParameters;
                    CurrentRaceParameters.RaceType = RaceType.RallyCross;
                }


                if (tmp.Count > 0)
                {
                    CurrentRaceParameters.Teams.Clear();
                    foreach(TeamInRace t in tmp)
                        CurrentRaceParameters.Teams.AddTeam(t);
                }
            }
        }

        public virtual void CreateRaceFromParameters()
        {
            Track defaultTrack = null;
            if (Tracks != null && Tracks.Count > 0)
                defaultTrack = Tracks[0];


            if (CurrentRaceParameters == null)
                CurrentRaceParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.GP, defaultTrack,DigitalParams);

            // si la course courrante n'est pas vide, on va conserver les équipes pour la suite
            List<TeamInRace> oldTeams = new List<TeamInRace>();
            if (CurrentRace != null)
            {
                CurrentRace.ResetRace(false,false);
                oldTeams.AddRange(CurrentRace.Teams.Values);


            }

            CurrentRace = DefaultDatas.GetDefaultRaceFromParameters(CurrentRaceParameters, oldTeams);
            // gestion des courbes de puissances par pilote
            foreach (KeyValuePair<int, TeamInRace> entry in CurrentRace.Teams)
            {
                // on récupère les pilotes dans les données (si le pilote existe) pour être certain d'avoir la bonne version du pilote car ses settings ont pu changer
                if (entry.Value.Pilot1 != null)
                {
                    Pilot pilot = this.Pilots.FirstOrDefault(p => p.Name == entry.Value.Pilot1.Name);
                    if (pilot != null)
                        entry.Value.Pilot1 = pilot;
                }

                AssignFavoritesHandSetCurvesToDriver(entry.Value.Pilot1, entry.Value.UseGamePadPlayerIndex.HasValue, entry.Value.InCarPro);
                if (entry.Value.Pilot2 != null)
                {
                    Pilot pilot = this.Pilots.FirstOrDefault(p => p.Name == entry.Value.Pilot2.Name);
                    if (pilot != null)
                        entry.Value.Pilot2 = pilot;

                    AssignFavoritesHandSetCurvesToDriver(entry.Value.Pilot2, entry.Value.UseGamePadPlayerIndex.HasValue, entry.Value.InCarPro);
                }
                if (entry.Value.Pilot3 != null)
                {
                    Pilot pilot = this.Pilots.FirstOrDefault(p => p.Name == entry.Value.Pilot3.Name);
                    if (pilot != null)
                        entry.Value.Pilot3 = pilot;
                    AssignFavoritesHandSetCurvesToDriver(entry.Value.Pilot3, entry.Value.UseGamePadPlayerIndex.HasValue, entry.Value.InCarPro);
                }
            }

            // Sauvegarde des parametres.
            if (CurrentRaceParameters.RaceType == RaceType.Endurance)
            {
                LastEnduranceParameters = CurrentRaceParameters;
                SaveLastEnduranceParameters();
            }
            else if (CurrentRaceParameters.RaceType == RaceType.GP)
            {
               LastGPParameters = CurrentRaceParameters;
                SaveLastGPParameters();
            }
            else if (CurrentRaceParameters.RaceType == RaceType.Practice)
            {
                LastPracticeParameters = CurrentRaceParameters;
                SaveLastPracticeParameters();
            }
            else if (CurrentRaceParameters.RaceType == RaceType.TimeAttack)
            {
                LastTimeAttackParameters = CurrentRaceParameters;
                SaveLLastTimeAttackParameters();
            }
            else if (CurrentRaceParameters.RaceType == RaceType.Qualification)
            {
                LastQualificationParameters = CurrentRaceParameters;
                SaveLastQualificationParameters();
            }
            else if (CurrentRaceParameters.RaceType == RaceType.RallyCross)
            {
                LastRallyCrossParameters = CurrentRaceParameters;
                SaveLastRallyCrossParameters();
            }
            


        }

        private void AssignFavoritesHandSetCurvesToDriver(Pilot driver,bool useGamePad, bool inCarPro)
        {
            driver.FavoriteGamePadThrottleCurve.Clear();
            driver.FavoriteGamePadBrakeCurves.Clear();
            driver.FavoriteGamePadInCarProBrakeCurve.Clear();
            driver.FavoriteHandsetThrottleCurve.Clear();

            if (useGamePad)
            {
                foreach (string curveTitle in driver.FavoriteGamePadThrottleCurveTitles)
                {
                    driver.FavoriteGamePadThrottleCurve.Add(this.GamePadThrottleCurves.FirstOrDefault(c => c.Title == curveTitle));
                }
                if (inCarPro)
                {
                    foreach (string curveTitle in driver.FavoriteGamePadInCarProBrakeCurveTitles)
                        driver.FavoriteGamePadInCarProBrakeCurve.Add(this.GamePadICPBrakesCurves.FirstOrDefault(c => c.Title == curveTitle));
                }
                else
                {
                    foreach (string curveTitle in driver.FavoriteGamePadBrakeCurvesTitles)
                        driver.FavoriteGamePadBrakeCurves.Add(this.GamePadBrakeCurves.FirstOrDefault(c => c.Title == curveTitle));
                }

            }
            else
            {
                foreach (string curveTitle in driver.FavoriteHandSetCurvesTitles)
                    driver.FavoriteHandsetThrottleCurve.Add(this.HandsetThrottleCurves.FirstOrDefault(c => c.Title == curveTitle));
            }

            driver.FavoriteGamePadThrottleCurve.RemoveAll(c => c == null);
            driver.FavoriteGamePadInCarProBrakeCurve.RemoveAll(c => c == null);
            driver.FavoriteGamePadBrakeCurves.RemoveAll(c => c == null);
            driver.FavoriteHandsetThrottleCurve.RemoveAll(c => c == null);

        }

        public IESRMPageViewModel CurrentPageModel
        {
            get;
            set;
        }

        public virtual void ActivatePage(string pageName)
        {
        }


        public virtual void Close(bool isClosing)
        {
        }
        
        protected  void InitModel()
        {
            EnsureFoldersExists();
            LoadModelFromFiles();
            FillDefaultRaceParameters();

        }

        public void LoadModelFromFiles()
        {
            LoadTiresParams();
            LoadDigitalParams();
            LoadPilots();
            LoadCars();
            LoadLastEnduranceParameters();
            LoadLastGPParameters();
            LoadLastPracticeParameters();
            LoadLastTimeAttackParameters();
            LoadLastQualificationParameters();
            LoadLastRallyCrossParameters();

            LoadRecords();
            LoadTracks();
            LoadCurves();
            LoadSoundSettings();
        }

        #region PILOTES

        public void LoadPilots()
        {
            using (Stream stream = FromFile(PilotsFilePath))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Pilot>));
                    Pilots = (List<Pilot>)js.ReadObject(stream);
                }
                else
                    Pilots = new List<Pilot>();
            }
        }

        public virtual void SavePilots()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Pilot>));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, Pilots);
            ToFile(stream, PilotsFilePath);
        }

        #endregion

        #region CARS

        public void LoadCars()
        {
            using (Stream stream = FromFile(CarsFilePath))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Car>));
                    Cars = (List<Car>)js.ReadObject(stream);
                }
                else
                    Cars = new List<Car>();
            }
        }

        public virtual void SaveCars()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Car>));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, Cars);
            ToFile(stream, CarsFilePath);
        }
        #endregion

        #region TIRES PARAMS

        public void LoadTiresParams()
        {
            Stream stream = FromFile(TiresParamsFilePath); // récupération du contenu du fichier

            if (stream != null)
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Dictionary<TireType, TireTypeParams>));
                TiresParams = (Dictionary<TireType, TireTypeParams>)js.ReadObject(stream);
            }
            else
                TiresParams = DefaultDatas.GetDefaultTireTypeParams();

            TiresManager.Instance.InitParameters(TiresParams);

        }

        public virtual void SaveTiresParams()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Dictionary<TireType, TireTypeParams>));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, TiresParams);
            ToFile(stream, TiresParamsFilePath);
        }

        #endregion

        #region TRACKS

        public void LoadTracks()
        {
            using (Stream stream = FromFile(TracksFilePath))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Track>));
                    Tracks = (List<Track>)js.ReadObject(stream);
                }
                else
                    Tracks = new List<Track>();
            }
        }

        public virtual void SaveTracks()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Track>));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, Tracks);
            ToFile(stream, TracksFilePath);
        }
        #endregion TRACKS

        #region RECORDS

        public void LoadRecords()
        {
            using (Stream stream = FromFile(RecordsFilePath))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RecordList));
                    Records = (RecordList)js.ReadObject(stream);
                }
                else
                    Records = new RecordList();
            }
        }

        public virtual void SaveRecords()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RecordList));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, Records);
            ToFile(stream, RecordsFilePath);
        }
        #endregion RECORDS

        #region CURVES

        public void LoadCurves()
        {
            using (Stream stream = FromFile(HandsetThrottleCurvesFilePath))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<HandsetThrottleCurve>));
                    HandsetThrottleCurves = (List<HandsetThrottleCurve>)js.ReadObject(stream);
                }
                else
                    HandsetThrottleCurves = new List<HandsetThrottleCurve>();
            }

            using (Stream stream = FromFile(GamepadThrottleCurvesFile))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<GamePadThrottleCurve>));
                    GamePadThrottleCurves = (List<GamePadThrottleCurve>)js.ReadObject(stream);
                }
                else
                    GamePadThrottleCurves = new List<GamePadThrottleCurve>();
            }

            using (Stream stream = FromFile(GamepagBrakeCurvesFilePath))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    try
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<GamePadThrottleCurve>));
                        GamePadBrakeCurves = (List<GamePadThrottleCurve>)js.ReadObject(stream);
                    }
                    catch(Exception ex)
                    {
                        GamePadBrakeCurves = new List<GamePadThrottleCurve>();
                    }
                }
                else
                    GamePadBrakeCurves = new List<GamePadThrottleCurve>();
            }


            using (Stream stream = FromFile(GamePadICPBrakesCurvesFile))
            {// récupération du contenu du fichier

                if (stream != null)
                {
                    try
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<GamePadThrottleCurve>));
                        GamePadICPBrakesCurves = (List<GamePadThrottleCurve>)js.ReadObject(stream);
                    }
                    catch (Exception ex)
                    {
                        GamePadICPBrakesCurves = new List<GamePadThrottleCurve>();
                    }
                }
                else
                    GamePadICPBrakesCurves = new List<GamePadThrottleCurve>();
            }
        }

        public virtual void SaveCurves()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<HandsetThrottleCurve>));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, HandsetThrottleCurves);
            ToFile(stream, HandsetThrottleCurvesFilePath);

            DataContractJsonSerializer js2 = new DataContractJsonSerializer(typeof(List<GamePadThrottleCurve>));
            MemoryStream stream2 = new MemoryStream();
            js2.WriteObject(stream2, GamePadThrottleCurves);
            ToFile(stream2, GamepadThrottleCurvesFile);


            DataContractJsonSerializer js3 = new DataContractJsonSerializer(typeof(List<GamePadThrottleCurve>));
            MemoryStream stream3 = new MemoryStream();
            js3.WriteObject(stream3, GamePadBrakeCurves);
            ToFile(stream3, GamepagBrakeCurvesFilePath);

            DataContractJsonSerializer js4 = new DataContractJsonSerializer(typeof(List<GamePadThrottleCurve>));
            MemoryStream stream4 = new MemoryStream();
            js4.WriteObject(stream4, GamePadICPBrakesCurves);
            ToFile(stream4, GamePadICPBrakesCurvesFilePath);

            

        }
        #endregion CURVES


        #region SOUNDS

        
        public void LoadSoundSettings()
        {
            try
            {
                using (Stream stream = FromFile(SoundSettingsFilePath))
                {
                    // récupération du contenu du fichier
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SoundSettings));
                        SoundSettings = (SoundSettings)js.ReadObject(stream);
                    }
                    else
                        SoundSettings = DefaultDatas.GetDefaultSoundsSettings(soundsRootPath);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public virtual void SaveSoundSettings()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SoundSettings));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, SoundSettings);
            ToFile(stream, SoundSettingsFilePath);
        }

        #endregion SOUNDS

        #region DigitalParams

        public void LoadDigitalParams()
        {
            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            Stream stream = FromFile(DigitalParamsFilePath); // récupération du contenu du fichier

            try
            {
                if (stream != null)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DigitalParamsBase));
                    DigitalParams = (DigitalParamsBase)js.ReadObject(stream);
                }
                else
                    DigitalParams = new DigitalParamsBase();
            }
            catch(Exception ex)
            {
                DigitalParams = new DigitalParamsBase();
            }

            GlobalDatas.INTERVALBETWEENTWOSIGNALS = DigitalParams.TimeBetweenData;
            GlobalDatas.LOWFUELLEVEL = DigitalParams.LowFuelLevel;
            GlobalDatas.LOWHEALTHLEVEL= DigitalParams.LowHealthLevel;
            GlobalDatas.LOWTIRESLEVEL= DigitalParams.LowTiresLevel;
            GlobalDatas.MAXACCELERATIONDELTA = DigitalParams.MaxAccelerationDelta;
            GlobalDatas.MAXBRAKEINTERVAL = DigitalParams.MaxBrakeIntervals;
        }

        public virtual void SaveDigitalParams()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DigitalParamsBase));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, DigitalParams);
            ToFile(stream, DigitalParamsFilePath);
        }

        #endregion

        #region LAST RACE PARAMS

        public void LoadLastEnduranceParameters()
        {
            try
            {
                using (Stream stream = FromFile(LastEnduranceParametersFilePath))
                {// récupération du contenu du fichier
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                        LastEnduranceParameters = (RaceParameters)js.ReadObject(stream);
                        LastEnduranceParameters.SetDigitalParams(DigitalParams);
                    }
                    else
                        LastEnduranceParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Endurance, defaultTrack, DigitalParams);
                }
            }
            catch (Exception ex)
            {
                LastEnduranceParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Endurance, defaultTrack, DigitalParams);
            }
            LoadLastTeams(LastEnduranceParameters);
        }

        public virtual void SaveLastEnduranceParameters()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, LastEnduranceParameters);
            ToFile(stream, LastEnduranceParametersFilePath);

            SaveLastTeams();

            //EnsureTeamsLoaded(LastEnduranceParameters);
        }

        //public void EnsureTeamsLoaded(RaceParameters parameters)
        //{
        //    //for (int i = 0; i < parameters.MaxTeamsCount; i++)
        //    //{
        //    //    parameters.Teams.Add(DefaultDatas.GetDefaultTeamInRace(i, parameters.PilotPerTeam));
        //    //}
        //}

        public void LoadLastGPParameters()
        {
            try
            {
                using (Stream stream = FromFile(LastGPParametersFilePath))
                {// récupération du contenu du fichier
                    if (stream != null)
                    {
                        try
                        {
                            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                            LastGPParameters = (RaceParameters)js.ReadObject(stream);
                            LastGPParameters.SetDigitalParams(DigitalParams);
                        }
                        catch (Exception ex)
                        {
                            LastGPParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.GP, defaultTrack, DigitalParams);
                        }
                    }
                    else
                        LastGPParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.GP, defaultTrack, DigitalParams);
                }
            }
            catch (Exception ex)
            {
                LastGPParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.GP, defaultTrack, DigitalParams);
            }

            LoadLastTeams(LastGPParameters);
        }

        public virtual void SaveLastGPParameters()
        {
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                MemoryStream stream = new MemoryStream();
                js.WriteObject(stream, LastGPParameters);
                ToFile(stream, LastGPParametersFilePath);
                SaveLastTeams();
            }
            catch(Exception ex)
            {

            }
        }

        public void LoadLastTimeAttackParameters()
        {
            try
            {
                using (Stream stream = FromFile(LastTimeAttackParametersFilePath))
                {// récupération du contenu du fichier
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                        LastTimeAttackParameters = (RaceParameters)js.ReadObject(stream);
                        LastTimeAttackParameters.SetDigitalParams(DigitalParams);
                    }
                    else
                        LastTimeAttackParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.TimeAttack, defaultTrack, DigitalParams);
                }
            }
            catch (Exception e)
            {
                LastTimeAttackParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.TimeAttack, defaultTrack, DigitalParams);
            }
            LoadLastTeams(LastTimeAttackParameters);
        }

        public virtual void SaveLLastTimeAttackParameters()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, LastTimeAttackParameters);
            ToFile(stream, LastTimeAttackParametersFilePath);
            SaveLastTeams();
        }

        public void LoadLastQualificationParameters()
        {
            try
            {
                using (Stream stream = FromFile(LastQualificationParametersFilePath))
                {
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                        LastQualificationParameters = (RaceParameters)js.ReadObject(stream);
                        LastQualificationParameters.SetDigitalParams(DigitalParams);
                    }
                    else
                        LastQualificationParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Qualification, defaultTrack, DigitalParams);
                }
            }
            catch (Exception e)
            {
                LastQualificationParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Qualification, defaultTrack, DigitalParams);

            }
            LoadLastTeams(LastQualificationParameters);
        }

        public virtual void SaveLastQualificationParameters()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, LastQualificationParameters);
            ToFile(stream, LastQualificationParametersFilePath);
            SaveLastTeams();
        }


        public void LoadLastRallyCrossParameters()
        {
            try
            {
                using (Stream stream = FromFile(LastRallyCrossParametersFilePath))
                {
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                        LastRallyCrossParameters = (RaceParameters)js.ReadObject(stream);
                        LastRallyCrossParameters.SetDigitalParams(DigitalParams);
                    }
                    else
                        LastRallyCrossParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.RallyCross, defaultTrack, DigitalParams);
                }
            }
            catch (Exception e)
            {
                LastRallyCrossParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.RallyCross, defaultTrack, DigitalParams);

            }
            LoadLastTeams(LastRallyCrossParameters);
        }

        public virtual void SaveLastRallyCrossParameters()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, LastRallyCrossParameters);
            ToFile(stream, LastRallyCrossParametersFilePath);
            SaveLastTeams();
        }




        public void LoadLastPracticeParameters()
        {
            try {
                using (Stream stream = FromFile(LastPracticeParametersFilePath))
                {// récupération du contenu du fichier
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
                        LastPracticeParameters = (RaceParameters)js.ReadObject(stream);
                        LastPracticeParameters.SetDigitalParams(DigitalParams);
                    }
                    else
                        LastPracticeParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Practice, defaultTrack, DigitalParams);
                }
            }
            catch(Exception ex)
            {
                LastPracticeParameters = DefaultDatas.GetDefaultRaceParameters(RaceType.Practice, defaultTrack, DigitalParams);
            }
            LoadLastTeams(LastPracticeParameters);
        }

        public virtual void SaveLastPracticeParameters()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RaceParameters));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, LastPracticeParameters);
            ToFile(stream, LastPracticeParametersFilePath);
            SaveLastTeams();
        }


        public void LoadLastTeams( RaceParameters raceParams)
        {
            raceParams.Teams = new TeamInRaceCollection();

            try
            {
                using (Stream stream = FromFile(LastTeamsFilePath))
                {// récupération du contenu du fichier
                    if (stream != null)
                    {
                        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<TeamInRace>));
                        if (raceParams != null)
                        {
                            List<TeamInRace> tmpTeams = (List<TeamInRace>)js.ReadObject(stream);
                            if (tmpTeams != null)
                            {
                                foreach (TeamInRace t in tmpTeams)
                                    raceParams.Teams.AddTeam(t);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (raceParams.Teams == null)
                raceParams.Teams = new TeamInRaceCollection();
        }



        public virtual void SaveLastTeams()
        {
            if (CurrentRace.RaceParams.Teams == null || CurrentRace.RaceParams.Teams.Count == 0)
                return;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<TeamInRace>));
            MemoryStream stream = new MemoryStream();
            js.WriteObject(stream, CurrentRace.RaceParams.Teams.Values.ToList());
            ToFile(stream, LastTeamsFilePath);
        }

        #endregion LAST RACE PARAMS

        #region METHODES SPECIFIQUES A CHAQUE OS

        protected virtual Stream FromFile(string filePath)
        {
            return null;
        }

        protected virtual void ToFile(MemoryStream str, string filePath)
        {
        }

        protected virtual void EnsureFoldersExists()
        {

        }
        #endregion

    }
}

