namespace Sistem_za_naplatu_parkinga
{
    partial class UserWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserWindow));
            mainStationButton = new Button();
            leaveParkingButton = new Button();
            SuspendLayout();
            // 
            // mainStationButton
            // 
            mainStationButton.BackColor = Color.LightPink;
            mainStationButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainStationButton.Location = new Point(177, 162);
            mainStationButton.Name = "mainStationButton";
            mainStationButton.Size = new Size(121, 73);
            mainStationButton.TabIndex = 1;
            mainStationButton.Text = "Upotreba centralnog objekta";
            mainStationButton.UseVisualStyleBackColor = false;
            mainStationButton.Click += mainStationButton_Click;
            // 
            // leaveParkingButton
            // 
            leaveParkingButton.BackColor = Color.LightPink;
            leaveParkingButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leaveParkingButton.Location = new Point(457, 162);
            leaveParkingButton.Name = "leaveParkingButton";
            leaveParkingButton.Size = new Size(127, 73);
            leaveParkingButton.TabIndex = 2;
            leaveParkingButton.Text = "Izlazak sa parkinga";
            leaveParkingButton.UseVisualStyleBackColor = false;
            leaveParkingButton.Click += leaveParkingButton_Click;
            // 
            // UserWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(leaveParkingButton);
            Controls.Add(mainStationButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserWindow";
            Text = "Parking";
            FormClosing += UserWindow_FormClosing;
            Resize += UserWindow_Resize;
            ResumeLayout(false);
        }

        #endregion
        private Button mainStationButton;
        private Button leaveParkingButton;
    }
}