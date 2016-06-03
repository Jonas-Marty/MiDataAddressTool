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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.loadingGroupsPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomLoadingPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomStatusLabel = new System.Windows.Forms.Label();
            this.excelButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.priorityInfoLabel = new System.Windows.Forms.Label();
            this.priorityUpButton = new System.Windows.Forms.Button();
            this.priorityDownButton = new System.Windows.Forms.Button();
            this.copyTnMobileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGroupsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomLoadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupsCheckedListBox
            // 
            this.groupsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsCheckedListBox.CheckOnClick = true;
            this.groupsCheckedListBox.Enabled = false;
            this.groupsCheckedListBox.FormattingEnabled = true;
            this.groupsCheckedListBox.Location = new System.Drawing.Point(15, 58);
            this.groupsCheckedListBox.Margin = new System.Windows.Forms.Padding(1);
            this.groupsCheckedListBox.Name = "groupsCheckedListBox";
            this.groupsCheckedListBox.Size = new System.Drawing.Size(290, 289);
            this.groupsCheckedListBox.TabIndex = 0;
            this.groupsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.groupsCheckedListBox_SelectedIndexChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(46, 18);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(259, 32);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Daten werden geladen...";
            // 
            // loadingGroupsPictureBox
            // 
            this.loadingGroupsPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingGroupsPictureBox.Image")));
            this.loadingGroupsPictureBox.Location = new System.Drawing.Point(15, 18);
            this.loadingGroupsPictureBox.Margin = new System.Windows.Forms.Padding(1);
            this.loadingGroupsPictureBox.Name = "loadingGroupsPictureBox";
            this.loadingGroupsPictureBox.Size = new System.Drawing.Size(22, 25);
            this.loadingGroupsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingGroupsPictureBox.TabIndex = 2;
            this.loadingGroupsPictureBox.TabStop = false;
            // 
            // bottomLoadingPictureBox
            // 
            this.bottomLoadingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bottomLoadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("bottomLoadingPictureBox.Image")));
            this.bottomLoadingPictureBox.Location = new System.Drawing.Point(15, 356);
            this.bottomLoadingPictureBox.Margin = new System.Windows.Forms.Padding(1);
            this.bottomLoadingPictureBox.Name = "bottomLoadingPictureBox";
            this.bottomLoadingPictureBox.Size = new System.Drawing.Size(22, 25);
            this.bottomLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bottomLoadingPictureBox.TabIndex = 3;
            this.bottomLoadingPictureBox.TabStop = false;
            this.bottomLoadingPictureBox.Visible = false;
            // 
            // bottomStatusLabel
            // 
            this.bottomStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bottomStatusLabel.Location = new System.Drawing.Point(44, 356);
            this.bottomStatusLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.bottomStatusLabel.Name = "bottomStatusLabel";
            this.bottomStatusLabel.Size = new System.Drawing.Size(261, 32);
            this.bottomStatusLabel.TabIndex = 4;
            this.bottomStatusLabel.Text = "Daten werden geladen...";
            this.bottomStatusLabel.Visible = false;
            // 
            // excelButton
            // 
            this.excelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelButton.Location = new System.Drawing.Point(327, 356);
            this.excelButton.Margin = new System.Windows.Forms.Padding(1);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(217, 32);
            this.excelButton.TabIndex = 5;
            this.excelButton.Text = "Excelliste generiern";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Visible = false;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // priorityInfoLabel
            // 
            this.priorityInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityInfoLabel.Location = new System.Drawing.Point(327, 58);
            this.priorityInfoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.priorityInfoLabel.Name = "priorityInfoLabel";
            this.priorityInfoLabel.Size = new System.Drawing.Size(217, 88);
            this.priorityInfoLabel.TabIndex = 7;
            this.priorityInfoLabel.Text = resources.GetString("priorityInfoLabel.Text");
            this.priorityInfoLabel.Visible = false;
            // 
            // priorityUpButton
            // 
            this.priorityUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityUpButton.Location = new System.Drawing.Point(327, 149);
            this.priorityUpButton.Name = "priorityUpButton";
            this.priorityUpButton.Size = new System.Drawing.Size(217, 51);
            this.priorityUpButton.TabIndex = 8;
            this.priorityUpButton.Text = "Priorität erhöhen";
            this.priorityUpButton.UseVisualStyleBackColor = true;
            this.priorityUpButton.Visible = false;
            this.priorityUpButton.Click += new System.EventHandler(this.priorityUpButton_Click);
            // 
            // priorityDownButton
            // 
            this.priorityDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityDownButton.Location = new System.Drawing.Point(327, 206);
            this.priorityDownButton.Name = "priorityDownButton";
            this.priorityDownButton.Size = new System.Drawing.Size(217, 51);
            this.priorityDownButton.TabIndex = 9;
            this.priorityDownButton.Text = "Priorität senken";
            this.priorityDownButton.UseVisualStyleBackColor = true;
            this.priorityDownButton.Visible = false;
            this.priorityDownButton.Click += new System.EventHandler(this.priorityDownButton_Click);
            // 
            // copyTnMobileButton
            // 
            this.copyTnMobileButton.Location = new System.Drawing.Point(327, 308);
            this.copyTnMobileButton.Name = "copyTnMobileButton";
            this.copyTnMobileButton.Size = new System.Drawing.Size(217, 38);
            this.copyTnMobileButton.TabIndex = 10;
            this.copyTnMobileButton.Text = "TN Handynummern in Zwischenablage kopieren";
            this.copyTnMobileButton.UseVisualStyleBackColor = true;
            this.copyTnMobileButton.Visible = false;
            this.copyTnMobileButton.Click += new System.EventHandler(this.copyTnMobileButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 398);
            this.Controls.Add(this.copyTnMobileButton);
            this.Controls.Add(this.priorityDownButton);
            this.Controls.Add(this.priorityUpButton);
            this.Controls.Add(this.priorityInfoLabel);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.bottomStatusLabel);
            this.Controls.Add(this.bottomLoadingPictureBox);
            this.Controls.Add(this.loadingGroupsPictureBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.groupsCheckedListBox);
            this.Margin = new System.Windows.Forms.Padding(1);
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
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Label priorityInfoLabel;
		private System.Windows.Forms.Button priorityUpButton;
		private System.Windows.Forms.Button priorityDownButton;
        private System.Windows.Forms.Button copyTnMobileButton;
    }
}

