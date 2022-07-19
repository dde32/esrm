namespace ESRM.Win.Views
{
    partial class EndRacePage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndRacePage));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStatsPilotes = new ESRM.Win.ESRMButton();
            this.btnEndurance = new ESRM.Win.ESRMButton();
            this.btnGP = new ESRM.Win.ESRMButton();
            this.btnRedo = new ESRM.Win.ESRMButton();
            this.raceGrid = new ESRM.Win.Controls.BaseControls.ESRMGrid();
            this.classicRaceView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPilote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEditPilotName = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colImagePilote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPicturePilot = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colLapCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEditLapCount = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTires = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFuel = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPitStopCOunt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIncidents = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTCCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandLaps = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBestLap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAvgLap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandCarImage = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colImageCar = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureCar = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicRaceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditPilotName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPicturePilot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditLapCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnStatsPilotes);
            this.panel1.Controls.Add(this.btnEndurance);
            this.panel1.Controls.Add(this.btnGP);
            this.panel1.Controls.Add(this.btnRedo);
            this.panel1.Name = "panel1";
            // 
            // btnStatsPilotes
            // 
            resources.ApplyResources(this.btnStatsPilotes, "btnStatsPilotes");
            this.btnStatsPilotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStatsPilotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStatsPilotes.ForeColor = System.Drawing.Color.White;
            this.btnStatsPilotes.Name = "btnStatsPilotes";
            this.btnStatsPilotes.UseCompatibleTextRendering = true;
            this.btnStatsPilotes.UseVisualStyleBackColor = false;
            this.btnStatsPilotes.Click += new System.EventHandler(this.esrmButtonStatsPilotes_Click);
            // 
            // btnEndurance
            // 
            resources.ApplyResources(this.btnEndurance, "btnEndurance");
            this.btnEndurance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnEndurance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnEndurance.ForeColor = System.Drawing.Color.White;
            this.btnEndurance.Name = "btnEndurance";
            this.btnEndurance.UseCompatibleTextRendering = true;
            this.btnEndurance.UseVisualStyleBackColor = false;
            this.btnEndurance.Click += new System.EventHandler(this.btnEndurance_Click);
            // 
            // btnGP
            // 
            resources.ApplyResources(this.btnGP, "btnGP");
            this.btnGP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGP.ForeColor = System.Drawing.Color.White;
            this.btnGP.Name = "btnGP";
            this.btnGP.UseCompatibleTextRendering = true;
            this.btnGP.UseVisualStyleBackColor = false;
            this.btnGP.Click += new System.EventHandler(this.btnGP_Click);
            // 
            // btnRedo
            // 
            resources.ApplyResources(this.btnRedo, "btnRedo");
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRedo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRedo.ForeColor = System.Drawing.Color.White;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.UseCompatibleTextRendering = true;
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // raceGrid
            // 
            resources.ApplyResources(this.raceGrid, "raceGrid");
            this.raceGrid.BackgroundImage = global::ESRM.Win.Images.endracewp;
            this.raceGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("raceGrid.EmbeddedNavigator.AccessibleDescription");
            this.raceGrid.EmbeddedNavigator.AccessibleName = resources.GetString("raceGrid.EmbeddedNavigator.AccessibleName");
            this.raceGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("raceGrid.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.raceGrid.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("raceGrid.EmbeddedNavigator.Anchor")));
            this.raceGrid.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("raceGrid.EmbeddedNavigator.BackgroundImage")));
            this.raceGrid.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("raceGrid.EmbeddedNavigator.BackgroundImageLayout")));
            this.raceGrid.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("raceGrid.EmbeddedNavigator.ImeMode")));
            this.raceGrid.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("raceGrid.EmbeddedNavigator.MaximumSize")));
            this.raceGrid.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("raceGrid.EmbeddedNavigator.TextLocation")));
            this.raceGrid.EmbeddedNavigator.ToolTip = resources.GetString("raceGrid.EmbeddedNavigator.ToolTip");
            this.raceGrid.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("raceGrid.EmbeddedNavigator.ToolTipIconType")));
            this.raceGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("raceGrid.EmbeddedNavigator.ToolTipTitle");
            gridLevelNode1.RelationName = "Level1";
            this.raceGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.raceGrid.LookAndFeel.SkinName = "Darkroom";
            this.raceGrid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.raceGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.raceGrid.MainView = this.classicRaceView;
            this.raceGrid.Name = "raceGrid";
            this.raceGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPicturePilot,
            this.repositoryItemMemoEditLapCount,
            this.repositoryItemPictureCar,
            this.repositoryItemMemoEditPilotName,
            this.repositoryItemMemoEdit1});
            this.raceGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.classicRaceView});
            // 
            // classicRaceView
            // 
            this.classicRaceView.ActiveFilterEnabled = false;
            this.classicRaceView.Appearance.BandPanel.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.BandPanel.BackColor")));
            this.classicRaceView.Appearance.BandPanel.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.BandPanel.BackColor2")));
            this.classicRaceView.Appearance.BandPanel.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.BandPanel.FontSizeDelta")));
            this.classicRaceView.Appearance.BandPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.BandPanel.FontStyleDelta")));
            this.classicRaceView.Appearance.BandPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.BandPanel.GradientMode")));
            this.classicRaceView.Appearance.BandPanel.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.BandPanel.Image")));
            this.classicRaceView.Appearance.BandPanel.Options.UseBackColor = true;
            this.classicRaceView.Appearance.ColumnFilterButton.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.ColumnFilterButton.BackColor")));
            this.classicRaceView.Appearance.ColumnFilterButton.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.ColumnFilterButton.BackColor2")));
            this.classicRaceView.Appearance.ColumnFilterButton.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.ColumnFilterButton.FontSizeDelta")));
            this.classicRaceView.Appearance.ColumnFilterButton.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.ColumnFilterButton.FontStyleDelta")));
            this.classicRaceView.Appearance.ColumnFilterButton.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.ColumnFilterButton.GradientMode")));
            this.classicRaceView.Appearance.ColumnFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.ColumnFilterButton.Image")));
            this.classicRaceView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.classicRaceView.Appearance.DetailTip.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.DetailTip.BackColor")));
            this.classicRaceView.Appearance.DetailTip.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.DetailTip.BackColor2")));
            this.classicRaceView.Appearance.DetailTip.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.DetailTip.FontSizeDelta")));
            this.classicRaceView.Appearance.DetailTip.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.DetailTip.FontStyleDelta")));
            this.classicRaceView.Appearance.DetailTip.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.DetailTip.GradientMode")));
            this.classicRaceView.Appearance.DetailTip.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.DetailTip.Image")));
            this.classicRaceView.Appearance.DetailTip.Options.UseBackColor = true;
            this.classicRaceView.Appearance.Empty.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Empty.BackColor")));
            this.classicRaceView.Appearance.Empty.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Empty.BackColor2")));
            this.classicRaceView.Appearance.Empty.BorderColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Empty.BorderColor")));
            this.classicRaceView.Appearance.Empty.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.Empty.FontSizeDelta")));
            this.classicRaceView.Appearance.Empty.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.Empty.FontStyleDelta")));
            this.classicRaceView.Appearance.Empty.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.Empty.GradientMode")));
            this.classicRaceView.Appearance.Empty.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.Empty.Image")));
            this.classicRaceView.Appearance.Empty.Options.UseBackColor = true;
            this.classicRaceView.Appearance.Empty.Options.UseBorderColor = true;
            this.classicRaceView.Appearance.FocusedCell.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.FocusedCell.BackColor")));
            this.classicRaceView.Appearance.FocusedCell.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.FocusedCell.BackColor2")));
            this.classicRaceView.Appearance.FocusedCell.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.FocusedCell.FontSizeDelta")));
            this.classicRaceView.Appearance.FocusedCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.FocusedCell.FontStyleDelta")));
            this.classicRaceView.Appearance.FocusedCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.FocusedCell.GradientMode")));
            this.classicRaceView.Appearance.FocusedCell.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.FocusedCell.Image")));
            this.classicRaceView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.classicRaceView.Appearance.FocusedRow.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.FocusedRow.BackColor")));
            this.classicRaceView.Appearance.FocusedRow.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.FocusedRow.BackColor2")));
            this.classicRaceView.Appearance.FocusedRow.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.FocusedRow.FontSizeDelta")));
            this.classicRaceView.Appearance.FocusedRow.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.FocusedRow.FontStyleDelta")));
            this.classicRaceView.Appearance.FocusedRow.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.FocusedRow.GradientMode")));
            this.classicRaceView.Appearance.FocusedRow.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.FocusedRow.Image")));
            this.classicRaceView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.classicRaceView.Appearance.GroupRow.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.GroupRow.BackColor")));
            this.classicRaceView.Appearance.GroupRow.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.GroupRow.BackColor2")));
            this.classicRaceView.Appearance.GroupRow.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.GroupRow.FontSizeDelta")));
            this.classicRaceView.Appearance.GroupRow.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.GroupRow.FontStyleDelta")));
            this.classicRaceView.Appearance.GroupRow.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.GroupRow.GradientMode")));
            this.classicRaceView.Appearance.GroupRow.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.GroupRow.Image")));
            this.classicRaceView.Appearance.GroupRow.Options.UseBackColor = true;
            this.classicRaceView.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("classicRaceView.Appearance.HeaderPanel.Font")));
            this.classicRaceView.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.HeaderPanel.FontSizeDelta")));
            this.classicRaceView.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.HeaderPanel.FontStyleDelta")));
            this.classicRaceView.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.HeaderPanel.GradientMode")));
            this.classicRaceView.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.HeaderPanel.Image")));
            this.classicRaceView.Appearance.HeaderPanel.Options.UseFont = true;
            this.classicRaceView.Appearance.HideSelectionRow.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.HideSelectionRow.BackColor")));
            this.classicRaceView.Appearance.HideSelectionRow.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.HideSelectionRow.BackColor2")));
            this.classicRaceView.Appearance.HideSelectionRow.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.HideSelectionRow.FontSizeDelta")));
            this.classicRaceView.Appearance.HideSelectionRow.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.HideSelectionRow.FontStyleDelta")));
            this.classicRaceView.Appearance.HideSelectionRow.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.HideSelectionRow.GradientMode")));
            this.classicRaceView.Appearance.HideSelectionRow.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.HideSelectionRow.Image")));
            this.classicRaceView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.classicRaceView.Appearance.Preview.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Preview.BackColor")));
            this.classicRaceView.Appearance.Preview.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Preview.BackColor2")));
            this.classicRaceView.Appearance.Preview.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.Preview.FontSizeDelta")));
            this.classicRaceView.Appearance.Preview.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.Preview.FontStyleDelta")));
            this.classicRaceView.Appearance.Preview.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.Preview.GradientMode")));
            this.classicRaceView.Appearance.Preview.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.Preview.Image")));
            this.classicRaceView.Appearance.Preview.Options.UseBackColor = true;
            this.classicRaceView.Appearance.Row.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Row.BackColor")));
            this.classicRaceView.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.Row.FontSizeDelta")));
            this.classicRaceView.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.Row.FontStyleDelta")));
            this.classicRaceView.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.Row.GradientMode")));
            this.classicRaceView.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.Row.Image")));
            this.classicRaceView.Appearance.Row.Options.UseBackColor = true;
            this.classicRaceView.Appearance.RowSeparator.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.RowSeparator.BackColor")));
            this.classicRaceView.Appearance.RowSeparator.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.RowSeparator.BackColor2")));
            this.classicRaceView.Appearance.RowSeparator.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.RowSeparator.FontSizeDelta")));
            this.classicRaceView.Appearance.RowSeparator.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.RowSeparator.FontStyleDelta")));
            this.classicRaceView.Appearance.RowSeparator.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.RowSeparator.GradientMode")));
            this.classicRaceView.Appearance.RowSeparator.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.RowSeparator.Image")));
            this.classicRaceView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.classicRaceView.Appearance.SelectedRow.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.SelectedRow.BackColor")));
            this.classicRaceView.Appearance.SelectedRow.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.SelectedRow.BackColor2")));
            this.classicRaceView.Appearance.SelectedRow.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.SelectedRow.FontSizeDelta")));
            this.classicRaceView.Appearance.SelectedRow.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.SelectedRow.FontStyleDelta")));
            this.classicRaceView.Appearance.SelectedRow.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.SelectedRow.GradientMode")));
            this.classicRaceView.Appearance.SelectedRow.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.SelectedRow.Image")));
            this.classicRaceView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.classicRaceView.Appearance.ViewCaption.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.ViewCaption.BackColor")));
            this.classicRaceView.Appearance.ViewCaption.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.ViewCaption.BackColor2")));
            this.classicRaceView.Appearance.ViewCaption.FontSizeDelta = ((int)(resources.GetObject("classicRaceView.Appearance.ViewCaption.FontSizeDelta")));
            this.classicRaceView.Appearance.ViewCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("classicRaceView.Appearance.ViewCaption.FontStyleDelta")));
            this.classicRaceView.Appearance.ViewCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("classicRaceView.Appearance.ViewCaption.GradientMode")));
            this.classicRaceView.Appearance.ViewCaption.Image = ((System.Drawing.Image)(resources.GetObject("classicRaceView.Appearance.ViewCaption.Image")));
            this.classicRaceView.Appearance.ViewCaption.Options.UseBackColor = true;
            this.classicRaceView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand6,
            this.gridBand1,
            this.bandLaps,
            this.bandCarImage});
            this.classicRaceView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.classicRaceView, "classicRaceView");
            this.classicRaceView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colPilote,
            this.colImagePilote,
            this.colLapCount,
            this.colGap,
            this.colBestLap,
            this.colAvgLap,
            this.colFuel,
            this.colTires,
            this.colPitStopCOunt,
            this.colIncidents,
            this.colTCCount,
            this.colImageCar,
            this.bandedGridColumn1});
            this.classicRaceView.GridControl = this.raceGrid;
            this.classicRaceView.Name = "classicRaceView";
            this.classicRaceView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsBehavior.AutoPopulateColumns = false;
            this.classicRaceView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.classicRaceView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.classicRaceView.OptionsBehavior.Editable = false;
            this.classicRaceView.OptionsBehavior.ReadOnly = true;
            this.classicRaceView.OptionsBehavior.SmartVertScrollBar = false;
            this.classicRaceView.OptionsCustomization.AllowBandMoving = false;
            this.classicRaceView.OptionsCustomization.AllowBandResizing = false;
            this.classicRaceView.OptionsCustomization.AllowColumnMoving = false;
            this.classicRaceView.OptionsCustomization.AllowFilter = false;
            this.classicRaceView.OptionsCustomization.AllowGroup = false;
            this.classicRaceView.OptionsCustomization.AllowQuickHideColumns = false;
            this.classicRaceView.OptionsCustomization.AllowRowSizing = true;
            this.classicRaceView.OptionsCustomization.AllowSort = false;
            this.classicRaceView.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.classicRaceView.OptionsDetail.EnableMasterViewMode = false;
            this.classicRaceView.OptionsDetail.ShowDetailTabs = false;
            this.classicRaceView.OptionsDetail.SmartDetailExpand = false;
            this.classicRaceView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.classicRaceView.OptionsFilter.AllowFilterEditor = false;
            this.classicRaceView.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.classicRaceView.OptionsFilter.AllowMRUFilterList = false;
            this.classicRaceView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.classicRaceView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.classicRaceView.OptionsFind.AllowFindPanel = false;
            this.classicRaceView.OptionsFind.ClearFindOnClose = false;
            this.classicRaceView.OptionsNavigation.AutoMoveRowFocus = false;
            this.classicRaceView.OptionsNavigation.UseAdvHorzNavigation = false;
            this.classicRaceView.OptionsNavigation.UseAdvVertNavigation = false;
            this.classicRaceView.OptionsNavigation.UseOfficePageNavigation = false;
            this.classicRaceView.OptionsNavigation.UseTabKey = false;
            this.classicRaceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.classicRaceView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.classicRaceView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.classicRaceView.OptionsView.AllowGlyphSkinning = true;
            this.classicRaceView.OptionsView.ColumnAutoWidth = true;
            this.classicRaceView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.classicRaceView.OptionsView.ShowBands = false;
            this.classicRaceView.OptionsView.ShowColumnHeaders = false;
            this.classicRaceView.OptionsView.ShowDetailButtons = false;
            this.classicRaceView.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.classicRaceView.OptionsView.ShowGroupPanel = false;
            this.classicRaceView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsView.ShowIndicator = false;
            this.classicRaceView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.classicRaceView.RowHeight = 45;
            this.classicRaceView.RowSeparatorHeight = 2;
            this.classicRaceView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;
            this.classicRaceView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.classicRaceView_RowCellStyle);
            // 
            // gridBand2
            // 
            resources.ApplyResources(this.gridBand2, "gridBand2");
            this.gridBand2.VisibleIndex = 0;
            // 
            // gridBand6
            // 
            resources.ApplyResources(this.gridBand6, "gridBand6");
            this.gridBand6.Columns.Add(this.colPilote);
            this.gridBand6.Columns.Add(this.colImagePilote);
            this.gridBand6.Columns.Add(this.colLapCount);
            this.gridBand6.VisibleIndex = 1;
            // 
            // colPilote
            // 
            this.colPilote.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colPilote.AppearanceCell.Font")));
            this.colPilote.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colPilote.AppearanceCell.FontSizeDelta")));
            this.colPilote.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colPilote.AppearanceCell.FontStyleDelta")));
            this.colPilote.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPilote.AppearanceCell.ForeColor")));
            this.colPilote.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colPilote.AppearanceCell.GradientMode")));
            this.colPilote.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colPilote.AppearanceCell.Image")));
            this.colPilote.AppearanceCell.Options.UseFont = true;
            this.colPilote.AppearanceCell.Options.UseForeColor = true;
            this.colPilote.AppearanceCell.Options.UseTextOptions = true;
            this.colPilote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPilote.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.colPilote.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("colPilote.AppearanceHeader.Font")));
            this.colPilote.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("colPilote.AppearanceHeader.FontSizeDelta")));
            this.colPilote.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colPilote.AppearanceHeader.FontStyleDelta")));
            this.colPilote.AppearanceHeader.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPilote.AppearanceHeader.ForeColor")));
            this.colPilote.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colPilote.AppearanceHeader.GradientMode")));
            this.colPilote.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("colPilote.AppearanceHeader.Image")));
            this.colPilote.AppearanceHeader.Options.UseFont = true;
            this.colPilote.AppearanceHeader.Options.UseForeColor = true;
            resources.ApplyResources(this.colPilote, "colPilote");
            this.colPilote.ColumnEdit = this.repositoryItemMemoEditPilotName;
            this.colPilote.FieldName = "TeamAndPilotName";
            this.colPilote.Name = "colPilote";
            this.colPilote.RowCount = 2;
            // 
            // repositoryItemMemoEditPilotName
            // 
            this.repositoryItemMemoEditPilotName.AcceptsTab = true;
            resources.ApplyResources(this.repositoryItemMemoEditPilotName, "repositoryItemMemoEditPilotName");
            this.repositoryItemMemoEditPilotName.AllowMouseWheel = false;
            this.repositoryItemMemoEditPilotName.Appearance.FontSizeDelta = ((int)(resources.GetObject("repositoryItemMemoEditPilotName.Appearance.FontSizeDelta")));
            this.repositoryItemMemoEditPilotName.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("repositoryItemMemoEditPilotName.Appearance.FontStyleDelta")));
            this.repositoryItemMemoEditPilotName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("repositoryItemMemoEditPilotName.Appearance.GradientMode")));
            this.repositoryItemMemoEditPilotName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemMemoEditPilotName.Appearance.Image")));
            this.repositoryItemMemoEditPilotName.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEditPilotName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemMemoEditPilotName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemMemoEditPilotName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemMemoEditPilotName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.repositoryItemMemoEditPilotName.LinesCount = 3;
            this.repositoryItemMemoEditPilotName.Name = "repositoryItemMemoEditPilotName";
            this.repositoryItemMemoEditPilotName.WordWrap = false;
            // 
            // colImagePilote
            // 
            resources.ApplyResources(this.colImagePilote, "colImagePilote");
            this.colImagePilote.ColumnEdit = this.repositoryItemPicturePilot;
            this.colImagePilote.FieldName = "TeamImage";
            this.colImagePilote.Name = "colImagePilote";
            this.colImagePilote.RowCount = 4;
            this.colImagePilote.RowIndex = 1;
            // 
            // repositoryItemPicturePilot
            // 
            resources.ApplyResources(this.repositoryItemPicturePilot, "repositoryItemPicturePilot");
            this.repositoryItemPicturePilot.ContextButtonOptions.AnimationType = DevExpress.Utils.ContextAnimationType.OpacityAnimation;
            this.repositoryItemPicturePilot.Name = "repositoryItemPicturePilot";
            this.repositoryItemPicturePilot.ShowMenu = false;
            this.repositoryItemPicturePilot.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPicturePilot.ZoomAccelerationFactor = 1D;
            // 
            // colLapCount
            // 
            this.colLapCount.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colLapCount.AppearanceCell.Font")));
            this.colLapCount.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colLapCount.AppearanceCell.FontSizeDelta")));
            this.colLapCount.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colLapCount.AppearanceCell.FontStyleDelta")));
            this.colLapCount.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colLapCount.AppearanceCell.ForeColor")));
            this.colLapCount.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colLapCount.AppearanceCell.GradientMode")));
            this.colLapCount.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colLapCount.AppearanceCell.Image")));
            this.colLapCount.AppearanceCell.Options.UseFont = true;
            this.colLapCount.AppearanceCell.Options.UseForeColor = true;
            this.colLapCount.AppearanceCell.Options.UseTextOptions = true;
            this.colLapCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLapCount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colLapCount, "colLapCount");
            this.colLapCount.ColumnEdit = this.repositoryItemMemoEditLapCount;
            this.colLapCount.FieldName = "LapCountForUI";
            this.colLapCount.Name = "colLapCount";
            this.colLapCount.RowCount = 4;
            this.colLapCount.RowIndex = 1;
            // 
            // repositoryItemMemoEditLapCount
            // 
            this.repositoryItemMemoEditLapCount.AcceptsTab = true;
            resources.ApplyResources(this.repositoryItemMemoEditLapCount, "repositoryItemMemoEditLapCount");
            this.repositoryItemMemoEditLapCount.Name = "repositoryItemMemoEditLapCount";
            // 
            // gridBand1
            // 
            resources.ApplyResources(this.gridBand1, "gridBand1");
            this.gridBand1.Columns.Add(this.colTires);
            this.gridBand1.Columns.Add(this.colFuel);
            this.gridBand1.Columns.Add(this.colPitStopCOunt);
            this.gridBand1.Columns.Add(this.colIncidents);
            this.gridBand1.Columns.Add(this.colTCCount);
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.VisibleIndex = 2;
            // 
            // colTires
            // 
            this.colTires.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colTires.AppearanceCell.FontSizeDelta")));
            this.colTires.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colTires.AppearanceCell.FontStyleDelta")));
            this.colTires.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colTires.AppearanceCell.ForeColor")));
            this.colTires.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colTires.AppearanceCell.GradientMode")));
            this.colTires.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colTires.AppearanceCell.Image")));
            this.colTires.AppearanceCell.Options.UseForeColor = true;
            this.colTires.AppearanceCell.Options.UseTextOptions = true;
            this.colTires.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTires.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colTires, "colTires");
            this.colTires.FieldName = "UsedTiresForEndRace";
            this.colTires.Name = "colTires";
            // 
            // colFuel
            // 
            this.colFuel.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colFuel.AppearanceCell.FontSizeDelta")));
            this.colFuel.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colFuel.AppearanceCell.FontStyleDelta")));
            this.colFuel.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colFuel.AppearanceCell.ForeColor")));
            this.colFuel.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colFuel.AppearanceCell.GradientMode")));
            this.colFuel.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colFuel.AppearanceCell.Image")));
            this.colFuel.AppearanceCell.Options.UseForeColor = true;
            this.colFuel.AppearanceCell.Options.UseTextOptions = true;
            this.colFuel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFuel.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colFuel, "colFuel");
            this.colFuel.FieldName = "UsedFuelForEndRace";
            this.colFuel.Name = "colFuel";
            this.colFuel.RowIndex = 1;
            // 
            // colPitStopCOunt
            // 
            this.colPitStopCOunt.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colPitStopCOunt.AppearanceCell.FontSizeDelta")));
            this.colPitStopCOunt.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colPitStopCOunt.AppearanceCell.FontStyleDelta")));
            this.colPitStopCOunt.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPitStopCOunt.AppearanceCell.ForeColor")));
            this.colPitStopCOunt.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colPitStopCOunt.AppearanceCell.GradientMode")));
            this.colPitStopCOunt.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colPitStopCOunt.AppearanceCell.Image")));
            this.colPitStopCOunt.AppearanceCell.Options.UseForeColor = true;
            this.colPitStopCOunt.AppearanceCell.Options.UseTextOptions = true;
            this.colPitStopCOunt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPitStopCOunt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colPitStopCOunt, "colPitStopCOunt");
            this.colPitStopCOunt.FieldName = "PitStopForEndRace";
            this.colPitStopCOunt.Name = "colPitStopCOunt";
            this.colPitStopCOunt.RowIndex = 2;
            // 
            // colIncidents
            // 
            this.colIncidents.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colIncidents.AppearanceCell.Font")));
            this.colIncidents.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colIncidents.AppearanceCell.FontSizeDelta")));
            this.colIncidents.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colIncidents.AppearanceCell.FontStyleDelta")));
            this.colIncidents.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colIncidents.AppearanceCell.ForeColor")));
            this.colIncidents.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colIncidents.AppearanceCell.GradientMode")));
            this.colIncidents.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colIncidents.AppearanceCell.Image")));
            this.colIncidents.AppearanceCell.Options.UseFont = true;
            this.colIncidents.AppearanceCell.Options.UseForeColor = true;
            this.colIncidents.AppearanceCell.Options.UseTextOptions = true;
            this.colIncidents.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIncidents.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colIncidents, "colIncidents");
            this.colIncidents.FieldName = "IncidentCountForEndRace";
            this.colIncidents.Name = "colIncidents";
            this.colIncidents.RowIndex = 3;
            // 
            // colTCCount
            // 
            this.colTCCount.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colTCCount.AppearanceCell.FontSizeDelta")));
            this.colTCCount.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colTCCount.AppearanceCell.FontStyleDelta")));
            this.colTCCount.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colTCCount.AppearanceCell.ForeColor")));
            this.colTCCount.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colTCCount.AppearanceCell.GradientMode")));
            this.colTCCount.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colTCCount.AppearanceCell.Image")));
            this.colTCCount.AppearanceCell.Options.UseForeColor = true;
            this.colTCCount.AppearanceCell.Options.UseTextOptions = true;
            this.colTCCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTCCount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colTCCount, "colTCCount");
            this.colTCCount.FieldName = "TrackCallCountForEndRace";
            this.colTCCount.Name = "colTCCount";
            this.colTCCount.RowIndex = 4;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("bandedGridColumn1.AppearanceCell.FontSizeDelta")));
            this.bandedGridColumn1.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bandedGridColumn1.AppearanceCell.FontStyleDelta")));
            this.bandedGridColumn1.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bandedGridColumn1.AppearanceCell.GradientMode")));
            this.bandedGridColumn1.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("bandedGridColumn1.AppearanceCell.Image")));
            this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.bandedGridColumn1, "bandedGridColumn1");
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.RowIndex = 5;
            // 
            // bandLaps
            // 
            resources.ApplyResources(this.bandLaps, "bandLaps");
            this.bandLaps.Columns.Add(this.colGap);
            this.bandLaps.Columns.Add(this.colBestLap);
            this.bandLaps.Columns.Add(this.colAvgLap);
            this.bandLaps.VisibleIndex = 3;
            // 
            // colGap
            // 
            this.colGap.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colGap.AppearanceCell.Font")));
            this.colGap.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colGap.AppearanceCell.FontSizeDelta")));
            this.colGap.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colGap.AppearanceCell.FontStyleDelta")));
            this.colGap.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colGap.AppearanceCell.ForeColor")));
            this.colGap.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colGap.AppearanceCell.GradientMode")));
            this.colGap.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colGap.AppearanceCell.Image")));
            this.colGap.AppearanceCell.Options.UseFont = true;
            this.colGap.AppearanceCell.Options.UseForeColor = true;
            this.colGap.AppearanceCell.Options.UseTextOptions = true;
            this.colGap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colGap, "colGap");
            this.colGap.FieldName = "GapForEndRace";
            this.colGap.Name = "colGap";
            this.colGap.RowCount = 2;
            // 
            // colBestLap
            // 
            this.colBestLap.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colBestLap.AppearanceCell.Font")));
            this.colBestLap.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colBestLap.AppearanceCell.FontSizeDelta")));
            this.colBestLap.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colBestLap.AppearanceCell.FontStyleDelta")));
            this.colBestLap.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colBestLap.AppearanceCell.ForeColor")));
            this.colBestLap.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colBestLap.AppearanceCell.GradientMode")));
            this.colBestLap.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colBestLap.AppearanceCell.Image")));
            this.colBestLap.AppearanceCell.Options.UseFont = true;
            this.colBestLap.AppearanceCell.Options.UseForeColor = true;
            this.colBestLap.AppearanceCell.Options.UseTextOptions = true;
            this.colBestLap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colBestLap, "colBestLap");
            this.colBestLap.FieldName = "BestLapForEndRace";
            this.colBestLap.Name = "colBestLap";
            this.colBestLap.RowCount = 2;
            this.colBestLap.RowIndex = 1;
            // 
            // colAvgLap
            // 
            this.colAvgLap.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colAvgLap.AppearanceCell.FontSizeDelta")));
            this.colAvgLap.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colAvgLap.AppearanceCell.FontStyleDelta")));
            this.colAvgLap.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colAvgLap.AppearanceCell.ForeColor")));
            this.colAvgLap.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colAvgLap.AppearanceCell.GradientMode")));
            this.colAvgLap.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colAvgLap.AppearanceCell.Image")));
            this.colAvgLap.AppearanceCell.Options.UseForeColor = true;
            this.colAvgLap.AppearanceCell.Options.UseTextOptions = true;
            this.colAvgLap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colAvgLap, "colAvgLap");
            this.colAvgLap.FieldName = "AverageLapForEndRace";
            this.colAvgLap.Name = "colAvgLap";
            this.colAvgLap.RowCount = 2;
            this.colAvgLap.RowIndex = 2;
            // 
            // bandCarImage
            // 
            resources.ApplyResources(this.bandCarImage, "bandCarImage");
            this.bandCarImage.Columns.Add(this.colImageCar);
            this.bandCarImage.VisibleIndex = 4;
            // 
            // colImageCar
            // 
            this.colImageCar.AppearanceCell.BorderColor = ((System.Drawing.Color)(resources.GetObject("colImageCar.AppearanceCell.BorderColor")));
            this.colImageCar.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colImageCar.AppearanceCell.FontSizeDelta")));
            this.colImageCar.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colImageCar.AppearanceCell.FontStyleDelta")));
            this.colImageCar.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colImageCar.AppearanceCell.GradientMode")));
            this.colImageCar.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colImageCar.AppearanceCell.Image")));
            this.colImageCar.AppearanceCell.Options.UseBorderColor = true;
            resources.ApplyResources(this.colImageCar, "colImageCar");
            this.colImageCar.ColumnEdit = this.repositoryItemPictureCar;
            this.colImageCar.FieldName = "CarImage";
            this.colImageCar.Name = "colImageCar";
            this.colImageCar.RowCount = 6;
            // 
            // repositoryItemPictureCar
            // 
            resources.ApplyResources(this.repositoryItemPictureCar, "repositoryItemPictureCar");
            this.repositoryItemPictureCar.Name = "repositoryItemPictureCar";
            this.repositoryItemPictureCar.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureCar.ZoomAccelerationFactor = 1D;
            // 
            // repositoryItemMemoEdit1
            // 
            resources.ApplyResources(this.repositoryItemMemoEdit1, "repositoryItemMemoEdit1");
            this.repositoryItemMemoEdit1.Appearance.FontSizeDelta = ((int)(resources.GetObject("repositoryItemMemoEdit1.Appearance.FontSizeDelta")));
            this.repositoryItemMemoEdit1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("repositoryItemMemoEdit1.Appearance.FontStyleDelta")));
            this.repositoryItemMemoEdit1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("repositoryItemMemoEdit1.Appearance.GradientMode")));
            this.repositoryItemMemoEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemMemoEdit1.Appearance.Image")));
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // EndRacePage
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.raceGrid);
            this.Controls.Add(this.panel1);
            this.Name = "EndRacePage";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.raceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicRaceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditPilotName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPicturePilot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditLapCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ESRMButton btnStatsPilotes;
        private ESRMButton btnEndurance;
        private ESRMButton btnGP;
        private ESRMButton btnRedo;
        private Controls.BaseControls.ESRMGrid raceGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView classicRaceView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPilote;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditPilotName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImagePilote;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPicturePilot;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLapCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditLapCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPitStopCOunt;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFuel;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTires;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBestLap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIncidents;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImageCar;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureCar;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAvgLap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTCCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandLaps;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandCarImage;
    }
}
