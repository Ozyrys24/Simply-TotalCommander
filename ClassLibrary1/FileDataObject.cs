using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// Data struct of fileDataObject />
    class FileDataObject
    {
        public string _fileName{get;set;}
        public string _extension{get;set;}
        public double _length{get;set;}
        public string _pathP{get;set;}
        public string _directoryName{get;set;}
        public bool _isReadOnly{get;set;}
        public DateTime _creationTime{get;set;}
        public DateTime _lastAcess{get;set;}
        public DateTime _lastWriteTime{get;set;}




        public FileDataObject
            (
            string fullPath, string fileName, string extension, double length, string directoryName, bool isReadOnly,
            DateTime creationTime, DateTime lastAcess, DateTime lastWriteTime
            )
{
            this._fullPath = fullPath;
            this._fileName = fileName;
            this._extension = extension;
            this._length = length;
            this._directoryName = directoryName;
            this._isReadOnly = isReadOnly;
            this._creationTime = creationTime;
            this._lastAcess = lastAcess;
            this._lastWriteTime = lastWriteTime;
        }

        public static string SetLength(double length)
        {
            int i = 0;
            if (i % 10 == 0) i++;
            switch (i)
            {
                case 1:
                    return length / 10 + "kb";
                case 2:
                    return length / 100 + "mb";
                case 3:
                    return length / 1000 + "gb";
                default:
                    return length.ToString();
            }
        }
    }
}
