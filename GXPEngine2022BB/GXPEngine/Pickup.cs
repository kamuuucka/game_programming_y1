using System;
using TiledMapParser;
using GXPEngine;

/// <summary>
/// Coins. Manages the objects that can be picked up by the player.
/// </summary>

internal class Pickup : AnimationSprite
{
    public Pickup(TiledObject obj = null) : base("coin_sprites.png", 7, 2)
    {
        if(obj != null)
        {
            width = 40;
            height = 40;
        }
    }

    public void Grab()
    {
        LateDestroy();
    }

    void Update()
    {
        Animate(0.2f);
    }

}

