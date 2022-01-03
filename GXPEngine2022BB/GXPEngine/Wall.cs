using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Wall : Sprite
{
    private Player player;
    private float startX = 0;
    private float startY = 0;
    public Wall(TiledObject obj = null) : base("colors.png")
    {
        collider.isTrigger = true;
        startX = obj.X;
        startY = obj.Y;
        Console.WriteLine("Wall spawned");
    }

    private void FollowPlayer()
    {    
        if (Input.GetKeyUp(Key.W))
        {
            Move(0, -64f);
        }  
    }

    void Update()
    {
        if (player.setDeath())
        {
            x = startX;
            y = startY;
        }
        FollowPlayer();
    }

    
}
