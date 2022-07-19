namespace ESRM.Win
{
    partial class RecordsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordsForm));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colBestLapRecord = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOk = new ESRM.Win.ESRMButton();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.gridRecords = new DevExpress.XtraGrid.GridControl();
            this.gridViewRecords = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPilot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecordDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.teamLapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelNew = new System.Windows.Forms.Panel();
            this.edtItemName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamLapBindingSource)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // colBestLapRecord
            // 
            this.colBestLapRecord.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colBestLapRecord.AppearanceCell.FontSizeDelta")));
            this.colBestLapRecord.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colBestLapRecord.AppearanceCell.FontStyleDelta")));
            this.colBestLapRecord.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colBestLapRecord.AppearanceCell.GradientMode")));
            this.colBestLapRecord.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colBestLapRecord.AppearanceCell.Image")));
            this.colBestLapRecord.AppearanceCell.Options.UseTextOptions = true;
            this.colBestLapRecord.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colBestLapRecord, "colBestLapRecord");
            this.colBestLapRecord.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBestLapRecord.FieldName = "LapTimeForUI";
            this.colBestLapRecord.Name = "colBestLapRecord";
            this.colBestLapRecord.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelSelect
            // 
            resources.ApplyResources(this.panelSelect, "panelSelect");
            this.panelSelect.Controls.Add(this.gridRecords);
            this.panelSelect.Name = "panelSelect";
            // 
            // gridRecords
            // 
            resources.ApplyResources(this.gridRecords, "gridRecords");
            this.gridRecords.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridRecords.EmbeddedNavigator.AccessibleDescription");
            this.gridRecords.EmbeddedNavigator.AccessibleName = resources.GetString("gridRecords.EmbeddedNavigator.AccessibleName");
            this.gridRecords.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridRecords.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridRecords.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridRecords.EmbeddedNavigator.Anchor")));
            this.gridRecords.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridRecords.EmbeddedNavigator.BackgroundImage")));
            this.gridRecords.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridRecords.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridRecords.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridRecords.EmbeddedNavigator.ImeMode")));
            this.gridRecords.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridRecords.EmbeddedNavigator.Margin")));
            this.gridRecords.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridRecords.EmbeddedNavigator.MaximumSize")));
            this.gridRecords.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridRecords.EmbeddedNavigator.TextLocation")));
            this.gridRecords.EmbeddedNavigator.ToolTip = resources.GetString("gridRecords.EmbeddedNavigator.ToolTip");
            this.gridRecords.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridRecords.EmbeddedNavigator.ToolTipIconType")));
            this.gridRecords.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridRecords.EmbeddedNavigator.ToolTipTitle");
            this.gridRecords.LookAndFeel.SkinName = "Darkroom";
            this.gridRecords.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridRecords.MainView = this.gridViewRecords;
            this.gridRecords.Name = "gridRecords";
            this.gridRecords.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRecords});
            // 
            // gridViewRecords
            // 
            this.gridViewRecords.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridViewRecords.Appearance.HeaderPanel.Font")));
            this.gridViewRecords.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("gridViewRecords.Appearance.HeaderPanel.FontSizeDelta")));
            this.gridViewRecords.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gridViewRecords.Appearance.HeaderPanel.FontStyleDelta")));
            this.gridViewRecords.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gridViewRecords.Appearance.HeaderPanel.GradientMode")));
            this.gridViewRecords.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("gridViewRecords.Appearance.HeaderPanel.Image")));
            this.gridViewRecords.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewRecords.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("gridViewRecords.Appearance.Row.Font")));
            this.gridViewRecords.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("gridViewRecords.Appearance.Row.FontSizeDelta")));
            this.gridViewRecords.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gridViewRecords.Appearance.Row.FontStyleDelta")));
            this.gridViewRecords.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gridViewRecords.Appearance.Row.GradientMode")));
            this.gridViewRecords.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("gridViewRecords.Appearance.Row.Image")));
            this.gridViewRecords.Appearance.Row.Options.UseFont = true;
            this.gridViewRecords.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.gridViewRecords, "gridViewRecords");
            this.gridViewRecords.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPilot,
            this.colBestLapRecord,
            this.colCarName,
            this.colRecordDate,
            this.colActions});
            this.gridViewRecords.DetailHeight = 220;
            gridFormatRule2.ColumnApplyTo = this.colBestLapRecord;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("resource.BackColor")));
            formatConditionRuleValue2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            formatConditionRuleValue2.Appearance.FontSizeDelta = ((int)(resources.GetObject("resource.FontSizeDelta")));
            formatConditionRuleValue2.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("resource.FontStyleDelta")));
            formatConditionRuleValue2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("resource.GradientMode")));
            formatConditionRuleValue2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = true;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridViewRecords.FormatRules.Add(gridFormatRule2);
            this.gridViewRecords.GridControl = this.gridRecords;
            this.gridViewRecords.Name = "gridViewRecords";
            this.gridViewRecords.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewRecords.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewRecords.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewRecords.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gridViewRecords.OptionsFind.AllowFindPanel = false;
            this.gridViewRecords.OptionsFind.ClearFindOnClose = false;
            this.gridViewRecords.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.gridViewRecords.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // colPilot
            // 
            resources.ApplyResources(this.colPilot, "colPilot");
            this.colPilot.FieldName = "PilotName";
            this.colPilot.Name = "colPilot";
            this.colPilot.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colCarName
            // 
            this.colCarName.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colCarName.AppearanceCell.FontSizeDelta")));
            this.colCarName.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colCarName.AppearanceCell.FontStyleDelta")));
            this.colCarName.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCarName.AppearanceCell.GradientMode")));
            this.colCarName.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colCarName.AppearanceCell.Image")));
            this.colCarName.AppearanceCell.Options.UseTextOptions = true;
            this.colCarName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCarName, "colCarName");
            this.colCarName.FieldName = "CarName";
            this.colCarName.Name = "colCarName";
            this.colCarName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colRecordDate
            // 
            this.colRecordDate.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("colRecordDate.AppearanceCell.FontSizeDelta")));
            this.colRecordDate.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("colRecordDate.AppearanceCell.FontStyleDelta")));
            this.colRecordDate.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colRecordDate.AppearanceCell.GradientMode")));
            this.colRecordDate.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("colRecordDate.AppearanceCell.Image")));
            this.colRecordDate.AppearanceCell.Options.UseTextOptions = true;
            this.colRecordDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colRecordDate, "colRecordDate");
            this.colRecordDate.FieldName = "Date";
            this.colRecordDate.Name = "colRecordDate";
            this.colRecordDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colActions
            // 
            resources.ApplyResources(this.colActions, "colActions");
            this.colActions.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colActions.Name = "colActions";
            this.colActions.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // repositoryItemButtonEdit1
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit1, "repositoryItemButtonEdit1");
            resources.ApplyResources(serializableAppearanceObject2, "serializableAppearanceObject2");
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), resources.GetString("repositoryItemButtonEdit1.Buttons1"), ((int)(resources.GetObject("repositoryItemButtonEdit1.Buttons2"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons3"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons4"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("repositoryItemButtonEdit1.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("repositoryItemButtonEdit1.Buttons8"), ((object)(resources.GetObject("repositoryItemButtonEdit1.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("repositoryItemButtonEdit1.Buttons10"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons11"))))});
            this.repositoryItemButtonEdit1.HideSelection = false;
            this.repositoryItemButtonEdit1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemButtonEdit1.Mask.AutoComplete")));
            this.repositoryItemButtonEdit1.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.BeepOnError")));
            this.repositoryItemButtonEdit1.Mask.EditMask = resources.GetString("repositoryItemButtonEdit1.Mask.EditMask");
            this.repositoryItemButtonEdit1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.IgnoreMaskBlank")));
            this.repositoryItemButtonEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemButtonEdit1.Mask.MaskType")));
            this.repositoryItemButtonEdit1.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemButtonEdit1.Mask.PlaceHolder")));
            this.repositoryItemButtonEdit1.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.SaveLiteral")));
            this.repositoryItemButtonEdit1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.ShowPlaceHolders")));
            this.repositoryItemButtonEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // teamLapBindingSource
            // 
            this.teamLapBindingSource.DataSource = typeof(ESRM.Entities.TeamLap);
            // 
            // panelButtons
            // 
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Name = "panelButtons";
            // 
            // panelHeader
            // 
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Name = "panelHeader";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // panelNew
            // 
            resources.ApplyResources(this.panelNew, "panelNew");
            this.panelNew.Name = "panelNew";
            // 
            // edtItemName
            // 
            resources.ApplyResources(this.edtItemName, "edtItemName");
            this.edtItemName.Name = "edtItemName";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // RecordsForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnOk;
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelNew);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelButtons);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecordsForm";
            this.panelSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamLapBindingSource)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRMButton btnOk;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelNew;
        private System.Windows.Forms.TextBox edtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource teamLapBindingSource;
        private DevExpress.XtraGrid.GridControl gridRecords;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecords;
        private DevExpress.XtraGrid.Columns.GridColumn colPilot;
        private DevExpress.XtraGrid.Columns.GridColumn colBestLapRecord;
        private DevExpress.XtraGrid.Columns.GridColumn colCarName;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colActions;
    }
}