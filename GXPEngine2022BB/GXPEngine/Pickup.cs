using System;
using TiledMapParser;
using GXPEngine;

//Creates coins that player can pickup

internal class Pickup : AnimationSprite
{
    public Pickup(TiledObject obj = null) : base("coin_sprites.png", 7, 2)
    {
        width = 40;
        height = 40;
    }

    //Let's player to pickup the object
    public void Grab()
    {
        LateDestroy();
        x -= 1000;
    }

    void Update()
    {
        Animate(0.2f);
    }

}

