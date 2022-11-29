using System.IO;
using System.Text.RegularExpressions;
using ControlDesktopDomainModel.Service.Clipboard;

namespace ControlDesktopDomainModel.Service.FileSystem
{
    public class FileElement : IFileSystemElement
    {
        public string Name { get; set; }
        public string ShortName
        {
            get => Path.GetFileName(this.Name);
        }
        public void Delete()
        {
            File.Delete(this.Name);
        }

        public void Copy(IClipboard clipboard)
        {
            clipboard.Storage.Add(this);
        }

        public void Paste()
        {
            FileCopy(
                this.Name,
                Path.Combine(_fileSystem.CurrentDirectory, this.ShortName));
        }

        public void Move()
        {
            File.Move(
                this.Name,
                Path.Combine(_fileSystem.CurrentDirectory, this.ShortName), true);
        }

        public void Rename(string newName)
        {
            File.Move(
                this.Name,
                Path.Combine(_fileSystem.CurrentDirectory, newName));
        }

        public bool Exist()
        {
            return File.Exists(this.Name);
        }

        private readonly IFileSystem _fileSystem;


        private FileElement()
        { }

        public FileElement(IFileSystem fileSystem, string name)
        {
            this._fileSystem = fileSystem;
            this.Name = name;
        }

        internal static void FileCopy(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
            {
                if (Regex.IsMatch(destFileName, @"^.+\sКопия\s\d$"))
                {
                    var prefix = Regex.Match(destFileName, @"^.+\sКопия\s").Value;
                    var number = Regex.Replace(destFileName, @"^.+\sКопия\s", "");
                    var i = int.Parse(number) + 1;
                    destFileName = prefix + i.ToString(new string('0', number.Length));
                }
                else
                {
                    destFileName = destFileName + " Копия 1";
                }
                FileCopy(sourceFileName, destFileName);
                return;
            }
            File.Copy(sourceFileName, destFileName);
        }
    }
}