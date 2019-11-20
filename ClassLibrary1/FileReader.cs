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

        public static List<string> getFilesFromActuallDirectory(string _path, List<string> _filesList)
        {
            string[] files = Directory.GetFiles(_path);
            foreach(string file in files)
            {

                Path.GetFileName(_path);
                _filesList.Add(file);
            }
            return _filesList;
        }
    }
}
