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

		public string Text() => "import";
		public string Help() => "import <path>\nimports module ZIP file where path is the ZIP to load from";

		public void Run(string[] args)
		{
			if (args.Length == 2)
			{
				broker.Archive = Archive.Import(args[1]);
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

		public string Text() => "export";
		public string Help() => "export <path>\nexports module ZIP file where path is the ZIP to store to";

		public void Run(string[] args)
		{
			if (broker.Archive == null)
			{
				throw new Exception("A module must be imported first.");
			}

			if (args.Length == 2)
			{
				broker.Archive.Export(args[1]);
			}
			else
			{
				throw new Exception("Incorrect number of arguments");
			}
		}
	}
}
