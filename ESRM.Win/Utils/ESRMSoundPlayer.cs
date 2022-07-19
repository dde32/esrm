using ESRM.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ESRM.Win
{
    public class ESRMSoundPlayer
    {
        [DllImport("winmm.dll")]
        //static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        static extern Int32 mciSendString(string command, string buffer, int bufferSize, IntPtr hwndCallback);

        Dictionary<SoundEnum, SoundSetting> _soundsPath;
        bool _rainSound = false;
        static SoundSettings _settings;

        private static ESRMSoundPlayer instance = null;
        private static readonly object padlock = new object();



        public static ESRMSoundPlayer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ESRMSoundPlayer();
                    }
                    return instance;
                }
            }
        }

        public void InitializeWithSettings(SoundSettings settings)
        {
            _settings = settings;
            if (_soundsPath == null)
                _soundsPath = new Dictionary<SoundEnum, SoundSetting>();
            else
                _soundsPath.Clear();
            if (_settings != null)
            {
                _soundsPath.Add(SoundEnum.Go, _settings.Get(SoundEnum.Go));
                _soundsPath.Add(SoundEnum.YellowFlag, _settings.Get(SoundEnum.YellowFlag));
                _soundsPath.Add(SoundEnum.GreenFlag, _settings.Get(SoundEnum.GreenFlag));
                _soundsPath.Add(SoundEnum.PitIn, _settings.Get(SoundEnum.PitIn));
                _soundsPath.Add(SoundEnum.Warning, _settings.Get(SoundEnum.Warning));
                _soundsPath.Add(SoundEnum.Alert, _settings.Get(SoundEnum.Alert));
                _soundsPath.Add(SoundEnum.LapRecord, _settings.Get(SoundEnum.LapRecord));
                _soundsPath.Add(SoundEnum.Beep, _settings.Get(SoundEnum.Beep));
                _soundsPath.Add(SoundEnum.Incident, _settings.Get(SoundEnum.Incident));
                _soundsPath.Add(SoundEnum.Finish, _settings.Get(SoundEnum.Finish));
                _soundsPath.Add(SoundEnum.PassSFLine, _settings.Get(SoundEnum.PassSFLine));
                _soundsPath.Add(SoundEnum.EnterPitlane, _settings.Get(SoundEnum.EnterPitlane));

                _soundsPath.Add(SoundEnum.EndRealy, _settings.Get(SoundEnum.EndRealy));
                _soundsPath.Add(SoundEnum.LightRain, _settings.Get(SoundEnum.LightRain));
                _soundsPath.Add(SoundEnum.MediumRain, _settings.Get(SoundEnum.MediumRain));
                _soundsPath.Add(SoundEnum.HardRain, _settings.Get(SoundEnum.HardRain));
            }
        }

        private ESRMSoundPlayer()
        {
        }



        private void PlaySound(string soundPath,string alias)
        {
            try
            {
                string closeCmd = string.Format("close {0}", alias);
                string openCmd = string.Format("open {0} type waveaudio alias {1}", soundPath, alias);
                string playCmd = string.Format("play {0}", alias);
                mciSendString(closeCmd, null, 0, IntPtr.Zero);
                int result1 = mciSendString(openCmd, null, 0, IntPtr.Zero);
                int result2 = mciSendString(playCmd, null, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void PlayRainSound(string soundPath, IntPtr hwnd)
        {
            string result = null;
            string closeCmd = string.Format("close rain");
            string openCmd = string.Format("open {0} type waveaudio alias rain", soundPath);
            string playCmd = string.Format("play rain notify");
            mciSendString(closeCmd, null, 0, hwnd);
            mciSendString(openCmd, null, 0, hwnd);
            mciSendString(playCmd, result, 0, hwnd);
        }

        public void PlaySound(SoundEnum sound)
        {
            if (!_soundsPath.ContainsKey(sound) || !_soundsPath[sound].UseSound)
                return;

            try
            {
                string path = _soundsPath[sound].SoundPath;
                string alias = sound.ToString();
                PlaySound(path, alias);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void PlayRainSound(SoundEnum sound, IntPtr hwnd)
        {
            if (!_soundsPath.ContainsKey(sound) || !_soundsPath[sound].UseSound)
                return;

            StopRainSound(hwnd);
            string path = _soundsPath[sound].SoundPath;
            PlayRainSound(path, hwnd);
            _rainSound = true;
        }

        public void StopRainSound(IntPtr hwnd)
        {
            try
            {
                if (_rainSound)
                {
                    _rainSound = false;
                    int r1 = mciSendString("stop rain", null, 0, hwnd);
                    int r2 = mciSendString("close rain", null, 0, hwnd);
                }
            }
            catch (Exception e)
            {

            }
        }
    }



}



 