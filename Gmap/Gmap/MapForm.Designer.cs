namespace Gmap
{
    partial class MapForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControler = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // gMapControler
            // 
            this.gMapControler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControler.Bearing = 0F;
            this.gMapControler.CanDragMap = true;
            this.gMapControler.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControler.GrayScaleMode = false;
            this.gMapControler.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControler.LevelsKeepInMemmory = 5;
            this.gMapControler.Location = new System.Drawing.Point(1, 0);
            this.gMapControler.MarkersEnabled = true;
            this.gMapControler.MaximumSize = new System.Drawing.Size(2048, 1080);
            this.gMapControler.MaxZoom = 2;
            this.gMapControler.MinimumSize = new System.Drawing.Size(816, 489);
            this.gMapControler.MinZoom = 2;
            this.gMapControler.MouseWheelZoomEnabled = true;
            this.gMapControler.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControler.Name = "gMapControler";
            this.gMapControler.NegativeMode = false;
            this.gMapControler.PolygonsEnabled = true;
            this.gMapControler.RetryLoadTile = 0;
            this.gMapControler.RoutesEnabled = true;
            this.gMapControler.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControler.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControler.ShowTileGridLines = false;
            this.gMapControler.Size = new System.Drawing.Size(816, 489);
            this.gMapControler.TabIndex = 0;
            this.gMapControler.Zoom = 0D;
            this.gMapControler.Load += new System.EventHandler(this.gMapControler_Load);
            this.gMapControler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControler_MouseDown);
            this.gMapControler.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControler_MouseMove);
            this.gMapControler.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControler_MouseUp);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gMapControler);
            this.Name = "MapForm";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControler;
    }
}

