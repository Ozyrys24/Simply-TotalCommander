using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace ClassLibrary1
{
    // Class handle with search for file / directories, main argument is DTO with file details. DTO properties collect from FileInfo and Path.
    public class FileReader : INotifyPropertyChanged
    {
        public delegate void ProgressChangedEventHandler();

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangedEventHandler PropertyHasChanged
        {
            add { PropertyChanged += value; }
            remove { PropertyChanged -= value; }
        }

        // Clear list & add a single FileDataObject to list oterwise do nothing
        public void GetOneFile(string path, ObservableCollection<FileDataObject> filesList,
            List<string> listOfDirectories)
        {
            if (File.Exists(path))
            {
                filesList.Clear();
                DtoListSetter(path, new DirectoryInfo(path).GetFiles(), filesList, listOfDirectories);
                foreach (FileDataObject dto in filesList)
                {
                    if (path == dto.path)
                    {
                        filesList.Clear();
                        filesList.Add(dto);
                        break;
                    }
                }
            }
        }
        // Process the list of files found in the directory (FileDataObject) otherwise do nothing
        public void ProcessCurrentDirectory(string directoryPath, ObservableCollection<FileDataObject> filesList,
            List<string> listOfDirectories, object sender, PropertyChangedEventArgs e)
        {
            if (Directory.Exists(directoryPath))
            {
                filesList.Clear();
                DtoListSetter(directoryPath, new DirectoryInfo(directoryPath).GetFiles(), filesList, listOfDirectories);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("filesList"));
             //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("listOfDirectories"));
            }
        }

        //  Clearing then updating list of string with file names and file list, otherwise do nothing.
        public void GetFilesNamesList(string directoryPath, ObservableCollection<FileDataObject> filesList,
            List<string> inListOfFilesName,
            List<string> inListOfDirectories,
            object sender)
        {
            if (Directory.Exists(directoryPath))
            {
                filesList.Clear();
                inListOfFilesName.Clear();
                DtoListSetter(directoryPath, new DirectoryInfo(directoryPath).GetFiles(), filesList,
                    inListOfDirectories);
                foreach (FileDataObject dto in filesList)
                {
                    inListOfFilesName.Add(dto.fileName);
                }
                PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("listOfFilesName"));
            }
        }

        // Secure in case of file name with extension in path.
        public string[] SecurePath(string inPath)
        {
            string[] securedPath = inPath.Split('\\');
            return securedPath;
        }

        // Change data into FileDataObject, clear and put in list taken as argument.
        // * Always clear when used
        private void DtoListSetter(string directoryPath, FileInfo[] inList,
            ObservableCollection<FileDataObject> inDtoList, List<string> inSubdirectoriesNameList)
        {
            // cleaning lists.
            inDtoList.Clear();
            inSubdirectoriesNameList.Clear();
            // setting directories       
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
            foreach (var d in dirInfo.GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                inSubdirectoriesNameList.Add(d.Name);
            }
            // create and put in inList <FileDataObject>
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
        // return string with data size.
        public string SetLenght(double fileLenght)
        {
            if (fileLenght < 0)
            {
                return "unknown size";
            }
            else if (fileLenght > 0 & fileLenght < 1024)
            {
                return $"{fileLenght} B";
            }
            else if (fileLenght < 1048576)
            {
                return $"{(fileLenght / 1024):.00} KB";
            }
            else if (fileLenght < 1073741824)
            {
                return $"{(fileLenght / 1048576):.00} MB";
            }
            else
            {
                return $"{(fileLenght / 10737418240):.00} GB";
            }
        }
    }
}

