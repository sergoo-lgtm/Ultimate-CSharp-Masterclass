public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}
