using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using System.Windows.Threading;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;

namespace ESRM.Win.Views
{
    public partial class EmptyPage : BasePage
    {
        public EmptyPage()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
        }

        protected override void btnMouseHover(object sender, EventArgs e)
        {
            base.btnMouseHover(sender, e);
        }

        protected override void btnMouseLeave(object sender, EventArgs e)
        {
            base.btnMouseLeave(sender, e);
        }
    }
}
