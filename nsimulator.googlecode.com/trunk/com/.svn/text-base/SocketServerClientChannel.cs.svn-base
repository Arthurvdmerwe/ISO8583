using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Threading;

namespace middleware.or.id.nSwitch4me.com
{
	/// <summary>
	/// Summary description for SocketServerClientChannel.
	/// </summary>
	public class SocketServerClientChannel
	{
		public	static Socket	Server;
		public	static ArrayList Client;
		public	static string  rln;
		public	AsyncCallback pfnWorkerCallBack ;
		private int portNumber = 1;
		private string hostname = "localhost";
		protected static string MsgHeaderLenFormat = "";
		protected static string MsgLenOrder_Send = "";
		protected static string MsgLenOrder_Recv = "";
		
		public SocketServerClientChannel()	{}

		[STAThread]
		public void ThreadMethod()
		{
			Console.WriteLine("Application Started .");
			IPHostEntry Iphe   = Dns.Resolve   (hostname);
			IPEndPoint  Ipep   = new IPEndPoint(Iphe.AddressList[0], portNumber);
			Console.WriteLine("Connecting to host {0} port {1}", host, Ipep.Port);
			Server = new Socket    (Ipep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);			
		
			rln = null;
			try 
			{
				Server.Connect(Ipep);				
				Console.WriteLine("Connected to host {0} port {1}", Dns.GetHostName(), Ipep.Port);
				WaitForData(Server, 1);
				Console.WriteLine("type 1 to Echo .");
				Console.WriteLine("type 2 to SignOn .");
				Console.WriteLine("type 3 to SignOff .");
				bool loop = true;
				while (loop)
				{
					int i = Console.Read();
					if (i=='1') echo();
					if (i=='2') signon();
					if (i=='3') signoff();
					if (i=='Q') loop = false;
				}		
						
				Console.WriteLine("Application Closed .");
			} catch (SocketException se) 
			{
				Console.WriteLine("Error : {0}" , se.Message );
				Console.WriteLine("Application Can't connect .");
			}						
		}
		

		private void echo() 
		{
			String msg = "0800822000000000000004000000000000000903185110022466301";
			send(msg);
			Console.WriteLine("Sending Echo message ...");
		}

		private void signon() 
		{
			Console.WriteLine("Sending signon message ...");
		}

		private void signoff() 
		{
			Console.WriteLine("Sending signoff message ...");
		}

		private void send(string msg) 
		{
			int imsg = msg.Length;
			byte[] b = SocketHeaderLength.getByteFromInt(MsgHeaderLenFormat, MsgLenOrder_Send, imsg);
			ASCIIEncoding AE = new ASCIIEncoding();
			byte[] ByteArray = AE.GetBytes(msg);			
			Server.Send(b);
			Server.Send(ByteArray);
		}

		public class CSocketPacket
		{
			public System.Net.Sockets.Socket thisSocket;
			public byte[] dataBuffer = new byte[1];
		}

		public void WaitForData(Socket soc, int len)
		{
			try
			{
				if  ( pfnWorkerCallBack == null ) 
				{
					pfnWorkerCallBack = new AsyncCallback (OnDataReceived);
				}
				CSocketPacket theSocPkt = new CSocketPacket ();
				theSocPkt.dataBuffer = new byte[len];
				theSocPkt.thisSocket = soc;
				// now start to listen for any data...
				soc .BeginReceive (theSocPkt.dataBuffer ,0,theSocPkt.dataBuffer.Length ,SocketFlags.None,pfnWorkerCallBack,theSocPkt);
			}
			catch(SocketException se)
			{
				Console.WriteLine( se.Message );
			}
		}

		public  void OnDataReceived(IAsyncResult asyn)
		{
			try
			{
				CSocketPacket theSockId = (CSocketPacket)asyn.AsyncState ;

				byte b1 = theSockId.dataBuffer[0];
				byte[] tcpRecv = new byte[4096];
				int tcpByte = theSockId.thisSocket.Receive(tcpRecv, 0, 1, SocketFlags.Partial);
				byte b2 = tcpRecv[0];
				string LE = String.Format("{0:x2}", System.Convert.ToInt32(b2)) +
					String.Format("{0:x2}", System.Convert.ToInt32(b1));
				Console.WriteLine("Server sending : {0} ", LE );
				tcpByte = theSockId.thisSocket.Receive(tcpRecv, 0, System.Convert.ToInt32(LE,16), SocketFlags.Partial);
				Console.WriteLine(Encoding.ASCII.GetString (tcpRecv, 0, tcpByte) + "\n\r");
				
				WaitForData(Server, 1);
			}
			catch (ObjectDisposedException )
			{
				System.Diagnostics.Debugger.Log(0,"1","\nOnDataReceived: Socket has been closed\n");
			}
			catch(SocketException se)
			{
				Console.WriteLine (se.Message );
			}
		}

		public int port
		{
			get
			{
				return portNumber;
			}
			set
			{
				portNumber = value;
			}
		}

		public string host
		{
			get
			{
				return hostname;
			}
			set
			{
				hostname = value;
			}
		}

		public string msgHeaderLenFormat
		{
			get
			{
				return MsgHeaderLenFormat;
			}
			set
			{
				MsgHeaderLenFormat = value;
			}
		}

		public string msgLenOrder_Send
		{
			get
			{
				return MsgLenOrder_Send;
			}
			set
			{
				MsgLenOrder_Send = value;
			}
		}

		public string msgLenOrder_Recv
		{
			get
			{
				return MsgLenOrder_Recv;
			}
			set
			{
				MsgLenOrder_Recv = value;
			}
		}

	}
}
