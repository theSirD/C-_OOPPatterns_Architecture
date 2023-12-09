namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public bool IsConnected { get; protected set; }
    public void Connect(Context context);
    public void Disconnect();

    public void TreeGoTo(Context context);

    public void TreeList(Context context);

    public void FileShow(Context context);

    public void FileMove(Context context);

    public void FileCopy(Context context);

    public void FileDelete(Context context);

    public void FileRename(Context context);
}