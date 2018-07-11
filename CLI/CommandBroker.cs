using AppX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI
{
	class CommandBroker
	{
		public List<Command> Commands { get; }
		public Archive Archive { get; set; }
		public Module Module { get; set; }
		public Design Design { get; set; }
		public Field Field { get; set; }

		public CommandBroker()
		{
			Commands = new List<Command>();
		}

		public void Run(string input)
		{
			var args = ArgArray.Parse(input);

			try
			{
				var command = Commands.Find(x => x.Name() == args[0]);
				if (command == null) { command = new NullCommand(); }
				command.Run(args);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
				Console.WriteLine("Enter 'help' for assistance.");
			}
		}
	}
}
