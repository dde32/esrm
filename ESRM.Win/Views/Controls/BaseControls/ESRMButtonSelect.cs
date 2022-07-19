using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRM.Win.Panels;
using System.Resources;
using ESRM.Entities;

namespace ESRM.Win
{
    public partial class ESRMButtonSelect : ScalableControl
    {
        protected bool isMouseHover;
        public bool UseMouseHoverColor;


        public string TextBoxHint
        {
            get
            {
                return toolTip1.GetToolTip(lblBtnText);
            }
            set
            {
                toolTip1.SetToolTip(lblBtnText, value);
            }
        }

        public bool ShowSecondText
        {
            get { return lblSubText.Visible; }
            set
            {
                lblSubText.Visible = value;
            }
        }
        [Localizable(true)]
        public string Caption
        {
            get { return lblBtnText.Text; }
            set { lblBtnText.Text = value; }
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

        public Size SubTextSize
        {
            get { return lblSubText.Size; }
            set { lblSubText.Size = value; }
        }

        public ESRMButtonSelect() : base()
        {
            InitializeComponent();
            Paint += ESRMButtonSelect_Paint;
        }

        void ESRMButtonSelect_Paint(object sender, PaintEventArgs e)
        {
            if (!UseMouseHoverColor)
                return;


            if (isMouseHover)
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ForeColor, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ForeColor, ButtonBorderStyle.None);
        }

        private void MouseHoverEx()
        {
            if (!UseMouseHoverColor)
                return;

            ForeColor = Color.Red;
            isMouseHover = true;
            Invalidate();
        }

        private void MouseLeaveEx()
        {
            if (!UseMouseHoverColor)
                return;


            isMouseHover = false;
            ForeColor = Color.White;
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (!UseMouseHoverColor)
                return;

            isMouseHover = true;
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (!UseMouseHoverColor)
                return;

            isMouseHover = false;
            ResetForeColor();
        }

        private void ESRMButtonSelect_MouseHover(object sender, EventArgs e)
        {
            MouseHoverEx();
        }

        private void pbBtnImage_MouseHover(object sender, EventArgs e)
        {
            MouseHoverEx();

        }

        private void pbBtnImage_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEx();
        }

        private void lblBtnText_MouseHover(object sender, EventArgs e)
        {
            MouseHoverEx();

        }

        private void lblBtnText_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEx();

        }

        private void lblSubText_MouseHover(object sender, EventArgs e)
        {
            MouseHoverEx();

        }

        private void lblSubText_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEx();

        }

        private void pbBtnImage_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }
    }

    public partial class ESRMButtonSelectBool : ESRMButtonSelect
    {
        bool _boolValue;
        public bool BoolValue
        {
            get { return _boolValue; }
            set
            {
                _boolValue = value;
                if (value)
                {
                    SubText = Textes.ResourceManager.GetString("Yes");
                    SubTextForeColor = Color.Green;
                }
                else
                {
                    SubText = Textes.ResourceManager.GetString("No");
                    SubTextForeColor = Color.Red;
                }

                if (this.DataBindings["SubText"] != null)
                    this.DataBindings["SubText"].ReadValue();
            }
        }
        
    }
}
