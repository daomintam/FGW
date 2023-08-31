using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils.StructuredStorage.Internal;
using DevExpress.Utils.StructuredStorage.Internal.Reader;
using DevExpress.Utils.StructuredStorage.Internal.Writer;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Impinj.OctaneSdk;
using Impinj.RShell;
using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using Org.LLRP.LTK.LLRPV1.Impinj;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FGW
{
    public partial class FinishedGoodsWarehouse : DevExpress.XtraEditors.XtraForm
    {
        private ImpinjReader ImpinjReader;
        private bool isConnected = false; 
        private BindingList<RFIDTag> rfidTagList;
        private HashSet<string> RFIDHashSet;
        private string dailyFolderPath = Path.Combine(Path.GetTempPath(), ".RFIDHashSet");
        public class RFIDTag
        {
            public string RFID { get; set; }
        }
        public FinishedGoodsWarehouse()
        {
            InitializeComponent();
            
        }
        #region Form Load
        private void FinishedGoodsWarehouse_Load(object sender, EventArgs e) {
            rfidTagList = new BindingList<RFIDTag>();
            BindingSource bindingSource = new BindingSource(rfidTagList, null);
            gcRFIDInput.DataSource = bindingSource;
            RFIDHashSet = new HashSet<string>();
            InitializeContextMenu();
            InitializeDaily();
        }
        #endregion

        #region Form Close
        private void FinishedGoodsWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteFinalDataToFile();
            if (ImpinjReader != null)
            {
                ImpinjReader.Stop();
                ImpinjReader.Disconnect();
            }
        }
        #endregion

        #region Initialize
        private void InitializeDaily()
        {
            SaveRFIDHashSetDaily();
            if (!Directory.Exists(dailyFolderPath))
                Directory.CreateDirectory(dailyFolderPath);
            string fileName = Path.Combine(dailyFolderPath, $"RFIDHashSet_{DateTime.Now:yyyy-MM-dd}.txt");
            if (!File.Exists(fileName))
                File.Create(fileName);
            LoadRFIDHashSetFromFile(fileName);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            InitializeReader();
        }
        private void btnConnect_MouseEnter(object sender, EventArgs e)
        {
            if (isConnected)
            {
                btnConnect.Text = "Disconnect";
                btnConnect.Appearance.BackColor = Color.Red;
            }
            else
            {
                btnConnect.Text = "Connect";
                btnConnect.Appearance.BackColor = Color.Chartreuse;
            }
        }

        private void btnConnect_MouseLeave(object sender, EventArgs e)
        {
            if (isConnected)
            {
                btnConnect.Text = "Connected";
                btnConnect.Appearance.BackColor = Color.Chartreuse;
            }
            else
            {
                btnConnect.Text = "Disconnected";
                btnConnect.Appearance.BackColor = Color.SlateGray;
            }
        }
        #region CustomDrawRowIndicator
        private void gvRFIDInput_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (view.DataRowCount != 0 && e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region Custom Draw Footer
        private void gvRFIDInput_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var rect = e.Bounds; rect.X += 10; e.DefaultDraw();
            e.Cache.DrawString(gv.DataRowCount + " rows", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat);
            e.Handled = true;
        }
        #endregion

        #endregion

        #region Connect & Setting RFID Reader
        private void InitializeReader()
        {
            try
            {
                if (!isConnected)
                {
                    isConnected = true;
                    splashScreenManager.ShowWaitForm();
                    ImpinjReader = new ImpinjReader();
                    ImpinjReader.Connect(txtIP.Text.Trim());

                    #region Setting RFID Reader
                    Settings set = ImpinjReader.QuerySettings();
                    set.AutoStart.Mode = AutoStartMode.None;
                    set.AutoStart.GpiPortNumber = 0;
                    set.AutoStart.GpiLevel = false;
                    set.AutoStart.FirstDelayInMs = 0;
                    set.AutoStart.PeriodInMs = 0;
                    set.AutoStart.UtcTimestamp = 0;
                    set.AutoStop.Mode = AutoStopMode.None;
                    set.AutoStop.DurationInMs = 0;
                    set.AutoStop.GpiPortNumber = 0;
                    set.AutoStop.GpiLevel=false;
                    set.AutoStop.Timeout = 0;
                    set.ReaderMode = ReaderMode.MaxThroughput;
                    set.RfMode = 1002;
                    set.SearchMode = SearchMode.DualTarget;
                    set.Session = 1;
                    set.TagPopulationEstimate = 32;
                    set.LowDutyCycle.IsEnabled = false;
                    set.LowDutyCycle.EmptyFieldTimeoutInMs = 500;
                    set.LowDutyCycle.FieldPingIntervalInMs = 200;
                    set.Filters.Mode = TagFilterMode.None;
                    set.Filters.TagFilter1.BitPointer = 32;
                    set.Filters.TagFilter1.BitCount = 0;
                    set.Filters.TagFilter1.MemoryBank = MemoryBank.Epc;
                    set.Filters.TagFilter1.FilterOp = TagFilterOp.Match;
                    set.Filters.TagFilter2.BitPointer = 32;
                    set.Filters.TagFilter2.BitCount = 0;
                    set.Filters.TagFilter2.MemoryBank = MemoryBank.Epc;
                    set.Filters.TagFilter2.FilterOp = TagFilterOp.Match;
                    //set.Filters.TagFilterVerificationMode = true;
                    set.TruncatedReply.IsEnabled = false;
                    set.TruncatedReply.Gen2v2TagsOnly = true;
                    set.TruncatedReply.EpcLengthInWords = 0;
                    set.TruncatedReply.BitPointer = 0;
                    set.Report.IncludeAntennaPortNumber = true;
                    set.Report.IncludeChannel = true;
                    set.Report.IncludeFirstSeenTime = true;
                    set.Report.IncludeLastSeenTime = false;
                    set.Report.IncludePeakRssi = true;
                    set.Report.IncludeSeenCount = false;
                    set.Report.IncludeFastId = false;
                    set.Report.IncludePhaseAngle = false;
                    set.Report.IncludeDopplerFrequency = false;
                    set.Report.IncludeGpsCoordinates = false;
                    set.Report.IncludePcBits = false;
                    set.Report.IncludeCrc = false;
                    set.Report.Mode = ReportMode.Individual;

                    set.Antennas.GetAntenna(1).IsEnabled = true;
                    set.Antennas.GetAntenna(1).PortNumber = 1;
                    set.Antennas.GetAntenna(1).PortName = "Antenna Port 1";
                    set.Antennas.GetAntenna(1).TxPowerInDbm = Double.Parse(txtPower.Text.Trim());
                    set.Antennas.GetAntenna(1).RxSensitivityInDbm = Double.Parse(txtRxSensitivity.Text.Trim());
                    set.Antennas.GetAntenna(1).MaxRxSensitivity = false;
                    set.Antennas.GetAntenna(1).MaxTxPower = false;

                    set.Antennas.GetAntenna(2).IsEnabled = true;
                    set.Antennas.GetAntenna(2).PortNumber = 2;
                    set.Antennas.GetAntenna(2).PortName = "Antenna Port 2";
                    set.Antennas.GetAntenna(2).TxPowerInDbm = Double.Parse(txtPower.Text.Trim());
                    set.Antennas.GetAntenna(2).RxSensitivityInDbm = Double.Parse(txtRxSensitivity.Text.Trim());
                    set.Antennas.GetAntenna(2).MaxRxSensitivity = false;
                    set.Antennas.GetAntenna(2).MaxTxPower = false;

                    set.Antennas.GetAntenna(3).IsEnabled = true;
                    set.Antennas.GetAntenna(3).PortNumber = 3;
                    set.Antennas.GetAntenna(3).PortName = "Antenna Port 3";
                    set.Antennas.GetAntenna(3).TxPowerInDbm = Double.Parse(txtPower.Text.Trim());
                    set.Antennas.GetAntenna(3).RxSensitivityInDbm = Double.Parse(txtRxSensitivity.Text.Trim());
                    set.Antennas.GetAntenna(3).MaxRxSensitivity = false;
                    set.Antennas.GetAntenna(3).MaxTxPower = false;

                    set.Antennas.GetAntenna(4).IsEnabled = true;
                    set.Antennas.GetAntenna(4).PortNumber = 4;
                    set.Antennas.GetAntenna(4).PortName = "Antenna Port 4";
                    set.Antennas.GetAntenna(4).TxPowerInDbm = Double.Parse(txtPower.Text.Trim());
                    set.Antennas.GetAntenna(4).RxSensitivityInDbm = Double.Parse(txtRxSensitivity.Text.Trim());
                    set.Antennas.GetAntenna(4).MaxRxSensitivity = false;
                    set.Antennas.GetAntenna(4).MaxTxPower = false;

                    set.Gpis.GetGpi(1).IsEnabled = false;
                    set.Gpis.GetGpi(1).DebounceInMs = 20;
                    set.Gpis.GetGpi(1).PortNumber = 1;

                    set.Gpis.GetGpi(2).IsEnabled = false;
                    set.Gpis.GetGpi(2).DebounceInMs = 20;
                    set.Gpis.GetGpi(2).PortNumber = 2;

                    set.Gpis.GetGpi(3).IsEnabled = false;
                    set.Gpis.GetGpi(3).DebounceInMs = 20;
                    set.Gpis.GetGpi(3).PortNumber = 3;

                    set.Gpis.GetGpi(4).IsEnabled = false;
                    set.Gpis.GetGpi(4).DebounceInMs = 20;
                    set.Gpis.GetGpi(4).PortNumber = 4;

                    set.Gpos.GetGpo(1).Mode = GpoMode.Normal;
                    set.Gpos.GetGpo(1).GpoPulseDurationMsec = 0;
                    set.Gpos.GetGpo(1).PortNumber = 1;

                    set.Gpos.GetGpo(2).Mode = GpoMode.Normal;
                    set.Gpos.GetGpo(2).GpoPulseDurationMsec = 0;
                    set.Gpos.GetGpo(2).PortNumber = 2;

                    set.Gpos.GetGpo(3).Mode = GpoMode.Normal;
                    set.Gpos.GetGpo(3).GpoPulseDurationMsec = 0;
                    set.Gpos.GetGpo(3).PortNumber = 3;

                    set.Gpos.GetGpo(4).Mode = GpoMode.Normal;
                    set.Gpos.GetGpo(4).GpoPulseDurationMsec = 0;
                    set.Gpos.GetGpo(4).PortNumber = 4;

                    set.Keepalives.Enabled = false;
                    set.Keepalives.PeriodInMs = 0;
                    set.Keepalives.EnableLinkMonitorMode = false;
                    set.Keepalives.LinkDownThreshold = 0;
                    
                    set.HoldReportsOnDisconnect = false;
                    set.SpatialConfig.Mode = SpatialMode.Inventory;
                    set.SpatialConfig.Placement.HeightCm = 400;
                    set.SpatialConfig.Placement.FacilityXLocationCm = 0;
                    set.SpatialConfig.Placement.FacilityYLocationCm = 0;
                    set.SpatialConfig.Placement.OrientationDegrees = 0;
                    set.SpatialConfig.Location.ComputeWindowSeconds = 10;
                    set.SpatialConfig.Location.TagAgeIntervalSeconds = 20;
                    set.SpatialConfig.Location.UpdateIntervalSeconds = 5;
                    set.SpatialConfig.Location.UpdateReportEnabled = true;
                    set.SpatialConfig.Location.EntryReportEnabled = true;
                    set.SpatialConfig.Location.ExitReportEnabled = true;
                    set.SpatialConfig.Location.DiagnosticReportEnabled = false;
                    set.SpatialConfig.Location.MaxTxPower = false;
                    set.SpatialConfig.Location.TxPowerInDbm = 30;
                    set.SpatialConfig.Direction.TagAgeIntervalSeconds = 20;
                    set.SpatialConfig.Direction.UpdateIntervalSeconds = 5;
                    set.SpatialConfig.Direction.UpdateReportEnabled = true;
                    set.SpatialConfig.Direction.EntryReportEnabled = true;
                    set.SpatialConfig.Direction.ExitReportEnabled= true;
                    set.SpatialConfig.Direction.FieldOfView = DirectionFieldOfView.Wide;
                    set.SpatialConfig.Direction.Mode = DirectionMode.HighPerformance;
                    set.SpatialConfig.Direction.TagPopulationLimit = 0;
                    set.SpatialConfig.Direction.DiagnosticReportEnabled= false;
                    set.SpatialConfig.Direction.MaxTxPower = false;
                    set.SpatialConfig.Direction.TxPowerInDbm = 30;
                    #endregion

                    ImpinjReader.SaveSettings();
                    ImpinjReader.ApplySettings(set);

                    ImpinjReader.TagsReported += Reader_TagsReported;
                    ImpinjReader.Start();
                    btnConnect.Text = "Connected";
                    btnConnect.BackColor = Color.Chartreuse;
                    txtIP.Enabled = false;
                    txtPower.Enabled = false;
                    txtRxSensitivity.Enabled = false;
                    splashScreenManager.CloseWaitForm();
                }
                else
                {
                    isConnected = false;
                    btnConnect.Text = "Disconnected";
                    btnConnect.BackColor = Color.Red;
                    txtIP.Enabled = true;
                    txtPower.Enabled = true;
                    txtRxSensitivity.Enabled = true;
                    ImpinjReader.Stop();
                    ImpinjReader.Disconnect();

                }
            }
            catch (Exception ex)
            {
                isConnected=false;
                btnConnect.Text = "Disconnected";
                btnConnect.BackColor = Color.Red;
                splashScreenManager.CloseWaitForm();
                splashScreenManager.Dispose();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Reader Tag Report & Show Tag on Gridview
        private void Reader_TagsReported(ImpinjReader sender, TagReport report)
        {
            foreach (Tag tag in report)
            {
                string epc = tag.Epc.ToString();
                string RFIDTag = epc.Replace(" ","");
                if (!RFIDHashSet.Contains(RFIDTag))
                {
                    AddTagToGridView(RFIDTag);
                    RFIDHashSet.Add(RFIDTag);
                    WriteRFIDTagToFile(RFIDTag);
                }
            }
        }
        private void AddTagToGridView(string RFIDTag)
        {

            if (gcRFIDInput.InvokeRequired)
            {
                gcRFIDInput.Invoke(new Action<string>(AddTagToGridView), RFIDTag);
            }
            else
            {
                gvRFIDInput.AddNewRow();
                gvRFIDInput.SetRowCellValue(gvRFIDInput.FocusedRowHandle, "RFID", RFIDTag);
                gvRFIDInput.UpdateCurrentRow();
                if (gvRFIDInput.DataRowCount >= 10)
                {
                    WriteGridViewDataToFile();
                    currentRowCount = 0;
                    rfidTagList.Clear();
                }
            }
        }
        #endregion

        #region Load - Write Daily File RFIDHashSet 
        private void LoadRFIDHashSetFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                RFIDHashSet = new HashSet<string>(lines);
            }
            else
            {
                RFIDHashSet = new HashSet<string>();
            }
        }
        private void SaveRFIDHashSetToFile(string folderPath)
        {
            string content = string.Join(Environment.NewLine, RFIDHashSet);

            string fileName = Path.Combine(folderPath, $"RFIDHashSet_{DateTime.Now:yyyy-MM-dd}.txt");

            if (!File.Exists(fileName))
                File.WriteAllText(fileName, content, Encoding.UTF8);
            else
                File.AppendAllText(fileName, Environment.NewLine + content, Encoding.UTF8);
        }
        private void SaveRFIDHashSetDaily()
        {
            if (!Directory.Exists(dailyFolderPath))
                Directory.CreateDirectory(dailyFolderPath);
            SaveRFIDHashSetToFile(dailyFolderPath);
        }
        private void WriteRFIDTagToFile(string RFIDTag)
        {
            string fileName = Path.Combine(dailyFolderPath, $"RFIDHashSet_{DateTime.Now:yyyy-MM-dd}.txt");

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(RFIDTag);
            }
        }
        #endregion

        #region Write RFIDTag to Text File

        private int currentRowCount = 0;
        private void WriteGridViewDataToFile()
        {
            try
            {
                if (!System.IO.Directory.Exists(@"D:\RFIDInput"))
                    System.IO.Directory.CreateDirectory(@"D:\RFIDInput");

                string fileName = $"RFID-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.txt";
                string filePath = System.IO.Path.Combine(@"D:\RFIDInput", fileName);

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = gvRFIDInput;
                    for (int i = 0; i < gridView.DataRowCount; i++)
                    {
                        string rfid = gridView.GetRowCellValue(i, "RFID").ToString();
                        writer.WriteLine(rfid);
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void WriteFinalDataToFile()
        {
            if (currentRowCount > 0)
                WriteGridViewDataToFile();
        }
        #endregion

        #region Custom Export Text file RFID Tag on Click
        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenuExport = new ContextMenuStrip();
            ToolStripMenuItem exportToTextMenuItem = new ToolStripMenuItem("Export to Text File");
            exportToTextMenuItem.Click += ExportToTextFile_Click;
            contextMenuExport.Items.Add(exportToTextMenuItem);
            gcRFIDInput.ContextMenuStrip = contextMenuExport;
        }
        private void ExportToTextFile_Click(object sender, EventArgs e)
        {
            string exportFolder = @"D:\RFIDInputExportClick";
            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);
            string fileNameExport = "RFIDInput_Export_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
            string filePath = Path.Combine(exportFolder, fileNameExport);
            ExportDataToFile(filePath);
        }
        private void ExportDataToFile(string filePath)
        {
            List<string> dataToExport = new List<string>();
            GridView gridView = gvRFIDInput;
            if (gridView.DataRowCount > 0)
            {
                for (int rowHandle = 0; rowHandle < gridView.DataRowCount; rowHandle++)
                {
                    string rfid = gridView.GetRowCellValue(rowHandle, "RFID").ToString();
                    dataToExport.Add(rfid);

                }
                File.WriteAllLines(filePath, dataToExport);
                toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            }
        }
        #endregion

        
    }
}
