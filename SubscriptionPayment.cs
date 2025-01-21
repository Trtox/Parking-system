using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Sistem_za_naplatu_parkinga
{
    public partial class SubscriptionPayment : Form
    {

        bool newUser;
        bool method;
        MainStation? owner;
        double amount;
        string? email, name, surname,numberPlate;
        bool cnValid = false, edValid = false, cvvValid = false;
        public SubscriptionPayment(MainStation? owner, bool? newUser, string? email, string? name, string? surname, string? numberPlate)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.newUser = newUser ?? false;
            this.owner = owner;
            this.email = email;
            this.name = name;
            this.surname = surname;
            this.numberPlate = numberPlate;
            amount = calculateAmount();
            paymentAmountLabel.Text = "Iznos za plaćanje: " + amount + " BAM";

            cashAmountLabel.Visible = false;
            cashAmountBox.Visible = false;

            paymentButton.Visible = false;

            cardNumberLabel.Visible = false;
            cardNumberBox.Visible = false;
            expiryDateLabel.Visible = false;
            expiryDateBox.Visible = false;
            cvvLabel.Visible = false;
            cvvBox.Visible = false;
        }

        private double calculateAmount()
        {
            double amount = 0.0;
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT mjesecna FROM Cjenovnik WHERE validan = 1";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            amount = reader.GetDouble(reader.GetOrdinal("mjesecna"));
                        }
                    }
                }
            }

            return amount;
        }

        private void cashButton_Click(object sender, EventArgs e)
        {
            cashAmountLabel.Visible = true;
            cashAmountBox.Visible = true;
            paymentButton.Visible = true;

            cardNumberLabel.Visible = false;
            cardNumberBox.Visible = false;
            expiryDateLabel.Visible = false;
            expiryDateBox.Visible = false;
            cvvLabel.Visible = false;
            cvvBox.Visible = false;

            method = false;
        }

        private void cardButton_Click(object sender, EventArgs e)
        {
            cardNumberLabel.Visible = true;
            cardNumberBox.Visible = true;
            expiryDateLabel.Visible = true;
            expiryDateBox.Visible = true;
            cvvLabel.Visible = true;
            cvvBox.Visible = true;
            paymentButton.Visible = true;

            cashAmountLabel.Visible = false;
            cashAmountBox.Visible = false;

            method = true;
        }

        private void SubscriptionPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (owner != null && !owner.IsDisposed)
            {
                owner.Show();
            }
        }

        private void cardNumberBox_Validating(object sender, CancelEventArgs e)
        {
            string cardNumber = cardNumberBox.Text;
            string pattern = @"^\d{4}-\d{4}-\d{4}-\d{4}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, pattern))
            {
                e.Cancel = true;
                cardNumberBox.Focus();
                errorProvider1.SetError(cardNumberBox, "Broj kartice mora biti unesen u formatu XXXX-XXXX-XXXX-XXXX i sadržati 16 cifara.");
                cnValid = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cardNumberBox, "");
                cnValid = true;
            }
        }

        private void expiryDateBox_Validating(object sender, CancelEventArgs e)
        {
            string expiryDate = expiryDateBox.Text;
            string pattern = @"^(0[1-9]|1[0-2])\/\d{2}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(expiryDate, pattern))
            {
                e.Cancel = true;
                expiryDateBox.Focus();
                errorProvider1.SetError(expiryDateBox, "Datum isteka mora biti u formatu MM/YY.");
                edValid = false;
            }
            else
            {
                string[] parts = expiryDate.Split('/');
                int month = int.Parse(parts[0]);
                int year = int.Parse(parts[1]) + 2000;

                DateTime expiry = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
                if (expiry < DateTime.Now)
                {
                    e.Cancel = true;
                    expiryDateBox.Focus();
                    errorProvider1.SetError(expiryDateBox, "Datum isteka ne može biti u prošlosti.");
                    edValid = false;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(expiryDateBox, "");
                    edValid = true;
                }
            }
        }

        private void cvvBox_Validating(object sender, CancelEventArgs e)
        {
            string cvv = cvvBox.Text;
            string pattern = @"^\d{3,4}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(cvv, pattern))
            {
                e.Cancel = true;
                cvvBox.Focus();
                errorProvider1.SetError(cvvBox, "CVV/CVC2 broj mora sadržati 3 ili 4 cifre.");
                cvvValid = false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cvvBox, "");
                cvvValid = true;
            }
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            if(method == false)
            {
                if (double.TryParse(cashAmountBox.Text, out double cashAmount) && cashAmount >= amount)
                {

                    generateBill(false);

                    MessageBox.Show("Plaćanje uspješno.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (double.Parse(cashAmountBox.Text) > amount)
                        MessageBox.Show("Vaš kusur iznosi: " + (double.Parse(cashAmountBox.Text) - amount).ToString("0.00") + " BAM", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    paymentSuccessful();
                    owner.Show(); 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Uneseni iznos je manji od iznosa za plaćanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(cnValid && edValid && cvvValid)
            {
                generateBill(true);
                MessageBox.Show("Plaćanje uspješno.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                paymentSuccessful();
                owner.Show();
                this.Close();

            }
        }

        private void generateBill(bool method)
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "INSERT INTO Racuni (tiket, iznos, datum, placen, metod) VALUES (@tiket, @iznos, @datum, @placen, @metod)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tiket", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("@iznos", amount);
                    command.Parameters.AddWithValue("@datum", DateTime.Now);
                    command.Parameters.AddWithValue("@placen", 1);
                    command.Parameters.AddWithValue("@metod", method ? 1 : 0);

                    command.ExecuteNonQuery();
                }
            }

        }

        private void paymentSuccessful()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";

            if (newUser)
            {
                string query = "INSERT INTO 'Pretplaceni korisnici' (tablice, email, ime, prezime, prva_pretplata, datum_vazenja) VALUES (@tablice, @Email, @Ime, @Prezime, @PrvaPretplata, @DatumVazenja)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tablice", numberPlate);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Ime", name);
                        command.Parameters.AddWithValue("@Prezime", surname);
                        command.Parameters.AddWithValue("@PrvaPretplata", DateTime.Now);
                        command.Parameters.AddWithValue("@DatumVazenja", DateTime.Now.AddMonths(1));

                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                string query = "SELECT datum_vazenja FROM 'Pretplaceni korisnici' WHERE tablice = @tablice";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tablice", numberPlate);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime datumVazenja = reader.GetDateTime(reader.GetOrdinal("datum_vazenja"));
                                DateTime newDatumVazenja = datumVazenja < DateTime.Now ? DateTime.Now.AddMonths(1) : datumVazenja.AddMonths(1);

                                string updateQuery = "UPDATE 'Pretplaceni korisnici' SET datum_vazenja = @DatumVazenja WHERE tablice = @tablice";
                                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@DatumVazenja", newDatumVazenja);
                                    updateCommand.Parameters.AddWithValue("@tablice", numberPlate);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
