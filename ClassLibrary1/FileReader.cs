using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace ClassLibrary1
{
    
    /// <summary>
    /// Class handle with search for file / directories, main argument is DTO with file details. DTO properties collect from FileInfo and Path.
    /// </summary>
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

        /// <summary>
        /// Secure in case of file name with extension in path.
        /// </summary>
        /// <param name="inPath"></param>
        /// <returns></returns>       
        public string[] SecurePath(string inPath)
        {
            string[] securedPath = inPath.Split('\\');
            return securedPath;
        }

        /// <summary>
        /// Change data into FileDataObject, clear and put in list taken as argument.
        /// </summary>
        /// Always clear when used
        /// <param name="path"></param>
        public void Refresh(string path)
        {
            
            ListOfDirectories = new DirectoryInfo(path);
            ListOfFiles  = GetFilesList(ListOfDirectories);
            ListOfDirectoriesName = GetDirectoriesNameList(ListOfDirectories); 
            ListOfFilesName = GetFilesNameList(ListOfDirectories);
        }
        
        /// <summary>
        /// setting directories 
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        ObservableCollection<string> GetDirectoriesNameList(DirectoryInfo directoryInfo)
        {
            ObservableCollection<string> directoriesNamesList = new ObservableCollection<string>();
            
            directoriesNamesList.Add("..");

            foreach (var directory in directoryInfo?.GetDirectories("*", SearchOption.TopDirectoryOnly))
                directoriesNamesList.Add(directory.Name);

            return directoriesNamesList;
        }
        /// <summary>
        /// dynamic data collection, which is provided when items are added, available or after refreshing the entire list.
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        ObservableCollection<string> GetFilesNameList(DirectoryInfo directoryInfo)
        {
            ObservableCollection<string> listOfFileName = new ObservableCollection<string>();
            foreach (var name in directoryInfo?.GetDirectories("*", SearchOption.TopDirectoryOnly))
                listOfFileName.Add(name.Name);
            return listOfFileName;
        }
        
        /// <summary>
        /// create and put in inList <FileDataObject>
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
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
                      file.Directory.FullName,
                      file.IsReadOnly,
                      file.CreationTime,
                      file.LastAccessTime,
                      file.LastWriteTime);
                    if (fileTransferObject.fileName != "")
                        fileDataObjectList.Add(fileTransferObject);
            }

            return fileDataObjectList;
        }
        
        /// <summary>
        /// return formating string with data size converting lenght byte, kilobyte, megabyte, gigabyte.
        /// </summary>
        /// <param name="fileLenght"></param>
        /// <returns></returns>
        public string SetLenght(double fileLenght)
        {
            if (fileLenght < 0)
                return "unknown size";

            else if (fileLenght > 0 & fileLenght < 1024)
                return $"{fileLenght} B";

            else if (fileLenght < 1048576)
                return $"{fileLenght / 1024:0.00} KB";

            else if (fileLenght < 1073741824)
                return $"{fileLenght / 1048576:0.00} MB";

            else
                return $"{fileLenght / 10737418240:0.00} GB";
        }
    }
}

