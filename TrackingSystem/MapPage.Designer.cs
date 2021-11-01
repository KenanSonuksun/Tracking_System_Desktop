
namespace TrackingSystem
{
    partial class MapPage
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
            this.googleMap = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // googleMap
            // 
            this.googleMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.googleMap.Bearing = 0F;
            this.googleMap.CanDragMap = true;
            this.googleMap.EmptyTileColor = System.Drawing.Color.Olive;
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
            this.googleMap.Size = new System.Drawing.Size(801, 450);
            this.googleMap.TabIndex = 2;
            this.googleMap.Zoom = 0D;
            this.googleMap.Load += new System.EventHandler(this.googleMap_Load);
            // 
            // MapPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.googleMap);
            this.Name = "MapPage";
            this.Text = "MapPage";
            this.Load += new System.EventHandler(this.MapPage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl googleMap;
    }
}