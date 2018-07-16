using AppX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI
{
	// Controller for running commands and storing state between commands
	class CommandBroker
	{
		public CommandBroker()
		{
			commands = new List<Command>();
			state = new Dictionary<string, dynamic>();
		}

		// Stores all possible commands for this broker
		private List<Command> commands { get; }
		// Stores the state of the command runtime
		private Dictionary<string, dynamic> state { get; }

		// Registers a new command with the broker
		public void AddCommand(Command command)
		{
			commands.Add(command);
		}

		// Gets an array of all active commands
		public Command[] GetCommands()
		{
			return commands.ToArray();
		}

		// Gets an item from the state by key
		public dynamic GetState(string key)
		{
			return state.GetValueOrDefault(key);
		}

		// Sets an item in the state using the key and value
		public void SetState(string key, dynamic value)
		{
			if (state.ContainsKey(key))
			{
				state.Remove(key);
			}
			state.Add(key, value);
		}

		// Runs a command by parsing the arguments, finding the command object, and calling it
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
				// Console.Error.WriteLine(e.StackTrace);
			}
		}

		// Gets the currently selected working path in the broker
		public string SelectedPath
		{
			get
			{
				Module module = GetState("module");
				Design design = GetState("design");
				Field field = GetState("field");

				var path = "";
				if (module != null)
				{
					path += '/' + module.Name;
					if (design != null)
					{
						path += '/' + design.Type;
						if (field != null)
						{
							path += '/' + field.Name;
						}
					}
				}
				return path;
			}
		}

		// Gets the currently selected item at the working path
		public dynamic SelectedItem
		{
			get
			{
				Module module = GetState("module");
				Design design = GetState("design");
				Field field = GetState("field");

				if (module == null)
				{
					throw new Exception("You must import a module first.");
				}

				if (field != null)
				{
					return field;
				}
				else if (design != null)
				{
					return design;
				}
				return module;
			}
		}
	}
}
