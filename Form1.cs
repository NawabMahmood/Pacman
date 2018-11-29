using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman_nawab
{
    public partial class Form1 : Form
    {
        PictureBox[] walls;
        PictureBox[] ghosts;
        PictureBox[] coins;
        int seconds = 0;
        int speed = 3;
        string directions;
        int win = 0;
        int point = 0;

        public Form1()
        {
            InitializeComponent();
            walls = new PictureBox[] { w1, w2, w3, w4, w5, w6, w7, w8, w9, w10, w11, w12, w13, w14, w15, w16, w17 };
            ghosts = new PictureBox[] { ghost, ghost2, ghost3, ghost4 };
            coins = new PictureBox[] { c1, c2, c3, c4, c5, c6, c7 };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                directions = "right";

            }

            if (e.KeyCode == Keys.Left)
            {
                directions = "left";

            }
            if (e.KeyCode == Keys.Up)
            {
                directions = "up";

            }
            if (e.KeyCode == Keys.Down)
            {
                directions = "down";

            }
        }


        private void wingame()
        {// for (int x = 0; x < coins.Length; x++) {
         //    if (coins.Visible==false)
         //  {
         //   timer1.Enabled = false;
         //   label1.Visible = true;
         // }

            if (c1.Visible == false && c2.Visible == false && c3.Visible == false && c4.Visible == false && c5.Visible == false && c6.Visible == false && c7.Visible == false)
            {
                timer1.Enabled = false;
                label1.Visible = true;

            }


        } 
        private void Losegame()
        { for (int x = 0; x < ghosts.Length; x++) {
                if (pacman.Bounds.IntersectsWith(ghosts[x].Bounds))
                {
                    timer1.Enabled = false;
                    label2.Visible = true;
                }
        } }

        



        private void collectcoins()
        {
            for (int x = 0; x < coins.Length; x++)
            {
                if (coins[x].Bounds.IntersectsWith(pacman.Bounds))
                {

                    coins[x].Visible = false;


                    point = point + 200;
                    win = win + 1;
                }
               
            }

      
            
            Points.Text = point.ToString();
        
    
    }
        private Boolean checkwalls(PictureBox s)
        {
            for (int x = 0; x < walls.Length; x++) {
                if (s.Bounds.IntersectsWith(walls[x].Bounds))
                {
                    return true;
                }
            } 
         
            return false;
        }
        public void moveGhost()
        {
            for (int x = 0; x < ghosts.Length; x++)
            {
              



                if (seconds > 90)


                {
                    if (x == 0) { speed =1; }
                    if (x == 1) { speed = 2; }
                    if (x == 2) { speed =  3; }
                    if (x == 3) { speed = 4; }
                    if (x == 4) { speed = 5; }

                    w18.Visible = false;
                    if (pacman.Left > ghosts[x].Left)
                    { 
                        ghosts[x].Left = ghosts[x].Left + speed;
                        if (checkwalls(ghosts[x]) == true) { ghosts[x].Left = ghosts[x].Left - speed; }
                    }

                    if (pacman.Left < ghosts[x].Left)
                    {
                        ghosts[x].Left = ghosts[x].Left - speed;
                        if (checkwalls(ghosts[x]) == true) { ghosts[x].Left = ghosts[x].Left + speed; }
                    }
                    if (pacman.Top < ghosts[x].Top)
                    {
                        ghosts[x].Top = ghosts[x].Top - speed;
                        if (checkwalls(ghosts[x]) == true) { ghosts[x].Top = ghosts[x].Top + speed; }
                    }
                    if (pacman.Top > ghosts[x].Top)
                    {
                        ghosts[x].Top = ghosts[x].Top + speed;
                        if (checkwalls(ghosts[x]) == true) { ghosts[x].Top = ghosts[x].Top - speed; }
                    }


                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            moveGhost();
            collectcoins();
            wingame();
            Losegame();
            if (directions == "right")
            {
                pacman.Left = pacman.Left + 9;
                if (checkwalls(pacman) == true) { pacman.Left = pacman.Left - 9; }

               
            }

             if (directions == "left")
                {
                    pacman.Left = pacman.Left - 9;
                    if (checkwalls(pacman) == true) { pacman.Left = pacman.Left + 9; }
                 
                }
            if(directions == "up")
                {
                    pacman.Top = pacman.Top - 9;
                    if (checkwalls(pacman) == true) { pacman.Top = pacman.Top + 9; }
                 
                }
            if(directions == "down")
                {
                    pacman.Top = pacman.Top + 9;
                    if (checkwalls(pacman) == true) { pacman.Top= pacman.Top - 9; }
                 
                }
            }
        }
    }

