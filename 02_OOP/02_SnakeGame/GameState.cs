
using System;
using System.Collections.Generic;

namespace SnakeGame;

public class GameState
{
    public int Rows { get; }
    public int Cols { get; }
    public Snake Snake { get; }
    public Position Food { get; private set; }
    public int Score { get; private set; }
    public bool GameOver { get; private set; }

    private readonly Random _random = new Random();

    public GameState(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        // Start in the middle
        Snake = new Snake(rows / 2, cols / 2);
        RespawnFood();
    }

    private void RespawnFood()
    {
        List<Position> emptyPositions = new List<Position>();
        // Ideally we shouldn't scan the whole grid if it's huge, but for console snake it's fine.
        
        // Optimization: Just pick random spots until we find an empty one.
        // But to be safe and avoid infinite loops near end-game:
        
        do
        {
            int r = _random.Next(1, Rows - 1); // Avoid borders
            int c = _random.Next(1, Cols - 1);
            Position p = new Position(r, c);
            
            bool hitSnake = false;
            foreach (var pos in Snake.Body)
            {
                if (pos == p)
                {
                    hitSnake = true;
                    break;
                }
            }
            
            if (!hitSnake)
            {
                Food = p;
                return;
            }
        } while (true);
    }

    public void ChangeDirection(Direction dir)
    {
        Snake.ChangeDirection(dir);
    }

    public void Update()
    {
        if (GameOver) return;

        Position nextHead = Snake.CalculateNextHeadPosition();

        // 1. Check Wall Collision
        if (nextHead.Row < 0 || nextHead.Row >= Rows ||
            nextHead.Col < 0 || nextHead.Col >= Cols)
        {
            GameOver = true;
            return;
        }

        // 2. Check Self Collision
        // We need to be careful: if we just move, the tail moves. 
        // If we eat, the tail stays.
        if (nextHead == Food)
        {
             // If we eat, we grow. Tail doesn't move. So hitting tail is bad?
             // Actually, if we hit food, we just grow into the food space.
             // We can proceed to check body collision.
             // But wait, if we grow, we add the new head, and DO NOT remove tail.
             // So we must check collision with CURRENT body.
             
             if (Snake.Body.Contains(nextHead))
             {
                 GameOver = true;
                 return;
             }
             
             Snake.Grow();
             Score++;
             RespawnFood();
        }
        else
        {
            // Moving normally.
            // Check if we hit ourselves.
            // Note: If nextHead is the current tail position, it's NOT a collision because tail will move.
            if (Snake.Body.Contains(nextHead) && nextHead != Snake.Body.Last.Value)
            {
                GameOver = true;
                return;
            }
            
            Snake.Move();
        }
    }
}
