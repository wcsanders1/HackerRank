using System;

class Solution
{

    // Complete the queensAttack function below.
    static int QueensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
    {
        var topDist = n - r_q;
        var rightDist = n - c_q;
        var bottomDist = r_q - 1;
        var leftDist = c_q - 1;
        var topRightDist = Math.Min(topDist, rightDist);
        var bottomRightDist = Math.Min(bottomDist, rightDist);
        var bottomLeftDist = Math.Min(bottomDist, leftDist);
        var topLeftDist = Math.Min(topDist, leftDist);

        foreach (var obstacle in obstacles)
        {
            var obstacleY = obstacle[0];
            var obstacleX = obstacle[1];

            // directly above
            if (obstacleX == c_q && obstacleY > r_q)
            {
                var distFromObstacle = obstacleY - r_q - 1;
                if (distFromObstacle < topDist)
                {
                    topDist = distFromObstacle;
                }

                continue;
            }

            // directly below
            if (obstacleX == c_q && obstacleY < r_q)
            {
                var distanceFromObstacle = r_q - obstacleY - 1;
                if (distanceFromObstacle < bottomDist)
                {
                    bottomDist = distanceFromObstacle;
                }

                continue;
            }

            //directly right
            if (obstacleY == r_q && obstacleX > c_q)
            {
                var distanceFromObstacle = obstacleX - c_q - 1;
                if (distanceFromObstacle < rightDist)
                {
                    rightDist = distanceFromObstacle;
                }

                continue;
            }

            // directly left
            if (obstacleY == r_q && obstacleX < c_q)
            {
                var distanceFromObstacle = c_q - obstacleX - 1;
                if (distanceFromObstacle < leftDist)
                {
                    leftDist = distanceFromObstacle;
                }

                continue;
            }

            // top right
            if (obstacleY - obstacleX == r_q - c_q &&
                obstacleY > r_q)
            {
                var distanceFromObstacle = obstacleY - r_q - 1;
                if (distanceFromObstacle < topRightDist)
                {
                    topRightDist = distanceFromObstacle;
                }

                continue;
            }

            // bottom left
            if (obstacleY - obstacleX == r_q - c_q &&
                obstacleY < r_q)
            {
                var distanceFromObstacle = r_q - obstacleY - 1;
                if (distanceFromObstacle < bottomLeftDist)
                {
                    bottomLeftDist = distanceFromObstacle;
                }

                continue;
            }

            // bottom right
            if (obstacleX > c_q && obstacleX - c_q == r_q - obstacleY)
            {
                var distanceFromObstacle = obstacleX - c_q - 1;
                if (distanceFromObstacle < bottomRightDist)
                {
                    bottomRightDist = distanceFromObstacle;
                }

                continue;
            }

            // top left
            if (obstacleX < c_q && c_q - obstacleX == obstacleY - r_q)
            {
                var distanceFromObstacle = c_q - obstacleX - 1;
                if (distanceFromObstacle < topLeftDist)
                {
                    topLeftDist = distanceFromObstacle;
                }

                continue;
            }
        }

        return 
            topDist +
            rightDist +
            bottomDist +
            leftDist +
            topRightDist +
            bottomRightDist +
            bottomLeftDist +
            topLeftDist;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);



        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        string[] r_qC_q = Console.ReadLine().Split(' ');

        int r_q = Convert.ToInt32(r_qC_q[0]);

        int c_q = Convert.ToInt32(r_qC_q[1]);

        int[][] obstacles = new int[k][];

        for (int i = 0; i < k; i++)
        {
            obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
        }

        int result = QueensAttack(n, k, r_q, c_q, obstacles);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
