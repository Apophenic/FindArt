using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using TagLib;

namespace FindArt
{
    /// <summary>
    /// Utility methods.
    /// </summary>
   public static class Util
   {
       public static byte[] convertImageToByteArray(Image img)
       {
           using(MemoryStream ms = new MemoryStream())
           {
               img.Save(ms, ImageFormat.Jpeg);
               return ms.ToArray();
           }
       }

       public static void writePictureData(ByteVector data, Album album)
       {
           foreach (string path in album.TrackPaths)
           {
               writePictureData(data, path);
           }
       }

       public static void writePictureData(ByteVector data, string path)
       {
           TagLib.File file = TagLib.File.Create(path);
           Picture pic = new Picture();
           pic.Data = data;
           file.Tag.Pictures = new IPicture[1] { pic };
           file.Save();
       }

       public static ArtistAlbumPair getArtistAndAlbumFromTag(string path)
       {
           ArtistAlbumPair aaPair;
           TagLib.File file = TagLib.File.Create(path);
           aaPair.artist = file.Tag.FirstAlbumArtist;
           aaPair.album = file.Tag.Album;
           return aaPair;
       }

       public static ArtistAlbumPair getArtistAndAlbumFromPath(string path)
       {
           ArtistAlbumPair aaPair;
           string[] temp = path.Split(path[2]); //split by / or \, depending on formatting
           aaPair.artist = temp[temp.Length - 3];
           aaPair.album = temp[temp.Length - 2];
           return aaPair;
       }

       public static Bitmap ResizeImage(Image image, int width, int height)
       {
           var destRect = new Rectangle(0, 0, width, height);
           var destImage = new Bitmap(width, height);

           destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

           using (var graphics = Graphics.FromImage(destImage))
           {
               graphics.CompositingMode = CompositingMode.SourceCopy;
               graphics.CompositingQuality = CompositingQuality.HighQuality;
               graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
               graphics.SmoothingMode = SmoothingMode.HighQuality;
               graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

               using (var wrapMode = new ImageAttributes())
               {
                   wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                   graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
               }
           }
           return destImage;
       }

       public static void removeAllArtwork(ItunesLibrary lib)
       {
           TagLib.Picture pic = new TagLib.Picture();
           foreach(KeyValuePair<string, Artist> artistEntry in lib.Artists)
           {
               foreach(KeyValuePair<string, Album> albumEntry in artistEntry.Value.Albums)
               {
                   foreach(string path in albumEntry.Value.TrackPaths)
                   {
                       TagLib.File file = TagLib.File.Create(path);
                       file.Tag.Pictures = null;
                       file.Save();
                   }
               }
           }
       }

       /// <summary>
       /// Compares two strings and determines a score representing
       /// their similarity. 0 is no similarities, 1 is the same string.
       /// </summary>
       /// <param name="string1">The first string</param>
       /// <param name="string2">The second string</param>
       /// <returns>Similarity score</returns>
       public static float checkStringDistance(string string1, string string2)
       {
           if (string1 == null || string2 == null)
           {
               return (float)0.5;
           }

           float score = 0;

           List<string> charactersString1 = new List<string>();
           List<string> charactersString2 = new List<string>();

           for (int i = 0; i < string1.Length; i++)
           {
               string aCharacter = Char.ToString(string1[i]);
               charactersString1.Add(aCharacter);
           }

           for (int i = 0; i < string2.Length; i++)
           {
               string aCharacter = Char.ToString(string2[i]);
               charactersString2.Add(aCharacter);
           }

           bool differentSize = false;
           List<string> arrayLargo = new List<string>();
           List<string> arrayCorto = new List<string>();
           if (charactersString1.Count < charactersString2.Count)
           {
               arrayLargo = charactersString2;
               arrayCorto = charactersString1;
               differentSize = true;
           }
           else
           {
               if (charactersString2.Count < charactersString1.Count)
               {
                   arrayLargo = charactersString1;
                   arrayCorto = charactersString2;
                   differentSize = true;
               }
               else
               {
                   if (charactersString2.Count == charactersString1.Count)
                   {
                       for (int i = 0; i < charactersString1.Count; i++)
                       {

                           string elementoS1 = charactersString1[i];
                           string elementoS2 = charactersString2[i];

                           if (elementoS1.Equals(elementoS2, StringComparison.OrdinalIgnoreCase))
                           {
                               score++;
                           }
                           else
                           {
                               if (0 < i)
                               {

                                   string elementoS1Past = charactersString1[i - 1];
                                   string elementoS2Past = charactersString2[i - 1];

                                   if (elementoS1Past.Equals(elementoS2, StringComparison.OrdinalIgnoreCase)
                                       && elementoS1.Equals(elementoS2Past, StringComparison.OrdinalIgnoreCase))
                                   {
                                       score++;
                                   }

                               }
                           }
                       }
                   }
                   else
                   {
                       //TODO: Throw error
                   }
                   score = score / charactersString1.Count;
               }
           }

           if (differentSize)
           {
               int indice = 0;
               for (int i = 0; i < arrayCorto.Count; i++)
               {
                   string elementoS1 = arrayLargo[i];
                   string elementoS2 = arrayCorto[i];

                   if (elementoS1.Equals(elementoS2, StringComparison.OrdinalIgnoreCase))
                   {
                       score = score + 1;
                   }
                   else
                   {
                       bool switched = false;
                       if (i + 1 < arrayCorto.Count)
                       {
                           string elementoS1Future = arrayLargo[i + 1];
                           string elementoS2Future = arrayCorto[i + 1];
                           if (elementoS1Future.Equals(elementoS2, StringComparison.OrdinalIgnoreCase)
                                   && elementoS1.Equals(elementoS2Future, StringComparison.OrdinalIgnoreCase))
                           {
                               score = score + 1;
                               i = i + 1;
                               switched = true;
                           }
                       }
                       if (!switched)
                       {
                           arrayLargo.RemoveAt(i);
                           indice = i;
                           i = i - 1;
                       }
                   }
                   if (arrayLargo.Count == arrayCorto.Count)
                   {
                       break;
                   }
               }
               if (arrayLargo.Count == arrayCorto.Count)
               {
                   for (int i = indice; i < charactersString1.Count && i < charactersString2.Count; i++)
                   {
                       string elementoS1 = arrayLargo[i];
                       string elementoS2 = arrayCorto[i];
                       if (elementoS1.Equals(elementoS2, StringComparison.OrdinalIgnoreCase))
                       {
                           score = score + 1;
                       }
                       else
                       {
                           if (0 < i)
                           {
                               string elementoS1Past = charactersString1[i - 1];
                               string elementoS2Past = charactersString2[i - 1];
                               if (elementoS1Past.Equals(elementoS2, StringComparison.OrdinalIgnoreCase)
                                       && elementoS1.Equals(elementoS2Past, StringComparison.OrdinalIgnoreCase))
                               {
                                   score++;
                               }
                           }
                       }
                   }
               }
               int normalize;
               if (charactersString2.Count <= charactersString1.Count)
               {
                   normalize = charactersString1.Count;
               }
               else
               {
                   normalize = charactersString2.Count;
               }
               score = score / normalize;
           }
           return score;
       }

    }
}
