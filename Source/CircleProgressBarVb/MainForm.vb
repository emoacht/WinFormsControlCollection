Public Class MainForm

	Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If (Not Debug) Then
		Me.Text = Application.ProductName
#End If

		'Set font of CircleProgressBar.
		CircleProgressBar_Target.Num.Font = New Font("Arial", 80, FontStyle.Bold, GraphicsUnit.Pixel)
		CircleProgressBar_Target.Unit.Font = New Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Pixel)
	End Sub

	Private Sub TrackBar_Perc_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Perc.Scroll
		CircleProgressBar_Target.Value = Convert.ToInt32(TrackBar_Perc.Value / TrackBar_Perc.Maximum * 100)
	End Sub

End Class