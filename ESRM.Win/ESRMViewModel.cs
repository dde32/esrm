using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ESRM.Entities.ViewsModels;

namespace ESRM.Win
{

    class ESRMViewModel : ESRMViewModelBase
    {
        public WindowsUIView view { get; set; } // vue principale
        public Form mainForm { get; set; } // fenetre de l'application
        public new IContentContainer CurrentPage { get; set; }

        public ESRMViewModel(WindowsUIView view, Form mainForm):base()
        {
            this.view = view;
            this.mainForm = mainForm;
            //modelRootPath = Path.Combine(Program.DataPath, "Datas", "Files");
            modelRootPath = Path.Combine(Program.DataPath, "Data", "Files");
            soundsRootPath = Path.Combine(Program.DataPath, "Sounds");

            PilotsFilePath = Path.Combine(modelRootPath, PilotsFile);
            DigitalParamsFilePath = Path.Combine(modelRootPath, DigitalParamsFile);
            CarsFilePath = Path.Combine(modelRootPath, CarsFile);
            TracksFilePath = Path.Combine(modelRootPath, TracksFile);
            RecordsFilePath = Path.Combine(modelRootPath, RecordsFile);
            LastPracticeParametersFilePath = Path.Combine(modelRootPath, LastPracticeParametersFile);
            LastGPParametersFilePath = Path.Combine(modelRootPath, LastGPParametersFile);
            LastEnduranceParametersFilePath = Path.Combine(modelRootPath, LastEnduranceParametersFile);
            LastTimeAttackParametersFilePath = Path.Combine(modelRootPath, LastTimeAttackParametersFile);
            LastRallyCrossParametersFilePath = Path.Combine(modelRootPath, LastRallyCrossParametersFile);
            LastTeamsFilePath = Path.Combine(modelRootPath, LastTeamsFile);
            TiresParamsFilePath = Path.Combine(modelRootPath, TiresParamsFile);
            HandsetThrottleCurvesFilePath = Path.Combine(modelRootPath, HandsetThrottleCurvesFile);
            GamepadThrottleCurvesFilePath = Path.Combine(modelRootPath, GamepadThrottleCurvesFile);
            GamepagBrakeCurvesFilePath = Path.Combine(modelRootPath, GamepagBrakeCurvesFile);
            SoundSettingsFilePath = Path.Combine(modelRootPath, SoundSettingsFile);
            GamePadICPBrakesCurvesFilePath = Path.Combine(modelRootPath, GamePadICPBrakesCurvesFile);

            InitModel();
        }      

        protected override  Stream FromFile(string filePath)
        {
            FileStream f = null;
            if (File.Exists(filePath))
                f = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return f;
        }

        protected override void ToFile(MemoryStream str,string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            FileStream file = null;
            file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            str.WriteTo(file);
            file.Close();
            str.Close();
        }

        protected override void EnsureFoldersExists()
        {
            if (!Directory.Exists(modelRootPath))
                Directory.CreateDirectory(modelRootPath);
        }

        public override void ActivatePage(string pageName)
        {
           IContentContainer page = view.ContentContainers[pageName] as IContentContainer;


                view.ActivateContainer(page);
        }

        public override void Close(bool isClosing)
        {
            if (isClosing)
            {
                Flyout flyout = view.ContentContainers["closeFlyout"] as Flyout;
                flyout.Action = new FlyoutAction()
                {
                    Caption = "Setup Wizard",
                    Description = "Are you sure you want to exit the setup?"
                };
                view.FlyoutHidden += view_FlyoutHidden;
                view.ActivateContainer(flyout);
            }
            else Close();
        }

        void view_FlyoutHidden(object sender, FlyoutResultEventArgs e)
        {
            view.FlyoutHidden -= view_FlyoutHidden;
            if (e.Result == System.Windows.Forms.DialogResult.Yes)
                Close();
        }

        void Close()
        {
            mainForm.BeginInvoke(new System.Action(mainForm.Close));
        }
    }
}
