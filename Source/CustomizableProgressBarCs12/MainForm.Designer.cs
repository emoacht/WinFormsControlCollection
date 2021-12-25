namespace CustomizableProgressBarCs
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Button_Turquoise = new System.Windows.Forms.Button();
			this.Button_Blue = new System.Windows.Forms.Button();
			this.Button_Green = new System.Windows.Forms.Button();
			this.Button_Yellow = new System.Windows.Forms.Button();
			this.Button_Red = new System.Windows.Forms.Button();
			this.TrackBar_Perc = new System.Windows.Forms.TrackBar();
			this.CustomizableProgressBar_Target = new CustomizableProgressBarCs.CustomizableProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Perc)).BeginInit();
			this.SuspendLayout();
			// 
			// Button_Turquoise
			// 
			this.Button_Turquoise.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Button_Turquoise.Location = new System.Drawing.Point(10, 10);
			this.Button_Turquoise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Button_Turquoise.Name = "Button_Turquoise";
			this.Button_Turquoise.Size = new System.Drawing.Size(70, 28);
			this.Button_Turquoise.TabIndex = 0;
			this.Button_Turquoise.Text = "Turquoise";
			this.Button_Turquoise.UseVisualStyleBackColor = true;
			this.Button_Turquoise.Click += new System.EventHandler(this.Button_Turquoise_Click);
			// 
			// Button_Blue
			// 
			this.Button_Blue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Button_Blue.Location = new System.Drawing.Point(86, 10);
			this.Button_Blue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Button_Blue.Name = "Button_Blue";
			this.Button_Blue.Size = new System.Drawing.Size(70, 28);
			this.Button_Blue.TabIndex = 1;
			this.Button_Blue.Text = "Blue";
			this.Button_Blue.UseVisualStyleBackColor = true;
			this.Button_Blue.Click += new System.EventHandler(this.Button_Blue_Click);
			// 
			// Button_Green
			// 
			this.Button_Green.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Button_Green.Location = new System.Drawing.Point(162, 10);
			this.Button_Green.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Button_Green.Name = "Button_Green";
			this.Button_Green.Size = new System.Drawing.Size(70, 28);
			this.Button_Green.TabIndex = 2;
			this.Button_Green.Text = "Green";
			this.Button_Green.UseVisualStyleBackColor = true;
			this.Button_Green.Click += new System.EventHandler(this.Button_Green_Click);
			// 
			// Button_Yellow
			// 
			this.Button_Yellow.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Button_Yellow.Location = new System.Drawing.Point(238, 10);
			this.Button_Yellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Button_Yellow.Name = "Button_Yellow";
			this.Button_Yellow.Size = new System.Drawing.Size(70, 28);
			this.Button_Yellow.TabIndex = 3;
			this.Button_Yellow.Text = "Yellow";
			this.Button_Yellow.UseVisualStyleBackColor = true;
			this.Button_Yellow.Click += new System.EventHandler(this.Button_Yellow_Click);
			// 
			// Button_Red
			// 
			this.Button_Red.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Button_Red.Location = new System.Drawing.Point(314, 10);
			this.Button_Red.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Button_Red.Name = "Button_Red";
			this.Button_Red.Size = new System.Drawing.Size(70, 28);
			this.Button_Red.TabIndex = 4;
			this.Button_Red.Text = "Red";
			this.Button_Red.UseVisualStyleBackColor = true;
			this.Button_Red.Click += new System.EventHandler(this.Button_Red_Click);
			// 
			// TrackBar_Perc
			// 
			this.TrackBar_Perc.Location = new System.Drawing.Point(8, 90);
			this.TrackBar_Perc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TrackBar_Perc.Maximum = 100;
			this.TrackBar_Perc.Name = "TrackBar_Perc";
			this.TrackBar_Perc.Size = new System.Drawing.Size(364, 45);
			this.TrackBar_Perc.TabIndex = 6;
			this.TrackBar_Perc.TickFrequency = 10;
			this.TrackBar_Perc.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.TrackBar_Perc.Value = 50;
			this.TrackBar_Perc.Scroll += new System.EventHandler(this.TrackBar_Perc_Scroll);
			// 
			// CustomizableProgressBar_Target
			// 
			this.CustomizableProgressBar_Target.BackColor = System.Drawing.Color.MediumTurquoise;
			this.CustomizableProgressBar_Target.ForeColor = System.Drawing.Color.DarkCyan;
			this.CustomizableProgressBar_Target.Location = new System.Drawing.Point(20, 50);
			this.CustomizableProgressBar_Target.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.CustomizableProgressBar_Target.Name = "CustomizableProgressBar_Target";
			this.CustomizableProgressBar_Target.Size = new System.Drawing.Size(339, 30);
			this.CustomizableProgressBar_Target.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.CustomizableProgressBar_Target.TabIndex = 5;
			this.CustomizableProgressBar_Target.Value = 50;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 132);
			this.Controls.Add(this.TrackBar_Perc);
			this.Controls.Add(this.CustomizableProgressBar_Target);
			this.Controls.Add(this.Button_Red);
			this.Controls.Add(this.Button_Yellow);
			this.Controls.Add(this.Button_Green);
			this.Controls.Add(this.Button_Blue);
			this.Controls.Add(this.Button_Turquoise);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "Color Customizable ProgressBar Demo";
			((System.ComponentModel.ISupportInitialize)(this.TrackBar_Perc)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal System.Windows.Forms.Button Button_Turquoise;
		internal System.Windows.Forms.Button Button_Blue;
		internal System.Windows.Forms.Button Button_Green;
		internal System.Windows.Forms.Button Button_Yellow;
		internal System.Windows.Forms.Button Button_Red;
		internal CustomizableProgressBar CustomizableProgressBar_Target;
		internal System.Windows.Forms.TrackBar TrackBar_Perc;

		#endregion
	}
}

