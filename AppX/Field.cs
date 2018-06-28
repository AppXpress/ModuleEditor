using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AppX
{
	class Field
	{
		private XElement parent;
		private XElement data;

		public Field(XElement parent, string name)
		{
			this.parent = parent;
			data = parent.Elements("scalarField").FirstOrDefault(x => x.Grab("fieldName").Value == name);

			if (data == null)
			{
				data = new XElement("scalarField");
				parent.Add(data);
				Name = name;
			}
		}

		public void Remove()
		{
			data.Remove();
		}

		public string Name
		{
			get { return data.Grab("fieldName").Value; }
			set { data.Grab("fieldName").Value = value; }
		}

		public string Description
		{
			get { return data.Grab("description").Value; }
			set { data.Grab("description").Value = value; }
		}

		public int Position
		{
			get { return int.Parse(data.Grab("fieldPosition").Value); }
			set { data.Grab("fieldPosition").Value = value.ToString(); }
		}

		public bool Indexed
		{
			get { return data.Grab("indexed").Value == "true"; }
			set { data.Grab("indexed").Value = value.ToString(); }
		}

		public bool Summary
		{
			get { return data.Grab("summaryField").Value == "true"; }
			set { data.Grab("summaryField").Value = value.ToString(); }
		}

		public int MaxLength
		{
			get { return int.Parse(data.Grab("maxLength").Value); }
			set { data.Grab("maxLength").Value = value.ToString(); }
		}
	}
}
