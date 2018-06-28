using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace AppX
{
	partial class Archive : IDisposable
	{
		// File location constants
		private const string module_data_file = "PlatformModule.xml";
		private const string module_meta_file = "metadata.properties";
		private const string design_folder = "CustomObjectModule/designs";

		// Archive instance data
		private string folder;
		private bool temporary;

		// Instance variables for module and designs
		private XDocument module_data;
		private Properties module_meta;
		private List<XDocument> all_designs;

		// Creates a new archive
		// folder is the location of the extracted ZIP
		// temporary is a flag indicating if the folder should be deleted after
		public Archive(string folder, bool temporary = false)
		{
			this.folder = folder;
			this.temporary = temporary;

			all_designs = new List<XDocument>();

			module_data = LoadXML(module_data_file);
			module_meta = LoadProps(module_meta_file);

			foreach (var file in Files(design_folder))
			{
				all_designs.Add(LoadXML(file));
				Delete(file);
			}
		}

		// Deletes the folder if it was temporary
		public void Dispose()
		{
			if (temporary)
			{
				Directory.Delete(folder, true);
			}
		}

		// Imports a ZIP archive from the given path
		// Returns an archive object for modifiying
		public static Archive Import(string path)
		{
			var temp = TempPath();
			ZipFile.ExtractToDirectory(path, temp);
			return new Archive(temp, true);
		}

		// Exports the data back into a ZIP archive
		// path is the location to save the ZIP to
		// force is flag indicating existing file should be overwritten
		public void Export(string path, bool force = false)
		{
			StoreXML(module_data_file, module_data);
			StoreProps(module_meta_file, module_meta);

			foreach (var design in all_designs)
			{
				var type = AppX.Design.GetType(design);
				var file = design_folder + "/Design_" + type + ".xml";
				StoreXML(file, design);
			}

			if (force) { File.Delete(path); }
			ZipFile.CreateFromDirectory(folder, path);
		}

		// Gets the module that this archive represents
		public Module Module()
		{
			return new Module(module_data, module_meta);
		}

		// Gets a design from the archive data
		public Design Design(string type)
		{
			return new Design(all_designs, type);
		}
	}
}
