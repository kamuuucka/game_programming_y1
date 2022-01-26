using GXPEngine;
using TiledMapParser;

/// <summary>
/// Creates button used on menu and end screens
/// </summary>

internal class Button : GameObject
{
    private Sprite visualButton;
    private string filename;
    private bool isFinished;

    public Button(Sprite visualButton, TiledObject obj)
    {
        this.visualButton = visualButton;
        filename = obj.GetStringProperty("load", "map_final");
        isFinished = obj.GetBoolProperty("isFinished", false);
    }

    /// <summary>
    /// Checks if mouse is hovering above the button
    /// </summary>
    /// <returns>
    /// 1 if it is
    /// 0 if it is not
    /// </returns>
    private bool CheckHovering()
    {
        if (visualButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            return true;
        }
        else return false;
    }

    /// <summary>
    /// If mouse is hovering above the button it changes color.
    /// After click button starts the level.
    /// If button is marked as the one finishing game it destroys the game object and closes the application.
    /// </summary>
    private void SelectButton()
    {
        if (CheckHovering())
        {
            visualButton.SetColor(1, 1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                ((MyGame)game).StopMusic();
                if (!isFinished)
                {
                    ((MyGame)game).LoadLevel(filename + ".tmx");
                }
                else
                {
                    ((MyGame)game).Destroy();
                }
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

