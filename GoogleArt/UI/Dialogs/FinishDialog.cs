using System;
using System.Windows.Forms;

namespace FindArt.Dialogs
{
    /// <summary>
    /// Thrown when library has been fully read and
    /// all missing albums have been addressed.
    /// </summary>
    public partial class FinishDialog : Form
    {
        public FinishDialog()
        {
            InitializeComponent();
            btnOk.MouseClick += new MouseEventHandler(close);
        }

        void close(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
