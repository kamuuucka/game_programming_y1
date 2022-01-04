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
    private float startY;
    private float speed = 2f;
    TiledObject obj;
    List<Enemy> enemyList = new List<Enemy>(2);
    //Enemy[] enemies = new Enemy[2];
    public Enemy(TiledObject obj = null) : base("truck.png")
    {
        this.obj = obj;
        //SpawnEnemy();
        EnemiesSpawn();
        startX = obj.X;
        //startY = obj.Y;
    }

    private void EnemiesSpawn()
    {
        for (int i = 0; i < 2; i++)
        {
            //Console.WriteLine("Enemies");
            //enemyList.Add(new Enemy(obj));
            //if (enemies[i] != null)
            //{
            //    enemies[i].x = (startX + i * 150f);
            //}

        }
        Console.WriteLine("Loop finished");
    }

    private void EnemiesMovement()
    {
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    enemies[i].EnemyMovement();
        //}
    }

    private void SpawnEnemy()
    {
        Console.WriteLine("Enemy spawned");        
    }

    //public void SetSpawnX(float configuredX)
    //{
    //    startX = configuredX;
    //}

    public void EnemyMovement()
    {
        Move(-speed, 0);

        if (x < 0 - width)
        {
            x = startX;
            Console.WriteLine("Respawning at " + startX);
        }
    }

    void Update()
    {
        //EnemyMovement();
        //EnemiesMovement();
    }
}

