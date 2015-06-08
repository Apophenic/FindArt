using System.Windows.Forms;
using Utezduyar.Windows.Forms;

namespace FindArt.UI
{
    /// <summary>
    /// Displays a panel with a circular marquee style progress bar
    /// and message
    /// </summary>
    public partial class ProgressControl : UserControl
    {
        public ProgressControl()
        {
            InitializeComponent();
            panelCircle.Controls.Add(new ProgressCircle());
        }

        public string Msg
        {
            get
            {
                return lblMsg.Text;
            }
            set
            {
                lblMsg.Text = value;
            }
        }
    }
}
