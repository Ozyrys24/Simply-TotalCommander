using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace FileReader
{
    public class FileReader : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static List<string> filesFound;
        // add a single file to list
        public static List<string> GetOneFile(string path)
        {
            // throws nullPointerException need to handle 
            if (File.Exists(path))
            {
                return ProcessFile(path);
            }
            return null;
        }
        // Process the list of files found in the directory. Add them to list passed by argument
        public static void ProcessCurrentDirectory(string targetDirectory, List<FileInfo> _filesList)
        {
            //Method to put filters on search, like name extension path etc.
           // string[] fileEntries = new DirectoryInfo(targetDirectory).GetFiles().Select(o => o.Extension).ToArray();
            FileInfo[] fileEntries1 = new DirectoryInfo(targetDirectory).GetFiles();
            foreach (FileInfo file in fileEntries1)
                _filesList.Add(file);
        }
        // Putting into list files from subdirectories
        public static void ProcessSubDirectories(string targetDirectories, List<FileInfo> _filesList)
        {

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectories);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessCurrentDirectory(subdirectory, _filesList);
        }

        //add existing files into list
        public static List<string> ProcessFile(string path)
        {
            foreach (string f in filesFound)
            {
                filesFound.Add(f);
            }
            return filesFound;
        }
    }
}
