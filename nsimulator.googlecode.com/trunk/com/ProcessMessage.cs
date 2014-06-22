using System;
using middleware.or.id.nSwitch4me.iso;
using System.Configuration;

namespace middleware.or.id.nSwitch4me.com
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ProcessMessage
	{
		private string input = "";
		private static AppSettingsReader configurationAppSettings;
		
		public ProcessMessage() 
		{
			configurationAppSettings = new System.Configuration.AppSettingsReader();
		}

		public ProcessMessage(string input)
		{
			this.input = input;
		}
		public string getOutputProcess() 
		{
			string XmlFile = ((string)(configurationAppSettings.GetValue("IsoXMLFile", typeof(string))));
			string result = "";
			Console.WriteLine( "UnPacking running ..." );
			ISOPackager c = new ISOPackager();
			c.IsoXmlFile = XmlFile;
			ISOMsg msgIso = new ISOMsg();
			msgIso.debug = true;
			msgIso.ASCIIMessage = this.input;
			c.ISOMsgObject = msgIso;			
			c.unpack();
					
			Console.WriteLine( "Packing with update field ..." );
			c.ISOMsgObject.set(0, "0810");
			c.ISOMsgObject.set(39, "00");
			c.pack();
			result =  c.ISOMsgObject.ASCIIMessage;
			return result;
		}
	}
}
