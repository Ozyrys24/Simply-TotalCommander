using System;
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

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { PropertyChanged += value; }
            remove { PropertyChanged -= value; }
        }

        public ObservableCollection<FileDataObject> ListOfFiles { get; private set; }
        public ObservableCollection<string> ListOfDirectoriesName { get; private set; }
        public ObservableCollection<string> ListOfFilesName { get; private set; }
        public DirectoryInfo ListOfDirectories { get; private set; }
        public string mainPath { get; set; }

        // Secure in case of file name with extension in path.
        public string[] SecurePath(string inPath)
        {
            string[] securedPath = inPath.Split('\\');
            return securedPath;
        }

        // Change data into FileDataObject, clear and put in list taken as argument.
        // * Always clear when used
        public void Refresh(string path)
        {
            
            ListOfDirectories = new DirectoryInfo(path);
            ListOfFiles  = GetFilesList(ListOfDirectories);
            ListOfDirectoriesName = GetDirectoriesNameList(ListOfDirectories); 
            ListOfFilesName = GetFilesNameList(ListOfDirectories);

        }
        // setting directories 
        ObservableCollection<string> GetDirectoriesNameList(DirectoryInfo directoryInfo)
        {
            ObservableCollection<string> directoriesNamesList = new ObservableCollection<string>();
            
            directoriesNamesList.Add("..");

            foreach (var directory in directoryInfo?.GetDirectories("*", SearchOption.TopDirectoryOnly))
                directoriesNamesList.Add(directory.Name);

            return directoriesNamesList;
        }

        ObservableCollection<string> GetFilesNameList(DirectoryInfo directoryInfo)
        {
            ObservableCollection<string> listOfFileName = new ObservableCollection<string>();
            foreach (var name in directoryInfo?.GetDirectories("*", SearchOption.TopDirectoryOnly))
                listOfFileName.Add(name.Name);
            return listOfFileName;
        }
        // create and put in inList <FileDataObject>
        ObservableCollection<FileDataObject> GetFilesList(DirectoryInfo directoryInfo)
        {
            ObservableCollection<FileDataObject> fileDataObjectList = new ObservableCollection<FileDataObject>();
            foreach (FileInfo file in directoryInfo.GetFiles())
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
                    if (fileTransferObject.fileName != "")
                        fileDataObjectList.Add(fileTransferObject);
            }

            return fileDataObjectList;
        }
        // return string with data size.
        public string SetLenght(double fileLenght)
        {
            if (fileLenght < 0)
                return "unknown size";

            else if (fileLenght > 0 & fileLenght < 1024)
                return $"{fileLenght} B";

            else if (fileLenght < 1048576)
                return $"{fileLenght / 1024:.00} KB";

            else if (fileLenght < 1073741824)
                return $"{fileLenght / 1048576:.00} MB";

            else
                return $"{fileLenght / 10737418240:.00} GB";
        }
    }
}

