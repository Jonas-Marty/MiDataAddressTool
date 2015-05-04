using System.ComponentModel;

namespace HitzgiAddressTool
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupsCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.statusLabel = new System.Windows.Forms.Label();
			this.loadingGroupsPictureBox = new System.Windows.Forms.PictureBox();
			this.bottomLoadingPictureBox = new System.Windows.Forms.PictureBox();
			this.bottomStatusLabel = new System.Windows.Forms.Label();
			this.excelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.loadingGroupsPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bottomLoadingPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// groupsCheckedListBox
			// 
			this.groupsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupsCheckedListBox.CheckOnClick = true;
			this.groupsCheckedListBox.FormattingEnabled = true;
			this.groupsCheckedListBox.Location = new System.Drawing.Point(41, 138);
			this.groupsCheckedListBox.Name = "groupsCheckedListBox";
			this.groupsCheckedListBox.Size = new System.Drawing.Size(731, 466);
			this.groupsCheckedListBox.TabIndex = 0;
			this.groupsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.groupsCheckedListBox_SelectedIndexChanged);
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.Location = new System.Drawing.Point(123, 43);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(446, 76);
			this.statusLabel.TabIndex = 1;
			this.statusLabel.Text = "Daten werden geladen...";
			// 
			// loadingGroupsPictureBox
			// 
			this.loadingGroupsPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingGroupsPictureBox.Image")));
			this.loadingGroupsPictureBox.Location = new System.Drawing.Point(41, 43);
			this.loadingGroupsPictureBox.Name = "loadingGroupsPictureBox";
			this.loadingGroupsPictureBox.Size = new System.Drawing.Size(60, 60);
			this.loadingGroupsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.loadingGroupsPictureBox.TabIndex = 2;
			this.loadingGroupsPictureBox.TabStop = false;
			// 
			// bottomLoadingPictureBox
			// 
			this.bottomLoadingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bottomLoadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("bottomLoadingPictureBox.Image")));
			this.bottomLoadingPictureBox.Location = new System.Drawing.Point(41, 699);
			this.bottomLoadingPictureBox.Name = "bottomLoadingPictureBox";
			this.bottomLoadingPictureBox.Size = new System.Drawing.Size(60, 60);
			this.bottomLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.bottomLoadingPictureBox.TabIndex = 3;
			this.bottomLoadingPictureBox.TabStop = false;
			// 
			// bottomStatusLabel
			// 
			this.bottomStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bottomStatusLabel.Location = new System.Drawing.Point(123, 699);
			this.bottomStatusLabel.Name = "bottomStatusLabel";
			this.bottomStatusLabel.Size = new System.Drawing.Size(649, 76);
			this.bottomStatusLabel.TabIndex = 4;
			this.bottomStatusLabel.Text = "Daten werden geladen...";
			// 
			// excelButton
			// 
			this.excelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.excelButton.Location = new System.Drawing.Point(575, 43);
			this.excelButton.Name = "excelButton";
			this.excelButton.Size = new System.Drawing.Size(197, 76);
			this.excelButton.TabIndex = 5;
			this.excelButton.Text = "Excelliste generiern";
			this.excelButton.UseVisualStyleBackColor = true;
			this.excelButton.Visible = false;
			this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(813, 784);
			this.Controls.Add(this.excelButton);
			this.Controls.Add(this.bottomStatusLabel);
			this.Controls.Add(this.bottomLoadingPictureBox);
			this.Controls.Add(this.loadingGroupsPictureBox);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.groupsCheckedListBox);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hitzgi Adress Tool";
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.loadingGroupsPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bottomLoadingPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox groupsCheckedListBox;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.PictureBox loadingGroupsPictureBox;
		private System.Windows.Forms.PictureBox bottomLoadingPictureBox;
		private System.Windows.Forms.Label bottomStatusLabel;
		private System.Windows.Forms.Button excelButton;
	}
}

