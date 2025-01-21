namespace Sistem_za_naplatu_parkinga
{
    partial class MainStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainStation));
            reportButton = new Button();
            payParkingButton = new Button();
            subscriptionButton = new Button();
            goBackButton = new Button();
            SuspendLayout();
            // 
            // reportButton
            // 
            reportButton.BackColor = Color.LightPink;
            reportButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reportButton.Location = new Point(600, 166);
            reportButton.Name = "reportButton";
            reportButton.Size = new Size(144, 65);
            reportButton.TabIndex = 0;
            reportButton.Text = "Podnesi žalbu";
            reportButton.UseVisualStyleBackColor = false;
            reportButton.Click += reportButton_Click;
            // 
            // payParkingButton
            // 
            payParkingButton.BackColor = Color.LightPink;
            payParkingButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payParkingButton.Location = new Point(199, 166);
            payParkingButton.Name = "payParkingButton";
            payParkingButton.Size = new Size(115, 65);
            payParkingButton.TabIndex = 1;
            payParkingButton.Text = "Plati parking";
            payParkingButton.UseVisualStyleBackColor = false;
            payParkingButton.Click += payParkingButton_Click;
            // 
            // subscriptionButton
            // 
            subscriptionButton.BackColor = Color.LightPink;
            subscriptionButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            subscriptionButton.Location = new Point(400, 166);
            subscriptionButton.Name = "subscriptionButton";
            subscriptionButton.Size = new Size(125, 65);
            subscriptionButton.TabIndex = 2;
            subscriptionButton.Text = "Pretplata";
            subscriptionButton.UseVisualStyleBackColor = false;
            subscriptionButton.Click += subscriptionButton_Click;
            // 
            // goBackButton
            // 
            goBackButton.BackColor = Color.LightPink;
            goBackButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            goBackButton.Location = new Point(409, 321);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new Size(103, 53);
            goBackButton.TabIndex = 3;
            goBackButton.Text = "Povratak nazad";
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += goBackButton_Click;
            // 
            // MainStation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(923, 447);
            Controls.Add(goBackButton);
            Controls.Add(subscriptionButton);
            Controls.Add(payParkingButton);
            Controls.Add(reportButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainStation";
            Text = "Centralni objekat";
            FormClosing += MainStation_FormClosing;
            Resize += MainStation_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button reportButton;
        private Button payParkingButton;
        private Button subscriptionButton;
        private Button goBackButton;
    }
}