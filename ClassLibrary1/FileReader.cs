using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace FileReader
{
    public class FileReader : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // add a single file to list
        public static void GetOneFile(string _path, List<FileInfo> _filesList)
        {
            // throws nullPointerException need to handle 
            if (File.Exists(_path))
            {
                FileInfo[] fileEntries1 = new DirectoryInfo(_path).GetFiles();
                foreach (FileInfo file in fileEntries1)
                    _filesList.Add(file);
            }   
        }
        // Process the list of files found in the directory. Add them to list passed by argument
        public static void ProcessCurrentDirectory(string _targetDirectory, List<FileInfo> _filesList)
        {
            //Method to put filters on search, like name extension path etc.
            // string[] fileEntries = new DirectoryInfo(targetDirectory).GetFiles().Select(o => o.Extension).ToArray();
            try
            {
                FileInfo[] fileEntries1 = new DirectoryInfo(_targetDirectory).GetFiles();
                foreach (FileInfo file in fileEntries1)
                    _filesList.Add(file);
            }
            catch
            {
                MessageBox.Show("Unable to read folder", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Putting into list files from subdirectories
        public static void ProcessSubDirectories(string _targetDirectories, List<FileInfo> _filesList)
        {

            string[] subdirectoryEntries = Directory.GetDirectories(_targetDirectories);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessCurrentDirectory(subdirectory, _filesList);
        }
    }
}
