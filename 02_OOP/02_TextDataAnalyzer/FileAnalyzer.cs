using System;
using System.Collections.Generic;
using System.Text;

namespace TextDataAnalyzer
{
    internal class FileAnalyzer:IFileAnalysis
    {
        AnalysisResult _results;
        
        public AnalysisResult GetAnalysisResult() { return _results; }

        public AnalysisResult SetAnalysisResult(AnalysisResult results)

        {
            _results = results;
            return _results;
                
        }
    
    
    }
}
