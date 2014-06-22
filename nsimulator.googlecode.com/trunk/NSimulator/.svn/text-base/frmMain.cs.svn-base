using System;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace middleware.or.id.HostSimulator
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox mainBox;
		private System.Windows.Forms.StatusBar mainStatusBar;
		private System.Windows.Forms.PictureBox pboxLogo;
		private System.Windows.Forms.Label lblBar;
		private System.Windows.Forms.Label btnFile;
		private System.Windows.Forms.ContextMenu ctxMenuFile;
		private System.Windows.Forms.MenuItem mnuConfiguration;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.ContextMenu ctxMenuServer;
		private System.Windows.Forms.Label btnServer;
		private System.Windows.Forms.MenuItem mnuStartServer;
		private HSSocketServerChannel serverChannel;
		private Thread threadServerChannel;
		private System.Windows.Forms.ContextMenu ctxMenuTools;
		private System.Windows.Forms.Label btnTools;
		private System.Windows.Forms.MenuItem mnuISO8583Validator;
		private System.Windows.Forms.GroupBox grbMain;
		private System.Windows.Forms.ListBox listLogger;
		private frmISO8583Parser fParser;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuLogger;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.mainBox = new System.Windows.Forms.GroupBox();
			this.grbMain = new System.Windows.Forms.GroupBox();
			this.listLogger = new System.Windows.Forms.ListBox();
			this.btnTools = new System.Windows.Forms.Label();
			this.btnServer = new System.Windows.Forms.Label();
			this.btnFile = new System.Windows.Forms.Label();
			this.lblBar = new System.Windows.Forms.Label();
			this.pboxLogo = new System.Windows.Forms.PictureBox();
			this.ctxMenuFile = new System.Windows.Forms.ContextMenu();
			this.mnuLogger = new System.Windows.Forms.MenuItem();
			this.mnuConfiguration = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mainStatusBar = new System.Windows.Forms.StatusBar();
			this.ctxMenuServer = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuStartServer = new System.Windows.Forms.MenuItem();
			this.ctxMenuTools = new System.Windows.Forms.ContextMenu();
			this.mnuISO8583Validator = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mainBox.SuspendLayout();
			this.grbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainBox
			// 
			this.mainBox.Controls.Add(this.grbMain);
			this.mainBox.Controls.Add(this.btnTools);
			this.mainBox.Controls.Add(this.btnServer);
			this.mainBox.Controls.Add(this.btnFile);
			this.mainBox.Controls.Add(this.lblBar);
			this.mainBox.Controls.Add(this.pboxLogo);
			this.mainBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainBox.Location = new System.Drawing.Point(0, 0);
			this.mainBox.Name = "mainBox";
			this.mainBox.Size = new System.Drawing.Size(552, 352);
			this.mainBox.TabIndex = 1;
			this.mainBox.TabStop = false;
			// 
			// grbMain
			// 
			this.grbMain.Controls.Add(this.listLogger);
			this.grbMain.Location = new System.Drawing.Point(3, 154);
			this.grbMain.Name = "grbMain";
			this.grbMain.Size = new System.Drawing.Size(224, 184);
			this.grbMain.TabIndex = 7;
			this.grbMain.TabStop = false;
			// 
			// listLogger
			// 
			this.listLogger.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listLogger.Location = new System.Drawing.Point(3, 16);
			this.listLogger.Name = "listLogger";
			this.listLogger.Size = new System.Drawing.Size(218, 160);
			this.listLogger.TabIndex = 8;
			// 
			// btnTools
			// 
			this.btnTools.Location = new System.Drawing.Point(128, 16);
			this.btnTools.Name = "btnTools";
			this.btnTools.Size = new System.Drawing.Size(56, 16);
			this.btnTools.TabIndex = 5;
			this.btnTools.Text = "&Tools";
			this.btnTools.Click += new System.EventHandler(this.btnTools_Click);
			// 
			// btnServer
			// 
			this.btnServer.Location = new System.Drawing.Point(72, 16);
			this.btnServer.Name = "btnServer";
			this.btnServer.Size = new System.Drawing.Size(48, 16);
			this.btnServer.TabIndex = 3;
			this.btnServer.Text = "&Server";
			this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
			// 
			// btnFile
			// 
			this.btnFile.Location = new System.Drawing.Point(16, 16);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(48, 16);
			this.btnFile.TabIndex = 2;
			this.btnFile.Text = "&File";
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// lblBar
			// 
			this.lblBar.BackColor = System.Drawing.SystemColors.ControlText;
			this.lblBar.Location = new System.Drawing.Point(0, 128);
			this.lblBar.Name = "lblBar";
			this.lblBar.Size = new System.Drawing.Size(552, 24);
			this.lblBar.TabIndex = 1;
			this.lblBar.Text = "label1";
			// 
			// pboxLogo
			// 
			this.pboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pboxLogo.Image")));
			this.pboxLogo.Location = new System.Drawing.Point(2, 0);
			this.pboxLogo.Name = "pboxLogo";
			this.pboxLogo.Size = new System.Drawing.Size(550, 128);
			this.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pboxLogo.TabIndex = 0;
			this.pboxLogo.TabStop = false;
			// 
			// ctxMenuFile
			// 
			this.ctxMenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuLogger,
																						this.mnuConfiguration,
																						this.menuItem3,
																						this.mnuExit});
			// 
			// mnuLogger
			// 
			this.mnuLogger.Index = 0;
			this.mnuLogger.Text = "&Logger";
			this.mnuLogger.Click += new System.EventHandler(this.mnuLogger_Click);
			// 
			// mnuConfiguration
			// 
			this.mnuConfiguration.Index = 1;
			this.mnuConfiguration.Text = "&Configuration";
			this.mnuConfiguration.Click += new System.EventHandler(this.mnuConfiguration_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 3;
			this.mnuExit.Text = "&Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mainStatusBar
			// 
			this.mainStatusBar.Location = new System.Drawing.Point(0, 349);
			this.mainStatusBar.Name = "mainStatusBar";
			this.mainStatusBar.Size = new System.Drawing.Size(552, 24);
			this.mainStatusBar.TabIndex = 3;
			this.mainStatusBar.Text = "statusBar1";
			// 
			// ctxMenuServer
			// 
			this.ctxMenuServer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.mnuStartServer,
																						  this.menuItem4,
																						  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "&Configure Server";
			// 
			// mnuStartServer
			// 
			this.mnuStartServer.Index = 0;
			this.mnuStartServer.Text = "&Start Server";
			this.mnuStartServer.Click += new System.EventHandler(this.mnuStartServer_Click);
			// 
			// ctxMenuTools
			// 
			this.ctxMenuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuISO8583Validator,
																						 this.menuItem2});
			// 
			// mnuISO8583Validator
			// 
			this.mnuISO8583Validator.Index = 0;
			this.mnuISO8583Validator.Text = "&ISO8583 Validator";
			this.mnuISO8583Validator.Click += new System.EventHandler(this.mnuISO8583Validator_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "&Script Editor";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "&Stop Server";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 373);
			this.Controls.Add(this.mainStatusBar);
			this.Controls.Add(this.mainBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "  ISO8583 Host Simulator";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Resize += new System.EventHandler(this._Resize);
			this.mainBox.ResumeLayout(false);
			this.grbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void _Resize(object sender, System.EventArgs e)
		{
			this.mainBox.Size = new System.Drawing.Size(this.Width-8, this.Height-this.mainStatusBar.Height-30);
			this.pboxLogo.Size = new System.Drawing.Size(this.mainBox.Width, this.pboxLogo.Height);
			this.lblBar.Size = new System.Drawing.Size(this.mainBox.Width, this.lblBar.Height);
			this.grbMain.Size = new System.Drawing.Size(this.mainBox.Width-2*this.grbMain.Left, this.mainBox.Height-this.mainStatusBar.Height-this.pboxLogo.Height-this.lblBar.Height+15);
		}

		private void btnFile_Click(object sender, System.EventArgs e)
		{
			this.ctxMenuFile.Show(this.btnFile, 
				new Point(this.btnFile.Left, this.btnFile.Top  - (this.btnFile.Height/2)));
		}

		private void mnuConfiguration_Click(object sender, System.EventArgs e)
		{
			
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void mnuStartServer_Click(object sender, System.EventArgs e)
		{
			this.mnuLogger_Click(this, null);
			serverChannel = new HSSocketServerChannel();
			serverChannel.listLogger = this.listLogger;
			threadServerChannel = new Thread(new ThreadStart(serverChannel.ThreadMethod));
			threadServerChannel.Start();
		}

		private void btnServer_Click(object sender, System.EventArgs e)
		{
			this.ctxMenuServer.Show(this.btnServer, 
				new Point(this.btnServer.Left - ((this.btnServer.Left+this.btnServer.Width)/2), this.btnServer.Top  - (this.btnServer.Height/2)));
		}

		private void btnTools_Click(object sender, System.EventArgs e)
		{
			this.ctxMenuTools.Show(this.btnServer, 
				new Point(this.btnTools.Left - (this.btnTools.Width/2), this.btnTools.Top  - (this.btnServer.Height/2)));
		}

		private void mnuISO8583Validator_Click(object sender, System.EventArgs e)
		{
			this.grbMain.Controls.RemoveAt(0);

			if (fParser==null) fParser = new frmISO8583Parser();
			fParser.reInitializeComponent();
			fParser.initAllObject();
			this.grbMain.Controls.Add(fParser.tabMain);
		}

		private void mnuLogger_Click(object sender, System.EventArgs e)
		{
			this.grbMain.Controls.RemoveAt(0);
			this.grbMain.Controls.Add(listLogger);
			this.listLogger.Dock = DockStyle.Fill;		
		}
	}

}
