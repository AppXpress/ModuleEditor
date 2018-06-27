using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ModuleEditor
{
	class Field
	{
		private List<XElement> all_fields;
		private XElement field;

		// Creates a new field object using the list of all fields and the selected field
		public Field(List<XElement> all_fields, XElement field)
		{
			this.all_fields = all_fields;
			this.field = field;
		}

		// Finds a field in the list of all fields using a name
		public static Field Find(List<XElement> all_fields, string name)
		{
			var field = all_fields.Find(x => x.Element("fieldName").Value == name);
			return new Field(all_fields, field);
		}

		// Remvoes a field from all fields
		public void Remove()
		{
			all_fields.Remove(field);
		}

		// Copies a field into a new object
		public Field Copy()
		{
			var copy = XElement.Parse(field.ToString());
			all_fields.Add(copy);
			return new Field(all_fields, copy);
		}

		public string Name
		{
			get
			{
				return field.Element("fieldName").Value;
			}
			set
			{
				field.Element("fieldName").Value = value;
			}
		}

		public string Description
		{
			get
			{
				return field.Element("description").Value;
			}
			set
			{
				field.Element("description").Value = value;
			}
		}

		public int Position
		{
			get
			{
				return int.Parse(field.Element("fieldPosition").Value);
			}
			set
			{
				field.Element("fieldPosition").Value = value.ToString();
			}
		}

		public bool Indexed
		{
			get
			{
				return field.Element("indexed").Value == "true";
			}
			set
			{
				field.Element("indexed").Value = value.ToString();
			}
		}
	}
}
