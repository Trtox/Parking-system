namespace Sistem_za_naplatu_parkinga
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            cashButton = new Button();
            cardButton = new Button();
            paymentAmountLabel = new Label();
            cashAmountBox = new TextBox();
            paymentButton = new Button();
            cashAmountLabel = new Label();
            cardNumberBox = new TextBox();
            cvvBox = new TextBox();
            expiryDateBox = new TextBox();
            cardNumberLabel = new Label();
            expiryDateLabel = new Label();
            cvvLabel = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cashButton
            // 
            cashButton.BackColor = Color.LightPink;
            cashButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cashButton.Location = new Point(200, 80);
            cashButton.Name = "cashButton";
            cashButton.Size = new Size(100, 55);
            cashButton.TabIndex = 0;
            cashButton.Text = "Gotovina";
            cashButton.UseVisualStyleBackColor = false;
            cashButton.Click += cashButton_Click;
            // 
            // cardButton
            // 
            cardButton.BackColor = Color.LightPink;
            cardButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardButton.Location = new Point(500, 80);
            cardButton.Name = "cardButton";
            cardButton.Size = new Size(100, 55);
            cardButton.TabIndex = 1;
            cardButton.Text = "Kartica";
            cardButton.UseVisualStyleBackColor = false;
            cardButton.Click += cardButton_Click;
            // 
            // paymentAmountLabel
            // 
            paymentAmountLabel.AutoSize = true;
            paymentAmountLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentAmountLabel.Location = new Point(351, 35);
            paymentAmountLabel.Name = "paymentAmountLabel";
            paymentAmountLabel.Size = new Size(101, 15);
            paymentAmountLabel.TabIndex = 2;
            paymentAmountLabel.Text = "Iznos za plaćanje:";
            // 
            // cashAmountBox
            // 
            cashAmountBox.BackColor = Color.LightPink;
            cashAmountBox.Location = new Point(155, 189);
            cashAmountBox.Name = "cashAmountBox";
            cashAmountBox.Size = new Size(174, 23);
            cashAmountBox.TabIndex = 3;
            // 
            // paymentButton
            // 
            paymentButton.BackColor = Color.LightPink;
            paymentButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentButton.Location = new Point(351, 362);
            paymentButton.Name = "paymentButton";
            paymentButton.Size = new Size(98, 41);
            paymentButton.TabIndex = 4;
            paymentButton.Text = "Plati";
            paymentButton.UseVisualStyleBackColor = false;
            paymentButton.Click += paymentButton_Click;
            // 
            // cashAmountLabel
            // 
            cashAmountLabel.AutoSize = true;
            cashAmountLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cashAmountLabel.Location = new Point(164, 171);
            cashAmountLabel.Name = "cashAmountLabel";
            cashAmountLabel.Size = new Size(154, 15);
            cashAmountLabel.TabIndex = 5;
            cashAmountLabel.Text = "Unesite koliko novca dajete:";
            // 
            // cardNumberBox
            // 
            cardNumberBox.BackColor = Color.LightPink;
            cardNumberBox.Location = new Point(468, 189);
            cardNumberBox.Name = "cardNumberBox";
            cardNumberBox.Size = new Size(180, 23);
            cardNumberBox.TabIndex = 6;
            cardNumberBox.Validating += cardNumberBox_Validating;
            // 
            // cvvBox
            // 
            cvvBox.BackColor = Color.LightPink;
            cvvBox.Location = new Point(500, 318);
            cvvBox.Name = "cvvBox";
            cvvBox.Size = new Size(100, 23);
            cvvBox.TabIndex = 7;
            cvvBox.Validating += cvvBox_Validating;
            // 
            // expiryDateBox
            // 
            expiryDateBox.BackColor = Color.LightPink;
            expiryDateBox.Location = new Point(500, 260);
            expiryDateBox.Name = "expiryDateBox";
            expiryDateBox.Size = new Size(100, 23);
            expiryDateBox.TabIndex = 8;
            expiryDateBox.Validating += expiryDateBox_Validating;
            // 
            // cardNumberLabel
            // 
            cardNumberLabel.AutoSize = true;
            cardNumberLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardNumberLabel.Location = new Point(519, 171);
            cardNumberLabel.Name = "cardNumberLabel";
            cardNumberLabel.Size = new Size(69, 15);
            cardNumberLabel.TabIndex = 9;
            cardNumberLabel.Text = "Broj kartice:";
            // 
            // expiryDateLabel
            // 
            expiryDateLabel.AutoSize = true;
            expiryDateLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            expiryDateLabel.Location = new Point(509, 242);
            expiryDateLabel.Name = "expiryDateLabel";
            expiryDateLabel.Size = new Size(80, 15);
            expiryDateLabel.TabIndex = 10;
            expiryDateLabel.Text = "Datum isteka:";
            // 
            // cvvLabel
            // 
            cvvLabel.AutoSize = true;
            cvvLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cvvLabel.Location = new Point(519, 300);
            cvvLabel.Name = "cvvLabel";
            cvvLabel.Size = new Size(67, 15);
            cvvLabel.TabIndex = 11;
            cvvLabel.Text = "CVV/CVC2:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(784, 461);
            Controls.Add(cvvLabel);
            Controls.Add(expiryDateLabel);
            Controls.Add(cardNumberLabel);
            Controls.Add(expiryDateBox);
            Controls.Add(cvvBox);
            Controls.Add(cardNumberBox);
            Controls.Add(cashAmountLabel);
            Controls.Add(paymentButton);
            Controls.Add(cashAmountBox);
            Controls.Add(paymentAmountLabel);
            Controls.Add(cardButton);
            Controls.Add(cashButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PaymentForm";
            Text = "Plaćanje";
            FormClosing += PaymentForm_FormClosing;
            Load += PaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cashButton;
        private Button cardButton;
        private Label paymentAmountLabel;
        private TextBox cashAmountBox;
        private Button paymentButton;
        private Label cashAmountLabel;
        private TextBox cardNumberBox;
        private TextBox cvvBox;
        private TextBox expiryDateBox;
        private Label cardNumberLabel;
        private Label expiryDateLabel;
        private Label cvvLabel;
        private ErrorProvider errorProvider1;
    }
}