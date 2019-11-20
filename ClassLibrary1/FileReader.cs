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

        string path;
        List<string> Extensions;
        public static List<string> filesFound;
        // add a single file to list
        public FileReader(string _path)
        {
            this.path = _path;
        }
        public FileReader(string _path, List<string> _Extensions)
        {
            this.path = _path;
            this.Extensions = _Extensions;
        }
        public static List<string> GetOneFile(string path)
        {
            // throws nullPointerException
            if (File.Exists(path))
            {
                return ProcessFile(path);
            }
            return null;
        }
        public static void ProcessCurrentDirectory(string targetDirectory, List<string> _filesList)
        {
            // Process the list of files found in the directory. Add them to list passed by argument
            //filters only on name of file
            string[] fileEntries = new DirectoryInfo(targetDirectory).GetFiles().Select(o => o.Name).ToArray();
            foreach (string file in fileEntries)
                _filesList.Add(file);
        }
        public static void ProcessSubDirectories(string targetDirectories, List<string> _filesList)
        {
            // Recurse into subdirectories of this directory by using recurrency
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
