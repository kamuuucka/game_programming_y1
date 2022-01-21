using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Enemy : Sprite
{
    public float startX = 0;
    private float speed = 2f;
    private bool goesLeft = false;
    public Enemy(TiledObject obj = null) : base("truck.png")
    {
        goesLeft = obj.GetBoolProperty("goesLeft", true);
        EnemiesSpawn();
    }

    private void EnemiesSpawn()
    {
        if (goesLeft)
        {
            startX = 777f;
        }
        else
        {
            startX = -128f;
            Mirror(true,false);
        }
        
        Console.WriteLine("Enemy spawned");
    }

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

