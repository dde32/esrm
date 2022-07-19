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
using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    public enum ParamEnum
    {
        Acceleration = 0,
        Brake = 1,
        Wear = 2,
    }


    public partial class TiresParamsPanel : ScalableControl
    {
        TireTypeParams _hardParams;
        TireTypeParams _mediumParams;
        TireTypeParams _softParams;
        TireTypeParams _intermediateParams;
        TireTypeParams _wetParams;

        ParamEnum _currentParamView;
        IESRMViewModel _appViewModel;
        public IESRMViewModel AppViewModel
        {
            get { return _appViewModel; }
        }

        public bool ShowMaxPerf
        {
            get { return _currentParamView == ParamEnum.Wear; }
        }

        #region HARD
        public double Hard_DryFresh
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _hardParams.MaxAcceleration_DryAndFreshTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _hardParams.BrakingDelai_DryAndFreshTemp;
                else
                    return _hardParams.WearDelta_DryAndFreshTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _hardParams.MaxAcceleration_DryAndFreshTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _hardParams.BrakingDelai_DryAndFreshTemp = (int)value;
                else
                    _hardParams.WearDelta_DryAndFreshTemp = (int)value;
            }
        }

        public double Hard_DryMedium
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _hardParams.MaxAcceleration_DryAndMediumTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _hardParams.BrakingDelai_DryAndMediumTemp;
                else
                    return _hardParams.WearDelta_DryAndMediumTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _hardParams.MaxAcceleration_DryAndMediumTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _hardParams.BrakingDelai_DryAndMediumTemp = (int)value;
                else
                    _hardParams.WearDelta_DryAndMediumTemp = (int)value;
            }
        }

        public double Hard_DryHot
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _hardParams.MaxAcceleration_DryAndHotTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _hardParams.BrakingDelai_DryAndHotTemp;
                else
                    return _hardParams.WearDelta_DryAndHotTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _hardParams.MaxAcceleration_DryAndHotTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _hardParams.BrakingDelai_DryAndHotTemp = (int)value;
                else
                    _hardParams.WearDelta_DryAndHotTemp = (int)value;
            }
        }

        public double Hard_Damp
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _hardParams.MaxAcceleration_Damp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _hardParams.BrakingDelai_Damp;
                else
                    return _hardParams.WearDelta_Damp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _hardParams.MaxAcceleration_Damp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _hardParams.BrakingDelai_Damp = (int)value;
                else
                    _hardParams.WearDelta_Damp = (int)value;
            }
        }

        public double Hard_Wet
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _hardParams.MaxAcceleration_Wet;
                else if (_currentParamView == ParamEnum.Brake)
                    return _hardParams.BrakingDelai_Wet;
                else
                    return _hardParams.WearDelta_Wet;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _hardParams.MaxAcceleration_Wet = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _hardParams.BrakingDelai_Wet = (int)value;
                else
                    _hardParams.WearDelta_Wet = (int)value;
            }
        }

        #endregion HARD

        #region MEDIUM


        public double Medium_DryFresh
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _mediumParams.MaxAcceleration_DryAndFreshTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _mediumParams.BrakingDelai_DryAndFreshTemp;
                else
                    return _mediumParams.WearDelta_DryAndFreshTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _mediumParams.MaxAcceleration_DryAndFreshTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _mediumParams.BrakingDelai_DryAndFreshTemp = (int)value;
                else
                    _mediumParams.WearDelta_DryAndFreshTemp = (int)value;
            }
        }

        public double Medium_DryMedium
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _mediumParams.MaxAcceleration_DryAndMediumTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _mediumParams.BrakingDelai_DryAndMediumTemp;
                else
                    return _mediumParams.WearDelta_DryAndMediumTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _mediumParams.MaxAcceleration_DryAndMediumTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _mediumParams.BrakingDelai_DryAndMediumTemp = (int)value;
                else
                    _mediumParams.WearDelta_DryAndMediumTemp = (int)value;
            }
        }

        public double Medium_DryHot
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _mediumParams.MaxAcceleration_DryAndHotTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _mediumParams.BrakingDelai_DryAndHotTemp;
                else
                    return _mediumParams.WearDelta_DryAndHotTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _mediumParams.MaxAcceleration_DryAndHotTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _mediumParams.BrakingDelai_DryAndHotTemp = (int)value;
                else
                    _mediumParams.WearDelta_DryAndHotTemp = (int)value;
            }
        }

        public double Medium_Damp
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _mediumParams.MaxAcceleration_Damp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _mediumParams.BrakingDelai_Damp;
                else
                    return _mediumParams.WearDelta_Damp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _mediumParams.MaxAcceleration_Damp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _mediumParams.BrakingDelai_Damp = (int)value;
                else
                    _mediumParams.WearDelta_Damp = (int)value;
            }
        }

        public double Medium_Wet
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _mediumParams.MaxAcceleration_Wet;
                else if (_currentParamView == ParamEnum.Brake)
                    return _mediumParams.BrakingDelai_Wet;
                else
                    return _mediumParams.WearDelta_Wet;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _mediumParams.MaxAcceleration_Wet = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _mediumParams.BrakingDelai_Wet = (int)value;
                else
                    _mediumParams.WearDelta_Wet = (int)value;
            }
        }


        //;
        //seMedium_Damp;
        //seMedium_DryHot;
        //seMedium_DryMedium;
        //;
        #endregion MEDIUM

        #region SOFT


        public double Soft_DryFresh
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _softParams.MaxAcceleration_DryAndFreshTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _softParams.BrakingDelai_DryAndFreshTemp;
                else
                    return _softParams.WearDelta_DryAndFreshTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _softParams.MaxAcceleration_DryAndFreshTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _softParams.BrakingDelai_DryAndFreshTemp = (int)value;
                else
                    _softParams.WearDelta_DryAndFreshTemp = (int)value;
            }
        }

        public double Soft_DryMedium
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _softParams.MaxAcceleration_DryAndMediumTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _softParams.BrakingDelai_DryAndMediumTemp;
                else
                    return _softParams.WearDelta_DryAndMediumTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _softParams.MaxAcceleration_DryAndMediumTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _softParams.BrakingDelai_DryAndMediumTemp = (int)value;
                else
                    _softParams.WearDelta_DryAndMediumTemp = (int)value;
            }
        }

        public double Soft_DryHot
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _softParams.MaxAcceleration_DryAndHotTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _softParams.BrakingDelai_DryAndHotTemp;
                else
                    return _softParams.WearDelta_DryAndHotTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _softParams.MaxAcceleration_DryAndHotTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _softParams.BrakingDelai_DryAndHotTemp = (int)value;
                else
                    _softParams.WearDelta_DryAndHotTemp = (int)value;
            }
        }

        public double Soft_Damp
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _softParams.MaxAcceleration_Damp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _softParams.BrakingDelai_Damp;
                else
                    return _softParams.WearDelta_Damp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _softParams.MaxAcceleration_Damp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _softParams.BrakingDelai_Damp = (int)value;
                else
                    _softParams.WearDelta_Damp = (int)value;
            }
        }

        public double Soft_Wet
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _softParams.MaxAcceleration_Wet;
                else if (_currentParamView == ParamEnum.Brake)
                    return _softParams.BrakingDelai_Wet;
                else
                    return _softParams.WearDelta_Wet;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _softParams.MaxAcceleration_Wet = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _softParams.BrakingDelai_Wet = (int)value;
                else
                    _softParams.WearDelta_Wet = (int)value;
            }
        }
        #endregion SOFT


        #region INTERMEDIATE


        public double Intermediate_DryFresh
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _intermediateParams.MaxAcceleration_DryAndFreshTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _intermediateParams.BrakingDelai_DryAndFreshTemp;
                else
                    return _intermediateParams.WearDelta_DryAndFreshTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _intermediateParams.MaxAcceleration_DryAndFreshTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _intermediateParams.BrakingDelai_DryAndFreshTemp = (int)value;
                else
                    _intermediateParams.WearDelta_DryAndFreshTemp = (int)value;
            }
        }

        public double Intermediate_DryMedium
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _intermediateParams.MaxAcceleration_DryAndMediumTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _intermediateParams.BrakingDelai_DryAndMediumTemp;
                else
                    return _intermediateParams.WearDelta_DryAndMediumTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _intermediateParams.MaxAcceleration_DryAndMediumTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _intermediateParams.BrakingDelai_DryAndMediumTemp = (int)value;
                else
                    _intermediateParams.WearDelta_DryAndMediumTemp = (int)value;
            }
        }

        public double Intermediate_DryHot
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _intermediateParams.MaxAcceleration_DryAndHotTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _intermediateParams.BrakingDelai_DryAndHotTemp;
                else
                    return _intermediateParams.WearDelta_DryAndHotTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _intermediateParams.MaxAcceleration_DryAndHotTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _intermediateParams.BrakingDelai_DryAndHotTemp = (int)value;
                else
                    _intermediateParams.WearDelta_DryAndHotTemp = (int)value;
            }
        }

        public double Intermediate_Damp
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _intermediateParams.MaxAcceleration_Damp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _intermediateParams.BrakingDelai_Damp;
                else
                    return _intermediateParams.WearDelta_Damp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _intermediateParams.MaxAcceleration_Damp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _intermediateParams.BrakingDelai_Damp = (int)value;
                else
                    _intermediateParams.WearDelta_Damp = (int)value;
            }
        }

        public double Intermediate_Wet
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _intermediateParams.MaxAcceleration_Wet;
                else if (_currentParamView == ParamEnum.Brake)
                    return _intermediateParams.BrakingDelai_Wet;
                else
                    return _intermediateParams.WearDelta_Wet;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _intermediateParams.MaxAcceleration_Wet = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _intermediateParams.BrakingDelai_Wet = (int)value;
                else
                    _intermediateParams.WearDelta_Wet = (int)value;
            }
        }
        #endregion INTERMEDIATE


        #region WET


        public double Wet_DryFresh
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _wetParams.MaxAcceleration_DryAndFreshTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _wetParams.BrakingDelai_DryAndFreshTemp;
                else
                    return _wetParams.WearDelta_DryAndFreshTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _wetParams.MaxAcceleration_DryAndFreshTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _wetParams.BrakingDelai_DryAndFreshTemp = (int)value;
                else
                    _wetParams.WearDelta_DryAndFreshTemp = (int)value;
            }
        }

        public double Wet_DryMedium
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _wetParams.MaxAcceleration_DryAndMediumTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _wetParams.BrakingDelai_DryAndMediumTemp;
                else
                    return _wetParams.WearDelta_DryAndMediumTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _wetParams.MaxAcceleration_DryAndMediumTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _wetParams.BrakingDelai_DryAndMediumTemp = (int)value;
                else
                    _wetParams.WearDelta_DryAndMediumTemp = (int)value;
            }
        }

        public double Wet_DryHot
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _wetParams.MaxAcceleration_DryAndHotTemp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _wetParams.BrakingDelai_DryAndHotTemp;
                else
                    return _wetParams.WearDelta_DryAndHotTemp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _wetParams.MaxAcceleration_DryAndHotTemp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _wetParams.BrakingDelai_DryAndHotTemp = (int)value;
                else
                    _wetParams.WearDelta_DryAndHotTemp = (int)value;
            }
        }

        public double Wet_Damp
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _wetParams.MaxAcceleration_Damp;
                else if (_currentParamView == ParamEnum.Brake)
                    return _wetParams.BrakingDelai_Damp;
                else
                    return _wetParams.WearDelta_Damp;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _wetParams.MaxAcceleration_Damp = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _wetParams.BrakingDelai_Damp = (int)value;
                else
                    _wetParams.WearDelta_Damp = (int)value;
            }
        }

        public double Wet_Wet
        {
            get
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    return _wetParams.MaxAcceleration_Wet;
                else if (_currentParamView == ParamEnum.Brake)
                    return _wetParams.BrakingDelai_Wet;
                else
                    return _wetParams.WearDelta_Wet;
            }
            set
            {
                if (_currentParamView == ParamEnum.Acceleration)
                    _wetParams.MaxAcceleration_Wet = value;
                else if (_currentParamView == ParamEnum.Brake)
                    _wetParams.BrakingDelai_Wet = (int)value;
                else
                    _wetParams.WearDelta_Wet = (int)value;
            }
        }
        #endregion INTERMEDIATE



        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        public TiresParamsPanel()
        {
            InitializeComponent();
            _currentParamView = ParamEnum.Acceleration;
            try
            {
                Font btnFont = Program.fontManager.GetRadioStarFont(btnAccelParams.Font.Size, FontStyle.Regular);
                btnAccelParams.Font = btnFont;
                btnbrakeParams.Font = btnFont;
                btnResetParams.Font = btnFont;
                btnWearParams.Font = btnFont;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetParams(IESRMViewModel appViewModel)
        {
           _appViewModel = appViewModel;
            _hardParams = _appViewModel.TiresParams[TireType.Hard];
            _mediumParams = _appViewModel.TiresParams[TireType.Medium];
             _softParams = _appViewModel.TiresParams[TireType.Soft];
            _intermediateParams = _appViewModel.TiresParams[TireType.Intermediate];
            _wetParams = _appViewModel.TiresParams[TireType.Wet];
            SwitchParamType(_currentParamView);

        }

        public void SwitchParamType(ParamEnum newParamToShow)
        {
            Validate();

            _currentParamView = newParamToShow;
            switch(_currentParamView)
            {
                case ParamEnum.Acceleration:
                    foreach (Control c in panelFill.Controls)
                    {
                        if (c is SpinEdit)
                        {
                            (c as SpinEdit).Properties.MinValue = 0;
                            (c as SpinEdit).Properties.MaxValue = 100;
                            (c as SpinEdit).Properties.IsFloatValue = true;
                            (c as SpinEdit).Properties.Increment = new decimal(0.5);
                            (c as SpinEdit).Properties.EditMask = "N1";
                        }
                    }

                    lblConsigne.Text = Textes.TiresConsigne_Acceleration;
                    break;
                case ParamEnum.Brake:
                    foreach (Control c in panelFill.Controls)
                    {
                        if (c is SpinEdit)
                        {
                            (c as SpinEdit).Properties.MinValue = 0;
                            (c as SpinEdit).Properties.MaxValue = 1000;
                            (c as SpinEdit).Properties.IsFloatValue = false;
                            (c as SpinEdit).Properties.Increment = 50;
                            (c as SpinEdit).Properties.EditMask = "N00";
                        }
                    }
                    lblConsigne.Text = Textes.TiresConsigne_BrakeDelai;
                    break;
                case ParamEnum.Wear:
                    foreach (Control c in panelFill.Controls)
                    {
                        if (c is SpinEdit)
                        {
                            (c as SpinEdit).Properties.MinValue = -100;
                            (c as SpinEdit).Properties.MaxValue = 100;
                            (c as SpinEdit).Properties.IsFloatValue = false;
                            (c as SpinEdit).Properties.Increment = 5;
                            (c as SpinEdit).Properties.EditMask = "N00";
                        }
                    }
                    lblConsigne.Text = Textes.TiresConsigne_Wear;
                    break;
                default:
                    break;
            }
            DoBinding();
        }

        #region BINDING



        protected override void DoBinding()
        {
            base.DoBinding();
            
            foreach(Control c in this.Controls)
            {
                if (c is SpinEdit)
                    c.DataBindings.Clear();
            }
            lblMaxPerf.DataBindings.Clear();

            seHard_DryFresh.DataBindings.Add(new Binding("Value",this, "Hard_DryFresh"));
            seHard_DryMedium.DataBindings.Add(new Binding("Value", this, "Hard_DryMedium"));
            seHard_DryHot.DataBindings.Add(new Binding("Value", this, "Hard_DryHot"));
            seHard_Damp.DataBindings.Add(new Binding("Value", this, "Hard_Damp"));
            seHard_Wet.DataBindings.Add(new Binding("Value", this, "Hard_Wet"));

            seMedium_DryFresh.DataBindings.Add(new Binding("Value", this, "Medium_DryFresh"));
            seMedium_DryMedium.DataBindings.Add(new Binding("Value", this, "Medium_DryMedium"));
            seMedium_DryHot.DataBindings.Add(new Binding("Value", this, "Medium_DryHot"));
            seMedium_Damp.DataBindings.Add(new Binding("Value", this, "Medium_Damp"));
            seMedium_Wet.DataBindings.Add(new Binding("Value", this, "Medium_Wet"));

            seSoft_DryFresh.DataBindings.Add(new Binding("Value", this, "Soft_DryFresh"));
            seSoft_DryMedium.DataBindings.Add(new Binding("Value", this, "Soft_DryMedium"));
            seSoft_DryHot.DataBindings.Add(new Binding("Value", this, "Soft_DryHot"));
            seSoft_Damp.DataBindings.Add(new Binding("Value", this, "Soft_Damp"));
            seSoft_Wet.DataBindings.Add(new Binding("Value", this, "Soft_Wet"));

            seInter_DryFresh.DataBindings.Add(new Binding("Value", this, "Intermediate_DryFresh"));
            seInter_DryMedium.DataBindings.Add(new Binding("Value", this, "Intermediate_DryMedium"));
            seInter_DryHot.DataBindings.Add(new Binding("Value", this, "Intermediate_DryHot"));
            seInter_Damp.DataBindings.Add(new Binding("Value", this, "Intermediate_Damp"));
            seInter_Wet.DataBindings.Add(new Binding("Value", this, "Intermediate_Wet"));

            seWet_DryFresh.DataBindings.Add(new Binding("Value", this, "Wet_DryFresh"));
            seWet_DryMedium.DataBindings.Add(new Binding("Value", this, "Wet_DryMedium"));
            seWet_DryHot.DataBindings.Add(new Binding("Value", this, "Wet_DryHot"));
            seWet_Damp.DataBindings.Add(new Binding("Value", this, "Wet_Damp"));
            seWet_Wet.DataBindings.Add(new Binding("Value", this, "Wet_Wet"));

            se_HardMaxPerf.DataBindings.Add(new Binding("Visible", this, "ShowMaxPerf"));
            se_IntermediateMaxPerf.DataBindings.Add(new Binding("Visible", this, "ShowMaxPerf"));
            se_MediumMaxPerf.DataBindings.Add(new Binding("Visible", this, "ShowMaxPerf"));
            se_SoftMaxPerf.DataBindings.Add(new Binding("Visible", this, "ShowMaxPerf"));
            se_WetMaxPerf.DataBindings.Add(new Binding("Visible", this, "ShowMaxPerf"));
            lblMaxPerf.DataBindings.Add(new Binding("Visible", this, "ShowMaxPerf"));
        }


        #endregion

        private void btnAccelParams_Click(object sender, EventArgs e)
        {
            btnAccelParams.ForeColor = Color.YellowGreen;
            btnbrakeParams.ForeColor = Color.DimGray;
            btnWearParams.ForeColor = Color.DimGray;
            SwitchParamType(ParamEnum.Acceleration);
        }

        private void btnbrakeParams_Click(object sender, EventArgs e)
        {
            btnAccelParams.ForeColor = Color.DimGray;
            btnbrakeParams.ForeColor = Color.YellowGreen;
            btnWearParams.ForeColor = Color.DimGray;
            SwitchParamType(ParamEnum.Brake);
        }

        private void btnWearParams_Click(object sender, EventArgs e)
        {
            btnAccelParams.ForeColor = Color.DimGray;
            btnbrakeParams.ForeColor = Color.DimGray;
            btnWearParams.ForeColor = Color.YellowGreen;
            SwitchParamType(ParamEnum.Wear);
        }

        private void btnResetParams_Click(object sender, EventArgs e)
        {
            AppViewModel.TiresParams = DefaultDatas.GetDefaultTireTypeParams();
            SetParams(AppViewModel);
            SwitchParamType(_currentParamView);
        }
    }
}
