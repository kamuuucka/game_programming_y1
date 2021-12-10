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
        public Player(int screen_width, int screen_height) : base("forg.png")
        {
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            SpawnPlayer();
        }

        public void CharacterMovement()
        {
            bool isMoving = false; //Can be used to create idle and moving animation

            if (Input.GetKeyUp(Key.A))
            {
                Move(-speed, 0);
                Mirror(true, false);
                isMoving = true;
            }
            else if (Input.GetKeyUp(Key.D))
            {
                Move(speed, 0);
                Mirror(false, false);
                isMoving = true;
            }
            else if (Input.GetKeyUp(Key.W))
            {
                Move(0, -speed);
            }
            else if (Input.GetKeyUp(Key.S))
            {
                Move(0, speed);
            }
            else
            {
                isMoving = false;
            }

        }

        private void SpawnPlayer()
        {
            SetXY(screen_width / 2 + 32, screen_height - 26);
            SetOrigin(width/2, height/2);
            Console.WriteLine(screen_width + " : " + screen_height);
        }
    }
}
