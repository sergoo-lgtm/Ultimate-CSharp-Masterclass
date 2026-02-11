
using System;
using System.Text;
using System.Threading;

namespace SnakeGame;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        GameState gameState = new GameState(20, 40); // 20 Rows, 40 Cols

        while (!gameState.GameOver)
        {
            // 1. Handle Input
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        gameState.ChangeDirection(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        gameState.ChangeDirection(Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        gameState.ChangeDirection(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        gameState.ChangeDirection(Direction.Right);
                        break;
                }
            }

            // 2. Update Game Logic
            gameState.Update();

            // 3. Render
            Draw(gameState);

            // 4. Wait
            Thread.Sleep(100);
        }

        Console.SetCursorPosition(0, gameState.Rows + 1);
        Console.WriteLine($"Game Over! Score: {gameState.Score}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void Draw(GameState gameState)
    {
        Console.SetCursorPosition(0, 0);

        char[,] grid = new char[gameState.Rows, gameState.Cols];
        for (int r = 0; r < gameState.Rows; r++)
        {
            for (int c = 0; c < gameState.Cols; c++)
            {
                grid[r, c] = ' ';
            }
        }

        // Draw Snake
        foreach (var pos in gameState.Snake.Body)
        {
            if (pos.Row >= 0 && pos.Row < gameState.Rows &&
                pos.Col >= 0 && pos.Col < gameState.Cols)
            {
                grid[pos.Row, pos.Col] = (pos == gameState.Snake.Head) ? 'O' : 'o';
            }
        }

        // Draw Food
        Position food = gameState.Food;
        if (food.Row >= 0 && food.Row < gameState.Rows &&
            food.Col >= 0 && food.Col < gameState.Cols)
        {
             grid[food.Row, food.Col] = '@';
        }

        StringBuilder sb = new StringBuilder();

        // Top Border
        sb.Append(new string('#', gameState.Cols + 2));
        sb.AppendLine();

        for (int r = 0; r < gameState.Rows; r++)
        {
            sb.Append('#');
            for (int c = 0; c < gameState.Cols; c++)
            {
                sb.Append(grid[r, c]);
            }
            sb.Append('#');
            sb.AppendLine();
        }

        // Bottom Border
        sb.Append(new string('#', gameState.Cols + 2));
        sb.AppendLine();

        sb.AppendLine($"Score: {gameState.Score}  "); 

        Console.Write(sb.ToString());
    }
    
}
