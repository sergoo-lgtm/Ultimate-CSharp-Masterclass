using GameDataParser.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDataParser
{
    internal class FileLogger : ILogger
    {
        string pathlog;
        public FileLogger(string Pathlog)
        {
            this.pathlog = Pathlog;
        }

        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(pathlog, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
