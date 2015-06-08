using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindArt.Library
{
    /// <summary>
    /// For when a folder path containing subdirs of music
    /// is selected. <see cref="Library.AbstractLibrary"/>
    /// </summary>
    class DirectoryLibrary : AbstractLibrary
    {
        public DirectoryLibrary(string directory)
            : base(directory)
        { }

        protected override List<string> readFilePaths()
        {
            return Directory.GetFiles(fileLocation, "*.*", SearchOption.AllDirectories)
                .Where(s => EXTS.Any(e => s.EndsWith(e))).ToList();
        }
    }
}
