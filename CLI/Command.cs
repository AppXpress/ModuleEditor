using AppX;
using System;
using System.Collections.Generic;

namespace CLI
{
	// Command interface representing a possible command
	interface Command
	{
		// The command name - what the user enters to run it
		string Name();
		// A string describing the arguments where <> is required, [] is option
		string Args();
		// A string describing what the command is for and how it works
		string Info();

		// Function to call when the user enters the command name
		void Run(string[] args);
	}

	// Prints a help message to the user using the commands in the broker
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
