public class CachingDataDownloader : IDataDownloader
{
    private IDataDownloader _innerDownloader;
    private CACHE<string, string> _cache = new CACHE<string, string>();
    public CachingDataDownloader(IDataDownloader innerDownloader)
    {
        _innerDownloader = innerDownloader;
    }


    public string DownloadData(string resourceId)
    {
        return _cache.get(resourceId, _innerDownloader.DownloadData);
    }
}
