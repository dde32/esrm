using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ESRM.Win
{
    public partial class ScalablePanel : PanelControl
    {

        public ScalablePanel()
        {
            InitializeComponent();
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        #region BINDING

        static public void ClearBindings(Control control)
        {
            control.DataBindings.Clear();

            foreach (Control ctrl in control.Controls)
            {
                ctrl.DataBindings.Clear();
                ClearBindings(ctrl);
            }
        }

        protected virtual void ClearBindings()
        {
            foreach (Control ctrl in Controls)
            {
                ctrl.DataBindings.Clear();
                if (ctrl is Panel)
                {
                    foreach (Control ctrlChilds in ctrl.Controls)
                        ctrlChilds.DataBindings.Clear();

                }
            }
        }

        protected virtual void RefreshPanel()
        {
            foreach (Control ctrl in Controls)
            {
                foreach (Binding db in this.DataBindings)
                    db.ReadValue();

                if (ctrl is Panel)
                {
                    foreach (Binding db2 in ctrl.DataBindings)
                        db2.ReadValue();
                }
            }
        }

        protected virtual void DoBinding()
        {
            ClearBindings(this);


        }

        #endregion


        #region MISE A L ECHELLE

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            this.SuspendLayout();
            base.ScaleControl(factor, specified);

            ////float ratio = factor.Height > factor.Width ? factor.Height : factor.Width;
            //float ratio = Math.Max(factor.Width * 0.95f, factor.Height * 0.8f);

            //foreach (Control ctrl in Controls)
            //{
            //    if (ctrl is Panel)
            //    {
            //        foreach (Control ctrlChilds in ctrl.Controls)
            //        {
            //            float fontSize = ctrlChilds.Font.Size * ratio;
            //            Font f2 = new Font(ctrlChilds.Font.Name, fontSize, ctrlChilds.Font.Style);
            //            ctrlChilds.Font = f2;
            //        }
            //    }
            //    else
            //    {
            //        float fontSize = ctrl.Font.Size * ratio;
            //        Font f = new Font(ctrl.Font.Name, fontSize, ctrl.Font.Style);
            //        ctrl.Font = f;
            //    }
            //}
            this.ResumeLayout();
        }

        #endregion

    }



}
