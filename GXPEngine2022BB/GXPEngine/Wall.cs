using System;
using GXPEngine;
using TiledMapParser;


internal class Wall : Sprite
{ 
    private float previousY = 0;
    private Player playerToFollow;
    private float mapHeight = 0;
    public Wall(Player player, float mapHeight) : base("wall1.png")
    {
        playerToFollow = player;
        this.mapHeight = mapHeight;
        WallRespawn();
        collider.isTrigger = true;
        
        
        Console.WriteLine("Wall spawned: " + x + "," + y);
    }

    private void FollowPlayer()
    {
        previousY = y;
        if (Input.GetKeyUp(Key.S))
        {
            if (playerToFollow.y > previousY)
            {
                HitTest(playerToFollow);
                Console.WriteLine("STOP");
            }
        }
        if (Input.GetKeyUp(Key.W))
        {
            //+ 116 if you want to make the wall higher and visible
            if (y > playerToFollow.y + 180)
            {
                Move(0, -64f);
            }
            
        }
    }

    public void WallRespawn()
    {
        //SetXY(0, mapHeight - 64);
        SetXY(0, mapHeight);
    }

    void Update()
    {       
        FollowPlayer();
        if (playerToFollow.isDead)
        {
            WallRespawn();
        }
    }

    
}
