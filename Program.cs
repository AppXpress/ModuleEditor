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
			broker.AddCommand(new HelpCommand(broker));

			broker.AddCommand(new ExitCommand());
			broker.AddCommand(new EchoCommand());
			broker.AddCommand(new ClearCommand());

			broker.AddCommand(new ImportCommand(broker));
			broker.AddCommand(new ExportCommand(broker));

			broker.AddCommand(new SelectCommand(broker));
			broker.AddCommand(new RemoveCommand(broker));
			broker.AddCommand(new NameCommand(broker));
			broker.AddCommand(new DescCommand(broker));
			broker.AddCommand(new TypeCommand(broker));

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
