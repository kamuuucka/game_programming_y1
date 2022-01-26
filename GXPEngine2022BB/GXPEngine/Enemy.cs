using System;
using GXPEngine;
using TiledMapParser;

/// <summary>
/// Enemy. Contains everything that needed to have an enemy
/// </summary>
internal class Enemy : Sprite
{
    private float startX = 0;
    private float speed = 2f;
    private bool goesLeft = false;
    public Enemy(TiledObject obj = null) : base("car.png")
    {
        goesLeft = obj.GetBoolProperty("goesLeft", true);
        EnemySpawn();
    }

    /// <summary>
    /// Sets start X for enemy depending on which way it goes
    /// </summary>
    private void EnemySpawn()
    {
        if (goesLeft)
        {
            startX = 905f;
        }
        else
        {
            startX = -128f;
            Mirror(true,false);
        }
    }

    /// <summary>
    /// Moves the enemy and respawns it when it leaves the screen
    /// </summary>
    public void EnemyMovement()
    {
        if (goesLeft)
        {
            Move(-speed, 0);

            if (x < 0 - width)
            {
                x = startX;
            }
        } else
        {
            Move(speed, 0);
            if (x > 777 + width)
            {
                x = startX;
            }
        }
    }

    void Update()
    {
        EnemyMovement();
    }
}

