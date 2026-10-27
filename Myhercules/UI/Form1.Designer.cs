using System.Windows.Forms;

namespace Myhercules
{
    partial class Form1
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
            System.Windows.Forms.PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.he_btClearAll = new System.Windows.Forms.Button();
            this.CT_tabPage = new System.Windows.Forms.TabControl();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tabPageUDP = new System.Windows.Forms.TabPage();
            this.groupBoxUDP = new System.Windows.Forms.GroupBox();
            this.labelUdpRemoteIP = new System.Windows.Forms.Label();
            this.tb_UdpRemoteIP = new System.Windows.Forms.TextBox();
            this.cb_UdpBroadcast = new System.Windows.Forms.CheckBox();
            this.labelUdpRemotePort = new System.Windows.Forms.Label();
            this.tb_UdpRemotePort = new System.Windows.Forms.TextBox();
            this.labelUdpLocalPort = new System.Windows.Forms.Label();
            this.tb_UdpLocalPort = new System.Windows.Forms.TextBox();
            this.cb_UdpServerEcho = new System.Windows.Forms.CheckBox();
            this.cb_UdpShowRemote = new System.Windows.Forms.CheckBox();
            this.bt_UdpListen = new System.Windows.Forms.Button();
            this.udp_State_Connect = new System.Windows.Forms.PictureBox();
            this.lb_UdpStatus = new System.Windows.Forms.Label();
            this.groupBoxUdpSend = new System.Windows.Forms.GroupBox();
            this.labelUdpSend = new System.Windows.Forms.Label();
            this.tb_UdpSendText = new System.Windows.Forms.TextBox();
            this.rb_UdpAscii = new System.Windows.Forms.RadioButton();
            this.rb_UdpHex = new System.Windows.Forms.RadioButton();
            this.cb_UdpCRLF = new System.Windows.Forms.CheckBox();
            this.bt_UdpSend = new System.Windows.Forms.Button();
            this.bt_UdpClearSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxI2C = new System.Windows.Forms.GroupBox();
            this.bt_BenchStop = new System.Windows.Forms.Button();
            this.bt_BenchStart = new System.Windows.Forms.Button();
            this.FT_cb_Baud = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FT_bt_Add = new System.Windows.Forms.Button();
            this.FT_bt_Scan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStatusSummary = new System.Windows.Forms.Label();
            this.labelStatusDetail = new System.Windows.Forms.Label();
            this.FT_bt_Init = new System.Windows.Forms.Button();
            this.groupBoxCOM = new System.Windows.Forms.GroupBox();
            this.he_cbLF = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.he_State_Connect = new System.Windows.Forms.PictureBox();
            this.he_State_rx = new System.Windows.Forms.PictureBox();
            this.he_State_tx = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.he_cbStopBit = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.he_cbDisplay = new System.Windows.Forms.ComboBox();
            this.he_cbShowTime = new System.Windows.Forms.CheckBox();
            this.he_cbAutoScroll = new System.Windows.Forms.CheckBox();
            this.he_cbCR = new System.Windows.Forms.CheckBox();
            this.he_chxAutoConnect = new System.Windows.Forms.CheckBox();
            this.he_btOpen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.he_cbParity = new System.Windows.Forms.ComboBox();
            this.he_cbDataSize = new System.Windows.Forms.ComboBox();
            this.he_cbBaud = new System.Windows.Forms.ComboBox();
            this.he_cbCOM = new System.Windows.Forms.ComboBox();
            this.gbConnecType = new System.Windows.Forms.GroupBox();
            this.radioButtonI2C = new System.Windows.Forms.RadioButton();
            this.radioButtonUART = new System.Windows.Forms.RadioButton();
            this.tabPageUpdate = new System.Windows.Forms.TabPage();
            this.gB_Cameratype = new System.Windows.Forms.GroupBox();
            this.radioButtonRear = new System.Windows.Forms.RadioButton();
            this.radioButtonFront = new System.Windows.Forms.RadioButton();
            this.bt_Init = new System.Windows.Forms.Button();
            this.bt_Scan = new System.Windows.Forms.Button();
            this.lb_UpdateTime = new System.Windows.Forms.Label();
            this.tb_Process = new System.Windows.Forms.TextBox();
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.bt_StopUpdate = new System.Windows.Forms.Button();
            this.bt_StartUpdate = new System.Windows.Forms.Button();
            this.bt_CheckCRC = new System.Windows.Forms.Button();
            this.tb_SaveCRC = new System.Windows.Forms.TextBox();
            this.tb_BLTN_FW_CRC = new System.Windows.Forms.TextBox();
            this.tb_Hash = new System.Windows.Forms.TextBox();
            this.tb_FWImageSize = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.bt_UpdateOpen = new System.Windows.Forms.Button();
            this.tb_BLTNFW = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPagePW = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripClear = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_Language = new System.Windows.Forms.ComboBox();
            this.he_tbRxTx = new System.Windows.Forms.RichTextBox();
            this.I2C_dtgv = new System.Windows.Forms.DataGridView();
            this.he_dtgvSend = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Dec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ascii = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tran = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTXListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTXListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualCOMPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayCRLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerDP = new System.Windows.Forms.Timer(this.components);
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.CT_tabPage.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.tabPageUDP.SuspendLayout();
            this.groupBoxUDP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udp_State_Connect)).BeginInit();
            this.groupBoxUdpSend.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxI2C.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxCOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.he_State_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.he_State_rx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.he_State_tx)).BeginInit();
            this.gbConnecType.SuspendLayout();
            this.tabPageUpdate.SuspendLayout();
            this.gB_Cameratype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.I2C_dtgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.he_dtgvSend)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            pictureBox1.Location = new System.Drawing.Point(3, 460);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(131, 151);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM18";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // he_btClearAll
            // 
            this.he_btClearAll.Location = new System.Drawing.Point(6, 280);
            this.he_btClearAll.Name = "he_btClearAll";
            this.he_btClearAll.Size = new System.Drawing.Size(121, 23);
            this.he_btClearAll.TabIndex = 5;
            this.he_btClearAll.UseVisualStyleBackColor = true;
            this.he_btClearAll.Click += new System.EventHandler(this.btClearAll_Click);
            // 
            // CT_tabPage
            // 
            this.CT_tabPage.Controls.Add(this.tabPageConfig);
            this.CT_tabPage.Controls.Add(this.tabPageUDP);
            this.CT_tabPage.Controls.Add(this.tabPageUpdate);
            this.CT_tabPage.Controls.Add(this.tabPagePW);
            this.CT_tabPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.CT_tabPage.Location = new System.Drawing.Point(662, 24);
            this.CT_tabPage.Name = "CT_tabPage";
            this.CT_tabPage.SelectedIndex = 0;
            this.CT_tabPage.Size = new System.Drawing.Size(299, 692);
            this.CT_tabPage.TabIndex = 15;
            this.CT_tabPage.Tag = "";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.tableLayoutPanel1);
            this.tabPageConfig.Controls.Add(this.gbConnecType);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(291, 666);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Configure";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxI2C, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxCOM, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 620);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // groupBoxI2C
            // 
            this.groupBoxI2C.Controls.Add(this.bt_BenchStop);
            this.groupBoxI2C.Controls.Add(this.bt_BenchStart);
            this.groupBoxI2C.Controls.Add(this.FT_cb_Baud);
            this.groupBoxI2C.Controls.Add(this.label1);
            this.groupBoxI2C.Controls.Add(this.label11);
            this.groupBoxI2C.Controls.Add(this.FT_bt_Add);
            this.groupBoxI2C.Controls.Add(this.FT_bt_Scan);
            this.groupBoxI2C.Controls.Add(this.groupBox1);
            this.groupBoxI2C.Controls.Add(this.FT_bt_Init);
            this.groupBoxI2C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxI2C.Location = new System.Drawing.Point(3, 3);
            this.groupBoxI2C.Name = "groupBoxI2C";
            this.groupBoxI2C.Size = new System.Drawing.Size(136, 614);
            this.groupBoxI2C.TabIndex = 17;
            this.groupBoxI2C.TabStop = false;
            this.groupBoxI2C.Text = "I2C Config";
            // 
            // bt_BenchStop
            // 
            this.bt_BenchStop.Location = new System.Drawing.Point(30, 533);
            this.bt_BenchStop.Name = "bt_BenchStop";
            this.bt_BenchStop.Size = new System.Drawing.Size(86, 33);
            this.bt_BenchStop.TabIndex = 38;
            this.bt_BenchStop.Text = "STOP";
            this.bt_BenchStop.UseVisualStyleBackColor = true;
            this.bt_BenchStop.Click += new System.EventHandler(this.bt_BenchStop_Click);
            // 
            // bt_BenchStart
            // 
            this.bt_BenchStart.Location = new System.Drawing.Point(30, 494);
            this.bt_BenchStart.Name = "bt_BenchStart";
            this.bt_BenchStart.Size = new System.Drawing.Size(86, 33);
            this.bt_BenchStart.TabIndex = 39;
            this.bt_BenchStart.Text = "START";
            this.bt_BenchStart.UseVisualStyleBackColor = true;
            this.bt_BenchStart.Click += new System.EventHandler(this.bt_BenchStart_Click);
            // 
            // FT_cb_Baud
            // 
            this.FT_cb_Baud.FormattingEnabled = true;
            this.FT_cb_Baud.Items.AddRange(new object[] {
            "100",
            "150",
            "200",
            "250",
            "300",
            "350",
            "400"});
            this.FT_cb_Baud.Location = new System.Drawing.Point(5, 47);
            this.FT_cb_Baud.Name = "FT_cb_Baud";
            this.FT_cb_Baud.Size = new System.Drawing.Size(80, 21);
            this.FT_cb_Baud.TabIndex = 37;
            this.FT_cb_Baud.Text = "400";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Kbps";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "I2C Baud";
            // 
            // FT_bt_Add
            // 
            this.FT_bt_Add.Location = new System.Drawing.Point(30, 455);
            this.FT_bt_Add.Name = "FT_bt_Add";
            this.FT_bt_Add.Size = new System.Drawing.Size(86, 33);
            this.FT_bt_Add.TabIndex = 34;
            this.FT_bt_Add.Text = "Add";
            this.FT_bt_Add.UseVisualStyleBackColor = true;
            this.FT_bt_Add.Click += new System.EventHandler(this.FT_bt_Add_Click);
            // 
            // FT_bt_Scan
            // 
            this.FT_bt_Scan.Location = new System.Drawing.Point(30, 126);
            this.FT_bt_Scan.Name = "FT_bt_Scan";
            this.FT_bt_Scan.Size = new System.Drawing.Size(86, 33);
            this.FT_bt_Scan.TabIndex = 33;
            this.FT_bt_Scan.Text = "Scan";
            this.FT_bt_Scan.UseVisualStyleBackColor = true;
            this.FT_bt_Scan.Click += new System.EventHandler(this.FT_bt_Scan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStatusSummary);
            this.groupBox1.Controls.Add(this.labelStatusDetail);
            this.groupBox1.Location = new System.Drawing.Point(7, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 152);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // labelStatusSummary
            // 
            this.labelStatusSummary.AutoSize = true;
            this.labelStatusSummary.BackColor = System.Drawing.Color.Transparent;
            this.labelStatusSummary.Location = new System.Drawing.Point(11, 21);
            this.labelStatusSummary.Name = "labelStatusSummary";
            this.labelStatusSummary.Size = new System.Drawing.Size(10, 13);
            this.labelStatusSummary.TabIndex = 15;
            this.labelStatusSummary.Text = "-";
            this.labelStatusSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatusDetail
            // 
            this.labelStatusDetail.BackColor = System.Drawing.Color.Transparent;
            this.labelStatusDetail.Location = new System.Drawing.Point(4, 49);
            this.labelStatusDetail.Name = "labelStatusDetail";
            this.labelStatusDetail.Size = new System.Drawing.Size(110, 91);
            this.labelStatusDetail.TabIndex = 19;
            // 
            // FT_bt_Init
            // 
            this.FT_bt_Init.Location = new System.Drawing.Point(30, 86);
            this.FT_bt_Init.Name = "FT_bt_Init";
            this.FT_bt_Init.Size = new System.Drawing.Size(86, 33);
            this.FT_bt_Init.TabIndex = 0;
            this.FT_bt_Init.Text = "Connect";
            this.FT_bt_Init.UseVisualStyleBackColor = true;
            this.FT_bt_Init.Click += new System.EventHandler(this.FT_bt_Init_Click);
            // 
            // groupBoxCOM
            // 
            this.groupBoxCOM.Controls.Add(this.he_cbLF);
            this.groupBoxCOM.Controls.Add(this.label8);
            this.groupBoxCOM.Controls.Add(this.he_State_Connect);
            this.groupBoxCOM.Controls.Add(this.he_State_rx);
            this.groupBoxCOM.Controls.Add(this.he_State_tx);
            this.groupBoxCOM.Controls.Add(this.label9);
            this.groupBoxCOM.Controls.Add(this.he_cbStopBit);
            this.groupBoxCOM.Controls.Add(this.linkLabel1);
            this.groupBoxCOM.Controls.Add(this.label7);
            this.groupBoxCOM.Controls.Add(this.he_cbDisplay);
            this.groupBoxCOM.Controls.Add(this.he_cbShowTime);
            this.groupBoxCOM.Controls.Add(this.he_cbAutoScroll);
            this.groupBoxCOM.Controls.Add(this.he_cbCR);
            this.groupBoxCOM.Controls.Add(this.he_btClearAll);
            this.groupBoxCOM.Controls.Add(pictureBox1);
            this.groupBoxCOM.Controls.Add(this.he_chxAutoConnect);
            this.groupBoxCOM.Controls.Add(this.he_btOpen);
            this.groupBoxCOM.Controls.Add(this.label6);
            this.groupBoxCOM.Controls.Add(this.label5);
            this.groupBoxCOM.Controls.Add(this.label4);
            this.groupBoxCOM.Controls.Add(this.label3);
            this.groupBoxCOM.Controls.Add(this.he_cbParity);
            this.groupBoxCOM.Controls.Add(this.he_cbDataSize);
            this.groupBoxCOM.Controls.Add(this.he_cbBaud);
            this.groupBoxCOM.Controls.Add(this.he_cbCOM);
            this.groupBoxCOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCOM.Location = new System.Drawing.Point(145, 3);
            this.groupBoxCOM.Name = "groupBoxCOM";
            this.groupBoxCOM.Size = new System.Drawing.Size(137, 614);
            this.groupBoxCOM.TabIndex = 16;
            this.groupBoxCOM.TabStop = false;
            this.groupBoxCOM.Text = "Serial Config";
            // 
            // he_cbLF
            // 
            this.he_cbLF.AutoSize = true;
            this.he_cbLF.Location = new System.Drawing.Point(65, 371);
            this.he_cbLF.Name = "he_cbLF";
            this.he_cbLF.Size = new System.Drawing.Size(38, 17);
            this.he_cbLF.TabIndex = 21;
            this.he_cbLF.Text = "LF";
            this.he_cbLF.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = " Tx       Rx     Connected  ";
            // 
            // he_State_Connect
            // 
            this.he_State_Connect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.he_State_Connect.Location = new System.Drawing.Point(80, 324);
            this.he_State_Connect.Name = "he_State_Connect";
            this.he_State_Connect.Size = new System.Drawing.Size(18, 18);
            this.he_State_Connect.TabIndex = 19;
            this.he_State_Connect.TabStop = false;
            // 
            // he_State_rx
            // 
            this.he_State_rx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.he_State_rx.Location = new System.Drawing.Point(40, 324);
            this.he_State_rx.Name = "he_State_rx";
            this.he_State_rx.Size = new System.Drawing.Size(18, 18);
            this.he_State_rx.TabIndex = 18;
            this.he_State_rx.TabStop = false;
            // 
            // he_State_tx
            // 
            this.he_State_tx.BackColor = System.Drawing.Color.Transparent;
            this.he_State_tx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.he_State_tx.Location = new System.Drawing.Point(6, 324);
            this.he_State_tx.Name = "he_State_tx";
            this.he_State_tx.Size = new System.Drawing.Size(18, 18);
            this.he_State_tx.TabIndex = 17;
            this.he_State_tx.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Stop bits";
            // 
            // he_cbStopBit
            // 
            this.he_cbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.he_cbStopBit.FormattingEnabled = true;
            this.he_cbStopBit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.he_cbStopBit.Location = new System.Drawing.Point(6, 189);
            this.he_cbStopBit.Name = "he_cbStopBit";
            this.he_cbStopBit.Size = new System.Drawing.Size(121, 21);
            this.he_cbStopBit.TabIndex = 15;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(9, 530);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Warning: Don\'t Touch";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Display";
            // 
            // he_cbDisplay
            // 
            this.he_cbDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.he_cbDisplay.FormattingEnabled = true;
            this.he_cbDisplay.Items.AddRange(new object[] {
            "HEX",
            "DEC",
            "ASCII"});
            this.he_cbDisplay.Location = new System.Drawing.Point(6, 228);
            this.he_cbDisplay.Name = "he_cbDisplay";
            this.he_cbDisplay.Size = new System.Drawing.Size(121, 21);
            this.he_cbDisplay.TabIndex = 10;
            this.he_cbDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.he_tbRxTx_KeyPress);
            // 
            // he_cbShowTime
            // 
            this.he_cbShowTime.AutoSize = true;
            this.he_cbShowTime.Location = new System.Drawing.Point(6, 417);
            this.he_cbShowTime.Name = "he_cbShowTime";
            this.he_cbShowTime.Size = new System.Drawing.Size(103, 17);
            this.he_cbShowTime.TabIndex = 8;
            this.he_cbShowTime.Text = "Show timestamp";
            this.he_cbShowTime.UseVisualStyleBackColor = true;
            // 
            // he_cbAutoScroll
            // 
            this.he_cbAutoScroll.AutoSize = true;
            this.he_cbAutoScroll.Location = new System.Drawing.Point(6, 394);
            this.he_cbAutoScroll.Name = "he_cbAutoScroll";
            this.he_cbAutoScroll.Size = new System.Drawing.Size(72, 17);
            this.he_cbAutoScroll.TabIndex = 7;
            this.he_cbAutoScroll.Text = "Autoscroll";
            this.he_cbAutoScroll.UseVisualStyleBackColor = true;
            // 
            // he_cbCR
            // 
            this.he_cbCR.AutoSize = true;
            this.he_cbCR.Location = new System.Drawing.Point(6, 371);
            this.he_cbCR.Name = "he_cbCR";
            this.he_cbCR.Size = new System.Drawing.Size(41, 17);
            this.he_cbCR.TabIndex = 4;
            this.he_cbCR.Text = "CR";
            this.he_cbCR.UseVisualStyleBackColor = true;
            // 
            // he_chxAutoConnect
            // 
            this.he_chxAutoConnect.AutoSize = true;
            this.he_chxAutoConnect.Location = new System.Drawing.Point(6, 348);
            this.he_chxAutoConnect.Name = "he_chxAutoConnect";
            this.he_chxAutoConnect.Size = new System.Drawing.Size(91, 17);
            this.he_chxAutoConnect.TabIndex = 3;
            this.he_chxAutoConnect.Text = "Auto Connect";
            this.he_chxAutoConnect.UseVisualStyleBackColor = true;
            // 
            // he_btOpen
            // 
            this.he_btOpen.Location = new System.Drawing.Point(6, 251);
            this.he_btOpen.Name = "he_btOpen";
            this.he_btOpen.Size = new System.Drawing.Size(121, 23);
            this.he_btOpen.TabIndex = 2;
            this.he_btOpen.Text = "Open";
            this.he_btOpen.UseVisualStyleBackColor = true;
            this.he_btOpen.Click += new System.EventHandler(this.he_btOpen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Parity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Baud";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // he_cbParity
            // 
            this.he_cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.he_cbParity.FormattingEnabled = true;
            this.he_cbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mask"});
            this.he_cbParity.Location = new System.Drawing.Point(6, 150);
            this.he_cbParity.Name = "he_cbParity";
            this.he_cbParity.Size = new System.Drawing.Size(121, 21);
            this.he_cbParity.TabIndex = 0;
            // 
            // he_cbDataSize
            // 
            this.he_cbDataSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.he_cbDataSize.FormattingEnabled = true;
            this.he_cbDataSize.Items.AddRange(new object[] {
            "7",
            "8"});
            this.he_cbDataSize.Location = new System.Drawing.Point(6, 111);
            this.he_cbDataSize.Name = "he_cbDataSize";
            this.he_cbDataSize.Size = new System.Drawing.Size(121, 21);
            this.he_cbDataSize.TabIndex = 0;
            // 
            // he_cbBaud
            // 
            this.he_cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.he_cbBaud.FormattingEnabled = true;
            this.he_cbBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600",
            "1000000"});
            this.he_cbBaud.Location = new System.Drawing.Point(6, 70);
            this.he_cbBaud.Name = "he_cbBaud";
            this.he_cbBaud.Size = new System.Drawing.Size(121, 21);
            this.he_cbBaud.TabIndex = 0;
            // 
            // he_cbCOM
            // 
            this.he_cbCOM.BackColor = System.Drawing.SystemColors.Window;
            this.he_cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.he_cbCOM.FormattingEnabled = true;
            this.he_cbCOM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.he_cbCOM.Location = new System.Drawing.Point(6, 31);
            this.he_cbCOM.Name = "he_cbCOM";
            this.he_cbCOM.Size = new System.Drawing.Size(121, 21);
            this.he_cbCOM.TabIndex = 0;
            this.he_cbCOM.Click += new System.EventHandler(this.he_cbCOM_Click);
            // 
            // gbConnecType
            // 
            this.gbConnecType.Controls.Add(this.radioButtonI2C);
            this.gbConnecType.Controls.Add(this.radioButtonUART);
            this.gbConnecType.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnecType.Location = new System.Drawing.Point(3, 3);
            this.gbConnecType.Name = "gbConnecType";
            this.gbConnecType.Size = new System.Drawing.Size(285, 40);
            this.gbConnecType.TabIndex = 18;
            this.gbConnecType.TabStop = false;
            this.gbConnecType.Text = "Connection Type";
            // 
            // radioButtonI2C
            // 
            this.radioButtonI2C.AutoSize = true;
            this.radioButtonI2C.Location = new System.Drawing.Point(5, 16);
            this.radioButtonI2C.Name = "radioButtonI2C";
            this.radioButtonI2C.Size = new System.Drawing.Size(41, 17);
            this.radioButtonI2C.TabIndex = 0;
            this.radioButtonI2C.Text = "I2C";
            this.radioButtonI2C.UseVisualStyleBackColor = true;
            this.radioButtonI2C.CheckedChanged += new System.EventHandler(this.radioButtonI2C_CheckedChanged);
            // 
            // radioButtonUART
            // 
            this.radioButtonUART.AutoSize = true;
            this.radioButtonUART.Location = new System.Drawing.Point(46, 16);
            this.radioButtonUART.Name = "radioButtonUART";
            this.radioButtonUART.Size = new System.Drawing.Size(55, 17);
            this.radioButtonUART.TabIndex = 0;
            this.radioButtonUART.Text = "UART";
            this.radioButtonUART.UseVisualStyleBackColor = true;
            this.radioButtonUART.CheckedChanged += new System.EventHandler(this.radioButtonUART_CheckedChanged);
            // 
            // tabPageUpdate
            // 
            this.tabPageUpdate.Controls.Add(this.gB_Cameratype);
            this.tabPageUpdate.Controls.Add(this.bt_Init);
            this.tabPageUpdate.Controls.Add(this.bt_Scan);
            this.tabPageUpdate.Controls.Add(this.lb_UpdateTime);
            this.tabPageUpdate.Controls.Add(this.tb_Process);
            this.tabPageUpdate.Controls.Add(this.progressBarUpdate);
            this.tabPageUpdate.Controls.Add(this.bt_StopUpdate);
            this.tabPageUpdate.Controls.Add(this.bt_StartUpdate);
            this.tabPageUpdate.Controls.Add(this.bt_CheckCRC);
            this.tabPageUpdate.Controls.Add(this.tb_SaveCRC);
            this.tabPageUpdate.Controls.Add(this.tb_BLTN_FW_CRC);
            this.tabPageUpdate.Controls.Add(this.tb_Hash);
            this.tabPageUpdate.Controls.Add(this.tb_FWImageSize);
            this.tabPageUpdate.Controls.Add(this.label37);
            this.tabPageUpdate.Controls.Add(this.label36);
            this.tabPageUpdate.Controls.Add(this.label35);
            this.tabPageUpdate.Controls.Add(this.bt_UpdateOpen);
            this.tabPageUpdate.Controls.Add(this.tb_BLTNFW);
            this.tabPageUpdate.Controls.Add(this.label29);
            this.tabPageUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdate.Name = "tabPageUpdate";
            this.tabPageUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdate.Size = new System.Drawing.Size(291, 664);
            this.tabPageUpdate.TabIndex = 2;
            this.tabPageUpdate.Text = "Update";
            this.tabPageUpdate.UseVisualStyleBackColor = true;
            // 
            // gB_Cameratype
            // 
            this.gB_Cameratype.Controls.Add(this.radioButtonRear);
            this.gB_Cameratype.Controls.Add(this.radioButtonFront);
            this.gB_Cameratype.Location = new System.Drawing.Point(144, 373);
            this.gB_Cameratype.Name = "gB_Cameratype";
            this.gB_Cameratype.Size = new System.Drawing.Size(105, 77);
            this.gB_Cameratype.TabIndex = 22;
            this.gB_Cameratype.TabStop = false;
            this.gB_Cameratype.Text = "Camera Type";
            // 
            // radioButtonRear
            // 
            this.radioButtonRear.AutoSize = true;
            this.radioButtonRear.Location = new System.Drawing.Point(5, 49);
            this.radioButtonRear.Name = "radioButtonRear";
            this.radioButtonRear.Size = new System.Drawing.Size(48, 17);
            this.radioButtonRear.TabIndex = 0;
            this.radioButtonRear.Text = "Rear";
            this.radioButtonRear.UseVisualStyleBackColor = true;
            // 
            // radioButtonFront
            // 
            this.radioButtonFront.AutoSize = true;
            this.radioButtonFront.Checked = true;
            this.radioButtonFront.Location = new System.Drawing.Point(5, 22);
            this.radioButtonFront.Name = "radioButtonFront";
            this.radioButtonFront.Size = new System.Drawing.Size(49, 17);
            this.radioButtonFront.TabIndex = 0;
            this.radioButtonFront.TabStop = true;
            this.radioButtonFront.Text = "Front";
            this.radioButtonFront.UseVisualStyleBackColor = true;
            // 
            // bt_Init
            // 
            this.bt_Init.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Init.Location = new System.Drawing.Point(7, 415);
            this.bt_Init.Name = "bt_Init";
            this.bt_Init.Size = new System.Drawing.Size(117, 35);
            this.bt_Init.TabIndex = 21;
            this.bt_Init.Text = "Init";
            this.bt_Init.UseVisualStyleBackColor = true;
            this.bt_Init.Click += new System.EventHandler(this.bt_Init_Click);
            // 
            // bt_Scan
            // 
            this.bt_Scan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Scan.Location = new System.Drawing.Point(7, 373);
            this.bt_Scan.Name = "bt_Scan";
            this.bt_Scan.Size = new System.Drawing.Size(117, 35);
            this.bt_Scan.TabIndex = 20;
            this.bt_Scan.Text = "Scan";
            this.bt_Scan.UseVisualStyleBackColor = true;
            this.bt_Scan.Click += new System.EventHandler(this.bt_Scan_Click);
            // 
            // lb_UpdateTime
            // 
            this.lb_UpdateTime.AutoSize = true;
            this.lb_UpdateTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UpdateTime.ForeColor = System.Drawing.Color.Blue;
            this.lb_UpdateTime.Location = new System.Drawing.Point(208, 607);
            this.lb_UpdateTime.Name = "lb_UpdateTime";
            this.lb_UpdateTime.Size = new System.Drawing.Size(90, 22);
            this.lb_UpdateTime.TabIndex = 19;
            this.lb_UpdateTime.Text = "00:00:00";
            // 
            // tb_Process
            // 
            this.tb_Process.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Process.Location = new System.Drawing.Point(137, 255);
            this.tb_Process.Name = "tb_Process";
            this.tb_Process.Size = new System.Drawing.Size(149, 50);
            this.tb_Process.TabIndex = 18;
            this.tb_Process.Text = "Process";
            this.tb_Process.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBarUpdate
            // 
            this.progressBarUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarUpdate.Location = new System.Drawing.Point(3, 636);
            this.progressBarUpdate.Name = "progressBarUpdate";
            this.progressBarUpdate.Size = new System.Drawing.Size(285, 25);
            this.progressBarUpdate.Step = 1;
            this.progressBarUpdate.TabIndex = 17;
            // 
            // bt_StopUpdate
            // 
            this.bt_StopUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_StopUpdate.Location = new System.Drawing.Point(7, 286);
            this.bt_StopUpdate.Name = "bt_StopUpdate";
            this.bt_StopUpdate.Size = new System.Drawing.Size(117, 35);
            this.bt_StopUpdate.TabIndex = 15;
            this.bt_StopUpdate.Text = "STOP";
            this.bt_StopUpdate.UseVisualStyleBackColor = true;
            this.bt_StopUpdate.Click += new System.EventHandler(this.bt_StopUpdate_Click);
            // 
            // bt_StartUpdate
            // 
            this.bt_StartUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_StartUpdate.Location = new System.Drawing.Point(7, 245);
            this.bt_StartUpdate.Name = "bt_StartUpdate";
            this.bt_StartUpdate.Size = new System.Drawing.Size(117, 35);
            this.bt_StartUpdate.TabIndex = 16;
            this.bt_StartUpdate.Text = "START";
            this.bt_StartUpdate.UseVisualStyleBackColor = true;
            this.bt_StartUpdate.Click += new System.EventHandler(this.bt_StartUpdate_Click);
            // 
            // bt_CheckCRC
            // 
            this.bt_CheckCRC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_CheckCRC.Location = new System.Drawing.Point(219, 184);
            this.bt_CheckCRC.Name = "bt_CheckCRC";
            this.bt_CheckCRC.Size = new System.Drawing.Size(68, 30);
            this.bt_CheckCRC.TabIndex = 14;
            this.bt_CheckCRC.Text = "Check Sum";
            this.bt_CheckCRC.UseVisualStyleBackColor = true;
            this.bt_CheckCRC.Click += new System.EventHandler(this.bt_CheckCRC_Click);
            // 
            // tb_SaveCRC
            // 
            this.tb_SaveCRC.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_SaveCRC.Location = new System.Drawing.Point(5, 181);
            this.tb_SaveCRC.Name = "tb_SaveCRC";
            this.tb_SaveCRC.Size = new System.Drawing.Size(104, 32);
            this.tb_SaveCRC.TabIndex = 12;
            this.tb_SaveCRC.Text = "29935152";
            // 
            // tb_BLTN_FW_CRC
            // 
            this.tb_BLTN_FW_CRC.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_BLTN_FW_CRC.Location = new System.Drawing.Point(114, 181);
            this.tb_BLTN_FW_CRC.Name = "tb_BLTN_FW_CRC";
            this.tb_BLTN_FW_CRC.ReadOnly = true;
            this.tb_BLTN_FW_CRC.Size = new System.Drawing.Size(104, 32);
            this.tb_BLTN_FW_CRC.TabIndex = 13;
            this.tb_BLTN_FW_CRC.Text = "FW CRC";
            // 
            // tb_Hash
            // 
            this.tb_Hash.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Hash.Location = new System.Drawing.Point(5, 90);
            this.tb_Hash.Name = "tb_Hash";
            this.tb_Hash.ReadOnly = true;
            this.tb_Hash.Size = new System.Drawing.Size(281, 21);
            this.tb_Hash.TabIndex = 10;
            // 
            // tb_FWImageSize
            // 
            this.tb_FWImageSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_FWImageSize.Location = new System.Drawing.Point(5, 132);
            this.tb_FWImageSize.Name = "tb_FWImageSize";
            this.tb_FWImageSize.ReadOnly = true;
            this.tb_FWImageSize.Size = new System.Drawing.Size(244, 21);
            this.tb_FWImageSize.TabIndex = 11;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 74);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 13);
            this.label37.TabIndex = 7;
            this.label37.Text = "Hash";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(5, 116);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(27, 13);
            this.label36.TabIndex = 8;
            this.label36.Text = "Size";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(254, 138);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(33, 13);
            this.label35.TabIndex = 9;
            this.label35.Text = "Bytes";
            // 
            // bt_UpdateOpen
            // 
            this.bt_UpdateOpen.Location = new System.Drawing.Point(218, 11);
            this.bt_UpdateOpen.Name = "bt_UpdateOpen";
            this.bt_UpdateOpen.Size = new System.Drawing.Size(68, 30);
            this.bt_UpdateOpen.TabIndex = 6;
            this.bt_UpdateOpen.Text = "Open";
            this.bt_UpdateOpen.UseVisualStyleBackColor = true;
            this.bt_UpdateOpen.Click += new System.EventHandler(this.bt_UpdateOpen_Click);
            // 
            // tb_BLTNFW
            // 
            this.tb_BLTNFW.Location = new System.Drawing.Point(5, 48);
            this.tb_BLTNFW.Name = "tb_BLTNFW";
            this.tb_BLTNFW.ReadOnly = true;
            this.tb_BLTNFW.Size = new System.Drawing.Size(281, 20);
            this.tb_BLTNFW.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 13);
            this.label29.TabIndex = 4;
            this.label29.Text = "File";
            // 
            // tabPageUDP
            // 
            this.tabPageUDP.Controls.Add(this.groupBoxUdpSend);
            this.tabPageUDP.Controls.Add(this.groupBoxUDP);
            this.tabPageUDP.Location = new System.Drawing.Point(4, 22);
            this.tabPageUDP.Name = "tabPageUDP";
            this.tabPageUDP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUDP.Size = new System.Drawing.Size(291, 664);
            this.tabPageUDP.TabIndex = 4;
            this.tabPageUDP.Text = "UDP";
            this.tabPageUDP.UseVisualStyleBackColor = true;
            // 
            // groupBoxUDP
            // 
            this.groupBoxUDP.Controls.Add(this.udp_State_Connect);
            this.groupBoxUDP.Controls.Add(this.lb_UdpStatus);
            this.groupBoxUDP.Controls.Add(this.bt_UdpListen);
            this.groupBoxUDP.Controls.Add(this.cb_UdpServerEcho);
            this.groupBoxUDP.Controls.Add(this.cb_UdpShowRemote);
            this.groupBoxUDP.Controls.Add(this.tb_UdpLocalPort);
            this.groupBoxUDP.Controls.Add(this.labelUdpLocalPort);
            this.groupBoxUDP.Controls.Add(this.tb_UdpRemotePort);
            this.groupBoxUDP.Controls.Add(this.labelUdpRemotePort);
            this.groupBoxUDP.Controls.Add(this.cb_UdpBroadcast);
            this.groupBoxUDP.Controls.Add(this.tb_UdpRemoteIP);
            this.groupBoxUDP.Controls.Add(this.labelUdpRemoteIP);
            this.groupBoxUDP.Location = new System.Drawing.Point(6, 6);
            this.groupBoxUDP.Name = "groupBoxUDP";
            this.groupBoxUDP.Size = new System.Drawing.Size(279, 215);
            this.groupBoxUDP.TabIndex = 0;
            this.groupBoxUDP.TabStop = false;
            this.groupBoxUDP.Text = "UDP Setup";
            // 
            // labelUdpRemoteIP
            // 
            this.labelUdpRemoteIP.AutoSize = true;
            this.labelUdpRemoteIP.Location = new System.Drawing.Point(10, 22);
            this.labelUdpRemoteIP.Name = "labelUdpRemoteIP";
            this.labelUdpRemoteIP.Size = new System.Drawing.Size(120, 13);
            this.labelUdpRemoteIP.TabIndex = 0;
            this.labelUdpRemoteIP.Text = "Remote IP (Module IP):";
            // 
            // tb_UdpRemoteIP
            // 
            this.tb_UdpRemoteIP.Location = new System.Drawing.Point(10, 40);
            this.tb_UdpRemoteIP.Name = "tb_UdpRemoteIP";
            this.tb_UdpRemoteIP.Size = new System.Drawing.Size(175, 20);
            this.tb_UdpRemoteIP.TabIndex = 1;
            this.tb_UdpRemoteIP.Text = "192.168.1.100";
            // 
            // cb_UdpBroadcast
            // 
            this.cb_UdpBroadcast.AutoSize = true;
            this.cb_UdpBroadcast.Location = new System.Drawing.Point(195, 42);
            this.cb_UdpBroadcast.Name = "cb_UdpBroadcast";
            this.cb_UdpBroadcast.Size = new System.Drawing.Size(74, 17);
            this.cb_UdpBroadcast.TabIndex = 2;
            this.cb_UdpBroadcast.Text = "Broadcast";
            this.cb_UdpBroadcast.UseVisualStyleBackColor = true;
            this.cb_UdpBroadcast.CheckedChanged += new System.EventHandler(this.cb_UdpBroadcast_CheckedChanged);
            // 
            // labelUdpRemotePort
            // 
            this.labelUdpRemotePort.AutoSize = true;
            this.labelUdpRemotePort.Location = new System.Drawing.Point(10, 68);
            this.labelUdpRemotePort.Name = "labelUdpRemotePort";
            this.labelUdpRemotePort.Size = new System.Drawing.Size(69, 13);
            this.labelUdpRemotePort.TabIndex = 3;
            this.labelUdpRemotePort.Text = "Remote Port:";
            // 
            // tb_UdpRemotePort
            // 
            this.tb_UdpRemotePort.Location = new System.Drawing.Point(10, 86);
            this.tb_UdpRemotePort.Name = "tb_UdpRemotePort";
            this.tb_UdpRemotePort.Size = new System.Drawing.Size(115, 20);
            this.tb_UdpRemotePort.TabIndex = 4;
            this.tb_UdpRemotePort.Text = "5000";
            // 
            // labelUdpLocalPort
            // 
            this.labelUdpLocalPort.AutoSize = true;
            this.labelUdpLocalPort.Location = new System.Drawing.Point(145, 68);
            this.labelUdpLocalPort.Name = "labelUdpLocalPort";
            this.labelUdpLocalPort.Size = new System.Drawing.Size(58, 13);
            this.labelUdpLocalPort.TabIndex = 5;
            this.labelUdpLocalPort.Text = "Local Port:";
            // 
            // tb_UdpLocalPort
            // 
            this.tb_UdpLocalPort.Location = new System.Drawing.Point(145, 86);
            this.tb_UdpLocalPort.Name = "tb_UdpLocalPort";
            this.tb_UdpLocalPort.Size = new System.Drawing.Size(115, 20);
            this.tb_UdpLocalPort.TabIndex = 6;
            this.tb_UdpLocalPort.Text = "5000";
            // 
            // cb_UdpServerEcho
            // 
            this.cb_UdpServerEcho.AutoSize = true;
            this.cb_UdpServerEcho.Location = new System.Drawing.Point(10, 118);
            this.cb_UdpServerEcho.Name = "cb_UdpServerEcho";
            this.cb_UdpServerEcho.Size = new System.Drawing.Size(84, 17);
            this.cb_UdpServerEcho.TabIndex = 7;
            this.cb_UdpServerEcho.Text = "Server echo";
            this.cb_UdpServerEcho.UseVisualStyleBackColor = true;
            // 
            // cb_UdpShowRemote
            // 
            this.cb_UdpShowRemote.AutoSize = true;
            this.cb_UdpShowRemote.Checked = true;
            this.cb_UdpShowRemote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_UdpShowRemote.Location = new System.Drawing.Point(105, 118);
            this.cb_UdpShowRemote.Name = "cb_UdpShowRemote";
            this.cb_UdpShowRemote.Size = new System.Drawing.Size(107, 17);
            this.cb_UdpShowRemote.TabIndex = 8;
            this.cb_UdpShowRemote.Text = "Show Remote IP";
            this.cb_UdpShowRemote.UseVisualStyleBackColor = true;
            // 
            // bt_UdpListen
            // 
            this.bt_UdpListen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_UdpListen.Location = new System.Drawing.Point(10, 150);
            this.bt_UdpListen.Name = "bt_UdpListen";
            this.bt_UdpListen.Size = new System.Drawing.Size(115, 36);
            this.bt_UdpListen.TabIndex = 8;
            this.bt_UdpListen.Text = "Listen";
            this.bt_UdpListen.UseVisualStyleBackColor = true;
            this.bt_UdpListen.Click += new System.EventHandler(this.bt_UdpListen_Click);
            // 
            // udp_State_Connect
            // 
            this.udp_State_Connect.BackColor = System.Drawing.Color.Red;
            this.udp_State_Connect.Location = new System.Drawing.Point(145, 150);
            this.udp_State_Connect.Name = "udp_State_Connect";
            this.udp_State_Connect.Size = new System.Drawing.Size(36, 36);
            this.udp_State_Connect.TabIndex = 9;
            this.udp_State_Connect.TabStop = false;
            // 
            // lb_UdpStatus
            // 
            this.lb_UdpStatus.AutoSize = true;
            this.lb_UdpStatus.Location = new System.Drawing.Point(188, 162);
            this.lb_UdpStatus.Name = "lb_UdpStatus";
            this.lb_UdpStatus.Size = new System.Drawing.Size(39, 13);
            this.lb_UdpStatus.TabIndex = 10;
            this.lb_UdpStatus.Text = "Closed";
            // 
            // groupBoxUdpSend
            // 
            this.groupBoxUdpSend.Controls.Add(this.bt_UdpClearSend);
            this.groupBoxUdpSend.Controls.Add(this.bt_UdpSend);
            this.groupBoxUdpSend.Controls.Add(this.cb_UdpCRLF);
            this.groupBoxUdpSend.Controls.Add(this.rb_UdpHex);
            this.groupBoxUdpSend.Controls.Add(this.rb_UdpAscii);
            this.groupBoxUdpSend.Controls.Add(this.tb_UdpSendText);
            this.groupBoxUdpSend.Controls.Add(this.labelUdpSend);
            this.groupBoxUdpSend.Location = new System.Drawing.Point(6, 230);
            this.groupBoxUdpSend.Name = "groupBoxUdpSend";
            this.groupBoxUdpSend.Size = new System.Drawing.Size(279, 175);
            this.groupBoxUdpSend.TabIndex = 1;
            this.groupBoxUdpSend.TabStop = false;
            this.groupBoxUdpSend.Text = "UDP Send";
            // 
            // labelUdpSend
            // 
            this.labelUdpSend.AutoSize = true;
            this.labelUdpSend.Location = new System.Drawing.Point(10, 22);
            this.labelUdpSend.Name = "labelUdpSend";
            this.labelUdpSend.Size = new System.Drawing.Size(71, 13);
            this.labelUdpSend.TabIndex = 0;
            this.labelUdpSend.Text = "Data to send:";
            // 
            // tb_UdpSendText
            // 
            this.tb_UdpSendText.Location = new System.Drawing.Point(10, 40);
            this.tb_UdpSendText.Multiline = true;
            this.tb_UdpSendText.Name = "tb_UdpSendText";
            this.tb_UdpSendText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_UdpSendText.Size = new System.Drawing.Size(250, 48);
            this.tb_UdpSendText.TabIndex = 1;
            // 
            // rb_UdpAscii
            // 
            this.rb_UdpAscii.AutoSize = true;
            this.rb_UdpAscii.Checked = true;
            this.rb_UdpAscii.Location = new System.Drawing.Point(10, 96);
            this.rb_UdpAscii.Name = "rb_UdpAscii";
            this.rb_UdpAscii.Size = new System.Drawing.Size(52, 17);
            this.rb_UdpAscii.TabIndex = 2;
            this.rb_UdpAscii.TabStop = true;
            this.rb_UdpAscii.Text = "ASCII";
            this.rb_UdpAscii.UseVisualStyleBackColor = true;
            // 
            // rb_UdpHex
            // 
            this.rb_UdpHex.AutoSize = true;
            this.rb_UdpHex.Location = new System.Drawing.Point(68, 96);
            this.rb_UdpHex.Name = "rb_UdpHex";
            this.rb_UdpHex.Size = new System.Drawing.Size(47, 17);
            this.rb_UdpHex.TabIndex = 3;
            this.rb_UdpHex.Text = "HEX";
            this.rb_UdpHex.UseVisualStyleBackColor = true;
            // 
            // cb_UdpCRLF
            // 
            this.cb_UdpCRLF.AutoSize = true;
            this.cb_UdpCRLF.Checked = true;
            this.cb_UdpCRLF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_UdpCRLF.Location = new System.Drawing.Point(125, 96);
            this.cb_UdpCRLF.Name = "cb_UdpCRLF";
            this.cb_UdpCRLF.Size = new System.Drawing.Size(65, 17);
            this.cb_UdpCRLF.TabIndex = 4;
            this.cb_UdpCRLF.Text = "+CR/LF";
            this.cb_UdpCRLF.UseVisualStyleBackColor = true;
            // 
            // bt_UdpSend
            // 
            this.bt_UdpSend.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_UdpSend.Location = new System.Drawing.Point(10, 126);
            this.bt_UdpSend.Name = "bt_UdpSend";
            this.bt_UdpSend.Size = new System.Drawing.Size(115, 35);
            this.bt_UdpSend.TabIndex = 5;
            this.bt_UdpSend.Text = "Send";
            this.bt_UdpSend.UseVisualStyleBackColor = true;
            this.bt_UdpSend.Click += new System.EventHandler(this.bt_UdpSend_Click);
            // 
            // bt_UdpClearSend
            // 
            this.bt_UdpClearSend.Location = new System.Drawing.Point(145, 126);
            this.bt_UdpClearSend.Name = "bt_UdpClearSend";
            this.bt_UdpClearSend.Size = new System.Drawing.Size(75, 35);
            this.bt_UdpClearSend.TabIndex = 6;
            this.bt_UdpClearSend.Text = "Clear";
            this.bt_UdpClearSend.UseVisualStyleBackColor = true;
            this.bt_UdpClearSend.Click += new System.EventHandler(this.bt_UdpClearSend_Click);
            // 
            // tabPagePW
            // 
            this.tabPagePW.Location = new System.Drawing.Point(4, 22);
            this.tabPagePW.Name = "tabPagePW";
            this.tabPagePW.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePW.Size = new System.Drawing.Size(291, 664);
            this.tabPagePW.TabIndex = 3;
            this.tabPagePW.Text = "Power Supply";
            this.tabPagePW.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.I2C_dtgv);
            this.splitContainer1.Panel2.Controls.Add(this.he_dtgvSend);
            this.splitContainer1.Size = new System.Drawing.Size(662, 692);
            this.splitContainer1.SplitterDistance = 435;
            this.splitContainer1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.he_tbRxTx, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(662, 435);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(662, 27);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripClear
            // 
            this.toolStripClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClear.Image")));
            this.toolStripClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClear.Name = "toolStripClear";
            this.toolStripClear.Size = new System.Drawing.Size(23, 24);
            this.toolStripClear.Text = "toolStripButton1";
            this.toolStripClear.Click += new System.EventHandler(this.toolStripClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonBrowse);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cb_Language);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 21);
            this.panel1.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateTimePicker1.Location = new System.Drawing.Point(193, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Received/Send data";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBrowse.Location = new System.Drawing.Point(393, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 21);
            this.buttonBrowse.TabIndex = 60;
            this.buttonBrowse.Text = "Send File";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Location = new System.Drawing.Point(468, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 21);
            this.label10.TabIndex = 58;
            this.label10.Text = "Language";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Language
            // 
            this.cb_Language.Dock = System.Windows.Forms.DockStyle.Right;
            this.cb_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Language.FormattingEnabled = true;
            this.cb_Language.Items.AddRange(new object[] {
            "Korean",
            "Vietnamese",
            "English"});
            this.cb_Language.Location = new System.Drawing.Point(528, 0);
            this.cb_Language.Name = "cb_Language";
            this.cb_Language.Size = new System.Drawing.Size(128, 21);
            this.cb_Language.TabIndex = 59;
            this.cb_Language.SelectedIndexChanged += new System.EventHandler(this.cb_Language_SelectedIndexChanged);
            // 
            // he_tbRxTx
            // 
            this.he_tbRxTx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.he_tbRxTx.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.he_tbRxTx.Location = new System.Drawing.Point(3, 57);
            this.he_tbRxTx.Name = "he_tbRxTx";
            this.he_tbRxTx.Size = new System.Drawing.Size(656, 375);
            this.he_tbRxTx.TabIndex = 6;
            this.he_tbRxTx.Text = "";
            this.he_tbRxTx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.he_tbRxTx_KeyPress);
            // 
            // I2C_dtgv
            // 
            this.I2C_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.I2C_dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.I2C_dtgv.Location = new System.Drawing.Point(0, 0);
            this.I2C_dtgv.Name = "I2C_dtgv";
            this.I2C_dtgv.RowTemplate.Height = 23;
            this.I2C_dtgv.Size = new System.Drawing.Size(662, 253);
            this.I2C_dtgv.TabIndex = 1;
            this.I2C_dtgv.Visible = false;
            this.I2C_dtgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.I2C_dtgv_CellClick);
            // 
            // he_dtgvSend
            // 
            this.he_dtgvSend.BackgroundColor = System.Drawing.Color.White;
            this.he_dtgvSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.he_dtgvSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Hex,
            this.Dec,
            this.Ascii,
            this.Tran,
            this.Note});
            this.he_dtgvSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.he_dtgvSend.Location = new System.Drawing.Point(0, 0);
            this.he_dtgvSend.Name = "he_dtgvSend";
            this.he_dtgvSend.Size = new System.Drawing.Size(662, 253);
            this.he_dtgvSend.TabIndex = 0;
            this.he_dtgvSend.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.he_dtgvSend_CellClick);
            this.he_dtgvSend.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.he_dtgvSend_RowsAdded);
            this.he_dtgvSend.Resize += new System.EventHandler(this.he_dtgvSend_Resize);
            // 
            // Data
            // 
            this.Data.HeaderText = "Message";
            this.Data.Name = "Data";
            this.Data.Width = 500;
            // 
            // Hex
            // 
            this.Hex.HeaderText = "Hex";
            this.Hex.Name = "Hex";
            this.Hex.Width = 35;
            // 
            // Dec
            // 
            this.Dec.HeaderText = "Dec";
            this.Dec.Name = "Dec";
            this.Dec.Width = 35;
            // 
            // Ascii
            // 
            this.Ascii.HeaderText = "Ascii";
            this.Ascii.Name = "Ascii";
            this.Ascii.Width = 35;
            // 
            // Tran
            // 
            this.Tran.HeaderText = "Send";
            this.Tran.Name = "Tran";
            this.Tran.Text = "Send";
            this.Tran.Width = 50;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 61;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTXListToolStripMenuItem,
            this.saveTXListToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadTXListToolStripMenuItem
            // 
            this.loadTXListToolStripMenuItem.Name = "loadTXListToolStripMenuItem";
            this.loadTXListToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.loadTXListToolStripMenuItem.Text = "Load TX list";
            this.loadTXListToolStripMenuItem.Click += new System.EventHandler(this.loadTXListToolStripMenuItem_Click);
            // 
            // saveTXListToolStripMenuItem
            // 
            this.saveTXListToolStripMenuItem.Name = "saveTXListToolStripMenuItem";
            this.saveTXListToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveTXListToolStripMenuItem.Text = "Save TX list";
            this.saveTXListToolStripMenuItem.Click += new System.EventHandler(this.saveTXListToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.virtualCOMPortToolStripMenuItem,
            this.displayCRLFToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // virtualCOMPortToolStripMenuItem
            // 
            this.virtualCOMPortToolStripMenuItem.Name = "virtualCOMPortToolStripMenuItem";
            this.virtualCOMPortToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.virtualCOMPortToolStripMenuItem.Text = "Virtual COM Port";
            this.virtualCOMPortToolStripMenuItem.Click += new System.EventHandler(this.virtualCOMPortToolStripMenuItem_Click);
            // 
            // displayCRLFToolStripMenuItem
            // 
            this.displayCRLFToolStripMenuItem.Name = "displayCRLFToolStripMenuItem";
            this.displayCRLFToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.displayCRLFToolStripMenuItem.Text = "Display CR/LF";
            this.displayCRLFToolStripMenuItem.Click += new System.EventHandler(this.displayCRLFToolStripMenuItem_Click);
            // 
            // timerDP
            // 
            this.timerDP.Interval = 60;
            this.timerDP.Tick += new System.EventHandler(this.timerDP_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 716);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.CT_tabPage);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UART Communication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.CT_tabPage.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxI2C.ResumeLayout(false);
            this.groupBoxI2C.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxCOM.ResumeLayout(false);
            this.groupBoxCOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.he_State_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.he_State_rx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.he_State_tx)).EndInit();
            this.gbConnecType.ResumeLayout(false);
            this.gbConnecType.PerformLayout();
            this.groupBoxUDP.ResumeLayout(false);
            this.groupBoxUDP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udp_State_Connect)).EndInit();
            this.groupBoxUdpSend.ResumeLayout(false);
            this.groupBoxUdpSend.PerformLayout();
            this.tabPageUDP.ResumeLayout(false);
            this.tabPageUpdate.ResumeLayout(false);
            this.tabPageUpdate.PerformLayout();
            this.gB_Cameratype.ResumeLayout(false);
            this.gB_Cameratype.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.I2C_dtgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.he_dtgvSend)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button he_btClearAll;
        private System.Windows.Forms.TabControl CT_tabPage;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.DataGridView he_dtgvSend;
        private System.Windows.Forms.GroupBox groupBoxCOM;
        private System.Windows.Forms.CheckBox he_cbCR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox he_tbRxTx;
        private System.Windows.Forms.CheckBox he_chxAutoConnect;
        private System.Windows.Forms.Button he_btOpen;
        private System.Windows.Forms.ComboBox he_cbParity;
        private System.Windows.Forms.ComboBox he_cbDataSize;
        private System.Windows.Forms.ComboBox he_cbBaud;
        private System.Windows.Forms.ComboBox he_cbCOM;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox he_cbShowTime;
        private System.Windows.Forms.CheckBox he_cbAutoScroll;
        private System.Windows.Forms.ComboBox he_cbDisplay;
        private TabPage tabPageUpdate;
        private LinkLabel linkLabel1;
        private Label label7;
        private Label label9;
        private ComboBox he_cbStopBit;
        private Label label8;
        private PictureBox he_State_Connect;
        private ComboBox cb_Language;
        private Label label10;
        private Button buttonBrowse;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadTXListToolStripMenuItem;
        private ToolStripMenuItem saveTXListToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private CheckBox he_cbLF;
        private TabPage tabPagePW;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem virtualCOMPortToolStripMenuItem;
        private Timer timerDP;
        private Panel panel1;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewCheckBoxColumn Hex;
        private DataGridViewCheckBoxColumn Dec;
        private DataGridViewCheckBoxColumn Ascii;
        private DataGridViewButtonColumn Tran;
        private DataGridViewTextBoxColumn Note;
        private GroupBox groupBoxI2C;
        private Button FT_bt_Init;
        private GroupBox groupBox1;
        private Label labelStatusSummary;
        private Label labelStatusDetail;
        private Button FT_bt_Scan;
        private DataGridView I2C_dtgv;
        private Button FT_bt_Add;
        private ComboBox FT_cb_Baud;
        private Label label1;
        private Label label11;
        private Button bt_BenchStop;
        private Button bt_BenchStart;
        private GroupBox gbConnecType;
        private RadioButton radioButtonI2C;
        private RadioButton radioButtonUART;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripClear;
        public PictureBox he_State_rx;
        public PictureBox he_State_tx;
        private Button bt_StopUpdate;
        private Button bt_StartUpdate;
        private Button bt_CheckCRC;
        private TextBox tb_SaveCRC;
        private TextBox tb_BLTN_FW_CRC;
        private TextBox tb_Hash;
        private TextBox tb_FWImageSize;
        private Label label37;
        private Label label36;
        private Label label35;
        private Button bt_UpdateOpen;
        private TextBox tb_BLTNFW;
        private Label label29;
        private Label lb_UpdateTime;
        private TextBox tb_Process;
        private ProgressBar progressBarUpdate;
        private Button bt_Init;
        private Button bt_Scan;
        private GroupBox gB_Cameratype;
        private RadioButton radioButtonRear;
        private RadioButton radioButtonFront;
        private ToolStripMenuItem displayCRLFToolStripMenuItem;
        private TabPage tabPageUDP;
        private GroupBox groupBoxUDP;
        private Label labelUdpRemoteIP;
        private TextBox tb_UdpRemoteIP;
        private CheckBox cb_UdpBroadcast;
        private Label labelUdpRemotePort;
        private TextBox tb_UdpRemotePort;
        private Label labelUdpLocalPort;
        private TextBox tb_UdpLocalPort;
        private CheckBox cb_UdpServerEcho;
        private CheckBox cb_UdpShowRemote;
        private Button bt_UdpListen;
        private PictureBox udp_State_Connect;
        private Label lb_UdpStatus;
        private GroupBox groupBoxUdpSend;
        private Label labelUdpSend;
        private TextBox tb_UdpSendText;
        private RadioButton rb_UdpAscii;
        private RadioButton rb_UdpHex;
        private CheckBox cb_UdpCRLF;
        private Button bt_UdpSend;
        private Button bt_UdpClearSend;
    }
}

