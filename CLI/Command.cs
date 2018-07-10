using AppX;
using System;
using System.Collections.Generic;

namespace CLI
{
	interface Command
	{
		string Text();
		string Help();
		void Run(string[] args);
	}

	class HelpCommand : Command
	{
		private CommandBroker broker;
		public HelpCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Text() => "help";
		public string Help() => "help\ndisplays this message";

		public void Run(string[] args)
		{
			Console.WriteLine(" GTN Module Editor Help");
			Console.WriteLine(" Key: <> = required arg; [] = optional arg");

			foreach (var command in broker.Commands)
			{
				Console.WriteLine(" ├─ " + command.Help().Replace("\n", "\n │  ") + "\n │  ");
			}
		}
	}


}
