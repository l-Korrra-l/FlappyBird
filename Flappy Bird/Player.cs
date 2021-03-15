using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Flappy_Bird
{
    class Player
    {
        public float x;
        public float y;
        public int size;
        public int score;

        public float gravityValue;

        public Image birdImg;
        
        public Player(int x, int y)
        {
            birdImg = new Bitmap(@"C:\Users\User\Documents\c# lessons\Flappy Bird\Flappy Bird\pic\photo_2021-02-14_00-24-55.jpg");  //--------------------------
            this.x = x;
            this.y = y;
            size = 50;
            gravityValue = 0.2f;
            score = 0;
        }
    }
}
