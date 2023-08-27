using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using Impinj.OctaneSdk;
namespace FGW
{
    public partial class FinishedGoodsWarehouse : DevExpress.XtraEditors.XtraForm
    {
        private ImpinjReader ImpinjReader;
        int RowCount;
        private bool isConnected = false;
        private Timer timerAddRandomTags; 
        private BindingList<RFIDTag> rfidTagList; 
        public class RFIDTag
        {
            public string RFID { get; set; }
        }
        public FinishedGoodsWarehouse()
        {
            InitializeComponent();
            RowCount = 0;
            btnConnect.Text = "Connect";
            btnConnect.BackColor = Color.Transparent; 
            rfidTagList = new BindingList<RFIDTag>();
            BindingSource bindingSource = new BindingSource(rfidTagList, null); 
            gcRFIDInput.DataSource = bindingSource;
        }
        private void FinishedGoodsWarehouse_Load(object sender, EventArgs e)
        {
            dockPanel.CustomButtonChecked += DockPanel_CustomButtonChecked;
        }


        private void DockPanel_CustomButtonChecked(object sender, ButtonEventArgs e)
        {
            timerAddRandomTags = new Timer();
            timerAddRandomTags.Interval = 5000;
            timerAddRandomTags.Tick += TimerAddRandomTags_Tick;
            timerAddRandomTags.Start();
        }

        private void FinishedGoodsWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteFinalDataToFile();
            if (ImpinjReader != null)
            {
                ImpinjReader.Stop();
                ImpinjReader.Disconnect();
            }
            
            if (timerAddRandomTags != null)
            {
                timerAddRandomTags.Stop();
                timerAddRandomTags.Dispose();
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            InitializeReader();
            
        }
        private void InitializeReader()
        {
            if (!isConnected && ImpinjReader!=null)
            {
                isConnected = true;
                try
                {
                    splashScreenManager.ShowWaitForm();
                    ImpinjReader = new ImpinjReader();
                    ImpinjReader.Connect("192.168.1.91");
                    ImpinjReader.TagsReported += Reader_TagsReported;
                    ImpinjReader.ApplyDefaultSettings();
                    ImpinjReader.Start();
                    btnConnect.Text = "Connected";
                    btnConnect.BackColor = Color.Chartreuse;
                    splashScreenManager.CloseWaitForm();

                }
                catch (Exception ex)
                {
                    splashScreenManager.CloseWaitForm();
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                isConnected = false;
                btnConnect.Text = "Not connected";
                btnConnect.BackColor = Color.Red;
            }
            

        }

        private void Reader_TagsReported(ImpinjReader sender, TagReport report)
        {
            foreach (Tag tag in report)
            {
                string RFIDTag = tag.Epc.ToString();
                if (!TagExistsInGridView(RFIDTag)) 
                {
                    AddTagToGridView(RFIDTag);
                }
            }
        }
        //private void AddTagToGridView(string RFIDTag)
        //{
        //    DevExpress.XtraGrid.Views.Grid.GridView view = gcRFIDInput.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
        //    view.AddNewRow();
        //    view.SetRowCellValue(RowCount, "RFID", RFIDTag);
        //    view.UpdateCurrentRow();
        //    RowCount++;
        //}
        private void AddTagToGridView(string RFIDTag)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = gcRFIDInput.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            view.AddNewRow();
            int newRowHandle = view.FocusedRowHandle;
            view.SetRowCellValue(newRowHandle, "RFID", RFIDTag);
            view.UpdateCurrentRow();
        }
        private bool TagExistsInGridView(string RFIDTag)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = gcRFIDInput.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            for (int i = 0; i < view.RowCount; i++)
            {
                string RFID = view.GetRowCellValue(i, "RFID").ToString();
                if (RFID == RFIDTag)
                {
                    return true;
                }
            }
            return false;
        }
        
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
        
        private void TimerAddRandomTags_Tick(object sender, EventArgs e)
        {
            lock (lockObject)
            {
                int numberOfTagsToAdd = new Random().Next(1, 4);
                gcRFIDInput.UseWaitCursor = true;
                for (int i = 0; i < numberOfTagsToAdd; i++)
                {
                    string randomRFIDTag = Guid.NewGuid().ToString();
                    if (!TagExistsInGridView(randomRFIDTag))
                    {
                        if (currentRowCount < 100)
                        {
                            currentRowCount++;
                            dataToWriteToFile.Add(randomRFIDTag);
                        }
                        else dataToWriteToFile.Add(randomRFIDTag);
                        //AddTagToGridView(randomRFIDTag);
                    }
                }
                gcRFIDInput.UseWaitCursor = false;
                if (gvRFIDInput.RowCount >= 100)
                {
                    WriteGridViewDataToFile();
                    currentRowCount = 0;
                    rfidTagList.Clear();
                }
                if (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0 && dataToWriteToFile.Count>0)
                {
                    WriteFinalDataToFile();
                }
            }
        }

        private object lockObject = new object();
        private int currentRowCount = 0; 
        private List<string> dataToWriteToFile = new List<string>();
        private void WriteGridViewDataToFile()
        {
            if (dataToWriteToFile.Count > 0)
            {
                try
                {
                    string folderPath = @"D:\RFIDInput";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    string currentDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string fileName = $"RFID-{currentDateTime}.txt";
                    string filePath = System.IO.Path.Combine(folderPath, fileName);

                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView gridView = gvRFIDInput;
                        for (int i = 0; i < gridView.RowCount; i++)
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
                dataToWriteToFile.Clear();
            }    
        }

        private void WriteFinalDataToFile()
        {
            if (currentRowCount > 0)
            {
                WriteGridViewDataToFile();
            }
        }
        private void InsertRandomData_Click(object sender, EventArgs e)
        {
            timerAddRandomTags = new Timer();
            timerAddRandomTags.Interval = 5000; 
            timerAddRandomTags.Tick += TimerAddRandomTags_Tick;
            timerAddRandomTags.Start();
        }
    }
}
