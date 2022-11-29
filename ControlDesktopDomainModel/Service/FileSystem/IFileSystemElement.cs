using ControlDesktopDomainModel.Service.Clipboard;

namespace ControlDesktopDomainModel.Service.FileSystem
{
    public interface IFileSystemElement
    {
        string Name { get; set; }
        string ShortName { get; }
        void Delete();
        void Copy(IClipboard clipboard);
        void Paste();
        void Move();
        void Rename(string newName);
        bool Exist();
    }
}