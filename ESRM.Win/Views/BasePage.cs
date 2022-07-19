using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using ESRM.Entities;

namespace ESRM.Win.Views
{
    public partial class BasePage : UserControl, ISupportNavigation
    {
        protected IESRMViewModel appViewModel;


        public BasePage()
        {
            InitializeComponent();
        }
        protected IESRMPageViewModel PageViewModel
        {
            get { return AppViewModel.CurrentPageModel; }
        }
        public IESRMViewModel AppViewModel
        {
            get { return appViewModel; }
        }


        #region ISupportNavigation Members
        public virtual void OnNavigatedTo(INavigationArgs args)
        {
            appViewModel = args.Parameter as IESRMViewModel;
            appViewModel.CurrentPage = this;
        }

        public virtual void OnNavigatedFrom(INavigationArgs args)
        {
        }

        #endregion

        public void SetCaption(string caption)
        {
            Text = caption;
        }

        protected virtual void btnMouseHover(object sender, EventArgs e)
        {
            if(sender is SimpleButton)
                (sender as SimpleButton).ForeColor = Color.Orange;
        }

        protected virtual void btnMouseLeave(object sender, EventArgs e)
        {
            if (sender is SimpleButton)
                (sender as SimpleButton).ResetForeColor();
        }

    }

}