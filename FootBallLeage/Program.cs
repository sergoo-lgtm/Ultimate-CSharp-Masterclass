using Football_Leage;
using System;
using System.IO;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new FootballLeageDBContect();

        var teamRepo = new GenericRepository<Team>(context);
        var coachRepo = new GenericRepository<Coach>(context);

        var teamService = new TeamService(teamRepo);
        var coachService = new CoachService(coachRepo);

        var program = new Program(); 

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1=> Manage Teams");
            Console.WriteLine("2=> Manage Coaches");
            Console.WriteLine("3=> Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    program.ManageTeams(teamService);
                    break;

                case "2":
                    program.ManageCoaches(coachService);
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }
        }
    }
    void ManageTeams(TeamService teamService)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("=================> Teams <=============");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 View All");
            Console.WriteLine("3 Update");
            Console.WriteLine("4 Delete");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    var addName = Console.ReadLine();
                    var addDto = new AddTeamDto { Name = addName };
                    teamService.AddTeam(addDto);
                    Console.WriteLine("Team added successfully!");
                    break;

                case "2":
                    var teams = teamService.GetAllTeams();
                    foreach (var t in teams)
                        Console.WriteLine($"{t.TeamId} - {t.Name}");
                    break;

                case "3":
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("New Name: ");
                        var newName = Console.ReadLine();
                        var updateDto = new UpdateTeamDTO
                        {
                            TeamId = updateId,
                            Name = newName
                        };

                        try
                        {
                            teamService.UpdateTeam(updateDto);
                            Console.WriteLine("Team updated successfully!");
                        }
                        catch (KeyNotFoundException ex) 
                        {
                            Console.WriteLine($"Update Error: {ex.Message}");
                            LogError(ex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id!");
                    }
                    break;

                case "4":
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        teamService.DeleteTeam(deleteId);
                        Console.WriteLine("Team deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id!");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        catch (Exception ex) 
        { 
            Console.WriteLine($"Unexpected Error: {ex.Message}");
            LogError(ex);
        }

        Console.WriteLine("\nPress any key");
        Console.ReadKey();
    }


    void ManageCoaches(CoachService coachService)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("============> Coaches <======");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 View All");
            Console.WriteLine("3 Update");
            Console.WriteLine("4 Delete");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    var addName = Console.ReadLine();
                    var addDto = new AddCoachDto { Name = addName };
                    coachService.AddCoach(addDto);
                    Console.WriteLine("Coach added successfully!");
                    break;

                case "2":
                    var coaches = coachService.GetAllCoaches();
                    foreach (var c in coaches)
                        Console.WriteLine($"{c.CoachId} - {c.Name}");
                    break;

                case "3":
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("New Name: ");
                        var updateDto = new UpdateCoachDto
                        {
                            CoachId = updateId,
                            Name = Console.ReadLine()
                        };

                        try
                        {
                            coachService.UpdateCoach(updateDto);
                            Console.WriteLine("Coach updated successfully!");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine($"Update Error: {ex.Message}");
                            LogError(ex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id!");
                    }
                    break;

                case "4":
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        coachService.DeleteCoach(deleteId);
                        Console.WriteLine("Coach deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id!");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
            LogError(ex);
        }

        Console.WriteLine("\nPress any key");
        Console.ReadKey();
    }
    void LogError(Exception ex)
    {
        try
        {
            var logMessage = $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
            File.AppendAllText("error.log", logMessage);
        }
        catch
        {
        }
    }
}