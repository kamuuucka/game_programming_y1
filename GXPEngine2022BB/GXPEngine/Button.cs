using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Button : GameObject
{
    private Sprite visualButton;
    private string filename;

    public Button(Sprite visualButton, TiledObject obj)
    {
        this.visualButton = visualButton;
        filename = obj.GetStringProperty("load", "map1");
    }

    void Update()
    { 
        
        if(visualButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            Console.WriteLine("Hovering");
            visualButton.SetColor(1,1,1);
            if (Input.GetMouseButtonDown(0))
            {
                ((MyGame)game).LoadLevel(filename + ".tmx");
            }
        }
        else
        {
            visualButton.SetColor(0.7f, 0.7f, 0.7f);
        }
    }
}

