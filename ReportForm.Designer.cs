namespace Sistem_za_naplatu_parkinga
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            emailLabel = new Label();
            emailTextBox = new TextBox();
            reasonLabel = new Label();
            reasonTextBox = new TextBox();
            submitButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            emailLabel.Location = new Point(137, 44);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 15);
            emailLabel.TabIndex = 0;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.LightPink;
            emailTextBox.Location = new Point(182, 41);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(219, 23);
            emailTextBox.TabIndex = 1;
            emailTextBox.Validating += emailTextBox_Validating;
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            reasonLabel.Location = new Point(77, 74);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(103, 15);
            reasonLabel.TabIndex = 2;
            reasonLabel.Text = "Objašnjenje žalbe:";
            // 
            // reasonTextBox
            // 
            reasonTextBox.BackColor = Color.LightPink;
            reasonTextBox.Location = new Point(182, 71);
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.Size = new Size(219, 96);
            reasonTextBox.TabIndex = 3;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.LightPink;
            submitButton.Location = new Point(256, 199);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 4;
            submitButton.Text = "Pošalji";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ReportForm
            // 
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(584, 361);
            Controls.Add(submitButton);
            Controls.Add(reasonTextBox);
            Controls.Add(reasonLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReportForm";
            Text = "Podnošenje žalbe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Button submitButton;
        private ErrorProvider errorProvider1;
    }

        #endregion
    
}