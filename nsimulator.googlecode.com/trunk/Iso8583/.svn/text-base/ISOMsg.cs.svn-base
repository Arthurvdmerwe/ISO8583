using System;
using System.Collections;

namespace middleware.or.id.nSwitch4me.iso
{
	/* 
	 *	Created		: 18 December 2004
	 * License		: Free 
	 * Copyright	: Widyantoro @ 2004 (&ar)
	*/

	public class ISOMsg
	{
		private string AsciiMessage;
		private string mti;
		private int maxField = 128;
		private Hashtable bitMapHash;
		private Hashtable strFieldHash;
		private bool isdebug = false;

		public ISOMsg()
		{
			bitMapHash = new Hashtable(maxField+1);
			strFieldHash = new Hashtable(maxField+1);
			for (int i=0; i<maxField+1; i++)
			{
				bitMapHash.Add(i, false);
			}
		}

		public string ASCIIMessage
		{
			get
			{
				return AsciiMessage;
			}
			set
			{
				AsciiMessage = value;
			}
		}

		public string MTI
		{
			get
			{
				return mti;
			}
			set
			{
				bitMapHash[0] = true;
				strFieldHash.Add(0, value);
				mti = value;
			}
		}

		public bool hasField(int index)
		{
			bool bm = (bool) bitMapHash[index];
			return bm;
		}

		public string getField(int index)
		{
			return (string) strFieldHash[index];			
		}

		public int MaxField
		{
			get
			{
				return maxField;
			}
			set
			{
				maxField = value;
			}
		}

		public Hashtable BitMapHash
		{
			set
			{
				bitMapHash = value;
			}
			get
			{
				return bitMapHash;
			}
		}

		public void set(int index, string strField)
		{
			if (bitMapHash.ContainsKey(index)) strFieldHash.Remove(index);
			bitMapHash[index] = true;
			strFieldHash.Add(index, strField);
		}

		public void unset(int index)
		{
			if (bitMapHash.ContainsKey(index)) 
			{
				bitMapHash[index] = false;
				strFieldHash.Remove(index);
			}
		}

		public Hashtable FieldHash
		{
			get
			{
				return strFieldHash;
			}
			set
			{
				strFieldHash = value;
			}
		}

		public bool debug
		{
			get
			{
				return isdebug;
			}
			set
			{
				isdebug = value;
			}
		}
	}
}
