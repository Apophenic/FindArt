using FindArt.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindArt
{
    /// <summary>
    /// For when an iTunes Music Library.xml file is
    /// selected. <see cref="Library.AbstractLibrary"/>
    /// </summary>
    public class ItunesLibrary : AbstractLibrary
    {
        ///Pulls file paths from library file
        public const string REGEX_FILEPATH = "(?<=Location\\<\\/key\\>\\<string\\>file\\:\\/\\/localhost\\/)((?!\\<).)*";
   //   public const string REGEX_MUSICFOLDER = "(?<=Music Folder\\<\\/key\\>\\<string\\>file\\:\\/\\/localhost\\/)((?!\\<).)*";

        public ItunesLibrary(string file)
            : base(file)
        { }

        protected override List<string> readFilePaths()
        {
            string[] lines = File.ReadAllLines(fileLocation);
            return lines.Where(l => Regex.IsMatch(l, REGEX_FILEPATH)).Select(l => formatFilePath(l)).ToList();
        }

        /// <summary>
        /// Trims xml keys and file://localhost from track paths
        /// ...iTunes has terrible uri formatting that doesn't
        /// match any known standard
        /// </summary>
        /// <param name="path">Track path</param>
        /// <returns>Proper windows file path</returns>
        private string formatFilePath(string path)
        {
            path = path.Substring(47);
            path = path.Substring(0, path.Length - 9);
            path = path.Replace("&#38;", "&");
            return Uri.UnescapeDataString(path);
        }

    }
}
