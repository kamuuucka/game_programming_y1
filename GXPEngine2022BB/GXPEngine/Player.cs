using System;
using TiledMapParser;
using GXPEngine;

/// <summary>
/// PLayer. Contains everything important for the player.
/// </summary>
internal class Player : AnimationSprite
{
    private int damage = 1;
    private float previousY = 0;
    private float previousX = 0;
    public float startX = 0;
    public float startY = 0;
    private float speed = 64f;
    private bool logAttached = false;
    public bool isDead = false;
    private bool isFinished = false;
    private PlayerData playerData = new PlayerData();
    private Sound jump = new Sound("jump.wav");
        
    public Player(TiledObject obj=null) : base("forg_sprites_big.png", 2, 2)
    {
        if (obj != null)
        {
            startX = obj.X + 20;
            startY = obj.Y + 20;
            previousX = startX;
            previousY = startY;
            Console.WriteLine("Player spawned: " + startX + ", " + startY);
        }
        SpawnPlayer();
    }

    /// <summary>
    /// Player can move with the help of WASD keys.
    /// Handles the animation, side blocking and collision.
    /// Detaches player from the logs
    /// </summary>
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

        Animate();
        CheckCollisions();
        OutOfScreen();
        logAttached = false;
    }

    /// <summary>
    /// Prevents player from jumping out of screen on the sides.
    /// Checks if player got out of the screen with help of the log.
    /// </summary>
    /// <returns>
    /// 1 if player is out of the screen
    /// 0 if player is still on the screen
    /// </returns>
    private bool OutOfScreen()
    {
        if (x < 0 || x > 768)
        {
            x = previousX;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Checks player's collisions with different objects
    /// </summary>
    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is MovingEnemy)
            {
                new Sound("death.wav").Play();
                PlayerDeath();
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
            if (collisions[i] is MovingLog)
            {
                Move(((Log)collisions[i]).getSpeed(), 0);
                logAttached = true;
            }
            if (collisions[i] is Death && !logAttached)
            {
                new Sound("death_water.wav").Play();
                PlayerDeath();
            }
            if (collisions[i] is SaveSpot)
            {
                if (((SaveSpot)collisions[i]).GetIsEnd())
                {
                    isFinished = true;
                }
                //Calculating the frog's position, so it still moves every 64 pixels
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

    /// <summary>
    /// Removes one live from the player and respawns him.
    /// Marks player as dead one. It is used in Wall.Update()
    /// </summary>
    private void PlayerDeath()
    {
        TakeDamage();
        isDead = true;
        SpawnPlayer();
    }

    private void LogDeath()
    {
        if (logAttached && OutOfScreen())
        {
            PlayerDeath();
        }
    }

    public bool GameOver()
    {
        if (playerData.Lives == 0)
        {
            new Sound("lose.wav").Play();
            return true;
        }
        return false;
    }

    public bool GameWin()
    {
        if (isFinished)
        {
            new Sound("win_1.wav").Play();
            return true;
        }
        return false;
    }

    void Update()
    {
        CharacterMovement();
        LogDeath();
        ((MyGame)game).ShowHealth(playerData.Lives);
        ((MyGame)game).ShowPoints(playerData.Points);
    }
}

