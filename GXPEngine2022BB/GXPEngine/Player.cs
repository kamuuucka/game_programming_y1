using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


internal class Player : AnimationSprite
{
    private int damage = 1;
    const int maxHealth = 5;
    private int health;
    private float previousY = 0;
    private float previousX = 0;
    public float startX = 0;
    public float startY = 0;
    private float speed = 64f;
    private bool started;
    public bool isDead = false;
    private LevelManager levelManager;
        
    public Player(TiledObject obj=null) : base("forg_sprites_big.png", 2, 2)
    {
        SpawnPlayer();
        health = maxHealth;
        ((MyGame)game).ShowHealth(health);
        if (obj != null)
        {
            startX = obj.X + 20;
            previousX = startX;
            startY = obj.Y + 20;
            previousY = startY;
            
            Console.WriteLine("Player spawned: " + startX + ", " + startY);
        }
        
    }


    private void CharacterMovement()
    {

        if (Input.GetKeyUp(Key.A))
        {
            previousX = x;
            Move(-speed, 0);
            SetCycle(1, 1);
        }
        else if (Input.GetKeyUp(Key.D))
        {
            previousX = x;
            Move(speed, 0);
            SetCycle(0, 1);
        }
        else if (Input.GetKeyUp(Key.W))
        {
            previousY = y;
            Move(0, -speed);
            SetCycle(2, 1);
        }
        else if (Input.GetKeyUp(Key.S))
        {
            previousY = y;
            Move(0, speed);
            SetCycle(3, 1);  
        }

        if (x<0 || x > 768)
        {
            x = previousX;
        }

        Animate();
        CheckCollisions();        
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Enemy)
            {
                TakeDamage();
                isDead = true;
                SpawnPlayer();
            }
            if (collisions[i] is Pickup)
            {
                ((Pickup)collisions[i]).Grab();
            }
            if (collisions[i] is Wall)
            {
                BlockPlayer();          
            }
            if (collisions[i] is Log)
            {
                Move(((Log)collisions[i]).getSpeed(), 0);
            }
        }
    }


    private void SpawnPlayer()
    {
        x = startX;
        y = startY;
        SetCycle(2, 1);
    }


    private void BlockPlayer()
    {
        y = previousY;
        x = previousX;
    }

    private void TakeDamage()
    {
        health -= damage;
        ((MyGame)game).ShowHealth(health);
    }

    void Update()
    {
        if (!started)
        {
            ((MyGame)game).ShowHealth(health);
            started = true;
        }
        CharacterMovement();
    }
}

