using GodotPCKExplorer;

using System;

Console.WriteLine("Loading Webfishing pck");

PCKReader webfishReader = new PCKReader();

webfishReader.OpenFile("webfishing.pck");

Directory.CreateDirectory("temp2");

webfishReader.ExtractAllFiles("temp2");

Console.WriteLine("Loading target pck, to_merge.pck");

PCKReader pckReader = new PCKReader();

pckReader.OpenFile("to_merge.pck");

// extract it to folder

Directory.CreateDirectory("temp");

pckReader.ExtractAllFiles("temp");

// merge the two folders

Console.WriteLine("Merging target pck");

void CopyFilesRecursively(string sourcePath, string targetPath)
{
    //Now Create all of the directories
    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
    {
        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
    }

    //Copy all the files & Replaces any files with the same name
    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",SearchOption.AllDirectories))
    {
        string end = newPath.Replace(sourcePath, targetPath);
        Console.WriteLine(newPath + " to " + end);
        File.Copy(newPath, end, true);
    }
}

CopyFilesRecursively("temp", "temp2");

// create new pck from temp2

// 1 = godot-3.x, 3.5.2 is our godot version
var ver = new PCKVersion(1, 3,5,2);

var p = PCKActions.Pack("temp2","output.pck",ver.ToString());

Console.WriteLine("Moving files...");

// backup old webfishing.pck

pckReader.Close();
pckReader.Dispose();
webfishReader.Close();
webfishReader.Dispose();

File.Move("webfishing.pck", "webfishing.old");

File.Move("output.pck", "webfishing.pck");

void DeleteDirectory(string target_dir)
{
    string[] files = Directory.GetFiles(target_dir);
    string[] dirs = Directory.GetDirectories(target_dir);

    foreach (string file in files)
    {
        File.SetAttributes(file, FileAttributes.Normal);
        File.Delete(file);
    }

    foreach (string dir in dirs)
    {
        DeleteDirectory(dir);
    }

    Directory.Delete(target_dir, false);
}

DeleteDirectory("temp");
DeleteDirectory("temp2");

Console.WriteLine("Done!");

Console.Read();