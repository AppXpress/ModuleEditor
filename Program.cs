using AppX;
using System;

namespace ModuleEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start");

			using (var archive = Archive.Import("../modules/CRTaskDashboard-1098490738_v100.zip"))
			{
				var module = archive.Module();
				module.Name = "TestModule";
				module.Description = "This module is for testing the module editor";

				var design = archive.Design("$BlankB1");
				design.Name = "TestDesign";
				design.Description = "Test description";

				// var field = design.Field("licensee");
				// field.Description = "Hello!";

				// var design2 = design.Copy();
				// design2.Name = "CopyDesign";
				// design2.Description = "Copy description";

				// var field2 = design2.Field("licensee");
				// field2.Description = "Goodbye!";

				archive.Export("../modules/test.zip", true);
			}

			Console.WriteLine("Finish");
		}
	}
}
