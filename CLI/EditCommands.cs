using AppX;
using System;

namespace CLI
{
	// Removes the selected item from the archive
	class RemoveCommand : BrokerCommand
	{
		public RemoveCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "remove";
		public override string Args() => "";
		public override string Info() => "removes the current selection";

		public override void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection != null)
			{
				var type = selection.GetType();
				if (type == typeof(Design) || type == typeof(Field))
				{
					selection.Remove();
					broker.SetState("selection", null);

					if (type == typeof(Design))
					{
						Console.WriteLine("Removed design '" + selection.Type + "'");
					}
					else
					{
						Console.WriteLine("Removed field '" + selection.Name + "'");
					}
					return;
				}
			}
			throw new Exception("You must select a design or field first.");
		}
	}

	class ListCommand : BrokerCommand
	{
		public ListCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "list";
		public override string Args() => "";
		public override string Info() => "lists all values in the selected item";

		public override void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection == null)
			{
				throw new Exception("Nothing is selected.");
			}

			var type = selection.GetType();
			var properties = type.GetProperties();
			foreach (var property in properties)
			{
				Console.WriteLine(property.Name);
			}
		}
	}

	class GetCommand : BrokerCommand
	{
		public GetCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "get";
		public override string Args() => "<key>";
		public override string Info() => "gets a value from the selected item";

		public override void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection == null)
			{
				throw new Exception("Nothing is selected.");
			}

			if (args.Length < 2)
			{
				throw new Exception("Not enough arguments.");
			}

			var type = selection.GetType();
			var property = type.GetProperty(args[1]);

			if (property == null)
			{
				throw new Exception("Property not found.");
			}

			if (!property.CanRead)
			{
				throw new Exception("Cannot get this property.");
			}

			var value = property.GetValue(selection);

			if (value == null)
			{
				throw new Exception("Property not found in object.");
			}

			Console.WriteLine(value.ToString());
		}
	}

	class SetCommand : BrokerCommand
	{
		public SetCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "set";
		public override string Args() => "<key> <value>";
		public override string Info() => "sets a value from the selected item";

		public override void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection == null)
			{
				throw new Exception("Nothing is selected.");
			}

			if (args.Length < 3)
			{
				throw new Exception("Not enough arguments.");
			}

			var type = selection.GetType();
			var property = type.GetProperty(args[1]);

			if (property == null)
			{
				throw new Exception("Property not found.");
			}

			if (!property.CanWrite)
			{
				throw new Exception("Cannot set this property.");
			}

			property.SetValue(selection, args[2]);
		}
	}
}
