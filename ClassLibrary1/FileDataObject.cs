using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        public string directoryPath{get;set;}
        public bool isReadOnly{get;set;}
        public DateTime creationTime{get;set;}
        public DateTime lastAcess{get;set;}
        public DateTime lastWriteTime{get;set;}
        public Icon icon { get; set; }
        public ImageSource imageIcon{ get; set; }

        public FileDataObject(string inPath, string inFileName, string inExtension, string inLength, string inDirectoryName, string inDirectoryPath,
            bool inIsReadOnly, DateTime inCreationTime, DateTime inLastAcess, DateTime inLastWriteTime)
        {
            path = inPath;
            fileName = inFileName;
            extension = inExtension;
            length = inLength;
            directoryName = inDirectoryName;
            directoryPath = inDirectoryPath;
            isReadOnly = inIsReadOnly;
            creationTime = inCreationTime;
            lastAcess = inLastAcess;
            lastWriteTime = inLastWriteTime;
            icon = Icon.ExtractAssociatedIcon(path);
            imageIcon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                                  icon.Handle,
                                  System.Windows.Int32Rect.Empty,
                                  System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

        }
        // Override ToString method to easly display in SearchButton
        public override string ToString()
        {
            return fileName;
        }
    }
}
