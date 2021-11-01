
namespace TrackingSystem
{
    partial class HomePage
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.googleMap = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.latText = new System.Windows.Forms.TextBox();
            this.lngText = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.addPointButton = new System.Windows.Forms.Button();
            this.totalKm = new System.Windows.Forms.Label();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.goToMapButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.settingsButton = new System.Windows.Forms.Button();
            this.updateUserNameText = new System.Windows.Forms.TextBox();
            this.updatePasswordText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(462, 450);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // googleMap
            // 
            this.googleMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.googleMap.Bearing = 0F;
            this.googleMap.CanDragMap = true;
            this.googleMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.googleMap.GrayScaleMode = false;
            this.googleMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.googleMap.LevelsKeepInMemory = 5;
            this.googleMap.Location = new System.Drawing.Point(0, 0);
            this.googleMap.MarkersEnabled = true;
            this.googleMap.MaxZoom = 2;
            this.googleMap.MinZoom = 2;
            this.googleMap.MouseWheelZoomEnabled = true;
            this.googleMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.googleMap.Name = "googleMap";
            this.googleMap.NegativeMode = false;
            this.googleMap.PolygonsEnabled = true;
            this.googleMap.RetryLoadTile = 0;
            this.googleMap.RoutesEnabled = true;
            this.googleMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.googleMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.googleMap.ShowTileGridLines = false;
            this.googleMap.Size = new System.Drawing.Size(462, 450);
            this.googleMap.TabIndex = 1;
            this.googleMap.Zoom = 0D;
            this.googleMap.Load += new System.EventHandler(this.googleMap_Load);
            this.googleMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.googleMap_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Latitude";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Longitude";
            // 
            // latText
            // 
            this.latText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.latText.Location = new System.Drawing.Point(479, 29);
            this.latText.Name = "latText";
            this.latText.Size = new System.Drawing.Size(167, 22);
            this.latText.TabIndex = 4;
            // 
            // lngText
            // 
            this.lngText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lngText.Location = new System.Drawing.Point(479, 74);
            this.lngText.Name = "lngText";
            this.lngText.Size = new System.Drawing.Size(167, 22);
            this.lngText.TabIndex = 5;
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.findButton.ForeColor = System.Drawing.SystemColors.Window;
            this.findButton.Location = new System.Drawing.Point(479, 102);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(167, 28);
            this.findButton.TabIndex = 6;
            this.findButton.Text = "Load";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // addPointButton
            // 
            this.addPointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addPointButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.addPointButton.ForeColor = System.Drawing.SystemColors.Window;
            this.addPointButton.Location = new System.Drawing.Point(672, 29);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(100, 28);
            this.addPointButton.TabIndex = 8;
            this.addPointButton.Text = "Add Point";
            this.addPointButton.UseVisualStyleBackColor = false;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // totalKm
            // 
            this.totalKm.AutoSize = true;
            this.totalKm.Location = new System.Drawing.Point(566, 195);
            this.totalKm.Name = "totalKm";
            this.totalKm.Size = new System.Drawing.Size(0, 17);
            this.totalKm.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(479, 242);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 84);
            this.listBox1.TabIndex = 12;
            // 
            // goToMapButton
            // 
            this.goToMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goToMapButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.goToMapButton.ForeColor = System.Drawing.SystemColors.Window;
            this.goToMapButton.Location = new System.Drawing.Point(672, 63);
            this.goToMapButton.Name = "goToMapButton";
            this.goToMapButton.Size = new System.Drawing.Size(100, 28);
            this.goToMapButton.TabIndex = 14;
            this.goToMapButton.Text = "Map";
            this.goToMapButton.UseVisualStyleBackColor = false;
            this.goToMapButton.Click += new System.EventHandler(this.mapPageButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(479, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 46);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.moveButton.ForeColor = System.Drawing.SystemColors.Window;
            this.moveButton.Location = new System.Drawing.Point(672, 97);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(100, 28);
            this.moveButton.TabIndex = 16;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = false;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Selected Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Coordinates";
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.settingsButton.ForeColor = System.Drawing.SystemColors.Window;
            this.settingsButton.Location = new System.Drawing.Point(479, 408);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(81, 32);
            this.settingsButton.TabIndex = 19;
            this.settingsButton.Text = "Update";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // updateUserNameText
            // 
            this.updateUserNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateUserNameText.Location = new System.Drawing.Point(662, 359);
            this.updateUserNameText.Name = "updateUserNameText";
            this.updateUserNameText.Size = new System.Drawing.Size(110, 22);
            this.updateUserNameText.TabIndex = 20;
            // 
            // updatePasswordText
            // 
            this.updatePasswordText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatePasswordText.Location = new System.Drawing.Point(662, 387);
            this.updatePasswordText.Name = "updatePasswordText";
            this.updatePasswordText.Size = new System.Drawing.Size(110, 22);
            this.updatePasswordText.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Password";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(662, 416);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 24);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "State";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updatePasswordText);
            this.Controls.Add(this.updateUserNameText);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.goToMapButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.totalKm);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.lngText);
            this.Controls.Add(this.latText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.googleMap);
            this.Controls.Add(this.splitter1);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl googleMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox latText;
        private System.Windows.Forms.TextBox lngText;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.Label totalKm;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button goToMapButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TextBox updateUserNameText;
        private System.Windows.Forms.TextBox updatePasswordText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
    }
}