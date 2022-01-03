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
    private float speed = 64f;
    private bool hit;
        
    public Player(TiledObject obj=null) : base("forg.png")
    {
        SpawnPlayer();
    }

    private void CharacterMovement()
    {

        if (Input.GetKeyUp(Key.A))
        {
            Move(-speed, 0);
            Mirror(true, false);

        }
        else if (Input.GetKeyUp(Key.D))
        {
            Move(speed, 0);
            Mirror(false, false);
        }
        else if (Input.GetKeyUp(Key.W))
        {
            Move(0, -speed);
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
            }
        }
    }

    private void SpawnPlayer()
    {
        SetOrigin(width/2, height/2);
        Console.WriteLine("Player spawned");
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

