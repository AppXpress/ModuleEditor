using System;

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
		public string Args() => "<'design'|'field'> <type>";
		public string Info() => "selects a design or field for editing - 'type' is the type of the design/field";

		public void Run(string[] args)
		{
			if (broker.Archive == null)
			{
				throw new Exception("You must import a module first.");
			}

			if (args.Length != 3)
			{
				throw new Exception("Incorrect number of arguments.");
			}

			switch (args[1])
			{
				case "design":
					broker.Design = broker.Archive.Design(args[2]);
					if (broker.Design == null)
					{
						throw new Exception("Design not found.");
					}
					break;

				case "field":
					if (broker.Design == null)
					{
						throw new Exception("You must select a design first.");
					}

					broker.Field = broker.Design.Field(args[2]);
					if (broker.Field == null)
					{
						throw new Exception("Field not found.");
					}
					break;

				default:
					throw new Exception("Selection target type not recognized.");
			}
		}
	}
}
