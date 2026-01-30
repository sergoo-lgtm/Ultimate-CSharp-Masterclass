IDataDownloader dataDownloader = new SlowDataDownloader();
IDataDownloader cachingDownloader = new CachingDataDownloader(dataDownloader);
Console.WriteLine(cachingDownloader.DownloadData("id1"));
Console.WriteLine(cachingDownloader.DownloadData("id2"));
Console.WriteLine(cachingDownloader.DownloadData("id3"));
Console.WriteLine(cachingDownloader.DownloadData("id1"));
Console.WriteLine(cachingDownloader.DownloadData("id3"));
Console.WriteLine(cachingDownloader.DownloadData("id1"));
Console.WriteLine(cachingDownloader.DownloadData("id2"));

Console.ReadKey();
