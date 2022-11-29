using System;
using System.Collections.Generic;
using System.Text;

namespace ControlDesktopDomainModel.Service.FileSystem
{
    public interface IFileSystem
    {
        string CurrentDirectory { get; }
        public string CurrentDrive { get; }
        bool ChangeDirectoryToParent();
        void ChangeDirectoryToChild(int index);
        List<IFileSystemElement> DirectoryContent { get; }
        void CreateFile(string name);
        void CreateDir(string name);
        void Refresh();
        //event Action Refresh;
        void Delete(int index);
        void Delete(List<int> fileList);
        void Copy(int index);
        void Copy(List<int> fileList);
        void Paste();
        void Move();
        void Rename(int index, string newName);
        void Zip(int index, string zipName);
        string SendFile(int index);
        bool Exist(int index);
        bool Exist(string name);
        bool ExistInFolder(string name);

    }
}
