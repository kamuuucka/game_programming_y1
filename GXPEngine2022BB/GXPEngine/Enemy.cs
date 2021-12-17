using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Enemy : Sprite
    {
        private int eX;
        private int eY;
        private float speed = 2f;
        private new Player player;
        public Enemy(Player player, int eX, int eY) : base("truck.png")
        {
            this.player = player;
            this.eX = eX;
            this.eY = eY;
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            //eX = 770
            //ey = 256
            SetXY(eX, eY - height/2 - 2);
            SetOrigin(width / 2, height / 2);
        }

        public void EnemyMovement()
        {
            Move(-speed, 0);

            if (x < 0 - width)
            {
                x = eX;
                Console.WriteLine("Respawning at " + eX);
            }

            RunOverPlayer();
            
        }

        private void RunOverPlayer()
        {
            if (HitTest(player))
            {
                player.getHit(true);
            }
        }
    }
}
