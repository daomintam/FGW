
namespace FGW
{
    partial class FinishedGoodsWarehouse
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
            this.gcRFIDInput = new DevExpress.XtraGrid.GridControl();
            this.gvRFIDInput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtRxSensitivity = new DevExpress.XtraEditors.TextEdit();
            this.txtPower = new DevExpress.XtraEditors.TextEdit();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.txtIP = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FGW.WaitForm), true, true);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcRFIDInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRFIDInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRxSensitivity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPower.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcRFIDInput
            // 
            this.gcRFIDInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRFIDInput.Location = new System.Drawing.Point(2, 166);
            this.gcRFIDInput.MainView = this.gvRFIDInput;
            this.gcRFIDInput.Name = "gcRFIDInput";
            this.gcRFIDInput.Size = new System.Drawing.Size(289, 331);
            this.gcRFIDInput.TabIndex = 0;
            this.gcRFIDInput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRFIDInput});
            // 
            // gvRFIDInput
            // 
            this.gvRFIDInput.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvRFIDInput.Appearance.FocusedRow.Options.UseFont = true;
            this.gvRFIDInput.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.gvRFIDInput.Appearance.FooterPanel.Options.UseFont = true;
            this.gvRFIDInput.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRFIDInput.Appearance.GroupFooter.Options.UseFont = true;
            this.gvRFIDInput.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvRFIDInput.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvRFIDInput.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gvRFIDInput.Appearance.ViewCaption.Options.UseFont = true;
            this.gvRFIDInput.ColumnPanelRowHeight = 30;
            this.gvRFIDInput.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RFID});
            this.gvRFIDInput.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvRFIDInput.GridControl = this.gcRFIDInput;
            this.gvRFIDInput.GroupRowHeight = 25;
            this.gvRFIDInput.IndicatorWidth = 50;
            this.gvRFIDInput.Name = "gvRFIDInput";
            this.gvRFIDInput.OptionsBehavior.Editable = false;
            this.gvRFIDInput.OptionsNavigation.AutoFocusNewRow = true;
            this.gvRFIDInput.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvRFIDInput.OptionsSelection.MultiSelect = true;
            this.gvRFIDInput.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvRFIDInput.OptionsView.ShowFooter = true;
            this.gvRFIDInput.OptionsView.ShowGroupPanel = false;
            this.gvRFIDInput.OptionsView.ShowViewCaption = true;
            this.gvRFIDInput.RowHeight = 28;
            this.gvRFIDInput.ViewCaption = "RFID Input Data";
            this.gvRFIDInput.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvRFIDInput_CustomDrawRowIndicator);
            this.gvRFIDInput.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvRFIDInput_CustomDrawFooter);
            // 
            // RFID
            // 
            this.RFID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFID.AppearanceCell.Options.UseFont = true;
            this.RFID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFID.AppearanceHeader.Options.UseFont = true;
            this.RFID.Caption = "RFID";
            this.RFID.FieldName = "RFID";
            this.RFID.Name = "RFID";
            this.RFID.Visible = true;
            this.RFID.VisibleIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(300, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(713, 527);
            this.gcData.TabIndex = 1;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.ColumnPanelRowHeight = 30;
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsView.ShowFooter = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.RowHeight = 25;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.AutoSize = true;
            this.layoutControl1.Controls.Add(this.txtRxSensitivity);
            this.layoutControl1.Controls.Add(this.txtPower);
            this.layoutControl1.Controls.Add(this.btnConnect);
            this.layoutControl1.Controls.Add(this.txtIP);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(830, 0, 650, 400);
            this.layoutControl1.OptionsView.AlwaysScrollActiveControlIntoView = false;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(289, 164);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "RFID Reader Setting";
            // 
            // txtRxSensitivity
            // 
            this.txtRxSensitivity.EditValue = "-80";
            this.txtRxSensitivity.Location = new System.Drawing.Point(230, 41);
            this.txtRxSensitivity.Name = "txtRxSensitivity";
            this.txtRxSensitivity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtRxSensitivity.Properties.Appearance.Options.UseFont = true;
            this.txtRxSensitivity.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRxSensitivity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRxSensitivity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRxSensitivity.Size = new System.Drawing.Size(54, 22);
            this.txtRxSensitivity.StyleController = this.layoutControl1;
            this.txtRxSensitivity.TabIndex = 7;
            // 
            // txtPower
            // 
            this.txtPower.EditValue = "15.5";
            this.txtPower.Location = new System.Drawing.Point(58, 41);
            this.txtPower.Name = "txtPower";
            this.txtPower.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtPower.Properties.Appearance.Options.UseFont = true;
            this.txtPower.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPower.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPower.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtPower.Size = new System.Drawing.Size(52, 22);
            this.txtPower.StyleController = this.layoutControl1;
            this.txtPower.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.btnConnect.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Appearance.Options.UseBackColor = true;
            this.btnConnect.Appearance.Options.UseFont = true;
            this.btnConnect.Location = new System.Drawing.Point(20, 88);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnConnect.Size = new System.Drawing.Size(249, 56);
            this.btnConnect.StyleController = this.layoutControl1;
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Disconnected";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.MouseEnter += new System.EventHandler(this.btnConnect_MouseEnter);
            this.btnConnect.MouseLeave += new System.EventHandler(this.btnConnect_MouseLeave);
            // 
            // txtIP
            // 
            this.txtIP.EditValue = "192.168.1.91";
            this.txtIP.Location = new System.Drawing.Point(32, 5);
            this.txtIP.Name = "txtIP";
            this.txtIP.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Properties.Appearance.Options.UseFont = true;
            this.txtIP.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIP.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtIP.Size = new System.Drawing.Size(252, 26);
            this.txtIP.StyleController = this.layoutControl1;
            this.txtIP.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(289, 164);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem2.Control = this.btnConnect;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.layoutControlItem2.Size = new System.Drawing.Size(289, 96);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem1.Control = this.txtIP;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(289, 36);
            this.layoutControlItem1.Text = "IP:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(22, 20);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtRxSensitivity;
            this.layoutControlItem4.Location = new System.Drawing.Point(115, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(174, 32);
            this.layoutControlItem4.Text = "Rx Sensitivity";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(105, 18);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtPower;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(115, 32);
            this.layoutControlItem3.Text = "Power";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 18);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcRFIDInput);
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(293, 499);
            this.panelControl1.TabIndex = 6;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel
            // 
            this.dockPanel.Appearance.Options.UseTextOptions = true;
            this.dockPanel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dockPanel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dockPanel.Controls.Add(this.dockPanel1_Container);
            this.dockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel.ID = new System.Guid("c7d11972-5d63-4299-88aa-338a98b187c3");
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.OriginalSize = new System.Drawing.Size(300, 200);
            this.dockPanel.Size = new System.Drawing.Size(300, 527);
            this.dockPanel.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Left;
            this.dockPanel.Text = "RFID Reader Setting";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(293, 499);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "c3d6973a-b943-40aa-a1c2-6e6c6c0e2a6b";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("153f18ae-6419-4c31-8334-34f5eb8baf30", null, "Notification", "The file has been saved to the path D:\\RFIDInputExportClick", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.SMS, DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Default, DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Text01)});
            // 
            // FinishedGoodsWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 527);
            this.Controls.Add(this.gcData);
            this.Controls.Add(this.dockPanel);
            this.IconOptions.Image = global::FGW.Properties.Resources.fgw;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.LookAndFeel.TouchScaleFactor = 1F;
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FinishedGoodsWarehouse";
            this.Text = "Finished Goods Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinishedGoodsWarehouse_FormClosing);
            this.Load += new System.EventHandler(this.FinishedGoodsWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcRFIDInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRFIDInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRxSensitivity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPower.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcRFIDInput;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRFIDInput;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtIP;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn RFID;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraEditors.TextEdit txtRxSensitivity;
        private DevExpress.XtraEditors.TextEdit txtPower;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}

