using UglyToad.PdfPig; 
using UglyToad.PdfPig.Content;

namespace TicketsDataAggregator
{
    internal class PdfReader
    {
        public string ReadPdf(string filePath)
        {
            using (PdfDocument documents = PdfDocument.Open(filePath))
            {
                Page page = documents.GetPage(1);
                return page.Text;
            }


        }
    }
}
