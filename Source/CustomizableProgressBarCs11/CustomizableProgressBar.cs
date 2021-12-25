using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomizableProgressBarCs
{
	// This control will not work properly when visual style is not enabled.
	public class CustomizableProgressBar : ProgressBar
	{
		public CustomizableProgressBar()
		{
			if (ProgressBarRenderer.IsSupported)
				this.SetStyle(ControlStyles.UserPaint, true);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// None (To avoid background being painted so as to prevent flickering).
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			using (Image offscreen = new Bitmap(this.Width, this.Height))
			{
				using (Graphics g = Graphics.FromImage(offscreen))
				{
					//---------
					// Outline
					//---------
					Rectangle rectBase = new Rectangle(Point.Empty, this.Size);

					// Draw outline of standard ProgressBar.
					if (ProgressBarRenderer.IsSupported)
						ProgressBarRenderer.DrawHorizontalBar(g, rectBase);

					//-------------------------------------------
					// Background bar (to overwrite vacant area)
					//-------------------------------------------
					// Deflate inner rectangle not to overwrite outline.
					rectBase.Inflate(new Size(-2, -2));

					// Create solid brush of same color as default SystemColor.ControlLightLight.
					SolidBrush brushBase = new SolidBrush(Color.FromArgb(251, 251, 251));

					g.FillRectangle(brushBase, rectBase);

					//----------
					// Main bar
					//----------
					Rectangle rectMain = new Rectangle(Point.Empty, this.Size);

					// Deflate inner rectangle not to overwrite outline.
					rectMain.Inflate(new Size(-1, -1));

					// Calculate length of bar.
					rectMain.Width = (int)Math.Truncate((double)rectMain.Width * this.Value / this.Maximum);
					if (rectMain.Width == 0)
					{
						// Minimum value must be 1 because rectangle cannot be drawn if width <= 0.
						rectMain.Width = 1;
					}

					// Create linear gradient brush (Color defined here will not affect).
					LinearGradientBrush brushMain = new LinearGradientBrush(rectMain, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);

					// Create color blend (3 colors, 3 points).
					ColorBlend cbMain = new ColorBlend
					{
						Positions = new float[]
						{
							0.0f,
							0.55f,
							1.0f
						},
						Colors = new Color[]
						{
							this.BackColor,
							this.ForeColor,
							this.BackColor
						}
					};

					// Reflect color blend to blush.
					brushMain.InterpolationColors = cbMain;

					g.FillRectangle(brushMain, rectMain);

					//--------------------------
					// Side edges (Transparent)
					//--------------------------
					Pen p = new Pen(Color.FromArgb(80, Color.White));

					g.DrawLine(p, 1, 1, 1, rectMain.Height); // Left
					g.DrawLine(p, rectMain.Width, 1, rectMain.Width, rectMain.Height); // Right

					//--------------------------------------
					// Highlight (Round shape, Transparent)
					//--------------------------------------
					Rectangle rectHighRound = new Rectangle(2, 1, rectMain.Width - 2, rectMain.Height);
					if (rectHighRound.Width <= 0)
					{
						// Minimum value must be 1 because rectangle cannot be drawn if width <= 0.
						rectHighRound.Width = 1;
					}

					// Prepare rectangle for path for blush (This path may be larger than area to fill).
					Rectangle rectHighRoundPath = new Rectangle(2, 1, rectHighRound.Width, (int)(rectHighRound.Height * 1.3));

					// Create path for blush.
					GraphicsPath gpHighRound = new GraphicsPath();
					gpHighRound.AddRectangle(rectHighRoundPath);

					// Create path gradient brush.
					PathGradientBrush brushHighRound = new PathGradientBrush(gpHighRound)
					{
						CenterColor = Color.FromArgb(70, Color.White),
						SurroundColors = new Color[]
						{
							Color.FromArgb(0, Color.White),
							Color.FromArgb(0, Color.White),
							Color.FromArgb(160, this.ForeColor),
							Color.FromArgb(160, this.ForeColor),
						}
					};

					g.FillRectangle(brushHighRound, rectHighRound);

					//------------------------------------
					// Highlight (Bar shape, Transparent)
					//------------------------------------
					Rectangle rectHighBar = new Rectangle(1, 1, rectMain.Width, (int)(Math.Truncate(rectMain.Height * 0.45)));

					// Create linear gradient brush (Color defined here will not affect).
					LinearGradientBrush brushHighBar = new LinearGradientBrush(rectHighBar, Color.White, Color.White, LinearGradientMode.Vertical);

					// Create color blend (3 colors, 3 points).
					ColorBlend cbHighBar = new ColorBlend
					{
						Positions = new float[]
						{
							0.0f,
							0.3f,
							1.0f
						},
						Colors = new Color[]
						{
							Color.FromArgb(120, Color.White),
							Color.FromArgb(110, Color.White),
							Color.FromArgb(80, Color.White)
						}
					};

					// Reflect color blend to blush.
					brushHighBar.InterpolationColors = cbHighBar;

					// Make gamma correction enabled.
					brushHighBar.GammaCorrection = true;

					g.FillRectangle(brushHighBar, rectHighBar);

					//------------------
					// Reflect to image
					//------------------
					e.Graphics.DrawImage(offscreen, Point.Empty);
				}
			}
		}
	}
}