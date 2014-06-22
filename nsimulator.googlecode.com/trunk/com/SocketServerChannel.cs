using System;
using System.Net;
using System.Text;
using System.Timers;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace middleware.or.id.nSwitch4me.com
{
	/*
	 * This channel is the main socket server channel for middleware.or.id
	 * */
	public abstract class SocketServerChannel
	{
		protected static Socket	Server;
		protected static ArrayList Client;		
		protected int PortNumber = 1100;
		protected IPHostEntry Iphe = null;
		protected IPEndPoint Ipep = null;
		protected System.Timers.Timer aTimer = null;

		protected bool Started = false;
		protected static string  MessageBuffer;
		protected static string MsgHeaderLenFormat = "StandartISO";
		protected static string MsgLenOrder_Send = "LE";
		protected static string MsgLenOrder_Recv = "BE";

		public SocketServerChannel() {}
		~SocketServerChannel() {}

		//abstract public void ThreadMethod();
		[STAThread]
		public void ThreadMethod()
		{
			IPHostEntry Iphe   = Dns.Resolve   (Dns.GetHostName());
			MsgHeaderLenFormat = "StandartISO";
			IPEndPoint  Ipep   = new IPEndPoint(Iphe.AddressList[0], PortNumber);
			Server = new Socket    (Ipep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			Started = true;
		
			Client = new ArrayList ();
			MessageBuffer    = null;
		
			Client.Capacity =   256;
			Server.Blocking = false;
			Server.Bind  (Ipep);
			Server.Listen( 32 );
			
			aTimer = new System.Timers.Timer();
			aTimer.Elapsed += new ElapsedEventHandler(OnTimer);
			aTimer.Interval = 1;
			aTimer.Enabled = true;    

			InitServer();

			LogDebug ("Application Started .");
			String debug = Dns.GetHostName() + " listening on port : " + Ipep.Port;
			LogDebug (debug);
		}		
		

		protected void OnTimer(Object source, ElapsedEventArgs e)
		{
			Select();
		}
		
		private void Select() 
		{    
		    
			ArrayList hex = new ArrayList();
			///1. Poll the Server sockChannel; if true then accept the new connection.
			///2. Poll the Client sockChannel; if true then receive data from Clients.
			
			if (Server.Poll(0, SelectMode.SelectRead))
			{
				int i = Client.Add(new SocketChannel());
				((SocketChannel)Client[i]).sockChannel = Server.Accept ();
				String debug = "Client " + i + " connected.";
				LogDebug (debug);
			}
		
			for (int i = 0; i < Client.Count; i++)
			{
				//check for incoming data
				if (((SocketChannel)Client[i]).sockChannel.Poll(0, SelectMode.SelectRead))
				{
					//receive incoming data
					//if (((SocketChannel)Client[i]).Recv(ref MessageBuffer) > 0)
					if (((SocketChannel)Client[i]).Recv(ref MessageBuffer, 0, SocketHeaderLength.getLength(MsgHeaderLenFormat)) > 0)
					//if (((SocketChannel)Client[i]).Recv(ref MessageBuffer, 0, 2) > 0)
					{
						ASCIIEncoding AE = new ASCIIEncoding();
						byte[] ByteArray = AE.GetBytes(MessageBuffer);						
						int len = SocketHeaderLength.getEndianByteToInt(MsgLenOrder_Recv, ByteArray);
						LogDebug ("Client sending ...");
						LogDebug ("Client Len Message - " + len);
						if (((SocketChannel)Client[i]).Recv(ref MessageBuffer, 0, len) > 0)
						{
							LogDebug ("Client Message : " + MessageBuffer );
							ProcessMessage proses = new ProcessMessage(MessageBuffer);
							String respon = proses.getOutputProcess();
							Send(respon, (SocketChannel)Client[i]);
						}		
						else
						{
							((SocketChannel)Client[i]).sockChannel.Shutdown(SocketShutdown.Both);
							((SocketChannel)Client[i]).sockChannel.Close();
							Client.RemoveAt (i);
							LogDebug ("Client disconnected.");
						}
					}
					//recv returned <= 0; close the socket
					else
					{
						((SocketChannel)Client[i]).sockChannel.Shutdown(SocketShutdown.Both);
						((SocketChannel)Client[i]).sockChannel.Close();
						Client.RemoveAt (i);
						LogDebug ("Client disconnected.");
					}
				}
		    
			}
		}

		static internal void Send(string msg, SocketChannel eChannel) 
		{
			int imsg = msg.Length;
			byte[] b = SocketHeaderLength.getByteFromInt(MsgHeaderLenFormat, MsgLenOrder_Send, imsg);
			ASCIIEncoding AE = new ASCIIEncoding();						
			eChannel.Send(AE.GetString(b));
			eChannel.Send(msg);
			Console.WriteLine("Server sending : {0}", msg);
		}

		abstract protected void InitServer();
		abstract protected int LogInformation(String info);
		abstract protected int LogError(String error);
		abstract protected int LogDebug(String debug);

	}

	internal struct SocketMessageFormatter 
	{
		public String LenType;
		public String LenOrderSend;
		public String LenOrderRecv;
		public String MessageFormat;
	}
}
