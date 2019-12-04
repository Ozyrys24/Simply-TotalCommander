using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ClassLibrary1
{
    public class FileReader : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Clear list & add a single FileDataObject to list oterwise do nothing
        public static void GetOneFile(string path, List<FileDataObject> filesList)
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
        public static void ProcessCurrentDirectory(string directoryPath, List<FileDataObject> filesList)
        {
            if(Directory.Exists(directoryPath))
            {
                filesList.Clear();
                DtoListSetter(new DirectoryInfo(directoryPath).GetFiles(), filesList);
            }
        }
        // Putting into list files from subdirectories (FileDataObject)
        public static void ProcessSubDirectories(string targetDirectories, List<FileDataObject> filesList)
        {

            string[] subdirectoriesEntries = Directory.GetDirectories(targetDirectories);
            foreach (string subdirectories in subdirectoriesEntries)
                ProcessCurrentDirectory(subdirectories, filesList);
        }

        // Clearing then updating list of string with file names
        public static void GetFilesNamesList(string directoryPath, List<FileDataObject> filesList, List<string> stringList) {
        if (Directory.Exists(directoryPath))
        {
                filesList.Clear();
                stringList.Clear();
                DtoListSetter(new DirectoryInfo(directoryPath).GetFiles(), filesList);
                foreach(FileDataObject dto in filesList)
                {             
                    stringList.Add(dto.fileName);
                }
        }
        }
        // Change data into DTO object, clear and put in list taken as argument.
        public static void DtoListSetter(FileInfo[] inList, List<FileDataObject> inDtoList)
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
        public static string SetLenght(double fileLenght)
        {
            int i = 0;
            string value;
            while (fileLenght % 0 == 0)
            {
                fileLenght /= 1000;
                i++;
            }
            switch (i)
            {
                case 0:
                    value = "kilobyte (kB)";
                    break;
                case 1:
                    value = "megabyte (MB)";
                    break;
                case 2:
                    value = "gigabyte (GB)";
                    break;
                case 3:
                    value = "terabyte (TB)";
                    break;
                case 4:
                    value = "petabyte (PB)";
                    break;
                default:
                    value = "unknown size";
                    break;
            }
            return i + " " + value;
        }
}
}
