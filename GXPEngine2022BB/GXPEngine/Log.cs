using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Log : Sprite
{
    //TODO: Log needs to drop player every 64 pixels
    private bool goesLeft;
    private float startX = 0f;
    private float speed = 2f;
    public Log(TiledObject obj = null) : base("checkers.png")
    {
        goesLeft = obj.GetBoolProperty("goesLeft", false);
        LogsSpawn();
    }

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

        Console.WriteLine("Log spawned");
    }

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

