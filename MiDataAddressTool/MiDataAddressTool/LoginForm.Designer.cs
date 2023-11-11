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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LoginForm));
            titelLabel = new Label();
            LoginButton = new Button();
            loadingPictureBox = new PictureBox();
            TokenLabel = new Label();
            ErrorLabel = new Label();
            PrimaryGroupIdLabel = new Label();
            TokenTextBox = new TextBox();
            PrimaryGroupIdTextBox = new TextBox();
            ((ISupportInitialize)loadingPictureBox).BeginInit();
            SuspendLayout();
            // 
            // titelLabel
            // 
            titelLabel.Location = new System.Drawing.Point(17, 17);
            titelLabel.Margin = new Padding(2, 0, 2, 0);
            titelLabel.Name = "titelLabel";
            titelLabel.Size = new System.Drawing.Size(375, 40);
            titelLabel.TabIndex = 1;
            titelLabel.Text = "Gib deine MiData Service Token ein";
            // 
            // LoginButton
            // 
            LoginButton.Anchor = AnchorStyles.Top;
            LoginButton.Location = new System.Drawing.Point(292, 153);
            LoginButton.Margin = new Padding(2);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new System.Drawing.Size(100, 48);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // loadingPictureBox
            // 
            loadingPictureBox.Anchor = AnchorStyles.Top;
            loadingPictureBox.Image = (System.Drawing.Image)resources.GetObject("loadingPictureBox.Image");
            loadingPictureBox.Location = new System.Drawing.Point(252, 153);
            loadingPictureBox.Margin = new Padding(0);
            loadingPictureBox.Name = "loadingPictureBox";
            loadingPictureBox.Size = new System.Drawing.Size(37, 48);
            loadingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            loadingPictureBox.TabIndex = 7;
            loadingPictureBox.TabStop = false;
            loadingPictureBox.Visible = false;
            // 
            // TokenLabel
            // 
            TokenLabel.Location = new System.Drawing.Point(17, 60);
            TokenLabel.Margin = new Padding(2, 0, 2, 0);
            TokenLabel.Name = "TokenLabel";
            TokenLabel.Size = new System.Drawing.Size(88, 31);
            TokenLabel.TabIndex = 2;
            TokenLabel.Text = "Token";
            TokenLabel.Visible = true;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new System.Drawing.Point(17, 165);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new System.Drawing.Size(0, 25);
            ErrorLabel.TabIndex = 13;
            // 
            // PrimaryGroupIdLabel
            // 
            PrimaryGroupIdLabel.Location = new System.Drawing.Point(17, 103);
            PrimaryGroupIdLabel.Margin = new Padding(2, 0, 2, 0);
            PrimaryGroupIdLabel.Name = "PrimaryGroupIdLabel";
            PrimaryGroupIdLabel.Size = new System.Drawing.Size(157, 31);
            PrimaryGroupIdLabel.TabIndex = 3;
            PrimaryGroupIdLabel.Text = "Primary Group Id";
            PrimaryGroupIdLabel.Visible = true;
            // 
            // TokenTextBox
            // 
            TokenTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TokenTextBox.Location = new System.Drawing.Point(178, 60);
            TokenTextBox.Margin = new Padding(2);
            TokenTextBox.Name = "TokenTextBox";
            TokenTextBox.Size = new System.Drawing.Size(214, 31);
            TokenTextBox.TabIndex = 3;
            TokenTextBox.Visible = true;
            // 
            // PrimaryGroupIdTextBox
            // 
            PrimaryGroupIdTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PrimaryGroupIdTextBox.Location = new System.Drawing.Point(178, 103);
            PrimaryGroupIdTextBox.Margin = new Padding(2);
            PrimaryGroupIdTextBox.Name = "PrimaryGroupIdTextBox";
            PrimaryGroupIdTextBox.Size = new System.Drawing.Size(214, 31);
            PrimaryGroupIdTextBox.TabIndex = 5;
            PrimaryGroupIdTextBox.Visible = true;
            // 
            // LoginForm
            // 
            AcceptButton = LoginButton;
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(413, 230);
            Controls.Add(PrimaryGroupIdTextBox);
            Controls.Add(PrimaryGroupIdLabel);
            Controls.Add(ErrorLabel);
            Controls.Add(TokenTextBox);
            Controls.Add(TokenLabel);
            Controls.Add(loadingPictureBox);
            Controls.Add(LoginButton);
            Controls.Add(titelLabel);
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ((ISupportInitialize)loadingPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label titelLabel;
        private Button LoginButton;
        private PictureBox loadingPictureBox;
        private Label TokenLabel;
        private Label ErrorLabel;
        private Label PrimaryGroupIdLabel;
        private TextBox TokenTextBox;
        private TextBox PrimaryGroupIdTextBox;
    }
}