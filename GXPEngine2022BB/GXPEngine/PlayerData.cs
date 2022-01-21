using System;

internal class PlayerData
{

    private const int START_LIVES = 5;
    private const int START_POINTS = 0;
    private int lives = 0;
    private int points = 0;

    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            int oldLives = lives;
            lives = value;
            if (lives < 0)
            {
                lives = 0;
                Console.WriteLine("Lives can't be negative. Was {0} new value {1}, ", oldLives, value);
            }
            Console.WriteLine("Player lives" + lives);

        }
    }

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }

    }

    public PlayerData()
    {
        Reset();
    }

    private void Reset()
    {
        lives = START_LIVES;
        points = START_POINTS;
        Console.WriteLine("Resetting player data. Lives = {0}, Points = {1}", lives, points);
    }
}
