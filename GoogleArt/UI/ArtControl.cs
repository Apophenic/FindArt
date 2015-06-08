using FindArt.ImageSearch;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FindArt
{
    /// <summary>
    /// User Interface created for each album missing artwork.
    /// Handles loading and selection of images that are retrieved
    /// from the AbstractImageSearch object.
    /// </summary>
    public partial class ArtControl : UserControl
    {
        private SelectionBox selectionBox = new SelectionBox(300, 300, 10);

        /// Image loaded will be forced to these specifications
        public const int imgHeight = 300;
        public const int imgWidth = 300;

        /// Have the first set of images been loaded?
        private bool isImagesLoaded = false;

        private Artist artist = new Artist();
        private Album album = new Album();
        private PictureBox selectedArt;
        private AbstractImageSearch imgSearch;

        public ArtControl()
        {
            InitializeComponent();
            this.Controls.Add(selectionBox);

            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(PictureBox)
                    && control.Name != "selectionBox")
                {
                    ((PictureBox)control).MouseClick += new MouseEventHandler(moveSelectionBox);
                }
            }
        }

        public ArtControl(Artist artist, Album album)
            : this()
        {
            this.artist = artist;
            this.album = album;
            this.imgSearch = new GoogleImageSearch(artist.ArtistName, album.AlbumName);
            this.selectedArt = pbox1;
            this.loadNextImages();
        }

        public ArtControl(string artist, string album)
            : this(new Artist(artist), new Album(album))
        { }

        /// <summary>
        /// Deselects all images. If next album is proceeded to,
        /// no artwork will be written to current album.
        /// </summary>
        public void deselectArtwork()
        {
            selectionBox.Visible = false;
            selectedArt = null;
        }

        /// <summary>
        /// Loads the next images in queue onto the UI.
        /// </summary>
        public void loadNextImages()
        {
            if (imgSearch == null)
            {
                return;
            }

            Thread thread = new Thread(() => //TODO: How else to implement?
            {
                if (isImagesLoaded)
                {
                    new ProgressDialog("Loading Images...").ShowDialog();
                }
            });
            thread.Priority = ThreadPriority.Lowest;
            thread.Name = "Load Images";
            thread.Start();

            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(PictureBox)
                    && control.Name != "selectionBox")
                {
                    ((PictureBox)control).Image = loadImage();
                }
            }

            thread.Abort();
            isImagesLoaded = true;
        }

        /// <summary>
        /// Write selected artwork image to all tracks on album.
        /// </summary>
        public void saveArtwork()
        {
            if(selectedArt == null)
            {
                return;
            }
            else
            {
                album.writeArtwork(Util.convertImageToByteArray(selectedArt.Image)); //TODO: seperate thread ?
            }
        }

        /// <summary>
        /// Load image from queued url, empty image is no urls remain.
        /// </summary>
        private Image loadImage()
        {
            var urls = imgSearch.ImgUrls;
            Image img = (urls.Count > 0) ? AbstractImageSearch.getImageFromUrl(urls.Dequeue(), imgHeight, imgWidth) : new Bitmap(imgWidth, imgHeight);
            return img;
        }

        /// <summary>
        /// Move selection box and save reference to clicked image.
        /// </summary>
        void moveSelectionBox(object sender, EventArgs e)
        {
            var img = (PictureBox)sender;
            selectionBox.Visible = true;
            selectionBox.Location = new Point(img.Location.X - 5, img.Location.Y - 5);
            selectedArt = img;
        }

        public Artist Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }

        public Album Album
        {
            get
            {
                return album;
            }
            set
            {
                album = value;
            }
        }

        public PictureBox SelectedArtwork
        {
            get
            {
                return selectedArt;
            }
            set
            {
                selectedArt = value;
            }
        }

    }
}
