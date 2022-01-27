using System;
using GXPEngine;
using TiledMapParser;

/// <summary>
/// Creates the area that kills the player
/// </summary>
internal class Death : Sprite
{
    public Death (TiledObject obj = null) : base("wall1.png")
    {
        collider.isTrigger = true;
    }
}