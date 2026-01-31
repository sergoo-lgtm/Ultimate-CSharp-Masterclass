using System;
using System.Collections.Generic;
using System.Linq;

var movies = new List<Movie>
{
    new Movie { Id = 1, Title = "Inception", Genres = new List<string> { "Sci-Fi", "Action" }, Rating = 8.8, DurationMinutes = 148 },
    new Movie { Id = 2, Title = "The Godfather", Genres = new List<string> { "Crime", "Drama" }, Rating = 9.2, DurationMinutes = 175 },
    new Movie { Id = 3, Title = "Toy Story", Genres = new List<string> { "Animation", "Family" }, Rating = 8.3, DurationMinutes = 81 },
    new Movie { Id = 4, Title = "Interstellar", Genres = new List<string> { "Sci-Fi", "Drama" }, Rating = 8.6, DurationMinutes = 169 },
    new Movie { Id = 5, Title = "Sharknado", Genres = new List<string> { "Action", "Comedy" }, Rating = 3.3, DurationMinutes = 90 },
    new Movie { Id = 6, Title = "Frozen", Genres = new List<string> { "Animation", "Family" }, Rating = 7.4, DurationMinutes = 102 }
};

var users = new List<User>
{
    new User { Id = 101, Name = "Youssef", PreferredGenres = new List<string> { "Sci-Fi", "Action" } },
    new User { Id = 102, Name = "Sarah", PreferredGenres = new List<string> { "Animation", "Drama" } },
    new User { Id = 103, Name = "Ali", PreferredGenres = new List<string> { "Crime" } }
};

var history = new List<WatchLog>
{
    new WatchLog { UserId = 101, MovieId = 1, MinutesWatched = 148 },
    new WatchLog { UserId = 101, MovieId = 4, MinutesWatched = 100 },
    new WatchLog { UserId = 102, MovieId = 3, MinutesWatched = 81 },
    new WatchLog { UserId = 102, MovieId = 6, MinutesWatched = 102 },
    new WatchLog { UserId = 103, MovieId = 2, MinutesWatched = 10 },
};

Console.WriteLine("--- CimaStream Advanced Analytics ---\n");

bool allLongMovies = movies.All(m => m.DurationMinutes > 60);
bool hasBadMovies = movies.Any(m => m.Rating < 4);

Console.WriteLine($"1. Validations: All > 60min? {allLongMovies}, Has Bad Movies? {hasBadMovies}");

var allGenres = movies.SelectMany(m => m.Genres).Distinct().OrderBy(g => g).ToList();

Console.WriteLine($"\n2. All Genres: {string.Join(", ", allGenres)}");

var page2 = movies.OrderByDescending(m => m.Rating).Skip(2).Take(2);

Console.WriteLine("\n3. Top Rated (Page 2):");
foreach (var m in page2) Console.WriteLine($"   - {m.Title} ({m.Rating})");

var youssefPrefs = users.First(u => u.Name == "Youssef").PreferredGenres;
var sarahPrefs = users.First(u => u.Name == "Sarah").PreferredGenres;
var commonInterests = youssefPrefs.Intersect(sarahPrefs);

Console.WriteLine($"\n4. Common Interests (Youssef & Sarah): {(commonInterests.Any() ? string.Join(",", commonInterests) : "None")}");

var userStats = users.GroupJoin(
    history,
    u => u.Id,
    h => h.UserId,
    (user, logs) => new
    {
        UserName = user.Name,
        TotalMovies = logs.Count(),
        TotalMinutes = logs.Sum(l => l.MinutesWatched),
        AvgWatchTime = logs.Any() ? logs.Average(l => l.MinutesWatched) : 0
    }
).OrderByDescending(s => s.TotalMinutes);

Console.WriteLine("\n5. User Watch Statistics:");
foreach (var stat in userStats)
{
    string status = stat.TotalMinutes > 150 ? "Binge Watcher" : "Casual";
    Console.WriteLine($"   - {stat.UserName}: {stat.TotalMovies} movies ({stat.TotalMinutes} mins) -> {status}");
}

Dictionary<int, string> moviesDict = movies.ToDictionary(m => m.Id, m => m.Title);

Console.WriteLine($"\n6. Dictionary Lookup ID(4): {moviesDict[4]}");

string allTitles = movies.Select(m => m.Title)
                         .Aggregate((current, next) => current + " | " + next);

Console.WriteLine($"\n7. Aggregated Titles: {allTitles}");

var specificMovie = movies.SingleOrDefault(m => m.Title == "Inception");
var thirdMovie = movies.ElementAtOrDefault(2);

Console.WriteLine($"\n8. Specific: {specificMovie?.Title}, Third: {thirdMovie?.Title}");
