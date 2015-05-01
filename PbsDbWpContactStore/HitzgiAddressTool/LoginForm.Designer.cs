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
			this.emailLabel.Location = new System.Drawing.Point(13, 91);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(100, 35);
			this.emailLabel.TabIndex = 0;
			this.emailLabel.Text = "Email";
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(13, 148);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(141, 38);
			this.passwordLabel.TabIndex = 1;
			this.passwordLabel.Text = "Passwort";
			// 
			// emailTextBox
			// 
			this.emailTextBox.Location = new System.Drawing.Point(160, 91);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new System.Drawing.Size(415, 38);
			this.emailTextBox.TabIndex = 2;
			// 
			// passwortTextBox
			// 
			this.passwortTextBox.Location = new System.Drawing.Point(160, 148);
			this.passwortTextBox.Name = "passwortTextBox";
			this.passwortTextBox.Size = new System.Drawing.Size(415, 38);
			this.passwortTextBox.TabIndex = 3;
			// 
			// titelLabel
			// 
			this.titelLabel.Location = new System.Drawing.Point(13, 24);
			this.titelLabel.Name = "titelLabel";
			this.titelLabel.Size = new System.Drawing.Size(432, 43);
			this.titelLabel.TabIndex = 4;
			this.titelLabel.Text = "Gib deine anmelde Daten ein";
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(450, 201);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(125, 46);
			this.loginButton.TabIndex = 5;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// errorLabel
			// 
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(163, 201);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(281, 74);
			this.errorLabel.TabIndex = 6;
			// 
			// loadingPictureBox
			// 
			this.loadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingPictureBox.Image")));
			this.loadingPictureBox.Location = new System.Drawing.Point(384, 195);
			this.loadingPictureBox.Margin = new System.Windows.Forms.Padding(0);
			this.loadingPictureBox.Name = "loadingPictureBox";
			this.loadingPictureBox.Size = new System.Drawing.Size(60, 60);
			this.loadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.loadingPictureBox.TabIndex = 7;
			this.loadingPictureBox.TabStop = false;
			this.loadingPictureBox.Visible = false;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 320);
			this.Controls.Add(this.loadingPictureBox);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.titelLabel);
			this.Controls.Add(this.passwortTextBox);
			this.Controls.Add(this.emailTextBox);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.emailLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
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