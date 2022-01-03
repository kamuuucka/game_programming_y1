using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    internal class LevelManager : GameObject
    {
        Player player;
        TiledLoader loader;
        string currentLevelName;

        public LevelManager(string filename)
        {
            Console.WriteLine("Creating new level " + filename);
            currentLevelName = filename; //Basic respawning

            loader = new TiledLoader(filename);

            CreateLevel();
            Console.WriteLine("LEVEL " + filename + " loaded.");
        }

        private void CreateLevel(bool includeImageLayers = true)
        {
            Console.WriteLine("Spawning level elements");

            loader.addColliders = false;
            loader.rootObject = game;
            loader.LoadImageLayers();

            loader.rootObject = this; //child of level
            loader.LoadTileLayers(0);
            loader.LoadTileLayers(1);
            loader.autoInstance = true;
            loader.LoadObjectGroups();

            player = FindObjectOfType<Player>();

            //Setting camera on player
            if (player.y + y > game.height - 128)
            {
                y = -512;
            }
        }

        private void Scrolling()
        {
            int boundary = 716;            

            if (player.y + y < boundary)
            {
                y = boundary - player.y;
            }
            
        }

        public void setStartCamera()
        {
            if (player.y + y > game.height - 128)
            {
                y = -512;
            }
        }

        void Update()
        {
            if (player == null) return;
            if (player.setDeath())
            {
                setStartCamera();
            }
            Scrolling();
        }
    }
}
