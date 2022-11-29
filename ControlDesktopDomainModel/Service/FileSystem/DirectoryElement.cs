using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ControlDesktopDomainModel.Service.Clipboard;

namespace ControlDesktopDomainModel.Service.FileSystem
{
    public class DirectoryElement : IFileSystemElement
    {
        public string Name { get; set; }
        public string ShortName
        {
            get => Path.GetFileName(this.Name);
        }
        public void Delete()
        {
            Directory.Delete(this.Name, true);
        }

        public void Copy(IClipboard clipboard)
        {
            clipboard.Storage.Add(this);
        }

        public void Paste()
        {
            DirectoryCopy(
                this.Name,
                Path.Combine(_fileSystem.CurrentDirectory, this.ShortName),
                true);
        }

        public void Move()
        {
            MoveDirectory(
                this.Name,
                Path.Combine(_fileSystem.CurrentDirectory, this.ShortName));
        }

        public void Rename(string newName)
        {
            Directory.Move(
                this.Name,
                Path.Combine(_fileSystem.CurrentDirectory, newName));
        }

        public bool Exist()
        {
            return Directory.Exists(this.Name);
        }

        private readonly IFileSystem _fileSystem;

        private DirectoryElement()
        { }

        public DirectoryElement(IFileSystem fileSystem, string name)
        {
            this._fileSystem = fileSystem;
            this.Name = name;
        }

        internal static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (Directory.Exists(destDirName))
            {
                if (Regex.IsMatch(destDirName, @"^.+\sКопия\s\d$"))
                {
                    var prefix = Regex.Match(destDirName, @"^.+\sКопия\s").Value;
                    var number = Regex.Replace(destDirName, @"^.+\sКопия\s", "");
                    var i = int.Parse(number) + 1;
                    destDirName = prefix + i.ToString(new string('0', number.Length));
                }
                else
                {
                    destDirName = destDirName + " Копия 1";
                }
                DirectoryCopy(sourceDirName, destDirName, copySubDirs);
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destDirName);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public static void MoveDirectory(string source, string target)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    string targetFile = Path.Combine(folders.Target, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }

                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
            Directory.Delete(source, true);
        }

        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }

    }
}