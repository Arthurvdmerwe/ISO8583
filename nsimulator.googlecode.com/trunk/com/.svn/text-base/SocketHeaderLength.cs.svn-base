using System;

namespace  middleware.or.id.nSwitch4me.com
{
	/// <summary>
	/// Summary description for SocketHeaderLength.
	/// </summary>
	public class SocketHeaderLength
	{
		public SocketHeaderLength()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static int getLength(string tipeofheaderlen) 
		{
			int result = 0;
			switch (tipeofheaderlen)
			{
				case "StandartISO" :
					result = 2;
					break;
			}

			return result;
		}
		
		public static byte[] getByteFromInt(string format, string order, int len) 
		{
			string rs = "";
			byte[]  result = null;
			switch (format) 
			{
				case "StandartISO" :
					rs = String.Format("{0:x4}", len);
					result = new byte[2];
					if (order.Equals("LE")) 
					{
						result[1] = (byte)System.Convert.ToInt32(rs.Substring(0,2),16);
						result[0] = (byte)System.Convert.ToInt32(rs.Substring(2,2),16);
					} 
					else 
					{
						result[0] = (byte)System.Convert.ToInt32(rs.Substring(0,2),16);
						result[1] = (byte)System.Convert.ToInt32(rs.Substring(2,2),16);
					}
					break;
			}

			return result;
		}

		public static int getEndianByteToInt(string type, byte[] bytes) 
		{
			int result = 0;
			string LE = String.Format("{0:x2}", System.Convert.ToInt32(bytes[1])) +
				String.Format("{0:x2}", System.Convert.ToInt32(bytes[0]));
			result = System.Convert.ToInt32(LE,16);
			Console.WriteLine("Client sending : {0} ", LE );
			Console.WriteLine("Client sending : {0} ", result );
			return result;
		}
	}
}
