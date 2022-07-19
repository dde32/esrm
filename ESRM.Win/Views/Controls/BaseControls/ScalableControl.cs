using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;

namespace ESRM.Win.Panels
{
    public partial class ScalableControl : ESRMControl
    {
        protected float? _lastRatio;

        public ScalableControl()
        {
            InitializeComponent();
        }
        

        #region MISE A L ECHELLE

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            if (float.IsInfinity(factor.Height) || float.IsInfinity(factor.Width))
                return;

            this.SuspendLayout();
            base.ScaleControl(factor, BoundsSpecified.All);


            if (!_lastRatio.HasValue || _lastRatio.Value == 0)
                _lastRatio = 1;

            // float ratio = factor.Height > factor.Width ? factor.Height : factor.Width;
            float ratio = Math.Max(factor.Width, factor.Height * 0.9f);

            if (factor.Height > 1.8 * factor.Width || factor.Width > 1.8 * factor.Height)
                ratio = ratio * (float)0.7;

            foreach (Control ctrl in Controls)
                DeepScaleControl(ctrl, ratio, _lastRatio.Value, specified, factor);

            _lastRatio = ratio;

            this.ResumeLayout();
        }


        public void DeepScaleControl(Control control, float newRatio, float previousRatio, BoundsSpecified specified, SizeF factor)
        {
            control.SuspendLayout();

            float fontSize = control.Font.Size / _lastRatio.Value;
            fontSize = fontSize * newRatio;

            if (fontSize >= 6)
            {
                Font f = new Font(control.Font.Name, fontSize, control.Font.Style);
                control.Font = f;
            }

            foreach (Control ctrl in control.Controls)
            {
                DeepScaleControl(ctrl, newRatio, previousRatio, specified, factor);
            }
            control.ResumeLayout();
        }


        #endregion


    }



}
