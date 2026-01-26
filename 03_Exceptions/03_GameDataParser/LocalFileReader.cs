using GameDataParser.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDataParser
{
    internal class LocalFileReader : IFileReader
    {
        string IFileReader.read(string filename)
        {
           
            string FileContent = File.ReadAllText(filename);
            return FileContent;

        }
    }
}
