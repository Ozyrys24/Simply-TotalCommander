using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace ClassLibrary1
{
    class CompressionFileClass
    {

        private bool CompressFileToZip(string filesToZipPath, string zipPlacePath)
        {
            
            ZipFile.CreateFromDirectory(filesToZipPath,zipPlacePath);
            return true;
        }

    }
}
