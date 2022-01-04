using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Wall : Sprite
{ 
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
            Console.WriteLine(this.x);
        }  
    }

    public void WallRespawn()
    {
        this.x = startX;
        this.y = startY;
    }

    void Update()
    {
        //TODO: Respawning wall after player's death
       
        FollowPlayer();
    }

    
}
