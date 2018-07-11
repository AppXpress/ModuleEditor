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

			broker.Commands.Add(new SelectCommand(broker));
			broker.Commands.Add(new ModuleCommand(broker));
			broker.Commands.Add(new DesignCommand(broker));
			broker.Commands.Add(new FieldCommand(broker));

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
