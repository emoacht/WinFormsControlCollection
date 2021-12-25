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

					//-------------------------------
					// Main bar (Vertical gradation)
					//-------------------------------
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
					LinearGradientBrush brushMainV = new LinearGradientBrush(rectMain, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);

					// Create color blend (3 colors, 3 points).
					ColorBlend cbMainV = new ColorBlend
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
					brushMainV.InterpolationColors = cbMainV;

					g.FillRectangle(brushMainV, rectMain);

					//----------------------------------------------
					// Main bar (Horizontal gradation, Transparent)
					//----------------------------------------------
					// Create linear gradient brush (Color defined here will not affect).
					LinearGradientBrush brushMainH = new LinearGradientBrush(rectMain, this.ForeColor, this.BackColor, LinearGradientMode.Horizontal);

					// Create color blend (4 colors, 4 points).
					ColorBlend cbMainH = new ColorBlend
					{
						Positions = new float[]
						{
							0.0f,
							0.35f,
							0.65f,
							1.0f
						},
						Colors = new Color[]
						{
							Color.FromArgb(200, this.ForeColor),
							Color.FromArgb(100, this.BackColor),
							Color.FromArgb(100, this.BackColor),
							Color.FromArgb(200, this.ForeColor)
						}
					};

					// Reflect color blend to blush.
					brushMainH.InterpolationColors = cbMainH;

					// Make gamma correction enabled.
					brushMainH.GammaCorrection = true;

					g.FillRectangle(brushMainH, rectMain);

					//--------------------------
					// Side edges (Transparent)
					//--------------------------
					Pen p = new Pen(Color.FromArgb(80, Color.White));

					g.DrawLine(p, 1, 1, 1, rectMain.Height); // Left
					g.DrawLine(p, rectMain.Width, 1, rectMain.Width, rectMain.Height); // Right

					//-------------------------
					// Highlight (Transparent)
					//-------------------------
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