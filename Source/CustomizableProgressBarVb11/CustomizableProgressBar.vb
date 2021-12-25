Imports System.Drawing
Imports System.Drawing.Drawing2D

'This control will not work properly when visual style is not enabled.
Public Class CustomizableProgressBar
	Inherits ProgressBar

	Public Sub New()
		If (ProgressBarRenderer.IsSupported) Then
			Me.SetStyle(ControlStyles.UserPaint, True)
		End If
	End Sub

	Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
		'None (To avoid background being painted so as to prevent flickering).
	End Sub

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		Using offscreen As Image = New Bitmap(Me.Width, Me.Height)
			Using g As Graphics = Graphics.FromImage(offscreen)
				'---------
				' Outline
				'---------
				Dim rectBase As New Rectangle(Point.Empty, Me.Size)

				'Draw outline of standard ProgressBar.
				If (ProgressBarRenderer.IsSupported) Then
					ProgressBarRenderer.DrawHorizontalBar(g, rectBase)
				End If

				'-------------------------------------------
				' Background bar (to overwrite vacant area)
				'-------------------------------------------
				'Deflate inner rectangle not to overwrite outline.
				rectBase.Inflate(New Size(-2, -2))

				'Create solid brush of same color as default SystemColor.ControlLightLight.
				Dim brushBase As New SolidBrush(Color.FromArgb(251, 251, 251))

				g.FillRectangle(brushBase, rectBase)

				'----------
				' Main bar
				'----------
				Dim rectMain As New Rectangle(Point.Empty, Me.Size)

				'Deflate inner rectangle not to overwrite outline.
				rectMain.Inflate(New Size(-1, -1))

				'Calculate length of bar.
				rectMain.Width = Convert.ToInt32(Math.Truncate(Convert.ToDouble(rectMain.Width) * Me.Value / Me.Maximum))
				If (rectMain.Width = 0) Then
					'Minimum value must be 1 because rectangle cannot be drawn if width <= 0.
					rectMain.Width = 1
				End If

				'Create linear gradient brush (Color defined here will not affect).
				Dim brushMain As New LinearGradientBrush(rectMain, Me.BackColor, Me.ForeColor, LinearGradientMode.Vertical)

				'Create color blend (3 colors, 3 points).
				Dim cbMain As New ColorBlend With
				{
					.Positions = New Single() {0.0F,
											   0.55F,
											   1.0F},
					.Colors = New Color() {Me.BackColor,
										   Me.ForeColor,
										   Me.BackColor}
				}

				'Reflect color blend to blush.
				brushMain.InterpolationColors = cbMain

				g.FillRectangle(brushMain, rectMain)

				'--------------------------
				' Side edges (Transparent)
				'--------------------------
				Dim p As New Pen(Color.FromArgb(80, Color.White))

				g.DrawLine(p, 1, 1, 1, rectMain.Height)	'Left
				g.DrawLine(p, rectMain.Width, 1, rectMain.Width, rectMain.Height) 'Right

				'--------------------------------------
				' Highlight (Round shape, Transparent)
				'--------------------------------------
				Dim rectHighRound As New Rectangle(2, 1, rectMain.Width - 2, rectMain.Height)
				If (rectHighRound.Width <= 0) Then
					'Minimum value must be 1 because rectangle cannot be drawn if width <= 0.
					rectHighRound.Width = 1
				End If

				'Prepare rectangle for path for blush (This path may be larger than area to fill).
				Dim rectHighRoundPath As New Rectangle(2, 1, rectHighRound.Width, Convert.ToInt32(rectHighRound.Height * 1.3))

				'Create path for blush.
				Dim gpHighRound As New GraphicsPath
				gpHighRound.AddRectangle(rectHighRoundPath)

				'Create path gradient brush.
				Dim brushHighRound As New PathGradientBrush(gpHighRound) With
				{
					.CenterColor = Color.FromArgb(70, Color.White),
					.SurroundColors = New Color() {Color.FromArgb(0, Color.White),
												   Color.FromArgb(0, Color.White),
												   Color.FromArgb(160, Me.ForeColor),
												   Color.FromArgb(160, Me.ForeColor)}
				}

				g.FillRectangle(brushHighRound, rectHighRound)

				'------------------------------------
				' Highlight (Bar shape, Transparent)
				'------------------------------------
				Dim rectHighBar As New Rectangle(1, 1, rectMain.Width, Convert.ToInt32(Math.Truncate(rectMain.Height * 0.45)))

				'Create linear gradient brush (Color defined here will not affect).
				Dim brushHighBar As New LinearGradientBrush(rectHighBar, Color.White, Color.White, LinearGradientMode.Vertical)

				'Create color blend (3 colors, 3 points).
				Dim cbHighBar As New ColorBlend With
				{
					.Positions = New Single() {0.0F,
											   0.3F,
											   1.0F},
					.Colors = New Color() {Color.FromArgb(120, Color.White),
										   Color.FromArgb(110, Color.White),
										   Color.FromArgb(80, Color.White)}
				}

				'Reflect color blend to blush.
				brushHighBar.InterpolationColors = cbHighBar

				'Make gamma correction enabled.
				brushHighBar.GammaCorrection = True

				g.FillRectangle(brushHighBar, rectHighBar)

				'------------------
				' Reflect to image
				'------------------
				e.Graphics.DrawImage(offscreen, Point.Empty)
			End Using
		End Using
	End Sub

End Class