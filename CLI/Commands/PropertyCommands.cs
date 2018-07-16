using AppX;
using System;

namespace CLI
{
	// Lists properties of the working path
	class ListCommand : BrokerCommand
	{
		public ListCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "listp";
		public override string Args() => "";
		public override string Info() => "lists all properties of the working path";

		public override void Run(string[] args)
		{
			var selection = broker.SelectedItem;
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

	// Gets a property value of the working path
	class GetCommand : BrokerCommand
	{
		public GetCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "getp";
		public override string Args() => "<key>";
		public override string Info() => "gets a property of the working path";

		public override void Run(string[] args)
		{
			var selection = broker.SelectedItem;
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
				throw new Exception("Cannot read from this property.");
			}

			var value = property.GetValue(selection);
			if (value == null)
			{
				throw new Exception("Property not found.");
			}

			Console.WriteLine(value.ToString());
		}
	}

	// Sets a property value of the working path
	class SetCommand : BrokerCommand
	{
		public SetCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "setp";
		public override string Args() => "<key> <value>";
		public override string Info() => "sets a property of the working path";

		public override void Run(string[] args)
		{
			var selection = broker.SelectedItem;
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
				throw new Exception("Cannot write to this property.");
			}

			property.SetValue(selection, args[2]);
		}
	}
}
