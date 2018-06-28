using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AppX
{
	class Design
	{
		private List<XDocument> all_designs;
		private XDocument design;
		private XElement fields_parent;

		// Creates a design object from the list of all designs and a design type
		public Design(List<XDocument> all_designs, string type)
		{
			this.all_designs = all_designs;
			design = all_designs.Find(x => GetType(x) == type);

			fields_parent = design.Element("CustomObjectDesignV110");
		}

		// Gets a field by name using the field find
		public Field Field(string name)
		{
			return new Field(fields_parent, name);
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
			return new Design(all_designs, GetType(copy));
		}

		// Gets the type of a design from the XDocument format
		public static string GetType(XDocument design)
		{
			return design.Element("CustomObjectDesignV110").Element("globalObjectType").Value;
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
