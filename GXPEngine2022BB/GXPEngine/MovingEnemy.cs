using TiledMapParser;
using System;

internal class MovingEnemy : MovingObject
{
    public MovingEnemy(TiledObject obj = null): base ("car.png", 2f)
    {
        goesLeft(obj.GetBoolProperty("goesLeft", true));
    }

    void Update()
    {
        ObjectMovement();
    }
}

