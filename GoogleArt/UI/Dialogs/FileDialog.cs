using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FindArt
{
    /// <summary>
    /// Creates a dialog box with a file browser allowing
    /// folder or file path selection. The selected path is saved
    /// and used to determine what library type should be created.
    /// </summary>
    public partial class FileDialog : Form
    {
        private LibraryFileType libraryType;

        public enum LibraryFileType {
            iTunes, Directory
        }

        public FileDialog()
        {
            InitializeComponent();

            btnBrowse.MouseClick += new MouseEventHandler(browse);
            btnBegin.MouseClick += new MouseEventHandler(begin);
            btnCancel.MouseClick += new MouseEventHandler(close);
        }

        /// <summary>
        /// Detects the type of the library from the selected path.
        /// </summary>
        /// <returns>true if valid detection successful</returns>
        private bool detectLibraryType()
        {
            try
            {
                FileAttributes attr = File.GetAttributes(LibraryFile);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    libraryType = LibraryFileType.Directory;
                }
                else
                {
                    if(!Regex.IsMatch(Path.GetFileName(LibraryFile).ToLower(), "itunes (music)? library\\.xml"))
                    {
                        throw new IOException();
                    }
                    libraryType = LibraryFileType.iTunes;
                }
            } 
            catch
            {
                MessageBox.Show("Invalid file selected");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Opens file or folder browser, based on selected
        /// library type.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void browse(object sender, EventArgs e)
        {
            if(rdbtbnItunes.Checked)
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "iTunes * Library.xml |*.xml"; //valid files: itunes library.xml, itunes music library.xml
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    LibraryFile = fileDialog.FileName;
                }
            }
            else if(rdbtnDir.Checked)
            {
                var folderDialog = new FolderBrowserDialog();
                if(folderDialog.ShowDialog() == DialogResult.OK)
                {
                    LibraryFile = folderDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Closes the blocking instance of FileDialog
        /// once a valid file/folder path is confirmed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void begin(object sender, EventArgs e)
        {
            if(detectLibraryType())
            {
                this.Close();
            }
        }

        void close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string LibraryFile
        {
            get
            {
                return txtFile.Text;
            }
            set
            {
                txtFile.Text = value;
            }
        }

        public LibraryFileType LibraryType
        {
            get
            {
                return libraryType;
            }
            set
            {
                libraryType = value;
            }
        }
    }
}
