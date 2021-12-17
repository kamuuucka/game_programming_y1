using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Player : Sprite
    {
        private int screen_width;
        private int screen_height; 
        private float speed = 64f;
        private bool hit;
        //public Player(int screen_width, int screen_height) : base("forg.png")
        //{
        //    this.screen_height = screen_height;
        //    this.screen_width = screen_width;
        //    SpawnPlayer();
        //}
        public Player() : base("forg.png")
        {
            SpawnPlayer();
        }

        public void CharacterMovement()
        {

            if (Input.GetKeyUp(Key.A))
            {
                Move(-speed, 0);
                Mirror(true, false);
                Console.Write("A key pressed");
            }
            else if (Input.GetKeyUp(Key.D))
            {
                Move(speed, 0);
                Mirror(false, false);
            }
            else if (Input.GetKeyUp(Key.W))
            {
                Move(0, -speed);
            }
            else if (Input.GetKeyUp(Key.S))
            {
                Move(0, speed);
            }

            if (hit)
            {
                Console.WriteLine("Ran over by truck :(");
                SpawnPlayer();
                hit = false;
            }

        }

        private void SpawnPlayer()
        {
            SetOrigin(width/2, height/2);
            Console.WriteLine("Player spawned");
        }

        public void getHit(bool isHit)
        {
            hit = isHit;
        }

        void Update()
        {
            CharacterMovement();
        }
    }
}
