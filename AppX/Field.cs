using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AppX
{
	class Field
	{
		private XElement parent;
		private XElement field;

		public Field(XElement parent, string name)
		{
			this.parent = parent;
			field = parent.Elements("scalarField").FirstOrDefault(x => x.Grab("fieldName").Value == name);

			if (field == null)
			{
				field = new XElement("scalarField");
				parent.Add(field);
				Name = name;
			}
		}

		public void Remove()
		{
			field.Remove();
		}

		public string Name
		{
			get { return field.Grab("fieldName").Value; }
			set { field.Grab("fieldName").Value = value; }
		}

		public string Description
		{
			get { return field.Grab("description").Value; }
			set { field.Grab("description").Value = value; }
		}

		public int Position
		{
			get { return int.Parse(field.Grab("fieldPosition").Value); }
			set { field.Grab("fieldPosition").Value = value.ToString(); }
		}

		public bool Indexed
		{
			get { return field.Grab("indexed").Value == "true"; }
			set { field.Grab("indexed").Value = value.ToString(); }
		}

		public bool Summary
		{
			get { return field.Grab("summaryField").Value == "true"; }
			set { field.Grab("summaryField").Value = value.ToString(); }
		}

		public int MaxLength
		{
			get { return int.Parse(field.Grab("maxLength").Value); }
			set { field.Grab("maxLength").Value = value.ToString(); }
		}
	}
}
