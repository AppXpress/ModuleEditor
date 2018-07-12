using System;

namespace CLI
{
	// Represents a non-existant command
	class NullCommand : Command
	{
		public override string Name() => null;
		public override string Args() => null;
		public override string Info() => "";

		public override void Run(string[] args)
		{
			throw new Exception("Command not found.");
		}
	}

	// Command for quitting the program
	class ExitCommand : Command
	{
		public override string Name() => "exit";
		public override string Args() => "";
		public override string Info() => "closes the program";

		public override void Run(string[] args)
		{
			Environment.Exit(0);
		}
	}

	// Debug command for printing out given arguments to test ArgArray class
	class EchoCommand : Command
	{
		public override string Name() => "echo";
		public override string Args() => "[string [...]]";
		public override string Info() => "lists the given arguments out";

		public override void Run(string[] args)
		{
			for (var i = 1; i < args.Length; i++)
			{
				Console.WriteLine(" . " + args[i]);
			}
		}
	}

	// Clears the console screen of text
	class ClearCommand : Command
	{
		public override string Name() => "clear";
		public override string Args() => "";
		public override string Info() => "clears the console screen";

		public override void Run(string[] args)
		{
			Console.Clear();
		}
	}
}
