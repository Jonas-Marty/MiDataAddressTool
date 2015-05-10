using System.ComponentModel;
using System.Windows.Forms;

namespace HitzgiAddressTool
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
			this.emailLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.emailTextBox = new System.Windows.Forms.TextBox();
			this.passwortTextBox = new System.Windows.Forms.TextBox();
			this.titelLabel = new System.Windows.Forms.Label();
			this.loginButton = new System.Windows.Forms.Button();
			this.errorLabel = new System.Windows.Forms.Label();
			this.loadingPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// emailLabel
			// 
			this.emailLabel.Location = new System.Drawing.Point(10, 38);
			this.emailLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(38, 15);
			this.emailLabel.TabIndex = 0;
			this.emailLabel.Text = "Email";
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(10, 60);
			this.passwordLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(53, 16);
			this.passwordLabel.TabIndex = 1;
			this.passwordLabel.Text = "Passwort";
			// 
			// emailTextBox
			// 
			this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.emailTextBox.Location = new System.Drawing.Point(64, 38);
			this.emailTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new System.Drawing.Size(164, 20);
			this.emailTextBox.TabIndex = 2;
			// 
			// passwortTextBox
			// 
			this.passwortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.passwortTextBox.Location = new System.Drawing.Point(64, 60);
			this.passwortTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.passwortTextBox.Name = "passwortTextBox";
			this.passwortTextBox.Size = new System.Drawing.Size(164, 20);
			this.passwortTextBox.TabIndex = 3;
			// 
			// titelLabel
			// 
			this.titelLabel.Location = new System.Drawing.Point(10, 9);
			this.titelLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.titelLabel.Name = "titelLabel";
			this.titelLabel.Size = new System.Drawing.Size(162, 18);
			this.titelLabel.TabIndex = 4;
			this.titelLabel.Text = "Gib deine anmelde Daten ein";
			// 
			// loginButton
			// 
			this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.loginButton.Location = new System.Drawing.Point(168, 84);
			this.loginButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(60, 25);
			this.loginButton.TabIndex = 5;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// errorLabel
			// 
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(61, 84);
			this.errorLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(106, 25);
			this.errorLabel.TabIndex = 6;
			// 
			// loadingPictureBox
			// 
			this.loadingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.loadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingPictureBox.Image")));
			this.loadingPictureBox.Location = new System.Drawing.Point(144, 84);
			this.loadingPictureBox.Margin = new System.Windows.Forms.Padding(0);
			this.loadingPictureBox.Name = "loadingPictureBox";
			this.loadingPictureBox.Size = new System.Drawing.Size(22, 25);
			this.loadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.loadingPictureBox.TabIndex = 7;
			this.loadingPictureBox.TabStop = false;
			this.loadingPictureBox.Visible = false;
			// 
			// LoginForm
			// 
			this.AcceptButton = this.loginButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(238, 120);
			this.Controls.Add(this.loadingPictureBox);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.titelLabel);
			this.Controls.Add(this.passwortTextBox);
			this.Controls.Add(this.emailTextBox);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.emailLabel);
			this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label emailLabel;
		private Label passwordLabel;
		private TextBox emailTextBox;
		private TextBox passwortTextBox;
		private Label titelLabel;
		private Button loginButton;
		private Label errorLabel;
		private PictureBox loadingPictureBox;
	}
}