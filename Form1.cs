using System;
using System.Drawing;
using System.Windows.Forms;

namespace DinoGame
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer gameTimer;
        private int score = 0;
        private bool isJumping = false;
        private bool isDucking = false;
        private int jumpForce = 0;
        private Random random = new Random();
        private int obstacleSpeed = 5;
        private int obstacleSpawnTimer = 0;
        private int flyingObstacleSpawnTimer = 0;
        private int obstacleSpawnDelay = 50;
        private int flyingObstacleSpawnDelay = 100;
        private const int GROUND_LEVEL = 300;
        private const int JUMP_HEIGHT = 25;
        private const int GRAVITY = 1;
        private bool obstaclePassed = false;
        private bool flyingObstaclePassed = false;
        private int normalHeight = 80;
        private int duckHeight = 40;
        private bool isGroundObstacleActive = true;
        private int ammo = 0;
        private bool isFiring = false;
        private int powerUpSpawnTimer = 0;
        private const int POWER_UP_SPAWN_DELAY = 500; // Spawn power-up every 500 ticks
        private const int FIRE_SPEED = 10;
        private bool hasPowerUp = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Set up the form
            this.Width = 968;
            this.Height = 400;
            this.Text = "Dino Runner";
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set initial positions
            dino.Location = new Point(100, GROUND_LEVEL);
            obstacle.Location = new Point(this.Width, GROUND_LEVEL + 20);
            flyingObstacle.Location = new Point(this.Width, 274);
            powerUpBox.Visible = false;
            fireProjectile.Visible = false;

            // Set up game timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            // Set up key events
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Handle jumping
            if (isJumping)
            {
                dino.Top -= jumpForce;
                jumpForce -= GRAVITY;

                if (dino.Top >= GROUND_LEVEL)
                {
                    dino.Top = GROUND_LEVEL;
                    isJumping = false;
                }
            }

            // Handle ducking
            if (isDucking && !isJumping)
            {
                dino.Height = duckHeight;
                dino.Top = GROUND_LEVEL + (normalHeight - duckHeight);
            }
            else if (!isJumping)
            {
                dino.Height = normalHeight;
                dino.Top = GROUND_LEVEL;
            }

            // Move active obstacle
            if (isGroundObstacleActive)
            {
                obstacle.Left -= obstacleSpeed;
                flyingObstacle.Left = this.Width;
            }
            else
            {
                flyingObstacle.Left -= obstacleSpeed;
                obstacle.Left = this.Width;
            }

            // Handle power-up box
            powerUpSpawnTimer++;
            if (powerUpSpawnTimer >= POWER_UP_SPAWN_DELAY && !powerUpBox.Visible)
            {
                powerUpBox.Visible = true;
                powerUpBox.Left = this.Width;
                powerUpBox.Top = random.Next(200, 350);
                powerUpSpawnTimer = 0;
            }

            if (powerUpBox.Visible)
            {
                powerUpBox.Left -= obstacleSpeed;
                if (powerUpBox.Right < 0)
                {
                    powerUpBox.Visible = false;
                }

                // Check if dino collected power-up
                if (dino.Bounds.IntersectsWith(powerUpBox.Bounds))
                {
                    powerUpBox.Visible = false;
                    ammo = 5;
                    ammoLabel.Text = "Ammo: " + ammo;
                    hasPowerUp = true;
                }
            }

            // Handle fire projectile
            if (isFiring && ammo > 0)
            {
                fireProjectile.Visible = true;
                fireProjectile.Left += FIRE_SPEED;

                // Check if fire hit an obstacle
                if (isGroundObstacleActive && fireProjectile.Bounds.IntersectsWith(obstacle.Bounds))
                {
                    obstacle.Left = this.Width;
                    fireProjectile.Visible = false;
                    isFiring = false;
                    ammo--;
                    ammoLabel.Text = "Ammo: " + ammo;
                }
                else if (!isGroundObstacleActive && fireProjectile.Bounds.IntersectsWith(flyingObstacle.Bounds))
                {
                    flyingObstacle.Left = this.Width;
                    fireProjectile.Visible = false;
                    isFiring = false;
                    ammo--;
                    ammoLabel.Text = "Ammo: " + ammo;
                }

                // Reset fire if it goes off screen
                if (fireProjectile.Left > this.Width)
                {
                    fireProjectile.Visible = false;
                    isFiring = false;
                    ammo--;
                    ammoLabel.Text = "Ammo: " + ammo;
                }
            }

            // Check if active obstacle is passed
            if (isGroundObstacleActive)
            {
                if (!obstaclePassed && obstacle.Right < dino.Left)
                {
                    obstaclePassed = true;
                    score++;
                    scoreLabel.Text = "Score: " + score;

                    if (score % 5 == 0)
                    {
                        obstacleSpeed += 2;
                        if (obstacleSpawnDelay > 20)
                        {
                            obstacleSpawnDelay -= 2;
                        }
                    }
                }
            }
            else
            {
                if (!flyingObstaclePassed && flyingObstacle.Right < dino.Left)
                {
                    flyingObstaclePassed = true;
                    score++;
                    scoreLabel.Text = "Score: " + score;
                }
            }

            // Spawn new obstacle when current one is passed
            if (isGroundObstacleActive)
            {
                if (obstacle.Right < 0)
                {
                    obstacle.Left = this.Width;
                    obstaclePassed = false;
                    isGroundObstacleActive = false;
                }
            }
            else
            {
                if (flyingObstacle.Right < 0)
                {
                    flyingObstacle.Left = this.Width;
                    flyingObstaclePassed = false;
                    isGroundObstacleActive = true;
                }
            }

            // Check collisions with active obstacle
            if ((isGroundObstacleActive && dino.Bounds.IntersectsWith(obstacle.Bounds)) ||
                (!isGroundObstacleActive && dino.Bounds.IntersectsWith(flyingObstacle.Bounds)))
            {
                GameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !isJumping)
            {
                isJumping = true;
                jumpForce = JUMP_HEIGHT;
                if (isDucking)
                {
                    dino.Height = duckHeight;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                isDucking = true;
                if (!isJumping)
                {
                    dino.Height = duckHeight;
                    dino.Top = GROUND_LEVEL + (normalHeight - duckHeight);
                }
            }
            else if (e.KeyCode == Keys.X && hasPowerUp && ammo > 0 && !isFiring)
            {
                isFiring = true;
                fireProjectile.Left = dino.Right;
                fireProjectile.Top = dino.Top + (dino.Height / 2) - (fireProjectile.Height / 2);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isDucking = false;
                if (!isJumping)
                {
                    dino.Height = normalHeight;
                    dino.Top = GROUND_LEVEL;
                }
            }
        }

        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show($"Game Over! Your score: {score}", "Game Over");
            
            // Reset game
            score = 0;
            scoreLabel.Text = "Score: 0";
            dino.Top = GROUND_LEVEL;
            dino.Height = normalHeight;
            obstacle.Left = this.Width;
            flyingObstacle.Left = this.Width;
            powerUpBox.Visible = false;
            fireProjectile.Visible = false;
            isJumping = false;
            isDucking = false;
            obstacleSpeed = 5;
            obstacleSpawnDelay = 50;
            flyingObstacleSpawnDelay = 100;
            obstaclePassed = false;
            flyingObstaclePassed = false;
            isGroundObstacleActive = true;
            ammo = 0;
            ammoLabel.Text = "Ammo: 0";
            hasPowerUp = false;
            gameTimer.Start();
        }
    }
}
