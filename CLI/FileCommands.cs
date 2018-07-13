using AppX;
using System;

namespace CLI
{
	// Imports a ZIP module into the broker state
	class ImportCommand : BrokerCommand
	{
		public ImportCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "import";
		public override string Args() => "<path>";
		public override string Info() => "imports module ZIP file where path is the ZIP to load from";

		public override void Run(string[] args)
		{
			if (args.Length == 2)
			{
				broker.SetState("module", Module.Import(args[1]));
			}
			else
			{
				throw new Exception("Incorrect number of arguments.");
			}
		}
	}

	// Exports the module in the broker state into a ZIP file
	class ExportCommand : BrokerCommand
	{
		public ExportCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "export";
		public override string Args() => "<path>";
		public override string Info() => "exports module ZIP file where path is the ZIP to store to";

		public override void Run(string[] args)
		{
			if (broker.GetState("module") == null)
			{
				throw new Exception("A module must be imported first.");
			}

			if (args.Length != 2)
			{
				throw new Exception("Incorrect number of arguments");
			}

			broker.GetState("module").Export(args[1]);
		}
	}
}
