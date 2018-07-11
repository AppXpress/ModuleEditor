using System;
using System.Xml.Linq;

namespace AppX
{
	// Represents the module itself in the AppX archive
	class Module
	{
		private XDocument data;
		private Properties meta;

		// Creates a new module using the module data
		public Module(XDocument data, Properties meta)
		{
			this.data = data;
			this.meta = meta;
		}

		public string Name
		{
			get { return data.Grab("PlatformModule400").Grab("name").Value; }
			set
			{
				data.Grab("PlatformModule400").Grab("name").Value = value;
				meta.Set("name", value);
			}
		}

		public string Description
		{
			get { return data.Grab("PlatformModule400").Grab("description").Value; }
			set { data.Grab("PlatformModule400").Grab("description").Value = value; }
		}
	}
}
