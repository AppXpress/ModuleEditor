using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace AppX
{
	// Represents a ZIP archive of a AppX platform module
	partial class Module : IDisposable
	{
		// Archive instance data
		private string folder;
		private bool temporary;

		// Instance variables for module and designs
		private XDocument data;
		private Properties meta;
		private List<XDocument> all_designs;

		// Creates a new archive
		// folder is the location of the extracted ZIP
		// temporary is a flag indicating if the folder should be deleted after
		public Module(string folder, bool temporary = false)
		{
			this.folder = folder;
			this.temporary = temporary;

			all_designs = new List<XDocument>();
		}

		// Deletes the folder if it was temporary
		public void Dispose()
		{
			if (temporary)
			{
				Directory.Delete(folder, true);
			}
		}

		// Gets if the module is a temporary module
		public bool GetTemp()
		{
			return temporary;
		}

		// Gets a design from the archive data
		public Design Design(string type)
		{
			return new Design(all_designs, type);
		}

		public string[] List()
		{
			var list = new List<string>();
			foreach (var design in all_designs)
			{
				list.Add(AppX.Design.GetType(design));
			}
			return list.ToArray();
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
