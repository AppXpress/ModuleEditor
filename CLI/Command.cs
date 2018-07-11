using AppX;
using System;
using System.Collections.Generic;

namespace CLI
{
	interface Command
	{
		string Name();
		string Args();
		string Info();
		void Run(string[] args);
	}

	class HelpCommand : Command
	{
		private CommandBroker broker;
		public HelpCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "help";
		public string Args() => "";
		public string Info() => "displays this message";

		public void Run(string[] args)
		{
			Console.WriteLine();
			Console.WriteLine("GTN Module Editor Help");
			Console.WriteLine("Key: <> = required arg; [] = optional arg");
			Console.WriteLine();

			foreach (var command in broker.GetCommands())
			{
				Console.WriteLine(command.Name() + " " + command.Args());
				Console.WriteLine(command.Info());
				Console.WriteLine();
			}
		}
	}
}
