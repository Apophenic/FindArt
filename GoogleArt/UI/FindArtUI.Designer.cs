using FindArt.UI;
namespace FindArt
{
    partial class FindArtUI
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
            this.btnDeselect = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblAlbumTitle = new System.Windows.Forms.Label();
            this.lblArtistTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblSizeTitle = new System.Windows.Forms.Label();
            this.lblQualityTitle = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblQuality = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeselect
            // 
            this.btnDeselect.Location = new System.Drawing.Point(273, 704);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(107, 37);
            this.btnDeselect.TabIndex = 8;
            this.btnDeselect.Text = "Deselect";
            this.btnDeselect.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(513, 704);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(125, 37);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next Album";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(22, 706);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(129, 35);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load Next 4 Images";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbum.Location = new System.Drawing.Point(97, 33);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(0, 24);
            this.lblAlbum.TabIndex = 5;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.Location = new System.Drawing.Point(83, 9);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(0, 24);
            this.lblArtist.TabIndex = 4;
            // 
            // lblAlbumTitle
            // 
            this.lblAlbumTitle.AutoSize = true;
            this.lblAlbumTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbumTitle.Location = new System.Drawing.Point(15, 33);
            this.lblAlbumTitle.Name = "lblAlbumTitle";
            this.lblAlbumTitle.Size = new System.Drawing.Size(76, 24);
            this.lblAlbumTitle.TabIndex = 3;
            this.lblAlbumTitle.Text = "Album:";
            // 
            // lblArtistTitle
            // 
            this.lblArtistTitle.AutoSize = true;
            this.lblArtistTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistTitle.Location = new System.Drawing.Point(15, 9);
            this.lblArtistTitle.Name = "lblArtistTitle";
            this.lblArtistTitle.Size = new System.Drawing.Size(62, 24);
            this.lblArtistTitle.TabIndex = 2;
            this.lblArtistTitle.Text = "Artist:";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(12, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(640, 640);
            this.mainPanel.TabIndex = 0;
            // 
            // lblSizeTitle
            // 
            this.lblSizeTitle.AutoSize = true;
            this.lblSizeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeTitle.Location = new System.Drawing.Point(428, 9);
            this.lblSizeTitle.Name = "lblSizeTitle";
            this.lblSizeTitle.Size = new System.Drawing.Size(104, 20);
            this.lblSizeTitle.TabIndex = 9;
            this.lblSizeTitle.Text = "Image Size:";
            // 
            // lblQualityTitle
            // 
            this.lblQualityTitle.AutoSize = true;
            this.lblQualityTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualityTitle.Location = new System.Drawing.Point(428, 33);
            this.lblQualityTitle.Name = "lblQualityTitle";
            this.lblQualityTitle.Size = new System.Drawing.Size(69, 20);
            this.lblQualityTitle.TabIndex = 10;
            this.lblQualityTitle.Text = "Quality:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(538, 9);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(78, 20);
            this.lblSize.TabIndex = 11;
            this.lblSize.Text = "300 x 300";
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuality.Location = new System.Drawing.Point(538, 33);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(42, 20);
            this.lblQuality.TabIndex = 12;
            this.lblQuality.Text = "High";
            // 
            // FindArtUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 762);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblQualityTitle);
            this.Controls.Add(this.lblSizeTitle);
            this.Controls.Add(this.btnDeselect);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblArtistTitle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblAlbumTitle);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblAlbum);
            this.Name = "FindArtUI";
            this.Text = "FindArt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArtistTitle;
        private System.Windows.Forms.Label lblAlbumTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDeselect;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblSizeTitle;
        private System.Windows.Forms.Label lblQualityTitle;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblQuality;
    }
}

