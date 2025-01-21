namespace Sistem_za_naplatu_parkinga
{
    partial class NewUserSubscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUserSubscription));
            emailBox = new TextBox();
            nameBox = new TextBox();
            surnameBox = new TextBox();
            emailLabel = new Label();
            nameLabel = new Label();
            surnameLabel = new Label();
            registerButton = new Button();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.BackColor = Color.LightPink;
            emailBox.Location = new Point(272, 66);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(200, 23);
            emailBox.TabIndex = 0;
            // 
            // nameBox
            // 
            nameBox.BackColor = Color.LightPink;
            nameBox.Location = new Point(282, 136);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(200, 23);
            nameBox.TabIndex = 1;
            // 
            // surnameBox
            // 
            surnameBox.BackColor = Color.LightPink;
            surnameBox.Location = new Point(281, 209);
            surnameBox.Name = "surnameBox";
            surnameBox.Size = new Size(200, 23);
            surnameBox.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            emailLabel.Location = new Point(284, 35);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(81, 15);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "Unesite email:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            nameLabel.Location = new Point(289, 112);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(72, 15);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Unesite ime:";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            surnameLabel.Location = new Point(300, 190);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(95, 15);
            surnameLabel.TabIndex = 5;
            surnameLabel.Text = "Unesite prezime:";
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.LightPink;
            registerButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            registerButton.Location = new Point(344, 298);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(89, 23);
            registerButton.TabIndex = 6;
            registerButton.Text = "Pretplati se";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // NewUserSubscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(surnameLabel);
            Controls.Add(nameLabel);
            Controls.Add(emailLabel);
            Controls.Add(surnameBox);
            Controls.Add(nameBox);
            Controls.Add(emailBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NewUserSubscription";
            Text = "Pretplata novog korisnika";
            FormClosing += NewUserSubscription_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailBox;
        private TextBox nameBox;
        private TextBox surnameBox;
        private Label emailLabel;
        private Label nameLabel;
        private Label surnameLabel;
        private Button registerButton;
    }
}