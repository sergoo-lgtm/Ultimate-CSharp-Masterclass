using Foorball_Leage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

internal class Program
{
    static async Task Main(string[] args)
    {
        using var context = new FootballLeagueDbContext();
        var unitOfWork = new UnitOfWork(context);

        var teamService = new TeamService(unitOfWork);
        var coachService = new CoachService(unitOfWork);

        var program = new Program();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== Football League Management ======");
            Console.WriteLine("1 => Manage Teams");
            Console.WriteLine("2 => Manage Coaches");
            Console.WriteLine("3 => Add Team + Coach together");
            Console.WriteLine("4 => View Teams Ordered by Name (Query)");
            Console.WriteLine("5 => View Coaches Ordered by Name (Query)");
            Console.WriteLine("6 => Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await program.ManageTeamsAsync(teamService, unitOfWork);
                    break;

                case "2":
                    await program.ManageCoachesAsync(coachService, unitOfWork);
                    break;

                case "3":
                    await program.AddTeamAndCoachTogetherAsync(teamService, coachService, unitOfWork);
                    break;

                case "4":
                    await program.ViewTeamsQueryAsync(teamService);
                    break;

                case "5":
                    await program.ViewCoachesQueryAsync(coachService);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }
        }
    }

    async Task ManageTeamsAsync(TeamService teamService, IUnitOfWork unitOfWork)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("============ Teams Management ============");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 View All");
            Console.WriteLine("3 Update");
            Console.WriteLine("4 Delete");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    var addName = Console.ReadLine();
                    Console.Write("Description: ");
                    var addDescription = Console.ReadLine();

                    await teamService.AddTeam(new AddTeamDto { Name = addName, Description = addDescription });
                    await unitOfWork.SaveChangesAsync(); 

                    Console.WriteLine("Team added successfully!");
                    break;

                case "2":
                    var teams = await teamService.GetAllTeams();
                    foreach (var t in teams)
                        Console.WriteLine($"{t.TeamId} - {t.Name} - {t.Description}");
                    break;

                case "3":
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("New Name: ");
                        var newName = Console.ReadLine();
                        Console.Write("New Description: ");
                        var newDescription = Console.ReadLine();

                        var updateDto = new UpdateTeamDto
                        {
                            TeamId = updateId,
                            Name = newName,
                            Description = newDescription
                        };

                        await teamService.UpdateTeam(updateDto);
                        await unitOfWork.SaveChangesAsync(); 

                        Console.WriteLine("Team updated successfully!");
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
                        await teamService.DeleteTeam(deleteId);
                        await unitOfWork.SaveChangesAsync(); 

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

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    async Task ManageCoachesAsync(CoachService coachService, IUnitOfWork unitOfWork)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("============ Coaches Management ============");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 View All");
            Console.WriteLine("3 Update");
            Console.WriteLine("4 Delete");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    var addName = Console.ReadLine();
                    Console.Write("Description: ");
                    var addDescription = Console.ReadLine();

                    await coachService.AddCoach(new AddCoachDto { Name = addName, Description = addDescription });
                    await unitOfWork.SaveChangesAsync(); 

                    Console.WriteLine("Coach added successfully!");
                    break;

                case "2":
                    var coaches = await coachService.GetAllCoach();
                    foreach (var c in coaches)
                        Console.WriteLine($"{c.CoachId} - {c.Name} - {c.Description}");
                    break;

                case "3":
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("New Name: ");
                        var newName = Console.ReadLine();
                        Console.Write("New Description: ");
                        var newDescription = Console.ReadLine();

                        var updateDto = new UpdateCoachDto
                        {
                            CoachId = updateId,
                            Name = newName,
                            Description = newDescription
                        };

                        await coachService.UpdateCoach(updateDto);
                        await unitOfWork.SaveChangesAsync();
                        Console.WriteLine("Coach updated successfully!");
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
                        await coachService.DeleteCoach(deleteId);
                        await unitOfWork.SaveChangesAsync(); // <-- هنا الحفظ

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

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    async Task AddTeamAndCoachTogetherAsync(TeamService teamService, CoachService coachService, IUnitOfWork unitOfWork)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("==== Add Team and Coach Together ====");

            Console.Write("Team Name: ");
            var teamName = Console.ReadLine();
            Console.Write("Team Description: ");
            var teamDesc = Console.ReadLine();

            Console.Write("Coach Name: ");
            var coachName = Console.ReadLine();
            Console.Write("Coach Description: ");
            var coachDesc = Console.ReadLine();

            var teamDto = new AddTeamDto { Name = teamName, Description = teamDesc };
            var coachDto = new AddCoachDto { Name = coachName, Description = coachDesc };

            await teamService.AddTeam(teamDto);
            await coachService.AddCoach(coachDto);
            await unitOfWork.SaveChangesAsync(); 

            Console.WriteLine("Team and Coach added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding team and coach: {ex.Message}");
            LogError(ex);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    async Task ViewTeamsQueryAsync(TeamService teamService)
    {
        Console.Clear();
        Console.WriteLine("====== Teams Ordered by Name (Query) ======");
        var teamsQuery = teamService.GetTeamsQuery();

        var teams = teamsQuery
            .Where(t => !string.IsNullOrEmpty(t.Name))
            .OrderBy(t => t.Name)
            .ToList();

        foreach (var t in teams)
            Console.WriteLine($"{t.TeamId} - {t.Name} - {t.Description}");

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    async Task ViewCoachesQueryAsync(CoachService coachService)
    {
        Console.Clear();
        Console.WriteLine("====== Coaches Ordered by Name (Query) ======");
        var coachesQuery = coachService.GetCoachesQuery();

        var coaches = coachesQuery
            .Where(c => !string.IsNullOrEmpty(c.Name))
            .OrderBy(c => c.Name)
            .ToList();

        foreach (var c in coaches)
            Console.WriteLine($"{c.CoachId} - {c.Name} - {c.Description}");

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    void LogError(Exception ex)
    {
        try
        {
            var logMessage = $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
            File.AppendAllText("error.log", logMessage);
        }
        catch { }
    }
}