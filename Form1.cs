using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.IO;
using System.IO.Ports;

namespace WinFormsApp_ReadLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*******************************************************************************
         * Constant 
         ******************************************************************************/
        /* These are constant variables */
        public static readonly string userDocFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /*******************************************************************************
         * Gobal Variable 
         ******************************************************************************/
        static string userAppFolder = userDocFolder + "\\pxToRGB";
        // 可選：獲取完整路徑
        string executablePath = Assembly.GetExecutingAssembly().Location;
        // 獲取目前執行檔的名稱
        static string fileName = Assembly.GetExecutingAssembly().GetName().Name;
        //獲取執行檔版本
        string fileVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        string buildDateTime = System.IO.File.GetCreationTime(Assembly.GetExecutingAssembly().Location).ToString("yyyy-MM-dd HH:mm");    //ToString("yyyy-MM-dd HH:mm:ss")

        string strFilePath = "";    //userAppFolder + "\\" + "H4_IQC_LBS_BURN.csv";
        static string strDailyLogDate = DateTime.Now.ToString("yyyy-MM-dd");
        static string strFileDailyFolder = userAppFolder + "\\" + DateTime.Now.ToString("yyyy")
            + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd");
        static string strLogNameDaily = ""; //strFileDailyFolder + "\\" + "H4_IQC_LBS_BURN" + "_" + strDailyLogDate + ".csv";
        string strFileDailyPath = "";   //userAppFolder + "\\" + strLogNameDaily;    //@"\Burn1to10.csv";
        string strSwVer = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMacAddr.ReadOnly = true;
            txtFilePath.ReadOnly = true;
            //txtFilePath.BackColor = SystemColors.Info;
            richText_Ans.ReadOnly = true;
            toolStripStatusLabel1.Text = "Select a file to Read.";
            btnRead.Enabled = false; txtKeyword.Enabled = false;

            txtMacAddr.Text = GetMacAddress().ToString();
            lblSWver.Text = "SW : " + fileName + " - ver: " + strSwVer + " ; 程式碼日期 : " + buildDateTime;
        }

        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)  //2023-03-21
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
                else if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utilHelpAbout();
        }
        private void utilHelpAbout()
        {
            string company = "Megaforce(R) " + fileName + " Ver:" + fileVersion + "\n";
            string copyright = "(C)Copyright Megaforce Corp 2025-2035.\n";
            string buildDT = "Built on " + buildDateTime + "\n";
            string Author = "Author: Eric Hsu\n";
            MessageBox.Show(company + copyright + buildDT + Author, "About " + fileName);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void utilCheckUserFile()
        {
            if (Directory.Exists(userAppFolder) == false)
            { Directory.CreateDirectory(userAppFolder); }
            //if (Directory.Exists(strFileDailyFolder) == false)
            //{ Directory.CreateDirectory(strFileDailyFolder); }
        }
        public bool IsFileLocked(string filename)
        {
            bool Locked = false;
            try
            {
                FileStream fs =
                    File.Open(filename, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Locked = true;
            }
            return Locked;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit？", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
            else { e.Cancel = true; }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x219;
            const int DBT_DEVICEARRIVAL = 0x8000;
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            const int SC_CLICK = 0xF093;
            const int SC_DOUBLE_CLICK = 0xF063;

            object ojb = new object();
            try   //2023-09-25
            {
                // WM_DEVICECHANGE Message : 電腦硬體裝置改變時產生的訊息
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            Console.WriteLine("DEVICE CHANGEed");
                            break;
                        // DBT_DEVICEARRIVAL Event : 裝置插入並且可以使用時，產生的系統訊息
                        case DBT_DEVICEARRIVAL:
                            //string[] portnames = SerialPort.GetPortNames(); //---工具箱無SerialPort，不存在於目前的內容中
                            Console.WriteLine("DEVICE was inserted.");
                            toolStripStatusLabel1.Text = "DEVICE was inserted";
                            break;

                        // DBT_DEVICEREMOVECOMPLETE Event : 裝置卸載或移除時產生的系統訊息
                        case DBT_DEVICEREMOVECOMPLETE:
                            //portnames = SerialPort.GetPortNames(); //---工具箱無SerialPort，不存在於目前的內容中
                            Console.WriteLine("DEVICE was removed.");
                            toolStripStatusLabel1.Text = "DEVICE was removed";
                            break;
                    }
                }
                else if (m.Msg == WM_SYSCOMMAND)
                {
                    if (m.WParam.ToInt32() == SC_CLOSE)
                    {
                        // 点击winform右上关闭按钮 
                        // 加入想要的逻辑处理
                        //utilWindowClosingWithConfirm(false);
                        //return;
                    }
                    else if (m.WParam.ToInt32() == SC_CLICK)
                    {
                        return;
                    }
                    else if (m.WParam.ToInt32() == SC_DOUBLE_CLICK)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WndProc");
            }
            base.WndProc(ref m);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "Log Files (*.txt;*.log;*.json;*.html)|*.txt; *.log; *.json;*.html" + "|" + "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;
                txtFilePath.Text = file;
                toolStripStatusLabel1.Text = "InputFile= " + txtFilePath.Text;
            }
            if (txtFilePath.Text != "" ) 
            { 
                txtKeyword.Enabled = true; 
                if(txtKeyword.Text != "") {toolStripStatusLabel1.Text = "Keyword已輸入，可按'GetResult'";  }
                else { toolStripStatusLabel1.Text = "請輸入Keyword已輸入"; }
            }
            else 
            { txtKeyword.Enabled = false; toolStripStatusLabel1.Text = "請輸入Keywords"; }
            
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "") 
            { 
                btnRead.Enabled = true;
                toolStripStatusLabel1.Text = "輸入完成請按'GetResult'.";
            }
            else { btnRead.Enabled = false; toolStripStatusLabel1.Text = "請輸入Keywords"; }
            richText_Ans.Text = "";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text; // 請替換成你的檔案路徑
            string targetString = (txtKeyword.Text).Trim(); // 請替換成你要搜尋的字串
            string strAnswer = "";
            try
            {
                int count = 0;
                Boolean bStartFindResult = false;   //start to find certain value
                
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line; 
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (bStartFindResult)
                        {
                            if (line.Contains("Pass")) 
                            { strAnswer = "Pass"; bStartFindResult = false; }
                            else if(line.Contains("Fail")) 
                            { strAnswer = "Fail"; bStartFindResult = false; }
                            else if (line.Contains("EndScript")) 
                            { bStartFindResult = false; }
                        }
                        if (line.Contains(targetString))
                        {
                            Console.WriteLine($"Found '{targetString}' in line: {line}");
                            // 找到字串後，可以執行其他操作
                            //break; // 如果只需要找到第一個匹配項，則在此處中斷迴圈
                            count += 1;
                            bStartFindResult = true;
                        }
                        //count += line.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count(word => word.Equals(targetString.ToLower())); //忽略大小寫比較
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine($"The string '{targetString}' appears {count} times in the file.");
                richText_Ans.Text = "Found keyword: '" + targetString + "', count = " + count.ToString() + "\r\n" + "Answer is " + strAnswer + ".";
                toolStripStatusLabel1.Text = "完成查詢，結果為 " + strAnswer;
            }
            catch (FileNotFoundException)
            { Console.WriteLine($"File not found: {filePath}"); }
            catch (Exception ex)
            { Console.WriteLine($"An error occurred: {ex.Message}"); }
        }
        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            richText_Ans.Text = "";
            if (txtKeyword.Text != "")
            {
                btnRead.Enabled = true;
                toolStripStatusLabel1.Text = "輸入完成請按'GetResult'.";
            }
        }
    }
}
