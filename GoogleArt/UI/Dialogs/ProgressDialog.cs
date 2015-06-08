using System.Windows.Forms;

namespace FindArt
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
            this.TopLevel = true;
            setIndeterminate();
        }

        public ProgressDialog(string message)
            : this()
        {
            this.Msg = message;
        }

        public ProgressDialog(int min, int max)
            : this()
        {
            setDeterminate(min, max);
        }

        public ProgressDialog(int min, int max, string message) 
            : this(message)
        {
            setDeterminate(min, max);
        }

        public void updateImmediately(int value)
        {
            pbarProgress.Value = value;
            lblMsg.Refresh();
            pbarProgress.PerformStep();
        }

        public void updateLazily(int value)
        {
            if(value % 50 == 0)
            {
                updateImmediately(value);
            }
        }

        public void setDeterminate(int min, int max)
        {
            pbarProgress.Style = ProgressBarStyle.Continuous;
            pbarProgress.Minimum = min;
            pbarProgress.Maximum = max;   
        }

        public void setIndeterminate()
        {
            pbarProgress.Style = ProgressBarStyle.Marquee;
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
                lblMsg.Refresh();
            }
        }
    }
}
