using AppX;
using System;
using System.Collections.Generic;

namespace CLI
{
	class SelectCommand : Command
	{
		private CommandBroker broker;
		public SelectCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "select";
		public string Args() => "[ <'module'> | <'design' <type>> | <'field' <design-type> <field-name>> ]";
		public string Info() => "selects an item for edit/removal - omit all args to view current selection";

		public void Run(string[] args)
		{
			if (args.Length > 1)
			{
				Archive archive = broker.GetState("archive");
				if (archive == null)
				{
					throw new Exception("You must import a ZIP first.");
				}

				switch (args[1])
				{
					case "module":
						broker.SetState("selection", archive.Module());
						break;

					case "design":
						if (args.Length < 3)
						{
							throw new Exception("Incorrect number of arguments.");
						}

						broker.SetState("selection", archive.Design(args[2]));
						break;

					case "field":
						if (args.Length < 4)
						{
							throw new Exception("Incorrect number of arguments.");
						}

						broker.SetState("selection", archive.Design(args[2]).Field(args[3]));
						break;

					default:
						throw new Exception("Selection target type not recognized.");
				}
			}

			var selection = broker.GetState("selection");
			if (selection == null)
			{
				Console.WriteLine("Nothing is selected.");
			}
			else
			{
				string message;
				var type = selection.GetType();
				if (type == typeof(Module))
				{
					message = "Module '" + selection.Name + "'";
				}
				else if (type == typeof(Design))
				{
					message = "Design '" + selection.Type + "'";
				}
				else if (type == typeof(Field))
				{
					message = "Field '" + selection.Name + "'";
				}
				else
				{
					throw new Exception("Unrecognized selection type.");
				}

				Console.WriteLine(message + " is selected.");
			}
		}
	}
}
