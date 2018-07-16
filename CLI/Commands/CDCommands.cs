using AppX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI
{
	// Command for changing working path
	class CDCommand : BrokerCommand
	{
		public CDCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "cd";
		public override string Args() => "<path>";
		public override string Info() => "changes the current editing path";

		public override void Run(string[] args)
		{
			if (broker.GetState("module") == null)
			{
				throw new Exception("You must import a module first.");
			}

			var parts = args[1].Split('/');
			foreach (var part in parts)
			{
				ChangeDir(part);
			}
		}

		// Updates the current directory in the broker from the given path piece
		// path can be '..' to go up; a design or field to name to select; '.' is ignored
		private void ChangeDir(string part)
		{
			Module module = broker.GetState("module");
			Design design = broker.GetState("design");
			Field field = broker.GetState("field");

			if (part == "..")
			{
				if (field != null)
				{
					broker.SetState("field", null);
				}
				else if (design != null)
				{
					broker.SetState("design", null);
				}
			}
			else if (part != "." && part.Length > 0)
			{
				if (design == null)
				{
					broker.SetState("design", module.Design(part));
				}
				else if (field == null)
				{
					broker.SetState("field", design.Field(part));
				}
			}
		}
	}
}
