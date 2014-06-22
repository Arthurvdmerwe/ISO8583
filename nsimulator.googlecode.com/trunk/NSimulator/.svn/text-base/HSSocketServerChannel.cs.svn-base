using System;
using System.Net;
using System.Timers;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using middleware.or.id.nSwitch4me.com;
using System.Windows.Forms;
using MSScriptControl;

namespace middleware.or.id.HostSimulator
{
	/// <summary>
	/// Summary description for HSSocketServerChannel.
	/// </summary>
	public class HSSocketServerChannel: SocketServerChannel  
	{
		public ListBox listLogger;
		private MSScriptControl.ScriptControl scriptObject = null;

		public HSSocketServerChannel()
		{
		}

		protected override int LogDebug(string debug)
		{
			listLogger.Items.Add("[DEBUG] " + debug);
			//scriptObject.ExecuteStatement("this.Testing(\"Test saja ahhhhh ....\")");
			return 1;
		}

		protected override int LogError(string error)
		{
			return 0;
		}

		protected override int LogInformation(string info)
		{
			return 0;
		}

		protected override void InitServer()
		{
			scriptObject = new MSScriptControl.ScriptControlClass();
			scriptObject.Language = "VBScript";
			scriptObject.AddObject("this", this, true);
		}

		public void Testing(string Tests) 
		{
			listLogger.Items.Add("[SCRIPT] " + Tests);
		}

	}
}
