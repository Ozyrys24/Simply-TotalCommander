using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ClassLibrary1
{
    public class FileReader : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Clear list & add a single file to list
        public static void GetOneFile(string path, List<FileInfo> filesList)
        {
            if (File.Exists(path))
            {
                filesList.Clear();
                FileInfo[] fileEntries1 = new DirectoryInfo(path).GetFiles();
                foreach (FileInfo file in fileEntries1)
                    filesList.Add(file);
            }   
        }
        // Process the list of files found in the directory. Add them to list passed by argument
        public static void ProcessCurrentDirectory(string targetDirectory, List<FileInfo> filesList)
        {
            //Method to put filters on search, like name extension path etc.
            // string[] fileEntries = new DirectoryInfo(targetDirectory).GetFiles().Select(o => o.Extension).ToArray();
            if(Directory.Exists(targetDirectory))
            {
                filesList.Clear();
                FileInfo[] fileEntries1 = new DirectoryInfo(targetDirectory).GetFiles();
                foreach (FileInfo file in fileEntries1)
                    file.Name = Path.GetFileNameWithoutExtension(path);
                    filesList.Add(file);
            }
        }
        // Putting into list files from subdirectories
        public static void ProcessSubDirectories(string targetDirectories, List<FileInfo> filesList)
        {

            string[] subdirectoriesEntries = Directory.GetDirectories(targetDirectories);
            foreach (string subdirectories in subdirectoriesEntries)
                ProcessCurrentDirectory(subdirectories, filesList);
        }

        // Clearing then updating list of string with file names
        public static void GetFilesNamesList(string targetDirectory, List<string> filesList) { 
        filesList.Clear();
        if (Directory.Exists(targetDirectory))
        {
            FileInfo[] fileEntries1 = new DirectoryInfo(targetDirectory).GetFiles();
            foreach (FileInfo file in fileEntries1)
                filesList.Add(file.Name);
        }
        }

        public static void CopyFile(FileInfo fileToCopy)
        {
            string elo = fileToCopy.Name.ToString();
            File.Copy(elo,elo+" Copy");
        }
}
}
