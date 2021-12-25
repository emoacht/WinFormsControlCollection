using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircleProgressBarCs
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
#if (!DEBUG)
			this.Text = Application.ProductName;
#endif

			// Set font of CircleProgressBar.
			circleProgressBar_Target.Num.Font = new Font("Arial", 80, FontStyle.Bold, GraphicsUnit.Pixel);
			circleProgressBar_Target.Unit.Font = new Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel);
		}

		private void trackBar_Perc_Scroll(object sender, EventArgs e)
		{
			circleProgressBar_Target.Value = Convert.ToInt32((double)trackBar_Perc.Value / trackBar_Perc.Maximum * 100);
		}
	}
}