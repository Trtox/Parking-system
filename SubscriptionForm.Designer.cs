namespace Sistem_za_naplatu_parkinga
{
    partial class SubscriptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscriptionForm));
            subscriptionStatus = new Label();
            centralButton = new Button();
            SuspendLayout();
            // 
            // subscriptionStatus
            // 
            subscriptionStatus.AutoSize = true;
            subscriptionStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            subscriptionStatus.Location = new Point(354, 80);
            subscriptionStatus.Name = "subscriptionStatus";
            subscriptionStatus.Size = new Size(93, 15);
            subscriptionStatus.TabIndex = 0;
            subscriptionStatus.Text = "Status pretplate:";
            // 
            // centralButton
            // 
            centralButton.BackColor = Color.LightPink;
            centralButton.Location = new Point(354, 214);
            centralButton.Name = "centralButton";
            centralButton.Size = new Size(166, 23);
            centralButton.TabIndex = 1;
            centralButton.Text = "button1";
            centralButton.UseVisualStyleBackColor = false;
            centralButton.Click += centralButton_Click;
            // 
            // SubscriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(784, 461);
            Controls.Add(centralButton);
            Controls.Add(subscriptionStatus);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SubscriptionForm";
            Text = "Pretplata";
            FormClosing += SubscriptionForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label subscriptionStatus;
        private Button centralButton;
    }
}