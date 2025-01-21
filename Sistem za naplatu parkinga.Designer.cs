namespace Sistem_za_naplatu_parkinga
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            label1 = new Label();
            controlParkingButton = new Button();
            useParkingButton = new Button();
            welcomeLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(707, 426);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "OSI Grupa 2";
            // 
            // controlParkingButton
            // 
            controlParkingButton.AutoSize = true;
            controlParkingButton.BackColor = Color.Khaki;
            controlParkingButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            controlParkingButton.Location = new Point(152, 175);
            controlParkingButton.Name = "controlParkingButton";
            controlParkingButton.Size = new Size(137, 72);
            controlParkingButton.TabIndex = 1;
            controlParkingButton.Text = "Upravljanje parkingom";
            controlParkingButton.UseVisualStyleBackColor = false;
            controlParkingButton.Click += button1_Click;
            // 
            // useParkingButton
            // 
            useParkingButton.BackColor = Color.LightPink;
            useParkingButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            useParkingButton.Location = new Point(495, 175);
            useParkingButton.Name = "useParkingButton";
            useParkingButton.Size = new Size(125, 71);
            useParkingButton.TabIndex = 2;
            useParkingButton.Text = "Korišćenje parkinga";
            useParkingButton.UseVisualStyleBackColor = false;
            useParkingButton.Click += button2_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeLabel.Location = new Point(245, 59);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(305, 21);
            welcomeLabel.TabIndex = 3;
            welcomeLabel.Text = "Dobrodošli u sistem za naplatu parkinga!";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(welcomeLabel);
            Controls.Add(useParkingButton);
            Controls.Add(controlParkingButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            Text = "Sistem za naplatu parkinga";
            TransparencyKey = Color.Transparent;
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            Resize += MainWindow_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button controlParkingButton;
        private Button useParkingButton;
        private Label welcomeLabel;
    }
}
