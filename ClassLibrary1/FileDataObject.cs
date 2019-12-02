using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// Data struct of fileDataObject />
    struct FileDataObject
    {
        private string fullPath;
        private string fileName;
        private string extension;
        private double length;


        public FileDataObject(string fullPath, string fileName, string extension, double length)
        {
            this.fullPath = fullPath;
            this.fileName = fileName;
            this.extension = extension;
            this.length = length;
        }
    }
}
