using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using ESRM.Entities;
using Portable.Licensing;
using ESRM.HWInterfaces;
using System.Deployment.Application;
using System.IO.Ports;
using ESRM.GamePads;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ESRM.Win
{

    static class Program
    {
        private const string publicKey = "MIIBKjCB4wYHKoZIzj0CATCB1wIBATAsBgcqhkjOPQEBAiEA/////wAAAAEAAAAAAAAAAAAAAAD///////////////8wWwQg/////wAAAAEAAAAAAAAAAAAAAAD///////////////wEIFrGNdiqOpPns+u9VXaYhrxlHQawzFOw9jvOPD4n0mBLAxUAxJ02CIbnBJNqZnjhE50mt4GffpAEIQNrF9Hy4SxCR/i85uVjpEDydwN9gS3rM6D0oTlF2JjClgIhAP////8AAAAA//////////+85vqtpxeehPO5ysL8YyVRAgEBA0IABLl/AUeTcObJXj1v8lQGF56oMyTTsce+juYmT4fuE+7QkuI+N7a/h1tQqQF+KrRnuoVHRW0/psQ69T9sl536kZk=";
        public static ESRMLicence Licence;
        public static string licenceId = "Full";
        //private static Guid macAddressGuid;


        static IDigitalParamsBase _digitalParams;
        public static IHardwareInterface hwInterface;
        public static SmartSensorInterface_ForPitLane pitSensors;
        public static StartLights _startLight;
        public static CarIdProgrammer _carIdProgrammer;
        //public static PitPro pitPro;

        public static FontManager fontManager;

        public static string DataPath;

        static TextWriter logger;
        static Thread hwInterfaceThread;
        static Thread sensorsInterfaceThread;
        static Thread slInterfaceThread;
        static Thread carIdProgrammerThread;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //int port = 666;
            //if (FirewallUtils.IsPortOpen(port))
            //    FirewallUtils.ClosePort(port);
            //FirewallUtils.OpenPort(port, "ESRM API");

            logger = File.AppendText("log.txt");

            Log("Open Application");

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

;
            try
            {
                string ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                DataPath = Path.Combine(ProgramDataPath, "ESRM");

                CreateDataDirectory();

                GetOldDatasFiles();

                Log("Initialising Ressources");
                InitRessources();
                Log("Initialised");
                Log("Initialising Licence");
                InitLicence();
                Log("Initialised");

                // JUST FOR TESTS ! 
                Application.CurrentCulture = CultureInfo.GetCultureInfo("en");

                Log("Set Culture");
                if (Application.CurrentCulture.Name.StartsWith("en")  || !Application.CurrentCulture.Name.StartsWith("fr"))
                {
                    Application.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                    Thread.CurrentThread.CurrentCulture = Application.CurrentCulture;
                    Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
                }

                Log("register Skins");
                DevExpress.UserSkins.BonusSkins.Register();


                Application.ApplicationExit += ApplicationExit;
                Application.ThreadException += Application_ThreadException;

                UserLookAndFeel.Default.SkinName = "Darkroom";
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                fontManager = new FontManager();

                Log("Run Main Form");

                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                Log(e.Message);
            }
        }
        
        static void CreateDataDirectory()
        {
            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);

            DirectoryInfo info = new DirectoryInfo(DataPath);

            DirectorySecurity security = info.GetAccessControl();

            // Using this instead of the "Everyone" string means we work on non-English systems.
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            security.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(DataPath, security);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show(e.Exception.Message);
                Log(e.Exception.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log(e.Exception.Message);
            }
        }

        public static void GetOldDatasFiles()
        {
            string oldDataPath = Path.GetDirectoryName(Application.LocalUserAppDataPath);
            oldDataPath = Path.Combine(oldDataPath, "Data", "Files");
            string  newPath = Path.Combine(DataPath, "Data", "Files");
            try
            {
                DirectoryCopy(oldDataPath, newPath, false);
            }
            catch(Exception ex)
            {
            }
        }

        /// <summary>
        /// Copie des fichiers nécessaires au fonctionnement de l'application
        /// Images
        /// Sons
        /// Datas
        /// Si les fichiers existent on les conserve, sinon on récupères ceux qui sont distribués avec la version
        /// </summary>
        public static void InitRessources()
        {
            try
            {
                // images
                if (!Directory.Exists(Path.Combine(DataPath, "Images")))
                  DirectoryCopy(Path.Combine(Application.StartupPath, "Images"), Path.Combine(DataPath, "Images"), true);

                // sons
                if (!Directory.Exists(Path.Combine(DataPath, "Sounds")))
                    DirectoryCopy(Path.Combine(Application.StartupPath, "Sounds"), Path.Combine(DataPath, "Sounds"), true);

                //// datas
                //if (!Directory.Exists(Path.Combine(DataPath, "Datas")))
                //    DirectoryCopy(Path.Combine(Application.StartupPath, "Datas"), Path.Combine(DataPath, "Datas"), true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: "+ sourceDirName);
            }

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);


                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
        }


        public static void InitLicence()
        {
            // récupération de l'ID de la machine en fonction de son adresse MAC
            //NetworkInterface[] networkInterface = NetworkInterface.GetAllNetworkInterfaces();
            //licenceId = networkInterface.FirstOrDefault().Id.ToString() ;
            //licenceId = licenceId.Replace("{", "").Replace("}","");
            //Guid.TryParse(licenceId, out macAddressGuid);

            // ouverture de la licence
            //bool licSignOk = false;
            //if (File.Exists(Path.Combine(Program.DataPath, "License.lic")))
            //{
            //    FileStream stream = File.Open(Path.Combine(Program.DataPath, "License.lic"), FileMode.Open);
            //    Portable.Licensing.License vLicence = Portable.Licensing.License.Load(stream);
            //    // la licence est ok si elle est signée correctement et que son ID correspond à l'ID de la machine.
            //    licSignOk = vLicence.VerifySignature(publicKey) && vLicence.Id == macAddressGuid;
            //    if (licSignOk)
            //        Licence = new ESRMLicence(vLicence);
            //}
            //// sinon on passe en mode Trial
            //if (Licence == null)
            //    Licence = new ESRMLicence(null);

            //if (Licence.IsTrial)
            //    MessageBox.Show(Textes.TrialVersion + Licence.LimitationDescription);

            // temporaire
               Licence = new ESRMLicence(null,false);
        }

        #region HARDWARES INTERFACES


        public static void GetComPorts()
        {
           // List<string> result = new List<string>();
            string[] result = SerialPort.GetPortNames();
            _digitalParams.OpenedComPort = new List<string>();
            _digitalParams.OpenedComPort.AddRange(result);
        }
        static public void InitHardwareConnexionThread( IDigitalParamsBase digitalParams,bool searchComPorts)
        {
            _digitalParams = digitalParams;
            if (searchComPorts || _digitalParams.OpenedComPort == null || _digitalParams.OpenedComPort.Count == 0 || !_digitalParams.OpenedComPort.Contains(_digitalParams.ComPort))
                GetComPorts();



            if (hwInterfaceThread == null || !hwInterfaceThread.IsAlive)
            {
                hwInterfaceThread = new Thread(InitAPBConnexion);
            }
            else if (hwInterfaceThread.IsAlive)
            {
                hwInterfaceThread.Abort();
                Thread.Sleep(50);
            }
            hwInterfaceThread.Name = "ESRM.WIN.SSDInterface";
            hwInterfaceThread.Priority = ThreadPriority.Normal;
            hwInterfaceThread.IsBackground = true;
            hwInterfaceThread.Start();

            IniStartLightConnexionThread(digitalParams);
            Thread.Sleep(100);
            IniSensorsConnexionThread(digitalParams);
            Thread.Sleep(100);
            IniCarIdProgrammerConnexionThread(digitalParams);
        }


        static public void IniSensorsConnexionThread(IDigitalParamsBase digitalParams)
        {
            _digitalParams = digitalParams;

            if (sensorsInterfaceThread == null || !sensorsInterfaceThread.IsAlive)
            {
                sensorsInterfaceThread = new Thread(InitPitSensorsConnexion);
            }
            else if (sensorsInterfaceThread.IsAlive)
            {
                sensorsInterfaceThread.Abort();
                Thread.Sleep(50);
            }

            sensorsInterfaceThread.Name = "ESRM.WIN.SensorsInterface";
            sensorsInterfaceThread.Priority = ThreadPriority.Normal;
            sensorsInterfaceThread.IsBackground = true;
            sensorsInterfaceThread.Start();
        }

        static public void IniStartLightConnexionThread(IDigitalParamsBase digitalParams)
        {
            _digitalParams = digitalParams;

            if (slInterfaceThread == null || !slInterfaceThread.IsAlive)
            {
                slInterfaceThread = new Thread(InitStartLightConnexion);
            }
            else if (slInterfaceThread.IsAlive)
            {
                slInterfaceThread.Abort();
                Thread.Sleep(50);
            }

            slInterfaceThread.Name = "ESRM.WIN.StartLigth";
            slInterfaceThread.Priority = ThreadPriority.Normal;
            slInterfaceThread.IsBackground = true;
            slInterfaceThread.Start();
        }

        static public void IniCarIdProgrammerConnexionThread(IDigitalParamsBase digitalParams)
        {
            _digitalParams = digitalParams;

            if (carIdProgrammerThread == null || !carIdProgrammerThread.IsAlive)
            {
                carIdProgrammerThread = new Thread(InitCarIdProgrammerConnexion);
            }
            else if (carIdProgrammerThread.IsAlive)
            {
                carIdProgrammerThread.Abort();
                Thread.Sleep(50);
            }

            carIdProgrammerThread.Name = "ESRM.WIN.CarIdProgrammer";
            carIdProgrammerThread.Priority = ThreadPriority.Lowest;
            carIdProgrammerThread.IsBackground = true;
            carIdProgrammerThread.Start();
        }

        

        static public void ResetHardwareConnexion(IDigitalParamsBase digitalParams)
        {
            InitHardwareConnexionThread(digitalParams,false);
        }

        private static void CloseHardwareConnexions()
        {
            CloseAPBConnexions();
            ClosePitSensorsConnexion();
        }


        #region SSD
        static private void InitAPBConnexion()
        {
            // si une instance de PB est créée on ferme la connexion pour libérer le port com
            if (hwInterface != null)
            {
                hwInterface.CloseConnexionCommand();
            }

            if (hwInterface == null)
            {
                hwInterface = new SSDInterface();

                if (string.IsNullOrEmpty(_digitalParams.ComPort) && _digitalParams.OpenedComPort.Count == 1)
                    _digitalParams.ComPort = _digitalParams.OpenedComPort[0];

                hwInterface.SetDigitalParams(_digitalParams);
                //hwInterface.SetCallBackLogging(Log);
                (hwInterface as SSDInterface)._logging = false;
            }

            if (hwInterface.DetectCommand())
                ConnectToAPB(false);

            Thread.Sleep(30);
        }

        static private void ResetAPBConnexionInternal()
        {
            // si une instance de PB est créée on ferme la connexion pour libérer le port com
            if (hwInterface != null)
            {
                hwInterface.CloseConnexionCommand();
                Thread.Sleep(30);
                hwInterface.Dispose();
                Thread.Sleep(30);
                hwInterface = null;
            }

            InitAPBConnexion();
        }

        private static void ConnectToAPB(bool sendResetPacket)
        {
            hwInterface.ConnectToCommand(sendResetPacket);
            Thread.Sleep(30);
           // hwInterface.StartCommand();
        }
        
        private static void CloseAPBConnexions()
        {
            hwInterface.ResetCommand();
            Thread.Sleep(30);
            hwInterface.CloseConnexionCommand();
            Thread.Sleep(30);
            hwInterface.Dispose();
        }
        #endregion SSD

       #region PIT SENSORS
       static private void InitPitSensorsConnexion()
        {
            if (pitSensors == null)
            {
                //_digitalParams.PitSmartSensorsParams.SensorsCount = 1;
                //_digitalParams.PitSmartSensorsParams.SensorProtocol = SensorProtocolEnum.PP;

                pitSensors = new SmartSensorInterface_ForPitLane(_digitalParams);
                //pitSensors.SetCallBackLogging(Log);

                _digitalParams.PitSmartSensorsParams.OpenedComPort = new List<string>();
                if(_digitalParams.PitSmartSensorsParams.OpenedComPort != null)
                     _digitalParams.PitSmartSensorsParams.OpenedComPort.AddRange(_digitalParams.OpenedComPort);

                //_digitalParams.PitSmartSensorsParams.OpenedComPort = pitSensors.GetComPorts();
                if (!string.IsNullOrEmpty(_digitalParams.ComPort) && _digitalParams.PitSmartSensorsParams.OpenedComPort.Contains(_digitalParams.ComPort))
                    _digitalParams.PitSmartSensorsParams.OpenedComPort.Remove(_digitalParams.ComPort);
                //if (!string.IsNullOrEmpty(_digitalParams.StartLightComPort) && _digitalParams.PitSmartSensorsParams.OpenedComPort.Contains(_digitalParams.StartLightComPort))
                //    _digitalParams.PitSmartSensorsParams.OpenedComPort.Remove(_digitalParams.StartLightComPort);

                if (string.IsNullOrEmpty(_digitalParams.PitSmartSensorsParams.ComPort) && _digitalParams.PitSmartSensorsParams.OpenedComPort != null && _digitalParams.PitSmartSensorsParams.OpenedComPort.Count == 1)
                    _digitalParams.PitSmartSensorsParams.ComPort = _digitalParams.PitSmartSensorsParams.OpenedComPort[0];
                else if( _digitalParams.PitSmartSensorsParams.OpenedComPort == null || _digitalParams.PitSmartSensorsParams.OpenedComPort.Count == 0)
                    _digitalParams.PitSmartSensorsParams.ComPort = string.Empty;
            }

            if (!string.IsNullOrEmpty(_digitalParams.PitSmartSensorsParams.ComPort))
            {
                ConnectToPitSensors();
            }
        }

        static private void ResetPitSensorsConnexion()
        {
            // si une instance de PB est créée on ferme la connexion pour libérer le port com
            ClosePitSensorsConnexion();
            Thread.Sleep(1000);
            InitPitSensorsConnexion();
        }

        private static void ConnectToPitSensors()
        {
            pitSensors.ConnectToCommand();
            Thread.Sleep(2000);
            //pitSensors.SetMode((int)_digitalParams.PitSmartSensorsParams.SensorProtocol);
        }

        private static void ClosePitSensorsConnexion()
        {
            if (pitSensors != null)
            {
                pitSensors.CloseConnexion();
                pitSensors.Dispose();
                pitSensors = null;
            }
        }
        #endregion PIT SENSORS

        #region START LIGHTS
        static private void InitStartLightConnexion()
        {
            if (_startLight == null)
            {
                _startLight = new StartLights(_digitalParams);

                //_digitalParams.PitSmartSensorsParams.OpenedComPort = new List<string>();
                //if (_digitalParams.OpenedComPort != null)
                //    _digitalParams.PitSmartSensorsParams.OpenedComPort.AddRange(_digitalParams.OpenedComPort);

                //if (!string.IsNullOrEmpty(_digitalParams.ComPort) && _digitalParams.PitSmartSensorsParams.OpenedComPort.Contains(_digitalParams.ComPort))
                //    _digitalParams.PitSmartSensorsParams.OpenedComPort.Remove(_digitalParams.ComPort);

                //if (string.IsNullOrEmpty(_digitalParams.PitSmartSensorsParams.ComPort) && _digitalParams.PitSmartSensorsParams.OpenedComPort != null && _digitalParams.PitSmartSensorsParams.OpenedComPort.Count == 1)
                //    _digitalParams.PitSmartSensorsParams.ComPort = _digitalParams.PitSmartSensorsParams.OpenedComPort[0];
                //else if (_digitalParams.PitSmartSensorsParams.OpenedComPort == null || _digitalParams.PitSmartSensorsParams.OpenedComPort.Count == 0)
                //    _digitalParams.PitSmartSensorsParams.ComPort = string.Empty;
            }

            if (_digitalParams.OpenedComPort != null && _digitalParams.UseStartLight)
            {
                ConnectToStartLight();
            }
        }

        static private void ResetStartLightConnexion()
        {
            // si une instance de PB est créée on ferme la connexion pour libérer le port com
            CloseStartLightConnexion();
            InitStartLightConnexion();
        }

        private static void ConnectToStartLight()
        {
            _startLight.ConnectToCommand();
        }

        private static void CloseStartLightConnexion()
        {
            if (_startLight != null)
            {
                _startLight.CloseConnexion();
                _startLight.Dispose();
                _startLight = null;
            }
        }
        #endregion START LIGHT


        #region CAR ID PROGRAMMER
        static private void InitCarIdProgrammerConnexion()
        {
            if (_carIdProgrammer == null)
            {
                _carIdProgrammer = new CarIdProgrammer(_digitalParams);
            }

            if (_digitalParams.OpenedComPort != null && _digitalParams.UseCarIdProgrammer)
            {
                ConnectToCarIdProgrammer();
            }
        }

        static private void ResetCarIdProgrammerConnexion()
        {
            // si une instance de PB est créée on ferme la connexion pour libérer le port com
            CloseCarIdProgrammerConnexion();
            InitCarIdProgrammerConnexion();
        }

        private static void ConnectToCarIdProgrammer()
        {
            _carIdProgrammer.ConnectToCommand();
        }

        private static void CloseCarIdProgrammerConnexion()
        {
            if (_carIdProgrammer != null)
            {
                _carIdProgrammer.CloseConnexion();
                _carIdProgrammer.Dispose();
                _carIdProgrammer = null;
            }
        }
        #endregion CAR ID PROGRAMMER



        #endregion



        static void ApplicationExit(object sender, EventArgs e)
        {
            CloseHardwareConnexions();

            logger.Close();
            logger.Dispose();
            logger = null;
        }

        public static string GetGamePadConnections()
        {
            string message = string.Empty;
            message += string.Format("GamePad API : {0} ", GamePadFactory.GetAPIType()) + Environment.NewLine;

            for (int i = 0; i <= 5; i++)
            {
                //ESRMGamePad gp = new ESRMGamePad(i);
                if (GamePadFactory.IsConnected(i))
                {
                    //message += string.Format("GamePad {0} is connected, type : {1}", i, gp.GetGamePadType());
                    message += string.Format("GamePad {0} is connected ", i);

                    string errorTest = string.Empty;
                    //if (gp.TestButtons(ref errorTest))
                    //    message += Environment.NewLine + string.Format("GamePad {0} Button test OK", i);
                    //else
                    //    message += Environment.NewLine + string.Format("GamePad {0} Button test Error {1}", i, errorTest);
                }
                else
                {
                    message += string.Format("GamePad {0} is NOT connected", i);
                }

                message += Environment.NewLine;
            }

            return message;
        }


        public static void Log(string logMessage)
        {
            //logger.Write("\r\nLog Entry : ");
            //logger.WriteLine("{0} {1}", DateTime.Now.Date.ToShortDateString(),DateTime.Now.ToString("HH:mm:ss.ffff"));
            //logger.WriteLine("  :{0}", logMessage);
            //logger.WriteLine("-------------------------------");
        }

        public static void StartHttpService()
        {


        }
   }
}
