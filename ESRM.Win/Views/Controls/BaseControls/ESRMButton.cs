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
    public partial class ESRMButton : Button
    {
        public bool UseMouseHoverColor;
        protected  bool isMouseHover;
        public ESRMButton()
        {
            InitializeComponent();

        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            isMouseHover = true;
            if (UseMouseHoverColor)
            {
                ForeColor = Color.Red;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseHover = false;
            if (UseMouseHoverColor)
            {
                ForeColor = Color.White;
                Invalidate();
            }
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

        //protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        //{
        //    base.ScaleControl(factor, specified);
        //}

        //protected override void ScaleCore(float dx, float dy)
        //{
        //    base.ScaleCore(dx, dy);
        //}
    }
}
