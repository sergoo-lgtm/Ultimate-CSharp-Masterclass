
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame;

public class Snake
{
    public Direction Direction { get; private set; } = Direction.Right;
    public Position Head => Body.First.Value;
    
    // Using LinkedList to efficiently add to head and remove from tail
    public LinkedList<Position> Body { get; } = new LinkedList<Position>();

    public Snake(int startRow, int startCol, int length = 3)
    {
        for (int i = 0; i < length; i++)
        {
            Body.AddLast(new Position(startRow, startCol - i));
        }
    }

    public Position CalculateNextHeadPosition()
    {
        return Head.Translate(Direction);
    }

    public void Move()
    {
        Position newHead = CalculateNextHeadPosition();
        Body.AddFirst(newHead);
        Body.RemoveLast();
    }

    public void Grow()
    {
        Position newHead = CalculateNextHeadPosition();
        Body.AddFirst(newHead);
        // Do not remove tail to simulate growth
    }

    public void ChangeDirection(Direction newDirection)
    {
        // Prevent 180 degree turn
        if (Direction != newDirection.Opposite())
        {
            Direction = newDirection;
        }
    }

    public bool WillHitSelf(Position nextHead)
    {
        // Check if the next head position is already in the body
        // Note: The tail will move at the same time, so hitting the tail is fine ONLY if we are not growing.
        // But for simplicity, we can check collision with the current body minus the tail.
        
        // Actually, simpler logic:
        foreach (var pos in Body)
        {
             // If we are moving (not growing), the tail will move away, so we shouldn't collide with it.
             // But if we grow, the tail stays.
             // Let's implement strict collision for now: if it hits any part of the body.
             if (pos == nextHead)
             {
                 // Special case: if nextHead is the tail, and we are moving, it's safe.
                 if (pos == Body.Last.Value)
                 {
                     return false; 
                 }
                 return true;
             }
        }
        return false;
    }
}
