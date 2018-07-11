using System;

namespace CLI
{
	class DesignCommand : Command
	{
		private CommandBroker broker;
		public DesignCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "design";
		public string Args() => "<'name'|'desc'|'remove'> [value]";
		public string Info() => "get/set design properties or use 'remove' to delete design";

		public void Run(string[] args)
		{
			if (broker.Design == null)
			{
				throw new Exception("You must select a design first.");
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
						broker.Design.Name = args[2];
					}
					else
					{
						Console.WriteLine(broker.Design.Name);
					}
					break;

				case "desc":
					if (args.Length == 3)
					{
						broker.Design.Description = args[2];
					}
					else
					{
						Console.WriteLine(broker.Design.Description);
					}
					break;

				case "remove":
					broker.Design.Remove();
					broker.Design = null;
					break;
			}
		}
	}
}
