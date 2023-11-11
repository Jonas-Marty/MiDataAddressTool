using System.ComponentModel;

namespace MiDataAddressTool
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            groupsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            statusLabel = new System.Windows.Forms.Label();
            loadingGroupsPictureBox = new System.Windows.Forms.PictureBox();
            bottomLoadingPictureBox = new System.Windows.Forms.PictureBox();
            bottomStatusLabel = new System.Windows.Forms.Label();
            excelButton = new System.Windows.Forms.Button();
            priorityInfoLabel = new System.Windows.Forms.Label();
            priorityUpButton = new System.Windows.Forms.Button();
            priorityDownButton = new System.Windows.Forms.Button();
            copyTnMobileButton = new System.Windows.Forms.Button();
            ((ISupportInitialize)loadingGroupsPictureBox).BeginInit();
            ((ISupportInitialize)bottomLoadingPictureBox).BeginInit();
            SuspendLayout();
            // 
            // groupsCheckedListBox
            // 
            groupsCheckedListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupsCheckedListBox.CheckOnClick = true;
            groupsCheckedListBox.Enabled = false;
            groupsCheckedListBox.FormattingEnabled = true;
            groupsCheckedListBox.Location = new System.Drawing.Point(30, 134);
            groupsCheckedListBox.Margin = new System.Windows.Forms.Padding(2);
            groupsCheckedListBox.Name = "groupsCheckedListBox";
            groupsCheckedListBox.Size = new System.Drawing.Size(576, 612);
            groupsCheckedListBox.TabIndex = 0;
            groupsCheckedListBox.SelectedIndexChanged += GroupsCheckedListBox_SelectedIndexChanged;
            // 
            // statusLabel
            // 
            statusLabel.Location = new System.Drawing.Point(92, 42);
            statusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(518, 74);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "Daten werden geladen...";
            // 
            // loadingGroupsPictureBox
            // 
            loadingGroupsPictureBox.Image = (System.Drawing.Image)resources.GetObject("loadingGroupsPictureBox.Image");
            loadingGroupsPictureBox.Location = new System.Drawing.Point(30, 42);
            loadingGroupsPictureBox.Margin = new System.Windows.Forms.Padding(2);
            loadingGroupsPictureBox.Name = "loadingGroupsPictureBox";
            loadingGroupsPictureBox.Size = new System.Drawing.Size(44, 58);
            loadingGroupsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            loadingGroupsPictureBox.TabIndex = 2;
            loadingGroupsPictureBox.TabStop = false;
            // 
            // bottomLoadingPictureBox
            // 
            bottomLoadingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bottomLoadingPictureBox.Image = (System.Drawing.Image)resources.GetObject("bottomLoadingPictureBox.Image");
            bottomLoadingPictureBox.Location = new System.Drawing.Point(30, 822);
            bottomLoadingPictureBox.Margin = new System.Windows.Forms.Padding(2);
            bottomLoadingPictureBox.Name = "bottomLoadingPictureBox";
            bottomLoadingPictureBox.Size = new System.Drawing.Size(44, 58);
            bottomLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bottomLoadingPictureBox.TabIndex = 3;
            bottomLoadingPictureBox.TabStop = false;
            bottomLoadingPictureBox.Visible = false;
            // 
            // bottomStatusLabel
            // 
            bottomStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bottomStatusLabel.Location = new System.Drawing.Point(88, 822);
            bottomStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            bottomStatusLabel.Name = "bottomStatusLabel";
            bottomStatusLabel.Size = new System.Drawing.Size(522, 74);
            bottomStatusLabel.TabIndex = 4;
            bottomStatusLabel.Text = "Daten werden geladen...";
            bottomStatusLabel.Visible = false;
            // 
            // excelButton
            // 
            excelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            excelButton.Location = new System.Drawing.Point(654, 822);
            excelButton.Margin = new System.Windows.Forms.Padding(2);
            excelButton.Name = "excelButton";
            excelButton.Size = new System.Drawing.Size(434, 74);
            excelButton.TabIndex = 5;
            excelButton.Text = "Excelliste generiern";
            excelButton.UseVisualStyleBackColor = true;
            excelButton.Visible = false;
            excelButton.Click += ExcelButtonOnClick;
            // 
            // priorityInfoLabel
            // 
            priorityInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            priorityInfoLabel.Location = new System.Drawing.Point(654, 134);
            priorityInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            priorityInfoLabel.Name = "priorityInfoLabel";
            priorityInfoLabel.Size = new System.Drawing.Size(434, 203);
            priorityInfoLabel.TabIndex = 7;
            priorityInfoLabel.Text = resources.GetString("priorityInfoLabel.Text");
            priorityInfoLabel.Visible = false;
            // 
            // priorityUpButton
            // 
            priorityUpButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            priorityUpButton.Location = new System.Drawing.Point(654, 344);
            priorityUpButton.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            priorityUpButton.Name = "priorityUpButton";
            priorityUpButton.Size = new System.Drawing.Size(434, 118);
            priorityUpButton.TabIndex = 8;
            priorityUpButton.Text = "Priorität erhöhen";
            priorityUpButton.UseVisualStyleBackColor = true;
            priorityUpButton.Visible = false;
            priorityUpButton.Click += PriorityUpButton_Click;
            // priorityDownButton
            // 
            priorityDownButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            priorityDownButton.Location = new System.Drawing.Point(654, 475);
            priorityDownButton.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            priorityDownButton.Name = "priorityDownButton";
            priorityDownButton.Size = new System.Drawing.Size(434, 118);
            priorityDownButton.TabIndex = 9;
            priorityDownButton.Text = "Priorität senken";
            priorityDownButton.UseVisualStyleBackColor = true;
            priorityDownButton.Visible = false;
            priorityDownButton.Click += PriorityDownButton_Click;
            // 
            // copyTnMobileButton
            // 
            copyTnMobileButton.Location = new System.Drawing.Point(654, 710);
            copyTnMobileButton.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            copyTnMobileButton.Name = "copyTnMobileButton";
            copyTnMobileButton.Size = new System.Drawing.Size(434, 88);
            copyTnMobileButton.TabIndex = 10;
            copyTnMobileButton.Text = "TN Handynummern in Zwischenablage kopieren";
            copyTnMobileButton.UseVisualStyleBackColor = true;
            copyTnMobileButton.Visible = false;
            copyTnMobileButton.Click += CopyTnMobileButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1112, 918);
            Controls.Add(copyTnMobileButton);
            Controls.Add(priorityDownButton);
            Controls.Add(priorityUpButton);
            Controls.Add(priorityInfoLabel);
            Controls.Add(excelButton);
            Controls.Add(bottomStatusLabel);
            Controls.Add(bottomLoadingPictureBox);
            Controls.Add(loadingGroupsPictureBox);
            Controls.Add(statusLabel);
            Controls.Add(groupsCheckedListBox);
            Margin = new System.Windows.Forms.Padding(2);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Hitzgi Adress Tool";
            Shown += MainForm_Shown;
            ((ISupportInitialize)loadingGroupsPictureBox).EndInit();
            ((ISupportInitialize)bottomLoadingPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckedListBox groupsCheckedListBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.PictureBox loadingGroupsPictureBox;
        private System.Windows.Forms.PictureBox bottomLoadingPictureBox;
        private System.Windows.Forms.Label bottomStatusLabel;
        private System.Windows.Forms.Button excelButton;
        private System.Windows.Forms.Label priorityInfoLabel;
        private System.Windows.Forms.Button priorityUpButton;
        private System.Windows.Forms.Button priorityDownButton;
        private System.Windows.Forms.Button copyTnMobileButton;
    }
}

