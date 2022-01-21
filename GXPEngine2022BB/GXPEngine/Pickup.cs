using System;
using TiledMapParser;
using GXPEngine;

//Creates coins that player can pickup

    internal class Pickup : Sprite
    {
        public Pickup(TiledObject obj = null) : base("circle.png")
        {

        }

    //Let's player to pickup the object
        public void Grab()
        {
            LateDestroy();
            x -= 1000;
        }

    }

