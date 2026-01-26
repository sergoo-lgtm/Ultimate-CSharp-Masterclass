using GameDataParser;
using GameDataParser.INTERFACES;

IFileReader _fileReader = new LocalFileReader();

IGameParser _gameParser = new JsonGameParser();

ILogger _logger = new FileLogger("log.txt");

IUserInteractor _userInteractor = new ConsoleUserInteractor();

GameDataParserApp app = new GameDataParserApp(_fileReader, _gameParser, _logger, _userInteractor);

app.Start();
Console.ReadKey();