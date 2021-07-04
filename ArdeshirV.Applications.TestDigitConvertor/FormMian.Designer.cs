#region Header
// FormMain.Designer.cs : Main form of 'TestDigitiConvetor' windows-form application
// Copyright© 2010-2021 ArdeshirV@protonmail.com, Licensed under GPLv3+

using System;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.TestDigitConvertor
{
	partial class FormMain
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelNumber;
		private System.Windows.Forms.NumericUpDown nupdownNumber;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonFormAbout;
		private System.Windows.Forms.TextBox textboxOutput;
		private System.Windows.Forms.Button buttonCopy;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.labelNumber = new System.Windows.Forms.Label();
			this.nupdownNumber = new System.Windows.Forms.NumericUpDown();
			this.buttonExit = new System.Windows.Forms.Button();
			this.buttonFormAbout = new System.Windows.Forms.Button();
			this.textboxOutput = new System.Windows.Forms.TextBox();
			this.buttonCopy = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nupdownNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// labelNumber
			// 
			this.labelNumber.BackColor = System.Drawing.Color.Transparent;
			this.labelNumber.Location = new System.Drawing.Point(12, 13);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(72, 18);
			this.labelNumber.TabIndex = 0;
			this.labelNumber.Text = "Number:";
			this.labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nupdownNumber
			// 
			this.nupdownNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.nupdownNumber.Location = new System.Drawing.Point(87, 14);
			this.nupdownNumber.Minimum = new decimal(new int[] {
			100,
			0,
			0,
			0});
			this.nupdownNumber.Name = "nupdownNumber";
			this.nupdownNumber.Size = new System.Drawing.Size(124, 20);
			this.nupdownNumber.TabIndex = 1;
			this.nupdownNumber.Value = new decimal(new int[] {
			100,
			0,
			0,
			0});
			this.nupdownNumber.ValueChanged += new System.EventHandler(this.NupdownNumberValueChanged);
			this.nupdownNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NupdownNumberKeyUp);
			// 
			// buttonExit
			// 
			this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonExit.Location = new System.Drawing.Point(217, 70);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(74, 23);
			this.buttonExit.TabIndex = 5;
			this.buttonExit.Text = "E&xit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
			// 
			// buttonFormAbout
			// 
			this.buttonFormAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFormAbout.Location = new System.Drawing.Point(217, 41);
			this.buttonFormAbout.Name = "buttonFormAbout";
			this.buttonFormAbout.Size = new System.Drawing.Size(74, 23);
			this.buttonFormAbout.TabIndex = 4;
			this.buttonFormAbout.Text = "&About...";
			this.buttonFormAbout.UseVisualStyleBackColor = true;
			this.buttonFormAbout.Click += new System.EventHandler(this.ButtonFormAboutClick);
			// 
			// textboxOutput
			// 
			this.textboxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textboxOutput.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textboxOutput.Location = new System.Drawing.Point(12, 40);
			this.textboxOutput.Multiline = true;
			this.textboxOutput.Name = "textboxOutput";
			this.textboxOutput.ReadOnly = true;
			this.textboxOutput.Size = new System.Drawing.Size(199, 54);
			this.textboxOutput.TabIndex = 2;
			this.textboxOutput.TabStop = false;
			// 
			// buttonCopy
			// 
			this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCopy.Location = new System.Drawing.Point(218, 12);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(74, 23);
			this.buttonCopy.TabIndex = 3;
			this.buttonCopy.Text = "&Copy";
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Click += new System.EventHandler(this.ButtonCopyClick);
			// 
			// FormMain
			// 
			this.AcceptButton = this.buttonCopy;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonExit;
			this.ClientSize = new System.Drawing.Size(304, 106);
			this.Controls.Add(this.buttonCopy);
			this.Controls.Add(this.textboxOutput);
			this.Controls.Add(this.buttonFormAbout);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.nupdownNumber);
			this.Controls.Add(this.labelNumber);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(250, 145);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Digit Convertor";
			this.Shown += new System.EventHandler(this.FormMainShown);
			((System.ComponentModel.ISupportInitialize)(this.nupdownNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
