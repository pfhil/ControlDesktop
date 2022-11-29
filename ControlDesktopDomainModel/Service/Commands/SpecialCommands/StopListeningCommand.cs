using System.Collections.Generic;

namespace ControlDesktopDomainModel.Service.Commands.SpecialCommands
{
    public class StopListeningCommand : Command
    {
        private CommandManager _commandManager;
        public StopListeningCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "StopListening";
        public override void Execute(dynamic instruction)
        {
            var report = new Dictionary<string, dynamic>
            {
                {"command_state", "ok_stop_listening"}
            };
            this.Report(report);
            this._commandManager._mainService.InvokeStopListeningEvent();
        }
    }
}