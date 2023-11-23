namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public void Disconnect();

    public void TreeGoTo(string address);

    public void TreeList(string depth);

    public void FileShow();

    public void FileMove();

    public void FileCopy();

    public void FileDelete();

    public void FileRename();
}