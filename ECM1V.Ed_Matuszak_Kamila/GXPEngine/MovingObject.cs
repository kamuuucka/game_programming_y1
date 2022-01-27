using GXPEngine;
using System;

/// <summary>
/// Moving object. Class responsible for events connected with objects that are moving from side to side
/// </summary>

internal class MovingObject : Sprite
{
    private bool isLeft;
    private float startX;
    private float speed;

    public MovingObject(string sprite, float speed) : base(sprite)
    {
        this.speed = speed;
    }

    /// <summary>
    /// Variable that checks if object is moving to the right or to the left
    /// </summary>
    public bool IsGoingLeft
    {
        get
        {
            return isLeft;
        }
        set
        {
            isLeft = value;
        }
    }

    protected void ObjectSpawn()
    {
        if (isLeft)
        {
            startX = 905f;
            Console.WriteLine("Object left spawn X: " + startX);
        }
        if (!isLeft)
        {
            startX = -128f;
            Mirror(true, false);
        }
    }
    protected void ObjectMovement()
    {
        if (isLeft)
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
}

