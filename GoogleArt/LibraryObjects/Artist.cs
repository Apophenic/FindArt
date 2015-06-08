using System.Collections.Generic;

namespace FindArt
{
    /// <summary>
    /// Created using literal name, stores
    /// respective album objects
    /// </summary>
    public class Artist
    {
        private string artistName;

        private Dictionary<string, Album> albums = new Dictionary<string, Album>();

        public Artist()
        { }

        public Artist(string name)
        {
            this.artistName = name;
        }

        public void addAlbum(Album album)
        {
            albums.Add(album.AlbumName.ToLower(), album);
        }

        public string ArtistName
        {
            get
            {
                return artistName;
            }
            set
            {
                artistName = value;
            }
        }

        public Dictionary<string, Album> Albums
        {
            get
            {
                return albums;
            }
            set
            {
                albums = value;
            }
        }
    }
}
