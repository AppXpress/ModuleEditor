using AppX;
using System;

namespace CLI
{
	class ImportCommand : Command
	{
		private CommandBroker broker;
		public ImportCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "import";
		public string Args() => "<path>";
		public string Info() => "imports module ZIP file where path is the ZIP to load from";

		public void Run(string[] args)
		{
			if (args.Length == 2)
			{
				broker.SetState("archive", Archive.Import(args[1]));
			}
			else
			{
				throw new Exception("Incorrect number of arguments.");
			}
		}
	}

	class ExportCommand : Command
	{
		private CommandBroker broker;
		public ExportCommand(CommandBroker broker)
		{
			this.broker = broker;
		}

		public string Name() => "export";
		public string Args() => "<path>";
		public string Info() => "exports module ZIP file where path is the ZIP to store to";

		public void Run(string[] args)
		{
			if (broker.GetState("archive") == null)
			{
				throw new Exception("A module must be imported first.");
			}

			if (args.Length != 2)
			{
				throw new Exception("Incorrect number of arguments");
			}

			broker.GetState("archive").Export(args[1]);
		}
	}
}
