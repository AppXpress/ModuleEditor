using AppX;
using CLI;
using System;

namespace ModuleEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			var broker = new CommandBroker();
			broker.Commands.Add(new HelpCommand(broker));

			broker.Commands.Add(new ExitCommand());
			broker.Commands.Add(new EchoCommand());
			broker.Commands.Add(new ClearCommand());

			broker.Commands.Add(new ImportCommand(broker));
			broker.Commands.Add(new ExportCommand(broker));

			while (true)
			{
				Console.Write("> ");
				var line = Console.ReadLine();
				if (line.Length == 0) { continue; }
				broker.Run(line);
			}

			// Console.WriteLine("Module Editor running.");
			// Console.WriteLine("Enter 'help' for more options.");
			// Console.WriteLine("Enter 'exit' to quit.");

			// Archive archive = null;
			// Module module = null;
			// Design design = null;
			// Field field = null;

			// try
			// {
			// 	while (true)
			// 	{
			// 		Console.Write("> ");
			// 		var input = Console.ReadLine();
			// 		if (input.Length == 0) { continue; }
			// 		var reader = new CommandReader(input);

			// 		switch (reader.GetNext())
			// 		{
			// 			case "help":
			// 				Console.WriteLine("[] is required argument, <> is optional argument");
			// 				Console.WriteLine("exit -- quit the program");
			// 				Console.WriteLine("import [path] -- load an archive from path to ZIP");
			// 				Console.WriteLine("export [path] -- save an archive to ZIP at path");
			// 				Console.WriteLine("name <set> -- gets or sets the name of the module");
			// 				Console.WriteLine("desc <set> -- gets or sets the description of the module");
			// 				break;

			// 			case "exit":
			// 				return;

			// 			case "import":
			// 				if (reader.HasNext())
			// 				{
			// 					if (archive != null) { archive.Dispose(); }
			// 					archive = Archive.Import(reader.GetNext());
			// 					module = archive.Module();
			// 					Console.WriteLine(module.Name);
			// 					Console.WriteLine(module.Description);
			// 				}
			// 				else
			// 				{
			// 					Console.WriteLine("No path specified, cannot import.");
			// 				}
			// 				break;

			// 			case "export":
			// 				if (reader.HasNext())
			// 				{
			// 					if (archive == null) { break; }
			// 					archive.Export(reader.GetNext());
			// 				}
			// 				else
			// 				{
			// 					Console.WriteLine("No path specified, cannot export.");
			// 				}
			// 				break;

			// 			case "name":
			// 				if (reader.HasNext())
			// 				{
			// 					Console.WriteLine(module.Name);
			// 				}
			// 				else
			// 				{
			// 					module.Name = reader.GetNext();
			// 				}
			// 				break;

			// 			case "desc":
			// 				if (reader.HasNext())
			// 				{
			// 					Console.WriteLine(module.Description);
			// 				}
			// 				else
			// 				{
			// 					module.Description = reader.GetNext();
			// 				}
			// 				break;

			// 			case "design":
			// 				if (reader.HasNext())
			// 				{
			// 					Console.WriteLine("No design name given, cannot select.");
			// 				}
			// 				else
			// 				{
			// 					design = archive.Design(reader.GetNext());
			// 				}
			// 				break;

			// 			default:
			// 				Console.WriteLine("Command not recognized. Enter 'help' for options.");
			// 				break;
			// 		}
			// 	}
			// }
			// finally
			// {
			// 	if (archive != null)
			// 	{
			// 		archive.Dispose();
			// 	}
			// }



			// // using (var archive = Archive.Import("../modules/CRTaskDashboard-1098490738_v100.zip"))
			// using (var archive = Archive.Import("../modules/IssueTracker-83901514_v100.zip"))
			// {
			// 	var module = archive.Module();
			// 	module.Name = "TestModule";
			// 	module.Description = "This module is for testing the module editor";

			// 	var design = archive.Design("$GenericAnchorT1");

			// 	var field = design.Field("objectType");
			// 	field.Remove();

			// 	// var design = archive.Design("$BlankB1");
			// 	// design.Name = "TestDesign";
			// 	// design.Description = "Test description";

			// 	// var field = design.Field("licensee");
			// 	// field.Description = "Hello!";

			// 	// var design2 = design.Copy();
			// 	// design2.Name = "CopyDesign";
			// 	// design2.Description = "Copy description";

			// 	// var field2 = design2.Field("licensee");
			// 	// field2.Description = "Goodbye!";

			// 	archive.Export("../modules/test.zip", true);
			// }
		}
	}
}
