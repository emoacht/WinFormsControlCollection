namespace CircleProgressBarCs
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
			this.trackBar_Perc = new System.Windows.Forms.TrackBar();
			this.circleProgressBar_Target = new CircleProgressBarCs.CircleProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Perc)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar_Perc
			// 
			this.trackBar_Perc.Location = new System.Drawing.Point(13, 318);
			this.trackBar_Perc.Maximum = 100;
			this.trackBar_Perc.Name = "trackBar_Perc";
			this.trackBar_Perc.Size = new System.Drawing.Size(225, 45);
			this.trackBar_Perc.TabIndex = 1;
			this.trackBar_Perc.TickFrequency = 10;
			this.trackBar_Perc.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trackBar_Perc.Value = 42;
			this.trackBar_Perc.Scroll += new System.EventHandler(this.trackBar_Perc_Scroll);
			// 
			// circleProgressBar_Target
			// 
			this.circleProgressBar_Target.BackColor = System.Drawing.Color.LightPink;
			this.circleProgressBar_Target.ForeColor = System.Drawing.Color.Crimson;
			this.circleProgressBar_Target.Location = new System.Drawing.Point(12, 12);
			this.circleProgressBar_Target.Name = "circleProgressBar_Target";
			this.circleProgressBar_Target.Size = new System.Drawing.Size(300, 300);
			this.circleProgressBar_Target.TabIndex = 0;
			this.circleProgressBar_Target.Value = 42;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 375);
			this.Controls.Add(this.trackBar_Perc);
			this.Controls.Add(this.circleProgressBar_Target);
			this.Name = "MainForm";
			this.Text = "Circle ProgressBar CS";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Perc)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CircleProgressBar circleProgressBar_Target;
		private System.Windows.Forms.TrackBar trackBar_Perc;
	}
}

