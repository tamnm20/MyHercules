using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Management;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;
using System.Resources;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;


namespace Myhercules
{

    public partial class Form1 : Form
    {
        //List<string> recBufList = new List<string>();
        CultureInfo culture;
        readonly ResourceManager rm = new ResourceManager("Myhercules.lang.MyResource", typeof(Form1).Assembly);
        private string lastFilePath; // Lưu đường dẫn tập tin cuối cùng được chọn
        private bool Isuart;
        private bool IsFR = true;
        private bool DisCRLF = false;
        private bool benchTestStop = false;
        string update_log="";
        private bool TX_block_Success = false;
        private bool TX_check_Success = false;
        private byte TX_check_Verify = 0xff;
        private byte updateStatus;
        uint addDevice = 0x20;
        bool radarFound = false;

        #region UDP Variables
        private UdpClient udpClient = null;
        private CancellationTokenSource udpCts = null;
        private bool isUdpListening = false;
        #endregion
        #region FT260 config

        IntPtr ft260handle = new IntPtr();
        FT260_STATUS Status = 0;

        bool DLL_Loaded = false;

        private enum FT260_STATUS
        {
            FT260_OK,
            FT260_INVALID_HANDLE,
            FT260_DEVICE_NOT_FOUND,
            FT260_DEVICE_NOT_OPENED,
            FT260_DEVICE_OPEN_FAIL,
            FT260_DEVICE_CLOSE_FAIL,
            FT260_INCORRECT_INTERFACE,
            FT260_INCORRECT_CHIP_MODE,
            FT260_DEVICE_MANAGER_ERROR,
            FT260_IO_ERROR,
            FT260_INVALID_PARAMETER,
            FT260_NULL_BUFFER_POINTER,
            FT260_BUFFER_SIZE_ERROR,
            FT260_UART_SET_FAIL,
            FT260_RX_NO_DATA,
            FT260_GPIO_WRONG_DIRECTION,
            FT260_INVALID_DEVICE,
            FT260_INVALID_OPEN_DRAIN_SET,
            FT260_INVALID_OPEN_DRAIN_RESET,
            FT260_I2C_READ_FAIL,
            FT260_OTHER_ERROR
        };

        private enum FT260_GPIO2_Pin
        {
            FT260_GPIO2_GPIO = 0,
            FT260_GPIO2_SUSPOUT = 1,
            FT260_GPIO2_PWREN = 2,
            FT260_GPIO2_TX_LED = 4
        };

        private enum FT260_GPIOA_Pin
        {
            FT260_GPIOA_GPIO = 0,
            FT260_GPIOA_TX_ACTIVE = 3,
            FT260_GPIOA_TX_LED = 4
        };

        private enum FT260_GPIOG_Pin
        {
            FT260_GPIOG_GPIO = 0,
            FT260_GPIOG_PWREN = 2,
            FT260_GPIOG_RX_LED = 5,
            FT260_GPIOG_BCD_DET = 6
        };

        private enum FT260_Clock_Rate
        {
            FT260_SYS_CLK_12M = 0,
            FT260_SYS_CLK_24M,
            FT260_SYS_CLK_48M,
        };

        private enum FT260_Interrupt_Trigger_Type
        {
            FT260_INTR_RISING_EDGE = 0,
            FT260_INTR_LEVEL_HIGH,
            FT260_INTR_FALLING_EDGE,
            FT260_INTR_LEVEL_LOW
        };

        private enum FT260_Interrupt_Level_Time_Delay
        {
            FT260_INTR_DELY_1MS = 1,
            FT260_INTR_DELY_5MS,
            FT260_INTR_DELY_30MS
        };

        private enum FT260_Suspend_Out_Polarity
        {
            FT260_SUSPEND_OUT_LEVEL_HIGH = 0,
            FT260_SUSPEND_OUT_LEVEL_LOW
        };

        private enum FT260_UART_Mode
        {
            FT260_UART_OFF = 0,
            FT260_UART_RTS_CTS_MODE,        // hardware flow control RTS, CTS mode
            FT260_UART_DTR_DSR_MODE,        // hardware flow control DTR, DSR mode
            FT260_UART_XON_XOFF_MODE,       // software flow control mode
            FT260_UART_NO_FLOW_CTRL_MODE    // no flow control mode
        };

        private enum FT260_Data_Bit
        {
            FT260_DATA_BIT_7 = 7,
            FT260_DATA_BIT_8 = 8
        };

        private enum FT260_Stop_Bit
        {
            FT260_STOP_BITS_1 = 0,
            FT260_STOP_BITS_2 = 2
        };

        private enum FT260_Parity
        {
            FT260_PARITY_NONE = 0,
            FT260_PARITY_ODD,
            FT260_PARITY_EVEN,
            FT260_PARITY_MARK,
            FT260_PARITY_SPACE
        };

        private enum FT260_RI_Wakeup_Type
        {
            FT260_RI_WAKEUP_RISING_EDGE = 0,
            FT260_RI_WAKEUP_FALLING_EDGE,
        };

        //struct FT260_GPIO_Report
        //{
        //    WORD value;       // GPIO0~5 values
        //    WORD dir;         // GPIO0~5 directions
        //    WORD gpioN_value; // GPIOA~H values
        //    WORD gpioN_dir;   // GPIOA~H directions
        //};

        private enum FT260_GPIO_DIR
        {
            FT260_GPIO_IN = 0,
            FT260_GPIO_OUT
        };

        private enum FT260_GPIO
        {
            FT260_GPIO_0 = 1 << 0,
            FT260_GPIO_1 = 1 << 1,
            FT260_GPIO_2 = 1 << 2,
            FT260_GPIO_3 = 1 << 3,
            FT260_GPIO_4 = 1 << 4,
            FT260_GPIO_5 = 1 << 5,
            FT260_GPIO_A = 1 << 6,
            FT260_GPIO_B = 1 << 7,
            FT260_GPIO_C = 1 << 8,
            FT260_GPIO_D = 1 << 9,
            FT260_GPIO_E = 1 << 10,
            FT260_GPIO_F = 1 << 11,
            FT260_GPIO_G = 1 << 12,
            FT260_GPIO_H = 1 << 13
        };

        private enum FT260_I2C_FLAG
        {
            FT260_I2C_NONE = 0,
            FT260_I2C_START = 0x02,
            FT260_I2C_REPEATED_START = 0x03,
            FT260_I2C_STOP = 0x04,
            FT260_I2C_START_AND_STOP = 0x06
        };

        private enum FT260_PARAM_1
        {
            FT260_DS_CTL0 = 0x50,
            FT260_DS_CTL3 = 0x51,
            FT260_DS_CTL4 = 0x52,
            FT260_SR_CTL0 = 0x53,
            FT260_GPIO_PULL_UP = 0x61,
            FT260_GPIO_OPEN_DRAIN = 0x62,
            FT260_GPIO_PULL_DOWN = 0x63,
            FT260_GPIO_GPIO_SLEW_RATE = 0x65
        };

        private enum FT260_PARAM_2
        {
            FT260_GPIO_GROUP_SUSPEND_0 = 0x10, // for gpio 0 ~ gpio 5
            FT260_GPIO_GROUP_SUSPEND_A = 0x11, // for gpio A ~ gpio H
            FT260_GPIO_DRIVE_STRENGTH = 0x64
        };

        // LIBFT260_API FT260_STATUS WINAPI FT260_CreateDeviceList(LPDWORD lpdwNumDevs);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_CreateDeviceList(ref UInt32 lpdwNumDevs);

        // LIBFT260_API FT260_STATUS WINAPI FT260_OpenByVidPid(WORD vid, WORD pid, DWORD deviceIndex, FT260_HANDLE* pFt260Handle);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_OpenByVidPid(ushort vid, ushort pid, UInt32 deviceIndex, ref IntPtr ft260handle);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Init(FT260_HANDLE ft260Handle, uint32 kbps);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Init(IntPtr ft260Handle, UInt32 kbps);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Read(FT260_HANDLE ft260Handle, uint8 deviceAddress, FT260_I2C_FLAG flag, LPVOID lpBuffer, DWORD dwBytesToRead, LPDWORD lpdwBytesReturned, timeout);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Read(IntPtr ft260Handle, uint deviceAddress, FT260_I2C_FLAG flag, System.IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned, UInt32 Timeout);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Write(FT260_HANDLE ft260Handle, uint8 deviceAddress, FT260_I2C_FLAG flag, LPVOID lpBuffer, DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Write(IntPtr ft260Handle, uint deviceAddress, FT260_I2C_FLAG flag, System.IntPtr lpBuffer, UInt32 dwBytesToWrite, ref UInt32 lpdwBytesWritten);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_GetStatus(FT260_HANDLE ft260Handle, uint8* status);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_GetStatus(IntPtr ft260Handle, ref byte status);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Reset(FT260_HANDLE ft260Handle);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Reset(IntPtr ft260Handle);

        //LIBFT260_API FT260_STATUS WINAPI FT260_GPIO_SetDir(FT260_HANDLE ft260Handle, WORD pinNum, BYTE dir);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_GPIO_SetDir(IntPtr ft260Handle, FT260_GPIO pinNum, byte dir);

        // LIBFT260_API FT260_STATUS WINAPI FT260_GPIO_Read(FT260_HANDLE ft260Handle, WORD pinNum, BYTE* pValue);

        //LIBFT260_API FT260_STATUS WINAPI FT260_GPIO_Write(FT260_HANDLE ft260Handle, WORD pinNum, BYTE value);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_GPIO_Write(IntPtr ft260Handle, FT260_GPIO pinNum, byte value);

        //LIBFT260_API FT260_STATUS WINAPI FT260_Close(FT260_HANDLE ft260Handle);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_Close(IntPtr ft260Handle);
        #endregion
        public enum result
        {
            Pass,
            Fail,
            Unknow
        }
        public result TestResult = result.Unknow;
        public enum testcase
        {
            //free,
            FSERInit,
            RSERInit,
            DESInit,
            SERLinkInit,
            DESSleep,
            FRRecovery,
            RRadarRecovery,
            DESWakeup,
            SERControlerWakeup,
            DESControlerWakeup,
            FLEDSetting,
            FLEDSettingOff,
            FRadarSleep,
            FRadarStandby,
            FRadarWorking00,
            FRadarWorking03,
            FSettingOperation,
            FSettingParameter,
            FSERSetting,
            RLEDSetting,
            RLEDSettingOff,
            RRadarSleep,
            RRadarStandby,
            RRadarWorking00,
            RRadarWorking03,
            RSetingOperation,
            RSettingParameter,
            RSERSetting,
            GSensorSetting,
            HighPassFilter,
            ThresholdSetting,
            InteruptGsensorOff,
            InteruptGsensorOn,
            WakeupEventcheck,
            ADCSetting1,
            ADCSetting2,
            ADCSetting3,
            ImageSleep,
            Image30fps,
            ImageWakeup,
            Image10fps,
            Reset,
            ReadInfo,
            InputVideo,
            Radaroff,
            Radaron,
            ModeParking1,
            ModeParking2,
            ModeSleep1,
            ModeSleep2,
            ModeWakeup1,
            ModeWakeup2,
            SettingRadar,
            SettingDistance,
            CheckConnection,
            CheckRadar,
            CheckFWVersion,
            CheckUpdateFW,
            DetectDistance,
            ReadRadar,
            Bench,
            RadarReset,
            ScanI2C1,
            ScanI2C2,
            updateHW,









            UpdateFW = 100,
            Verify,
            Scan,
            free = 0x255,

        }
        public static testcase testItem = testcase.free;

        public Form1()
        {
            InitializeComponent();
            I2C_dtgv.DataSource = TestBenchList;

            // Tạo một cột dạng button
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "send";
            btnColumn.HeaderText = "Send";
            btnColumn.Text = "Click";
            btnColumn.UseColumnTextForButtonValue = true;
            btnColumn.Width = 40;
            I2C_dtgv.Columns.Add(btnColumn);
            I2C_dtgv.Columns["num"].Width = 30;
            I2C_dtgv.Columns["num"].HeaderText = "No";
            I2C_dtgv.Columns["readWrite"].Width = 40;
            I2C_dtgv.Columns["readWrite"].HeaderText = "Read/ Write";
            I2C_dtgv.Columns["size"].Width = 50;
            I2C_dtgv.Columns["i2C_add"].Width = 50;
            I2C_dtgv.Columns["i2C_add"].HeaderText = "I2C Add";
            I2C_dtgv.Columns["reg_size"].Width = 50;
            I2C_dtgv.Columns["reg_size"].HeaderText = "Reg size";
            I2C_dtgv.Columns["reg_add"].Width = 50;
            I2C_dtgv.Columns["reg_add"].HeaderText = "Reg Add";
            I2C_dtgv.Columns["note"].Width = I2C_dtgv.Width / 4;
            I2C_dtgv.Columns["data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            I2C_dtgv.Columns["time"].Width = 40;
        }

        #region Form_load
        private void Form1_Load(object sender, EventArgs e)
        {
            // WESTERN European: Ma hoa ca 8 bit (ASCII mo rong)
            serialPort.Encoding = Encoding.GetEncoding(28591);
            //serialPort.Encoding = Encoding.ASCII;
            serialPort.Handshake = Handshake.None;   // như TeraTerm: không dùng HW/SW flow control
            serialPort.DtrEnable = true;             // assert DTR
            serialPort.RtsEnable = true;            // assert RTS
            serialPort.ReceivedBytesThreshold = 1;
            serialPort.NewLine = "\r";
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
            //Load cấu hình UART
            //SetLanguage("en-US");
            //Lay va sap xep danh sach COM
            ScanCOM();
            //Tim kiem COM ket noi có con trong danh sach khong
            bool found = false;
            foreach (string str in he_cbCOM.Items)
            {
                if (str == Properties.Settings.Default.PortName)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                he_cbCOM.Text = Properties.Settings.Default.PortName;
            }
            he_cbBaud.Text = Properties.Settings.Default.Baud;
            he_cbDataSize.Text = Properties.Settings.Default.DataSize;
            he_cbParity.Text = Properties.Settings.Default.Parity;
            he_cbStopBit.Text = Properties.Settings.Default.Stopbit.ToString();
            cb_Language.Text = Properties.Settings.Default.Language;

            //Luu vi tri, trang thai tu dong ket noi
            this.Location = new Point(Properties.Settings.Default.Left, Properties.Settings.Default.Top);
            this.Location = new Point(0,0);
            //Load cac thong so
            he_chxAutoConnect.Checked = Properties.Settings.Default.AutoConnect;
            he_cbCR.Checked = Properties.Settings.Default.CRLF;
            he_cbAutoScroll.Checked = Properties.Settings.Default.At_Scroll;
            he_cbDisplay.Text = Properties.Settings.Default.Display;
            he_cbShowTime.Checked = Properties.Settings.Default.Sh_time;

            he_dtgvSend.Rows[0].Cells[1].Value = false;
            he_dtgvSend.Rows[0].Cells[2].Value = false;
            he_dtgvSend.Rows[0].Cells[3].Value = true;
            buttonBrowse.Enabled = false;
            if (Properties.Settings.Default.Device == "uart")
            {
                Isuart = true;
                radioButtonUART.Checked = true;
            }
            else
            {
                Isuart = false;
                radioButtonI2C.Checked = true;
            }
            if (Properties.Settings.Default.AutoConnect)
            {
                he_btOpen_Click(null, null);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            StopUdpListener();
            SaveSetting();
        }
        #endregion

        #region Multi Language
        private void cb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Language.SelectedIndex == 0)
            {
                SetLanguage("ko-KR");

            }
            else if (cb_Language.SelectedIndex == 1)
            {
                SetLanguage("vi-VN");
            }
            else
            {
                SetLanguage("en-US");
            }
            Properties.Settings.Default.Language = cb_Language.Text;
            Properties.Settings.Default.Save();
        }

        private void SetLanguage(string cultureName)
        {
            culture = CultureInfo.CreateSpecificCulture(cultureName);
            groupBoxCOM.Text = rm.GetString("groupBox3", culture);
            he_btOpen.Text = rm.GetString("he_btOpen", culture);
            he_cbAutoScroll.Text = rm.GetString("he_cbAutoScroll", culture);
            he_cbShowTime.Text = rm.GetString("he_cbShowTime", culture);
            he_chxAutoConnect.Text = rm.GetString("he_chxAutoConnect", culture);
            label2.Text = rm.GetString("label2", culture);
            label3.Text = rm.GetString("label3", culture);
            label7.Text = rm.GetString("label7", culture);
            label10.Text = rm.GetString("label10", culture);
            linkLabel1.Text = rm.GetString("linkLabel1", culture);
            CT_tabPage.Text = rm.GetString("tabControl1", culture);
            tabPageConfig.Text = rm.GetString("tabPage2", culture);
            he_btClearAll.Text = rm.GetString("he_btClearAll", culture);
        }
        private void SaveSetting()
        {
            Properties.Settings.Default.PortName = he_cbCOM.Text;
            Properties.Settings.Default.Baud = he_cbBaud.Text;
            Properties.Settings.Default.DataSize = he_cbDataSize.Text;
            Properties.Settings.Default.Parity = he_cbParity.Text;
            Properties.Settings.Default.Stopbit = Convert.ToByte(he_cbStopBit.Text);
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.AutoConnect = he_chxAutoConnect.Checked;
            Properties.Settings.Default.CRLF = he_cbCR.Checked;
            Properties.Settings.Default.Sh_time = he_cbShowTime.Checked;
            Properties.Settings.Default.At_Scroll = he_cbAutoScroll.Checked;
            Properties.Settings.Default.Display = he_cbDisplay.Text;
            if (Isuart)
            {
                Properties.Settings.Default.Device = "uart";
            }
            else
            {
                Properties.Settings.Default.Device = "i2c";
            }
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Receive data

        private Queue<string> recBufQueue = new Queue<string>();
        private const int MAX_QUEUE_SIZE = 100;  // Giới hạn số phần tử tối đa trong queue
        private const int MAX_PROCESS_COUNT = 5; // Số gói tin tối đa xử lý mỗi lần tick
        string buffer;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (recBufQueue)
            {
                while (serialPort.IsOpen && serialPort.BytesToRead > 0)
                {
                    string receivedData = serialPort.ReadExisting();
                    buffer += receivedData;
                    if (testItem != testcase.UpdateFW)
                    {
                        if (recBufQueue.Count < MAX_QUEUE_SIZE) // Giới hạn số lượng dữ liệu trong hàng đợi
                        {
                            recBufQueue.Enqueue(receivedData);
                            he_State_rx.BackColor = Color.Yellow;
                        }
                    }
                    int index = buffer.IndexOf('\n');  // Kiểm tra có dấu xuống dòng không
                    while (index >= 0)
                    {
                        string line = buffer.Substring(0, index + 1);  // Lấy dòng hoàn chỉnh
                        buffer = buffer.Substring(index + 1);         // Cắt bỏ phần đã xử lý

                        ProcessLine(line.Trim());  // Xử lý dữ liệu
                        index = buffer.IndexOf('\n');  // Kiểm tra tiếp
                    }
                }
            }
        }

        // Timer hiển thị dữ liệu lên UI
        private void timerDP_Tick(object sender, EventArgs e)
        {
            int processCount = 0;
            string dataToDisplay = "";

            lock (recBufQueue)
            {
                while (recBufQueue.Count > 0 && processCount < MAX_PROCESS_COUNT)
                {
                    dataToDisplay += recBufQueue.Dequeue();  // Gộp dữ liệu thành chuỗi
                    processCount++;
                }
            }

            // Chỉ cập nhật UI nếu có dữ liệu mới
            if (!string.IsNullOrEmpty(dataToDisplay))
            {
                serialPortReceiver(dataToDisplay);
            }
            if (!serialPort.IsOpen && he_btOpen.Text == "Close")
            {

                he_tbRxTx.SelectionColor = Color.Red;
                he_State_Connect.BackColor = Color.Red;
                he_tbRxTx.AppendText("\nSerial port " + serialPort.PortName + " closed\r\n");
                // Cập nhật giao diện khi cổng Serial đóng
                he_btOpen.Text = "Open";
                he_cbCOM.Enabled = true;
                he_cbBaud.Enabled = true;
                he_cbDataSize.Enabled = true;
                he_cbParity.Enabled = true;
                he_cbStopBit.Enabled = true;
                buttonBrowse.Enabled = false;
                he_cbCOM.Items.Clear();
                serialPort.Close();
            }

            he_State_tx.BackColor = Color.Transparent;
            he_State_rx.BackColor = Color.Transparent;
            if (testItem == testcase.UpdateFW)
            {
                progressBarUpdate.Value = Update_progress;
                TimeSpan delta = DateTime.Now - globalTime;
                lb_UpdateTime.Text = delta.ToString(@"hh\:mm\:ss");
                if (update_log != "")
                {
                    AddTextAndScrollToBottom(update_log, Color.Black, false);
                    update_log = "";
                }
                //he_tbRxTx.AppendText(update_log);
            }
            if(testItem == testcase.Scan)
            {
                if (IsFR)
                {
                    radioButtonFront.Checked = true;
                }
                else
                {
                    radioButtonRear.Checked = true;
                }
            }
        }
        #endregion

        #region Ham xu ly du lieu nhan ve
        private void checkPassFail(string line)
        {
            if (Regex.Match(line, "OK").Success)
            {
                TestResult = result.Pass;
            }
            else if (Regex.Match(line, "NG").Success)
            {
                TestResult = result.Fail;
            }
        }
        private bool ProcessLine(string RxData)
        {
            Console.WriteLine(RxData);

            switch (testItem)
            {


                case testcase.Radaron:
                    break;
                case testcase.Radaroff:

                case testcase.FLEDSettingOff:

                case testcase.RLEDSettingOff:

                case testcase.FSERInit:

                case testcase.RSERInit:

                case testcase.DESInit:

                case testcase.SERLinkInit:

                case testcase.DESSleep:

                case testcase.FRRecovery:

                case testcase.RRadarRecovery:

                case testcase.DESWakeup:

                case testcase.SERControlerWakeup:

                case testcase.DESControlerWakeup:

                case testcase.FLEDSetting:

                case testcase.RSERSetting:

                case testcase.FSERSetting:

                case testcase.RSettingParameter:

                case testcase.RSetingOperation:

                case testcase.FSettingParameter:

                case testcase.FSettingOperation:

                case testcase.RRadarStandby:

                case testcase.RRadarSleep:

                case testcase.FRadarStandby:

                case testcase.FRadarSleep:

                case testcase.RRadarWorking00:

                case testcase.FRadarWorking00:

                case testcase.RRadarWorking03:

                case testcase.FRadarWorking03:

                case testcase.RLEDSetting:

                case testcase.GSensorSetting:

                case testcase.ThresholdSetting:

                case testcase.InteruptGsensorOff:

                case testcase.HighPassFilter:

                case testcase.InteruptGsensorOn:

                case testcase.WakeupEventcheck:

                case testcase.ADCSetting1:

                case testcase.ADCSetting2:

                case testcase.ADCSetting3:

                case testcase.ImageSleep:

                case testcase.Image30fps:

                case testcase.ImageWakeup:

                case testcase.Image10fps:
                    checkPassFail(RxData);
                    break;

                case testcase.ReadInfo:
                    //match = Regex.Match(RxData, @"SW Ver: (\S{4})");
                    //if (match.Success)
                    //{
                    //    string fwVersion = match.Groups[1].Value;
                    //    if (fwVersion == Camera.SWVersion) numtest++;
                    //    else TestResult = result.Fail;
                    //    //Console.WriteLine("Firmware Version: " + fwVersion);
                    //}
                    //else
                    //{

                    //}
                    //match = Regex.Match(RxData, @"HW Ver: (\S{4})");
                    //if (match.Success)
                    //{
                    //    string fwVersion = match.Groups[1].Value;
                    //    if (fwVersion == Camera.HWVersion) numtest++;
                    //    else TestResult = result.Fail;
                    //    //Console.WriteLine("Firmware Version: " + fwVersion);
                    //}
                    //if (numtest == 2) TestResult = result.Pass;
                    break;


                case testcase.RadarReset:
                    //match = Regex.Match(RxData, "Reset");
                    //if (match.Success)
                    //{
                    //    TestResult = result.Pass;
                    //    //Console.WriteLine("Firmware Version: " + fwVersion);
                    //}
                    break;
                case testcase.UpdateFW:
                    if (TX_block_Success == false)
                    {
                        if (Regex.Match(RxData, "Start: OK").Success == true || Regex.Match(RxData, string.Format("Block: OK")).Success == true)
                        {
                            //if(Regex.Match(RxData, string.Format("Block: OK")).Success == true)
                            //{
                            //    TX_block_Success = true;
                            //}
                            TX_block_Success = true;
                        }
                    }
                    if (TX_check_Success == false)
                    {
                        Match match = Regex.Match(RxData, @"Status = (\S{2})");
                        if (match.Success)
                        {
                            byte.TryParse(match.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out updateStatus);
                            TX_check_Success = true;
                        }

                    }

                    break;
                case testcase.Verify:
                    if (TX_check_Verify == 0xfe)
                    {
                        Match match = Regex.Match(RxData, @"Firmware MD5 hashing code = (\S{32})");
                        if (match.Success)
                        {
                            if (match.Groups[1].Value == FWmd5Hash)
                            {
                                TX_check_Verify = (byte)(TX_check_Verify & ~(1 << 1));
                            }
                        }
                    }
                    break;
                case testcase.Scan:
                    if (Regex.Match(RxData, "Found I2C1 device at address 0x20").Success)
                    {
                        I2C_RadarAddress = 0x40;
                        IsFR = true;
                    }
                    else if (Regex.Match(RxData, "Found I2C1 device at address 0x21").Success)
                    {
                        I2C_RadarAddress = 0x42;
                        IsFR = false;
                    }
                    break;
                default:

                    break;
            }
            return true;
        }
        private string ConvertStringToAscii(string input)
        {
            StringBuilder asciiStringBuilder = new StringBuilder();
            string dis;
            foreach (char c in input)
            {
                asciiStringBuilder.Append($"{(int)c} ");
            }
            dis = asciiStringBuilder.ToString();
            if (dis.Length >= 2 && dis.Substring(dis.Length - 3) == "10 ")
            {
                dis += "\n";
            }
            return dis;
        }

        private string ConvertStringToHex(string input)
        {
            StringBuilder hexStringBuilder = new StringBuilder();
            string dis;
            foreach (char c in input)
            {
                hexStringBuilder.Append("0x" + String.Format("{0:X2} ", (int)c));
            }
            dis = hexStringBuilder.ToString();
            if (dis.Length >= 2 && dis.Substring(dis.Length - 3) == "0A ")
            {
                dis += "\n";
            }
            return dis;
        }

        private void displayCRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DisCRLF)
            {
                DisCRLF = false;
            }
            else
            {
                DisCRLF = true;
            }
        }
        private void serialPortReceiver(string input)
        {
            //he_State_rx.BackColor = Color.Yellow;
            //timer1.Enabled = true;
            if (he_cbDisplay.Text == "HEX")
            {
                input = ConvertStringToHex(input);
            }
            else if (he_cbDisplay.Text == "DEC")
            {
                input = ConvertStringToAscii(input);
            }
            else if (DisCRLF)
            {
                input = input.Replace("\r", "<CR>").Replace("\n", "<LF>");
            }
            else
            {

            }
            // Xử lý dữ liệu khi nhận được từ cổng serial
            AddTextAndScrollToBottom(input, Color.Black, false);
  
        }

        private void ScrollToBottom()
        {
            // Cuộn xuống caret.
            he_tbRxTx.ScrollToCaret();
        }

        public void AddTextAndScrollToBottom(string text, Color color, bool isBold = false)
        {
            DateTime t_dis = DateTime.Now;
            // Thêm văn bản vào RichTextBox.
            he_tbRxTx.SelectionColor = color;
            he_tbRxTx.SelectionStart = he_tbRxTx.TextLength;
            he_tbRxTx.SelectionLength = 0;
            //he_tbRxTx.AppendText(text);
            if (isBold)
                he_tbRxTx.SelectionFont = new Font(he_tbRxTx.Font, FontStyle.Bold);
            else
                he_tbRxTx.SelectionFont = new Font(he_tbRxTx.Font, FontStyle.Regular);
            if (he_cbShowTime.Checked)
            {
                if (text.Length >= 2 && text.Substring(text.Length - 1) == "\n")
                {
                    // Hiển thị nếu có CRLF
                    he_tbRxTx.AppendText($"{t_dis.Hour:D2}:{t_dis.Minute:D2}:{t_dis.Second:D2}.{t_dis.Millisecond:D3} -> {text}");
                }
                else
                {
                    // Hiển thị nếu 0 có CRLF
                    he_tbRxTx.AppendText(text);
                }
            }
            else
            {
                // Hiển thị 0 show time
                he_tbRxTx.AppendText(text);
                //Console.WriteLine(text);
            }
            if (he_cbAutoScroll.Checked)
            {
                // Cuộn xuống dòng cuối cùng.
                ScrollToBottom();
            }
            if (he_tbRxTx.TextLength > 80000)
            {
                he_tbRxTx.Select(0, he_tbRxTx.TextLength / 2);
                he_tbRxTx.SelectedText = "";
            }
        }

        //Clear message
        private void btClearAll_Click(object sender, EventArgs e)
        {
            he_tbRxTx.Clear();
        }
        private void toolStripClear_Click(object sender, EventArgs e)
        {
            he_tbRxTx.Clear();
        }
        #endregion

        #region Open Port
        private void he_btOpen_Click(object sender, EventArgs e)
        {
            
            if (he_cbCOM.Text == "")
            {
                MessageBox.Show("Vui lòng chọn cổng com", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                he_tbRxTx.SelectionColor = Color.Red;
                he_State_Connect.BackColor = Color.Red;
                he_tbRxTx.AppendText("\nSerial port " + serialPort.PortName + " closed\r\n");
                he_btOpen.Text = "Open";
                he_cbCOM.Enabled = true;
                he_cbBaud.Enabled = true;
                he_cbDataSize.Enabled = true;
                he_cbParity.Enabled = true;
                he_cbStopBit.Enabled = true;
                buttonBrowse.Enabled = false;
                he_cbCOM.Items.Clear();
            }
            else
            {
                try
                {
                    serialPort.PortName = he_cbCOM.Text;
                    serialPort.BaudRate = Convert.ToInt32(he_cbBaud.Text);
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), he_cbParity.Text);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), he_cbStopBit.Text.ToString());
                    serialPort.Open();
                    Thread.Sleep(5);
                    if (serialPort.IsOpen == true)
                    {
                        //startWorkerThread();
                        timerDP.Enabled = true;
                        he_tbRxTx.SelectionColor = Color.Green;
                        he_tbRxTx.AppendText("\nSerial port " + serialPort.PortName + " opened\r\n");
                        serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                        he_btOpen.Text = "Close";
                        he_State_Connect.BackColor = Color.SpringGreen;
                        he_cbCOM.Enabled = false;
                        he_cbBaud.Enabled = false;
                        he_cbDataSize.Enabled = false;
                        he_cbParity.Enabled = false;
                        he_cbStopBit.Enabled = false;
                        buttonBrowse.Enabled = true;
                        this.KeyPreview = true; // Cho phép Form nhận sự kiện phím
                        this.KeyDown += MainForm_KeyDown; // Gán sự kiện KeyDown cho Form
                    }
                    else
                    {
                        Console.WriteLine("Loi ket noi");
                    }

                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Lỗi không mở được cổng COM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Scan COM
        //private void ScanCOM()
        //{
        //    he_cbCOM.Items.Clear();
        //    string[] ComList = SerialPort.GetPortNames();

        //    // Tạo danh sách để lưu số cổng COM
        //    List<int> ComNumberList = new List<int>();

        //    // Trích xuất số cổng COM từ tên cổng
        //    for (int i = 0; i < ComList.Length; i++)
        //    {
        //        int comNumber = int.Parse(ComList[i].Substring(3));
        //        // Chỉ thêm vào nếu số cổng chưa tồn tại trong danh sách
        //        if (!ComNumberList.Contains(comNumber))
        //        {
        //            ComNumberList.Add(comNumber);
        //        }
        //    }

        //    // Sắp xếp danh sách số cổng COM
        //    ComNumberList.Sort();

        //    // Thêm các cổng COM vào ComboBox
        //    foreach (int ComNumber in ComNumberList)
        //    {
        //        he_cbCOM.Items.Add("COM" + ComNumber.ToString());
        //    }

        //    // Nếu không tìm thấy cổng COM nào
        //    if (he_cbCOM.Items.Count == 0)
        //    {
        //        for (int i = 1; i < 101; i++)
        //        {
        //            he_cbCOM.Items.Add("COM" + i.ToString());
        //        }
        //    }
        //}
        
    private void ScanCOM()
        {
            he_cbCOM.Items.Clear();
            string[] ComList = SerialPort.GetPortNames();

            // Tạo danh sách để lưu số cổng COM
            List<int> ComNumberList = new List<int>();

            // Trích xuất số cổng COM từ tên cổng
            for (int i = 0; i < ComList.Length; i++)
            {
                // Loại bỏ khoảng trắng và chuyển thành chữ hoa
                string portName = ComList[i].Trim().ToUpper();

                // Kiểm tra xem có bắt đầu bằng "COM" không
                if (portName.StartsWith("COM") && portName.Length > 3)
                {
                    string numberPart = portName.Substring(3);
                    int comNumber;

                    // Sử dụng TryParse thay vì Parse
                    if (int.TryParse(numberPart, out comNumber))
                    {
                        if (!ComNumberList.Contains(comNumber))
                        {
                            ComNumberList.Add(comNumber);
                        }
                    }
                }
            }

            // Sắp xếp danh sách số cổng COM
            ComNumberList.Sort();

            // Thêm các cổng COM vào ComboBox
            foreach (int ComNumber in ComNumberList)
            {
                he_cbCOM.Items.Add("COM" + ComNumber.ToString());
            }

            // Nếu không tìm thấy cổng COM nào
            if (he_cbCOM.Items.Count == 0)
            {
                for (int i = 1; i < 101; i++)
                {
                    he_cbCOM.Items.Add("COM" + i.ToString());
                }
            }
        }

//**Hoặc sử dụng Regular Expression để an toàn hơn:**

//```csharp
//private void ScanCOM()
//        {
//            he_cbCOM.Items.Clear();
//            string[] ComList = SerialPort.GetPortNames();

//            List<int> ComNumberList = new List<int>();

//            // Sử dụng Regex để trích xuất số từ tên cổng COM
//            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"COM(\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

//            foreach (string port in ComList)
//            {
//                var match = regex.Match(port);
//                if (match.Success)
//                {
//                    int comNumber = int.Parse(match.Groups[1].Value);
//                    if (!ComNumberList.Contains(comNumber))
//                    {
//                        ComNumberList.Add(comNumber);
//                    }
//                }
//            }

//            ComNumberList.Sort();

//            foreach (int ComNumber in ComNumberList)
//            {
//                he_cbCOM.Items.Add("COM" + ComNumber.ToString());
//            }

//            if (he_cbCOM.Items.Count == 0)
//            {
//                for (int i = 1; i < 101; i++)
//                {
//                    he_cbCOM.Items.Add("COM" + i.ToString());
//                }
//            }
//        }
//```

//Cách này sẽ xử lý được các trường hợp tên cổng COM không chuẩn và tránh được lỗi FormatException.

        private void he_cbCOM_Click(object sender, EventArgs e)
        {
            ScanCOM();
        }
        #endregion

        #region Transmit data
        static byte[] HexStringToByteArray(string hexString)
        {
            // Loại bỏ các ký tự không phải là hex từ chuỗi.
            hexString = new string(hexString.Where(c => "0123456789ABCDEFabcdef".Contains(c)).ToArray());

            // Chuyển đổi chuỗi hex thành mảng byte.
            int length = hexString.Length;
            if (length % 2 != 0)
            {
                hexString = "0" + hexString;
            }

            byte[] byteArray = new byte[hexString.Length / 2];

            for (int i = 0; i < hexString.Length; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return byteArray;
        }

        static byte[] ConvertDecimalStringToByteArray(string decimalString)
        {
            string[] splitValues = decimalString.Split(' ');
            byte[] byteArray = new byte[splitValues.Length];

            for (int i = 0; i < splitValues.Length; i++)
            {
                if (byte.TryParse(splitValues[i], out byte byteValue))
                {
                    byteArray[i] = byteValue;
                }
                else
                {
                    // Xử lý lỗi nếu cần thiết (ví dụ: giá trị không phải số byte hợp lệ)
                }
            }

            return byteArray;
        }

        // Gui du lieu di
        private void he_dtgvSend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isUdpActive = (CT_tabPage.SelectedTab == tabPageUDP) || (!serialPort.IsOpen && isUdpListening);
            if (!serialPort.IsOpen && !isUdpActive)
            {
                MessageBox.Show("Chưa kết nối cổng COM hoặc chưa kích hoạt UDP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    object STR_dem = he_dtgvSend.Rows[e.RowIndex].Cells[0].Value;
                    if (STR_dem != null)
                    {
                        Console.Write(STR_dem);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string STR_toSend;
                    if (he_cbCR.Checked && he_cbLF.Checked)
                    {
                        STR_toSend = STR_dem.ToString() + "\r\n";
                    }
                    else if (he_cbLF.Checked)
                    {
                        STR_toSend = STR_dem.ToString() + "\n";
                    }
                    else if (he_cbCR.Checked)
                    {
                        if ((bool)he_dtgvSend.Rows[e.RowIndex].Cells[1].Value == true)
                        {
                            STR_toSend = STR_dem.ToString() + "0D";
                        }
                        else {
                            STR_toSend = STR_dem.ToString() + "\r";
                        }
                    }
                    else
                    {
                        STR_toSend = STR_dem.ToString();
                    }
                    if ((bool)he_dtgvSend.Rows[e.RowIndex].Cells[1].Value == true)
                    {
                        //hex
                        byte[] hex = new byte[STR_toSend.Length / 2];
                        hex = HexStringToByteArray(STR_toSend);
                        he_State_tx.BackColor = Color.Yellow;
                        if (isUdpActive)
                        {
                            SendUdpData(hex);
                            AddTextAndScrollToBottom("[UDP TX]: " + BitConverter.ToString(hex).Replace("-", "") + "\n", Color.Blue, false);
                        }
                        else
                        {
                            serialPort.Write(hex, 0, hex.Length);
                            AddTextAndScrollToBottom(BitConverter.ToString(hex).Replace("-", "") + "\n", Color.Blue, false);
                        }
                    }
                    else if ((bool)he_dtgvSend.Rows[e.RowIndex].Cells[2].Value == true)
                    {
                        //dec
                        byte[] decimalArray = ConvertDecimalStringToByteArray(STR_toSend);
                        he_State_tx.BackColor = Color.Yellow;
                        string decimalString = "";
                        foreach (byte byteValue in decimalArray)
                        {
                            decimalString += byteValue.ToString() + " ";
                        }
                        decimalString = decimalString.TrimEnd() + "\n";
                        if (isUdpActive)
                        {
                            SendUdpData(decimalArray);
                            AddTextAndScrollToBottom("[UDP TX]: " + decimalString, Color.Orange, false);
                        }
                        else
                        {
                            serialPort.Write(decimalArray, 0, decimalArray.Length);
                            AddTextAndScrollToBottom(decimalString, Color.Orange, false);
                        }
                    }
                    else if ((bool)he_dtgvSend.Rows[e.RowIndex].Cells[3].Value == true)
                    {
                        //Ascii
                        he_State_tx.BackColor = Color.Yellow;
                        if (isUdpActive)
                        {
                            Encoding enc = serialPort.Encoding ?? Encoding.GetEncoding(28591);
                            SendUdpData(enc.GetBytes(STR_toSend));
                            AddTextAndScrollToBottom("[UDP TX]: " + STR_toSend, Color.Magenta, false);
                        }
                        else
                        {
                            AddTextAndScrollToBottom(STR_toSend, Color.Magenta, false);
                            serialPort.Write(STR_toSend);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn kiểu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    he_State_tx.BackColor = Color.Transparent;
                }
            }

            //Chi duoc chon 1 trong 3 o
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                he_dtgvSend.Rows[e.RowIndex].Cells[1].Value = false;
                he_dtgvSend.Rows[e.RowIndex].Cells[2].Value = false;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            { 
                he_dtgvSend.Rows[e.RowIndex].Cells[1].Value = false;
                he_dtgvSend.Rows[e.RowIndex].Cells[3].Value = false;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                he_dtgvSend.Rows[e.RowIndex].Cells[3].Value = false;
                he_dtgvSend.Rows[e.RowIndex].Cells[2].Value = false;
            }
        }

        //tick truoc cot Hex
        private void he_dtgvSend_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            he_dtgvSend.Rows[e.RowIndex].Cells[1].Value = false;
            he_dtgvSend.Rows[e.RowIndex].Cells[2].Value = false;
            he_dtgvSend.Rows[e.RowIndex].Cells[3].Value = true;
        }


        #endregion

        #region Thay doi kich thuoc Form
        // thay doi Size
        //Chinh kich thuoc cac doi tuong khi resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            int width = form.Width;
            int height = form.Height;
            //this.VTtabPage.Size = new System.Drawing.Size(width - 30, height - 50);

        }
        private void he_dtgvSend_Resize(object sender, EventArgs e)
        {
            he_dtgvSend.Columns[0].Width = he_dtgvSend.Width*3/5;
        }

        //Không cho phép nhập từ bàn phím vào combo box
        private void he_tbRxTx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Hủy bỏ sự kiện KeyPress để ngăn chặn việc nhập liệu từ bàn phím
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://imgur.com/gallery/epnSKF9");
        }
        #endregion

        #region Load file to send
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            // Hiển thị hộp thoại mở tập tin để chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Hex Files (*.hex)|*.hex|Bin Files (*.bin)|*.bin|All Files (*.*)|*.*"; // Chỉ cho phép chọn các loại file hex, bin và txt
            openFileDialog.Title = "Select a File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tập tin đã chọn
                lastFilePath = openFileDialog.FileName;

                // Gửi tập tin đi
                SendFile(lastFilePath);
            }
        }

        private void SendFile(string filePath)
        {
            try
            {
                // Kiểm tra phần mở rộng của file để xác định loại file
                string fileExtension = Path.GetExtension(filePath).ToLower();

                // Kiểm tra nếu là file bin
                if (fileExtension == ".bin" || fileExtension == ".hex")
                {
                    SendBinFile(filePath); // Gửi file bin
                    return;
                }

                // Đối với các loại file khác, đọc nội dung của file
                string fileContent = File.ReadAllText(filePath);
                bool isUdpActive = (CT_tabPage.SelectedTab == tabPageUDP) || (!serialPort.IsOpen && isUdpListening);

                if (isUdpActive)
                {
                    Encoding enc = serialPort.Encoding ?? Encoding.GetEncoding(28591);
                    SendUdpData(enc.GetBytes(fileContent));
                    AddTextAndScrollToBottom("[UDP File Sent]: " + fileContent + "\r\n", Color.Magenta, false);
                }
                else
                {
                    AddTextAndScrollToBottom(fileContent, Color.Magenta, false);
                    serialPort.Write(fileContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SendBinFile(string filePath)
        {
            try
            {
                // Đọc dữ liệu từ file bin
                byte[] fileData = File.ReadAllBytes(filePath);
                bool isUdpActive = (CT_tabPage.SelectedTab == tabPageUDP) || (!serialPort.IsOpen && isUdpListening);

                if (isUdpActive)
                {
                    SendUdpData(fileData);
                    AddTextAndScrollToBottom("[UDP Binary File Sent]: " + fileData.Length + " bytes\r\n", Color.Blue, false);
                }
                else
                {
                    serialPort.Write(fileData, 0, fileData.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấn tổ hợp phím Ctrl+O hay không
            if (e.Control && e.KeyCode == Keys.O)
            {
                OpenFile();
            }

            // Kiểm tra xem người dùng đã nhấn tổ hợp phím Ctrl+S hay không
            if (e.Control && e.KeyCode == Keys.S)
            {
                ResendLastFile();
            }
        }
        private void ResendLastFile()
        {
            if (!string.IsNullOrEmpty(lastFilePath))
            {
                // Gửi lại tập tin cuối cùng được chọn
                SendFile(lastFilePath);
            }
            else
            {
                MessageBox.Show("No file has been selected.");
            }
        }
        #endregion

        #region UDP Communication
        private void cb_UdpBroadcast_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_UdpBroadcast.Checked)
            {
                tb_UdpRemoteIP.Text = "255.255.255.255";
                if (udpClient != null)
                {
                    try { udpClient.EnableBroadcast = true; } catch { }
                }
            }
            else
            {
                if (tb_UdpRemoteIP.Text == "255.255.255.255")
                {
                    tb_UdpRemoteIP.Text = "192.168.1.100";
                }
            }
        }

        private void bt_UdpListen_Click(object sender, EventArgs e)
        {
            if (isUdpListening)
            {
                StopUdpListener();
            }
            else
            {
                if (!int.TryParse(tb_UdpLocalPort.Text.Trim(), out int localPort) || localPort < 1 || localPort > 65535)
                {
                    MessageBox.Show("Vui lòng nhập Local Port hợp lệ (1 - 65535).", "Lỗi UDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    udpClient = new UdpClient(localPort);
                    udpClient.EnableBroadcast = cb_UdpBroadcast.Checked;
                    udpCts = new CancellationTokenSource();
                    isUdpListening = true;

                    bt_UdpListen.Text = "Close";
                    bt_UdpListen.BackColor = Color.SpringGreen;
                    udp_State_Connect.BackColor = Color.SpringGreen;
                    lb_UdpStatus.Text = "Listening on " + localPort;
                    tb_UdpLocalPort.Enabled = false;
                    buttonBrowse.Enabled = true;

                    AddTextAndScrollToBottom("\n[UDP] Started listening on local port " + localPort + "...\r\n", Color.Green, false);

                    Task.Run(() => UdpReceiveLoop(udpCts.Token));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở UDP port " + localPort + ": " + ex.Message, "Lỗi khởi động UDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StopUdpListener();
                }
            }
        }

        private void StopUdpListener()
        {
            try
            {
                if (udpCts != null)
                {
                    udpCts.Cancel();
                    udpCts.Dispose();
                    udpCts = null;
                }
                if (udpClient != null)
                {
                    udpClient.Close();
                    udpClient = null;
                }
            }
            catch { }
            finally
            {
                isUdpListening = false;
                bt_UdpListen.Text = "Listen";
                bt_UdpListen.BackColor = SystemColors.Control;
                udp_State_Connect.BackColor = Color.Red;
                lb_UdpStatus.Text = "Closed";
                tb_UdpLocalPort.Enabled = true;
                if (!serialPort.IsOpen)
                {
                    buttonBrowse.Enabled = false;
                }
                AddTextAndScrollToBottom("\n[UDP] Stopped listening.\r\n", Color.Red, false);
            }
        }

        private async Task UdpReceiveLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested && udpClient != null)
            {
                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
                    byte[] receivedBytes = result.Buffer;
                    IPEndPoint remoteEP = result.RemoteEndPoint;

                    if (receivedBytes == null || receivedBytes.Length == 0)
                        continue;

                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            he_State_rx.BackColor = Color.Yellow;
                        }));
                    }

                    string displayData = "";
                    if (he_cbDisplay.Text == "HEX")
                    {
                        displayData = BitConverter.ToString(receivedBytes).Replace("-", " ") + " \r\n";
                    }
                    else
                    {
                        Encoding enc = serialPort.Encoding ?? Encoding.GetEncoding(28591);
                        displayData = enc.GetString(receivedBytes);
                    }

                    string prefix = cb_UdpShowRemote.Checked ? "[UDP from " + remoteEP.ToString() + "]: " : "";

                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            AddTextAndScrollToBottom(prefix + displayData, Color.Black, false);
                        }));
                    }
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested && this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            AddTextAndScrollToBottom("\n[UDP RX Error]: " + ex.Message + "\r\n", Color.Red, false);
                        }));
                    }
                    break;
                }
            }
        }

        public bool SendUdpData(byte[] data)
        {
            if (data == null || data.Length == 0) return false;

            string ipStr = tb_UdpRemoteIP.Text.Trim();
            if (!IPAddress.TryParse(ipStr, out IPAddress remoteIp))
            {
                MessageBox.Show("Địa chỉ Remote IP không hợp lệ!", "Lỗi UDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(tb_UdpRemotePort.Text.Trim(), out int remotePort) || remotePort < 1 || remotePort > 65535)
            {
                MessageBox.Show("Remote Port không hợp lệ (1 - 65535)!", "Lỗi UDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IPEndPoint targetEP = new IPEndPoint(remoteIp, remotePort);
            bool tempClient = false;
            UdpClient client = udpClient;

            try
            {
                if (client == null)
                {
                    client = new UdpClient();
                    if (cb_UdpBroadcast.Checked || ipStr == "255.255.255.255")
                    {
                        client.EnableBroadcast = true;
                    }
                    tempClient = true;
                }

                he_State_tx.BackColor = Color.Yellow;
                client.Send(data, data.Length, targetEP);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi dữ liệu UDP: " + ex.Message, "Lỗi UDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (tempClient && client != null)
                {
                    client.Close();
                }
            }
        }

        private void bt_UdpSend_Click(object sender, EventArgs e)
        {
            string textToSend = tb_UdpSendText.Text;
            if (string.IsNullOrEmpty(textToSend))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu cần gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rb_UdpHex.Checked)
            {
                string hexInput = textToSend;
                if (cb_UdpCRLF.Checked)
                {
                    hexInput += " 0D 0A";
                }
                try
                {
                    byte[] hexBytes = HexStringToByteArray(hexInput);
                    if (SendUdpData(hexBytes))
                    {
                        string log = BitConverter.ToString(hexBytes).Replace("-", " ") + "\r\n";
                        AddTextAndScrollToBottom("[UDP TX to " + tb_UdpRemoteIP.Text + ":" + tb_UdpRemotePort.Text + "]: " + log, Color.Blue, false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dữ liệu HEX không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string asciiInput = textToSend;
                if (cb_UdpCRLF.Checked)
                {
                    asciiInput += "\r\n";
                }
                Encoding enc = serialPort.Encoding ?? Encoding.GetEncoding(28591);
                byte[] bytes = enc.GetBytes(asciiInput);
                if (SendUdpData(bytes))
                {
                    AddTextAndScrollToBottom("[UDP TX to " + tb_UdpRemoteIP.Text + ":" + tb_UdpRemotePort.Text + "]: " + asciiInput, Color.Magenta, false);
                }
            }
        }

        private void bt_UdpClearSend_Click(object sender, EventArgs e)
        {
            tb_UdpSendText.Clear();
        }
        #endregion

        #region Save and Load file TX, RX

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveTXListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "(*.txt)|*.txt|(*.doc)|*.doc";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string path = saveFile.FileName;
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
                {
                    if (Isuart)
                    {
                        he_dtgvSend.CurrentCell = he_dtgvSend[0, he_dtgvSend.RowCount - 1];
                        he_dtgvSend.Focus();
                        foreach (DataGridViewRow row in he_dtgvSend.Rows)
                        {
                            // Kiểm tra nếu hàng không phải là hàng header
                            if (!row.IsNewRow)
                            {
                                // Lặp qua từng ô trong hàng và ghi giá trị vào tệp
                                for (int i = 0; i < he_dtgvSend.Columns.Count; i++)
                                {
                                    if (row.Cells[i].Value != null)
                                    {
                                        writer.Write(row.Cells[i].Value.ToString());
                                    }
                                    if (i < he_dtgvSend.Columns.Count - 1)
                                    {
                                        writer.Write("\t"); // Sử dụng tab để ngăn cách giữa các cột
                                    }
                                }
                                writer.WriteLine(); // Xuống dòng sau khi hoàn thành hàng
                            }
                        }
                    }
                    else
                    {
                        I2C_dtgv.CurrentCell = I2C_dtgv[0, I2C_dtgv.RowCount - 1];
                        I2C_dtgv.Focus();
                        foreach (DataGridViewRow row in I2C_dtgv.Rows)
                        {
                            // Kiểm tra nếu hàng không phải là hàng header
                            if (!row.IsNewRow)
                            {
                                // Lặp qua từng ô trong hàng và ghi giá trị vào tệp
                                for (int i = 0; i < I2C_dtgv.Columns.Count; i++)
                                {
                                    if (row.Cells[i].Value != null)
                                    {
                                        writer.Write(row.Cells[i].Value.ToString());
                                    }
                                    if (i < I2C_dtgv.Columns.Count - 1)
                                    {
                                        writer.Write("\t"); // Sử dụng tab để ngăn cách giữa các cột
                                    }
                                }
                                writer.WriteLine(); // Xuống dòng sau khi hoàn thành hàng
                            }
                        }
                    }
                    MessageBox.Show("Dữ liệu đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void loadTXListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.txt)|*.txt|(*.doc)|*.doc";
            // Mở hộp thoại mở file
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //    // Lấy đường dẫn đến file mà người dùng đã chọn
                string path = openFile.FileName;
                try
                {
                    he_dtgvSend.Rows.Clear(); // Xóa tất cả dữ liệu hiện có trong DataGridView
                    testBenchList.Clear();
                    using (StreamReader reader = new StreamReader(path))
                    {
                        if (Isuart)
                        {
                            int hang = 0;
                            bool[] data = new bool[3];
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                string[] values = line.Split('\t'); // Giả sử các cột trong tệp văn bản được ngăn cách bằng tab

                                // Thêm hàng mới vào DataGridView và gán giá trị từ tệp văn bản vào từng ô
                                he_dtgvSend.Rows.Add(values);
                                he_dtgvSend.Rows[hang].Cells[0].Value = values[0];
                                he_dtgvSend.Rows[hang].Cells[1].Value = Convert.ToBoolean(values[1]);
                                he_dtgvSend.Rows[hang].Cells[2].Value = Convert.ToBoolean(values[2]);
                                he_dtgvSend.Rows[hang].Cells[3].Value = Convert.ToBoolean(values[3]);
                                hang++;
                            }
                        }
                        else
                        {
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                string[] values = line.Split('\t'); // các cột trong tệp văn bản được ngăn cách bằng tab
                                Bench b = new Bench(values);
                                if (b != null)
                                {
                                    testBenchList.Add(b);
                                }
                            }
                        }
                    }
                    MessageBox.Show("Dữ liệu đã được tải thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Virtual COM Port
        private void virtualCOMPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "cmd.exe";
                string arguments = "/c " +
                    "C: && cd C:\\Program Files (x86)\\com0com && start setupg.exe";

                ProcessStartInfo psi = new ProcessStartInfo(command, arguments)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new Process { StartInfo = psi };
                process.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region FT260 I2C
        public static BindingList<Bench> TestBenchList { get => testBenchList; set => testBenchList = value; }
        private static BindingList<Bench> testBenchList = new BindingList<Bench>();

        public bool IsI2CConnected()
        {
            // Nếu handle chưa mở (vẫn là IntPtr.Zero) thì chưa kết nối
            if (ft260handle == IntPtr.Zero)
                return false;

            byte i2cStatus = 0;
            FT260_STATUS checkStatus = FT260_I2CMaster_GetStatus(ft260handle, ref i2cStatus);

            // Kiểm tra lệnh gọi có thành công không
            if (checkStatus != FT260_STATUS.FT260_OK)
                return false;

            // Kiểm tra bit 0 (controller busy) hoặc bit 5 (controller idle)
            bool isIdle = (i2cStatus & (1 << 5)) != 0;
            bool isBusy = (i2cStatus & (1 << 0)) != 0;

            // Nếu không busy và đang idle → coi như đã kết nối ổn
            return isIdle && !isBusy;
        }

        private void FT_bt_Init_Click(object sender, EventArgs e)
        {
            if (DLL_Loaded == true && FT_bt_Init.Text == "Disconnect")
            {
                FT260_Close(ft260handle);
                SetControls_Exit();
            }
            else
            {
                byte result = 0;
                FT260_Close(ft260handle);
                result = Init_I2C();
                if (result == 0)
                {
                    timerDP.Enabled = true;
                    SetControls_Initalised();
                }
            }
        }
        private void Init_I2C(byte add)
        {
            addDevice = add; // Assign found radar address
            radarFound = true;
            I2C_RadarAddress = add;
            UInt32 writeLength = 0;
            byte[] config = { 0x0C, 0x02 };
            IntPtr ptr = Marshal.AllocHGlobal(config.Length);
            Marshal.Copy(config, 0, ptr, config.Length);
            // --- Send config to radar 3 times ---
            for (int i = 0; i < 3; i++)
            {
                var status = FT260_I2CMaster_Write(ft260handle, add,
                    FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, ptr, 2, ref writeLength);

                if (status != FT260_STATUS.FT260_OK || writeLength != 2)
                    ShowError("Error", $"I2C config write {i + 1}/3 failed.");

                Thread.Sleep(10);
            }
            Marshal.FreeHGlobal(ptr);
        }
        private byte Init_I2C()
        {
            // Get I2C speed from ComboBox
            if (!UInt32.TryParse(FT_cb_Baud.Text, out uint i2cSpeed))
                i2cSpeed = 100; // Default if invalid

            UInt32 numDevs = 0;

            DLL_Loaded = false;

            try
            {
                // --- Check FT260 and open connection ---
                if (FT260_CreateDeviceList(ref numDevs) != FT260_STATUS.FT260_OK)
                    return ShowError("Error", "No FT260 device found.");

                if (FT260_OpenByVidPid(0x0403, 0x6030, 0, ref ft260handle) != FT260_STATUS.FT260_OK)
                    return ShowError("Error", "Failed to open FT260 device.");

                if (FT260_I2CMaster_Init(ft260handle, i2cSpeed) != FT260_STATUS.FT260_OK)
                    return ShowError("Error", "Failed to initialize I2C.");

                //// --- Scan for radar device at 0x20 or 0x21 ---
                //byte[] radarAddresses = { 0x20, 0x21 };
                //byte radarStatus = 0;
                //UInt32 dummyReadLen = 0;
                //byte[] dummyBuffer = new byte[1];
                //IntPtr dummyPtr = Marshal.AllocHGlobal(1);
                //Marshal.Copy(dummyBuffer, 0, dummyPtr, 1);

                //bool radarFound = false;

                //foreach (byte addr in radarAddresses)
                //{
                //    var readStatus = FT260_I2CMaster_Read(ft260handle, addr,
                //        FT260_I2C_FLAG.FT260_I2C_START, dummyPtr, 1, ref dummyReadLen, 100);

                //    FT260_I2CMaster_GetStatus(ft260handle, ref radarStatus);

                //    if (readStatus == FT260_STATUS.FT260_OK &&
                //        dummyReadLen == 1 &&
                //        (radarStatus & 0x40) != 0)
                //    {
                //        addDevice = addr; // Assign found radar address
                //        radarFound = true;
                //        I2C_RadarAddress = addr;
                //        //break;
                //    }
                //}

                //Marshal.FreeHGlobal(dummyPtr);

                //// --- Send config to radar 3 times ---
                //for (int i = 0; i < 3; i++)
                //{
                //    var status = FT260_I2CMaster_Write(ft260handle, addDevice,
                //        FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, ptr, 2, ref writeLength);

                //    if (status != FT260_STATUS.FT260_OK || writeLength != 2)
                //        return ShowError("Error", $"I2C config write {i + 1}/3 failed.");

                //    Thread.Sleep(10);
                //}

                // --- Get I2C status ---
                /* I2C Master Controller Status (I2Cstatus variable)
                *   bit 0 = controller busy: all other status bits invalid
                *   bit 1 = error condition
                *   bit 2 = slave address was not acknowledged during last operation
                *   bit 3 = data not acknowledged during last operation
                *   bit 4 = arbitration lost during last operation
                *   bit 5 = controller idle
                *   bit 6 = bus busy
                */
                byte i2cStatus = 0;
                if (FT260_I2CMaster_GetStatus(ft260handle, ref i2cStatus) != FT260_STATUS.FT260_OK)
                    return ShowError("Error", "Failed to get I2C status.");

                Console.WriteLine($"I2Cstatus: 0x{i2cStatus:X2}");
                labelStatusSummary.Text = "Ready";
                DLL_Loaded = true;
                return 0;
            }
            catch (DllNotFoundException)
            {
                return ShowError("DLL Missing", "LibFT260.dll not found in application directory.");
            }
            catch (Exception)
            {
                return ShowError("Unexpected Error", "An unexpected error occurred. Try reconnecting the device.");
            }
            finally
            {
                //Marshal.FreeHGlobal(ptr);
            }
        }

        private byte ShowError(string title, string msg)
        {
            SetControls_Error(title, msg);
            return 1;
        }

        private void SetControls_Initalised()
        {
            //=============================================
            labelStatusSummary.Text = "Ready";
            labelStatusDetail.Text = " ";
            FT_bt_Init.Text = "Disconnect";
            he_State_Connect.BackColor = Color.SpringGreen;
            AddTextAndScrollToBottom("I2C connected success\r\n", Color.Green, false);
            //=============================================
        }
        private void SetControls_Error(String ErrorSummary, String ErrorDetail)
        {
            //=============================================
            labelStatusSummary.Text = ErrorSummary.ToString();
            labelStatusDetail.Text = ErrorDetail.ToString();
            he_State_Connect.BackColor = Color.Red;
            AddTextAndScrollToBottom("\n" + ErrorSummary.ToString() + ": " + ErrorDetail.ToString() + "\r\n", Color.Red, false);
            //---------------------------------------------
        }

        private void SetControls_Exit()
        {
            //=============================================
            labelStatusSummary.Text = "Closing";
            labelStatusDetail.Text = " ";
            FT_bt_Init.Text = "Connect";
            he_State_Connect.BackColor = Color.Red;
            AddTextAndScrollToBottom("\nI2C disconnected success\r\n", Color.Red, false);
            //=============================================
        }
        private void FT_bt_Scan_Click(object sender, EventArgs e)
        {
            byte[] dummyWrite = new byte[1] { 0x00 }; // Dummy data để ghi
            UInt32 writeLength = 0;
            UInt32 numBytesToWrite = 1;
            IntPtr pnt = Marshal.AllocHGlobal(dummyWrite.Length);
            Marshal.Copy(dummyWrite, 0, pnt, dummyWrite.Length);

            byte I2Cstatus = 0;
            int foundCount = 0;

            AddTextAndScrollToBottom("Scanning I2C bus with write...\n", Color.Blue, false);

            for (byte address = 0x03; address <= 0x77; address++)
            {
                bool deviceFound = false;

                for (int attempt = 0; attempt < 3; attempt++) // Retry 3 lần
                {
                    writeLength = 0;
                    FT260_STATUS writeStatus = FT260_I2CMaster_Write(ft260handle, address, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP,
                                                                      pnt, numBytesToWrite, ref writeLength);

                    FT260_STATUS status = FT260_I2CMaster_GetStatus(ft260handle, ref I2Cstatus);

                    if (writeStatus != FT260_STATUS.FT260_OK || status != FT260_STATUS.FT260_OK)
                        continue;

                    // Kiểm tra trạng thái giao tiếp I2C
                    bool noNack = (I2Cstatus & 0x04) == 0;
                    bool noError = (I2Cstatus & 0x02) == 0;
                    bool noBusError = (I2Cstatus & 0x10) == 0 && (I2Cstatus & 0x80) == 0;

                    if (writeLength == numBytesToWrite && noNack && noError && noBusError)
                    {
                        deviceFound = true;
                        if (address == 0x20)
                        {
                            Init_I2C(address);
                            IsFR = true;
                        }
                        else if (address == 0x21)
                        {
                            Init_I2C(address);
                            IsFR = false;
                        }
                        break;
                    }
                }

                if (deviceFound)
                {
                    AddTextAndScrollToBottom($"I2C Device Found at 0x{address:X2}\n", Color.Black, false);
                    foundCount++;
                }
            }

            Marshal.FreeHGlobal(pnt);
            if (!radarFound)
                ShowError("Radar not found", "No radar detected at 0x20 or 0x21.");
            if (foundCount == 0)
                AddTextAndScrollToBottom("No I2C devices found.\n", Color.Black, false);
        }

        //private void FT_bt_Scan_Click(object sender, EventArgs e)
        //{
        //    // Kiểm tra kết nối FT260 trước khi scan
        //    if (ft260handle == IntPtr.Zero || ft260handle == null)
        //    {
        //        AddTextAndScrollToBottom("FT260 not connected. Please connect device first.\n", Color.Red, false);
        //        return;
        //    }

        //    //// Kiểm tra trạng thái thiết bị
        //    //FT260_CHIP_VERSION chipVersion = new FT260_CHIP_VERSION();
        //    //FT260_STATUS deviceStatus = FT260_GetChipVersion(ft260handle, ref chipVersion);

        //    //if (deviceStatus != FT260_STATUS.FT260_OK)
        //    //{
        //    //    AddTextAndScrollToBottom("FT260 device error. Please check connection.\n", Color.Red, false);
        //    //    return;
        //    //}

        //    byte[] dummyWrite = new byte[1] { 0x00 };
        //    UInt32 writeLength = 0;
        //    UInt32 numBytesToWrite = 1;
        //    IntPtr pnt = Marshal.AllocHGlobal(dummyWrite.Length);
        //    Marshal.Copy(dummyWrite, 0, pnt, dummyWrite.Length);

        //    byte I2Cstatus = 0;
        //    int foundCount = 0;
        //    bool busConnected = false;

        //    AddTextAndScrollToBottom("Scanning I2C bus with write...\n", Color.Blue, false);

        //    //// Test địa chỉ 0x00 để kiểm tra bus có kết nối không
        //    //FT260_STATUS testStatus = FT260_I2CMaster_Write(ft260handle, 0x00,
        //    //    FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToWrite, ref writeLength);

        //    //FT260_I2CMaster_GetStatus(ft260handle, ref I2Cstatus);

        //    //// Kiểm tra xem có bus error không (thường xảy ra khi không có pull-up hoặc không kết nối)
        //    //if ((I2Cstatus & 0x10) != 0 || (I2Cstatus & 0x80) != 0)
        //    //{
        //    //    AddTextAndScrollToBottom("I2C bus error detected. Check pull-up resistors and connections.\n", Color.Red, false);
        //    //    Marshal.FreeHGlobal(pnt);
        //    //    return;
        //    //}

        //    //// Kiểm tra timeout hoặc các lỗi khác
        //    //if ((I2Cstatus & 0x01) != 0) // Controller busy
        //    //{
        //    //    AddTextAndScrollToBottom("I2C controller busy or not responding.\n", Color.Red, false);
        //    //    Marshal.FreeHGlobal(pnt);
        //    //    return;
        //    //}

        //    for (byte address = 0x03; address <= 0x77; address++)
        //    {
        //        bool deviceFound = false;

        //        for (int attempt = 0; attempt < 3; attempt++)
        //        {
        //            writeLength = 0;
        //            FT260_STATUS writeStatus = FT260_I2CMaster_Write(ft260handle, address,
        //                FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToWrite, ref writeLength);

        //            // Delay nhỏ giữa các lần thử
        //            System.Threading.Thread.Sleep(5);

        //            FT260_STATUS status = FT260_I2CMaster_GetStatus(ft260handle, ref I2Cstatus);

        //            if (writeStatus != FT260_STATUS.FT260_OK || status != FT260_STATUS.FT260_OK)
        //                continue;

        //            // Debug log
        //            if (address == 0x03) // Log lần đầu để debug
        //            {
        //                Console.WriteLine($"I2C Status byte: 0x{I2Cstatus:X2}");
        //                Console.WriteLine($"Write length: {writeLength}, expected: {numBytesToWrite}");
        //            }

        //            // Kiểm tra trạng thái giao tiếp I2C
        //            bool noNack = (I2Cstatus & 0x04) == 0;
        //            bool noError = (I2Cstatus & 0x02) == 0;
        //            bool noBusError = (I2Cstatus & 0x10) == 0 && (I2Cstatus & 0x80) == 0;
        //            bool notBusy = (I2Cstatus & 0x01) == 0;

        //            // Kiểm tra thêm điều kiện
        //            if (writeLength == numBytesToWrite && noNack && noError && noBusError && notBusy)
        //            {
        //                // Xác nhận lại bằng cách đọc 1 byte
        //                byte[] readBuffer = new byte[1];
        //                UInt32 readLength = 0;
        //                IntPtr readPtr = Marshal.AllocHGlobal(1);

        //                FT260_STATUS readStatus = FT260_I2CMaster_Read(ft260handle, address,
        //                    FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, readPtr, 1, ref readLength, 50);

        //                Marshal.FreeHGlobal(readPtr);

        //                if (readStatus == FT260_STATUS.FT260_OK || readStatus == FT260_STATUS.FT260_I2C_READ_FAIL)
        //                {
        //                    deviceFound = true;
        //                    busConnected = true;

        //                    if (address == 0x20)
        //                    {
        //                        Init_I2C(address);
        //                        IsFR = true;
        //                    }
        //                    else if (address == 0x21)
        //                    {
        //                        Init_I2C(address);
        //                        IsFR = false;
        //                    }
        //                    break;
        //                }
        //            }
        //        }

        //        if (deviceFound)
        //        {
        //            AddTextAndScrollToBottom($"I2C Device Found at 0x{address:X2}\n", Color.Black, false);
        //            foundCount++;
        //        }
        //    }

        //    Marshal.FreeHGlobal(pnt);

        //    if (!busConnected)
        //    {
        //        AddTextAndScrollToBottom("Warning: No I2C bus activity detected. Check connections.\n", Color.Orange, false);
        //    }

        //    if (!radarFound)
        //        ShowError("Radar not found", "No radar detected at 0x20 or 0x21.");

        //    if (foundCount == 0)
        //        AddTextAndScrollToBottom("No I2C devices found.\n", Color.Black, false);
        //    else
        //        AddTextAndScrollToBottom($"Scan complete. Found {foundCount} device(s).\n", Color.Green, false);
        //}

        private void FT_bt_Add_Click(object sender, EventArgs e)
        {
            if (I2C_dtgv.SelectedCells.Count > 0)
            {
                int selectedRowIndex = I2C_dtgv.SelectedCells[0].RowIndex;
                Bench oj = new Bench();
                testBenchList.Insert(selectedRowIndex + 1, oj);
                for (int i = selectedRowIndex; i < testBenchList.Count; i++)
                {
                    testBenchList[i].Num = (uint)(i + 1);
                }
            }
            else
            {
                testBenchList.Add(new Bench((uint)testBenchList.Count + 1));
            }
        }

        private void I2C_dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (IsI2CConnected())
            //{
            if (e.ColumnIndex >= 0 && I2C_dtgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Kiểm tra chỉ số hàng hợp lệ
                if (e.RowIndex >= 0 && e.RowIndex < I2C_dtgv.Rows.Count)
                {
                    // Lấy đối tượng của hàng đang được click
                    Bench selectedObject = I2C_dtgv.Rows[e.RowIndex].DataBoundItem as Bench;
                    if (selectedObject != null && selectedObject.Reg_add != "")
                    {
                        selectedObject.Bench_handle(this);
                        // Xử lý logic tùy ý với đối tượng selectedObject tại đây
                    }
                    else
                    {
                        MessageBox.Show("Invalid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            //}
            //else
            //{
            //    MessageBox.Show("I2C not connected or error occurred.");
            //}

        }

        public bool I2CWrite(IntPtr ft260Handle, uint deviceAddress, byte[] writeDataConfig, int size)
        {
            if (writeDataConfig.Length >= size)
            {
                UInt32 writeLength = 0;
                IntPtr pnt = Marshal.AllocHGlobal(size);
                Marshal.Copy(writeDataConfig, 0, pnt, size);
                Status = FT260_I2CMaster_Write(ft260handle, deviceAddress, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, (UInt32)size, ref writeLength);
                Marshal.FreeHGlobal(pnt);
                if ((Status != FT260_STATUS.FT260_OK) || (writeLength != size))
                {
                    Console.WriteLine("Please check hardware and re-start application");
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool I2CRead(IntPtr ft260Handle, uint deviceAddress, byte[] regAddress, ref byte[] readData, uint sizetoread)
        {
            UInt32 writeLength = 0;
            UInt32 readLength = 0;
            byte[] read = new byte[10]; ;
            IntPtr pnt = Marshal.AllocHGlobal((int)sizetoread);
            Marshal.Copy(regAddress, 0, pnt, regAddress.Length);
            int numBytesToWrite = regAddress.Length;
            Status = FT260_I2CMaster_Write(ft260Handle, deviceAddress, FT260_I2C_FLAG.FT260_I2C_START, pnt, (UInt32)numBytesToWrite, ref writeLength);

            Status = FT260_I2CMaster_Read(ft260Handle, deviceAddress, (FT260_I2C_FLAG)(FT260_I2C_FLAG.FT260_I2C_REPEATED_START | FT260_I2C_FLAG.FT260_I2C_STOP),
                pnt, sizetoread, ref readLength, 5000);
            Marshal.Copy(pnt, readData, 0, (int)sizetoread);
            Marshal.FreeHGlobal(pnt);


            if ((Status != FT260_STATUS.FT260_OK) /*|| (writeLength != numBytesToWrite)*/)
            {
                Console.WriteLine("Please check hardware and re-start application");
                return false;
            }
            return true;
        }
        public bool I2CRead(IntPtr ft260Handle, uint deviceAddress, byte regAddress, ref byte readData)
        {
            UInt32 writeLength = 0;
            UInt32 readLength = 0;
            byte[] read = new byte[10]; ;
            IntPtr pnt = Marshal.AllocHGlobal(1);
            //Marshal.Copy((int)regAddress, 0, pnt, 1);
            Marshal.WriteByte(pnt, regAddress);
            int numBytesToWrite = 1;
            Status = FT260_I2CMaster_Write(ft260Handle, deviceAddress, FT260_I2C_FLAG.FT260_I2C_START, pnt, (UInt32)numBytesToWrite, ref writeLength);

            Status = FT260_I2CMaster_Read(ft260Handle, deviceAddress, (FT260_I2C_FLAG)(FT260_I2C_FLAG.FT260_I2C_REPEATED_START | FT260_I2C_FLAG.FT260_I2C_STOP),
                pnt, 1, ref readLength, 5000);
            //Marshal.Copy(pnt, readData, 0, (int)1);
            readData = Marshal.ReadByte(pnt);
            Marshal.FreeHGlobal(pnt);


            if ((Status != FT260_STATUS.FT260_OK) /*|| (writeLength != numBytesToWrite)*/)
            {
                Console.WriteLine("Please check hardware and re-start application");
                return false;
            }
            return true;
        }
        public bool WriteFrame(uint addDevice, uint numBytesToWrite, byte[] data, uint regsize)
        {
            bool check = false;
            if (DLL_Loaded == true && FT_bt_Init.Text == "Disconnect")
            {
                uint writeLength = 0;
                int size = Marshal.SizeOf(data[0]) * data.Length;
                IntPtr pnt = Marshal.AllocHGlobal(size);

                Marshal.Copy(data, 0, pnt, data.Length);
                Status = FT260_I2CMaster_Write(ft260handle, addDevice, FT260_I2C_FLAG.FT260_I2C_START, pnt, numBytesToWrite, ref writeLength);

                if ((Status != FT260_STATUS.FT260_OK) || (writeLength != numBytesToWrite))
                {
                    SetControls_Error("Error", "Please check hardware and re-start application");
                    check = false;
                }
                else
                {
                    check = true;
                    he_tbRxTx.SelectionColor = Color.Blue;
                    //string log = $"I2C Write Start (regSize={regsize}, size={numBytesToWrite}, addr=0x{addDevice:X2}, reg=0x{data[0]:X2}): ";
                    //for (int i = 1; i < data.Length; i++)
                    //{
                    //    log += $"0x{data[i]:X2} ";
                    //}
                    // Xây dựng log message
                    string log = $"I2C Write Start (regSize={regsize}, size={numBytesToWrite}, addr=0x{addDevice:X2}, reg=0x";

                    // Hiển thị địa chỉ register
                    if (regsize == 8)
                    {
                        log += $"{data[0]:X2}): ";
                        // Hiển thị data bytes bắt đầu từ index 1
                        for (int i = 1; i < data.Length; i++)
                        {
                            log += $"0x{data[i]:X2} ";
                        }
                    }
                    else if (regsize == 16)
                    {
                        log += $"{data[0]:X2}{data[1]:X2}): ";
                        // Hiển thị data bytes bắt đầu từ index 2
                        for (int i = 2; i < data.Length; i++)
                        {
                            log += $"0x{data[i]:X2} ";
                        }
                    }
                    log += "\n";
                    Console.WriteLine(log);
                    AddTextAndScrollToBottom(log, Color.Blue, false);
                }

                Marshal.FreeHGlobal(pnt);
            }
            return check;
        }

        public byte[] Readframe(uint adddevice, uint numBytesToRead, byte[] data, uint regsize)
        {
            byte[] Reading = new byte[numBytesToRead];
            UInt32 readLength = 0;
            UInt32 writeLength = 0;
            UInt32 numBytesToWrite = 0;

            int size = Marshal.SizeOf(data[0]) * data.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            //SetControls_Running();

            // ################################# Read Data ###########################
            if (regsize == 8)
            {
                numBytesToWrite = 1;
            }
            else if(regsize == 16)
            {
                numBytesToWrite = 2;
            }
            Marshal.Copy(data, 0, pnt, data.Length);
            Status = FT260_I2CMaster_Write(ft260handle, adddevice, FT260_I2C_FLAG.FT260_I2C_START, pnt, numBytesToWrite, ref writeLength);

            if ((Status != FT260_STATUS.FT260_OK) || (writeLength != numBytesToWrite))
            {
                SetControls_Error("Error", "Please check hardware and re-start application");
                //return;
            }

            //numBytesToRead = 1;
            Status = FT260_I2CMaster_Read(ft260handle, adddevice, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToRead, ref readLength, 5000);

            if (Status == FT260_STATUS.FT260_OTHER_ERROR)
            {
                SetControls_Error("Error", "Please check hardware and re-start application");
                //return;
            }

            if (Status == FT260_STATUS.FT260_I2C_READ_FAIL)
            {
                Console.WriteLine("Read fail!!!");
                string log = "Fail to read from 0x" + adddevice.ToString("X2") + "[reg 0x" + data[0].ToString("X2") + "]";
                Console.WriteLine(log);
                SetControls_Error(log, "");
                //SetControls_Error_AllowReInit("Stopped", "Capture stopped: Click Initialise and the Start to begin again");
                //return;
            }

            if ((Status != FT260_STATUS.FT260_OK) || (readLength != numBytesToRead))
            {
                SetControls_Error("Error", "Please check hardware and re-start application");
                //return;
            }

            Marshal.Copy(pnt, Reading, 0, (int)numBytesToRead);
            Marshal.FreeHGlobal(pnt);
            //Console.WriteLine("Du lieu trong pnt: " + BitConverter.ToString(Reading));
            return Reading;

        }
        #endregion

        #region Update FW radar
        private void radioButtonUART_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in groupBoxCOM.Controls)
            {
                item.Enabled = true;
            }
            foreach (Control item in groupBoxI2C.Controls)
            {
                item.Enabled = false;
            }
            if (!Isuart && DLL_Loaded == true && FT_bt_Init.Text == "Disconnect")
            {
                FT260_Close(ft260handle);
                SetControls_Exit();
            }
            I2C_dtgv.Visible = false;
            Isuart = true;
        }

        private void radioButtonI2C_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in groupBoxCOM.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in groupBoxI2C.Controls)
            {
                item.Enabled = true;
            }
            I2C_dtgv.Visible = true;
            if (Isuart && !serialPort.IsOpen && he_btOpen.Text == "Close")
            {
                serialPort.Close();
                he_State_Connect.BackColor = Color.Red;
                AddTextAndScrollToBottom("\nSerial port " + serialPort.PortName + " closed\r\n", Color.Red, false);
                he_btOpen.Text = "Open";
                he_cbCOM.Enabled = true;
                he_cbBaud.Enabled = true;
                he_cbDataSize.Enabled = true;
                he_cbParity.Enabled = true;
                he_cbStopBit.Enabled = true;
                buttonBrowse.Enabled = false;
                he_cbCOM.Items.Clear();
            }
            Isuart = false;
        }

        private async void bt_BenchStart_Click(object sender, EventArgs e)
        {
            if (IsI2CConnected())
            {
                benchTestStop = false;
                AddTextAndScrollToBottom("------------------Bench test Start---------------------\r\n", Color.Blue, false);
                foreach (Bench item in testBenchList)
                {

                    if (benchTestStop == false)
                    {
                        if (!Isuart)
                        {
                            if (item != null && item.Reg_add != "")
                            {
                                item.Bench_handle(this);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            //BLTN_BLL.Instance.WriteFrame(item.Name);
                        }
                        await Task.Delay(100);
                    }
                }
            }
            else
            {
                MessageBox.Show("I2C not connected or error occurred.");
            }

        }

        private void bt_BenchStop_Click(object sender, EventArgs e)
        {
            benchTestStop = true;
        }
        private byte[] BLTNFWByte;
        public static string FWmd5Hash;
        public static string FWsize;
        private byte I2C_RadarAddress = 0x40;
        private int update_process = 0;
        public static int Update_progress = 0;
        private DateTime globalTime = new DateTime();
        private CancellationTokenSource updateflag = new CancellationTokenSource();
        private Task<bool> updateTask = null;

        static string ComputeMD5(string filePath)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2")); // Chuyển byte sang dạng hex
                    }
                    return sb.ToString();
                }
            }
        }
        private void bt_UpdateOpen_Click(object sender, EventArgs e)
        {
            //appimage
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Appimage files(*.appimage)|*.appimage|Bin files (*.bin)|*.bin|HEX files(*.hex)|*.hex";
            openFileDialog.Title = "Select Firmware File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                tb_BLTNFW.Text = openFileDialog.SafeFileName;
                try
                {
                    //App = System.IO.File.ReadAllBytes(filePath);
                    byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                    if (bytes != null)
                    {
                        BLTNFWByte = bytes;
                        tb_FWImageSize.Text = BLTNFWByte.Length.ToString();
                        FWmd5Hash = ComputeMD5(filePath);
                        tb_Hash.Text = FWmd5Hash;
                        //Console.WriteLine($"MD5 Hash: {BLTN_BLL.FWmd5Hash}");
                    }
                    else
                    {
                        MessageBox.Show("FirmWare is null, please check Firmware more", "Warmning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}");
                }
            }
        }
        private uint ComputeChecksum32(byte[] data)
        {
            uint checksum = 0;
            if (data != null)
            {
                foreach (byte b in data)
                {
                    checksum += b;
                }

                checksum = checksum & 0xFFFFFFFF;

                return checksum;
            }
            return 0;
        }
        private void bt_CheckCRC_Click(object sender, EventArgs e)
        {
            string CRC = ComputeChecksum32(BLTNFWByte).ToString();
            if (CRC == tb_SaveCRC.Text)
            {
                bt_CheckCRC.BackColor = Color.LightGreen;
            }
            else
            {
                bt_CheckCRC.BackColor = Color.Red;
            }

            tb_BLTN_FW_CRC.Text = CRC;
        }
        private async Task<bool> RunUpdateTask(CancellationToken token)
        {
            try
            {
                bt_StartUpdate.Enabled = false;
                globalTime = DateTime.Now;
                tb_Process.Text = "Updating";
                tb_Process.BackColor = Color.Cyan;
                bt_StopUpdate.Focus();
                bool result = await Task.Run(() => UpdateImage(BLTNFWByte, token), token);

                if (result == true)
                {
                    tb_Process.Text = "OK";
                    tb_Process.BackColor = Color.LightGreen;
                    bt_StartUpdate.Focus();
                    AddTextAndScrollToBottom("Finish Update and Verify Image\r\n",Color.Blue,false);
                    UpdateCount.addOK();
                }
                else
                {
                    tb_Process.Text = "NG";
                    tb_Process.BackColor = Color.Red;
                    bt_StopUpdate.Focus();
                    AddTextAndScrollToBottom("Fail to Update\r\n", Color.Red, false);
                    UpdateCount.addNG();
                }



                bt_StartUpdate.Enabled = true;
                testItem = testcase.free;
                return true;
            }
            catch (OperationCanceledException)
            {
                return false; // Trả về false nếu task bị hủy
            }
        }
        private async void bt_StartUpdate_Click(object sender, EventArgs e)
        {
            if (updateTask != null && !updateTask.IsCompleted)
            {
                var result = MessageBox.Show("Task trước đó vẫn đang chạy. Bạn có muốn hủy và chạy task mới?", "Xác nhận",
                                             MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    // Hủy Task cũ
                    updateflag.Cancel();
                    try
                    {
                        await updateTask; // Đợi Task cũ bị hủy
                    }
                    catch (OperationCanceledException)
                    {
                        // Bỏ qua lỗi do hủy task
                    }
                    finally
                    {
                        updateflag.Dispose();
                        updateflag = new CancellationTokenSource(); // Tạo mới Token
                    }
                }
                else
                {
                    return; // Không làm gì cả, tiếp tục chờ task cũ
                }
            }
            updateflag = new CancellationTokenSource();
            // Khởi chạy Task mới
            AddTextAndScrollToBottom("------------------------Radar FW Update------------------------\r\n", Color.Blue, false);
            updateTask = RunUpdateTask(updateflag.Token);
            await updateTask;
            //if (BLTNFWByte.Length > 0)
            //{
            //    tb_Process.Text = "Updating";
            //    tb_Process.BackColor = Color.AliceBlue;
            //}
            //bt_StartUpdate.Enabled = false;
            //globalTime = DateTime.Now;
            //bool result = await Task.Run(() => BLTN_BLL.Instance.UpdateImage(BLTNFWByte, updateflag.Token), updateflag.Token);

        }
        internal bool UpdateImage(byte[] bytes, CancellationToken token)
        {
            UInt32 len = (UInt32)bytes.Length;
            testItem = testcase.UpdateFW;
            update_process = 0;
            if (Isuart)
            {
                //WriteFrame(Camera.Info + " Radar Standby");
                if (SendUploadStart(0, len, token))
                {
                    if (SendUploadPage(bytes, 256, token))
                    {
                        testItem = testcase.Verify;
                        //FWsize = bytes.Length.ToString();
                        if (VerifyUpdate(I2C_RadarAddress, 0x6A))
                        {
                            if (I2C_RadarAddress == 0x40)
                            {
                                serialPort.Write("i2c 1 wr 8 1 40 66 AA\r");
                            }
                            else
                            {
                                serialPort.Write("i2c 1 wr 8 1 42 66 AA\r");
                            }
                            return true;
                        }
                        //return true;
                    }
                }
            }
            else
            {
                //WriteFrame(Camera.Info + " Radar Standby");
                if (SendUploadStart(0, len, token))
                {
                    //Thread.Sleep(3000);
                    //TXDisplay += "waiting for eraser";
                    if (SendUploadPage(bytes, 256, token))
                    {
                        testItem = testcase.Verify;
                        FWsize = bytes.Length.ToString();
                        if (VerifyUpdate(I2C_RadarAddress, 0x6A))
                        {
                            return true;
                        }
                        //return true;
                    }
                    return false;
                }
            }

            return false;
        }
        private bool SendUploadPage(byte[] bytes, int blocksize, CancellationToken token)
        {
            int blocks = (int)Math.Ceiling((bytes.Length * 1.0) / blocksize);
            byte[] block = new byte[blocksize + 4 + 1];
            int retryCnt = 0, retry2 = 0; ;
            byte Status_;
            bool succ = false;
            DateTime updateTime = DateTime.Now;
            update_log = "Start to upload image with Page counts: " + blocks.ToString() + "\r\n";
            for (int i = 0; i < blocks; i++)
            {
                retryCnt = 0;
                succ = false;
                while (!succ)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cập nhật đã bị hủy!");
                        return false; // Trả về false khi bị hủy
                    }
                    int remaining = bytes.Length - (i * blocksize); // Số byte còn lại
                    int copyLength = Math.Min(blocksize, remaining);
                    Array.Clear(block, 0, blocksize + 4 + 1);
                    Array.Copy(bytes, i * blocksize, block, 4 + 1, copyLength);
                    block[0] = (byte)((i * blocksize) >> 24);
                    block[1] = (byte)((i * blocksize) >> 16);
                    block[2] = (byte)((i * blocksize) >> 8);
                    block[3] = (byte)(i * blocksize);
                    block[4] = 0; //Chksum
                    for (int j = 0; j < 256; j++) //calculate checksum
                        block[4] += block[4 + 1 + j];
                    if (UploadSendBlock(I2C_RadarAddress, 0x73, block))
                    {
                        retry2 = 0;
                        while (retry2 < 20)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Cập nhật đã bị hủy!");
                                return false; // Trả về false khi bị hủy
                            }
                            Status_ = I2cReadRegisterOneByte(I2C_RadarAddress, 0x70);
                            if (Status_ == 0x01) // ready
                            {
                                succ = true;
                                //Console.Write((DateTime.Now - updateTime) + "\t" + block[i].ToString());
                                //updateTime = DateTime.Now;
                                //Console.WriteLine();
                                break;
                            }
                            else
                            {
                                if (Status_ == 0x40)
                                {
                                    i = i - 2; // Update Block index error, chang back to previous 2 blocks
                                    if (i < 0)
                                        i = 0;
                                    break;
                                }
                            }
                            retry2++;
                            Thread.Sleep(100);
                        }
                    }
                    retryCnt++;
                    if (retryCnt >= 5)
                        break;
                }
                if (retryCnt == 5)
                {
                    return false;
                }
                else
                {

                }
                //update_process = i + 2;
                //progressBarUpdate.Value =  (update_process * 100 / blocks);
                // if (progressBarUpdate.Value > 100) progressBarUpdate.Value = 100;
                //TimeSpan delta = DateTime.Now - globalTime;
                //Console.WriteLine(update_process * 100 / blocks);
                //Console.WriteLine(delta.ToString(@"hh\:mm\:ss"));
                //lb_UpdateTime.Text = delta.ToString(@"hh\:mm\:ss");
                update_process = i + 2;
                update_log += "Upload Block " + (update_process -1).ToString() + " of " + blocks.ToString() + ". Time: ";
                update_log += (DateTime.Now - updateTime) + "\r\n";
                Update_progress = (update_process * 100 / blocks);
                if (Update_progress > 100) Update_progress = 100;
            }
            //Console.Write((DateTime.Now - updateTime) + "\t");
            //updateTime = DateTime.Now;
            //Console.WriteLine();
            return true;
        }
        private bool SendUploadStart(UInt32 StartAddress, UInt32 length, CancellationToken token)
        {
            byte[] block = new byte[128];
            Array.Clear(block, 0, 128);
            UInt16 reTryCnt = 0;
            byte Status_ = new byte();
            block[0] = (byte)(StartAddress >> 24);
            block[1] = (byte)(StartAddress >> 16);
            block[2] = (byte)(StartAddress >> 8);
            block[3] = (byte)StartAddress;
            block[4] = (byte)(length >> 24);
            block[5] = (byte)(length >> 16);
            block[6] = (byte)(length >> 8);
            block[7] = (byte)length;
            if (UploadSendBlock(I2C_RadarAddress, 0x72, block)) // send start block
            {

                while (reTryCnt < 20)   // check status 20 times
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cập nhật đã bị hủy!");
                        return false; // Trả về false khi bị hủy
                    }
                    Status_ = I2cReadRegisterOneByte(I2C_RadarAddress, 0x70); // Read Status_ Register
                    if ((Status_ & 0x02) != 0x02) // not BUSY
                    {
                        if ((Status_ & 0x01) == 0x01)
                        {
                            // Erase image finished"
                            return true;
                        }
                        else
                            //if ((buf[0] & 0x04) == 0x04) //Error
                            //    return false;
                            return false; // Error happen, can check bit 3,4,5,6,7 for error reason
                    }
                    reTryCnt++;
                    Thread.Sleep(1000);

                }
            }
            else update_log = "Fail to start update.\n";//AddTextAndScrollToBottom("Fail to start update", Color.Red, false);
            return false;
        }
        private bool UploadSendBlock(byte i2C_RadarAddress, byte reg, byte[] block)
        {
            uint num = 0;
            bool result = true;
            //string hexString = BitConverter.ToString(block).Replace("-", " ");
            if (Isuart == true)
            {
                //if (reg == 0x72)
                //{
                //    TX_block_Success = false;
                //    WriteFrame("Radar Update Start " + hexString.Substring(0, 24));
                //    while (num < 100 && TX_block_Success == false)
                //    {
                //        Thread.Sleep(10);
                //        num++;
                //    }
                //    if (num == 100) result = false;
                //}
                //else if (reg == 0x73)
                //{
                //    TX_block_Success = false;
                //    WriteFrame("Radar Update Block " + update_process.ToString() + " " + hexString);
                //    while (num < 100 && TX_block_Success == false)
                //    {
                //        Thread.Sleep(10);
                //        num++;
                //    }
                //    if (num == 100) result = false;
                //}
                if(i2C_RadarAddress != 0x40 && i2C_RadarAddress != 0x42)
                {
                    update_log += "Incorrect device address. Please click Scan button\n";
                    result = false;
                }
                TX_block_Success = false;
                update_log += "\n";
                byte[] datawrite = new byte[] { 0xEF, i2C_RadarAddress, reg }
                    .Concat(block)
                    .Concat(new byte[] { 0x0D })
                    .ToArray();
                serialPort.Write(datawrite, 0, datawrite.Length);
                //string hexString = BitConverter.ToString(datawrite).Replace("-", " ").ToUpper();
                //update_log += hexString + "\n";
                //Thread.Sleep(1000);
                while (num < 100 && TX_block_Success == false)
                {
                    Thread.Sleep(10);
                    num++;
                }
                if (num == 100) result = false;
                //return I2CWrite(ft260handle, (uint)i2C_RadarAddress, datawrite, datawrite.Length);
            }
            else
            {
                //AddTextAndScrollToBottom("Radar Update Start " + hexString.Substring(0, 24) + "\n");
                byte[] datawrite = new byte[] { reg }.Concat(block).ToArray();
                return I2CWrite(ft260handle, (uint)i2C_RadarAddress, datawrite, datawrite.Length);
                //return WriteFrame((uint)i2C_RadarAddress, (uint)datawrite.Length, datawrite, 8);
            }
            return result;
        }
        private byte I2cReadRegisterOneByte(byte radarAdd, byte reg)
        {
            updateStatus = 0xff;
            uint num = 0;
            if (Isuart == true)
            {
                TX_check_Success = false;
                //WriteFrame("Radar Update Check");
                byte[] datawrite = new byte[] { 0xEF, radarAdd , reg }
                    .Concat(new byte[] { 0x0D })
                    .ToArray();
                serialPort.Write(datawrite, 0, datawrite.Length);
                while (num < 100 && TX_check_Success == false)
                {
                    Thread.Sleep(10);
                    num++;
                }
            }
            else
            {
                byte dataread = 0xFF;
                I2CRead(ft260handle, (uint)radarAdd, reg, ref dataread);
                return dataread;
            }
            return updateStatus;
        }
        private bool VerifyUpdate(byte radarAdd, byte reg) //Tam 250321
        {
            uint num = 0;
            if (Isuart == true)
            {
                TX_check_Verify = 0xfe;
                byte[] datawrite = new byte[] { 0xEF, radarAdd, reg }
                   .Concat(new byte[] { 0x0D })
                   .ToArray();
                serialPort.Write(datawrite, 0, datawrite.Length);
                while (num < 100 && TX_check_Verify == 0xfe)
                {
                    Thread.Sleep(10);
                    num++;
                }
                if (num == 100) return false;
                if (TX_check_Verify == 0xfc) return true;
                else return false;
            }
            else
            {
                byte[] readData = new byte[16];
                byte[] regArr = new byte[] { reg };
                I2CRead(ft260handle, (uint)radarAdd, regArr, ref readData, 16);
                string md5fw = BitConverter.ToString(readData).Replace("-", "");
                Console.WriteLine(md5fw);
                if (FWmd5Hash.ToUpper() == md5fw)
                    return true;
            }
            return false;
        }
        private void bt_StopUpdate_Click(object sender, EventArgs e)
        {
            updateflag.Cancel();
            bt_StartUpdate.Enabled = true;
            progressBarUpdate.Value = 0;
            lb_UpdateTime.Text = "00:00:00";
            testItem = testcase.free;
        }
        private async void bt_Scan_Click(object sender, EventArgs e)
        {
            testItem = testcase.Scan;
            if (Isuart)
            {
                serialPort.Write("i2c 1 scan\r");
                await Task.Delay(1000);
            }
            else
            {
                FT_bt_Scan_Click(FT_bt_Scan, EventArgs.Empty);
                await Task.Delay(1000);
            }
            testItem = testcase.free;
        }

        private void bt_Init_Click(object sender, EventArgs e)
        {
            if (Isuart)
            {
                if (I2C_RadarAddress == 0x40)
                {
                    serialPort.Write("i2c 1 init 40\r");
                }
                else
                {
                    serialPort.Write("i2c 1 init 42\r");
                }
            }
        }
        #endregion

    }
    #region Bench class
    public class Bench
    {
        private uint num;
        private string note = "";
        private string readWrite = "rd";
        private string size = "1";
        private string i2C_add = "";
        private string reg_size = "8";
        private string reg_add = "";
        private string data;
        private uint time = 500;
        //private bool isI2CFrame = false;

        public uint Num { get => num; set => num = value; }
        public string ReadWrite { get => readWrite; set => readWrite = value; }
        public string Size { get => size; set => size = value; }
        public string I2C_add { get => i2C_add; set => i2C_add = value; }
        public string Reg_size { get => reg_size; set => reg_size = value; }
        public string Reg_add { get => reg_add; set => reg_add = value; }
        public string Data { get => data; set => data = value; }
        //public bool IsI2CFrame { get => isI2CFrame; set => isI2CFrame = value; }
        public uint Time { get => time; set => time = value; }
        public string Note { get => note; set => note = value; }

        public Bench()
        {

        }
        public Bench(uint num)
        {
            this.Num = num;
        }
        public Bench(uint num, string note, string readwrite, string size, string i2cadd, string regsize, string regadd, string data, uint time)
        {
            this.Num = num;
            this.Note = note;
            this.I2C_add = i2cadd;
            this.Reg_add = regadd;
            this.Data = data;
            this.ReadWrite = readwrite;
            this.Size = size;
            this.Time = time;
            this.Reg_size = regsize;
        }
        public Bench(string[] str)
        {
            uint num, time;
            if (uint.TryParse(str[1], out num) && uint.TryParse(str[8], out time))
            {
                this.Num = num;
                this.ReadWrite = str[2];
                this.Size = str[3];
                this.I2C_add = str[4];
                this.Reg_size = str[5];
                this.Reg_add = str[6];
                this.Data = str[7];
                this.Time = time;
                this.Note = str[9];
            }
        }
        public void Bench_handle(Form1 form)
        {
            if (!string.IsNullOrEmpty(this.Reg_add))
            {
                form.he_State_tx.BackColor = Color.Yellow;

                uint length = uint.Parse(this.Size) + 1;
                uint regsize = uint.Parse(this.Reg_size);

                byte[] data;
                uint regAddressBytes = 0; // Số byte dùng cho địa chỉ register

                if (regsize == 8)
                {
                    data = new byte[length];
                    regAddressBytes = 1;
                    // Chuyển đổi địa chỉ register 8-bit
                    data[0] = byte.Parse(this.Reg_add, NumberStyles.HexNumber);
                }
                else if (regsize == 16)
                {
                    data = new byte[length + 1];
                    regAddressBytes = 2;

                    // Chuyển đổi địa chỉ register 16-bit từ chuỗi hex
                    // Giả sử this.Reg_add có định dạng "HHLL" hoặc "HH LL"
                    string regAddHex = this.Reg_add.Replace(" ", ""); // Loại bỏ khoảng trắng nếu có

                    if (regAddHex.Length >= 4)
                    {
                        // Tách thành 2 byte: High byte và Low byte
                        string highByte = regAddHex.Substring(0, 2);
                        string lowByte = regAddHex.Substring(2, 2);

                        // Lưu vào mảng data theo thứ tự Big-Endian (High byte trước)
                        data[0] = byte.Parse(highByte, NumberStyles.HexNumber);
                        data[1] = byte.Parse(lowByte, NumberStyles.HexNumber);
                    }
                    else
                    {
                        // Nếu địa chỉ ngắn hơn 4 ký tự, xử lý như địa chỉ 16-bit với byte cao = 0
                        ushort regAddr = ushort.Parse(regAddHex, NumberStyles.HexNumber);
                        data[0] = (byte)(regAddr >> 8);    // High byte
                        data[1] = (byte)(regAddr & 0xFF);  // Low byte
                    }
                }
                else
                {
                    // Xử lý trường hợp khác nếu cần
                    return;
                }

                byte devadd = byte.Parse(this.I2C_add, NumberStyles.HexNumber);

                if (this.ReadWrite == "rd")
                {
                    byte[] readbuf = form.Readframe(devadd, length - 1, data, regsize);

                    string log = "Read I2C from 0x" + devadd.ToString("X2") + "[reg 0x";

                    // Hiển thị địa chỉ register
                    if (regsize == 8)
                    {
                        log += data[0].ToString("X2");
                    }
                    else if (regsize == 16)
                    {
                        log += data[0].ToString("X2") + data[1].ToString("X2");
                    }

                    log += "]: ";

                    for (int i = 0; i < length - 1; i++)
                    {
                        log += "0x" + readbuf[i].ToString("X2") + " ";
                    }

                    // Hiển thị ASCII
                    log += " | ASCII: ";
                    for (int i = 0; i < length - 1; i++)
                    {
                        char c = (readbuf[i] >= 32 && readbuf[i] <= 126) ? (char)readbuf[i] : '.';
                        log += c;
                    }

                    log += "\n";
                    form.AddTextAndScrollToBottom(log, Color.Black, false);
                }
                else if (this.ReadWrite == "wr")
                {
                    string[] parts = this.Data.Split(' ');

                    // Bắt đầu ghi data từ vị trí sau địa chỉ register
                    uint dataStartIndex = regAddressBytes;
                    if (regsize == 8)
                    {
                        for (int i = 0; i < length - regAddressBytes; i++)
                        {
                            if (i < parts.Length)
                            {
                                data[dataStartIndex + i] = byte.Parse(parts[i], NumberStyles.HexNumber);
                            }
                        }
                    }
                    else if (regsize == 16)
                    {
                        for (int i = 0; i < length+1 - regAddressBytes; i++)
                        {
                            if (i < parts.Length)
                            {
                                data[dataStartIndex + i] = byte.Parse(parts[i], NumberStyles.HexNumber);
                            }
                        }
                    }

                    bool res = form.WriteFrame(devadd, length + (regAddressBytes - 1), data, regsize);
                    if (res)
                    {
                        form.AddTextAndScrollToBottom("Write complete.\r\n", Color.Black, false);
                    }
                }
            }
            //if (!string.IsNullOrEmpty(this.Reg_add))
            //{
            //    form.he_State_tx.BackColor = Color.Yellow;

            //    uint length = uint.Parse(this.Size) + 1;
            //    uint regsize = uint.Parse(this.Reg_size);
            //    byte[] data;
            //    if (regsize == 8)
            //    {
            //        data = new byte[length];
            //        data[0] = byte.Parse(this.Reg_add, NumberStyles.HexNumber);
            //    }
            //    else if (regsize == 16)
            //    {
            //        data = new byte[length +1];
            //        data[0] = byte.Parse(this.Reg_add, NumberStyles.HexNumber);
            //    }
            //    else
            //    {

            //    }
            //    byte devadd = byte.Parse(this.I2C_add, NumberStyles.HexNumber);
            //    if (this.ReadWrite == "rd")
            //    {
            //        byte[] readbuf = form.Readframe(devadd, length - 1, data, regsize);

            //        string log = "Read I2C from 0x" + devadd.ToString("X2") + "[reg 0x" + data[0].ToString("X2") + "]: ";
            //        for (int i = 0; i < length - 1; i++)
            //        {
            //            log += "0x" + readbuf[i].ToString("X2") + " ";
            //        }

            //        // Hiển thị ASCII
            //        log += " | ASCII: ";
            //        for (int i = 0; i < length - 1; i++)
            //        {
            //            char c = (readbuf[i] >= 32 && readbuf[i] <= 126) ? (char)readbuf[i] : '.';
            //            log += c;
            //        }

            //        log += "\n";
            //        form.AddTextAndScrollToBottom(log, Color.Black, false);
            //    }
            //    else if (this.ReadWrite == "wr")
            //    {
            //        string[] parts = this.Data.Split(' ');
            //        for (int i = 1; i < length; i++)
            //        {
            //            data[i] = byte.Parse(parts[i - 1], NumberStyles.HexNumber);
            //        }

            //        bool res = form.WriteFrame(devadd, length, data, regsize);
            //        if (res)
            //        {
            //            form.AddTextAndScrollToBottom("Write complete.\r\n", Color.Black, false);
            //        }
            //    }
            //}
        }
    }
    #endregion

    #region Update class
    class UpdateCount
    {
        private static uint oK = 0;
        private static uint nG = 0;
        private static uint total = 0;

        //public static uint OK { get => oK; set => oK = value; }
        //public static uint NG { get => nG; set => nG = value; }
        //public static uint Total { get => total; set => total = value; }

        private static Label lblOK = new Label()
        {
            Text = "0",
            Dock = DockStyle.Fill,
            ForeColor = Color.LightGreen,
            TextAlign = ContentAlignment.MiddleCenter

        };
        private static Label lblNG = new Label()
        {
            Text = "0",
            Dock = DockStyle.Fill,
            ForeColor = Color.Red,
            TextAlign = ContentAlignment.MiddleCenter

        };
        private static Label lblTotal = new Label()
        {
            Text = "0",
            Dock = DockStyle.Fill,
            ForeColor = Color.Black,
            TextAlign = ContentAlignment.MiddleCenter

        };

        public static Label LblOK { get => lblOK; set => lblOK = value; }
        public static Label LblNG { get => lblNG; set => lblNG = value; }
        public static Label LblTotal { get => lblTotal; set => lblTotal = value; }

        public static void clear()
        {
            oK = 0;
            nG = 0;
            total = 0;
            if (lblNG.InvokeRequired)
            {
                lblNG.Invoke(new Action(() =>
                {
                    lblOK.Text = oK.ToString();
                    lblNG.Text = nG.ToString();
                    lblTotal.Text = total.ToString();
                }));
            }
            else
            {
                lblOK.Text = oK.ToString();
                lblNG.Text = nG.ToString();
                lblTotal.Text = total.ToString();
            }
        }

        public static void addOK()
        {
            oK++;
            total++;
            if (lblNG.InvokeRequired)
            {
                lblNG.Invoke(new Action(() =>
                {
                    lblOK.Text = oK.ToString();
                    lblNG.Text = nG.ToString();
                    lblTotal.Text = total.ToString();
                }));
            }
            else
            {
                lblOK.Text = oK.ToString();
                lblNG.Text = nG.ToString();
                lblTotal.Text = total.ToString();
            }
        }

        public static void addNG()
        {
            nG++;
            total++;
            if (lblNG.InvokeRequired)
            {
                lblNG.Invoke(new Action(() =>
                {
                    lblOK.Text = oK.ToString();
                    lblNG.Text = nG.ToString();
                    lblTotal.Text = total.ToString();
                }));
            }
            else
            {
                lblOK.Text = oK.ToString();
                lblNG.Text = nG.ToString();
                lblTotal.Text = total.ToString();
            }

        }
    }
    #endregion
}
