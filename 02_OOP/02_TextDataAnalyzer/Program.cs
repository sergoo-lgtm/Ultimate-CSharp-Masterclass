using TextDataAnalyzer;

Console.Write("welcome to file analyzer\nenter folder path ===> ");

string inputfolder=Console.ReadLine();
DirectoryInfo directoryInfo=new DirectoryInfo(inputfolder);
if (directoryInfo.Exists == false) { Console.WriteLine("folder not found"); return; }
var filenames = directoryInfo.GetFiles();
IFileAnalysis fileAnalysis = null;
Console.WriteLine();
foreach (var file in filenames)
{
    if (file.Extension == ".txt")
    {
        fileAnalysis = new TxtFileAnalyzer();
        fileAnalysis.AnalyzeFile(file);
        var results = ((FileAnalyzer)fileAnalysis).GetAnalysisResult();
        Console.WriteLine("file name   : " + file.Name);
        Console.WriteLine("word count  : " + results.wordcount);
        Console.WriteLine("char count  : " + results.charactercount);
        Console.WriteLine("line count  : " + results.linecount);

    }
    


    else if (file.Extension == ".csv")
    {
        fileAnalysis = new CsvFileAnalyzer();
        fileAnalysis.AnalyzeFile(file);
        var results = ((FileAnalyzer)fileAnalysis).GetAnalysisResult();
        Console.WriteLine("file  name   : " + file.Name);
        Console.WriteLine("filed count  : " + results.fieldcount);
        
    }

    Console.WriteLine();
}
