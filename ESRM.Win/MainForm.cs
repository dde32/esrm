using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using System.Drawing;
using ESRM.Win.Views;
using ESRM.Entities;
using System.Windows.Forms;
using System;
using System.Threading;
using ESRM.HWInterfaces;
using Nancy.Hosting.Self;
using Nancy;
using System.Threading.Tasks;

namespace ESRM.Win
{
    public partial class MainForm : XtraForm
    {
        IESRMViewModel appViewModel;
        static NancyHost _host;
        static Thread _httpServerThread;

        
        public MainForm()
        {
            Program.Log("Main Form initialisation");

            try
            {
                InitializeComponent();
                windowsUIView.UseSplashScreen = DevExpress.Utils.DefaultBoolean.False;
                _httpServerThread = new Thread(StartWebServer);
                _httpServerThread.Start();
            }
            catch (Exception ex)
            {
                Program.Log("Error INIT MainForm : " + ex.Message);
            }

            Program.Log("Main Form initialised");

            // Handling the QueryControl event that will populate all automatically generated Documents
            this.windowsUIView.QueryControl += windowsUIView_QueryControl;

            Program.Log("Main Form  : Model creation");
            appViewModel = new ESRMViewModel(windowsUIView, this);
            Program.Log("Main Form  : Created");
            windowsUIView.Caption +=" " + Application.ProductVersion;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if(_httpServerThread != null)
                {
                    if(_host != null)
                       _host.Stop();
                    _httpServerThread.Abort();
                    _httpServerThread = null;
                }

                components.Dispose();

            }
            base.Dispose(disposing);
        }

        protected void StartWebServer()
        {
            try
            {
                HostConfiguration hostConfigs = new HostConfiguration();
                hostConfigs.UrlReservations.CreateAutomatically = true;
                string serverURL = "http://localhost:666";
                MainForm._host = new NancyHost(new Uri(serverURL), new DefaultNancyBootstrapper(), hostConfigs);

                _host.Start();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        } 


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Program.Log("Init PB Connexion");
            Program.InitHardwareConnexionThread(appViewModel.DigitalParams,true);
            Program.Log("PB Connexion Initialised");
            Thread.Sleep(300);
            ChangeConnexionButtonColor();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_host != null)
                _host.Stop();

            base.OnFormClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            appViewModel.SaveRecords();
            Program.hwInterface.ResetCommand();
            Thread.Sleep(5);
            base.OnClosed(e);
        }

        // Assigning a required content for each auto generated Document
        void windowsUIView_QueryControl(object sender, QueryControlEventArgs e)
        {
            try
            {
                if (e.Document == mainMenuPageDocument)
                {
                    e.Control = new ESRM.Win.Views.MainMenuPage();
                }
                if (e.Document == driverAndCarSelectionDocument)
                    e.Control = new ESRM.Win.Views.DriverAndCarSelectionPage();
                if (e.Document == raceParamsPageDocument)
                    e.Control = new ESRM.Win.Views.RaceParamsPage();
                if (e.Document == tracksPageDocument)
                    e.Control = new ESRM.Win.Views.TracksPage();
                if (e.Document == racePageDocument)
                    e.Control = new ESRM.Win.Views.RacePage();
                if (e.Document == RPTeamsPageDocument)
                    e.Control = new ESRM.Win.RPTeamsPage();
                if (e.Control == null)
                    e.Control = new System.Windows.Forms.Control();
                if (e.Document == lapCountPageDocument)
                    e.Control = new ESRM.Win.Views.LapCountPage();
                if (e.Document == testPageSSDDocument)
                    e.Control = new ESRM.Win.Views.TestPageSSD();
                if (e.Document == endRacePageDocument)
                    e.Control = new ESRM.Win.Views.EndRacePage();
                if (e.Document == timeAttackRaceParamsPageDocument)
                    e.Control = new ESRM.Win.Views.TimeAttackRaceParamsPage();
                if (e.Document == digitalParamsPageDocument)
                    e.Control = new ESRM.Win.Views.DigitalParamsPage();
                if (e.Document == GaragePageDocument)
                    e.Control = new ESRM.Win.Views.GaragePage();
                if (e.Document == PilotePageDocument)
                    e.Control = new ESRM.Win.Views.PilotPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Program.Log(ex.Message);
            }
        }

        private void windowsUIView_NavigatedFrom(object sender, NavigationEventArgs e)
        {
            ChangeConnexionButtonColor();
        }

        public void SetTitle(string documentTitle)
        {
            windowsUIView.Caption = documentTitle;
        }

        public void ChangeConnexionButtonColor()
        {

            //Program.Log("Change connexion Button color");

            if (Program.hwInterface == null || !Program.hwInterface.IsConnected())
            {
                pageMainMenu.Buttons[3].Properties.Appearance.ForeColor = Color.Red;
                if(pageRace.Container != null)
                   pageRace.Buttons[1].Properties.Appearance.ForeColor = Color.Red;
            }
            else
            {
                pageMainMenu.Buttons[3].Properties.Appearance.ForeColor = Color.Green;
                if (pageRace.Container != null)
                    pageRace.Buttons[1].Properties.Appearance.ForeColor = Color.Green;
            }
            //Program.Log("Connexion Button color changed");
        }

        private void windowsUIView_NavigatedTo(object sender, NavigationEventArgs e)
        {
            Program.Log("Navigated to " + e.Target.Name.ToString());

            e.Parameter = appViewModel;

            if (e.Target.Name == "RPTeamsPage" || e.Target.Name == "pageRace")
            {
                e.Target.Parent = (appViewModel as ESRMViewModel).CurrentPage;
            }
            else if (e.Target.Name == "pageMainMenu")
            {
                //if (Program.hwInterface == null || !Program.hwInterface.IsConnected())
                //    MessageBox.Show(Textes.Message_NoPB);
            }
            else if (e.Target.Name == "pageEndRace")
            {
                e.Target.Parent = (appViewModel as ESRMViewModel).CurrentPage.Parent;
            }

          (appViewModel as ESRMViewModel).CurrentPage = e.Target;

            Program.Log("End Navigated to " + e.Target.Name.ToString());
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Program.hwInterface.CloseConnexionCommand();
            base.OnClosing(e);
        }

        #region BOUTONS GLOBAUX

        private void pageRace_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == pageRace.Buttons[0]) // Go To Main Page
            {
                this.appViewModel.ActivatePage("pageMainMenu");
            }
        }

        private void pageMainMenu_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Tag.ToString() == "Configuration")
            {
                appViewModel.ActivatePage("pageDigitalParams");
            }
            if (e.Button.Properties.Tag.ToString() == "Reset")
            {
                Program.ResetHardwareConnexion(appViewModel.DigitalParams);
                Thread.Sleep(350);
                ChangeConnexionButtonColor();
            }
            if (e.Button.Properties.Tag.ToString() == "Exit")
            {
                Application.Exit();
            }
            if (e.Button.Properties.Tag.ToString() == "Records")
            {
                RecordsForm form = new RecordsForm(appViewModel);
                form.ShowDialog();
            }
            if (e.Button.Properties.Tag.ToString() == "Pilots")
            {
                appViewModel.ActivatePage("pagePilotes");
            }
            if (e.Button.Properties.Tag.ToString() == "Cars")
            {
                appViewModel.ActivatePage("pageGarage");
            }
        }

        private void pageRace_ButtonClick_1(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == pageRace.Buttons[0]) // monitoring
            {
                (pageRace.Document.Control as RacePage).ShowMonitoringDialog();
            }
            else if (e.Button == pageRace.Buttons[1]) // Reset connexion
            {
                (pageRace.Document.Control as RacePage).ResetConnexion();
            }
            else if (e.Button == pageRace.Buttons[2]) // affichage secondaire
            {
                (pageRace.Document.Control as RacePage).ShowSecondRaceView();    
            }

        }
        #endregion


        protected override void OnSizeChanged(EventArgs e)
        {
            this.PerformLayout();
        }
    }
}
