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
        private string _fullPath;
        private string _fileName;
        private string _extension;
        private double _length;


        public FileDataObject(string fullPath, string fileName, string extension, double length)
        {
            this._fullPath = fullPath;
            this._fileName = fileName;
            this._extension = extension;
            this._length = length;
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
