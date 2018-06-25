using System;
using System.Xml.Linq;

namespace ModuleEditor
{
	class Design : IDisposable
	{
		private static string design_path(string type) { return "CustomObjectModule/designs/Design_" + type + ".xml"; }
		private static string schema_path(string type) { return "CustomObjectModule/xsd/" + type + ".xsd"; }

		private Archive archive;
		private XDocument design;
		private XDocument schema;

		/// <summary>Loads a design of the given type from the given archvie</summary>
		/// <param name="archive">The archive object to load from</param>
		/// <param name="type">The type name of the design to load</param>
		public Design(Archive archive, string type)
		{
			this.archive = archive;
			design = archive.LoadXML(design_path(type));
			if (Primary)
			{
				schema = archive.LoadXML(schema_path(type));
			}
		}

		/// <summary>Finalizes the changes to the design</summary>
		public void Dispose()
		{
			archive.StoreXML(design_path(Type), design);
			if (schema != null)
			{
				archive.StoreXML(schema_path(Type), schema);
			}
		}

		/// <summary>Removes a design from the archive</summary>
		/// <param name="archive">The archive to remove the design from</param>
		/// <param name="type">The design type to remove</param>
		public static void Remove(Archive archive, string type)
		{
			var design = new Design(archive, type);
			archive.RemoveFile(design_path(type));
			if (design.Primary)
			{
				archive.RemoveFile(schema_path(type));
			}
		}

		public string Type
		{
			get
			{
				return design.Element("CustomObjectDesignV110").Element("globalObjectType").Value;
			}
			set
			{
				design.Element("CustomObjectDesignV110").Element("globalObjectType").Value = value;
			}
		}

		public bool Primary
		{
			get
			{
				return design.Element("CustomObjectDesignV110").Element("designType").Value == "PRIMARY";
			}
		}
	}
}
