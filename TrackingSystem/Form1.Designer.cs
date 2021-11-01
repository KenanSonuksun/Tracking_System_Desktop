
namespace TrackingSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SignInButton = new System.Windows.Forms.Button();
            this.userPasswordSignIn = new System.Windows.Forms.TextBox();
            this.userNameSignIn = new System.Windows.Forms.TextBox();
            this.goToRegister = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SignInButton
            // 
            this.SignInButton.Location = new System.Drawing.Point(50, 268);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(176, 32);
            this.SignInButton.TabIndex = 14;
            this.SignInButton.Text = "Sign In";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // userPasswordSignIn
            // 
            this.userPasswordSignIn.Location = new System.Drawing.Point(50, 231);
            this.userPasswordSignIn.Name = "userPasswordSignIn";
            this.userPasswordSignIn.Size = new System.Drawing.Size(176, 22);
            this.userPasswordSignIn.TabIndex = 13;
            // 
            // userNameSignIn
            // 
            this.userNameSignIn.Location = new System.Drawing.Point(50, 177);
            this.userNameSignIn.Name = "userNameSignIn";
            this.userNameSignIn.Size = new System.Drawing.Size(176, 22);
            this.userNameSignIn.TabIndex = 12;
            // 
            // goToRegister
            // 
            this.goToRegister.Location = new System.Drawing.Point(50, 306);
            this.goToRegister.Name = "goToRegister";
            this.goToRegister.Size = new System.Drawing.Size(176, 32);
            this.goToRegister.TabIndex = 15;
            this.goToRegister.Text = "Register";
            this.goToRegister.UseVisualStyleBackColor = true;
            this.goToRegister.Click += new System.EventHandler(this.goToRegister_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(281, -44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(872, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.goToRegister);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.userPasswordSignIn);
            this.Controls.Add(this.userNameSignIn);
            this.Name = "Form1";
            this.Text = "Login Page";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button SignInButton;
        internal System.Windows.Forms.TextBox userPasswordSignIn;
        internal System.Windows.Forms.TextBox userNameSignIn;
        private System.Windows.Forms.Button goToRegister;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

