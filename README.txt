FindArt examines your music library for missing artwork, searches for the missing album art on Google Images, and returns the most relevant results. This is incredibly helpful if your music library contains a lot of obscure artists that don't have artwork listed on typical ID3 metadata APIs (like the iTunes Music Store).

The user can then select the most appropriate artwork simply by clicking it, and clicking "Next Album." If none of the artwork fectched is relevant, clicking "Load Next 4 Images" will fetch the next set of results from Google Images. If you'd rather not choose new artwork, you can deselect all artwork by clicking "Deselect" and then "Next Album." Selected artwork will be written directly to each track's ID3 tag for the given album.

Currently supports choosing a music directory or an iTunes Library xml file to represent the music library.

It's recommended to use a folder structure like music_directory/artist/album/tracks.mp3 for your music library, otherwise it may take awhile for FindArt to fully read your library.