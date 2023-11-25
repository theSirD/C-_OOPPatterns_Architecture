namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public bool IsConnected { get; protected set; }
    public void Disconnect();

    public void TreeGoTo(string address);

    public void TreeList(string depth);

    public void FileShow(string mode, string path);

    public void FileMove(string sourcePath, string destinationPath);

    public void FileCopy(string sourcePath, string destinationPath);

    public void FileDelete(string pathOfFileToDelete);

    public void FileRename(string pathOfFileToRename, string newFileName);
}