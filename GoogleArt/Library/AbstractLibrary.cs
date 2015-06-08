using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TagLib;

namespace FindArt.Library
{
    /// <summary>
    /// Reads music library and saves a dictionary containing
    /// artist objects, holding respective album objects,
    /// holding respective track file paths. Artist/Album
    /// object creation is handled by their literal name.
    /// Also stores reference to albums missing artwork.
    /// </summary>
    public abstract class AbstractLibrary
    {
        /// Supported file types
        public string[] EXTS = new string[] { ".mp3", ".m4a", ".wav", ".flac", ".ogg" };

        /// <see cref="detectProperFolderStructure()"/>
        public const int SAMPLE_SIZE = 100;
        public const double MIN_PERCENT = .80;

        protected Dictionary<string, Artist> artists = new Dictionary<string, Artist>();
        protected Queue<ArtControl> missingAlbums = new Queue<ArtControl>();

        protected string fileLocation; /// (or folder path)
        protected bool isFinishedReadingArtwork = false;


        /// <summary>
        /// Override to define how a library file path
        /// should be read to retrieve individual track paths
        /// in said library.
        /// </summary>
        /// <returns>List of all file paths in the library</returns>
        protected abstract List<string> readFilePaths();

        public AbstractLibrary(string file)
        {
            this.fileLocation = file;
            readLibrary();
        }

        protected void readLibrary()
        {
            Thread thread = new Thread(() =>
            {
                new ProgressDialog("Reading...").ShowDialog();
            });
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Name = "Read Library";
            thread.Start();

            List<string> paths = readFilePaths();

            thread.Abort();
            readArtistsAndAlbums(paths);
        }

        /// <summary>
        /// Creates Artist and Album objects from the
        /// provided library track paths
        /// </summary>
        /// <param name="paths">List of all track paths in the library</param>
        protected void readArtistsAndAlbums(List<string> paths)
        {
            ProgressDialog progressDialog = new ProgressDialog(0, paths.Count);
            progressDialog.Show();

            bool isProperStructure = detectProperFolderStructure(paths);

            int progressCounter = 0;
            foreach (var path in paths)
            {
                ArtistAlbumPair aaPair;
                if(isProperStructure)
                {
                    aaPair = Util.getArtistAndAlbumFromPath(path);
                }
                else
                {
                    aaPair = Util.getArtistAndAlbumFromTag(path);
                }

                Artist artist; Album album;
                artists.TryGetValue(aaPair.artist.ToLower(), out artist);
                if (artist == null)
                {
                    artist = new Artist(aaPair.artist);
                    album = new Album(aaPair.album);
                    artist.addAlbum(album);
                    artists.Add(artist.ArtistName.ToLower(), artist);
                }
                else
                {
                    artist.Albums.TryGetValue(aaPair.album.ToLower(), out album);
                    if (album == null)
                    {
                        album = new Album(aaPair.album);
                        artist.addAlbum(album);
                    }
                }
                album.addTrackPath(path);
                progressDialog.updateLazily(++progressCounter);
            }
            progressDialog.Close();
        }

        /// <summary>
        /// Creates a background thread that proceeds to read
        /// all track paths looking for artwork missing on
        /// ID3 tags.
        /// </summary>
        public void findMissingArtwork()
        {
            Thread thread = new Thread(() => //TODO: better way to implement; background worker?
            {
                foreach (KeyValuePair<string, Artist> artistEntry in artists)
                {
                    foreach (KeyValuePair<string, Album> albumEntry in artistEntry.Value.Albums)
                    {
                        ByteVector albumArtData = null;
                        List<string> missingArtTrackList = new List<string>();
                        foreach (string path in albumEntry.Value.TrackPaths)
                        {
                            Tag tag = File.Create(path).Tag;
                            if (tag == null || tag.IsEmpty)
                            {
                                //TODO: create new tag
                            }
                            if (tag.Pictures.Length > 0)
                            {
                                if (albumArtData == null)
                                {
                                    albumArtData = tag.Pictures[0].Data; ///Track on album has artwork, save in case others are missing it
                                }
                            }
                            else
                            {
                                missingArtTrackList.Add(path);
                            }
                        }

                        if (albumArtData == null)
                        {
                            missingAlbums.Enqueue(new ArtControl(artistEntry.Value, albumEntry.Value)); ///No art found, queue album
                        }
                        else
                        {
                            if (missingArtTrackList.Count > 0)
                            {
                                foreach (string path in missingArtTrackList)
                                {
                                    Util.writePictureData(albumArtData, path); ///Album has art, but not all tracks do, so write art
                                }
                            }
                        }
                    }
                }
                isFinishedReadingArtwork = true;
            });
            thread.Priority = ThreadPriority.Normal;
            thread.Name = "Find Missing Artwork";
            thread.Start();
        }

        /// <summary>
        /// Attempts to find a discernable (proper) folder structure
        /// for the subdirs within the main library folder.
        /// Proper structure is dir/artist/album/albumtrack.mp3.
        /// Artist and album objects can be created SIGNIFICANTLY faster 
        /// using file paths rather than having to read every track's 
        /// ID3 tag for the artist and album name.
        /// <paramref name="SAMPLE_SIZE"/> # of files are randomly selected
        /// and checked to see if proper. <paramref name="MIN_PERCENT"/>
        /// is the minimum required success rate.
        /// </summary>
        /// <param name="paths">List of library track paths</param>
        /// <returns>true if dir/artist/album/tracks.mp3, false otherwise</returns>
        protected bool detectProperFolderStructure(List<string> paths)
        {
            int sampleSize = (paths.Count > SAMPLE_SIZE) ? SAMPLE_SIZE : paths.Count;
            int properStructureCounter = 0;
            var rnd = new Random();

            ProgressDialog progressDialog = new ProgressDialog(0, sampleSize, "Detecting Folder Structure...");
            progressDialog.Show();

            int progressCounter = 0;
            for(int i = 0; i < sampleSize; i++)
            {
                string path = paths[rnd.Next(0, paths.Count - 1)];
                ArtistAlbumPair aaPairReadPath = Util.getArtistAndAlbumFromPath(path);
                ArtistAlbumPair aaPairReadTag = Util.getArtistAndAlbumFromTag(path);

                float artistScore = Util.checkStringDistance(aaPairReadTag.artist, aaPairReadPath.artist);
                float albumScore = Util.checkStringDistance(aaPairReadTag.album, aaPairReadPath.album);
                if(artistScore > MIN_PERCENT || albumScore > MIN_PERCENT)
                {
                    properStructureCounter++;
                }
                progressDialog.updateImmediately(++progressCounter);
            }
            progressDialog.Close();

            float score = ((float)properStructureCounter / sampleSize);
            if(score < MIN_PERCENT)
            {
                MessageBox.Show("Improper folder structure (doesn't match dir/artist/album/)\n; Library will take longer to read");
                return false;
            }
            else
            {
                return true;
            } 
        }

        public void printLibrary()
        {
            foreach (KeyValuePair<string, Artist> artistPair in artists)
            {
                Console.WriteLine("ARTIST: " + artistPair.Value.ArtistName);
                foreach (KeyValuePair<string, Album> albumPair in artistPair.Value.Albums)
                {
                    Console.WriteLine("-" + albumPair.Value.AlbumName);
                    foreach (string trackPath in albumPair.Value.TrackPaths)
                    {
                        Console.WriteLine("--" + trackPath);
                    }
                }
            }
        }

        public List<Album> getAllAlbums()
        {
            List<Album> albums = new List<Album>();
            foreach (KeyValuePair<string, Artist> artist in artists)
            {
                foreach (KeyValuePair<string, Album> album in artist.Value.Albums)
                {
                    albums.Add(album.Value);
                }
            }
            return albums;
        }

        public Dictionary<string, Artist> Artists
        {
            get
            {
                return artists;
            }
            set
            {
                artists = value;
            }
        }

        public Queue<ArtControl> MissingAlbums
        {
            get
            {
                return missingAlbums;
            }
            set
            {
                missingAlbums = value;
            }
        }

        public bool IsFinishedSearchingArtwork
        {
            get
            {
                return isFinishedReadingArtwork;
            }
            set
            {
                isFinishedReadingArtwork = value;
            }
        }
    }
}
