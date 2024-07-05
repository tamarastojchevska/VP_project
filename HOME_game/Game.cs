using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using Image = System.Drawing.Image;

namespace HOME_game
{
    public partial class Game : Form
    {
        enum Direction { None, Left, Right, Up, Down }
        Direction currentDir;

        int steps = 0;

        int end_left = 0;
        int end_up = 0;
        int end_right = 4100;
        int end_down = 4100;

        int imgSpeed = 20;
        int slowDownFrameRate = 0;

        int bestScore;

        PictureBox pbHome;
        List<PictureBox> pbFish = new List<PictureBox>();
        List<PictureBox> pbHouses = new List<PictureBox>();
        List<PictureBox> pbLakes = new List<PictureBox>();
        List<PictureBox> pbTrees = new List<PictureBox>();
        List<PictureBox> pbHousesDogs = new List<PictureBox>();
        List<PictureBox> pbHousesRight = new List<PictureBox>();
        List<PictureBox> pbHousesDiagonal = new List<PictureBox>();
        PictureBox pbHouseMiddle;
        PictureBox pbHouseDown;

        List<String> playerMovements = new List<String>();

        Random random;

        bool isHit = false;
        bool left = true;
        bool right = true;
        bool up = true;
        bool down = true;

        bool lake = false;
        bool house = false;
        bool house_right = false;
        bool house_diag = false;
        bool house_middle = false;
        bool house_down = false;
        bool dog = false;

        int health;
        int score;

        SoundPlayer bgMusic;
        public Game()
        {            
            InitializeComponent();

            bgMusic = new SoundPlayer(@"Resources\music\bg_music.wav");
            bgMusic.PlayLooping();

            random = new Random();

            Home();
            HouseLocations();

            playerMovements = Directory.GetFiles(@"Resources\player", "*.png").ToList();
            pbPlayer.Image = Image.FromFile(playerMovements[9]);
            pbPlayer.Location = new Point((this.Width/2) - 25, (this.Height/2) - 25);

            Houses();
            HousesDogs();
            Trees();
            Lakes();
            Fish();

            health = 150;
            pbHealth.Value = 150;
            score = 0;

            BestScore();

            pbPlayer.SendToBack();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left: currentDir = Direction.Left; break;
                case Keys.Right: currentDir = Direction.Right; break;
                case Keys.Up: currentDir = Direction.Up; break;
                case Keys.Down: currentDir = Direction.Down; break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left: if (currentDir == Direction.Left) currentDir = Direction.None; break;
                case Keys.Right: if (currentDir == Direction.Right) currentDir = Direction.None; break;
                case Keys.Up: if (currentDir == Direction.Up) currentDir = Direction.None; break;
                case Keys.Down: if (currentDir == Direction.Down) currentDir = Direction.None; break;
            }

            Messages();

            if (pbPlayer.Bounds.IntersectsWith(pbHome.Bounds))
            {
                gameOver();
            }
            
            isHit = false;
            lake = false;
            house = false;
            dog = false;
            house_right = false;
            house_diag = false;
            house_middle = false;
            house_down = false;
        }

        //---------------------MESSAGES---------------------------
        private void Messages()
        {
            if (isHit && lake)
            {
                MyMessage message = new MyMessage("water_drop.png", "You fell in a lake!");
                message.ShowDialog();
                health -= 5;
                score -= 5;
            }
            if (isHit && house)
            {
                MyMessage message = new MyMessage("cat_food.png", "Here have some food!");
                message.ShowDialog();
                health += 5;
                score += 5;
            }
            if(isHit && dog)
            {
                MyMessage message = new MyMessage("dog.png", "BEWARE OF DOG !!!");
                message.ShowDialog();
                health -= 5;
                score -= 5;
            }
            if(isHit && house_right)
            {
                MyMessage message = new MyMessage("arrow_right.png", "Oh the big house? Hmm.. I think it was somewhere to the right..");
                message.ShowDialog();
            }
            if (isHit && house_diag)
            {
                MyMessage message = new MyMessage("arrow_down.png", "I think it was somewhere down there? Maybe a bit to the right? Im not sure...");
                message.ShowDialog();
            }
            if (isHit && house_middle)
            {
                MyMessage message = new MyMessage("arrow_right.png", "Go right and you'll find your way~");
                message.ShowDialog();
            }
            if (isHit && house_down)
            {
                MyMessage message = new MyMessage("arrow_down.png", "It's right down the hill. Be careful along the way!");
                message.ShowDialog();
            }
        }
        //--------------------GAME-OVER--------------------------
        private void gameOver()
        {
            bgMusic.Stop();
            timerHealth.Stop();
            string str = String.Format("{0}\n", score);
            File.AppendAllText(@"resources\Scores.txt", str);

            //this.Hide();
            GameOver gameOver = new GameOver();
            gameOver.ShowDialog();
            if (gameOver.DialogResult == DialogResult.Cancel)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        //--------------------BEST-SCORE--------------------
        private void BestScore()
        {
            int maxScore = 0;
            List<string> Scores = File.ReadAllLines(@"Resources\Scores.txt").ToList();

            if(Scores.Count() == 0)
            {
                lblBestScore.Text = "Best Score: 0";
            }
            else
            {
                for(int i=0; i<Scores.Count; i++)
                {
                    int s = int.Parse(Scores[i]);
                    if (s > maxScore)
                    {
                        maxScore = s;
                    }
                }
                lblBestScore.Text = "Best Score: " + maxScore.ToString();
                bestScore = maxScore;
            }
        }
        //------------------CURRENT-SCORE--------------------
        private void CurrentScore()
        {
            if(score < 0)
            {
                lblCurrentScore.Text = "Current score: 0";
            }
            else
            {
                lblCurrentScore.Text = "Current score: " + score.ToString();
            }
            
        }
        //------------------TIMER-MOVE-----------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            switch (currentDir)
            {
               case Direction.Left:
                    if (pbPlayer.Location.X >= end_left)
                    {
                        HitLeft();
                        if (left)
                        {
                           moveLeft();
                           eatFish();
                        }
                        
                    }
               break;
               case Direction.Right:
                    if (pbPlayer.Location.X + pbPlayer.Width <= end_right)
                    {
                        HitRight();                            
                        if (right)
                        {
                           moveRight();
                           eatFish();
                        }
                    }
                    break;
               case Direction.Up:
                    if (pbPlayer.Location.Y >= end_up)
                    {
                        HitUp();
                        if (up)
                        {
                           moveUp();
                           eatFish();
                        }
                    }
                    break;
               case Direction.Down:
                    if (pbPlayer.Location.Y + pbPlayer.Height <= end_down)
                    {
                        HitDown();
                        if (down)
                        {
                            moveDown();
                            eatFish();
                        }
                    }
                    break;
           }
            
            left = true;
            right = true;
            up = true;
            down = true;
        }

        //-----------------ADD-HOME------------------------
        private void Home()
        {
            pbHome = new PictureBox();
            pbHome.Image = Image.FromFile(@"Resources\house_home.png");
            pbHome.Location = new Point(random.Next(3500, 4000), random.Next(3500, 4000));
            pbHome.Width = pbHome.Image.Width;
            pbHome.Height = pbHome.Image.Height;
            this.Controls.Add(pbHome);
        }

        //-------------------ADD-FISH-------------------------
        private void Fish()
        {
            for(int i=0; i<200; i++)
            {
                addFish(random.Next(0, 4000), random.Next(0, 4000));
            }
            if (!overlap(pbFish[0]))
            {
                pbFish.RemoveAt(0);
            }
        }
        private void addFish(int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(@"Resources\fish.png");
            pb.Location = new Point(x, y);
            pb.Width = 56;
            pb.Height = 36;

            if (pbFish.Count == 0)
            {
                pbFish.Add(pb);
                this.Controls.Add(pb);
            }
            if (overlap(pb) && pbFish.Count>0)
            {
                pbFish.Add(pb);
                this.Controls.Add(pb);
            }
        }

        //------------REMOVE-FISH---------------------  
        private void eatFish()
        {
            for(int i=0; i<pbFish.Count; i++)
            {
                if(pbPlayer.Bounds.IntersectsWith(pbFish[i].Bounds))
                {
                    pbFish[i].Hide();
                    pbFish.RemoveAt(i);
                    health += 5;
                    score += 5;
                }
            }
        }

        //--------------------ADD-HOUSES------------------------
        private void HouseLocations()
        {
            //right
            AddHouseRight(random.Next(500, 1000), random.Next(800, 1400));
            AddHouseRight(random.Next(1000, 1500), random.Next(1400, 2000));

            //diagonal_down
            AddHouseDiagonal(random.Next(1500, 2000), random.Next(500, 800));
            AddHouseDiagonal(random.Next(2000, 2500), random.Next(800, 1000));

            //middle
            pbHouseMiddle = new PictureBox();
            pbHouseMiddle.Image = Image.FromFile(@"Resources\house_3.png");
            pbHouseMiddle.Location = new Point(random.Next(3000, 3500), random.Next(3000, 3500));
            pbHouseMiddle.Width = pbHouseMiddle.Image.Width;
            pbHouseMiddle.Height = pbHouseMiddle.Image.Height;
            this.Controls.Add(pbHouseMiddle);

            //down
            pbHouseDown = new PictureBox();
            pbHouseDown.Image = Image.FromFile(@"Resources\house_3.png");
            pbHouseDown.Location = new Point(random.Next(2500, 3000), random.Next(2500, 3000));
            pbHouseDown.Width = pbHouseDown.Image.Width;
            pbHouseDown.Height = pbHouseDown.Image.Height;
            this.Controls.Add(pbHouseDown);
        }
        private void AddHouseRight(int x, int y)
        {
            PictureBox pbHouseRight = new PictureBox();
            pbHouseRight.Image = Image.FromFile(@"Resources\house_1.png");
            pbHouseRight.Location = new Point(x, y);
            pbHouseRight.Width = pbHouseRight.Image.Width;
            pbHouseRight.Height = pbHouseRight.Image.Height;
            this.Controls.Add(pbHouseRight);
            pbHousesRight.Add(pbHouseRight);
        }
        private void AddHouseDiagonal(int x, int y)
        {
            PictureBox pbHouseDiagonal = new PictureBox();
            pbHouseDiagonal.Image = Image.FromFile(@"Resources\house_2.png");
            pbHouseDiagonal.Location = new Point(x, y);
            pbHouseDiagonal.Width = pbHouseDiagonal.Image.Width;
            pbHouseDiagonal.Height = pbHouseDiagonal.Image.Height;
            this.Controls.Add(pbHouseDiagonal);
            pbHousesDiagonal.Add(pbHouseDiagonal);
        }
        private void HousesDogs()
        {
            for (int i = 0; i < 10; i++)
            {
                addHouseDogs(random.Next(0, 4000), random.Next(0, 4000), "house_1.png");
                addHouseDogs(random.Next(0, 4000), random.Next(0, 4000), "house_2.png");
                addHouseDogs(random.Next(0, 4000), random.Next(0, 4000), "house_3.png");
            }
            if (!overlap(pbHousesDogs[0]))
            {
                pbHousesDogs.RemoveAt(0);
            }
        }
        private void addHouseDogs(int x, int y, String type)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(@"Resources\" + type);
            pb.Location = new Point(x, y);
            pb.Width = pb.Image.Width;
            pb.Height = pb.Image.Height;

            if (pbHousesDogs.Count == 0)
            {
                pbHousesDogs.Add(pb);
                this.Controls.Add(pb);
            }
            if (overlap(pb) && pbHousesDogs.Count > 0)
            {
                pbHousesDogs.Add(pb);
                this.Controls.Add(pb);
            }
        }
        private void Houses()
        {
            //food
            for (int i=0; i<10; i++)
            {
                addHouse(random.Next(0, 4000), random.Next(0, 4000), "house_1.png");
            }
            for (int i = 0; i < 10; i++)
            {
                addHouse(random.Next(0, 4000), random.Next(0, 4000), "house_2.png");
            }
            for (int i = 0; i < 10; i++)
            {
                addHouse(random.Next(0, 4000), random.Next(0, 4000), "house_3.png");
            }
            if (!overlap(pbHouses[0]))
            {
                pbHouses.RemoveAt(0);
            }
        }
        private void addHouse(int x, int y, String type)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(@"Resources\"+type);
            pb.Location = new Point(x, y);
            pb.Width = pb.Image.Width;
            pb.Height = pb.Image.Height;

            if (pbHouses.Count == 0)
            {
                pbHouses.Add(pb);
                this.Controls.Add(pb);
            }
            if (overlap(pb) && pbHouses.Count>0)
            {
                pbHouses.Add(pb);
                this.Controls.Add(pb);
            }
        }

        //--------------------ADD-TREES------------------
        private void Trees()
        {
            for (int i = 0; i < 250; i++)
            {
                addTree(random.Next(0, 4000), random.Next(0, 4000));
            }
            if (!overlap(pbTrees[0]))
            {
                pbTrees.RemoveAt(0);
            }
        }
        private void addTree(int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(@"Resources\tree.png");
            pb.Location = new Point(x, y);
            pb.Width = 90;
            pb.Height = 123;

            if (pbTrees.Count == 0)
            {
                pbTrees.Add(pb);
                this.Controls.Add(pb);
            }
            if (overlap(pb) && pbTrees.Count>0)
            {
                pbTrees.Add(pb);
                this.Controls.Add(pb);
            }
        }

        //--------------------ADD-LAKES---------------------------
        private void Lakes()
        {
            for (int i = 0; i < 5; i++)
            {
                addLake(random.Next(0, 4000), random.Next(0, 4000), "lake_1.png");
            }
            for (int i = 0; i < 5; i++)
            {
                addLake(random.Next(0, 4000), random.Next(0, 4000), "lake_2.png");
            }
            for (int i = 0; i < 5; i++)
            {
                addLake(random.Next(0, 4000), random.Next(0, 4000), "lake_3.png");
            }
            for (int i = 0; i < 5; i++)
            {
                addLake(random.Next(0, 4000), random.Next(0, 4000), "lake_4.png");
            }
            for (int i = 0; i < 5; i++)
            {
                addLake(random.Next(0, 4000), random.Next(0, 4000), "lake_5.png");
            }
            if (!overlap(pbLakes[0]))
            {
                pbLakes.RemoveAt(0);
            }
        }
        private void addLake(int x, int y, String type)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(@"Resources\"+type);
            pb.Location = new Point(x, y);
            pb.Width = pb.Image.Width;
            pb.Height = pb.Image.Height;

            if (pbLakes.Count == 0)
            {
                pbLakes.Add(pb);
                this.Controls.Add(pb);
            }
            if (overlap(pb) && pbLakes.Count>0)
            {
                pbLakes.Add(pb);
                this.Controls.Add(pb);
            }
        }

        //--------------------OVERLAP---------------------
        private bool overlap(PictureBox pb)
        {
            if (IsTouching(pbPlayer, pb))
            {
                return false;
            }
            if (IsTouching(pbHome, pb))
            {
                return false;
            }
            if (IsTouching(pbHouseMiddle, pb))
            {
                return false;
            }
            if (IsTouching(pbHouseDown, pb))
            {
                return false;
            }
            foreach (PictureBox right in pbHousesRight)
            {
                if (IsTouching(right, pb))
                {
                    return false;
                }
            }
            foreach (PictureBox diag in pbHousesDiagonal)
            {
                if (IsTouching(diag, pb))
                {
                    return false;
                }
            }
            foreach (PictureBox fish in pbFish)
            {
                if(IsTouching(fish, pb))
                {
                    return false;
                }
            }
            foreach(PictureBox house in pbHouses)
            {
                if (IsTouching(house, pb))
                {
                    return false;
                }
            }
            foreach(PictureBox tree in pbTrees)
            {
                if (IsTouching(tree, pb))
                {
                    return false;
                }
            }
            foreach (PictureBox lake in pbLakes)
            {
                if (IsTouching(lake, pb))
                {
                    return false;
                }
            }
            foreach (PictureBox dog in pbHousesDogs)
            {
                if (IsTouching(dog, pb))
                {
                    return false;
                }
            }
            return true;
        }

        //---------------------TOUCH----------------------
        private bool IsTouching(PictureBox p1, PictureBox p2)
        {
            if (p1.Location.X + p1.Width <= p2.Location.X)
                return false;
            if (p2.Location.X + p2.Width <= p1.Location.X)
                return false;
            if (p1.Location.Y + p1.Height <= p2.Location.Y)
                return false;
            if (p2.Location.Y + p2.Height <= p1.Location.Y)
                return false;
            return true;
        }

        //---------------------IS-HIT------------------------------
        private bool IsHitRight(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.X + pb1.Width >= pb2.Location.X - 40 && pb1.Location.X + pb1.Width <= pb2.Location.X + pb2.Width && pb1.Location.Y <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y + pb1.Height >= pb2.Location.Y - 50 && pb1.Location.Y + pb1.Height <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y >= pb2.Location.Y - 50;
        }
        private bool IsHitLeft(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.X <= pb2.Location.X + pb2.Width + 40 && pb1.Location.X >= pb2.Location.X && pb1.Location.Y <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y + pb1.Height >= pb2.Location.Y - 50 && pb1.Location.Y + pb1.Height <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y >= pb2.Location.Y - 50;
        }
            private bool IsHitUp(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.Y <= pb2.Location.Y + pb2.Height + 40 && pb1.Location.Y >= pb2.Location.Y && pb1.Location.X >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width <= pb2.Location.X + pb2.Width + 50 && pb1.Location.X <= pb2.Location.X + pb2.Width + 50;
        }
        private bool IsHitDown(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.Y + pb1.Height >= pb2.Location.Y - 40 && pb1.Location.Y + pb1.Height <= pb2.Location.Y + pb2.Height && pb1.Location.X >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width <= pb2.Location.X + pb2.Width + 50 && pb1.Location.X <= pb2.Location.X + pb2.Width + 50;
        }
        //---------------------ANIMATION-------------------------
        private void AnimatePlayer(int start, int end)
        {
            slowDownFrameRate += 1;
            if (slowDownFrameRate == 4)
            {
                steps++;
                slowDownFrameRate = 0;
            }
            steps++;
            if (steps > end || steps < start)
            {
                steps = start;
            }
            pbPlayer.Image = Image.FromFile(playerMovements[steps]);
        }

        //-------------------MOVEMENT-------------------------
        private void moveLeft()
        {
            //pbPlayer.Left -= playerSpeed;
            AnimatePlayer(4, 7);
            foreach (PictureBox pb in pbFish)
            {
                pb.Left += imgSpeed;
            }
            foreach (PictureBox pb in pbHouses)
            {
                pb.Left += imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                pb.Left += imgSpeed;
            }
            foreach (PictureBox pb in pbHousesRight)
            {
                pb.Left += imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDiagonal)
            {
                pb.Left += imgSpeed;
            }
            foreach (PictureBox pb in pbTrees)
            {
                pb.Left += imgSpeed;
            }
            foreach (PictureBox pb in pbLakes)
            {
                pb.Left += imgSpeed;
            }
            pbHouseDown.Left += imgSpeed;
            pbHouseMiddle.Left += imgSpeed;
            pbHome.Left += imgSpeed;
            end_right += imgSpeed;
            end_left += imgSpeed;
        }
        private void moveRight()
        {
            //pbPlayer.Left += playerSpeed;
            AnimatePlayer(8, 11);
            foreach (PictureBox pb in pbFish)
            {
                pb.Left -= imgSpeed;
            }
            foreach (PictureBox pb in pbHouses)
            {
                pb.Left -= imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                pb.Left -= imgSpeed;
            }
            foreach (PictureBox pb in pbHousesRight)
            {
                pb.Left -= imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDiagonal)
            {
                pb.Left -= imgSpeed;
            }
            foreach (PictureBox pb in pbTrees)
            {
                pb.Left -= imgSpeed;
            }
            foreach (PictureBox pb in pbLakes)
            {
                pb.Left -= imgSpeed;
            }

            pbHouseDown.Left -= imgSpeed;
            pbHouseMiddle.Left -= imgSpeed;
            pbHome.Left -= imgSpeed;
            end_right -= imgSpeed;
            end_left -= imgSpeed;
        }
        private void moveUp()
        {
            //pbPlayer.Top -= playerSpeed;
            AnimatePlayer(12, 15);
            foreach (PictureBox pb in pbFish)
            {
                pb.Top += imgSpeed;
            }
            foreach (PictureBox pb in pbHouses)
            {
                pb.Top += imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                pb.Top += imgSpeed;
            }
            foreach (PictureBox pb in pbHousesRight)
            {
                pb.Top += imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDiagonal)
            {
                pb.Top += imgSpeed;
            }
            foreach (PictureBox pb in pbTrees)
            {
                pb.Top += imgSpeed;
            }
            foreach (PictureBox pb in pbLakes)
            {
                pb.Top += imgSpeed;
            }
            pbHouseDown.Top += imgSpeed;
            pbHouseMiddle.Top += imgSpeed;
            pbHome.Top += imgSpeed;
            end_down += imgSpeed;
            end_up += imgSpeed;
        }
        private void moveDown()
        {
            //pbPlayer.Top += playerSpeed;
            AnimatePlayer(0, 3);
            foreach (PictureBox pb in pbFish)
            {
                pb.Top -= imgSpeed;
            }
            foreach (PictureBox pb in pbHouses)
            {
                pb.Top -= imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                pb.Top -= imgSpeed;
            }
            foreach (PictureBox pb in pbHousesRight)
            {
                pb.Top -= imgSpeed;
            }
            foreach (PictureBox pb in pbHousesDiagonal)
            {
                pb.Top -= imgSpeed;
            }
            foreach (PictureBox pb in pbTrees)
            {
                pb.Top -= imgSpeed;
            }
            foreach (PictureBox pb in pbLakes)
            {
                pb.Top -= imgSpeed;
            }
            pbHouseDown.Top -= imgSpeed;
            pbHouseMiddle.Top -= imgSpeed;
            pbHome.Top -= imgSpeed;
            end_down -= imgSpeed;
            end_up -= imgSpeed;
        }
        //---------------------HITS-------------------
        private void HitLeft()
        {
            foreach (PictureBox pb in pbLakes)
            {
                if (IsHitLeft(pbPlayer, pb))
                {
                    left = false;
                    isHit = true;
                    lake = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHouses)
            {
                if (IsHitLeft(pbPlayer, pb))
                {
                    left = false;
                    isHit = true;
                    house = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                if (IsHitLeft(pbPlayer, pb))
                {
                    left = false;
                    isHit = true;
                    dog = true;
                    break;
                }
            }
            foreach(PictureBox pb in pbHousesRight)
            {
                if (IsHitLeft(pbPlayer, pb))
                {
                    left = false;
                    isHit = true;
                    house_right = true;
                }
            }
            foreach(PictureBox pb in pbHousesDiagonal)
            {
                if (IsHitLeft(pbPlayer, pb))
                {
                    left = false;
                    isHit = true;
                    house_diag = true;
                }
            }
            if (IsHitLeft(pbPlayer, pbHouseMiddle))
            {
                left = false;
                isHit = true;
                house_middle = true;
            }
            if (IsHitLeft(pbPlayer, pbHouseDown))
            {
                left = false;
                isHit = true;
                house_down = true;
            }
        }
        private void HitRight()
        {
            foreach (PictureBox pb in pbLakes)
            {
                if (IsHitRight(pbPlayer, pb))
                {
                    right = false;
                    isHit = true;
                    lake = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHouses)
            {
                if (IsHitRight(pbPlayer, pb))
                {
                    right = false;
                    isHit = true;
                    house = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                if (IsHitRight(pbPlayer, pb))
                {
                    right = false;
                    isHit = true;
                    dog = true;
                    break;
                }
            }
            foreach(PictureBox pb in pbHousesRight)
            {
                if (IsHitRight(pbPlayer, pb))
                {
                    right = false;
                    isHit = true;
                    house_right = true;
                }
            }
            foreach(PictureBox pb in pbHousesDiagonal)
            {
                if (IsHitRight(pbPlayer, pb))
                {
                    right = false;
                    isHit = true;
                    house_diag = true;
                }
            }
            if (IsHitRight(pbPlayer, pbHouseMiddle))
            {
                right = false;
                isHit = true;
                house_middle = true;
            }
            if (IsHitRight(pbPlayer, pbHouseDown))
            {
                right = false;
                isHit = true;
                house_down = true;
            }
        }
        private void HitUp()
        {
            foreach (PictureBox pb in pbLakes)
            {
                if (IsHitUp(pbPlayer, pb))
                {
                    up = false;
                    isHit = true;
                    lake = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHouses)
            {
                if (IsHitUp(pbPlayer, pb))
                {
                    up = false;
                    isHit = true;
                    house = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                if (IsHitUp(pbPlayer, pb))
                {
                    up = false;
                    isHit = true;
                    dog = true;
                    break;
                }
            }
            foreach(PictureBox pb in pbHousesRight)
            {
                if (IsHitUp(pbPlayer, pb))
                {
                    up = false;
                    isHit = true;
                    house_right = true;
                }
            }
            foreach(PictureBox pb in pbHousesDiagonal)
            {
                if (IsHitUp(pbPlayer, pb))
                {
                    up = false;
                    isHit = true;
                    house_diag = true;
                }
            }
            if (IsHitUp(pbPlayer, pbHouseMiddle))
            {
                up = false;
                isHit = true;
                house_middle = true;
            }
            if (IsHitUp(pbPlayer, pbHouseDown))
            {
                up = false;
                isHit = true;
                house_down = true;
            }
        }
        private void HitDown()
        {
            foreach (PictureBox pb in pbLakes)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    lake = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHouses)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    house = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    dog = true;
                    break;
                }
            }
            foreach(PictureBox pb in pbHousesRight)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    house_right = true;
                }
            }
            foreach(PictureBox pb in pbHousesDiagonal)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    house_diag = true;
                }
            }
            if (IsHitDown(pbPlayer, pbHouseMiddle))
            {
                down = false;
                isHit = true;
                house_middle = true;
            }
            if (IsHitDown(pbPlayer, pbHouseDown))
            {
                down = false;
                isHit = true;
                house_down = true;
            }
        }

        //---------------------TIMER-HEALTH-------------------
        private void timerHealth_Tick(object sender, EventArgs e)
        {
            health--;
            if (health <= 0)
            {
                gameOver();
            }
            if (health > 150)
            {
                pbHealth.Value = 150;
            }
            else if(health >= 0)
            {
                pbHealth.Value = health;
            }
            
            CurrentScore();
        }
        //-------------------PAUSE-RESUME-------------------
        private void pbResume_MouseClick(object sender, MouseEventArgs e)
        {
            timerHealth.Start();
            imgSpeed = 20;
        }

        private void pbPause_MouseClick(object sender, MouseEventArgs e)
        {
            timerHealth.Stop();
            imgSpeed = 0;
        }
    }
}
