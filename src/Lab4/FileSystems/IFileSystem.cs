namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public void Connect();

    public void Disconnect();

    public void TreeGoTo();

    public void TreeList();

    public void FileShow();

    public void FileMove();

    public void FileCopy();

    public void FileDelete();

    public void FileRename();
}