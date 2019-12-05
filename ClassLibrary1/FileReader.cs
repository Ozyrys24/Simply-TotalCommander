using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace ClassLibrary1
{
    // Class handle with search for file / directories, main argument is DTO with file details. DTO properties collect from FileInfo and Path.
    public class FileReader : INotifyPropertyChanged
    {
        public delegate void ProgressChangedEventHandler();
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler PropertyHasChanged {
            add
            {
                PropertyChanged += value;
            }
            remove
            {
                PropertyChanged -= value;
            }
        }



        // Clear list & add a single FileDataObject to list oterwise do nothing
        public void GetOneFile(string path, ObservableCollection<FileDataObject> filesList)
        {
            if (File.Exists(path))
            {
                filesList.Clear();
                DtoListSetter(new DirectoryInfo(path).GetFiles(), filesList);
                foreach (FileDataObject dto in filesList)
                {
                    if (path == dto.path)
                    {
                        filesList.Clear();
                        filesList.Add(dto);
                    }
                }
            }
        }
        // Process the list of files found in the directory (FileDataObject) otherwise do nothing
        public void ProcessCurrentDirectory(string directoryPath,ObservableCollection<FileDataObject> filesList,object sender,PropertyChangedEventArgs e)
        {
            if (Directory.Exists(directoryPath))
            {
                filesList.Clear();
                DtoListSetter(new DirectoryInfo(directoryPath).GetFiles(), filesList);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("filesList"));
            }
        }
       //  Putting into list files from subdirectories (FileDataObject)
        public void ProcessSubDirectories(string targetDirectories,ObservableCollection<FileDataObject> filesList,object sender,PropertyChangedEventArgs e)
        {
            if (Directory.GetDirectories(targetDirectories) != null)
            {
                string[] subdirectoriesEntries = Directory.GetDirectories(targetDirectories);
                foreach (string subdirectories in subdirectoriesEntries)
                {
                    ProcessCurrentDirectory(subdirectories, filesList, sender, e);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("directoryList"));
                }
            }
        }
       //  Clearing then updating list of string with file names
        public void GetFilesNamesList(string directoryPath,ObservableCollection<FileDataObject> filesList,List<string> inListOfFilesName,
            object sender)
        {
            if (Directory.Exists(directoryPath))
            {
                filesList.Clear();
                inListOfFilesName.Clear();
                DtoListSetter(new DirectoryInfo(directoryPath).GetFiles(), filesList);
                foreach (FileDataObject dto in filesList)
                {
                    inListOfFilesName.Add(dto.fileName);
                }
                PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("listOfFilesName"));
            }
        }
        // Change data into DTO object, clear and put in list taken as argument.
        private void DtoListSetter(FileInfo[] inList,
            ObservableCollection<FileDataObject> inDtoList)          
        {
            inDtoList.Clear();
            foreach (FileInfo file in inList)
            {
                FileDataObject fileTransferObject = new FileDataObject(
                    file.FullName,
                    Path.GetFileNameWithoutExtension(file.FullName),
                    file.Extension,
                    SetLenght(file.Length),
                    file.DirectoryName,
                    file.IsReadOnly,
                    file.CreationTime,
                    file.LastAccessTime,
                    file.LastWriteTime);
                inDtoList.Add(fileTransferObject);
            }
        }

        // return string with name of data size
        public string SetLenght(double fileLenght)
        {
            int i = 0;
            if (fileLenght < 0)
            {
                return "unknown size";
            }
            else if (fileLenght > 0 & fileLenght < 1024)
            {
                return fileLenght + " byte (B)";
            }
            else if (fileLenght < 1048576)
            {
                return fileLenght / 1024 + " kilobye (kB)";
            }
            else if (fileLenght < 1073741824)
            {
                return fileLenght / 1048576 + " megabyte (MB)";
            }
            else
            {
                return fileLenght / 1073741824 + " gigabyte (GB)";
            }
        }

    }
}

