using AppX;
using System;

namespace CLI
{
	// Removes the current design or field at the working path
	class RMCommand : BrokerCommand
	{
		public RMCommand(CommandBroker broker) : base(broker) { }

		public override string Name() => "rm";
		public override string Args() => "";
		public override string Info() => "removes the design or field in the working path";

		public override void Run(string[] args)
		{
			var selection = broker.SelectedItem;

			var type = selection.GetType();

			if (type == typeof(Module))
			{
				throw new Exception("Cannot remove module.");
			}

			if (type == typeof(Design))
			{
				broker.SetState("design", null);
				broker.SetState("field", null);
				selection.Remove();
			}

			if (type == typeof(Field))
			{
				broker.SetState("field", null);
				selection.Remove();
			}
		}
	}
}
