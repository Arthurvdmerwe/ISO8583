using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace middleware.or.id.nSwitch4me.com
{
	/// <summary>
	/// Summary description for SocketChannel.
	/// </summary>
	public class SocketChannel
	{
		int    tcpIndx = 0;
		int    tcpByte = 0;
		byte[] tcpRecv = new byte[1024];

		public Socket sockChannel;

		public int RecvAll  (ref string tcpRead)
		{
			tcpByte = sockChannel.Available;
			if (tcpByte > tcpRecv.Length - tcpIndx)
				tcpByte = tcpRecv.Length - tcpIndx;
	
			tcpByte = sockChannel.Receive(tcpRecv, tcpIndx, tcpByte,SocketFlags.Partial);
			tcpRead = Encoding.ASCII.GetString (tcpRecv, tcpIndx, tcpByte);
			tcpIndx+= tcpByte;
			return    tcpRead.Length;
		}

		public int RecvLine(ref string tcpRead)
		{
			tcpRead = Encoding.ASCII.GetString (tcpRecv, 0, tcpIndx);
			tcpIndx = 0;
			return    tcpRead.Length;
		}

		public int Recv(ref string tcpRead, int offset, int index)
		{
			tcpByte = sockChannel.Available;
			if (tcpByte == 0) return 0;
			tcpByte = sockChannel.Receive(tcpRecv, offset, index, SocketFlags.Partial);
			tcpRead = Encoding.ASCII.GetString (tcpRecv, offset, index);
			return    tcpRead.Length;
		}
	
		public int Send  (string tcpWrite)
		{
			return sockChannel.Send(Encoding.ASCII.GetBytes(tcpWrite));
		}

		public int SendLn(string tcpWrite)
		{
			return sockChannel.Send(Encoding.ASCII.GetBytes(tcpWrite + "\r\n"));
		}
	}
}
