using TiledMapParser;

/// <summary>
/// Log object. Moves from side to side. 
/// Can put its own speed on player.
/// Inharitates from MovingObject.
/// </summary>

internal class MovingLog : MovingObject
{
    private static float SPEED = 2.2f;

    public MovingLog(TiledObject obj = null) : base("log.png", SPEED)
    {
        x = obj.X;
        y = obj.Y;
        IsGoingLeft = obj.GetBoolProperty("goesLeft", true);
        ObjectSpawn();
    }

    /// <summary>
    /// Used to put the speed on the player when it's attached to the log
    /// </summary>
    /// <returns>
    /// -speed when log is going left
    /// speed when log is going right
    /// </returns>
    public float getSpeed()
    {
        if (IsGoingLeft)
        {
            return -SPEED;
        }
        else
        {
            return SPEED;
        }
    }
    void Update()
    {
        ObjectMovement();
    }
}
