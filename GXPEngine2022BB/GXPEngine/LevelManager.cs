using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


internal class LevelManager : GameObject
{
    Player player;
    TiledLoader loader;
    string currentLevelName;
    private float mapHeight = 0f;

    public LevelManager(string filename)
    {
        //Console.WriteLine("Creating new level " + filename);
        currentLevelName = filename; //Basic respawning

        loader = new TiledLoader(filename);
        loader.OnObjectCreated += ObjectCreateCallback;
        mapHeight = loader.map.Height;
        CreateLevel();

        //Console.WriteLine("LEVEL " + filename + " loaded.");
    }

    void ObjectCreateCallback(Sprite sprite, TiledObject obj)
    {
        if (sprite != null)
        {
            Console.WriteLine("Creating {0}", sprite.name);
        }
        if (obj.Type == "Button")
        {
            Console.WriteLine("Adding button");
            AddChild(new Button(sprite,obj));   
        }
    }

    private void CreateLevel(bool includeImageLayers = true)
    {
        //Console.WriteLine("Spawning level elements");

        loader.addColliders = false;
        loader.rootObject = game;
        loader.LoadImageLayers();

        loader.rootObject = this; //child of level
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        player = FindObjectOfType<Player>();

        //Setting camera on player
        if (player != null)
        {
            if (player.y + y > game.height - 128)
            {
                y = -576;
            }
            AddChild(new Wall(player, 64 * mapHeight));

            
        }
        
    }

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
            y = -576;
        }
    }

    void Update()
    {
        if (player == null) return;
        if (player.isDead)
        {
            SetStartCamera();
            
            player.x = player.startX;               //resetting start positions to allow player move on few blocks without camre movement
            player.y = player.startY;
            player.isDead = false;
        }
        Scrolling();

        if (player.IsDead())
        {
            Console.WriteLine("END");
            ((MyGame)game).LoadLevel("end.tmx");
        }
    }
}

