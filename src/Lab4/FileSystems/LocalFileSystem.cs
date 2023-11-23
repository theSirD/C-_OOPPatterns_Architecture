namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private string _currentPath = string.Empty;
    public LocalFileSystem(string path)
    {
        _currentPath = path;
    }

    public void Disconnect()
    {
        _currentPath = string.Empty;
    }

    public void TreeGoTo(string address)
    {
        throw new System.NotImplementedException();
    }

    public void TreeList(string depth)
    {
        throw new System.NotImplementedException();
    }

    public void FileShow(string mode, string path)
    {
        if (mode == "console")
        {
            throw new System.NotImplementedException();
        }

        throw new System.NotImplementedException();
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        throw new System.NotImplementedException();
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        throw new System.NotImplementedException();
    }

    public void FileDelete(string pathOfFileToDelete)
    {
        throw new System.NotImplementedException();
    }

    public void FileRename(string pathOfFileToRename, string newFileName)
    {
        throw new System.NotImplementedException();
    }
}