using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MSScriptControl;
using middleware.or.id.nSwitch4me.iso;

namespace middleware.or.id.HostSimulator
{

	public class frmISO8583Parser : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private MSScriptControl.ScriptControl scriptObject = null;
		private ISOPackager packager;
		public System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabParser;
		private System.Windows.Forms.GroupBox grbParser;
		private System.Windows.Forms.ListBox listOutput;
		private System.Windows.Forms.GroupBox grbFileInput;
		private System.Windows.Forms.RichTextBox rtbFileInput;
		private System.Windows.Forms.Button btnFileInput;
		private System.Windows.Forms.GroupBox grbInput;
		private System.Windows.Forms.RichTextBox rtfISOInput;
		private System.Windows.Forms.Button btnParser;
		private System.Windows.Forms.TabPage tabPacker;
		private ISOMsg isomsg;

		public frmISO8583Parser()
		{
			InitializeComponent();
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmISO8583Parser));
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabParser = new System.Windows.Forms.TabPage();
			this.grbParser = new System.Windows.Forms.GroupBox();
			this.listOutput = new System.Windows.Forms.ListBox();
			this.grbFileInput = new System.Windows.Forms.GroupBox();
			this.rtbFileInput = new System.Windows.Forms.RichTextBox();
			this.btnFileInput = new System.Windows.Forms.Button();
			this.grbInput = new System.Windows.Forms.GroupBox();
			this.rtfISOInput = new System.Windows.Forms.RichTextBox();
			this.btnParser = new System.Windows.Forms.Button();
			this.tabPacker = new System.Windows.Forms.TabPage();
			this.tabMain.SuspendLayout();
			this.tabParser.SuspendLayout();
			this.grbParser.SuspendLayout();
			this.grbFileInput.SuspendLayout();
			this.grbInput.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabParser);
			this.tabMain.Controls.Add(this.tabPacker);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(3, 10);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(514, 301);
			this.tabMain.TabIndex = 12;
			// 
			// tabParser
			// 
			this.tabParser.Controls.Add(this.grbParser);
			this.tabParser.Location = new System.Drawing.Point(4, 22);
			this.tabParser.Name = "tabParser";
			this.tabParser.Size = new System.Drawing.Size(506, 275);
			this.tabParser.TabIndex = 0;
			this.tabParser.Text = "ISO8583 Parser";
			// 
			// grbParser
			// 
			this.grbParser.Controls.Add(this.listOutput);
			this.grbParser.Controls.Add(this.grbFileInput);
			this.grbParser.Controls.Add(this.grbInput);
			this.grbParser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grbParser.Location = new System.Drawing.Point(0, 0);
			this.grbParser.Name = "grbParser";
			this.grbParser.Size = new System.Drawing.Size(506, 275);
			this.grbParser.TabIndex = 1;
			this.grbParser.TabStop = false;
			// 
			// listOutput
			// 
			this.listOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listOutput.Location = new System.Drawing.Point(3, 112);
			this.listOutput.Name = "listOutput";
			this.listOutput.Size = new System.Drawing.Size(500, 160);
			this.listOutput.TabIndex = 8;
			// 
			// grbFileInput
			// 
			this.grbFileInput.Controls.Add(this.rtbFileInput);
			this.grbFileInput.Controls.Add(this.btnFileInput);
			this.grbFileInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.grbFileInput.Location = new System.Drawing.Point(3, 72);
			this.grbFileInput.Name = "grbFileInput";
			this.grbFileInput.Size = new System.Drawing.Size(500, 40);
			this.grbFileInput.TabIndex = 6;
			this.grbFileInput.TabStop = false;
			// 
			// rtbFileInput
			// 
			this.rtbFileInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbFileInput.Location = new System.Drawing.Point(3, 16);
			this.rtbFileInput.Name = "rtbFileInput";
			this.rtbFileInput.Size = new System.Drawing.Size(438, 21);
			this.rtbFileInput.TabIndex = 3;
			this.rtbFileInput.Text = "";
			// 
			// btnFileInput
			// 
			this.btnFileInput.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnFileInput.Location = new System.Drawing.Point(441, 16);
			this.btnFileInput.Name = "btnFileInput";
			this.btnFileInput.Size = new System.Drawing.Size(56, 21);
			this.btnFileInput.TabIndex = 4;
			this.btnFileInput.Text = "...";
			this.btnFileInput.Click += new System.EventHandler(this.btnFileInput_Click);
			// 
			// grbInput
			// 
			this.grbInput.Controls.Add(this.rtfISOInput);
			this.grbInput.Controls.Add(this.btnParser);
			this.grbInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.grbInput.Location = new System.Drawing.Point(3, 16);
			this.grbInput.Name = "grbInput";
			this.grbInput.Size = new System.Drawing.Size(500, 56);
			this.grbInput.TabIndex = 5;
			this.grbInput.TabStop = false;
			// 
			// rtfISOInput
			// 
			this.rtfISOInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtfISOInput.Location = new System.Drawing.Point(3, 16);
			this.rtfISOInput.Name = "rtfISOInput";
			this.rtfISOInput.Size = new System.Drawing.Size(438, 37);
			this.rtfISOInput.TabIndex = 3;
			this.rtfISOInput.Text = "";
			// 
			// btnParser
			// 
			this.btnParser.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnParser.Location = new System.Drawing.Point(441, 16);
			this.btnParser.Name = "btnParser";
			this.btnParser.Size = new System.Drawing.Size(56, 37);
			this.btnParser.TabIndex = 4;
			this.btnParser.Text = "&Parse";
			this.btnParser.Click += new System.EventHandler(this.btnParser_Click);
			// 
			// tabPacker
			// 
			this.tabPacker.Location = new System.Drawing.Point(4, 22);
			this.tabPacker.Name = "tabPacker";
			this.tabPacker.Size = new System.Drawing.Size(506, 275);
			this.tabPacker.TabIndex = 1;
			this.tabPacker.Text = "ISO8583 Packer";
			this.tabPacker.Visible = false;
			// 
			// frmISO8583Parser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 320);
			this.Controls.Add(this.tabMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmISO8583Parser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmISO8583Validator";
			this.Load += new System.EventHandler(this.frmISO8583Parser_Load);
			this.tabMain.ResumeLayout(false);
			this.tabParser.ResumeLayout(false);
			this.grbParser.ResumeLayout(false);
			this.grbFileInput.ResumeLayout(false);
			this.grbInput.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnParser_Click(object sender, System.EventArgs e)
		{
			if (this.rtbFileInput.Text.Trim().Equals("")) 
			{
				MessageBox.Show(this, "Input Script File not specified !", 
					"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			String path = this.rtbFileInput.Text.Trim();
			try 
			{
				StreamReader reader = 
					new StreamReader(path,
					System.Text.Encoding.ASCII);
				String sb = reader.ReadToEnd();
				scriptObject.ExecuteStatement(sb);
				reader.Close();
				reader = null;
			} 
			catch (Exception ee) 
			{
				MessageBox.Show(this, ee.Message, 
					"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void frmISO8583Parser_Load(object sender, System.EventArgs e)
		{
			initAllObject();
		}

		public void reInitializeComponent()
		{
			InitializeComponent();
		}

		public void initAllObject()
		{			
			scriptObject = new MSScriptControl.ScriptControlClass();
			scriptObject.Language = "VBScript";
			scriptObject.AddObject("This", this, true);
			this.rtfISOInput.Text = "0210F22200010E80800800000000020000001651885629000000453830990000001500000821111507148829072303002323303200164053724000000032036008800210055500010200011101A000011       150000Case-006......................12345678901-00106001001";
			this.rtbFileInput.Text = Application.StartupPath + "\\ValidatorSampleParser.HSScript";
		}
		
		/*
		 * The code below is used by parser/packer from user scripting object
		 * This code make flexible to any scripting method, and documentation is needed for this part. 
		 * */ 
		#region Public Scripting Method
		
		public void LogInfo(string info) 
		{
			this.listOutput.Items.Add (info);
		}

		public void LogClear() 
		{
			this.listOutput.Items.Clear();
		}

		public string getISOMessage() 
		{
			return this.rtfISOInput.Text;
		}

		public void ProcessMessage(string input) 
		{
			this.LogInfo (input);
		}

		public int ProcessParsing(string input) 
		{
			this.packager = new ISOPackager();
			this.isomsg = new ISOMsg();
			this.isomsg.debug = false;
			this.isomsg.ASCIIMessage = this.rtfISOInput.Text;
			this.packager.ISOMsgObject = isomsg;
			try 
			{
				this.packager.unpack();
			} 
			catch (Exception e) 
			{
				this.LogInfo ("[PARSER] : " + "ERROR - Ending Parsing . " + e.Message);
				return -1;
			}
			return 0;
		}

		public string getISOField(int index) 
		{
			return this.isomsg.getField(index);
		}

		private void btnFileInput_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.Filter = "HS Script files (*.HSScript)|*.HSScript|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 1 ;
			openFileDialog.RestoreDirectory = true ;
			if (openFileDialog.ShowDialog() == DialogResult.OK) 
			{
				this.rtbFileInput.Text = openFileDialog.FileName;
			}
		}

		#endregion Public Scripting Method

	}
}
