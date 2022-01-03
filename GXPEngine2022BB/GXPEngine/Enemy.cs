using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Enemy : Sprite
{
    private int eX;
    private int eY;
    private float speed = 2f;
    private new Player player;
    public Enemy(TiledObject obj = null) : base("truck.png")
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Console.WriteLine("Enemy spawned");
    }

    public void EnemyMovement()
    {
        //Move(-speed, 0);

        //if (x < 0 - width)
        //{
        //    x = eX;
        //    Console.WriteLine("Respawning at " + eX);
        //}

        //RunOverPlayer();
            
    }

    //private void RunOverPlayer()
    //{
    //    if (HitTest(player))
    //    {
    //        player.getHit(true);
    //    }
    //}

    //void Update()
    //{
    //    GameObject[] collisions = GetCollisions();
    //}
}

