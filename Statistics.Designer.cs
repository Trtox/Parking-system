namespace Sistem_za_naplatu_parkinga
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            dataGridView1 = new DataGridView();
            usernumLabel = new Label();
            earningsLabel = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            startDateLabel = new Label();
            endDateLabel = new Label();
            dataGridView2 = new DataGridView();
            dg1Label = new Label();
            dg2Label = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(53, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(550, 516);
            dataGridView1.TabIndex = 1;
            // 
            // usernumLabel
            // 
            usernumLabel.AutoSize = true;
            usernumLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            usernumLabel.Location = new Point(794, 45);
            usernumLabel.Name = "usernumLabel";
            usernumLabel.Size = new Size(81, 15);
            usernumLabel.TabIndex = 2;
            usernumLabel.Text = "Broj korisnika:";
            // 
            // earningsLabel
            // 
            earningsLabel.AutoSize = true;
            earningsLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            earningsLabel.Location = new Point(794, 60);
            earningsLabel.Name = "earningsLabel";
            earningsLabel.Size = new Size(46, 15);
            earningsLabel.TabIndex = 3;
            earningsLabel.Text = "Zarada:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(79, 63);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(457, 63);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            startDateLabel.Location = new Point(161, 45);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(26, 15);
            startDateLabel.TabIndex = 6;
            startDateLabel.Text = "Od:";
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            endDateLabel.Location = new Point(564, 45);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(26, 15);
            endDateLabel.TabIndex = 7;
            endDateLabel.Text = "Do:";
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(692, 114);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(611, 516);
            dataGridView2.TabIndex = 8;
            // 
            // dg1Label
            // 
            dg1Label.AutoSize = true;
            dg1Label.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dg1Label.Location = new Point(228, 96);
            dg1Label.Name = "dg1Label";
            dg1Label.Size = new Size(204, 15);
            dg1Label.TabIndex = 9;
            dg1Label.Text = "Pregled vozila u navedenom periodu:";
            // 
            // dg2Label
            // 
            dg2Label.AutoSize = true;
            dg2Label.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dg2Label.Location = new Point(909, 96);
            dg2Label.Name = "dg2Label";
            dg2Label.Size = new Size(201, 15);
            dg2Label.TabIndex = 10;
            dg2Label.Text = "Računi izdani u navedenom periodu:";
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1335, 665);
            Controls.Add(dg2Label);
            Controls.Add(dg1Label);
            Controls.Add(dataGridView2);
            Controls.Add(endDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(earningsLabel);
            Controls.Add(usernumLabel);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Statistics";
            Text = "Prikaz statistike poslovanja";
            Load += Statistics_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label usernumLabel;
        private Label earningsLabel;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label startDateLabel;
        private Label endDateLabel;
        private DataGridView dataGridView2;
        private Label dg1Label;
        private Label dg2Label;
    }
}