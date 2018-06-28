using System.Xml.Linq;

namespace AppX
{
	static class XExtend
	{
		public static XElement Grab(this XElement parent, XName name)
		{
			var element = parent.Element(name);
			if (element == null)
			{
				element = new XElement(name);
				parent.Add(element);
			}
			return element;
		}
	}
}
