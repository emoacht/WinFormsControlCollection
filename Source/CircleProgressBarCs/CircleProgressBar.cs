
namespace CircleProgressBarCs
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Drawing.Imaging;
	using System.Drawing.Text;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;

	// This Control will not work properly when Visual style is not enabled.
	public class CircleProgressBar : ProgressBar
	{
		public class PercLabel : Label
		{
			// Direction
			private enum Direction
			{
				Horizontal,
				Vertical
			}

			// Distance from top-left corner
			private enum Distance
			{
				Near,
				Far
			}

			public PercLabel()
			{
				this.Text = "%";
			}

			public override Font Font
			{
				get { return base.Font; }
				set
				{
					base.Font = value;
					GetSizeHorizontal(value);
					GetSizeVertical(value);
				}
			}

			// Vertical margin and height
			public int TextTop { get; set; }
			public int TextBottom { get; set; }

			public int GetTextHeight()
			{
				return TextBottom - TextTop;
			}

			private void GetSizeVertical(Font fnt)
			{
				Dictionary<Distance, int> result = GetFontString(fnt, "0123456789%", Direction.Vertical);

				TextTop = result[Distance.Near];
				TextBottom = result[Distance.Far];
			}

			// Horizontal margin and width			
			public int[] TextLeft
			{
				get { return _textLeft; }
			}
			private readonly int[] _textLeft = new int[102];

			public int[] TextRight
			{
				get { return _textRight; }
			}
			private readonly int[] _textRight = new int[102];

			public int GetTextWidth(int num)
			{
				return TextRight[num] - TextLeft[num];
			}

			private void GetSizeHorizontal(Font fnt)
			{
				Dictionary<Distance, int> digitSingle = GetFontString(fnt, "9", Direction.Horizontal);
				Dictionary<Distance, int> digitDouble = GetFontString(fnt, "99", Direction.Horizontal);
				Dictionary<Distance, int> digitTriple = GetFontString(fnt, "100", Direction.Horizontal);

				for (int i = 0; i <= 101; i++)
				{
					Dictionary<Distance, int> result;

					if (i <= 9) // 0 <= percentage number <= 9
					{
						result = digitSingle;
					}
					else if (i <= 99) // 10 <= percentage number <= 99
					{
						result = digitDouble;
					}
					else if (i == 100) // Percentage number = 100
					{
						result = digitTriple;
					}
					else // Percentage unit
					{
						result = GetFontString(fnt, this.Text, Direction.Horizontal);
					}

					TextLeft[i] = result[Distance.Near];
					TextRight[i] = result[Distance.Far];
				}
			}

			// Get margin and size of designated font and string.
			private Dictionary<Distance, int> GetFontString(Font fnt, string str, Direction order)
			{
				// Get rectangle size required to draw string.
				Size rectSize = TextRenderer.MeasureText(str, fnt);

				using (Bitmap bmp = new Bitmap(rectSize.Width, rectSize.Height))
				using (Graphics g = Graphics.FromImage(bmp))
				{
					// Draw string (characters).
					g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
					g.DrawString(str, fnt, Brushes.Black, Point.Empty); // Any brush color will do.

					// Convert bitmap data to byte array.
					BitmapData bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size),
													  ImageLockMode.ReadOnly,
													  PixelFormat.Format32bppRgb);

					byte[] bytBuf = new byte[bmpData.Stride * bmpData.Height];
					Marshal.Copy(bmpData.Scan0, bytBuf, 0, bytBuf.Length);

					// Prepare dictionary to hold number of pixel(s) which has a part of character in each line.
					Dictionary<int, int> pxAlpha = new Dictionary<int, int>();

					switch (order)
					{
						case Direction.Horizontal: // Horizontal margin and width
							for (int x = 0; x <= bmp.Width - 1; x++)
							{
								int pxBuf = 0;

								for (int y = 0; y <= bmp.Height - 1; y++)
								{
									// Check alpha component of pixel to determine if it has a part of character.
									if (bytBuf[(y * bmp.Width + x) * 4 + 3] != 0) pxBuf++;
								}

								pxAlpha.Add(x, pxBuf);
							}
							break;

						case Direction.Vertical: // Vertical margin and width
							for (int y = 0; y <= bmp.Height - 1; y++)
							{
								int pxBuf = 0;

								for (int x = 0; x <= bmp.Width - 1; x++)
								{
									// Check alpha component of pixel to determine if it has a part of character.
									if (bytBuf[(y * bmp.Width + x) * 4 + 3] != 0) pxBuf++;
								}

								pxAlpha.Add(y, pxBuf);
							}
							break;
					}

					// Get lines that have parts of characters.
					int[] pxBlack = pxAlpha.Where(n => 0 < n.Value).Select(n => n.Key).ToArray();

					// Find the nearest line (left or top).
					int lineNearest = pxBlack[0];

					// Find the farthest line (right or bottom).
					int lineFarthest = pxBlack[pxBlack.Length - 1];

					return new Dictionary<Distance, int>
					{ 
						{ Distance.Near, lineNearest },
						{ Distance.Far, lineFarthest }
					};
				}
			}
		}

		public PercLabel Num // Percentage number (string)
		{
			get { return _num; }
		}
		private readonly PercLabel _num = new PercLabel();

		public PercLabel Unit // Percentage unit
		{
			get { return _unit; }
		}
		private readonly PercLabel _unit = new PercLabel();

		public int Thickness // Thickness of arc
		{
			get { return _thickness; }
			set { _thickness = value; }
		}
		private int _thickness = 50;

		private Color BaseColor; // BackColor of parent Control or Form

		public CircleProgressBar()
		{
			if (ProgressBarRenderer.IsSupported) this.SetStyle(ControlStyles.UserPaint, true);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			// None (To avoid background being painted so as to prevent flickering).
		}

		private bool isInitial = true;

		protected override void OnPaint(PaintEventArgs e)
		{
			//==========================
			// Prepare for initial draw
			//==========================
			if (isInitial)
			{
				isInitial = false;

				// Set this Control's region (this.Size cannot be correctly obtained in constructor).
				using (GraphicsPath p = new GraphicsPath())
				{
					p.AddEllipse(GetRectangle(0));
					this.Region = new Region(p);
				}

				// Set this Control's BaseColor.
				BaseColor = (this.Parent ?? this.FindForm()).BackColor;

				// Set font of Num and Unit (to avoid exception at DrawString).
				if (Num.Font == null)
				{
					Num.Font = new Font(this.FindForm().Font.FontFamily,
										Convert.ToInt32(this.Size.Width * 0.3),
										FontStyle.Bold,
										GraphicsUnit.Pixel);
				}

				if (Unit.Font == null)
				{
					Unit.Font = new Font(this.FindForm().Font.FontFamily,
										 Convert.ToInt32(this.Size.Width * 0.15),
										 FontStyle.Bold,
										 GraphicsUnit.Pixel);
				}
			}

			//=======================
			// Set percentage number
			//=======================
			Num.Text = Convert.ToString(this.Value);
			SetLocations(this.Value, this);

			//=======================
			// Draw circles and text
			//=======================
			using (Image bmp = new Bitmap(this.Width, this.Height))
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;

				//--------------------------------------------------
				// Base circle (for antialiasing background circle)
				//--------------------------------------------------
				using (SolidBrush brushBase = new SolidBrush(this.BaseColor))
				{
					g.FillEllipse(brushBase, GetRectangle(0));
				}

				//-------------------
				// Background circle
				//-------------------
				using (SolidBrush brushBack = new SolidBrush(this.BackColor))
				{
					g.FillEllipse(brushBack, GetRectangle(1));
				}

				using (SolidBrush brushFore = new SolidBrush(this.ForeColor))
				{
					//-----
					// Arc
					//-----
					float startAngle = -90.0F;
					float sweepAngle = Convert.ToSingle(3.6 * this.Value);

					using (GraphicsPath p = new GraphicsPath())
					{
						p.AddArc(GetRectangle(4), startAngle, sweepAngle);
						p.AddArc(GetRectangle(Thickness + 4), startAngle + sweepAngle, -sweepAngle);
						g.FillPath(brushFore, p);
					}

					//-------------
					// Center text
					//-------------
					g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
					g.DrawString(Num.Text, Num.Font, brushFore, Num.Location);
					g.DrawString(Unit.Text, Unit.Font, brushFore, Unit.Location);
				}

				// Reflect to image.
				e.Graphics.DrawImage(bmp, Point.Empty);
			}
		}

		// Get rectangle with designated offset.
		private Rectangle GetRectangle(int offset)
		{
			return new Rectangle(offset, offset, this.Width - offset * 2, this.Height - offset * 2);
		}

		// Set locations of Num and Unit.
		private void SetLocations(int value, Control sea)
		{
			// Prepare "isle" Control which can encompass Num and Unit.
			Control isle = new Control();
			isle.Width = Num.GetTextWidth(value) + Unit.GetTextWidth(101);
			isle.Height = Math.Max(Num.GetTextHeight(), Unit.GetTextHeight());

			// Place "isle" Control at the center of "sea" Control.
			isle.Location = new Point(Convert.ToInt32((sea.Width - isle.Width) / 2.0),
									  Convert.ToInt32((sea.Height - isle.Height) / 2.0));

			// Translate location of "isle" to locations of Num and Unit.
			Num.Location = new Point(isle.Location.X - Num.TextLeft[value],
									 isle.Location.Y + isle.Height - Num.TextBottom);
			Unit.Location = new Point(isle.Location.X + Num.GetTextWidth(value),
									  isle.Location.Y + isle.Height - Unit.TextBottom);
		}
	}
}