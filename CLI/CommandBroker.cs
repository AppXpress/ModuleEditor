using AppX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI
{
	class CommandBroker
	{
		public Archive Archive { get; set; }
		public Module Module { get; set; }
		public Design Design { get; set; }
		public Field Field { get; set; }

		public CommandBroker()
		{
			commands = new List<Command>();
			state = new Dictionary<string, dynamic>();
		}

		private List<Command> commands { get; }
		private Dictionary<string, dynamic> state { get; }

		public void AddCommand(Command command)
		{
			commands.Add(command);
		}

		public Command[] GetCommands()
		{
			return commands.ToArray();
		}

		public dynamic GetState(string key)
		{
			return state.GetValueOrDefault(key);
		}

		public void SetState(string key, dynamic value)
		{
			if (state.ContainsKey(key))
			{
				state.Remove(key);
			}
			state.Add(key, value);
		}

		public void Run(string input)
		{
			var args = ArgArray.Parse(input);

			try
			{
				var command = commands.Find(x => x.Name() == args[0]);
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
