using System;
using ESRM.Entities;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.IO;
using System.Windows.Forms;

namespace ESRM.Win.Views
{
    public partial class MainMenuPage : BasePage
    {
        public MainMenuPage()
        {
            Program.Log("Main Menu initialisation");

            InitializeComponent();
            btnEndurance.Text = Textes.Endurance.ToUpper();
            btnEndurance.UseMouseHoverColor = true;
            btnGP.Text = Textes.GrandPrix.ToUpper();
            btnGP.UseMouseHoverColor = true;
            btnPractice.Text = Textes.Practice.ToUpper();
            btnPractice.UseMouseHoverColor = true;
            btnQualif.Text = Textes.Qualification.ToUpper();
            btnQualif.UseMouseHoverColor = true;
            btnRalyCross.Text = Textes.RallyCross.ToUpper();
            btnRalyCross.UseMouseHoverColor = true;

            Uri u = new Uri(@"http://esrm.fr/download/ESRM_Documentation.pdf");
            lblDocumentation.Links.Add(0, lblDocumentation.Text.Length, u.ToString());

            Uri u2 = new Uri(@"http://esrm.forumactif.com");
            lblForum.Links.Add(0, lblForum.Text.Length, u2.ToString());

            Uri u3 = new Uri(@"http://esrm.fr/download/ChangeLog.txt");
            linkChangeLog.Links.Add(0, linkChangeLog.Text.Length, u3.ToString());
            Program.Log("Main Menu initialised");
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
            if (this.ParentForm != null && this.ParentForm is MainForm)
                (this.ParentForm as MainForm).SetTitle("Easy Slot Race Management " + Application.ProductVersion);
        }

        private void btnPractice_Click_1(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.Practice);
            AppViewModel.ActivatePage("pageRaceParams");

        }

        private void btnGP_Click(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.GP);
            AppViewModel.ActivatePage("pageRaceParams");
        }

        private void btnEndurance_Click(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.Endurance);
            AppViewModel.ActivatePage("pageRaceParams");

        }

        private void btnQualification_Click(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.Qualification);
            AppViewModel.ActivatePage("pageRaceParams");
        }

        private void btnRallyCross_Click(object sender, EventArgs e)
        {
            AppViewModel.InitRaceParameters(RaceType.RallyCross);
            AppViewModel.ActivatePage("pageRaceParams");
            //AppViewModel.ActivatePage("pageSSDTest");
        }

        protected override void btnMouseHover(object sender, EventArgs e)
        {
            base.btnMouseHover(sender, e);
        }

        protected override void btnMouseLeave(object sender, EventArgs e)
        {
            base.btnMouseLeave(sender, e);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            AppViewModel.ActivatePage("pageEndRace");
        }

        private void lblDocumentation_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void lblForum_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }


        private void linkChangeLog_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void btnDonate_Click(object sender, System.EventArgs e)
        {
            string url = "";

            string business = "d.desguin32@gmail.com";  // your paypal email
            string description = "Donation";            // '%20' represents a space. remember HTML!
            string country = "FR";                  // AU, US, etc.
            string currency = "EUR";                 // AUD, USD, etc.

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            System.Diagnostics.Process.Start(url);
        }
    }
}
