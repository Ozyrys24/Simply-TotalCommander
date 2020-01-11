using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// Data struct of fileDataObject />
    public struct FileDataObject
    {
        public string fileName{get;set;}
        public string extension{get;set;}
        public string length{get;set;}
        public string path{get;set;}
        public string directoryName{get;set;}
        public bool isReadOnly{get;set;}
        public DateTime creationTime{get;set;}
        public DateTime lastAcess{get;set;}
        public DateTime lastWriteTime{get;set;}

        public FileDataObject(string inPath, string inFileName, string inExtension, string inLength, string inDirectoryName, bool inIsReadOnly,
            DateTime inCreationTime, DateTime inLastAcess, DateTime inLastWriteTime)
        {
            path = inPath;
            fileName = inFileName;
            extension = inExtension;
            length = inLength;
            directoryName = inDirectoryName;
            isReadOnly = inIsReadOnly;
            creationTime = inCreationTime;
            lastAcess = inLastAcess;
            lastWriteTime = inLastWriteTime;
        }
        // Override ToString method to easly display in SearchButton
        public override string ToString()
        {
            return fileName;
        }
    }
}
