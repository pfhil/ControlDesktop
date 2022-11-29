using System;
using System.Collections.Generic;
using ControlDesktopDomainModel.Service.FileSystem;

namespace ControlDesktopDomainModel.Service.Clipboard
{
    public class Clipboard : IClipboard
    {
        public List<IFileSystemElement> Storage { get; set; } = new ();
        //public IFileSystem FileSystem { get; set; }
        public void Paste()
        {
            foreach (var fileSystemElement in Storage)
            {
                fileSystemElement.Paste();
            }
        }

        public void Move()
        {
            foreach (var fileSystemElement in Storage)
            {
                fileSystemElement.Move();
            }
        }

        public void Clear()
        {
            this.Storage.Clear();
        }

    }
}