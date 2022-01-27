using TiledMapParser;
using System;

internal class MovingLog : MovingObject
{
    public MovingLog(TiledObject obj = null) : base("log.png", 2.2f)
    {
        goesLeft(obj.GetBoolProperty("goesLeft", true));
    }

    void Update()
    {
        ObjectMovement();
    }
}
