using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using ControlDesktopDomainModel.Service.ApiProvider;
using ControlDesktopDomainModel.Service.Clipboard;
using ControlDesktopDomainModel.Service.Configuration;

namespace ControlDesktopDomainModel.Service.FileSystem
{
    public class FileSystem : IFileSystem
    {
        private readonly IClipboard _clipboard;
        public string CurrentDirectory { get; private set; }
        public string CurrentDrive { get; }
        public bool ChangeDirectoryToParent()
        {
            if (CurrentDirectory != CurrentDrive)
            {
                CurrentDirectory = Directory.GetParent(CurrentDirectory).ToString();
                this.Refresh();
                return true;
            }

            return false;
        }

        public void ChangeDirectoryToChild(int index)
        {
            CurrentDirectory = DirectoryContent[index-1].Name;
            this.Refresh();
        }

        public List<IFileSystemElement> DirectoryContent { get; } = new List<IFileSystemElement>();
        public void CreateFile(string name)
        {
            File.Create(@$"{CurrentDirectory}\{name}").Dispose();
            this.Refresh();
        }

        public void CreateDir(string name)
        {
            Directory.CreateDirectory(@$"{CurrentDirectory}\{name}");
            this.Refresh();
        }

        public void Refresh()
        {
            this.DirectoryContent.Clear();
            foreach (var directory in Directory.GetDirectories(CurrentDirectory))
            {
                DirectoryContent.Add(new DirectoryElement(this, directory));
            }

            foreach (var file in Directory.GetFiles(CurrentDirectory))
            {
                DirectoryContent.Add(new FileElement(this, file));
            }
        }

        public void Delete(int index)
        {
            this.DirectoryContent[index-1].Delete();
            this.Refresh();
        }

        public void Delete(List<int> fileList)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                DirectoryContent[fileList[i]-1].Delete();
            }
        }

        public void Copy(int index)
        {
            this._clipboard.Clear();
            this.DirectoryContent[index-1].Copy(this._clipboard);
        }

        public void Copy(List<int> fileList)
        {
            this._clipboard.Clear();
            for (int i = 0; i < fileList.Count; i++)
            {
                DirectoryContent[fileList[i] - 1].Copy(this._clipboard);
            }
        }

        public void Paste()
        {
            _clipboard.Paste();
            this._clipboard.Clear();
            this.Refresh();
        }

        public void Move()
        {
            _clipboard.Move();
            this.Refresh();
        }

        public void Rename(int index, string newName)
        {
            this.DirectoryContent[index-1].Rename(newName);
            this.Refresh();
        }

        public FileSystem(IClipboard clipboard, string currentDrive)
        {
            this._clipboard = clipboard;
            this.CurrentDrive = currentDrive;
            this.CurrentDirectory = currentDrive;

            this.Refresh();
        }

        public void Zip(int index, string zipName)
        {
            string tempDirectory = Path.Combine(this.CurrentDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            var element = this.DirectoryContent[index - 1];

            if (element is DirectoryElement)
            {
                DirectoryElement.DirectoryCopy(element.Name, Path.Combine(tempDirectory, element.ShortName), true);
            }
            else if (element is FileElement)
            {
                File.Copy(element.Name, Path.Combine(tempDirectory, element.ShortName));
            }

            string startPath = tempDirectory;
            string zipPath = Path.Combine(this.CurrentDirectory, zipName+".zip");

            ZipFile.CreateFromDirectory(startPath, zipPath);

            Directory.Delete(tempDirectory,true);
            this.Refresh();
        }

        public string SendFile(int index)
        {
            string fileName = Path.GetRandomFileName();
            this.Zip(index, fileName);

            var zipElement = this.DirectoryContent.Find(element => element.ShortName == fileName + ".zip");
            var indexForDelete = this.DirectoryContent.IndexOf(zipElement);
            
            var st = ApiMediator.SendFile(ConfigurationManager.AppLogin, ConfigurationManager.AppPassword, zipElement.Name).Result;

            this.Delete(indexForDelete+1);

            return fileName + ".zip";
        }

        public bool Exist(int index)
        {
            return this.DirectoryContent[index - 1].Exist();
        }

        public bool Exist(string name)
        {
            var element = this.DirectoryContent.Find(element => element.Name == name);
            if (element != null)
            {
                return element.Exist();
            }

            return false;
        }

        public bool ExistInFolder(string name)
        {
            var path = Path.Combine(CurrentDirectory, name);
            return (File.Exists(path) || Directory.Exists(path));
        }
    }
}