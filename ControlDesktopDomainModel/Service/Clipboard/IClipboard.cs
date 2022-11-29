using System.Collections;
using System.Collections.Generic;
using ControlDesktopDomainModel.Service.FileSystem;

namespace ControlDesktopDomainModel.Service.Clipboard
{
    public interface IClipboard
    {
        List<IFileSystemElement> Storage { get; set; }
        //IFileSystem FileSystem { get; set; }
        void Paste();
        void Move();
        void Clear();
    }
}