using System;

namespace CLI
{
	class ModuleCommand : Command
	{
		private CommandBroker broker;

		public ModuleCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "module";
		public string Args() => "<'name'|'desc'> [value]";
		public string Info() => "get/set module properties -- omit 'value' to print current value";

		public void Run(string[] args)
		{
			if (broker.Module == null)
			{
				throw new Exception("You must import a module first.");
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
						broker.Module.Name = args[2];
					}
					else
					{
						Console.WriteLine(broker.Module.Name);
					}
					break;

				case "desc":
					if (args.Length == 3)
					{
						broker.Module.Description = args[2];
					}
					else
					{
						Console.WriteLine(broker.Module.Description);
					}
					break;
			}
		}
	}
}
