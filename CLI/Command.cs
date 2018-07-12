using AppX;
using System;
using System.Collections.Generic;

namespace CLI
{
	// Command class representing a possible command
	abstract class Command
	{
		// The command name - what the user enters to run it
		public abstract string Name();
		// A string describing the arguments where <> is required, [] is option
		public abstract string Args();
		// A string describing what the command is for and how it works
		public abstract string Info();

		// Function to call when the user enters the command name
		public abstract void Run(string[] args);
	}

	// Command class for commands that interact with broker
	abstract class BrokerCommand : Command
	{
		protected CommandBroker broker;
		public BrokerCommand(CommandBroker broker)
		{
			this.broker = broker;
		}
	}

	// Prints a help message to the user using the commands in the broker
	class HelpCommand : BrokerCommand
	{
		public HelpCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "help";
		public override string Args() => "";
		public override string Info() => "displays this message";

		public override void Run(string[] args)
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
