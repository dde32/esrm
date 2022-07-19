using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using ESRM.Entities;
using ESRM.Win.Panels;
using DevExpress.XtraPrinting;
using System.Drawing.Imaging;

namespace ESRM.Win
{
    public partial class StatsPilotsForm : Form
    {

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }
        List<PilotStatistics> Stats;
        List<TeamLap> TeamLaps;
        RecordList Records;

        public StatsPilotsForm()
        {
            InitializeComponent();
        }

        public StatsPilotsForm(List<PilotStatistics> stats, List<TeamInRace> teams,RecordList records)
        {
            InitializeComponent();
            Stats = stats;
            Records = records;
            SetDlgSize();
            grid.DataSource = Stats;
            gridRecords.DataSource = Records;
            ComputeTeamsLaps(teams);
            chartPositions.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Position" });
            chartLaptimes.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "LapTime.TotalSeconds" });
            chartFuel.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "FuelPercent" });
            chartTires.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "TiresPercent" });


            chartPositions.DataSource = TeamLaps;
            chartLaptimes.DataSource = TeamLaps;
            chartFuel.DataSource = TeamLaps;
            chartTires.DataSource = TeamLaps;

            foreach (TeamInRace team in teams)
            {
                AddLapByLapPanels(team);
            }
        }

        public void ComputeTeamsLaps(List<TeamInRace> teams)
        {
            TeamLaps = new List<TeamLap>();

            foreach (TeamInRace team in teams)
            {
                foreach(Lap l in team.Laps)
                {
                    TeamLap newLap = new TeamLap();
                    newLap.TeamName = team.Name;
                    newLap.Position = l.Position;
                    newLap.Pilot = l.Pilot.Name;
                    newLap.FuelPercent = l.FuelPercent;
                    newLap.FuelConso = l.FuelConso;
                    newLap.TiresPercent = l.TiresPercent;
                    newLap.TeamAndPilotName = team.IsMultiPilot ?  string.Format("{0}:{1}", team.Name, l.Pilot.Name) : l.Pilot.Name;
                    newLap.LapTime = l.LapTime;
                    newLap.LapNumber = l.Number;
                    newLap.Color = team.Color;
                    if (l.Pilot == team.Pilot1)
                        newLap.PilotNumber = 1;
                    else if (l.Pilot == team.Pilot2)
                        newLap.PilotNumber = 2;
                    else if (l.Pilot == team.Pilot3)
                        newLap.PilotNumber = 3;

                    TeamLaps.Add(newLap);
                }
            }
        }


        public void SetDlgSize()
        {
            this.Size = new Size(this.Width, Screen.GetBounds(this).Height - 100);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            //if (e.SeriesPoint.Argument == "5" && e.Series.Name == "PIlot1")
            //    e.SeriesDrawOptions.Color = Color.Red;
        }

        private void AddLapByLapPanels(TeamInRace team)
        {
            LapByLapPanel newPanel = new LapByLapPanel();
            newPanel.SetDatas(team.Name, team.Pilot1.Name, team.Laps);
            newPanel.Dock = DockStyle.Left;
            panelLapByLap.Controls.Add(newPanel);

            if(team.Pilot2 != null)
            {
                LapByLapPanel newPanel2 = new LapByLapPanel();
                newPanel2.SetDatas(team.Name, team.Pilot2.Name, team.Laps);
                newPanel2.Dock = DockStyle.Left;
                panelLapByLap.Controls.Add(newPanel2);
            }

            if (team.Pilot3 != null)
            {
                LapByLapPanel newPanel3 = new LapByLapPanel();
                newPanel3.SetDatas(team.Name, team.Pilot3.Name, team.Laps);
                newPanel3.Dock = DockStyle.Left;
                panelLapByLap.Controls.Add(newPanel3);
            }
        }

        private void btnExportXLS_Click(object sender, EventArgs e)
        {
            string exportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ESRM XLS");
            
            if (!Directory.Exists(exportPath))
                Directory.CreateDirectory(exportPath);

            exportPath = Path.Combine(exportPath, DateTime.Now.ToLongDateString());
            if (!Directory.Exists(exportPath))
                Directory.CreateDirectory(exportPath);

            foreach(Control c in panelLapByLap.Controls)
            {
                if(c is LapByLapPanel)
                {
                    (c as LapByLapPanel).ExportToXls(exportPath);
                }
            }

            string filename = string.Format("ESRM-RaceStats-{0}.xls", DateTime.Now.ToLongDateString());
            string filepath = Path.Combine(exportPath, filename);
            grid.ExportToXls(filepath);

            filename = string.Format("ESRM-Records-{0}.xls", DateTime.Now.ToLongDateString());
            filepath = Path.Combine(exportPath, filename);
            gridRecords.ExportToXls(filepath);


            filename = string.Format("ESRM-Position Chart-{0}.png", DateTime.Now.ToLongDateString());
            filepath = Path.Combine(exportPath, filename);
            chartPositions.ExportToImage(filepath, ImageFormat.Png);

            filename = string.Format("ESRM-LapTime Chart-{0}.png", DateTime.Now.ToLongDateString());
            filepath = Path.Combine(exportPath, filename);
            chartLaptimes.ExportToImage(filepath, ImageFormat.Png);

            filename = string.Format("ESRM-Fuel Chart-{0}.png", DateTime.Now.ToLongDateString());
            filepath = Path.Combine(exportPath, filename);
            chartFuel.ExportToImage(filepath, ImageFormat.Png);

            filename = string.Format("ESRM-Tires Chart-{0}.png", DateTime.Now.ToLongDateString());
            filepath = Path.Combine(exportPath, filename);
            chartTires.ExportToImage(filepath, ImageFormat.Png);

            MessageBox.Show(string.Format("Exported in {0}", exportPath));
        }
    }


}
