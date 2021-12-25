Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

'This Control will not work properly when Visual style is not enabled.
Public Class CircleProgressBar
	Inherits ProgressBar

	Public Class PercLabel
		Inherits Label

		'Direction
		Private Enum Direction
			Horizontal
			Vertical
		End Enum

		'Distance from top-left corner
		Private Enum Distance
			Near
			Far
		End Enum

		Public Sub New()
			Me.Text = "%"
		End Sub

		Public Overrides Property Font As Font
			Get
				Return MyBase.Font
			End Get
			Set(value As Font)
				MyBase.Font = value
				GetSizeHorizontal(value)
				GetSizeVertical(value)
			End Set
		End Property

		'Vertical margin and height
		Public Property TextTop As Integer
		Public Property TextBottom As Integer

		Public ReadOnly Property TextHeight As Integer
			Get
				Return TextBottom - TextTop
			End Get
		End Property

		Private Sub GetSizeVertical(fnt As Font)
			Dim result As Dictionary(Of Distance, Integer) = GetFontString(fnt, "0123456789%", Direction.Vertical)

			TextTop = result(Distance.Near)
			TextBottom = result(Distance.Far)
		End Sub

		'Horizontal margin and width
		Public ReadOnly Property TextLeft As Integer()
			Get
				Return _textLeft
			End Get
		End Property
		Private ReadOnly _textLeft As Integer() = New Integer(101) {}

		Public ReadOnly Property TextRight As Integer()
			Get
				Return _textRight
			End Get
		End Property
		Private ReadOnly _textRight As Integer() = New Integer(101) {}

		Public ReadOnly Property TextWidth(num As Integer) As Integer
			Get
				Return TextRight(num) - TextLeft(num)
			End Get
		End Property

		Private Sub GetSizeHorizontal(fnt As Font)
			Dim digitSingle As Dictionary(Of Distance, Integer) = GetFontString(fnt, "9", Direction.Horizontal)
			Dim digitDouble As Dictionary(Of Distance, Integer) = GetFontString(fnt, "99", Direction.Horizontal)
			Dim digitTriple As Dictionary(Of Distance, Integer) = GetFontString(fnt, "100", Direction.Horizontal)

			For i = 0 To 101
				Dim result As Dictionary(Of Distance, Integer)

				Select Case i
					Case Is <= 9 '0 <= percentage number <= 9
						result = digitSingle

					Case Is <= 99 '10 <= percentage number <= 99
						result = digitDouble

					Case Is = 100 'Percentage number = 100
						result = digitTriple

					Case Else 'Percentage unit
						result = GetFontString(fnt, Me.Text, Direction.Horizontal)
				End Select

				TextLeft(i) = result(Distance.Near)
				TextRight(i) = result(Distance.Far)
			Next
		End Sub

		'Get margin and size of designated font and string.
		Private Function GetFontString(fnt As Font, str As String, order As Direction) As Dictionary(Of Distance, Integer)
			'Get rectangle size required to draw string.
			Dim rectSize As Size = TextRenderer.MeasureText(str, fnt)

			Using bmp As New Bitmap(rectSize.Width, rectSize.Height)
				Using g As Graphics = Graphics.FromImage(bmp)
					'Draw string (characters).
					g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
					g.DrawString(str, fnt, Brushes.Black, Point.Empty) 'Any brush color will do.

					'Convert bitmap data to byte array.
					Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(Point.Empty, bmp.Size),
															 ImageLockMode.ReadOnly,
															 PixelFormat.Format32bppRgb)

					Dim bytBuf As Byte() = New Byte(bmpData.Stride * bmpData.Height - 1) {}
					Marshal.Copy(bmpData.Scan0, bytBuf, 0, bytBuf.Length)

					'Prepare dictionary to hold number of pixel(s) which has a part of character in each line.
					Dim pxAlpha As New Dictionary(Of Integer, Integer)

					Select Case order
						Case Direction.Horizontal 'Horizontal margin and width
							For x = 0 To bmp.Width - 1
								Dim pxBuf As Integer = 0

								For y = 0 To bmp.Height - 1
									'Check alpha component of pixel to determine if it has a part of character.
									If (bytBuf((y * bmp.Width + x) * 4 + 3) <> 0) Then pxBuf += 1
								Next

								pxAlpha.Add(x, pxBuf)
							Next

						Case Direction.Vertical	'Vertical margin and width
							For y = 0 To bmp.Height - 1
								Dim pxBuf As Integer = 0

								For x = 0 To bmp.Width - 1
									'Check alpha component of pixel to determine if it has a part of character.
									If (bytBuf((y * bmp.Width + x) * 4 + 3) <> 0) Then pxBuf += 1
								Next

								pxAlpha.Add(y, pxBuf)
							Next
					End Select

					'Get lines that have parts of characters.
					Dim pxBlack As Integer() = pxAlpha.Where(Function(n) 0 < n.Value).Select(Function(n) n.Key).ToArray()

					'Find the nearest line (left or top).
					Dim lineNearest As Integer = pxBlack(0)

					'Find the farthest line (right or bottom).
					Dim lineFarthest As Integer = pxBlack(pxBlack.Length - 1)

					Return New Dictionary(Of Distance, Integer) From
					{
						{Distance.Near, lineNearest},
						{Distance.Far, lineFarthest}
					}
				End Using
			End Using
		End Function
	End Class

	Public ReadOnly Property Num As PercLabel 'Percentage number (string)
		Get
			Return _num
		End Get
	End Property
	Private ReadOnly _num As New PercLabel()

	Public ReadOnly Property Unit As PercLabel 'Percentage unit
		Get
			Return _unit
		End Get
	End Property
	Private ReadOnly _unit As New PercLabel()

	Public Property Thickness As Integer = 50 'Thickness for arc

	Private BaseColor As Color 'BackColor of parent Control or Form

	Public Sub New()
		If (ProgressBarRenderer.IsSupported) Then Me.SetStyle(ControlStyles.UserPaint, True)
	End Sub

	Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
		'None (To avoid background being painted so as to prevent flickering).
	End Sub

	Private isInitial As Boolean = True

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		'==========================
		' Prepare for initial draw
		'==========================
		If (isInitial) Then
			isInitial = False

			'Set this Control's region (Me.Size cannot be correctly obtained in constructor).
			Using p As New GraphicsPath()
				p.AddEllipse(GetRectangle(0))
				Me.Region = New Region(p)
			End Using

			'Set this Control's BaseColor.
			BaseColor = If(Me.Parent, Me.FindForm()).BackColor

			'Set font of Num and Unit (to avoid exception at DrawString).
			If (Num.Font Is Nothing) Then
				Num.Font = New Font(Me.FindForm().Font.FontFamily,
									Convert.ToInt32(Me.Size.Width * 0.3),
									FontStyle.Bold,
									GraphicsUnit.Pixel)
			End If

			If (Unit.Font Is Nothing) Then
				Unit.Font = New Font(Me.FindForm().Font.FontFamily,
									 Convert.ToInt32(Me.Size.Width * 0.15),
									 FontStyle.Bold,
									 GraphicsUnit.Pixel)
			End If
		End If

		'=======================
		' Set percentage number
		'=======================
		Num.Text = Convert.ToString(Me.Value)
		SetLocations(Me.Value, Me)

		'=======================
		' Draw circles and text
		'=======================
		Using bmp As Image = New Bitmap(Me.Width, Me.Height)
			Using g As Graphics = Graphics.FromImage(bmp)
				g.SmoothingMode = SmoothingMode.AntiAlias
				g.PixelOffsetMode = PixelOffsetMode.HighQuality

				'--------------------------------------------------
				' Base circle (for antialiasing background circle)
				'--------------------------------------------------
				Using brushBase As New SolidBrush(Me.BaseColor)
					g.FillEllipse(brushBase, GetRectangle(0))
				End Using

				'-------------------
				' Background circle
				'-------------------
				Using brushBack As New SolidBrush(Me.BackColor)
					g.FillEllipse(brushBack, GetRectangle(1))
				End Using

				Using brushFore As New SolidBrush(Me.ForeColor)
					'-----
					' Arc
					'-----
					Dim startAngle As Single = -90.0F
					Dim sweepAngle As Single = Convert.ToSingle(3.6 * Me.Value)

					Using p As New GraphicsPath()
						p.AddArc(GetRectangle(4), startAngle, sweepAngle)
						p.AddArc(GetRectangle(Thickness + 4), startAngle + sweepAngle, -sweepAngle)
						g.FillPath(brushFore, p)
					End Using

					'-------------
					' Center text
					'-------------
					g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
					g.DrawString(Num.Text, Num.Font, brushFore, Num.Location)
					g.DrawString(Unit.Text, Unit.Font, brushFore, Unit.Location)
				End Using

				'Reflect to image.
				e.Graphics.DrawImage(bmp, Point.Empty)
			End Using
		End Using
	End Sub

	'Get rectangle with designated offset.
	Private Function GetRectangle(offset As Integer) As Rectangle
		Return New Rectangle(offset, offset, Me.Width - offset * 2, Me.Height - offset * 2)
	End Function

	'Set locations of Num and Unit.
	Private Sub SetLocations(value As Integer, sea As Control)
		'Prepare "isle" Control which can encompass Num and Unit.
		Dim isle As New Control()
		isle.Width = Num.TextWidth(value) + Unit.TextWidth(101)
		isle.Height = Math.Max(Num.TextHeight, Unit.TextHeight)

		'Place "isle" Control at the center of "sea" Control.
		isle.Location = New Point(Convert.ToInt32((sea.Width - isle.Width) / 2.0),
								  Convert.ToInt32((sea.Height - isle.Height) / 2.0))

		'Translate location of "isle" to locations of Num and Unit.
		Num.Location = New Point(isle.Location.X - Num.TextLeft(value),
								 isle.Location.Y + isle.Height - Num.TextBottom)
		Unit.Location = New Point(isle.Location.X + Num.TextWidth(value),
								  isle.Location.Y + isle.Height - Unit.TextBottom)
	End Sub

End Class