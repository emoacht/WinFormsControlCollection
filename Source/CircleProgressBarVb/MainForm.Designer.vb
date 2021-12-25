<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.TrackBar_Perc = New System.Windows.Forms.TrackBar()
		Me.CircleProgressBar_Target = New CircleProgressBarVb.CircleProgressBar()
		CType(Me.TrackBar_Perc, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TrackBar_Perc
		'
		Me.TrackBar_Perc.Location = New System.Drawing.Point(13, 318)
		Me.TrackBar_Perc.Maximum = 100
		Me.TrackBar_Perc.Name = "TrackBar_Perc"
		Me.TrackBar_Perc.Size = New System.Drawing.Size(225, 45)
		Me.TrackBar_Perc.TabIndex = 1
		Me.TrackBar_Perc.TickFrequency = 10
		Me.TrackBar_Perc.TickStyle = System.Windows.Forms.TickStyle.TopLeft
		Me.TrackBar_Perc.Value = 42
		'
		'CircleProgressBar_Target
		'
		Me.CircleProgressBar_Target.BackColor = System.Drawing.Color.LightBlue
		Me.CircleProgressBar_Target.ForeColor = System.Drawing.Color.DodgerBlue
		Me.CircleProgressBar_Target.Location = New System.Drawing.Point(12, 12)
		Me.CircleProgressBar_Target.Name = "CircleProgressBar_Target"
		Me.CircleProgressBar_Target.Size = New System.Drawing.Size(300, 300)
		Me.CircleProgressBar_Target.TabIndex = 2
		Me.CircleProgressBar_Target.Value = 42
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(324, 375)
		Me.Controls.Add(Me.CircleProgressBar_Target)
		Me.Controls.Add(Me.TrackBar_Perc)
		Me.Name = "MainForm"
		Me.Text = "Circle ProgressBar VB"
		CType(Me.TrackBar_Perc, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TrackBar_Perc As System.Windows.Forms.TrackBar
	Friend WithEvents CircleProgressBar_Target As CircleProgressBarVb.CircleProgressBar

End Class
