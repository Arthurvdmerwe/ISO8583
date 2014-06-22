using System;
using System.Net;
using System.Text;
using System.Timers;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace middleware.or.id.nSwitch4me.com
{
	/// <summary>
	/// Summary description for SocketServerHostChannel.
	/// </summary>
	public class SocketServerHostChannel
	{
		public  static Socket	Server;
		public  static ArrayList Client;
		public static string  rln;
		
		//private bool isdebug = true;
		private int portNumber = 1;
		protected static string MsgHeaderLenFormat = "";
		protected static string MsgLenOrder_Send = "";
		protected static string MsgLenOrder_Recv = "";

		public SocketServerHostChannel() {}

		[STAThread]
		public void ThreadMethod()
		{
			IPHostEntry Iphe   = Dns.Resolve   (Dns.GetHostName());
			IPEndPoint  Ipep   = new IPEndPoint(Iphe.AddressList[0], portNumber);
			Server = new Socket    (Ipep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		
			Client = new ArrayList ();
			rln    = null;
		
			Client.Capacity =   256;
			Server.Blocking = false;
			Server.Bind  (Ipep);
			Server.Listen( 32 );
			Console.WriteLine("Application Started .");
			Console.WriteLine("{0}: listening on port {1}", Dns.GetHostName(), Ipep.Port);
			
			System.Timers.Timer aTimer = new System.Timers.Timer();
			aTimer.Elapsed += new ElapsedEventHandler(OnTimer);
			aTimer.Interval = 1;
			aTimer.Enabled = true;    
			int input = Console.Read();
			while(input!='q')
			{
				input = Console.Read(); 
			}
		}
		
		public static void OnTimer(Object source, ElapsedEventArgs e)
		{
			select();
		}
		
		private static void select() 
		{    
		    
			ArrayList hex = new ArrayList();
			///1. Poll the Server sockChannel; if true then accept the new connection.
			///2. Poll the Client sockChannel; if true then receive data from Clients.
			
			if (Server.Poll(0, SelectMode.SelectRead))
			{
				int i = Client.Add(new SocketChannel());
				((SocketChannel)Client[i]).sockChannel = Server.Accept ();
				Console.WriteLine("Client {0} connected.", i  );
			}
		
			for (int i = 0; i < Client.Count; i++)
			{
				//check for incoming data
				if (((SocketChannel)Client[i]).sockChannel.Poll(0, SelectMode.SelectRead))
				{
					//receive incoming data
					//if (((SocketChannel)Client[i]).Recv(ref rln) > 0)
					if (((SocketChannel)Client[i]).Recv(ref rln, 0, SocketHeaderLength.getLength(MsgHeaderLenFormat)) > 0)
					{
						Console.WriteLine("Client sending {0} - ", rln  );
						ASCIIEncoding AE = new ASCIIEncoding();
						byte[] ByteArray = AE.GetBytes(rln);
						
						int len = SocketHeaderLength.getEndianByteToInt(MsgLenOrder_Recv, ByteArray);						
						Console.WriteLine("Client Len Message : {0} ", len);
						if (((SocketChannel)Client[i]).Recv(ref rln, 0, len) > 0)
						{
							Console.WriteLine("Client Message : {0} ", rln );
							ProcessMessage proses = new ProcessMessage(rln);
							String respon = proses.getOutputProcess();
							send(respon, (SocketChannel)Client[i]);
						}		
						else
						{
							((SocketChannel)Client[i]).sockChannel.Shutdown(SocketShutdown.Both);
							((SocketChannel)Client[i]).sockChannel.Close();
							Client.RemoveAt (i);
							Console.WriteLine("Client {0} disconnected.", i);
						}
						Console.WriteLine( "\r\n" );
					}
					//recv returned <= 0; close the socket
					else
					{
						((SocketChannel)Client[i]).sockChannel.Shutdown(SocketShutdown.Both);
						((SocketChannel)Client[i]).sockChannel.Close();
						Client.RemoveAt (i);
						Console.WriteLine("Client {0} disconnected.", i);
					}
				}
		    
			}
		}

		private static void send(string msg, SocketChannel eChannel) 
		{
			int imsg = msg.Length;
			byte[] b = SocketHeaderLength.getByteFromInt(MsgHeaderLenFormat, MsgLenOrder_Send, imsg);
			ASCIIEncoding AE = new ASCIIEncoding();						
			eChannel.Send(AE.GetString(b));
			eChannel.Send(msg);
			Console.WriteLine("Server sendind : {0}", msg);
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
