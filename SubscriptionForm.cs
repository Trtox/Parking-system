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

namespace Sistem_za_naplatu_parkinga
{
    public partial class SubscriptionForm : Form
    {
        string? numberPlate;
        MainStation? owner;
        string email, name, surname;
        public SubscriptionForm(MainStation? owner, string? numberPlate)
        {
            InitializeComponent();
            centralButton.Visible = false;
            this.numberPlate = numberPlate;
            this.owner = owner;
            LoadData();
            CenterItems();

        }


        private void SubscriptionForm_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }

        private void CenterItems()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int labelWidth = subscriptionStatus.Width;
            int labelHeight = subscriptionStatus.Height;
            int horizontalSpacing = (formWidth - labelWidth) / 2;
            int verticalSpacing = (formHeight - centralButton.Height) / 2;

            subscriptionStatus.Location = new Point(horizontalSpacing, 80);
            centralButton.Location = new Point((formWidth - centralButton.Width) / 2, verticalSpacing);
        }
        private void LoadData()
        {

            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT * FROM 'Pretplaceni korisnici' WHERE tablice = @numberPlate";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@numberPlate", numberPlate);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                email = reader["email"].ToString();
                                name = reader["ime"].ToString();
                                surname = reader["prezime"].ToString();
                                DateTime firstSubscription = Convert.ToDateTime(reader["prva_pretplata"]);
                                DateTime expiryDate = Convert.ToDateTime(reader["datum_vazenja"]);

                                if (DateTime.Now > expiryDate)
                                {
                                    subscriptionStatus.Text = "Status pretplate:\nPretplata istekla: " + expiryDate.ToString("g");
                                    expiredSubscription(name, surname, email, firstSubscription, expiryDate);
                                }
                                else
                                {
                                    subscriptionStatus.Text = "Status pretplate:\nAktivna pretplata.\nVrijedi do: " + expiryDate.ToString("g");
                                    hasSubscription(name, surname, email, firstSubscription, expiryDate);
                                }

                            }
                            else
                            {
                                subscriptionStatus.Text = "Status pretplate:\nNemate aktivnu pretplatu.";
                                noSubscription();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Desila se greška: " + ex.Message);
                }
            }
        }
        private void hasSubscription(string ime, string prezime, string email, DateTime firstSubscription, DateTime expiryDate)
        {
            centralButton.Visible = true;
            centralButton.Text = "Produži pretplatu";
        }

        private void expiredSubscription(string ime, string prezime, string email, DateTime firstSubscription, DateTime expiryDate)
        {
            centralButton.Visible = true;
            centralButton.Text = "Obnovi pretplatu";
        }

        private void noSubscription()
        {
            centralButton.Visible = true;
            centralButton.Text = "Pretplati se";
        }

        private void centralButton_Click(object sender, EventArgs e)
        {
            if (centralButton.Text == "Pretplati se")
            {
                NewUserSubscription subscriptionForm2 = new NewUserSubscription(owner, numberPlate);    
                subscriptionForm2.Show();
                this.Hide();
            }
            else if (centralButton.Text == "Produži pretplatu")
            {
                SubscriptionPayment subscriptionPaymentForm = new SubscriptionPayment(owner, false, email, name, surname, numberPlate);
                subscriptionPaymentForm.Show();
                this.Hide();
            }
            else if (centralButton.Text == "Obnovi pretplatu")
            {
                SubscriptionPayment subscriptionPaymentForm = new SubscriptionPayment(owner, false, email, name, surname, numberPlate);
                subscriptionPaymentForm.Show();
                this.Hide();
            }
        }

        private void SubscriptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!owner.IsDisposed && owner != null)
                owner.Show();
        }
    }

}
