namespace Sistem_za_naplatu_parkinga
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            passwordTextBox = new TextBox();
            emailTextBox = new TextBox();
            nameTextBox = new TextBox();
            surnameTextBox = new TextBox();
            comboBox1 = new ComboBox();
            emailLabel = new Label();
            passwordLabel = new Label();
            nameLabel = new Label();
            surnameLabel = new Label();
            confirmButton = new Button();
            roleBox = new ComboBox();
            roleLabel = new Label();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.Khaki;
            passwordTextBox.Location = new Point(200, 100);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(176, 23);
            passwordTextBox.TabIndex = 0;
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.Khaki;
            emailTextBox.Location = new Point(200, 25);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(176, 23);
            emailTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.Khaki;
            nameTextBox.Location = new Point(200, 175);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(176, 23);
            nameTextBox.TabIndex = 2;
            // 
            // surnameTextBox
            // 
            surnameTextBox.BackColor = Color.Khaki;
            surnameTextBox.Location = new Point(200, 250);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(176, 23);
            surnameTextBox.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(200, 370);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(176, 23);
            comboBox1.TabIndex = 4;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(242, 9);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(81, 15);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "Unesite email:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(245, 82);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(75, 15);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Unesite šifru:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(245, 157);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(72, 15);
            nameLabel.TabIndex = 7;
            nameLabel.Text = "Unesite ime:";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            surnameLabel.Location = new Point(242, 232);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(95, 15);
            surnameLabel.TabIndex = 8;
            surnameLabel.Text = "Unesite prezime:";
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.Khaki;
            confirmButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmButton.Location = new Point(476, 173);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(75, 23);
            confirmButton.TabIndex = 9;
            confirmButton.Text = "Kreiraj";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // roleBox
            // 
            roleBox.BackColor = Color.Khaki;
            roleBox.FormattingEnabled = true;
            roleBox.Items.AddRange(new object[] { "administrator", "operater" });
            roleBox.Location = new Point(200, 325);
            roleBox.Name = "roleBox";
            roleBox.Size = new Size(176, 23);
            roleBox.TabIndex = 10;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roleLabel.Location = new Point(245, 307);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(73, 15);
            roleLabel.TabIndex = 11;
            roleLabel.Text = "Izaberite tip:";
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(584, 361);
            Controls.Add(roleLabel);
            Controls.Add(roleBox);
            Controls.Add(confirmButton);
            Controls.Add(surnameLabel);
            Controls.Add(nameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(emailLabel);
            Controls.Add(comboBox1);
            Controls.Add(surnameTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(passwordTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateAccount";
            Text = "Kreiranje naloga";
            Load += CreateAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox emailTextBox;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private ComboBox comboBox1;
        private Label emailLabel;
        private Label passwordLabel;
        private Label nameLabel;
        private Label surnameLabel;
        private Button confirmButton;
        private ComboBox roleBox;
        private Label roleLabel;
    }
}