using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ControlDesktopDomainModel.Service.ApiProvider;
using ControlDesktopDomainModel.Service.Configuration;
using ControlDesktopDomainModel.Service.FileSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public abstract class FileSystemCommand : Command
    {
        protected virtual void SendFiles(CommandManager commandManager, string state = "ok")
        {
            var (files, dirs) = this.GetFilesAndDirs(commandManager);

            var report = new Dictionary<string, dynamic>
            {
                {"command_state", state},
                {"current_dir", commandManager._fileSystem.CurrentDirectory},
                {"dirs", dirs},
                {"files", files}
            };
            this.Report(report);
        }

        protected virtual (List<string> files, List<string> dirs) GetFilesAndDirs(CommandManager commandManager)
        {
            var directoryContent = commandManager._fileSystem.DirectoryContent;

            var files = new List<string>();
            var dirs = new List<string>();

            foreach (var fileSystemElement in directoryContent)
            {
                switch (fileSystemElement)
                {
                    case FileElement:
                        files.Add(fileSystemElement.ShortName);
                        break;
                    case DirectoryElement:
                        dirs.Add(fileSystemElement.ShortName);
                        break;
                }
            }

            return (files, dirs);
        }

    }
}