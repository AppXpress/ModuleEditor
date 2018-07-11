using System;

namespace CLI
{
	class FieldCommand : Command
	{
		private CommandBroker broker;
		public FieldCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "field";
		public string Args() => "<'name'|'desc'|'remove'> [value]";
		public string Info() => "get/set field properties or use 'remove' to delete field";

		public void Run(string[] args)
		{
			if (broker.Field == null)
			{
				throw new Exception("You must select a field first.");
			}

			if (args.Length != 2 && args.Length != 3)
			{
				throw new Exception("Incorrect number of arguments.");
			}

			switch (args[1])
			{
				case "name":
					if (args.Length == 3)
					{
						broker.Field.Name = args[2];
					}
					else
					{
						Console.WriteLine(broker.Field.Name);
					}
					break;

				case "desc":
					if (args.Length == 3)
					{
						broker.Field.Description = args[2];
					}
					else
					{
						Console.WriteLine(broker.Field.Description);
					}
					break;

				case "remove":
					broker.Field.Remove();
					broker.Field = null;
					break;
			}
		}
	}
}
