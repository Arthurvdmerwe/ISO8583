using System;

namespace middleware.or.id.nSwitch4me.iso
{
	/* 
	 *	Created		: 18 December 2004
	 * License		: Free 
	 * Copyright	: Widyantoro @ 2004 (&ar)
	*/

	public class ISOGenericFunction
	{
		public ISOGenericFunction()
		{
		}
		
		public static string ConvertNumber2Base(int Base, int Number) 
		{
			String c = "";
			if (Number.Equals(0)) return "0";
			while (true)
			{ 				
				if (!((Number / Base) == 0)) 
				{
					int i = Number % Base;
					c = i.ToString() + c;
					Number = Number / Base;
				}
				else
				{
					c = "1" + c;
					return c;
				}
			}
			
		}

		public static string ConvertBinary2Hex(string binary)
		{
			string r = "";
			long lint = 0; int exp = 0;			
			for (int i=binary.Length-1; i>=0; i--) 			
			{
				lint += int.Parse(binary.Substring(i,1)) * (long)Math.Pow(2,exp);
				exp++;
			}
			r = String.Format("{0,2:x4}", lint );
			return r;
		}
	}
}
