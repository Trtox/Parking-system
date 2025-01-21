using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.VisualStyles;

namespace Sistem_za_naplatu_parkinga
{
    public partial class MainStation : Form
    {
        string? numberPlate, ticketID;
        UserWindow? ownerForm;
        public MainStation(UserWindow? ownerForm, string? numberPlate, string? ticketID)
        {
            InitializeComponent();
            CenterItems();
            this.numberPlate = numberPlate;
            this.ticketID = ticketID;
            this.ownerForm = ownerForm;

        }

        private void MainStation_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }

        private void CenterItems()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int buttonWidth = reportButton.Width;
            int buttonHeight = reportButton.Height;
            int totalButtonWidth = buttonWidth * 3;
            int horizontalSpacing = (formWidth - totalButtonWidth) / 4;
            int verticalSpacing = (formHeight - buttonHeight) / 2;

            goBackButton.Size = payParkingButton.Size = reportButton.Size = subscriptionButton.Size = new Size(buttonWidth, buttonHeight);

            payParkingButton.Left = horizontalSpacing;
            payParkingButton.Top = verticalSpacing;
            subscriptionButton.Left = payParkingButton.Right + horizontalSpacing;
            subscriptionButton.Top = verticalSpacing;
            reportButton.Left = subscriptionButton.Right + horizontalSpacing;
            reportButton.Top = verticalSpacing;

            goBackButton.Left = subscriptionButton.Left;
            goBackButton.Top = subscriptionButton.Bottom + 50;
        }

        private void payParkingButton_Click(object sender, EventArgs e)
        {
            if (checkSubscription().Item1)
            {
                MessageBox.Show("Posjedujete aktivnu mjesečnu pretplatu, ne trebate platiti parking! ", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               if(!isInParking())
                {
                    string connectionString = "Data Source=SNP-DB.db;Version=3;";
                    string query = "INSERT INTO 'Parking trenutno' (tablice, datum_ulaska, tiket, racun, racun_placen) VALUES (@numberPlate, @datumUlaska, @ticketID, '0', 0)";

                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@numberPlate", numberPlate);
                            command.Parameters.AddWithValue("@datumUlaska", DateTime.Now);
                            command.Parameters.AddWithValue("@ticketID", ticketID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                PaymentForm paymentForm = new PaymentForm(this, numberPlate, ticketID);
                paymentForm.Show();
                this.Hide();
            }
        }

        private bool isInParking()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT COUNT(*) FROM 'Parking trenutno' WHERE tablice = @numberPlate";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numberPlate", numberPlate);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private Tuple<bool, DateTime> checkSubscription()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT datum_vazenja FROM 'Pretplaceni korisnici' WHERE tablice = @numberPlate";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numberPlate", numberPlate);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime subscriptionDate = reader.GetDateTime(0);
                            if (subscriptionDate > DateTime.Now)
                            {
                               // MessageBox.Show(subscriptionDate.ToString());
                                return Tuple.Create(true, subscriptionDate);
                            }
                            else
                            {
                                return Tuple.Create(false, subscriptionDate);
                            }
                        }
                        else
                        {
                            return Tuple.Create(false, DateTime.Now);
                        }
                    }
                }
            }
        }

        private void subscriptionButton_Click(object sender, EventArgs e)
        {
            SubscriptionForm subscriptionForm = new SubscriptionForm(this, numberPlate);
            subscriptionForm.Show();
            this.Hide();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            ownerForm.Show();
            this.Close();
        }

        private void MainStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            ownerForm.Show();
        }
    }
    
}
