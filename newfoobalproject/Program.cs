using Foorball_Leage;
using Football_Leage;
using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new FootballLLeageDbContext();
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
            Console.WriteLine("4 => Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    program.ManageTeams(teamService, unitOfWork);
                    break;

                case "2":
                    program.ManageCoaches(coachService, unitOfWork);
                    break;

                case "3":
                    program.AddTeamAndCoachTogether(teamService, coachService, unitOfWork);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }
        }
    }

    void ManageTeams(TeamService teamService, IUnitOfWork unitOfWork)
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

                    teamService.AddTeam(new AddTeamDto { Name = addName, Description = addDescription });
                    unitOfWork.Save(); 
                    Console.WriteLine("Team added successfully!");
                    break;

                case "2":
                    var teams = teamService.GetAllTeams();
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

                        teamService.UpdateTeam(updateDto);
                        unitOfWork.Save(); 
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
                        teamService.DeleteTeam(deleteId);
                        unitOfWork.Save();
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

    void ManageCoaches(CoachService coachService, IUnitOfWork unitOfWork)
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

                    coachService.AddCoach(new AddCoachDto { Name = addName, Description = addDescription });
                    unitOfWork.Save(); 
                    Console.WriteLine("Coach added successfully!");
                    break;

                case "2":
                    var coaches = coachService.GetAllCoach();
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

                        coachService.UpdateCoach(updateDto);
                        unitOfWork.Save(); 
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
                        coachService.DeleteCoach(deleteId);
                        unitOfWork.Save(); 
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

    void AddTeamAndCoachTogether(TeamService teamService, CoachService coachService, IUnitOfWork unitOfWork)
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

            teamService.AddTeam(teamDto);
            coachService.AddCoach(coachDto);

            unitOfWork.Save(); 
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