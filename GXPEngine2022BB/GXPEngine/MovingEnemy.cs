using TiledMapParser;

/// <summary>
/// Enemy object. Moves from side to side. 
/// Inharitates from MovingObject.
/// </summary>

internal class MovingEnemy : MovingObject
{
    private static float SPEED = 2f;

    public MovingEnemy(TiledObject obj = null): base ("car.png", SPEED)
    {
        x = obj.X;
        y = obj.Y;
        IsGoingLeft = obj.GetBoolProperty("goesLeft", true);
        ObjectSpawn();
    }

    void Update()
    {
        ObjectMovement();
    }
}

