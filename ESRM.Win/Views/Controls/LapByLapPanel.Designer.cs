using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    partial class LapByLapPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LapByLapPanel));
            this.scalablePanel1 = new ESRM.Win.ScalablePanel();
            this.lblPilotName = new System.Windows.Forms.Label();
            this.panelFill = new ESRM.Win.ScalablePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRelay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLapTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConsoFuel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTires = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHealth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTCCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPitStop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeSpanEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel1)).BeginInit();
            this.scalablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).BeginInit();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeSpanEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // scalablePanel1
            // 
            resources.ApplyResources(this.scalablePanel1, "scalablePanel1");
            this.scalablePanel1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("scalablePanel1.Appearance.BackColor")));
            this.scalablePanel1.Appearance.FontSizeDelta = ((int)(resources.GetObject("scalablePanel1.Appearance.FontSizeDelta")));
            this.scalablePanel1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("scalablePanel1.Appearance.FontStyleDelta")));
            this.scalablePanel1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("scalablePanel1.Appearance.GradientMode")));
            this.scalablePanel1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("scalablePanel1.Appearance.Image")));
            this.scalablePanel1.Appearance.Options.UseBackColor = true;
            this.scalablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scalablePanel1.Controls.Add(this.lblPilotName);
            this.scalablePanel1.Name = "scalablePanel1";
            // 
            // lblPilotName
            // 
            resources.ApplyResources(this.lblPilotName, "lblPilotName");
            this.lblPilotName.BackColor = System.Drawing.Color.Transparent;
            this.lblPilotName.ForeColor = System.Drawing.Color.White;
            this.lblPilotName.Name = "lblPilotName";
            // 
            // panelFill
            // 
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelFill.Appearance.BackColor")));
            this.panelFill.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelFill.Appearance.FontSizeDelta")));
            this.panelFill.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelFill.Appearance.FontStyleDelta")));
            this.panelFill.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelFill.Appearance.GradientMode")));
            this.panelFill.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelFill.Appearance.Image")));
            this.panelFill.Appearance.Options.UseBackColor = true;
            this.panelFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFill.Controls.Add(this.gridControl1);
            this.panelFill.Name = "panelFill";
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleDescription");
            this.gridControl1.EmbeddedNavigator.AccessibleName = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleName");
            this.gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl1.EmbeddedNavigator.Anchor")));
            this.gridControl1.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImage")));
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl1.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl1.EmbeddedNavigator.ImeMode")));
            this.gridControl1.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridControl1.EmbeddedNavigator.MaximumSize")));
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeSpanEdit1});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRelay,
            this.colLap,
            this.colLapTime,
            this.colConsoFuel,
            this.colTires,
            this.colHealth,
            this.colTCCount,
            this.colPitStop});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRelay, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colRelay
            // 
            resources.ApplyResources(this.colRelay, "colRelay");
            this.colRelay.FieldName = "Relay";
            this.colRelay.Name = "colRelay";
            this.colRelay.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colRelay.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colLap
            // 
            resources.ApplyResources(this.colLap, "colLap");
            this.colLap.FieldName = "Number";
            this.colLap.Name = "colLap";
            this.colLap.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colLapTime
            // 
            resources.ApplyResources(this.colLapTime, "colLapTime");
            this.colLapTime.FieldName = "LapTimeForUI";
            this.colLapTime.Name = "colLapTime";
            this.colLapTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colConsoFuel
            // 
            resources.ApplyResources(this.colConsoFuel, "colConsoFuel");
            this.colConsoFuel.DisplayFormat.FormatString = "n2";
            this.colConsoFuel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colConsoFuel.FieldName = "FuelConso";
            this.colConsoFuel.Name = "colConsoFuel";
            this.colConsoFuel.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colTires
            // 
            resources.ApplyResources(this.colTires, "colTires");
            this.colTires.DisplayFormat.FormatString = "n2";
            this.colTires.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTires.FieldName = "TiresWear";
            this.colTires.Name = "colTires";
            this.colTires.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colHealth
            // 
            resources.ApplyResources(this.colHealth, "colHealth");
            this.colHealth.DisplayFormat.FormatString = "n0";
            this.colHealth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHealth.FieldName = "CarHealth";
            this.colHealth.Name = "colHealth";
            this.colHealth.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colTCCount
            // 
            resources.ApplyResources(this.colTCCount, "colTCCount");
            this.colTCCount.FieldName = "TrackCallCount";
            this.colTCCount.Name = "colTCCount";
            // 
            // colPitStop
            // 
            resources.ApplyResources(this.colPitStop, "colPitStop");
            this.colPitStop.FieldName = "PitStopinLap";
            this.colPitStop.Name = "colPitStop";
            this.colPitStop.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // repositoryItemTimeSpanEdit1
            // 
            resources.ApplyResources(this.repositoryItemTimeSpanEdit1, "repositoryItemTimeSpanEdit1");
            this.repositoryItemTimeSpanEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemTimeSpanEdit1.Buttons"))))});
            this.repositoryItemTimeSpanEdit1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.AutoComplete")));
            this.repositoryItemTimeSpanEdit1.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.BeepOnError")));
            this.repositoryItemTimeSpanEdit1.Mask.EditMask = resources.GetString("repositoryItemTimeSpanEdit1.Mask.EditMask");
            this.repositoryItemTimeSpanEdit1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.IgnoreMaskBlank")));
            this.repositoryItemTimeSpanEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.MaskType")));
            this.repositoryItemTimeSpanEdit1.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.PlaceHolder")));
            this.repositoryItemTimeSpanEdit1.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.SaveLiteral")));
            this.repositoryItemTimeSpanEdit1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.ShowPlaceHolders")));
            this.repositoryItemTimeSpanEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTimeSpanEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTimeSpanEdit1.Name = "repositoryItemTimeSpanEdit1";
            // 
            // LapByLapPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.scalablePanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "LapByLapPanel";
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel1)).EndInit();
            this.scalablePanel1.ResumeLayout(false);
            this.scalablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).EndInit();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeSpanEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ScalablePanel scalablePanel1;
        private System.Windows.Forms.Label lblPilotName;
        private ScalablePanel panelFill;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLap;
        private DevExpress.XtraGrid.Columns.GridColumn colLapTime;
        private DevExpress.XtraGrid.Columns.GridColumn colConsoFuel;
        private DevExpress.XtraGrid.Columns.GridColumn colTires;
        private DevExpress.XtraGrid.Columns.GridColumn colTCCount;
        private DevExpress.XtraGrid.Columns.GridColumn colPitStop;
        private DevExpress.XtraGrid.Columns.GridColumn colRelay;
        private DevExpress.XtraGrid.Columns.GridColumn colHealth;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit repositoryItemTimeSpanEdit1;
    }
}
