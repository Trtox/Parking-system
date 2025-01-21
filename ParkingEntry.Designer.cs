namespace Sistem_za_naplatu_parkinga
{
    partial class ParkingEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParkingEntry));
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            numPlateButton = new Button();
            label1 = new Label();
            enterParkingButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(123, 210);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // numPlateButton
            // 
            numPlateButton.BackColor = Color.LightPink;
            numPlateButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numPlateButton.Location = new Point(396, 105);
            numPlateButton.Name = "numPlateButton";
            numPlateButton.Size = new Size(245, 30);
            numPlateButton.TabIndex = 1;
            numPlateButton.Text = "Odaberite sliku registarskih oznaka";
            numPlateButton.UseVisualStyleBackColor = false;
            numPlateButton.Click += numPlateButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(419, 169);
            label1.Name = "label1";
            label1.Size = new Size(208, 15);
            label1.TabIndex = 2;
            label1.Text = "Očitavanje u toku, molimo sačekajte...";
            // 
            // enterParkingButton
            // 
            enterParkingButton.BackColor = Color.LightPink;
            enterParkingButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            enterParkingButton.Location = new Point(431, 474);
            enterParkingButton.Name = "enterParkingButton";
            enterParkingButton.Size = new Size(159, 32);
            enterParkingButton.TabIndex = 3;
            enterParkingButton.Text = "Ulazak na parking";
            enterParkingButton.UseVisualStyleBackColor = false;
            enterParkingButton.Click += enterParkingButton_Click;
            // 
            // ParkingEntry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1083, 555);
            Controls.Add(enterParkingButton);
            Controls.Add(label1);
            Controls.Add(numPlateButton);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ParkingEntry";
            Text = "Očitavanje registarskih oznaka";
            FormClosing += UserWindow_FormClosing;
            Resize += UserWindow_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private Button numPlateButton;
        private Label label1;
        private Button enterParkingButton;
    }
}