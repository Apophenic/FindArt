using System.Drawing;
using System.Windows.Forms;

namespace FindArt
{
    /// <summary>
    /// Helper class for ArtControl.
    /// Use to create a border effect around
    /// clicked (selected) artwork images.
    /// Height and Width should match image height/width.
    /// </summary>
    class SelectionBox : PictureBox
    {
        private int imgHeight;
        private int imgWidth;
        private int borderWidth;

        public SelectionBox(int height, int width, int border)
        {
            this.imgHeight = height;
            this.imgWidth = width;
            this.borderWidth = border;

            Image img = new Bitmap(imgWidth + borderWidth, imgHeight + borderWidth);
            Graphics g = Graphics.FromImage(img);
            g.DrawRectangle(new Pen(Brushes.Cyan, borderWidth), new Rectangle(0, 0, imgWidth + borderWidth, imgHeight + borderWidth));

            this.Image = img;
            this.Size = new Size(imgWidth + borderWidth, imgHeight + borderWidth);
            this.Location = new System.Drawing.Point(borderWidth, borderWidth);
            this.Name = "selectionBox";
            this.Visible = false;
        }

    }
}
