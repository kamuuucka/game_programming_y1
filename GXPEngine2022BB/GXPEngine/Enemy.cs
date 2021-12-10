using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Enemy : Sprite
    {

        private float speed = 2f;
        private new Player player;
        public Enemy(Player player) : base("truck.png")
        {
            SpawnEnemy();
            this.player = player;
        }

        private void SpawnEnemy()
        {
            SetXY(770, 256 - height/2 - 2);
            SetOrigin(width / 2, height / 2);
        }

        public void EnemyMovement()
        {
            Move(-speed, 0);

            if (x < 0 - width)
            {
                x = 780;
            }

            player.getHit(HitTest(player));
            //Console.WriteLine();
            
        }
    }
}
