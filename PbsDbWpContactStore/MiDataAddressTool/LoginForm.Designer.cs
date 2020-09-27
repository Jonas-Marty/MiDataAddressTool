using System.ComponentModel;
using System.Windows.Forms;

namespace MiDataAddressTool
{
	partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.titelLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.TokenTextBox = new System.Windows.Forms.TextBox();
            this.TokenLabel = new System.Windows.Forms.Label();
            this.UserRadioButton = new System.Windows.Forms.RadioButton();
            this.TokenRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.GroupIdTextBox = new System.Windows.Forms.TextBox();
            this.GroupIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmailLabel
            // 
            this.EmailLabel.Location = new System.Drawing.Point(19, 109);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(76, 29);
            this.EmailLabel.TabIndex = 0;
            this.EmailLabel.Text = "Email";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(19, 151);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(106, 31);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Passwort";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTextBox.Location = new System.Drawing.Point(160, 109);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(310, 31);
            this.EmailTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(160, 151);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(310, 31);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // titelLabel
            // 
            this.titelLabel.Location = new System.Drawing.Point(20, 17);
            this.titelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titelLabel.Name = "titelLabel";
            this.titelLabel.Size = new System.Drawing.Size(324, 35);
            this.titelLabel.TabIndex = 4;
            this.titelLabel.Text = "Gib deine anmelde Daten ein";
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoginButton.Location = new System.Drawing.Point(350, 198);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(120, 48);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingPictureBox.Image")));
            this.loadingPictureBox.Location = new System.Drawing.Point(302, 198);
            this.loadingPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(44, 48);
            this.loadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingPictureBox.TabIndex = 7;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // TokenTextBox
            // 
            this.TokenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenTextBox.Location = new System.Drawing.Point(160, 109);
            this.TokenTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.Size = new System.Drawing.Size(310, 31);
            this.TokenTextBox.TabIndex = 9;
            this.TokenTextBox.Visible = false;
            // 
            // TokenLabel
            // 
            this.TokenLabel.Location = new System.Drawing.Point(19, 109);
            this.TokenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TokenLabel.Name = "TokenLabel";
            this.TokenLabel.Size = new System.Drawing.Size(106, 31);
            this.TokenLabel.TabIndex = 8;
            this.TokenLabel.Text = "Token";
            this.TokenLabel.Visible = false;
            // 
            // UserRadioButton
            // 
            this.UserRadioButton.AutoSize = true;
            this.UserRadioButton.Location = new System.Drawing.Point(3, 3);
            this.UserRadioButton.Name = "UserRadioButton";
            this.UserRadioButton.Size = new System.Drawing.Size(129, 29);
            this.UserRadioButton.TabIndex = 10;
            this.UserRadioButton.Text = "Benutzer";
            this.UserRadioButton.UseVisualStyleBackColor = true;
            this.UserRadioButton.CheckedChanged += new System.EventHandler(this.UserRadioButton_CheckedChanged);
            // 
            // TokenRadioButton
            // 
            this.TokenRadioButton.AutoSize = true;
            this.TokenRadioButton.Checked = true;
            this.TokenRadioButton.Location = new System.Drawing.Point(191, 3);
            this.TokenRadioButton.Name = "TokenRadioButton";
            this.TokenRadioButton.Size = new System.Drawing.Size(103, 29);
            this.TokenRadioButton.TabIndex = 11;
            this.TokenRadioButton.TabStop = true;
            this.TokenRadioButton.Text = "Token";
            this.TokenRadioButton.UseVisualStyleBackColor = true;
            this.TokenRadioButton.CheckedChanged += new System.EventHandler(this.TokenRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TokenRadioButton);
            this.panel1.Controls.Add(this.UserRadioButton);
            this.panel1.Location = new System.Drawing.Point(24, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 39);
            this.panel1.TabIndex = 12;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(26, 197);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 25);
            this.ErrorLabel.TabIndex = 13;
            // 
            // GruppenIdTextBox
            // 
            this.GroupIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupIdTextBox.Location = new System.Drawing.Point(160, 151);
            this.GroupIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GroupIdTextBox.Name = "GruppenIdTextBox";
            this.GroupIdTextBox.Size = new System.Drawing.Size(310, 31);
            this.GroupIdTextBox.TabIndex = 15;
            this.GroupIdTextBox.Visible = false;
            // 
            // GruppenIdLabel
            // 
            this.GroupIdLabel.Location = new System.Drawing.Point(19, 151);
            this.GroupIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GroupIdLabel.Name = "GruppenIdLabel";
            this.GroupIdLabel.Size = new System.Drawing.Size(123, 31);
            this.GroupIdLabel.TabIndex = 14;
            this.GroupIdLabel.Text = "Gruppen ID";
            this.GroupIdLabel.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 265);
            this.Controls.Add(this.GroupIdTextBox);
            this.Controls.Add(this.GroupIdLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TokenTextBox);
            this.Controls.Add(this.TokenLabel);
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.titelLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label EmailLabel;
		private Label PasswordLabel;
		private TextBox EmailTextBox;
		private TextBox PasswordTextBox;
		private Label titelLabel;
		private Button LoginButton;
		private PictureBox loadingPictureBox;
        private TextBox TokenTextBox;
        private Label TokenLabel;
        private RadioButton UserRadioButton;
        private RadioButton TokenRadioButton;
        private Panel panel1;
        private Label ErrorLabel;
        private TextBox GroupIdTextBox;
        private Label GroupIdLabel;
    }
}