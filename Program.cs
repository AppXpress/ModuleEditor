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
			broker.AddCommand(new EchoCommand());
			broker.AddCommand(new ClearCommand());

			broker.AddCommand(new ImportCommand(broker));
			broker.AddCommand(new ExportCommand(broker));

			broker.AddCommand(new SelectCommand(broker));
			broker.AddCommand(new RemoveCommand(broker));

			broker.AddCommand(new ListCommand(broker));
			broker.AddCommand(new GetCommand(broker));
			broker.AddCommand(new SetCommand(broker));

			// Evaluates each line of input until the user quits
			while (true)
			{
				Console.Write("> ");
				var line = Console.ReadLine();
				if (line.Length == 0) { continue; }
				broker.Run(line);
			}
		}
	}
}
