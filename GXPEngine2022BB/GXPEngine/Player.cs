using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


internal class Player : Sprite
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
        
    public Player(TiledObject obj=null) : base("forg.png")
    {
        SpawnPlayer();
        health = maxHealth;
        ((MyGame)game).ShowHealth(health);
        if (obj != null)
        {
            startX = obj.X + 20;
            previousX = startX;
            Console.WriteLine(previousX);
            startY = obj.Y + 20;
            previousY = startY;
            Console.WriteLine(previousY);
        }
        
    }


    private void CharacterMovement()
    {

        if (Input.GetKeyUp(Key.A))
        {
            Move(-speed, 0);
            Mirror(true, false);
            
            //Console.WriteLine("PX: " + previousX + "   X: " + this.x);
            previousX = x;
        }
        else if (Input.GetKeyUp(Key.D))
        {
            Move(speed, 0);
            Mirror(false, false);
            //Console.WriteLine("PX: " + previousX + "   X: " + this.x);
            previousX = x;
        }
        else if (Input.GetKeyUp(Key.W))
        {
            Move(0, -speed);
            //Console.WriteLine("PY: " + previousY + "   Y: " + this.y);
            previousY = y;
        }
        else if (Input.GetKeyUp(Key.S))
        {
            Move(0, speed);
            //Console.WriteLine("PY: " + previousY + "   Y: " + this.y);
            previousY = y;
        }

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
                //Console.WriteLine("Coin stolen.");
            }
            if (collisions[i] is Wall)
            {
                BlockPlayer();
                Console.WriteLine("COLLISION");
                //TODO: collision with walls on sides                
            }
        }
    }


    private void SpawnPlayer()
    {
        x = startX;
        y = startY;
        //isDead = false;
       // Console.WriteLine("Player spawned");
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

