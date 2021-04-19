using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Flappy_Bird
{
    class Tubes
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public Image tubeImg;

        public Tubes(int x, int y, bool isRotated=false)
        {
            tubeImg = new Bitmap(@"C:\Users\User\Documents\c# lessons\Flappy Bird\FlappyBird\Flappy Bird\pic\1391616.png");  //--------------------------
            this.x = x;
            this.y = y;
            sizeX = 50;
            sizeY = 250;
            if (isRotated) tubeImg.RotateFlip(RotateFlipType.Rotate180FlipX);
        }
    }
}
