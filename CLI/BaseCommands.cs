using System;

namespace CLI
{
	class NullCommand : Command
	{
		public string Name() => null;
		public string Args() => null;
		public string Info() => "";

		public void Run(string[] args)
		{
			throw new Exception("Command not found.");
		}
	}

	class ExitCommand : Command
	{
		public string Name() => "exit";
		public string Args() => "";
		public string Info() => "closes the program";

		public void Run(string[] args)
		{
			Environment.Exit(0);
		}
	}

	class EchoCommand : Command
	{
		public string Name() => "echo";
		public string Args() => "[string [...]]";
		public string Info() => "lists the given arguments out";

		public void Run(string[] args)
		{
			for (var i = 1; i < args.Length; i++)
			{
				Console.WriteLine(" . " + args[i]);
			}
		}
	}

	class ClearCommand : Command
	{
		public string Name() => "clear";
		public string Args() => "";
		public string Info() => "clears the console screen";

		public void Run(string[] args)
		{
			Console.Clear();
		}
	}
}
