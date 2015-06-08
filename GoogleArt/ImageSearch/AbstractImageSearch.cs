using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FindArt.ImageSearch
{
    /// <summary>
    /// Constructs a search url using the supplied artist and
    /// album name, performs search, and saves a queue
    /// of image result urls scraped from the html.
    /// </summary>
    public abstract class AbstractImageSearch
    {
        public const string USER_AGENT = "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0; H010818)";

        ///Minimum time between search host queries (doesn't effect img queries)
        public abstract int htmlGetDelay {get;}

        public abstract string imageSearchUrlFormat {get;}
        public abstract string regexForImageUrls {get;}

        ///Constructed search URL (using imageSearchUrlFormat, artist, album)
        protected string searchUrl;

        protected Queue<string> imgUrls = new Queue<string>();

        public AbstractImageSearch(string artist, string album)
        {
            artist = artist.Replace(" ", "+");
            album = album.Replace(" ", "+");
            this.searchUrl = String.Format(imageSearchUrlFormat, artist, album);
            findImageUrlsFromSearch();
        }

        /// <summary>
        /// Gets an image from the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="width">The preferred width.</param>
        /// <param name="height">The preferred height.</param>
        /// <returns></returns>
        public static Image getImageFromUrl(string url, int width, int height)
        {
            Image img = new Bitmap(width, height);
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("User-Agent", USER_AGENT); //User agent required for proper response format
                    img = Bitmap.FromStream(client.OpenRead(url));
                    if(img.Height != height || img.Width != width)
                    {
                        img = Util.ResizeImage(img, width, height);
                    }
                }
                catch
                {
                    //MessageBox.Show("Failed to get image from => " + url); //TODO: Less intrusive warning
                }
            }
            return img;
        }

        /// <summary>
        /// Scraps the search url's html using the regex
        /// <paramref name="regexForImageUrls"/> and saves
        /// image urls to <paramref name="imgUrls"/>.
        /// </summary>
        protected void findImageUrlsFromSearch()
        {
            using (WebClient client = new WebClient())
            {
                try
                {   //TODO: Make sure http response OK first
                    client.Headers.Add("User-Agent", USER_AGENT);
                    string htmlCode = client.DownloadString(searchUrl);

                    MatchCollection mc = Regex.Matches(htmlCode, regexForImageUrls);
                    foreach (Match m in mc)
                    {
                        imgUrls.Enqueue(m.ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to read search url => " + searchUrl);
                }
            }
            System.Threading.Thread.Sleep(htmlGetDelay);
        }

        public Queue<string> ImgUrls
        {
            get
            {
                return imgUrls;
            }
            set
            {
                imgUrls = value;
            }
        }
    }
}
