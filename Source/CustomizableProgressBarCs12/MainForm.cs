using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizableProgressBarCs
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			if (!ProgressBarRenderer.IsSupported)
				CustomizableProgressBar_Target.BackColor = SystemColors.Control;
		}

		private void TrackBar_Perc_Scroll(object sender, EventArgs e)
		{
			CustomizableProgressBar_Target.Value = TrackBar_Perc.Value;
		}

		private void Button_Turquoise_Click(object sender, EventArgs e)
		{
			// Turquoise
			SetColors(Color.MediumTurquoise, Color.DarkCyan);
		}

		private void Button_Blue_Click(object sender, EventArgs e)
		{
			// Blue
			SetColors(Color.LightSkyBlue, Color.DodgerBlue);
		}

		private void Button_Green_Click(object sender, EventArgs e)
		{
			// Green
			SetColors(Color.LimeGreen, Color.ForestGreen);
		}

		private void Button_Yellow_Click(object sender, EventArgs e)
		{
			// Yellow
			SetColors(Color.Khaki, Color.Gold);
		}

		private void Button_Red_Click(object sender, EventArgs e)
		{
			// Red
			SetColors(Color.Red, Color.Firebrick);
		}

		private void SetColors(Color backColor, Color foreColor)
		{
			if (ProgressBarRenderer.IsSupported)
			{
				CustomizableProgressBar_Target.BackColor = backColor;
				CustomizableProgressBar_Target.ForeColor = foreColor;
			}
			else
			{
				CustomizableProgressBar_Target.BackColor = SystemColors.Control;
				CustomizableProgressBar_Target.ForeColor = backColor;
			}
		}
	}
}