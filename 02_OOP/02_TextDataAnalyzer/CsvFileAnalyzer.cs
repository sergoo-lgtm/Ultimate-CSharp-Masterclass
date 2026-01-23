using System;
using System.Collections.Generic;
using System.Text;

namespace TextDataAnalyzer
{
    internal class CsvFileAnalyzer : FileAnalyzer,IFileAnalysis
    {
        void IFileAnalysis.AnalyzeFile(FileInfo fileinfo)
        {
            string[] filestring = File.ReadAllLines(fileinfo.FullName);
            AnalysisResult result = new AnalysisResult();
            var rowelements = filestring[0].Split(',');
            result.fieldcount = rowelements.Length;
            SetAnalysisResult(result);


        }
    }
}
