using GXPEngine;
using TiledMapParser;

/// <summary>
/// Log. Allow player to stick to it and move from side to side
/// </summary>
internal class Log : Sprite
{
    private bool goesLeft;
    private float startX = 0f;
    private float speed = 2.2f;
    public Log(TiledObject obj = null) : base("log.png")
    {
        if (obj != null)
        {
            goesLeft = obj.GetBoolProperty("goesLeft", true);
            LogsSpawn();
        }
    }

    /// <summary>
    /// Spawn logs on the screen. Depends on the boolean declaring if the log goes left or right
    /// </summary>
    private void LogsSpawn()
    {
        if (goesLeft)
        {
            startX = 777f;
        }
        else
        {
            startX = -128f;
        }
    }

    /// <summary>
    /// Moves the logs and respawns them when they leave the screen
    /// </summary>
    private void LogMovement()
    {
        if (goesLeft)
        {
            Move(-speed, 0);

            if (x < 0 - width)
            {
                x = startX;
            }
        }
        else
        {
            Move(speed, 0);
            if (x > 777 + width)
            {
                x = startX;
            }
        }
    }

    /// <summary>
    /// Get's the log speed to put it on the player
    /// </summary>
    /// <returns>
    /// speed if log goes right
    /// -speed if log goes left
    /// </returns>
    public float getSpeed()
    {
        if (goesLeft)
        {
            return -speed;
        }
        else
        {
            return speed;
        }
    }

    void Update()
    {
        LogMovement();
    }
}

