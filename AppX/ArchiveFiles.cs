using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AppX
{
	// Adds file editing methods to the archive class
	partial class Archive
	{
		// Loads an XML document from the archive
		private XDocument LoadXML(string file)
		{
			return XDocument.Load(FullPath(file));
		}

		// Stores an XML document back in the folder
		private void StoreXML(string file, XDocument xml)
		{
			var settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			settings.Encoding = Encoding.ASCII;

			using (var writer = XmlWriter.Create(FullPath(file), settings))
			{
				xml.Save(writer);
			}
		}

		// Loads a properties file from the archive
		private Properties LoadProps(string file)
		{
			return Properties.Load(FullPath(file));
		}

		// Stores a properties file back in the archive
		private void StoreProps(string file, Properties props)
		{
			props.Save(FullPath(file));
		}

		// Gets a random temporary path for writing data
		private static string TempPath()
		{
			return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
		}

		// Converts relative path arguments to full archive paths
		private string FullPath(string file)
		{
			return Path.Combine(folder, file);
		}

		// Removes a file from the archive
		private void Delete(string file)
		{
			File.Delete(FullPath(file));
		}

		// Gets the contents of a folder in the archive
		private string[] Files(string dir)
		{
			var paths = Directory.GetFiles(FullPath(dir));
			var files = new string[paths.Length];

			for (var index = 0; index < paths.Length; index++)
			{
				files[index] = Path.Combine(dir, Path.GetFileName(paths[index]));
			}

			return files;
		}
	}
}
