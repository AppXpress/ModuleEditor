using System;
using System.Xml.Linq;

namespace AppX
{
	static class XExtend
	{
		private static XContainer GrabContainer(this XContainer parent, XName name)
		{
			var element = parent.Element(name);
			if (element == null)
			{
				element = new XElement(name);
				parent.Add(element);
			}
			return element;
		}

		// Gets an element by name or returns a new element
		public static XElement Grab(this XElement parent, XName name)
		{
			return (XElement)parent.GrabContainer(name);
		}

		public static XElement Grab(this XDocument parent, XName name)
		{
			return (XElement)parent.GrabContainer(name);
		}
	}
}
