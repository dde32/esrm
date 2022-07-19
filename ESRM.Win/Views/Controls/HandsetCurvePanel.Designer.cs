namespace ESRM.Win
{
    partial class HandsetCurvePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HandsetCurvePanel));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Trigger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewCurve = new ESRM.Win.ESRMButton();
            this.btnSmooth = new ESRM.Win.ESRMButton();
            this.btnRAZ = new ESRM.Win.ESRMButton();
            this.cbxThCurves = new System.Windows.Forms.ComboBox();
            this.btnDeleteThCurve = new ESRM.Win.ESRMButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveThCurveAs = new ESRM.Win.ESRMButton();
            this.btnSaveThCurve = new ESRM.Win.ESRMButton();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCalibrationMessage = new System.Windows.Forms.Label();
            this.btnCalibrate = new ESRM.Win.ESRMButton();
            this.edtItemName = new System.Windows.Forms.TextBox();
            this.panelSelect.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelect
            // 
            resources.ApplyResources(this.panelSelect, "panelSelect");
            this.panelSelect.Controls.Add(this.panel2);
            this.panelSelect.Controls.Add(this.panel1);
            this.panelSelect.Name = "panelSelect";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.chartControl1);
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Name = "panel2";
            // 
            // chartControl1
            // 
            resources.ApplyResources(this.chartControl1, "chartControl1");
            this.chartControl1.AllowDrop = true;
            this.chartControl1.AppearanceNameSerializable = "Dark";
            this.chartControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.chartControl1.CacheToMemory = true;
            this.chartControl1.CrosshairOptions.ArgumentLineColor = System.Drawing.Color.YellowGreen;
            this.chartControl1.CrosshairOptions.ShowValueLabels = true;
            this.chartControl1.CrosshairOptions.ShowValueLine = true;
            this.chartControl1.CrosshairOptions.ValueLineColor = System.Drawing.Color.YellowGreen;
            xyDiagram1.AxisX.GridLines.MinorVisible = true;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Interlaced = true;
            xyDiagram1.AxisX.Title.Text = resources.GetString("resource.Text");
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Text = resources.GetString("resource.Text1");
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisY.WholeRange.SideMarginsValue = 6.5D;
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.AlignmentHorizontal = ((DevExpress.XtraCharts.LegendAlignmentHorizontal)(resources.GetObject("chartControl1.Legend.AlignmentHorizontal")));
            this.chartControl1.Legend.AlignmentVertical = ((DevExpress.XtraCharts.LegendAlignmentVertical)(resources.GetObject("chartControl1.Legend.AlignmentVertical")));
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.UseCheckBoxes = true;
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Aspect";
            this.chartControl1.RuntimeHitTesting = true;
            this.chartControl1.SelectionMode = DevExpress.XtraCharts.ElementSelectionMode.Extended;
            this.chartControl1.SeriesSelectionMode = DevExpress.XtraCharts.SeriesSelectionMode.Point;
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.CheckableInLegend = false;
            series1.CheckedInLegend = false;
            series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series1.CrosshairLabelPattern = "{V:n}";
            resources.ApplyResources(series1, "series1");
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            lineSeriesView1.LineMarkerOptions.Size = 6;
            series1.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.SeriesTemplate.ColorDataMember = "Color";
            pointSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.HideOverlapped;
            pointSeriesLabel1.TextPattern = "{V:n3}";
            this.chartControl1.SeriesTemplate.Label = pointSeriesLabel1;
            lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.SeriesTemplate.View = lineSeriesView2;
            this.chartControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartControl1_MouseClick);
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
            this.gridControl1.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControl1.EmbeddedNavigator.Margin")));
            this.gridControl1.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridControl1.EmbeddedNavigator.MaximumSize")));
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.LookAndFeel.SkinName = "Darkroom";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
            this.gridView1.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("gridView1.Appearance.HeaderPanel.FontSizeDelta")));
            this.gridView1.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gridView1.Appearance.HeaderPanel.FontStyleDelta")));
            this.gridView1.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gridView1.Appearance.HeaderPanel.GradientMode")));
            this.gridView1.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("gridView1.Appearance.HeaderPanel.Image")));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.Row.Font")));
            this.gridView1.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("gridView1.Appearance.Row.FontSizeDelta")));
            this.gridView1.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gridView1.Appearance.Row.FontStyleDelta")));
            this.gridView1.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gridView1.Appearance.Row.GradientMode")));
            this.gridView1.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("gridView1.Appearance.Row.Image")));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Trigger,
            this.Result});
            this.gridView1.DetailHeight = 220;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("resource.BackColor")));
            formatConditionRuleValue1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            formatConditionRuleValue1.Appearance.FontSizeDelta = ((int)(resources.GetObject("resource.FontSizeDelta")));
            formatConditionRuleValue1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("resource.FontStyleDelta")));
            formatConditionRuleValue1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("resource.GradientMode")));
            formatConditionRuleValue1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gridView1.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.ClearFindOnClose = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Trigger
            // 
            this.Trigger.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("Trigger.AppearanceCell.FontSizeDelta")));
            this.Trigger.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("Trigger.AppearanceCell.FontStyleDelta")));
            this.Trigger.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("Trigger.AppearanceCell.GradientMode")));
            this.Trigger.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("Trigger.AppearanceCell.Image")));
            this.Trigger.AppearanceCell.Options.UseTextOptions = true;
            this.Trigger.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.Trigger, "Trigger");
            this.Trigger.DisplayFormat.FormatString = "n3";
            this.Trigger.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Trigger.FieldName = "Value";
            this.Trigger.Name = "Trigger";
            this.Trigger.OptionsColumn.AllowEdit = false;
            // 
            // Result
            // 
            this.Result.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("Result.AppearanceCell.FontSizeDelta")));
            this.Result.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("Result.AppearanceCell.FontStyleDelta")));
            this.Result.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("Result.AppearanceCell.GradientMode")));
            this.Result.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("Result.AppearanceCell.Image")));
            this.Result.AppearanceCell.Options.UseTextOptions = true;
            this.Result.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.Result, "Result");
            this.Result.FieldName = "ResultValue";
            this.Result.Name = "Result";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnNewCurve);
            this.panel1.Controls.Add(this.btnSmooth);
            this.panel1.Controls.Add(this.btnRAZ);
            this.panel1.Controls.Add(this.cbxThCurves);
            this.panel1.Controls.Add(this.btnDeleteThCurve);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSaveThCurveAs);
            this.panel1.Controls.Add(this.btnSaveThCurve);
            this.panel1.Name = "panel1";
            // 
            // btnNewCurve
            // 
            resources.ApplyResources(this.btnNewCurve, "btnNewCurve");
            this.btnNewCurve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnNewCurve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnNewCurve.ForeColor = System.Drawing.Color.White;
            this.btnNewCurve.Name = "btnNewCurve";
            this.btnNewCurve.UseCompatibleTextRendering = true;
            this.btnNewCurve.UseVisualStyleBackColor = false;
            this.btnNewCurve.Click += new System.EventHandler(this.btnNewCurve_Click);
            // 
            // btnSmooth
            // 
            resources.ApplyResources(this.btnSmooth, "btnSmooth");
            this.btnSmooth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSmooth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSmooth.ForeColor = System.Drawing.Color.White;
            this.btnSmooth.Name = "btnSmooth";
            this.btnSmooth.UseCompatibleTextRendering = true;
            this.btnSmooth.UseVisualStyleBackColor = false;
            this.btnSmooth.Click += new System.EventHandler(this.btnSmooth_Click);
            // 
            // btnRAZ
            // 
            resources.ApplyResources(this.btnRAZ, "btnRAZ");
            this.btnRAZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRAZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRAZ.ForeColor = System.Drawing.Color.White;
            this.btnRAZ.Name = "btnRAZ";
            this.btnRAZ.UseCompatibleTextRendering = true;
            this.btnRAZ.UseVisualStyleBackColor = false;
            this.btnRAZ.Click += new System.EventHandler(this.btnRAZ_Click);
            // 
            // cbxThCurves
            // 
            resources.ApplyResources(this.cbxThCurves, "cbxThCurves");
            this.cbxThCurves.DisplayMember = "Title";
            this.cbxThCurves.FormattingEnabled = true;
            this.cbxThCurves.Name = "cbxThCurves";
            this.cbxThCurves.ValueMember = "Title";
            this.cbxThCurves.SelectedIndexChanged += new System.EventHandler(this.cbxThCurves_SelectedIndexChanged);
            // 
            // btnDeleteThCurve
            // 
            resources.ApplyResources(this.btnDeleteThCurve, "btnDeleteThCurve");
            this.btnDeleteThCurve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnDeleteThCurve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnDeleteThCurve.ForeColor = System.Drawing.Color.White;
            this.btnDeleteThCurve.Name = "btnDeleteThCurve";
            this.btnDeleteThCurve.UseCompatibleTextRendering = true;
            this.btnDeleteThCurve.UseVisualStyleBackColor = false;
            this.btnDeleteThCurve.Click += new System.EventHandler(this.btnDeleteThCurve_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // btnSaveThCurveAs
            // 
            resources.ApplyResources(this.btnSaveThCurveAs, "btnSaveThCurveAs");
            this.btnSaveThCurveAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSaveThCurveAs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSaveThCurveAs.ForeColor = System.Drawing.Color.White;
            this.btnSaveThCurveAs.Name = "btnSaveThCurveAs";
            this.btnSaveThCurveAs.UseCompatibleTextRendering = true;
            this.btnSaveThCurveAs.UseVisualStyleBackColor = false;
            this.btnSaveThCurveAs.Click += new System.EventHandler(this.btnSaveThCurveAs_Click);
            // 
            // btnSaveThCurve
            // 
            resources.ApplyResources(this.btnSaveThCurve, "btnSaveThCurve");
            this.btnSaveThCurve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSaveThCurve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSaveThCurve.ForeColor = System.Drawing.Color.White;
            this.btnSaveThCurve.Name = "btnSaveThCurve";
            this.btnSaveThCurve.UseCompatibleTextRendering = true;
            this.btnSaveThCurve.UseVisualStyleBackColor = false;
            this.btnSaveThCurve.Click += new System.EventHandler(this.btnSaveThCurve_Click);
            // 
            // panelHeader
            // 
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Controls.Add(this.lblCalibrationMessage);
            this.panelHeader.Controls.Add(this.btnCalibrate);
            this.panelHeader.Name = "panelHeader";
            // 
            // lblCalibrationMessage
            // 
            resources.ApplyResources(this.lblCalibrationMessage, "lblCalibrationMessage");
            this.lblCalibrationMessage.ForeColor = System.Drawing.Color.White;
            this.lblCalibrationMessage.Name = "lblCalibrationMessage";
            // 
            // btnCalibrate
            // 
            resources.ApplyResources(this.btnCalibrate, "btnCalibrate");
            this.btnCalibrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCalibrate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCalibrate.ForeColor = System.Drawing.Color.White;
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.UseCompatibleTextRendering = true;
            this.btnCalibrate.UseVisualStyleBackColor = false;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // edtItemName
            // 
            resources.ApplyResources(this.edtItemName, "edtItemName");
            this.edtItemName.Name = "edtItemName";
            // 
            // HandsetCurvePanel
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "HandsetCurvePanel";
            this.panelSelect.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TextBox edtItemName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Trigger;
        private DevExpress.XtraGrid.Columns.GridColumn Result;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private ESRMButton btnSaveThCurveAs;
        private ESRMButton btnSaveThCurve;
        private ESRMButton btnDeleteThCurve;
        private System.Windows.Forms.ComboBox cbxThCurves;
        private ESRMButton btnRAZ;
        private ESRMButton btnCalibrate;
        private System.Windows.Forms.Label lblCalibrationMessage;
        private ESRMButton btnSmooth;
        private ESRMButton btnNewCurve;
    }
}