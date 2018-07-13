using System.IO;
using System.IO.Compression;

namespace AppX
{
	partial class Module
	{
		// File location constants
		private const string data_file = "PlatformModule.xml";
		private const string meta_file = "metadata.properties";
		private const string design_folder = "CustomObjectModule/designs";

		// Loads all module data
		public void LoadData()
		{
			data = LoadXML(data_file);
			meta = LoadProps(meta_file);

			foreach (var file in Files(design_folder))
			{
				all_designs.Add(LoadXML(file));
				Delete(file);
			}
		}

		// Stores module data back
		public void StoreData()
		{
			StoreXML(data_file, data);
			StoreProps(meta_file, meta);

			foreach (var design in all_designs)
			{
				var type = AppX.Design.GetType(design);
				var file = design_folder + "/Design_" + type + ".xml";
				StoreXML(file, design);
			}
		}

		// Imports a ZIP archive from the given path
		// Returns an archive object for modifiying
		public static Module Import(string path)
		{
			var temp = TempPath();
			ZipFile.ExtractToDirectory(path, temp);
			var module = new Module(temp, true);
			module.LoadData();
			return module;
		}

		// Exports the data back into a ZIP archive
		// path is the location to save the ZIP to
		// force is flag indicating existing file should be overwritten
		public void Export(string path, bool force = false)
		{
			StoreData();
			if (force) { File.Delete(path); }
			ZipFile.CreateFromDirectory(folder, path);
		}
	}
}
