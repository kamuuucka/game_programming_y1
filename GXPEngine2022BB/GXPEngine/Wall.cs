using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Wall : Sprite
{ 
    private float previousY = 0;
    private Player playerToFollow;
    private float mapHeight = 0;
    public Wall(Player player, float mapHeight) : base("colors.png")
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
            if (y > playerToFollow.y + 116)
            {
                Move(0, -64f);
            }
            
        }
    }

    public void WallRespawn()
    {
        SetXY(0, mapHeight - 64);
    }

    void Update()
    {
        //TODO: Respawning wall after player's death
       
        FollowPlayer();
        if (playerToFollow.isDead)
        {
            WallRespawn();
        }
    }

    
}
