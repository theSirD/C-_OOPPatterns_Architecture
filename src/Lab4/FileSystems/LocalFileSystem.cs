namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private string _currentPath = string.Empty;
    public LocalFileSystem(string path)
    {
        _currentPath = path;
    }

    public void Connect()
    {
        throw new System.NotImplementedException();
    }

    public void Disconnect()
    {
        throw new System.NotImplementedException();
    }

    public void TreeGoTo()
    {
        throw new System.NotImplementedException();
    }

    public void TreeList()
    {
        throw new System.NotImplementedException();
    }

    public void FileShow()
    {
        throw new System.NotImplementedException();
    }

    public void FileMove()
    {
        throw new System.NotImplementedException();
    }

    public void FileCopy()
    {
        throw new System.NotImplementedException();
    }

    public void FileDelete()
    {
        throw new System.NotImplementedException();
    }

    public void FileRename()
    {
        throw new System.NotImplementedException();
    }
}