using FindArt.Dialogs;
using FindArt.Library;
using FindArt.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace FindArt
{
    /// <summary>
    /// Main class. Initializes UI and runs application logic.
    /// </summary>
    public partial class FindArtUI : Form
    {
        /// If waiting to find missing art, how often should the queue be checked?
        public const int UPDATE_INTERVAL = 1000;

        private ArtControl activeArtControl = new ArtControl();
        private AbstractLibrary library;

        private bool isWaitingForMissingArt = true;
        private object _lock = new object();

        delegate void SetMainPanelCallback();

        public FindArtUI()
        {
            InitializeComponent();  //TODO: Create settings, load image size + quality to lbls
            mainPanel.Controls.Add(activeArtControl); 

            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            
            btnNext.MouseClick += new MouseEventHandler(changeArtPanel);
            btnDeselect.MouseClick += new MouseEventHandler(hideSelectionBox);
            btnLoad.MouseClick += new MouseEventHandler(loadNewImages);

            init();
        }

        /// <summary>
        /// Application logic: Open file dialog, get path and type,
        /// create library object, look for missing artwork, create
        /// timer to check for additions to the queue.
        /// </summary>
        public void init()
        {
            var fileDialog = new FileDialog();
            fileDialog.ShowDialog(); //blocking

            switch (fileDialog.LibraryType)
            {
                case (FileDialog.LibraryFileType.iTunes) :
                    library = new ItunesLibrary(fileDialog.LibraryFile);
                    break;
                case (FileDialog.LibraryFileType.Directory) :
                    library = new DirectoryLibrary(fileDialog.LibraryFile);
                    break;
            }
            fileDialog.Dispose();
            library.findMissingArtwork();

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(checkForQueuedArtControl);
            t.Interval = UPDATE_INTERVAL;
            t.Enabled = true;
        }

        /// <summary>
        /// Loads next ArtControl in queue (and its images if necessary)
        /// and attempts to preload images for the following ArtControl.
        /// </summary>
        private void loadNextArtControl()
        {
            if (this.mainPanel.InvokeRequired) /// Timer makes crossthread calls, making this necessary
            {
                SetMainPanelCallback d = new SetMainPanelCallback(loadNextArtControl);
                this.Invoke(d);
            }
            else
            {
                activeArtControl = library.MissingAlbums.Dequeue();

                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(activeArtControl);

                lblArtist.Text = activeArtControl.Artist.ArtistName;
                lblAlbum.Text = activeArtControl.Album.AlbumName;

                isWaitingForMissingArt = false;
            }
        }

        void hideSelectionBox(object sender, EventArgs e)
        {
            activeArtControl.deselectArtwork();
        }

        /// <summary>
        /// Loads the next set of images for the current
        /// ArtControl object.
        /// </summary>
        void loadNewImages(object sender, EventArgs e)
        {
            activeArtControl.loadNextImages();
        }

        /// <summary>
        /// Writes selected artwork to album tracks and loads
        /// next ArtControl
        /// </summary>
        void changeArtPanel(object sender, EventArgs e)
        {
            activeArtControl.saveArtwork();

            if (library.MissingAlbums.Count == 0)
            {
                isWaitingForMissingArt = true;
                if(library.IsFinishedSearchingArtwork)
                {
                    new FinishDialog().ShowDialog();
                }
                else
                {
                    mainPanel.Controls.Clear();
                    mainPanel.Controls.Add(new ProgressControl());
                }
                return;
            }

            loadNextArtControl();
        }

        /// <summary>
        /// Used by timer to check for new additions to the
        /// missing albums queue.
        /// </summary>
        void checkForQueuedArtControl(object sender, EventArgs e)
        {
            lock (_lock)
            {
                if (isWaitingForMissingArt)
                {
                    if(library.IsFinishedSearchingArtwork)
                    {
                        new FinishDialog().ShowDialog();
                    }
                    else if (library.MissingAlbums.Count > 0)
                    {
                        loadNextArtControl();
                    }
                }
            }
        }

        public ArtControl ActiveArtControl
        {
            get
            {
                return activeArtControl;
            }
            set
            {
                activeArtControl = value;
            }
        }

    }
}
