using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using ESRM.Win.Views;
using ESRM.Win.Panels;

namespace ESRM.Win
{
    public partial class DriverAndCarSelectionPanel : ScalableControl
    {
        TeamInRace _team;
        SelectablePanel _currentPanel;
        DriverAndCarSelectionPage _parentPage;

        int?[] _driverIndex;
        int? _car;
        bool _ready;
        bool _active;
        int _driverCount;
        int _currentDriverIdx;
        int _maxDriverCount;
        List<Pilot> _allDrivers;
        List<Car> _allCars;
        Pacer _pacerInfos;

        #region PROPERTIES

        public bool IsReady
        {
            get { return _active && _ready || !_active; }
        }
        public bool Activated
        {
            get { return _active; }
        }
        #endregion

        #region TOOLS
        Color ContrastColor(Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }

        public static string GetForegroundColor(string colorCode)
        {
            var c = System.Drawing.ColorTranslator.FromHtml(colorCode);
            return Brightness(c) < 130 ? "#FFFFFF" : "#000000";
        }

        public static Color GetForegroundColor(int colorCode)
        {
            var c = Color.FromArgb(colorCode);
            return Brightness(c) < 130 ? Color.White : Color.Black;
        }

        private static int Brightness(Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }


        #endregion

        #region DISPOSE
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                _team = null;
            }

            base.Dispose(disposing);
        }
        #endregion DISPOSE


        public DriverAndCarSelectionPanel()
        {
            InitializeComponent();
            InitPanel();
        }

        private void InitPanel()
        {
            _driverCount = 1;
            _currentDriverIdx = 0;
            _ready = false;
            _active = false;
            _driverIndex = new int?[3];

            panelDriverCount.Enabled = false;
            panelDriverCount.ParentPanel = this;
            panelDriverCount.UpPanel = null;
            panelDriverCount.DownPanel = panelIdDriver;

            panelIdDriver.Enabled = false;
            panelIdDriver.ParentPanel = this;
            panelIdDriver.UpPanel = panelDriverCount;
            panelIdDriver.DownPanel = panelDriver;

            panelDriver.Enabled = false;
            panelDriver.ParentPanel = this;
            panelDriver.UpPanel = panelIdDriver;
            panelDriver.DownPanel = panelCar;

            panelCar.Enabled = false;
            panelCar.ParentPanel = this;
            panelCar.UpPanel = panelDriver;
            panelCar.DownPanel = panelReady;

            panelReady.Enabled = false;
            panelReady.ParentPanel = this;
            panelReady.UpPanel = panelCar;
            panelReady.DownPanel = null;
            _originalSize = Size;

            _ready = false;
            _driverIndex[0] = null;
            _driverIndex[1] = null;
            _driverIndex[2] = null;
            _car = null;

            lblDriver2.Visible = _driverCount >= 2;
            lblDriver3.Visible = _driverCount >= 3;


            pbDriverImage.Image = null;
            lblDriverName.Text = string.Empty;

            pbCarImage.Image = null;
            lblCarName.Text = string.Empty;

            Color foreColor = Color.White;
            Color panelFocusColor = Color.FromArgb(75, Color.White);

            panelDriverCount.SelectedColor = panelFocusColor;
            panelIdDriver.SelectedColor = panelFocusColor;
            panelDriver.SelectedColor = panelFocusColor;
            panelCar.SelectedColor = panelFocusColor;
            panelReady.SelectedColor = panelFocusColor;


            lblCarName.ForeColor = foreColor;
            lblDriverName.ForeColor = foreColor;
            lblLaneId.ForeColor = foreColor;
            lblNbDrivers.ForeColor = foreColor;
            lblTeam.ForeColor = foreColor;
            lblDriversInTeam.ForeColor = foreColor;
            panelTeamColor.BackColor = foreColor;

            panelReady.Enabled = false;
            lblReady.ForeColor = Color.White;
        }

        public DriverAndCarSelectionPanel(DriverAndCarSelectionPage parentPage, List<Pilot> drivers, List<Car> cars, int id, int maxDriverCount)
        {
            InitializeComponent();
            _maxDriverCount = maxDriverCount;
            _parentPage = parentPage;
            _allDrivers = drivers.OrderBy(d=>d.Name).ToList();
            _allCars = cars.OrderBy(c=>c.Name).ToList();
            _originalSize = Size;
            lblLaneId.Text = id.ToString();
            lblNbDrivers.Text = _maxDriverCount.ToString();
            InitPanel();
        }

        public void Reset()
        {
            InitPanel();
        }

        public void SetInitialValues(TeamInRace team)
        {
            _driverIndex[0] = _allDrivers.FindIndex(d => d.Name == team.Pilot1.Name);
            if(team.Pilot2 != null)
                _driverIndex[1] = _allDrivers.FindIndex(d => d.Name == team.Pilot2.Name);
            if (team.Pilot3 != null)
                _driverIndex[2] = _allDrivers.FindIndex(d => d.Name == team.Pilot3.Name);
            if (team.Car != null)
                _car = _allCars.FindIndex(d => d.Name == team.Car.Name);

            _pacerInfos = team.Pacer;
            DisplayCurrentDriverInfos();
        }



        #region PAINTING ET SCALE
        Size _originalSize;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        
        protected override void ScaleCore(float dx, float dy)
        {
            base.ScaleCore(dx, dy);
        }


        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            if (float.IsInfinity(factor.Height) || float.IsInfinity(factor.Width))
                return;

            this.SuspendLayout();
           // base.ScaleControl(factor, BoundsSpecified.All);


            if (!_lastRatio.HasValue || _lastRatio.Value == 0)
                _lastRatio = 1;

            // float ratio = factor.Height > factor.Width ? factor.Height : factor.Width;
            float ratio = Math.Max(factor.Width, factor.Height * 0.85f);

            if (factor.Height > 1.5 * factor.Width || factor.Width > 1.5 * factor.Height)
                ratio = ratio * (float)0.85;

            //foreach (Control ctrl in Controls)

            DeepScaleControl(panelName, ratio, _lastRatio.Value, specified, factor);
            DeepScaleControl(panelDriverCount, ratio, _lastRatio.Value, specified, factor);
            DeepScaleControl(panelIdDriver, ratio, _lastRatio.Value, specified, factor);
            DeepScaleControl(panelDriver, ratio, _lastRatio.Value, specified, factor);
            DeepScaleControl(panelCar, ratio, _lastRatio.Value, specified, factor);
            DeepScaleControl(panelReady, ratio, _lastRatio.Value, specified, factor);

            _lastRatio = ratio;

            this.ResumeLayout();
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            if (_originalSize.Height > 0 && _originalSize.Width > 0)
            {
                SizeF factor = new SizeF(Size.Width / _originalSize.Width, (float)((float)Size.Height / (float)_originalSize.Height));
                ScaleControl(factor, BoundsSpecified.All);
            }

            base.OnSizeChanged(e);
        }

        //public void SuspendAllLayout()
        //{
        //    this.panelTeamHeader.SuspendLayout();
        //    this.panelTeam.SuspendLayout();
        //    this.panelName.SuspendLayout();
        //    ((System.ComponentModel.ISupportInitialize)(this.pbDriverImage.Properties)).BeginInit();
        //    this.SuspendLayout();
        //}

        //public void ResumeAllLayout()
        //{
        //    this.panelTeamHeader.ResumeLayout(false);
        //    this.panelTeam.ResumeLayout(false);
        //    this.panelName.ResumeLayout(false);
        //    ((System.ComponentModel.ISupportInitialize)(this.pbDriverImage.Properties)).EndInit();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();
        //}

        #endregion

        public void PreviousValueCommand()
        {
            this.BeginInvoke(new StandardCallBack(PreviousValue));
        }
        public void UpPanelCommand()
        {
            this.BeginInvoke(new StandardCallBack(ActivateUpPanel));
        }
        public void DownPanelCommand()
        {
            this.BeginInvoke(new StandardCallBack(ActivateDownPanel));
        }

        public void NextValueCommand()
        {
            this.BeginInvoke(new StandardCallBack(NextValue));
        }
        public void ReadyCommand()
        {
            this.BeginInvoke(new StandardCallBack(Ready));
        }
        public void NotReadyCommand()
        {
            this.BeginInvoke(new StandardCallBack(NotReady));
        }



        private bool ActivatePanel()
        {
            if (_active)
                return false;

            _active = true;
            panelDriverCount.Enabled = true;
            panelIdDriver.Enabled = true;
            panelDriver.Enabled = true;
            panelCar.Enabled = true;

            _currentPanel = panelDriverCount;
            panelDriverCount.FocusPanel(true);
            panelIdDriver.FocusPanel(false);
            panelDriver.FocusPanel(false);
            panelCar.FocusPanel(false);
            panelReady.FocusPanel(false);

            DisplayCurrentDriverInfos();
            return true;
        }

        private void ActivateUpPanel()
        {
            if (!ActivatePanel())
            {
                if (_ready) // si on est prêt on ne change plus rien
                    return;
                if (_currentPanel == null)
                    _currentPanel = panelDriverCount;
                else
                {
                    if (_currentPanel.UpPanel != null)
                    {
                        _currentPanel.FocusPanel(false);
                        _currentPanel.UpPanel.FocusPanel(true);
                        _currentPanel = _currentPanel.UpPanel;
                    }
                }
            }
        }

        private void ActivateDownPanel()
        {
            if (!ActivatePanel())
            {

                if (_ready) // si on est prêt on ne change plus rien
                    return;
                if (_currentPanel == null)
                    _currentPanel = panelDriverCount;
                else
                {
                    if (_currentPanel.DownPanel != null)
                    {
                        _currentPanel.FocusPanel(false);
                        _currentPanel.DownPanel.FocusPanel(true);
                        _currentPanel = _currentPanel.DownPanel;
                    }
                }
            }
        }


        private void NextValue()
        {
            if (!ActivatePanel())
            {

                if (_currentPanel == panelDriverCount)
                    NextValue_DriverCount();
                else if (_currentPanel == panelIdDriver)
                    NextValue_IdDriver();
                else if (_currentPanel == panelDriver)
                    NextValue_Driver();
                else if (_currentPanel == panelCar)
                    NextValue_Car();
                else if (_currentPanel == panelReady)
                    NextValue_Ready();
            }
        }
        private void PreviousValue()
        {
            if (!ActivatePanel())
            {

                if (_currentPanel == panelDriverCount)
                    PreviousValue_DriverCount();
                else if (_currentPanel == panelIdDriver)
                    PreviousValue_IdDriver();
                else if (_currentPanel == panelDriver)
                    PreviousValue_Driver();
                else if (_currentPanel == panelCar)
                    PreviousValue_Car();
                else if (_currentPanel == panelReady)
                    PreviousValue_Ready();
            }
        }


        private void PreviousValue_DriverCount()
        {
            _driverCount = _driverCount - 1;
            if (_driverCount < 1)
                _driverCount = 1;

            if (_currentDriverIdx > _driverCount - 1)
            {
                _currentDriverIdx = _driverCount - 1;
                DisplayCurrentDriverInfos();
            }

            lblNbDrivers.Text = _driverCount.ToString();
            lblDriver2.Visible = _driverCount >= 2;
            lblDriver3.Visible = _driverCount >= 3;
        }
        private void NextValue_DriverCount()
        {
            _driverCount = _driverCount + 1;
            if (_driverCount > _maxDriverCount)
                _driverCount = _maxDriverCount;

            lblNbDrivers.Text = _driverCount.ToString();

            lblDriver2.Visible = _driverCount >= 2;
            lblDriver3.Visible = _driverCount >= 3;

        }

        private void PreviousValue_IdDriver()
        {
            _currentDriverIdx = _currentDriverIdx - 1;
            if (_currentDriverIdx < 0)
                _currentDriverIdx = 0;

            DisplayCurrentDriverInfos();
        }

        private void NextValue_IdDriver()
        {
            _currentDriverIdx = _currentDriverIdx + 1;
            if (_currentDriverIdx > _driverCount - 1)
                _currentDriverIdx = _driverCount - 1;

            DisplayCurrentDriverInfos();

        }
        private void DisplayCurrentDriverInfos()
        {
            if (_currentDriverIdx == 0)
            {
                lblDriver1.ForeColor = Color.YellowGreen;
                lblDriver2.ForeColor = Color.White;
                lblDriver3.ForeColor = Color.White;
            }
            else if (_currentDriverIdx == 1)
            {
                lblDriver1.ForeColor = Color.White;
                lblDriver2.ForeColor = Color.YellowGreen;
                lblDriver3.ForeColor = Color.White;
            }
            else if (_currentDriverIdx == 2)
            {
                lblDriver1.ForeColor = Color.White;
                lblDriver2.ForeColor = Color.White;
                lblDriver3.ForeColor = Color.YellowGreen;
            }

            if (_driverIndex[_currentDriverIdx].HasValue && _driverIndex[_currentDriverIdx] > -1)
            {
                pbDriverImage.Image = ImageHelper.byteArrayToImage(_allDrivers[_driverIndex[_currentDriverIdx].Value].Image);
                pbDriverImage.Visible = pbDriverImage.Image != null;
                float ratio = pbDriverImage.Visible ? (float)1.5 : (float)4;
                float fontSize = lblDriverName.Height / ratio;

                Font f = new Font(lblDriverName.Font.Name, fontSize, lblDriverName.Font.Style);
                lblDriverName.Font = f;
 
                lblDriverName.Text = _allDrivers[_driverIndex[_currentDriverIdx].Value].Name;
            }
            else
            {
                pbDriverImage.Image = null;
                lblDriverName.Text = string.Empty;
            }

            if (_car.HasValue && _car.Value > -1)
            {
                pbCarImage.Image = ImageHelper.byteArrayToImage(_allCars[_car.Value].Image);
                lblCarName.Text = _allCars[_car.Value].Name;
            }
            else
            {
                pbCarImage.Image = null;
                lblCarName.Text = string.Empty;
            }

            Color foreColor = Color.White;
            Color panelFocusColor = Color.FromArgb(75, Color.White);

            if ((_driverIndex[0].HasValue && _driverIndex[0].Value > -1) || (_car.HasValue && _car.Value> -1))
            {
                if (_car.HasValue && _car.Value > -1)
                {
                    foreColor = Color.FromArgb(_allCars[_car.Value].Color);
                    panelFocusColor = Color.FromArgb(75, Color.FromArgb(_allCars[_car.Value].Color));
                }
                else if (_driverIndex[0].HasValue && _driverIndex[0].Value > -1)
                {
                    foreColor = Color.FromArgb(_allDrivers[_driverIndex[0].Value].Color);
                    panelFocusColor = Color.FromArgb(75, Color.FromArgb(_allDrivers[_driverIndex[0].Value].Color));
                }



                panelDriverCount.SelectedColor = panelFocusColor;
                panelIdDriver.SelectedColor = panelFocusColor;
                panelDriver.SelectedColor = panelFocusColor;
                panelCar.SelectedColor = panelFocusColor;
                if (_currentPanel != null)
                {
                    _currentPanel.SelectedColor = panelFocusColor;
                    _currentPanel.FocusPanel(true);
                }
                panelReady.SelectedColor = panelFocusColor;


                lblCarName.ForeColor = foreColor;
                lblDriverName.ForeColor = foreColor;
                lblLaneId.ForeColor = foreColor;
                lblNbDrivers.ForeColor = foreColor;
                lblTeam.ForeColor = foreColor;
                lblDriversInTeam.ForeColor = foreColor;
                panelTeamColor.BackColor = foreColor;


                panelReady.BackColor = _ready ? Color.FromArgb(90, 150, 192, 80) : Color.Transparent;
                lblReady.ForeColor = _ready ? Color.YellowGreen : Color.Gray;

                panelReady.Enabled = _ready;
            }
        }

        private void PreviousValue_Driver()
        {
            _driverIndex[_currentDriverIdx] = _driverIndex[_currentDriverIdx].HasValue ? _driverIndex[_currentDriverIdx] - 1 : 0;
            if (_driverIndex[_currentDriverIdx] < 0)
                _driverIndex[_currentDriverIdx] = 0;

            DisplayCurrentDriverInfos();
        }

        private void NextValue_Driver()
        {
            _driverIndex[_currentDriverIdx] = _driverIndex[_currentDriverIdx].HasValue ? _driverIndex[_currentDriverIdx] + 1 : 0;
            if (_driverIndex[_currentDriverIdx] > _allDrivers.Count - 1)
                _driverIndex[_currentDriverIdx] = _allDrivers.Count - 1;

            DisplayCurrentDriverInfos();

        }

        private void PreviousValue_Car()
        {
            _car = _car.HasValue ? _car - 1 : 0;
            if (_car < 0)
                _car = 0;

            DisplayCurrentDriverInfos();

        }


        private void NextValue_Car()
        {
            _car = _car.HasValue ? _car + 1 : 0;
            if (_car > _allCars.Count - 1)
                _car = _allCars.Count - 1;
            DisplayCurrentDriverInfos();
        }

        private void PreviousValue_Ready()
        {
            _ready = !_ready;
            if (_ready)
                Ready();
            else
                NotReady();
        }
        private void Ready()
        {
            _ready = true;
            DisplayCurrentDriverInfos();
            _parentPage.CheckIfAllTeamsAreReady();
        }
        private void NotReady()
        {
            _ready = false;
            DisplayCurrentDriverInfos();
            _parentPage.CheckIfAllTeamsAreReady();
        }
        private void NextValue_Ready()
        {
            PreviousValue_Ready();
            _parentPage.CheckIfAllTeamsAreReady();
        }


        public TeamInRace GetTeam()
        {
            TeamInRace newTeam = null;
            if (_active)
            {
                newTeam = DefaultDatas.GetDefaultTeamInRace(Convert.ToInt32(lblLaneId.Text), _driverCount);
                newTeam.UseGamePadPlayerIndex = (EsrmPlayerIndex) (Convert.ToInt32(lblLaneId.Text) - 1);
                if (_driverIndex[0].HasValue)
                    newTeam.Pilot1 = _allDrivers[_driverIndex[0].Value] ;
                if (_driverCount > 1 && _driverIndex[1].HasValue)
                    newTeam.Pilot2 = _allDrivers[_driverIndex[1].Value];
                if (_driverCount > 2 && _driverIndex[2].HasValue)
                    newTeam.Pilot3 = _allDrivers[_driverIndex[2].Value];

                if (_car.HasValue)
                    newTeam.Car = _allCars[_car.Value];

                newTeam.Color = newTeam.Pilot1.Color;
                if(newTeam.Car != null)
                    newTeam.InCarPro = newTeam.Car.InCarPro;
                newTeam.Color = this.panelTeamColor.BackColor.ToArgb();
                    newTeam.Name = string.Format("Team {0}", lblLaneId.Text);

                newTeam.IsPacer = _pacerInfos != null;
                newTeam.Pacer = _pacerInfos;
            }

            return newTeam;
        }
    

     private void DriverAndCarSelectionPanel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void DriverAndCarSelectionPanel_KeyDown(object sender, KeyEventArgs e)
        {
            ProccessKeyDown(e);
        }


        public void ProccessKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ActivateUpPanel();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Q)
            {
                ActivateDownPanel();
                e.Handled = true;

            }
            else if (e.KeyCode == Keys.D)
            {
                NextValue();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                PreviousValue();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ActivatePanel();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ActivatePanel();
            }
        }
    }

    public class SelectablePanel : ScalablePanel
    {
        public DriverAndCarSelectionPanel ParentPanel { get; set; }
        public SelectablePanel DownPanel { get; set; }
        public SelectablePanel UpPanel { get; set; }
        //public SelectablePanel LeftPanel { get; set; }
        public Color SelectedColor { get; set; }
        public Color EditModeColor { get; set; }

        bool _isSelected;
        public bool IsSelected { get; }
        bool _isInEditMode;
        public bool IsInEditMode { get; }

        public SelectablePanel()
        {
            _isSelected = false;
            _isInEditMode = false;
            UseDisabledStatePainter = true;
        }


        public void FocusPanel(bool focus)
        {
            _isSelected = focus;
            _isInEditMode = false;
            if(_isSelected)
                this.BackColor = SelectedColor;
            else
                this.BackColor = Color.Transparent;

        }

        public void Edit()
        {
            _isInEditMode = true;
            this.BackColor = EditModeColor;
        }

        public void CancelEdit()
        {
            _isInEditMode = false;
            this.BackColor = SelectedColor;
        }

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (ParentPanel != null && ParentPanel is DriverAndCarSelectionPanel)
        //        ParentPanel.ProccessKeyDown(e);
        //}
    }
}
