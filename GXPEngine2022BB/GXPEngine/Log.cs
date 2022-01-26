using System;
using GXPEngine;
using TiledMapParser;

//Logs that can move player from left to right


internal class Log : Sprite
{
    private bool goesLeft;
    private float startX = 0f;
    private float speed = 2.2f;
    public Log(TiledObject obj = null) : base("log.png")
    {
        goesLeft = obj.GetBoolProperty("goesLeft", true);
        LogsSpawn();
    }

    //Spawn logs on the screen. Depends on the boolean declaring if the log goes left or right
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

    //Responsible for moving the logs
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

    //Getter used to put the log's speed into the player
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

