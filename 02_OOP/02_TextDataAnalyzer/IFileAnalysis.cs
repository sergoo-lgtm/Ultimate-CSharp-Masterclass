using System;
using System.Collections.Generic;
using System.Text;

namespace TextDataAnalyzer
{
    internal interface IFileAnalysis
    {
        void AnalyzeFile(FileInfo fileinfo) { }

        void AnalyzeFile(string inputfolder) { }
    }
}
