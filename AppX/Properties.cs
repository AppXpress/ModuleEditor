using System;
using System.Collections.Generic;
using System.IO;

namespace AppX
{
	class Properties
	{
		private List<string> lines;

		private Properties() { }

		public static Properties Load(string path)
		{
			var lines = File.ReadAllLines(path);
			var result = new Properties();
			result.lines = new List<string>(lines);
			return result;
		}

		public void Save(string path)
		{
			File.WriteAllLines(path, lines);
		}

		public string Get(string key)
		{
			foreach (var line in lines)
			{
				if (line.StartsWith(key + "="))
				{
					return line.Replace(key + "=", "");
				}
			}
			return null;
		}

		public void Set(string key, string value)
		{
			var set = key + "=" + value;

			for (var id = 0; id < lines.Count; id++)
			{
				var line = lines[id];
				if (line.StartsWith(key + "="))
				{
					lines[id] = set;
					return;
				}
			}

			lines.Add(set);
		}
	}
}
