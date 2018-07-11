using AppX;
using System;

namespace CLI
{
	class RemoveCommand : Command
	{
		private CommandBroker broker;
		public RemoveCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "remove";
		public string Args() => "";
		public string Info() => "removes the current selection";

		public void Run(string[] args)
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

	class NameCommand : Command
	{
		private CommandBroker broker;
		public NameCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "name";
		public string Args() => "[set-value]";
		public string Info() => "get/set the name of the selection";

		public void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection != null)
			{
				var type = selection.GetType();
				if (type == typeof(Module) || type == typeof(Design) || type == typeof(Field))
				{
					if (args.Length > 1)
					{
						selection.Name = args[1];
					}
					Console.WriteLine(selection.Name);

					if (type == typeof(Design))
					{
						Console.WriteLine("* Automated type change -- design type is now '" + selection.Type + "'");
					}
					return;
				}
			}
			throw new Exception("You must select a module, design, or field first.");
		}
	}

	class DescCommand : Command
	{
		private CommandBroker broker;
		public DescCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "desc";
		public string Args() => "[set-value]";
		public string Info() => "get/set the description of the selection";

		public void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection != null)
			{
				var type = selection.GetType();
				if (type == typeof(Module) || type == typeof(Design) || type == typeof(Field))
				{
					if (args.Length > 1)
					{
						selection.Description = args[1];
					}
					Console.WriteLine(selection.Description);
					return;
				}
			}
			throw new Exception("You must select a module, design, or field first.");
		}
	}

	class TypeCommand : Command
	{
		private CommandBroker broker;
		public TypeCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "type";
		public string Args() => "";
		public string Info() => "get the type of the selection";

		public void Run(string[] args)
		{
			var selection = broker.GetState("selection");
			if (selection != null)
			{
				var type = selection.GetType();
				if (type == typeof(Design))
				{
					if (args.Length > 1)
					{
						Console.WriteLine("* Type cannot be changed directly -- use 'name' command instead");
					}

					Console.WriteLine(selection.Type);
					return;
				}
			}
			throw new Exception("You must select a design first.");
		}
	}
}
