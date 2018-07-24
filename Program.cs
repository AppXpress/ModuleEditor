using AppX;
using CLI;
using System;

namespace ModuleEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			// Creates a broker with the standard commands
			var broker = new CommandBroker();
			broker.AddCommand(new HelpCommand(broker));

			broker.AddCommand(new ExitCommand());
			broker.AddCommand(new ClearCommand());

			broker.AddCommand(new ImportCommand(broker));
			broker.AddCommand(new ExportCommand(broker));

			broker.AddCommand(new MountCommand(broker));
			broker.AddCommand(new PersistCommand(broker));

			broker.AddCommand(new ListCommand(broker));
			broker.AddCommand(new GetCommand(broker));
			broker.AddCommand(new SetCommand(broker));

			broker.AddCommand(new LSCommand(broker));
			broker.AddCommand(new CDCommand(broker));
			broker.AddCommand(new RMCommand(broker));

			Console.WriteLine("GTN Module Editor");
			Console.WriteLine("Import a module to get started.");
			Console.WriteLine("Enter 'help' for assistance.");
			Console.WriteLine();

			// Evaluates each line of input until the user quits
			while (true)
			{
				Console.Write(broker.SelectedPath + "> ");
				var line = Console.ReadLine();
				if (line.Length == 0) { continue; }
				broker.Run(line);
			}
		}
	}
}
