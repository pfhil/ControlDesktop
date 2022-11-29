using System.Collections.Generic;
using System.Threading.Tasks;
using ControlDesktopDomainModel.Service.ApiProvider;
using ControlDesktopDomainModel.Service.Configuration;
using Newtonsoft.Json;

namespace ControlDesktopDomainModel.Service.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(dynamic instruction);

        protected virtual void Report(Dictionary<string, dynamic> report)
        {
            var jsonReport = JsonConvert.SerializeObject(report, Formatting.Indented);
            var (json, status) = Task.Run(() =>
                ApiMediator.SendReport(ConfigurationManager.AppLogin, ConfigurationManager.AppPassword, jsonReport)).Result;
        }
    }
}