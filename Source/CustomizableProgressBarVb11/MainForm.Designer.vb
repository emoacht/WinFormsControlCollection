<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.Button_Turquoise = New System.Windows.Forms.Button()
		Me.Button_Blue = New System.Windows.Forms.Button()
		Me.Button_Green = New System.Windows.Forms.Button()
		Me.Button_Yellow = New System.Windows.Forms.Button()
		Me.Button_Red = New System.Windows.Forms.Button()
		Me.TrackBar_Perc = New System.Windows.Forms.TrackBar()
		Me.CustomizableProgressBar_Target = New CustomizableProgressBarVb.CustomizableProgressBar()
		CType(Me.TrackBar_Perc, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Button_Turquoise
		'
		Me.Button_Turquoise.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Turquoise.Location = New System.Drawing.Point(10, 10)
		Me.Button_Turquoise.Name = "Button_Turquoise"
		Me.Button_Turquoise.Size = New System.Drawing.Size(70, 28)
		Me.Button_Turquoise.TabIndex = 0
		Me.Button_Turquoise.Text = "Turquoise"
		Me.Button_Turquoise.UseVisualStyleBackColor = True
		'
		'Button_Blue
		'
		Me.Button_Blue.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Blue.Location = New System.Drawing.Point(86, 10)
		Me.Button_Blue.Name = "Button_Blue"
		Me.Button_Blue.Size = New System.Drawing.Size(70, 28)
		Me.Button_Blue.TabIndex = 1
		Me.Button_Blue.Text = "Blue"
		Me.Button_Blue.UseVisualStyleBackColor = True
		'
		'Button_Green
		'
		Me.Button_Green.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Green.Location = New System.Drawing.Point(162, 10)
		Me.Button_Green.Name = "Button_Green"
		Me.Button_Green.Size = New System.Drawing.Size(70, 28)
		Me.Button_Green.TabIndex = 2
		Me.Button_Green.Text = "Green"
		Me.Button_Green.UseVisualStyleBackColor = True
		'
		'Button_Yellow
		'
		Me.Button_Yellow.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Yellow.Location = New System.Drawing.Point(238, 10)
		Me.Button_Yellow.Name = "Button_Yellow"
		Me.Button_Yellow.Size = New System.Drawing.Size(70, 28)
		Me.Button_Yellow.TabIndex = 3
		Me.Button_Yellow.Text = "Yellow"
		Me.Button_Yellow.UseVisualStyleBackColor = True
		'
		'Button_Red
		'
		Me.Button_Red.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Red.Location = New System.Drawing.Point(314, 10)
		Me.Button_Red.Name = "Button_Red"
		Me.Button_Red.Size = New System.Drawing.Size(70, 28)
		Me.Button_Red.TabIndex = 4
		Me.Button_Red.Text = "Red"
		Me.Button_Red.UseVisualStyleBackColor = True
		'
		'TrackBar_Perc
		'
		Me.TrackBar_Perc.Location = New System.Drawing.Point(8, 90)
		Me.TrackBar_Perc.Maximum = 100
		Me.TrackBar_Perc.Name = "TrackBar_Perc"
		Me.TrackBar_Perc.Size = New System.Drawing.Size(364, 45)
		Me.TrackBar_Perc.TabIndex = 6
		Me.TrackBar_Perc.TickFrequency = 10
		Me.TrackBar_Perc.TickStyle = System.Windows.Forms.TickStyle.TopLeft
		Me.TrackBar_Perc.Value = 50
		'
		'CustomizableProgressBar_Target
		'
		Me.CustomizableProgressBar_Target.BackColor = System.Drawing.Color.MediumTurquoise
		Me.CustomizableProgressBar_Target.ForeColor = System.Drawing.Color.DarkCyan
		Me.CustomizableProgressBar_Target.Location = New System.Drawing.Point(20, 50)
		Me.CustomizableProgressBar_Target.Name = "CustomizableProgressBar_Target"
		Me.CustomizableProgressBar_Target.Size = New System.Drawing.Size(340, 30)
		Me.CustomizableProgressBar_Target.Style = System.Windows.Forms.ProgressBarStyle.Continuous
		Me.CustomizableProgressBar_Target.TabIndex = 5
		Me.CustomizableProgressBar_Target.Value = 50
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(394, 132)
		Me.Controls.Add(Me.TrackBar_Perc)
		Me.Controls.Add(Me.CustomizableProgressBar_Target)
		Me.Controls.Add(Me.Button_Red)
		Me.Controls.Add(Me.Button_Yellow)
		Me.Controls.Add(Me.Button_Green)
		Me.Controls.Add(Me.Button_Blue)
		Me.Controls.Add(Me.Button_Turquoise)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		Me.MaximizeBox = False
		Me.Name = "MainForm"
		Me.ShowIcon = False
		Me.Text = "Color Customizable ProgressBar Demo"
		CType(Me.TrackBar_Perc, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Button_Turquoise As System.Windows.Forms.Button
	Friend WithEvents Button_Blue As System.Windows.Forms.Button
	Friend WithEvents Button_Green As System.Windows.Forms.Button
	Friend WithEvents Button_Yellow As System.Windows.Forms.Button
	Friend WithEvents Button_Red As System.Windows.Forms.Button
	Friend WithEvents CustomizableProgressBar_Target As CustomizableProgressBar
	Friend WithEvents TrackBar_Perc As System.Windows.Forms.TrackBar

End Class
