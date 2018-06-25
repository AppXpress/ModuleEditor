using System;

namespace ModuleEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var archive = new Archive("../modules/CRTaskDashboard-1098490738_v100.zip"))
			{
				using (var module = archive.LoadModule())
				{
					module.Name = "CRTaskDash";
					module.Description = "just a test!";
				}

				using (var design = archive.LoadDesign("$BlankB1"))
				{
					design.Type = "$TestTypeT1";
					Design.Remove(archive, "$BlankB1");
				}

				archive.Export("../modules/new.zip", true);
			}
		}
	}
}
