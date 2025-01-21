namespace Sistem_za_naplatu_parkinga
{
    partial class AdminFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFunction));
            welcomeLabel = new Label();
            userTypeFilter = new ComboBox();
            dataGridView1 = new DataGridView();
            createAccButton = new Button();
            deleteAccButton = new Button();
            changePassButton = new Button();
            logoutButton = new Button();
            priceButton = new Button();
            statsButton = new Button();
            refreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeLabel.Location = new Point(427, 20);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(94, 20);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Dobrodošli, ";
            // 
            // userTypeFilter
            // 
            userTypeFilter.BackColor = Color.Khaki;
            userTypeFilter.FormattingEnabled = true;
            userTypeFilter.Items.AddRange(new object[] { "administrator", "operater" });
            userTypeFilter.Location = new Point(73, 114);
            userTypeFilter.Name = "userTypeFilter";
            userTypeFilter.Size = new Size(121, 23);
            userTypeFilter.TabIndex = 1;
            userTypeFilter.SelectedIndexChanged += userTypeFilter_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(73, 165);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(777, 335);
            dataGridView1.TabIndex = 2;
            // 
            // createAccButton
            // 
            createAccButton.BackColor = Color.Khaki;
            createAccButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            createAccButton.Location = new Point(612, 113);
            createAccButton.Name = "createAccButton";
            createAccButton.Size = new Size(91, 23);
            createAccButton.TabIndex = 3;
            createAccButton.Text = "Kreiraj nalog";
            createAccButton.UseVisualStyleBackColor = false;
            createAccButton.Click += createAccButton_Click;
            // 
            // deleteAccButton
            // 
            deleteAccButton.BackColor = Color.Khaki;
            deleteAccButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteAccButton.Location = new Point(756, 113);
            deleteAccButton.Name = "deleteAccButton";
            deleteAccButton.Size = new Size(94, 23);
            deleteAccButton.TabIndex = 4;
            deleteAccButton.Text = "Obriši nalog";
            deleteAccButton.UseVisualStyleBackColor = false;
            deleteAccButton.Click += deleteAccButton_Click;
            // 
            // changePassButton
            // 
            changePassButton.BackColor = Color.Khaki;
            changePassButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changePassButton.Location = new Point(917, 403);
            changePassButton.Name = "changePassButton";
            changePassButton.Size = new Size(75, 42);
            changePassButton.TabIndex = 5;
            changePassButton.Text = "Promjena šifre";
            changePassButton.UseVisualStyleBackColor = false;
            changePassButton.Click += changePassButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.Khaki;
            logoutButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutButton.Location = new Point(917, 470);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 30);
            logoutButton.TabIndex = 6;
            logoutButton.Text = "Odjava";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // priceButton
            // 
            priceButton.BackColor = Color.Khaki;
            priceButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceButton.Location = new Point(917, 218);
            priceButton.Name = "priceButton";
            priceButton.Size = new Size(75, 46);
            priceButton.TabIndex = 7;
            priceButton.Text = "Promjena cjenovnika";
            priceButton.UseVisualStyleBackColor = false;
            priceButton.Click += priceButton_Click;
            // 
            // statsButton
            // 
            statsButton.BackColor = Color.Khaki;
            statsButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statsButton.Location = new Point(917, 165);
            statsButton.Name = "statsButton";
            statsButton.Size = new Size(75, 29);
            statsButton.TabIndex = 8;
            statsButton.Text = "Statistika";
            statsButton.UseVisualStyleBackColor = false;
            statsButton.Click += statsButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.Khaki;
            refreshButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refreshButton.Location = new Point(917, 283);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 44);
            refreshButton.TabIndex = 9;
            refreshButton.Text = "Osvježi prikaz";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += refreshButton_Click;
            // 
            // AdminFunction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1013, 560);
            Controls.Add(refreshButton);
            Controls.Add(statsButton);
            Controls.Add(priceButton);
            Controls.Add(logoutButton);
            Controls.Add(changePassButton);
            Controls.Add(deleteAccButton);
            Controls.Add(createAccButton);
            Controls.Add(dataGridView1);
            Controls.Add(userTypeFilter);
            Controls.Add(welcomeLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminFunction";
            Text = "Administracija";
            FormClosing += AdminFunction_FormClosing;
            Load += AdminFunction_Load;
            Resize += AdminFunction_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private ComboBox userTypeFilter;
        private DataGridView dataGridView1;
        private Button createAccButton;
        private Button deleteAccButton;
        private Button changePassButton;
        private Button logoutButton;
        private Button priceButton;
        private Button statsButton;
        private Button refreshButton;
    }
}