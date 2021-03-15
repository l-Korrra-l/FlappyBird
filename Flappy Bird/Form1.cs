using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        Player bird;
        Tubes tube;
        Tubes topTube;
        Tubes tube1;
        Tubes topTube1;
        Tubes tube2;
        Tubes topTube2;
        float gravity;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 5;
            timer1.Tick += new EventHandler(update);
            Init();
            Invalidate();
        }


        public void Init()
        {
            bird = new Player(350,250);
            tube = new Tubes(750,350);
            topTube = new Tubes(750, -50, true);
            tube1 = new Tubes(1050, 250);
            topTube1 = new Tubes(1050, -150, true);
            tube2 = new Tubes(1350, 400);
            topTube2 = new Tubes(1350, 0, true);

            gravity = 0;
            textBox1.Text="Score:0";
            bird.score = 0;
        }

        bool start = false;
        private void Start()
        {
            bird.score = 0;
            start = true;
            timer1.Start();
        }

        private void update(object sender, EventArgs e)
        {
            if (Collide(tube, topTube) || Collide(tube1, topTube1) || Collide(tube2, topTube2)) endGame();
            if (bird.gravityValue <= 0f)
                bird.gravityValue += 0.2f;
            if ((bird.gravityValue <= 0.2f) && (bird.gravityValue>0))
                bird.gravityValue += 0.45f;
            Score(tube);
            Score(tube1);
            Score(tube2);
            gravity += bird.gravityValue;
            bird.y += gravity; 
            Invalidate();
            MoveTubes();
            CreateTube();

        }

        private void Score(Tubes tube)
        {
            if (((bird.x>=tube.x+tube.sizeX)&&(bird.x <= tube.x + tube.sizeX+2)))
            bird.score += 1;
            textBox1.Text = "Score:" + bird.score.ToString();
        }
        private void MoveTubes()
        {
            tube.x -= 3;
            topTube.x -= 3; 
            tube1.x -= 3;
            topTube1.x -= 3;
            tube2.x -= 3;
            topTube2.x -= 3;
        }

        private int buf;
        private int buf2;
        private void CreateTube()
        {
            Random rand = new Random();
            buf = rand.Next(-205,-40);
            buf2 = rand.Next(150,200);
            if (tube.x < -50 )
            {
                tube = new Tubes(850, buf+250+buf2);
                topTube = new Tubes(850, buf, true);
            }
            if (tube1.x < -50)
            {
                tube1 = new Tubes(850, buf + 250 + buf2);
                topTube1 = new Tubes(850, buf, true);
            }
            if (tube2.x < -50)
            {
                tube2 = new Tubes(850, buf + 250 + buf2);
                topTube2 = new Tubes(850, buf, true);
            }
        }

        private bool Collide(Tubes tube, Tubes tube1)
        {
            PointF delta = new PointF(); 
            delta.X = bird.x - tube.x;
            delta.Y = bird.y - tube.y;
            if ((Math.Abs(delta.X) <= bird.size)&&((tube.sizeY+tube1.y>=bird.size+bird.y)||(bird.y>=tube.y)))
            {
                    return true;
            }
            else if (bird.y<0 || bird.x>=500-bird.size) return true;
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);
            graphics.DrawImage(tube.tubeImg, tube.x, tube.y, tube.sizeX, tube.sizeY);
            graphics.DrawImage(topTube.tubeImg, topTube.x, topTube.y, topTube.sizeX, topTube.sizeY);
            graphics.DrawImage(tube1.tubeImg, tube1.x, tube1.y, tube1.sizeX, tube1.sizeY);
            graphics.DrawImage(topTube1.tubeImg, topTube1.x, topTube1.y, topTube1.sizeX, topTube1.sizeY);
            graphics.DrawImage(tube2.tubeImg, tube2.x, tube2.y, tube2.sizeX, tube2.sizeY);
            graphics.DrawImage(topTube2.tubeImg, topTube2.x, topTube2.y, topTube2.sizeX, topTube2.sizeY);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void gameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!start) Start();
            if (e.KeyChar == (char)Keys.Enter)
            {
                Init();
                timer1.Start();
            }
            gravity = 0;
            bird.gravityValue = -1.5f;
        }

        public void endGame()
        {
            timer1.Stop();
            bird.x = 350;
            bird.gravityValue = -1.5f;
            tube.x = 750;
            topTube.x = 750;
            tube1.x = 1050;
            topTube1.x = 1050;
            tube2.x = 1350;
            topTube2.x = 1350;
            gravity = 0;
            start = !start;
        }
    }
}
