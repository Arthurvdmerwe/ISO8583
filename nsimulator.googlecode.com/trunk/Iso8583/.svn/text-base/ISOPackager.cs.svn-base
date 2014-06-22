using System;
using System.Xml;
using System.Collections;

namespace middleware.or.id.nSwitch4me.iso
{
	/* 
	 *	Created		: 18 December 2004
	 * License		: Free 
	 * Copyright	: Widyantoro @ 2004 (&ar)
	 * */
	public class ISOPackager
	{
		
		private ISOMsg isoMsg;
		private int ISOMaxField = 0;
		private string iIsoAscii = "";
		private Hashtable iField = null;
		private ISOFieldAttribute iXWork;
		private bool isdebug = false;
		private string isoXmlFile = "iso8583_87dtd.xml";

		/*
		 * TODO: Add constructor logic here
		 * */
		public ISOPackager()
		{
		}		
				
		private void loadPackager() 
		{
			try
			{
				isdebug = isoMsg.debug;
				XmlTextReader reader = new XmlTextReader(isoXmlFile);
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.Element:
							Hashtable attributes = new Hashtable();
							string strURI= reader.NamespaceURI;
							string strName= reader.Name;
							if (reader.HasAttributes)
							{
								for (int i = 0; i < reader.AttributeCount; i++)
								{
									reader.MoveToAttribute(i);
									attributes.Add(reader.Name,reader.Value);
								}
							}

							/*
							 * Safe to hashtable							
							 * */							
							if (!(strName.Equals("isopackager")))
							{
								IDictionaryEnumerator en = attributes.GetEnumerator();
								ISOFieldAttribute iX = new ISOFieldAttribute();				
								while (en.MoveNext())
								{
									if (en.Key.ToString()=="id") iX.id = en.Value.ToString();
									if (en.Key.ToString()=="length") iX.length = en.Value.ToString();
									if (en.Key.ToString()=="name") iX.name = en.Value.ToString();
									if (en.Key.ToString()=="class") iX.classid = en.Value.ToString();
									if (en.Key.ToString()=="token") iX.token = en.Value.ToString();
									if (en.Key.ToString()=="pad") iX.pad = en.Value.ToString();
								}
								iField.Add(iX.id, iX);
							}
							else
							{
								IDictionaryEnumerator en = attributes.GetEnumerator();
								while (en.MoveNext())
								{
									if (en.Key.ToString()  == "maxValidField") 
									{
										ISOMaxField = int.Parse(en.Value.ToString());
										iField = new Hashtable(ISOMaxField+1);
									}					
								}
							}

							break;

							/*
							 * you can handle other cases here : 
							 * - case XmlNodeType.EndElement
							 * - case XmlNodeType.Text
							 * */
						default:
							break;
					}
				}
			}
			catch (XmlException e) 
			{
				Console.WriteLine("error occured: " + e.Message);
			}
		}

		public void unpack()
		{
			/*
			 * TODO: Add code to start application here
			 **/						
			try 
			{
				loadPackager();
				iIsoAscii = isoMsg.ASCIIMessage;
				
				/// Max Field
				isoMsg.MaxField = ISOMaxField;
				/// MTI First
				iXWork = (ISOFieldAttribute)iField["0"];
				isoMsg.MTI = ISOBaseField.pickField(ref iIsoAscii, iXWork);
				isoMsg.FieldHash[0] = isoMsg.MTI;
				if (isdebug) Console.WriteLine("<id_" + iXWork.id + ">" 
					+ "<" + iXWork.name + ">" + isoMsg.MTI + "</" + iXWork.name + ">" 
					+ "</id_" + iXWork.id + ">");
				/// BitMap
				iXWork = (ISOFieldAttribute)iField["1"];
				string bit = ISOBaseField.pickField(ref iIsoAscii, iXWork);
				Hashtable bitmap = ISOBaseField.HashBitMap(bit);
				isoMsg.BitMapHash = bitmap;
				isoMsg.FieldHash[1] = bit;
				/// Next Field Automatic Hashmap
				for (int c = 2; c<ISOMaxField+1; c++)
				{
					if (isoMsg.hasField(c)) 
					{
						iXWork = (ISOFieldAttribute)iField[c.ToString()];
						isoMsg.FieldHash[c] = ISOBaseField.pickField(ref iIsoAscii, iXWork);
						if (isdebug) Console.WriteLine("<id_" + iXWork.id + ">"
							+	"<" + iXWork.name + ">" + isoMsg.FieldHash[c] + "</" + iXWork.name + ">" 
							+	"</ID_" + iXWork.id + ">");					
					}
				}
			}
			catch (Exception ee)
			{
					Console.WriteLine(("Invalid ISO Message") + " - " + ee.Message);				
			}
		
		}


		public void pack() 
		{
			string r = "";
			try 
			{
				loadPackager();
				
				/* 
				 * MTI First
				 * */
				iXWork = (ISOFieldAttribute)iField["0"];
				r += ISOBaseField.putField(isoMsg.FieldHash, iXWork);
				if (isdebug) Console.WriteLine("MTI:" + r);
				
				/*
				 * Bitmap Generator				
				 * */
				iXWork = (ISOFieldAttribute)iField["1"];
				r += ISOBaseField.putField(isoMsg.BitMapHash, iXWork);
				
				for (int i=2; i<isoMsg.MaxField+1; i++) 
				{
					if (isoMsg.hasField(i))
					{						
						iXWork = (ISOFieldAttribute)iField[i.ToString()];	
						r += ISOBaseField.putField(isoMsg.FieldHash, iXWork); 
						if (isdebug) Console.WriteLine("<id_" + iXWork.id + ">"
							+	"<" + iXWork.name + ">" 
							+	ISOBaseField.putField(isoMsg.FieldHash, iXWork)
							+	"</" + iXWork.name + ">"
							+	"</id_" + iXWork.id + ">");					
					}
				}
				isoMsg.ASCIIMessage = r;				
			}
			catch (Exception ee)
			{
				Console.WriteLine("Packing error occured: " + ee.Message);
			}	
		}

		private void StartElement(string namespaceURI,string sName,string qName,Hashtable attrs) 
		{
			if (isdebug) Console.WriteLine(qName);
			IDictionaryEnumerator en = attrs.GetEnumerator();
			while (en.MoveNext())
			{
				if (isdebug) Console.WriteLine("--" + en.Key + " : " + en.Value);
			}
		}
		

		public ISOMsg ISOMsgObject
		{
			get
			{
				return isoMsg;
			}
			set
			{
				isoMsg = value;
			}
		}

		public string IsoXmlFile
		{
			get
			{
				return isoXmlFile;
			}
			set
			{
				isoXmlFile = value;
			}
		}

	}
}