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
    private float previousY = 0;
    private float previousX = 0;
    private float startX = 0;
    private float startY = 0;
    private float speed = 64f;
    private bool hit;
    private LevelManager levelManager;
        
    public Player(TiledObject obj=null) : base("forg.png")
    {
        SpawnPlayer();
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
            
            Console.WriteLine("PX: " + previousX + "   X: " + this.x);
            previousX = x;
        }
        else if (Input.GetKeyUp(Key.D))
        {
            Move(speed, 0);
            Mirror(false, false);
            Console.WriteLine("PX: " + previousX + "   X: " + this.x);
            previousX = x;
        }
        else if (Input.GetKeyUp(Key.W))
        {
            Move(0, -speed);
            Console.WriteLine("PY: " + previousY + "   Y: " + this.y);
            previousY = y;
        }
        else if (Input.GetKeyUp(Key.S))
        {
            Move(0, speed);
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
                SpawnPlayer();
            }
            if (collisions[i] is Pickup)
            {
                ((Pickup)collisions[i]).Grab();
                Console.WriteLine("Coin stolen.");
            }
            if (collisions[i] is Wall)
            {
                y = previousY;
                //TODO: collision with walls on sides                
            }
        }
    }

    private void SpawnPlayer()
    {
        setDeath();
        x = startX;
        y = startY;
        Console.WriteLine("Player spawned");
    }

    public bool setDeath()
    {
        return true;
    }

    public void getHit(bool isHit)
    {
        hit = isHit;
    }

    void Update()
    {
        CharacterMovement();
    }
}

