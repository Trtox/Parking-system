namespace Sistem_za_naplatu_parkinga
{
    partial class PriceChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceChange));
            hour = new NumericUpDown();
            day = new NumericUpDown();
            month = new NumericUpDown();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            zonePicker = new ComboBox();
            zoneLabel = new Label();
            activateZoneButton = new Button();
            startDateLabel = new Label();
            endDateLabel = new Label();
            confirmButton = new Button();
            hourLabel = new Label();
            dayLabel = new Label();
            monthLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)hour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)day).BeginInit();
            ((System.ComponentModel.ISupportInitialize)month).BeginInit();
            SuspendLayout();
            // 
            // hour
            // 
            hour.BackColor = Color.Khaki;
            hour.DecimalPlaces = 2;
            hour.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            hour.Location = new Point(166, 178);
            hour.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            hour.Name = "hour";
            hour.Size = new Size(120, 23);
            hour.TabIndex = 0;
            hour.TextAlign = HorizontalAlignment.Center;
            // 
            // day
            // 
            day.BackColor = Color.Khaki;
            day.DecimalPlaces = 2;
            day.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            day.Location = new Point(337, 178);
            day.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            day.Name = "day";
            day.Size = new Size(120, 23);
            day.TabIndex = 1;
            day.TextAlign = HorizontalAlignment.Center;
            // 
            // month
            // 
            month.BackColor = Color.Khaki;
            month.DecimalPlaces = 2;
            month.Location = new Point(513, 178);
            month.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            month.Name = "month";
            month.Size = new Size(120, 23);
            month.TabIndex = 2;
            month.TextAlign = HorizontalAlignment.Center;
            // 
            // startDatePicker
            // 
            startDatePicker.CalendarForeColor = SystemColors.ControlLight;
            startDatePicker.CalendarTitleBackColor = Color.Transparent;
            startDatePicker.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            startDatePicker.Location = new Point(120, 320);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(200, 23);
            startDatePicker.TabIndex = 3;
            startDatePicker.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // endDatePicker
            // 
            endDatePicker.CalendarForeColor = SystemColors.ControlLight;
            endDatePicker.CalendarTitleBackColor = Color.Transparent;
            endDatePicker.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            endDatePicker.Location = new Point(480, 320);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(200, 23);
            endDatePicker.TabIndex = 4;
            // 
            // zonePicker
            // 
            zonePicker.BackColor = Color.Khaki;
            zonePicker.FormattingEnabled = true;
            zonePicker.Items.AddRange(new object[] { "Zona 0", "Zona 1", "Zona 2" });
            zonePicker.Location = new Point(185, 76);
            zonePicker.Name = "zonePicker";
            zonePicker.Size = new Size(121, 23);
            zonePicker.TabIndex = 5;
            zonePicker.SelectedIndexChanged += zonePicker_SelectedIndexChanged;
            // 
            // zoneLabel
            // 
            zoneLabel.AutoSize = true;
            zoneLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            zoneLabel.Location = new Point(203, 58);
            zoneLabel.Name = "zoneLabel";
            zoneLabel.Size = new Size(86, 15);
            zoneLabel.TabIndex = 6;
            zoneLabel.Text = "Izaberite zonu:";
            // 
            // activateZoneButton
            // 
            activateZoneButton.BackColor = Color.Khaki;
            activateZoneButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            activateZoneButton.Location = new Point(463, 76);
            activateZoneButton.Name = "activateZoneButton";
            activateZoneButton.Size = new Size(95, 23);
            activateZoneButton.TabIndex = 7;
            activateZoneButton.Text = "Aktiviraj zonu";
            activateZoneButton.UseVisualStyleBackColor = false;
            activateZoneButton.Click += activateZoneButton_Click;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            startDateLabel.Location = new Point(185, 302);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(61, 15);
            startDateLabel.TabIndex = 8;
            startDateLabel.Text = "Vrijedi od:";
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            endDateLabel.Location = new Point(546, 302);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(61, 15);
            endDateLabel.TabIndex = 9;
            endDateLabel.Text = "Vrijedi do:";
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.Khaki;
            confirmButton.Location = new Point(358, 389);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(84, 23);
            confirmButton.TabIndex = 10;
            confirmButton.Text = "Potvrdi";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // hourLabel
            // 
            hourLabel.AutoSize = true;
            hourLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            hourLabel.Location = new Point(203, 160);
            hourLabel.Name = "hourLabel";
            hourLabel.Size = new Size(27, 15);
            hourLabel.TabIndex = 12;
            hourLabel.Text = "Sat:";
            // 
            // dayLabel
            // 
            dayLabel.AutoSize = true;
            dayLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dayLabel.Location = new Point(367, 160);
            dayLabel.Name = "dayLabel";
            dayLabel.Size = new Size(51, 15);
            dayLabel.TabIndex = 14;
            dayLabel.Text = "Dnevna:";
            // 
            // monthLabel
            // 
            monthLabel.AutoSize = true;
            monthLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            monthLabel.Location = new Point(546, 160);
            monthLabel.Name = "monthLabel";
            monthLabel.Size = new Size(60, 15);
            monthLabel.TabIndex = 15;
            monthLabel.Text = "Mjesečna:";
            // 
            // PriceChange
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(784, 461);
            Controls.Add(monthLabel);
            Controls.Add(dayLabel);
            Controls.Add(hourLabel);
            Controls.Add(confirmButton);
            Controls.Add(endDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(activateZoneButton);
            Controls.Add(zoneLabel);
            Controls.Add(zonePicker);
            Controls.Add(month);
            Controls.Add(day);
            Controls.Add(hour);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PriceChange";
            Text = "Promjena cjenovnika";
            Load += PriceChange_Load;
            ((System.ComponentModel.ISupportInitialize)hour).EndInit();
            ((System.ComponentModel.ISupportInitialize)day).EndInit();
            ((System.ComponentModel.ISupportInitialize)month).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown hour;
        private NumericUpDown day;
        private NumericUpDown month;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private ComboBox zonePicker;
        private Label zoneLabel;
        private Button activateZoneButton;
        private Label startDateLabel;
        private Label endDateLabel;
        private Button confirmButton;
        private Label hourLabel;
        private Label dayLabel;
        private Label monthLabel;
    }
}