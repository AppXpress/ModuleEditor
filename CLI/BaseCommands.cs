using System;

namespace CLI
{
	class NullCommand : Command
	{
		public string Text() => null;
		public string Help() => null;

		public void Run(string[] args)
		{
			throw new Exception("Command not found.");
		}
	}

	class ExitCommand : Command
	{
		public string Text() => "exit";
		public string Help() => "exit\ncloses the program";

		public void Run(string[] args)
		{
			Environment.Exit(0);
		}
	}

	class EchoCommand : Command
	{
		public string Text() => "echo";
		public string Help() => "echo [string [...]]\nlists the given arguments out";

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
		public string Text() => "clear";
		public string Help() => "clear\nclears the console screen";

		public void Run(string[] args)
		{
			Console.Clear();
		}
	}
}
