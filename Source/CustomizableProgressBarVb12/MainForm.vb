Public Class MainForm

	Public Sub New()
		InitializeComponent()

		If (Not ProgressBarRenderer.IsSupported) Then
			CustomizableProgressBar_Target.BackColor = SystemColors.Control
		End If
	End Sub

	Private Sub TrackBar_Perc_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Perc.Scroll
		CustomizableProgressBar_Target.Value = TrackBar_Perc.Value
	End Sub

	Private Sub Button_Turquoise_Click(sender As Object, e As EventArgs) Handles Button_Turquoise.Click
		'Turquoise
		SetColors(Color.MediumTurquoise, Color.DarkCyan)
	End Sub

	Private Sub Button_Blue_Click(sender As Object, e As EventArgs) Handles Button_Blue.Click
		'Blue
		SetColors(Color.LightSkyBlue, Color.DodgerBlue)
	End Sub

	Private Sub Button_Green_Click(sender As Object, e As EventArgs) Handles Button_Green.Click
		'Green
		SetColors(Color.LimeGreen, Color.ForestGreen)
	End Sub

	Private Sub Button_Yellow_Click(sender As Object, e As EventArgs) Handles Button_Yellow.Click
		'Yellow
		SetColors(Color.Khaki, Color.Gold)
	End Sub

	Private Sub Button_Red_Click(sender As Object, e As EventArgs) Handles Button_Red.Click
		'Red
		SetColors(Color.Red, Color.Firebrick)
	End Sub

	Private Sub SetColors(backColor As Color, foreColor As Color)
		If (ProgressBarRenderer.IsSupported) Then
			CustomizableProgressBar_Target.BackColor = backColor
			CustomizableProgressBar_Target.ForeColor = foreColor
		Else
			CustomizableProgressBar_Target.BackColor = SystemColors.Control
			CustomizableProgressBar_Target.ForeColor = backColor
		End If
	End Sub

End Class