using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private string _currentPath;

    public LocalFileSystem()
    {
        _currentPath = string.Empty;
        IsConnected = false;
    }

    public LocalFileSystem(string path)
    {
        if (!Directory.Exists(path))
            throw new ArgumentException("Specified directory does not exist");
        _currentPath = path;
        IsConnected = true;
    }

    public bool IsConnected { get; set; }
    public void Disconnect()
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        _currentPath = string.Empty;
        Console.WriteLine("Disconnected");
    }

    public void TreeGoTo(string address)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (address is null)
            throw new ArgumentException("Specified address is null");
        if (address[0] != '/' && !Directory.Exists(_currentPath + "/" + address))
            throw new ArgumentException("Given path either does not exist in FS or you can not follow this relative path from current directory");
        Console.WriteLine($"Changed directory from {_currentPath} to {_currentPath + "/" + address}");
        _currentPath = _currentPath + "/" + address;
    }

    public void TreeList(string depth)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (depth is null)
            throw new ArgumentException("Passed null instead of string");
        if (int.TryParse(depth, out int numValue))
        {
            var tree = new List<string>();
            var currentDirectory = new DirectoryInfo(_currentPath);
            if (numValue < 1)
                numValue = 1;

            TreeListHelper(tree, numValue, 0, currentDirectory);

            foreach (string line in tree)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            throw new ArgumentException("Depth is in incorrect format");
        }
    }

    public void FileShow(string mode, string path)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (mode == "console")
        {
            if (!File.Exists(path))
                throw new ArgumentException("File does not exist");
            IEnumerable<string> contentOfFile = File.ReadLines(path);
            foreach (string line in contentOfFile)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(" ");
        }
        else
        {
            throw new ArgumentException($"Mode {mode} is not supported");
        }
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (sourcePath is null || destinationPath is null)
            throw new ArgumentException("One of specified addresses is null");
        if (!PathIsReachable(sourcePath))
            throw new ArgumentException("Source path is unreachable");
        if (!PathIsReachable(destinationPath))
            throw new ArgumentException("Destination path is unreachable");
        if (!File.Exists(sourcePath))
            throw new ArgumentException("File does not exist");
        if (File.Exists(destinationPath))
            File.Delete(destinationPath);

        string[] componentsOfCurrentPath = sourcePath.Split("/");
        string[] componentsOfSecondPath = destinationPath.Split("/");
        if (componentsOfCurrentPath[componentsOfCurrentPath.Length - 1] !=
            componentsOfSecondPath[componentsOfSecondPath.Length - 1])
            throw new ArgumentException("Name of file must be the same for both paths");

        File.Move(sourcePath, destinationPath);
        Console.WriteLine($"Moved file from {sourcePath} to {destinationPath}");
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (sourcePath is null || destinationPath is null)
            throw new ArgumentException("One of specified addresses is null");
        if (!PathIsReachable(sourcePath))
            throw new ArgumentException("Source path is unreachable");
        if (!PathIsReachable(destinationPath))
            throw new ArgumentException("Destination path is unreachable");
        if (!File.Exists(sourcePath))
            throw new ArgumentException("File does not exist");
        File.Copy(sourcePath, destinationPath);
        Console.WriteLine($"Copied file from {sourcePath} to {destinationPath}");
    }

    public void FileDelete(string pathOfFileToDelete)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (pathOfFileToDelete is null)
            throw new ArgumentException("One of specified addresses is null");
        if (!PathIsReachable(pathOfFileToDelete))
            throw new ArgumentException("File is unreachable");
        if (!File.Exists(pathOfFileToDelete))
            throw new ArgumentException("File does not exist");
        File.Delete(pathOfFileToDelete);
        Console.WriteLine($"Deleted {pathOfFileToDelete}");
    }

    public void FileRename(string pathOfFileToRename, string newFileName)
    {
        if (_currentPath.Length == 0)
            throw new ArgumentException("You are not connected to file system");
        if (pathOfFileToRename is null || newFileName is null)
            throw new ArgumentException("One of specified addresses is null");
        if (!PathIsReachable(pathOfFileToRename))
            throw new ArgumentException("File is unreachable");
        if (!File.Exists(pathOfFileToRename))
            throw new ArgumentException("File does not exist");
        if (File.Exists(newFileName))
            throw new ArgumentException("File with this name already exists in this directory");

        string[] componentsOfCurrentPath = pathOfFileToRename.Split("/");
        string[] componentsOfSecondPath = newFileName.Split("/");

        for (int i = 0; i < componentsOfCurrentPath.Length - 1; i++)
        {
            if (componentsOfCurrentPath[i] != componentsOfSecondPath[i])
                throw new ArgumentException("First and second paths represent different directories");
        }

        File.Move(pathOfFileToRename, newFileName);
        Console.WriteLine("Renamed a file");
    }

    private bool PathIsReachable(string address)
    {
        return address[0] == '/' || !Directory.Exists(_currentPath + "/" + address);
    }

    private void TreeListHelper(List<string> tree, int depth, int levelOfDirInHierarchy, DirectoryInfo curDir)
    {
        if (depth == 0)
            return;

        string[] componentsOfPath = curDir.Name.Split("/");
        tree.Add(new string(' ', levelOfDirInHierarchy * 4) + "/" + componentsOfPath[componentsOfPath.Length - 1]);

        foreach (FileInfo file in curDir.GetFiles())
        {
            tree.Add(new string(' ', (levelOfDirInHierarchy + 1) * 4) + file.Name);
        }

        foreach (DirectoryInfo directory in curDir.GetDirectories())
        {
            TreeListHelper(tree, depth - 1, levelOfDirInHierarchy + 1, directory);
        }
    }
}