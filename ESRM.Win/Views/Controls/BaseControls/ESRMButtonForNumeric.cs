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
    public partial class ESRMButtonForNumeric : UserControl
    {
        protected bool isMouseHover;

        public bool ShowSecondText
        {
            get { return lblSubText.Visible; }
            set
            {
                lblSubText.Visible = value;
            }
        }

        public bool IsFloatValue
        {
            get { return lblSubText.Properties.IsFloatValue; }
            set
            {
                lblSubText.Properties.IsFloatValue = value;
                if (value)
                {
                    lblSubText.Properties.EditMask = "N1";
                    lblSubText.Properties.Increment = (Decimal)0.5;
                }
                else
                {
                    lblSubText.Properties.EditMask = "N0";
                    lblSubText.Properties.Increment = (Decimal)1;
                }
            }
        }



        [Localizable(true)]
        public string Caption
        {
            get { return lblBtnText.Text; }
            set {  lblBtnText.Text = value; }
        }

        [Localizable(true)]
        public string SubText
        {
            get { return lblSubText.Text; }
            set { lblSubText.Text = value; }
        }

        public Color SubTextForeColor
        {
            get { return lblSubText.ForeColor; }
            set { lblSubText.ForeColor = value; }
        }

        public Font TextFont
        {
            get { return lblBtnText.Font; }
            set { lblBtnText.Font = value; }
        }

        public Font SubTextFont
        {
            get { return lblSubText.Font; }
            set { lblSubText.Font = value; }
        }

        public Decimal MinValue
        {
            get { return lblSubText.Properties.MinValue; }
            set { lblSubText.Properties.MinValue = value; }
        }

        public Decimal MaxValue
        {
            get { return lblSubText.Properties.MaxValue; }
            set { lblSubText.Properties.MaxValue = value; }
        }


        public ESRMButtonForNumeric()
        {
            InitializeComponent();
            Paint += ESRMButtonSelect_Paint;
        }

        void ESRMButtonSelect_Paint(object sender, PaintEventArgs e)
        {
            if(isMouseHover)
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ForeColor, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ForeColor, ButtonBorderStyle.None);
        }

        private new void MouseHover()
        {
            ForeColor = Color.Red;
            Invalidate();
        }

        private new void MouseLeave()
        {
            ForeColor = Color.White;
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            isMouseHover = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ResetForeColor();
            base.OnMouseLeave(e);
            isMouseHover = true;
        }

        private void ESRMButtonSelect_MouseHover(object sender, EventArgs e)
        {
            MouseHover();
        }

        private void pbBtnImage_MouseHover(object sender, EventArgs e)
        {
            MouseHover();

        }

        private void pbBtnImage_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave();
        }

        private void lblBtnText_MouseHover(object sender, EventArgs e)
        {
            MouseHover();

        }

        private void lblBtnText_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave();

        }

        private void lblSubText_MouseHover(object sender, EventArgs e)
        {
            MouseHover();

        }

        private void lblSubText_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave();

        }


        //protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        //{
        //    base.ScaleControl(factor, specified);
        //    this.lblSubText.Scale(factor);
        //}

        private void lblSubText_EditValueChanged(object sender, EventArgs e)
        {
            if (this.DataBindings["SubText"] != null)
                this.DataBindings["SubText"].WriteValue();
            if (this.DataBindings["SubTextForeColor"] != null)
                this.DataBindings["SubTextForeColor"].ReadValue();
        }
    }
}
