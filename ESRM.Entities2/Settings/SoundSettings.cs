using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class SoundSettings
    {
        //[DataMember]
        //public SoundSetting Go { get; set; }

        //[DataMember]
        //public SoundSetting YellowFlag { get; set; }

        //[DataMember]
        //public SoundSetting GreenFlag { get; set; }

        //[DataMember]
        //public SoundSetting EnterPitlane { get; set; }

        //[DataMember]
        //public SoundSetting Warning { get; set; }

        //[DataMember]
        //public SoundSetting Alert { get; set; }

        //[DataMember]
        //public SoundSetting LapRecord { get; set; }
        //[DataMember]
        //public SoundSetting Incident { get; set; }
        //[DataMember]
        //public SoundSetting Finish { get; set; }
        //[DataMember]
        //public SoundSetting Beep { get; set; }
        //[DataMember]
        //public SoundSetting PassSFLine { get; set; }

        //[DataMember]
        //public SoundSetting EndRealy { get; set; }
        //[DataMember]
        //public SoundSetting LightRain { get; set; }
        //[DataMember]
        //public SoundSetting MediumRain { get; set; }
        //[DataMember]
        //public SoundSetting HardRain { get; set; }

        [DataMember]
        public List<SoundSetting> Settings { get; set; }

        public SoundSettings()
        {
            Settings = new List<SoundSetting>();
        }

        public void InitDefaultValues(string defaultSoundPath)
        {
            Settings = new List<SoundSetting>();

            Settings.Add(new SoundSetting(SoundEnum.Go, defaultSoundPath + "\\go.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.YellowFlag, defaultSoundPath + "\\YellowFlag.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.GreenFlag, defaultSoundPath + "\\GreenFlag.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.PitIn, defaultSoundPath + "\\PitIn.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.Warning, defaultSoundPath + "\\Warning.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.Alert, defaultSoundPath + "\\Alert.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.LapRecord, defaultSoundPath + "\\LapRecord.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.Incident, defaultSoundPath + "\\Incident.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.Finish, defaultSoundPath + "\\Finish.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.Beep, defaultSoundPath + "\\beep.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.EndRealy, defaultSoundPath + "\\Relay.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.LightRain, defaultSoundPath + "\\LightRain.wav", true));

            Settings.Add(new SoundSetting(SoundEnum.MediumRain, defaultSoundPath + "\\MediumRain.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.HardRain, defaultSoundPath + "\\HardRain.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.EnterPitlane, defaultSoundPath + "\\TA_Positive.wav", true));
            Settings.Add(new SoundSetting(SoundEnum.PassSFLine, defaultSoundPath + "\\beep.wav", true));

            /*
            Go = new SoundSetting(SoundEnum.Go, defaultSoundPath + "\\go.wav", true);
            YellowFlag = new SoundSetting(SoundEnum.YellowFlag, defaultSoundPath + "Sounds\\YellowFlag.wav", true);
            GreenFlag = new SoundSetting(SoundEnum.GreenFlag, defaultSoundPath + "Sounds\\GreenFlag.wav", true);
            EnterPitlane = new SoundSetting(SoundEnum.PitIn, defaultSoundPath + "Sounds\\PitIn.wav", true);
            Warning = new SoundSetting(SoundEnum.Warning, defaultSoundPath + "Sounds\\Warning.wav", true);
            Alert = new SoundSetting(SoundEnum.Alert, defaultSoundPath + "Sounds\\Alert.wav", true);
            LapRecord = new SoundSetting(SoundEnum.LapRecord, defaultSoundPath + "Sounds\\LapRecord.wav", true);
            Incident = new SoundSetting(SoundEnum.Incident, defaultSoundPath + "Sounds\\Incident.wav", true);
            Finish = new SoundSetting(SoundEnum.Finish, defaultSoundPath + "Sounds\\Finish.wav", true);
            Beep = new SoundSetting(SoundEnum.Beep, defaultSoundPath + "Sounds\\beep.wav", true);
            EndRealy = new SoundSetting(SoundEnum.EndRealy, defaultSoundPath + "Sounds\\Relay.wav", true);
            LightRain = new SoundSetting(SoundEnum.LightRain, defaultSoundPath + "Sounds\\LightRain.wav", true);

            MediumRain = new SoundSetting(SoundEnum.MediumRain, defaultSoundPath + "Sounds\\MediumRain.wav", true);
            HardRain = new SoundSetting(SoundEnum.HardRain, defaultSoundPath + "Sounds\\HardRain.wav", true);
            EnterPitlane = new SoundSetting(SoundEnum.EnterPitlane, defaultSoundPath + "Sounds\\TA_Positive.wav", true);
            PassSFLine = new SoundSetting(SoundEnum.PassSFLine, defaultSoundPath + "Sounds\\beep.wav", true);
            */
            //_soundsPath.Add(SoundEnum.TA_ChangeLevel, defaultSoundPath + "Sounds\\TA_ChangeLevel.wav", true);
            //_soundsPath.Add(SoundEnum.TA_Negative, defaultSoundPath + "Sounds\\TA_Negative.wav", true);
            //_soundsPath.Add(SoundEnum.TA_Positive, defaultSoundPath + "Sounds\\TA_Positive.wav", true);
        }

        public SoundSetting Get(SoundEnum sound)
        {
            for (int i = 0; i < Settings.Count; i++)
            {
                if (Settings[i].SoundType == sound)
                    return Settings[i];
            }
            return new SoundSetting(sound, "", false);
        }

        public void SwitchUseSound(SoundEnum sound)
        {
            for (int i = 0; i < Settings.Count; i++)
            {
                if (Settings[i].SoundType == sound)
                    Settings[i].UseSound = !Settings[i].UseSound;
            }
        }
        public void SetUseSound(SoundEnum sound, bool use)
        {
            for (int i = 0; i < Settings.Count; i++)
            {
                if (Settings[i].SoundType == sound)
                    Settings[i].UseSound = use;
            }
        }

        public void SetSoundPath(SoundEnum sound,string path)
        {
            for (int i = 0; i < Settings.Count; i++)
            {
                if (Settings[i].SoundType == sound)
                    Settings[i].SoundPath = path;
            }
        }
    }

        [DataContract]
    public class SoundSetting
    {
        [DataMember]
        public SoundEnum SoundType { get; set; }
        [DataMember]
        public string SoundPath { get; set; }
        [DataMember]
        public bool UseSound { get; set; }

        public SoundSetting(SoundEnum soundType,string path, bool useSound)
        {
            SoundType = soundType;
            SoundPath = path;
            UseSound = useSound;
        }
    }

}