using AppX;
using System;

namespace CLI
{
	// Lists available designs or fields in the current module or design respectively
	class LSCommand : BrokerCommand
	{
		public LSCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "ls";
		public override string Args() => "";
		public override string Info() => "lists designs or fields in working path";

		public override void Run(string[] args)
		{
			Module module = broker.GetState("module");
			Design design = broker.GetState("design");
			Field field = broker.GetState("field");

			if (module == null)
			{
				throw new Exception("You must import a module first.");
			}
			else
			{
				string[] list;
				if (design == null)
				{
					list = module.List();
				}
				else
				{
					if (field == null)
					{
						list = design.List();
					}
					else
					{
						throw new Exception("Cannot navigate deeper than a field. Use 'cd ..' to go up to design.");
					}
				}

				Console.WriteLine();
				foreach (var item in list)
				{
					Console.WriteLine(item);
				}
				Console.WriteLine();
			}
		}
	}
}
