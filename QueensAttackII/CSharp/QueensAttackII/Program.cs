using System;

public class Queen
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Obstacle
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class AttackPointsCalculator
{
    private Queen Queen { get; }

    private int TopDist { get; set; }
    private int RightDist { get; set; }
    private int BottomDist { get; set; }
    private int LeftDist { get; set; }
    private int TopRightDist { get; set; }
    private int BottomRightDist { get; set; }
    private int BottomLeftDist { get; set; }
    private int TopLeftDist { get; set; }

    public AttackPointsCalculator(Queen queen, int boardSize)
    {
        Queen = queen;
        TopDist = boardSize - queen.Y;
        RightDist = boardSize - queen.X;
        BottomDist = queen.Y - 1;
        LeftDist = queen.X - 1;
        TopRightDist = Math.Min(TopDist, RightDist);
        BottomRightDist = Math.Min(BottomDist, RightDist);
        BottomLeftDist = Math.Min(BottomDist, LeftDist);
        TopLeftDist = Math.Min(TopDist, LeftDist);
    }

    public void UpdateAttackPoints(Obstacle obstacle)
    {
        var obstaclePosition = GetObstaclePosition(obstacle);
        Calculate(obstaclePosition, obstacle);
    }

    public int GetTotalAttackPoints()
    {
        return 
            TopDist +
            RightDist +
            BottomDist +
            LeftDist +
            TopRightDist +
            BottomRightDist +
            BottomLeftDist +
            TopLeftDist;
    }

    private void Calculate(ObstaclePosition obstaclePosition, Obstacle obstacle)
    {
        var distanceFromObstacle = 0;
        switch (obstaclePosition)
        {
            case ObstaclePosition.Above:
                distanceFromObstacle = obstacle.Y - Queen.Y - 1;
                if (distanceFromObstacle < TopDist)
                {
                    TopDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.Below:
                distanceFromObstacle = Queen.Y - obstacle.Y - 1;
                if (distanceFromObstacle < BottomDist)
                {
                    BottomDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.Right:
                distanceFromObstacle = obstacle.X - Queen.X - 1;
                if (distanceFromObstacle < RightDist)
                {
                    RightDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.Left:
                distanceFromObstacle = Queen.X - obstacle.X - 1;
                if (distanceFromObstacle < LeftDist)
                {
                    LeftDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.AboveRight:
                distanceFromObstacle = obstacle.Y - Queen.Y - 1;
                if (distanceFromObstacle < TopRightDist)
                {
                    TopRightDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.BelowLeft:
                distanceFromObstacle = Queen.Y - obstacle.Y - 1;
                if (distanceFromObstacle < BottomLeftDist)
                {
                    BottomLeftDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.BelowRight:
                distanceFromObstacle = obstacle.X - Queen.X - 1;
                if (distanceFromObstacle < BottomRightDist)
                {
                    BottomRightDist = distanceFromObstacle;
                }
                break;
            case ObstaclePosition.AboveLeft:
                distanceFromObstacle = Queen.X - obstacle.X - 1;
                if (distanceFromObstacle < TopLeftDist)
                {
                    TopLeftDist = distanceFromObstacle;
                }
                break;
            default:
                break;
        }
    }

    private ObstaclePosition GetObstaclePosition (Obstacle obstacle)
    {
        if (obstacle.X == Queen.X && obstacle.Y > Queen.Y)
        {
            return ObstaclePosition.Above;
        }

        if (obstacle.Y - obstacle.X == Queen.Y - Queen.X && obstacle.Y > Queen.Y)
        {
            return ObstaclePosition.AboveRight;
        }

        if (obstacle.Y == Queen.Y && obstacle.X > Queen.X)
        {
            return ObstaclePosition.Right;
        }

        if (obstacle.X > Queen.X && obstacle.X - Queen.X == Queen.Y - obstacle.Y)
        {
            return ObstaclePosition.BelowRight;
        }

        if (obstacle.X == Queen.X && obstacle.Y < Queen.Y)
        {
            return ObstaclePosition.Below;
        }

        if (obstacle.Y - obstacle.X == Queen.Y - Queen.X && obstacle.Y < Queen.Y)
        {
            return ObstaclePosition.BelowLeft;
        }

        if (obstacle.Y == Queen.Y && obstacle.X < Queen.X)
        {
            return ObstaclePosition.Left;
        }

        if (obstacle.X < Queen.X && Queen.X - obstacle.X == obstacle.Y - Queen.Y)
        {
            return ObstaclePosition.AboveLeft;
        }

        return ObstaclePosition.Irrelevant;
    }
}

public enum ObstaclePosition
{
    Irrelevant,
    Above,
    AboveRight,
    Right,
    BelowRight,
    Below,
    BelowLeft,
    Left,
    AboveLeft
}

class Solution
{
    static int QueensAttack(int boardSize, Queen queen, int[][] obstacles)
    {
        var calculator = new AttackPointsCalculator(queen, boardSize);
        foreach (var o in obstacles)
        { 
            var obstacle = new Obstacle
            {
                Y = o[0],
                X = o[1]
            };

            calculator.UpdateAttackPoints(obstacle);
        };

        return calculator.GetTotalAttackPoints();
    }

    static void Main(string[] args)
    {
        string[] nk = Console.ReadLine().Split(' ');

        int boardSize = Convert.ToInt32(nk[0]);

        int numberOfObstacles = Convert.ToInt32(nk[1]);

        string[] queenPosition = Console.ReadLine().Split(' ');

        int queenY = Convert.ToInt32(queenPosition[0]);

        int queenX = Convert.ToInt32(queenPosition[1]);

        int[][] obstacles = new int[numberOfObstacles][];

        for (int i = 0; i < numberOfObstacles; i++)
        {
            obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
        }

        var queenCoordinates = new Queen
        {
            X = queenX,
            Y = queenY
        };

        int result = QueensAttack(boardSize, queenCoordinates, obstacles);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
