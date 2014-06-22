using System;
using System.Globalization;
using System.Collections;

namespace middleware.or.id.nSwitch4me.iso
{
	/* 
	 *	Created		: 18 December 2004
	 * License		: Free 
	 * Copyright	: Widyantoro @ 2004 (&ar)
	*/

	public class ISOBaseField
	{
		public ISOBaseField()
		{			
		}

		public static string putField(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = "";
			if (iXWork.classid=="IFA_NUMERIC") 
			{
				r = setIFA_NUMERIC(field, iXWork);
			}
			if (iXWork.classid=="IFA_CHAR") 
			{
				r = setIFA_CHAR(field, iXWork);
			}
			if (iXWork.classid=="IFA_LLCHAR") 
			{
				r = setIFA_LLCHAR(field, iXWork);
			}
			if (iXWork.classid=="IFA_LLLCHAR") 
			{
				r = setIFA_LLLCHAR(field, iXWork);
			}
			if (iXWork.classid=="IFA_LLNUM") 
			{
				r = setIFA_LLNUM(field, iXWork);
			}
			if (iXWork.classid=="IFA_BITMAP") 
			{
				r = setIFA_BITMAP(field, iXWork);
			}
			return r;
		}

		public static string pickField(ref string msg, ISOFieldAttribute iXWork) 
		{
			string r = "";
			if (iXWork.classid=="IFA_BITMAP") 
			{
				r = getIFA_BITMAP(ref msg);
			}
			if (iXWork.classid=="IFA_LLNUM") 
			{
				r = getIFA_LLNUM(ref msg);
			}
			if (iXWork.classid=="IFA_NUMERIC") 
			{	
				r = getIFA_NUMERIC(msg, int.Parse(iXWork.length));
				msg = msg.Substring(int.Parse(iXWork.length), msg.Length-int.Parse(iXWork.length));
			}
			if (iXWork.classid=="IFA_CHAR") 
			{	
				r = getIFA_CHAR(msg, int.Parse(iXWork.length));
				msg = msg.Substring(int.Parse(iXWork.length), msg.Length-int.Parse(iXWork.length));
			}
			if (iXWork.classid=="IFA_LLCHAR") 
			{
				r = getIFA_LLCHAR(ref msg);
			}
			if (iXWork.classid=="IFA_LLLCHAR") 
			{
				r = getIFA_LLLCHAR(ref msg);
			}
			if (iXWork.classid=="IFA_AMOUNT") 
			{	
				r = getIFA_AMOUNT(msg, int.Parse(iXWork.length));
				msg = msg.Substring(int.Parse(iXWork.length), msg.Length-int.Parse(iXWork.length));
			}
			return r;
		}

		private static string setIFA_LLNUM(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = (string)field[int.Parse(iXWork.id)];
			if (r.Length > int.Parse(iXWork.length)) 
				throw(new ISOFieldPackingException("Invalid field length on field : " + iXWork.id));
			string l = r.Length.ToString().PadLeft(2, '0');
			r = l + r;
			return r;
		}

		private static string getIFA_LLNUM(ref string msg) 
		{
			string r = "";
			string l = msg.Substring(0,2);
			msg = msg.Substring(2, msg.Length-2);
			r = msg.Substring(0,int.Parse(l));
			msg = msg.Substring(int.Parse(l), msg.Length-int.Parse(l));
			return r;
		}

		private static string setIFA_LLCHAR(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = (string)field[int.Parse(iXWork.id)];;
			if (r.Length > int.Parse(iXWork.length)) 
				throw(new ISOFieldPackingException("Invalid field length on field : " + iXWork.id));			
			string l = r.Length.ToString().PadLeft(2, '0');
			r = l + r;
			return r;
		}

		private static string getIFA_LLCHAR(ref string msg) 
		{
			string r = "";
			string l = msg.Substring(0,2);
			msg = msg.Substring(2, msg.Length-2);
			r = msg.Substring(0,int.Parse(l));
			msg = msg.Substring(int.Parse(l), msg.Length-int.Parse(l));
			return r;
		}

		private static string setIFA_LLLCHAR(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = (string)field[int.Parse(iXWork.id)];;
			if (r.Length > int.Parse(iXWork.length)) 
				throw(new ISOFieldPackingException("Invalid field length on field : " + iXWork.id));			
			string l = r.Length.ToString().PadLeft(3, '0');
			r = l + r;
			return r;
		}

		private static string getIFA_LLLCHAR(ref string msg) 
		{
			string r = "";
			string l = msg.Substring(0,3);
			msg = msg.Substring(3, msg.Length-3);
			r = msg.Substring(0,int.Parse(l));
			msg = msg.Substring(int.Parse(l), msg.Length-int.Parse(l));
			return r;
		}

		private static string setIFA_NUMERIC(Hashtable field, ISOFieldAttribute iXWork) 
		{			
			string r = "";
			r = (string)field[int.Parse(iXWork.id)];
			if (r.Length > int.Parse(iXWork.length)) 
				throw(new ISOFieldPackingException("Invalid field length on field : " + iXWork.id));
			r = r.PadLeft(int.Parse(iXWork.length), '0');
			return r;
		}

		private static string getIFA_NUMERIC(string msg, int mlen) 
		{
			return msg.Substring(0,mlen);
		}

		private static string setIFA_CHAR(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = (string)field[int.Parse(iXWork.id)];;
			if (r.Length > int.Parse(iXWork.length)) 
				throw(new ISOFieldPackingException("Invalid field length on field : " + iXWork.id));			
			r = r.PadLeft(int.Parse(iXWork.length), '0');
			return r;
		}

		private static string getIFA_CHAR(string msg, int mlen) 
		{
			return msg.Substring(0,mlen);
		}

		private static string setIFA_AMOUNT(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = (string)field[int.Parse(iXWork.id)];
			if (r.Length > int.Parse(iXWork.length)) 
				throw(new ISOFieldPackingException("Invalid field length on field : " + iXWork.id));
			r = r.PadLeft(int.Parse(iXWork.length)-1, '0');
			r = ((Int32.Parse(r) > 0) ? "C" : "D") + r ;
			return r;
		}

		private static string getIFA_AMOUNT(string msg, int mlen) 
		{
			return msg.Substring(0,mlen);
		}

		private static string setIFA_BITMAP(Hashtable field, ISOFieldAttribute iXWork) 
		{
			string r = "";
			string rs = "";
			IDictionaryEnumerator en = field.GetEnumerator();
			bool ign = en.MoveNext(); ign = en.MoveNext(); //start from bit 2
			int i = 2; bool Bitmap2nd = false;
			while (en.MoveNext()) 
			{
				if ((bool)field[i]) 
				{
					r += "1";
					if (i>64) Bitmap2nd = true;
				}
				else
				{
					r += "0";
				}
				i++;
			}
			if (Bitmap2nd) 
			{
				r = "1" + r;
			} 
			else
			{
				r = "0" + r;
				r = r.Substring(0,64);
			}
			for (int e=0; e< r.Length/16; e++)
			{
				rs += ISOGenericFunction.ConvertBinary2Hex(r.Substring(e*16,16));
			}
			return rs;
		}

		public static string getIFA_BITMAP(ref string msg) 
		{
			string bitmap = "";
			for (int i=0; i<2; i++) 
			{
				for (int x=0; x<4; x++) 
				{
					int ihex = int.Parse(msg.Substring(x*4,4), NumberStyles.AllowHexSpecifier);
					bitmap += ISOGenericFunction.ConvertNumber2Base(2, ihex).PadLeft(16,'0');
				}				
				msg = msg.Substring(16, msg.Length - 16);
				if (!(bitmap.Substring(0,1).Equals("1")))  i = 2;
			}
			return bitmap;
		}				

		public static Hashtable HashBitMap(string bitmap)
		{
			Hashtable bit = new Hashtable(128);
			bit.Add(0, true);			 
			for (int b=0; b<128; b++) 
			{
				if (bitmap.Substring(b,1).Equals("1"))
				{
					bit.Add(b+1, true); 
				} 
				else 
				{
					bit.Add(b+1, false); 
				}
			}
			return bit;
		}
		
	}	
	
}
