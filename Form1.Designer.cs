namespace DinoGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dino = new PictureBox();
            obstacle = new PictureBox();
            flyingObstacle = new PictureBox();
            powerUpBox = new PictureBox();
            fireProjectile = new PictureBox();
            scoreLabel = new Label();
            ammoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dino).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)flyingObstacle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)powerUpBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireProjectile).BeginInit();
            SuspendLayout();
            // 
            // dino
            // 
            dino.BackColor = Color.Gray;
            dino.Location = new Point(100, 300);
            dino.Name = "dino";
            dino.Size = new Size(58, 80);
            dino.SizeMode = PictureBoxSizeMode.StretchImage;
            dino.TabIndex = 0;
            dino.TabStop = false;
            // 
            // obstacle
            // 
            obstacle.BackColor = Color.IndianRed;
            obstacle.Location = new Point(800, 320);
            obstacle.Name = "obstacle";
            obstacle.Size = new Size(40, 60);
            obstacle.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle.TabIndex = 1;
            obstacle.TabStop = false;
            // 
            // flyingObstacle
            // 
            flyingObstacle.BackColor = Color.IndianRed;
            flyingObstacle.Location = new Point(800, 274);
            flyingObstacle.Name = "flyingObstacle";
            flyingObstacle.Size = new Size(40, 40);
            flyingObstacle.SizeMode = PictureBoxSizeMode.StretchImage;
            flyingObstacle.TabIndex = 3;
            flyingObstacle.TabStop = false;
            // 
            // powerUpBox
            // 
            powerUpBox.BackColor = Color.Gold;
            powerUpBox.Location = new Point(800, 250);
            powerUpBox.Name = "powerUpBox";
            powerUpBox.Size = new Size(30, 30);
            powerUpBox.SizeMode = PictureBoxSizeMode.StretchImage;
            powerUpBox.TabIndex = 4;
            powerUpBox.TabStop = false;
            // 
            // fireProjectile
            // 
            fireProjectile.BackColor = Color.Orange;
            fireProjectile.Location = new Point(100, 300);
            fireProjectile.Name = "fireProjectile";
            fireProjectile.Size = new Size(20, 10);
            fireProjectile.SizeMode = PictureBoxSizeMode.StretchImage;
            fireProjectile.TabIndex = 5;
            fireProjectile.TabStop = false;
            fireProjectile.Visible = false;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Arial", 16F, FontStyle.Bold);
            scoreLabel.Location = new Point(10, 10);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(97, 26);
            scoreLabel.TabIndex = 2;
            scoreLabel.Text = "Score: 0";
            // 
            // ammoLabel
            // 
            ammoLabel.AutoSize = true;
            ammoLabel.Font = new Font("Arial", 16F, FontStyle.Bold);
            ammoLabel.Location = new Point(10, 40);
            ammoLabel.Name = "ammoLabel";
            ammoLabel.Size = new Size(120, 26);
            ammoLabel.TabIndex = 6;
            ammoLabel.Text = "Ammo: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 400);
            Controls.Add(ammoLabel);
            Controls.Add(fireProjectile);
            Controls.Add(powerUpBox);
            Controls.Add(scoreLabel);
            Controls.Add(flyingObstacle);
            Controls.Add(obstacle);
            Controls.Add(dino);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dino Runner";
            ((System.ComponentModel.ISupportInitialize)dino).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle).EndInit();
            ((System.ComponentModel.ISupportInitialize)flyingObstacle).EndInit();
            ((System.ComponentModel.ISupportInitialize)powerUpBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fireProjectile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox dino;
        private PictureBox obstacle;
        private PictureBox flyingObstacle;
        private PictureBox powerUpBox;
        private PictureBox fireProjectile;
        private Label scoreLabel;
        private Label ammoLabel;
    }
}
