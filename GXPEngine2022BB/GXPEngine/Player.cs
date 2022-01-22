using System;
using TiledMapParser;
using GXPEngine;


internal class Player : AnimationSprite
{
    private int damage = 1;
    private float previousY = 0;
    private float previousX = 0;
    public float startX = 0;
    public float startY = 0;
    private float speed = 64f;
    private bool started;
    private bool logAttached = false;
    public bool isDead = false;
    PlayerData playerData = new PlayerData();
    Sound jump = new Sound("jump.wav");
        
    public Player(TiledObject obj=null) : base("forg_sprites_big.png", 2, 2)
    {
        SpawnPlayer();
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
            jump.Play().Volume = 0.2f;
        }
        else if (Input.GetKeyUp(Key.D))
        {
            previousX = x;
            Move(speed, 0);
            SetCycle(0, 1);
            jump.Play().Volume = 0.2f;
        }
        else if (Input.GetKeyUp(Key.W))
        {
            previousY = y;
            Move(0, -speed);
            SetCycle(2, 1);
            jump.Play().Volume = 0.2f;
        }
        else if (Input.GetKeyUp(Key.S))
        {
            previousY = y;
            Move(0, speed);
            SetCycle(3, 1);
            jump.Play().Volume = 0.2f;
        }
        if (x<0 || x > 768)
        {
            x = previousX;
        }
        Animate();
        CheckCollisions();
        logAttached = false;
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Enemy)
            {
                new Sound("death.wav").Play();
                TakeDamage();
                isDead = true;
                SpawnPlayer();
            }
            if (collisions[i] is Pickup)
            {
                new Sound("point.wav").Play();
                ((Pickup)collisions[i]).Grab();
                playerData.Points++;
            }
            if (collisions[i] is Wall)
            {
                BlockPlayer();    
            }
            if (collisions[i] is Log)
            {
                Move(((Log)collisions[i]).getSpeed(), 0);
                Console.WriteLine("LOG");
                logAttached = true;
            }
            if (collisions[i] is Death && !logAttached)
            {
                new Sound("death_water.wav").Play();
                TakeDamage();
                isDead = true;
                SpawnPlayer();
            }
            if (collisions[i] is SaveSpot)
            {
                //Calculating of frogs position, so it still moves every 64 pixels
                x = (int)(x / 64 + 1) * 64 - 32;
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
    }

    private void TakeDamage()
    {
        playerData.Lives -= damage;
    }

    public bool IsDead()
    {
        if (playerData.Lives == 0)
        {
            new Sound("lose.wav").Play();
            Console.WriteLine("dead");
            return true;
        }
        return false;
    }

    void Update()
    {
        if (!started)
        {
            started = true;
        }
        CharacterMovement();
        ((MyGame)game).ShowHealth(playerData.Lives);
        ((MyGame)game).ShowPoints(playerData.Points);
    }
}

