using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ModuleEditor
{
	class Module : IDisposable
	{
		private static string config_file = "PlatformModule.xml";
		private static string metadata_file = "metadata.properties";

		private Archive archive;
		private XDocument config;
		private Properties metadata;

		/// <summary>Loads a platform module from the given archive</summary>
		/// <param name="archive">The archvie object to load from</param>
		public Module(Archive archive)
		{
			this.archive = archive;
			config = archive.LoadXML(config_file);
			metadata = archive.LoadProps(metadata_file);
		}

		/// <summary>Finalizes changes to the module and stores in the archive</summary>
		public void Dispose()
		{
			archive.StoreXML(config_file, config);
			archive.StoreProps(metadata_file, metadata);
		}

		public string Name
		{
			get
			{
				return config.Element("PlatformModule400").Element("name").Value;
			}
			set
			{
				config.Element("PlatformModule400").Element("name").Value = value;
				metadata.Set("name", value);
			}
		}

		public string Description
		{
			get
			{
				return config.Element("PlatformModule400").Element("description").Value;
			}
			set
			{
				config.Element("PlatformModule400").Element("description").Value = value;
			}
		}
	}
}
