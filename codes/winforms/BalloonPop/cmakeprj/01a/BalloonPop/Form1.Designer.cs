using System.Drawing;
using System.Windows.Forms;

namespace BalloonPop
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
            this.components = new System.ComponentModel.Container();
            this.yellowBalloon = new System.Windows.Forms.PictureBox();
            this.redStar = new System.Windows.Forms.PictureBox();
            this.redHeart = new System.Windows.Forms.PictureBox();
            this.pinkBalloon = new System.Windows.Forms.PictureBox();
            this.bomb = new System.Windows.Forms.PictureBox();
            this.boom = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.yellowBalloon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redHeart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinkBalloon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boom)).BeginInit();
            this.SuspendLayout();
            // 
            // yellowBalloon
            // 
            this.yellowBalloon.BackColor = System.Drawing.Color.Transparent;
            this.yellowBalloon.Image = global::BalloonPop.Properties.Resources.yellowBalloon;
            this.yellowBalloon.Location = new System.Drawing.Point(9, 411);
            this.yellowBalloon.Name = "yellowBalloon";
            this.yellowBalloon.Size = new System.Drawing.Size(111, 116);
            this.yellowBalloon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.yellowBalloon.TabIndex = 0;
            this.yellowBalloon.TabStop = false;
            this.yellowBalloon.Tag = "Balloon";
            this.yellowBalloon.Click += new System.EventHandler(this.popBalloon);
            // 
            // redStar
            // 
            this.redStar.BackColor = System.Drawing.Color.Transparent;
            this.redStar.Image = global::BalloonPop.Properties.Resources.redStar;
            this.redStar.Location = new System.Drawing.Point(117, 411);
            this.redStar.Name = "redStar";
            this.redStar.Size = new System.Drawing.Size(111, 116);
            this.redStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.redStar.TabIndex = 1;
            this.redStar.TabStop = false;
            this.redStar.Tag = "Balloon";
            this.redStar.Click += new System.EventHandler(this.popBalloon);
            // 
            // redHeart
            // 
            this.redHeart.BackColor = System.Drawing.Color.Transparent;
            this.redHeart.Image = global::BalloonPop.Properties.Resources.redHeart;
            this.redHeart.Location = new System.Drawing.Point(228, 411);
            this.redHeart.Name = "redHeart";
            this.redHeart.Size = new System.Drawing.Size(111, 116);
            this.redHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.redHeart.TabIndex = 2;
            this.redHeart.TabStop = false;
            this.redHeart.Tag = "Balloon";
            this.redHeart.Click += new System.EventHandler(this.popBalloon);
            // 
            // pinkBalloon
            // 
            this.pinkBalloon.BackColor = System.Drawing.Color.Transparent;
            this.pinkBalloon.Image = global::BalloonPop.Properties.Resources.pinkBalloon;
            this.pinkBalloon.Location = new System.Drawing.Point(340, 411);
            this.pinkBalloon.Name = "pinkBalloon";
            this.pinkBalloon.Size = new System.Drawing.Size(100, 143);
            this.pinkBalloon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pinkBalloon.TabIndex = 3;
            this.pinkBalloon.TabStop = false;
            this.pinkBalloon.Tag = "Balloon";
            this.pinkBalloon.Click += new System.EventHandler(this.popBalloon);
            // 
            // bomb
            // 
            this.bomb.BackColor = System.Drawing.Color.Transparent;
            this.bomb.Image = global::BalloonPop.Properties.Resources.bomb;
            this.bomb.Location = new System.Drawing.Point(440, 411);
            this.bomb.Name = "bomb";
            this.bomb.Size = new System.Drawing.Size(100, 98);
            this.bomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bomb.TabIndex = 4;
            this.bomb.TabStop = false;
            this.bomb.Tag = "bomb";
            this.bomb.Click += new System.EventHandler(this.popBomb);
            // 
            // boom
            // 
            this.boom.BackColor = System.Drawing.Color.Transparent;
            this.boom.Image = global::BalloonPop.Properties.Resources.boom;
            this.boom.Location = new System.Drawing.Point(542, 411);
            this.boom.Name = "boom";
            this.boom.Size = new System.Drawing.Size(175, 189);
            this.boom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.boom.TabIndex = 5;
            this.boom.TabStop = false;
            this.boom.Tag = "boom";
            this.boom.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameEngine);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boom);
            this.Controls.Add(this.bomb);
            this.Controls.Add(this.pinkBalloon);
            this.Controls.Add(this.redHeart);
            this.Controls.Add(this.redStar);
            this.Controls.Add(this.yellowBalloon);
            this.Name = "Form1";
            this.Text = "Balloon Pop Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            ((System.ComponentModel.ISupportInitialize)(this.yellowBalloon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redHeart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinkBalloon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox yellowBalloon;
        private PictureBox redStar;
        private PictureBox redHeart;
        private PictureBox pinkBalloon;
        private PictureBox bomb;
        private PictureBox boom;
        private Label label1;
        private Timer gameTimer;
    }
}
