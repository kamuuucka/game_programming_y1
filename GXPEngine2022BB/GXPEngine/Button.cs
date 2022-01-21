using System;
using GXPEngine;
using TiledMapParser;

//Button used in main menu

internal class Button : GameObject
{
    private Sprite visualButton;
    private string filename;

    //Button takes it's properties (like sprite and level to load) from tiles
    public Button(Sprite visualButton, TiledObject obj)
    {
        this.visualButton = visualButton;
        filename = obj.GetStringProperty("load", "map1");
    }

    //Checks if mouse is over the button
    private bool CheckHovering()
    {
        if (visualButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            return true;
        }
        else return false;
    }

    //If mouse is over the button, it changes color to mark that it's selected. After left click, the button starts the level.
    private void SelectButton()
    {
        if (CheckHovering())
        {
            visualButton.SetColor(1, 1, 1);
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

    void Update()
    {
        SelectButton();
    }
}

