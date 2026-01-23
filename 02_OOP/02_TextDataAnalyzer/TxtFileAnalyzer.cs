using System;
using System.Collections.Generic;
using System.Text;

namespace TextDataAnalyzer
{
    internal class TxtFileAnalyzer : FileAnalyzer, IFileAnalysis
    {
        void IFileAnalysis.AnalyzeFile(FileInfo fileinfo)
        {
            string filestring = File.ReadAllText(fileinfo.FullName);
            AnalysisResult result = new AnalysisResult();
            var words =filestring.Split(new char[] { ' ', '\n' });
            result.wordcount = words.Length;
            result.charactercount = filestring.Length;
            var lines = filestring.Split(new char[] { '\n' });
            result.linecount = lines.Length;
            SetAnalysisResult(result);
        }
    }
}
