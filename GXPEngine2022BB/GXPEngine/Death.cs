﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Death : Sprite
{
    public Death (TiledObject obj = null) : base("wall.png")
    {
        collider.isTrigger = true;
        Console.WriteLine("Water is deadly");
        //TODO: Death needs to somehow not react if player is also touching logs.
    }
}

