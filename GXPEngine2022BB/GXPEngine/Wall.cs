using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Wall : Sprite
{
    public Wall(TiledObject obj = null) : base("wall.png")
    {
        this.width = 64;
        this.height = 64;
        SetOrigin(this.width / 2, this.height / 2);
        collider.isTrigger = true;
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
        FollowPlayer();
    }

    
}
