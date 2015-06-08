using FindArt.ImageSearch;

namespace FindArt
{
    /// <summary>
    /// <see cref="ImageSearch.AbstractImageSearch"/>
    /// </summary>
    class GoogleImageSearch : AbstractImageSearch
    {
        public override string imageSearchUrlFormat { get { return "https://www.google.com/search?q={0}+{1}&tbm=isch"; } }
        public override string regexForImageUrls { get { return "(?<=http://www\\.google\\.com/imgres\\?imgurl=)"
                                                                + "http(s)?://((?!\\&amp;imgrefurl).)*.jpg"; } }
        public override int htmlGetDelay { get { return 1000; } }


        public GoogleImageSearch(string artist, string album)
            : base(artist, album)
        { }
    }
}
