using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AppX
{
	// Represents a design in an AppX platform module
	class Design
	{
		// Gets the type of a design from the XDocument format
		public static string GetType(XDocument design)
		{
			return design.Element("CustomObjectDesignV110").Element("globalObjectType").Value;
		}

		private List<XDocument> designs;
		private XElement data;

		public Design(List<XDocument> designs, string type)
		{
			this.designs = designs;

			var find = designs.Find(x => Design.GetType(x) == type);
			if (find == null)
			{
				throw new Exception("Design not found.");
			}
			data = find.Element("CustomObjectDesignV110");
		}

		public Field Field(string name)
		{
			return new Field(data, name);
		}

		public void Remove()
		{
			designs.Remove(data.Document);
		}

		public string Type
		{
			get { return data.Element("globalObjectType").Value; }
			private set { data.Element("globalObjectType").Value = value; }
		}

		public string Name
		{
			get { return data.Element("name").Value; }
			set
			{
				Type = Type.Replace(Name, value);
				data.Element("name").Value = value;
			}
		}

		public string Description
		{
			get { return data.Element("description").Value; }
			set { data.Element("description").Value = value; }
		}

		public bool Primary
		{
			get { return data.Element("designType").Value == "PRIMARY"; }
		}
	}
}
