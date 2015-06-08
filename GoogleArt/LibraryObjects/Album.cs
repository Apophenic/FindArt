using System.Collections.Generic;

namespace FindArt
{
    /// <summary>
    /// Album containing list of it's containing
    /// track paths. Albums can only be accessed through their
    /// respective artist object.
    /// </summary>
    public class Album
    {
        private string albumName;
        private List<string> trackPaths = new List<string>();

        public Album()
        { }

        public Album(string name)
        {
            this.albumName = name;
        }

        public void addTrackPath(string path)
        {
            trackPaths.Add(path);
        }

        public void writeArtwork(TagLib.ByteVector picData)
        {
            Util.writePictureData(picData, this);
        }

        public string AlbumName
        {
            get
            {
                return albumName;
            }
            set
            {
                albumName = value;
            }
        }

        public List<string> TrackPaths
        {
            get
            {
                return trackPaths;
            }
            set
            {
                trackPaths = value;
            }
        }
    }
}
