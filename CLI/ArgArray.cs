using System.Collections.Generic;

namespace CLI
{
	// Represents an array of arguments
	static class ArgArray
	{
		// Parse a string into an argument array
		// Inteprets spaces as argument separators
		// Will include spaces in quoted strings
		// Allows backslash escaping for quotes and other backslashes
		public static string[] Parse(string input)
		{
			var items = new List<string>();

			var buffer = "";
			var quoted = false;
			var escape = false;

			foreach (char c in input)
			{
				if (c == '"')
				{
					if (escape)
					{
						escape = false;
						buffer += c;
					}
					else
					{
						quoted = !quoted;
						if (buffer.Length > 0)
						{
							items.Add(buffer);
							buffer = "";
						}
					}
				}
				else if (c == ' ')
				{
					if (quoted)
					{
						buffer += c;
					}
					else if (buffer.Length > 0)
					{
						items.Add(buffer);
						buffer = "";
					}
				}
				else if (c == '\\')
				{
					if (escape)
					{
						buffer += c;
					}
					escape = !escape;
				}
				else
				{
					buffer += c;
				}
			}
			if (buffer.Length > 0)
			{
				items.Add(buffer);
			}

			return items.ToArray();
		}
	}
}
