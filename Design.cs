using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ModuleEditor
{
	class Design
	{
		private List<XDocument> all_designs;
		private XDocument design;
		private List<XElement> all_fields;

		// Creates a new design object using the list of all designs and the selected design
		public Design(List<XDocument> all_designs, XDocument design)
		{
			this.all_designs = all_designs;
			this.design = design;

			all_fields = new List<XElement>();

			foreach (var field in design.Element("CustomObjectDesignV110").Elements("scalarField"))
			{
				all_fields.Add(field);
			}
		}

		// Gets the type of a design from the XDocument format
		public static string GetType(XDocument design)
		{
			return design.Element("CustomObjectDesignV110").Element("globalObjectType").Value;
		}

		// Finds a design from the list of all designs using the given type
		public static Design Find(List<XDocument> all_designs, string type)
		{
			var design = all_designs.Find(x => GetType(x) == type);
			return new Design(all_designs, design);
		}

		// Gets a field by name using the field find
		public Field Field(string name)
		{
			return ModuleEditor.Field.Find(all_fields, name);
		}

		// Removes a design from the module
		public void Remove()
		{
			all_designs.Remove(design);
		}

		// Copies a design to a new object
		public Design Copy()
		{
			var copy = XDocument.Parse(design.ToString());
			all_designs.Add(copy);
			return new Design(all_designs, copy);
		}

		public string Type
		{
			get
			{
				return GetType(design);
			}
		}

		public string Name
		{
			get
			{
				return design.Element("CustomObjectDesignV110").Element("name").Value;
			}
			set
			{
				design.Element("CustomObjectDesignV110").Element("globalObjectType").Value = "$" + value + Type.Replace("$" + Name, "");
				design.Element("CustomObjectDesignV110").Element("name").Value = value;
			}
		}

		public string Description
		{
			get
			{
				return design.Element("CustomObjectDesignV110").Element("description").Value;
			}
			set
			{
				design.Element("CustomObjectDesignV110").Element("description").Value = value;
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
