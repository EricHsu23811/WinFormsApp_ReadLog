namespace WinFormsApp_ReadLog
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnSelect = new Button();
            txtFilePath = new TextBox();
            lblPcMac = new Label();
            txtMacAddr = new TextBox();
            btnRead = new Button();
            grpSearch = new GroupBox();
            lblResult = new Label();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            richText_Ans = new RichTextBox();
            lblSWver = new Label();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpSearch.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(782, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(47, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(80, 23);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 23);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(134, 26);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 328);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(782, 25);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(158, 19);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(26, 53);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(149, 32);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select File";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(26, 91);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(742, 27);
            txtFilePath.TabIndex = 3;
            txtFilePath.TextChanged += txtFilePath_TextChanged;
            // 
            // lblPcMac
            // 
            lblPcMac.AutoSize = true;
            lblPcMac.Location = new Point(509, 60);
            lblPcMac.Name = "lblPcMac";
            lblPcMac.Size = new Size(81, 19);
            lblPcMac.TabIndex = 4;
            lblPcMac.Text = "PC MAC：";
            // 
            // txtMacAddr
            // 
            txtMacAddr.Location = new Point(596, 57);
            txtMacAddr.Name = "txtMacAddr";
            txtMacAddr.Size = new Size(172, 27);
            txtMacAddr.TabIndex = 5;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(596, 279);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(172, 44);
            btnRead.TabIndex = 6;
            btnRead.Text = "GetResult";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(lblResult);
            grpSearch.Controls.Add(lblKeyword);
            grpSearch.Controls.Add(txtKeyword);
            grpSearch.Controls.Add(richText_Ans);
            grpSearch.Location = new Point(20, 124);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(748, 149);
            grpSearch.TabIndex = 8;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search Test";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(56, 62);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(67, 19);
            lblResult.TabIndex = 12;
            lblResult.Text = "Result：";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(37, 34);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(86, 19);
            lblKeyword.TabIndex = 11;
            lblKeyword.Text = "Keyword：";
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(129, 26);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(149, 27);
            txtKeyword.TabIndex = 10;
            txtKeyword.Text = "Job End";
            txtKeyword.TextChanged += txtKeyword_TextChanged;
            // 
            // richText_Ans
            // 
            richText_Ans.Location = new Point(129, 59);
            richText_Ans.Name = "richText_Ans";
            richText_Ans.Size = new Size(613, 84);
            richText_Ans.TabIndex = 0;
            richText_Ans.Text = "";
            // 
            // lblSWver
            // 
            lblSWver.AutoSize = true;
            lblSWver.Location = new Point(20, 292);
            lblSWver.Name = "lblSWver";
            lblSWver.Size = new Size(103, 19);
            lblSWver.TabIndex = 9;
            lblSWver.Text = "SW_Ver_Date";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 353);
            Controls.Add(lblSWver);
            Controls.Add(grpSearch);
            Controls.Add(btnRead);
            Controls.Add(txtMacAddr);
            Controls.Add(lblPcMac);
            Controls.Add(txtFilePath);
            Controls.Add(btnSelect);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "STgui Log *.html read test";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnSelect;
        private TextBox txtFilePath;
        private Label lblPcMac;
        private TextBox txtMacAddr;
        private Button btnRead;
        private GroupBox grpSearch;
        private RichTextBox richText_Ans;
        private Label lblSWver;
        private SaveFileDialog saveFileDialog1;
        private TextBox txtKeyword;
        private Label lblKeyword;
        private Label lblResult;
    }
}
