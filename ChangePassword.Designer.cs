namespace Sistem_za_naplatu_parkinga
{
    partial class ChangePassword
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            oldPwLabel = new Label();
            newPwLabel = new Label();
            verifyPwLabel = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Khaki;
            textBox1.Location = new Point(200, 94);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(158, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Validating += textBox1_Validating;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Khaki;
            textBox2.Location = new Point(200, 180);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(158, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.Validating += textBox2_Validating;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Khaki;
            textBox3.Location = new Point(200, 268);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(158, 23);
            textBox3.TabIndex = 2;
            textBox3.TextChanged += textBox3_TextChanged;
            textBox3.Validating += textBox3_Validating;
            // 
            // oldPwLabel
            // 
            oldPwLabel.AutoSize = true;
            oldPwLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            oldPwLabel.Location = new Point(223, 76);
            oldPwLabel.Name = "oldPwLabel";
            oldPwLabel.Size = new Size(104, 15);
            oldPwLabel.TabIndex = 3;
            oldPwLabel.Text = "Unesite staru šifru:";
            // 
            // newPwLabel
            // 
            newPwLabel.AutoSize = true;
            newPwLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newPwLabel.Location = new Point(223, 162);
            newPwLabel.Name = "newPwLabel";
            newPwLabel.Size = new Size(105, 15);
            newPwLabel.TabIndex = 4;
            newPwLabel.Text = "Unesite novu šifru:";
            // 
            // verifyPwLabel
            // 
            verifyPwLabel.AutoSize = true;
            verifyPwLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            verifyPwLabel.Location = new Point(200, 250);
            verifyPwLabel.Name = "verifyPwLabel";
            verifyPwLabel.Size = new Size(148, 15);
            verifyPwLabel.TabIndex = 5;
            verifyPwLabel.Text = "Ponovo unesite novu šifru:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(584, 361);
            Controls.Add(verifyPwLabel);
            Controls.Add(newPwLabel);
            Controls.Add(oldPwLabel);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Promjena šifre";
            Load += ChangePassword_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label oldPwLabel;
        private Label newPwLabel;
        private Label verifyPwLabel;
        private ErrorProvider errorProvider1;
    }
}