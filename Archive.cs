using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ModuleEditor
{
	class Archive : IDisposable
	{
		private string folder;

		/// <summary>Creates a new archive object from the ZIP file at the given path</summary>
		/// <param name="path">The path to the source ZIP file</param>
		public Archive(string path)
		{
			folder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

			if (File.Exists(path))
			{
				ZipFile.ExtractToDirectory(path, folder);
			}
		}

		/// <summary>Cleans up temporary files from the archive</summary>
		public void Dispose()
		{
			Directory.Delete(folder, true);
		}

		/// <summary>Exports the archive data into a new ZIP file</summary>
		/// <param name="path">The path to export the archive ZIP into</summary>
		/// <param name="force">Set true to overwrite existing files<param>
		public void Export(string path, bool force = false)
		{
			if (File.Exists(path))
			{
				if (!force)
				{
					throw new Exception("Export path already exists, export failed");
				}
				File.Delete(path);
			}
			ZipFile.CreateFromDirectory(folder, path);
		}



		public Module LoadModule()
		{
			return new Module(this);
		}

		public Design LoadDesign(string type)
		{
			return new Design(this, type);
		}

		public void RemoveDesign(string type)
		{
			Design.Remove(this, type);
		}



		/// <summary>Loads an XML document from the archive</summary>
		/// <param name="file">The path to the file to load as XML</param>
		/// <returns>An XDocument of the file at the given path</returns>
		public XDocument LoadXML(string file)
		{
			return XDocument.Load(Path.Combine(folder, file));
		}

		/// <summary>Saves an XML document back into the archive</summary>
		/// <param name="file">The path to store the XML in</param>
		/// <param name="xml">The XML file to store in the archive</param>
		public void StoreXML(string file, XDocument xml)
		{
			var outpath = Path.Combine(folder, file);
			var settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			settings.Encoding = Encoding.ASCII;

			using (var writer = XmlWriter.Create(outpath, settings))
			{
				xml.Save(writer);
			}
		}

		/// <summary>Loads a properties file from the archive</summary>
		/// <param name="file">The path to the file to load as properties</param>
		/// <returns>A properties object of the file at the given path</returns>
		public Properties LoadProps(string file)
		{
			return Properties.Load(Path.Combine(folder, file));
		}

		/// <summary>Saves a properties file back into the archive</summary>
		/// <param name="file">The path to store the properties in</param>
		/// <param name="props">The properties file object to store in the archive</param>
		public void StoreProps(string file, Properties props)
		{
			props.Save(Path.Combine(folder, file));
		}


		/// <summary>Removes a file from the archive</summary>
		/// <param name="path">Path to the file to be removed</param>
		public void RemoveFile(string file)
		{
			File.Delete(Path.Combine(folder, file));
		}
	}
}
