# FindArt
---------
![Sample Img](https://github.com/Apophenic/FindArt/blob/master/res/sample.jpg)
FindArt scans your music library for missing artwork, searches Google Images, and returns only the most relevant
results.

This is incredibly helpful if your music library contains a lot of obscure artists that don't have artwork listed
on typical ID3 metadata APIs (like the iTunes Music Store).

### How To Use It
-----------------
You can find the pre-compiled exe [here](https://github.com/Apophenic/FindArt/blob/master/exe)

Begin by defining your music library by selecting your music directory or using an iTunes Music Library.xml file.
_FindArt_ will begin scanning your library and perform an image search as soon as it finds any missing artwork.
You'll then be presented with the four most relevant results. Select the most appropriate artwork simply by clicking
it, and clicking "Next Album." If none of the artwork fetched is relevant, clicking "Load Next 4 Images" will fetch
the next set of results. If you'd rather not choose any artwork, you can deselect all artwork
by clicking "Deselect" and then "Next Album."
Selected artwork will be written directly to each track's ID3 tag for the given album.

It's recommended to use a folder structure like music_directory/artist/album/tracks.mp3 for your music library,
otherwise it may take awhile for _FindArt_ to fully read your library.