using System;
using TiledMapParser;
using GXPEngine;

/// <summary>
/// Manages going from one level to another
/// </summary>
internal class LevelManager : GameObject
{
    private Player player;
    private TiledLoader loader;
    private float mapHeight = 0f;
    

    public LevelManager(string filename)
    {
        if (filename != null)
        {
            loader = new TiledLoader(filename);
            loader.OnObjectCreated += ObjectCreateCallback;
            mapHeight = loader.map.Height;
            StartLevel();
        }
    }

    void Update()
    {
        if (player == null) return;
        ResetPlayerAndCamera();
        Scrolling();
        GameStatus();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Button Creation
    //------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Creates button sprite from tiled
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="obj"></param>
    private void ObjectCreateCallback(Sprite sprite, TiledObject obj)
    {
        if (sprite != null)
        {
            Console.WriteLine("Creating {0}", sprite.name);
        }
        if (obj.Type == "Button")
        {
            AddChild(new Button(sprite,obj));   
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Game Level
    //------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Starts the level by creating all the layers
    /// </summary>
    /// <param name="includeImageLayers"></param>
    private void StartLevel(bool includeImageLayers = true)
    {
        loader.addColliders = false;
        loader.rootObject = game;
        loader.LoadImageLayers();

        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        player = FindObjectOfType<Player>();

        //Creating start camera and the blocking wall
        if (player != null)
        {
            SetStartCamera();
            AddChild(new Wall(player, 64 * mapHeight));
        }
        
    }

    /// <summary>
    /// Checks if game is won or lost and plays music according to it
    /// </summary>
    private void GameStatus()
    {
        if (player.GameOver())
        {
            ((MyGame)game).StopMusic();
            ((MyGame)game).LoadLevel("end.tmx");
        }

        if (player.GameWin())
        {
            ((MyGame)game).StopMusic();
            ((MyGame)game).LoadLevel("end.tmx");
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Camera settings
    //------------------------------------------------------------------------------------------------------------------------

    private void Scrolling()
    {
        int boundary = 588;            

        if (player.y + y < boundary)
        {
            y = boundary - player.y + 20;
        }
            
    }

    public void SetStartCamera()
    {
        if (player.y + y > game.height - 128)
        {
            y = -mapHeight * 64;
        }
    }

    private void ResetPlayerAndCamera()
    {
        if (player.isDead)
        {
            SetStartCamera();
            player.x = player.startX;
            player.y = player.startY;
            player.isDead = false;
        }
    }

}

