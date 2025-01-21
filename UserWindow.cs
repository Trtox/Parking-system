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
    public partial class UserWindow : Form
    {

        private string? numberPlate, ticketID;
        private DateTime? entryDate;
        public UserWindow(string? numberPlate, string? ticketID, DateTime? entryDate)
        {
            InitializeComponent();
            CenterItems();
            this.numberPlate = numberPlate;
            this.ticketID = ticketID;
            this.entryDate = entryDate;
        }

        private void CenterItems()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int buttonWidth = mainStationButton.Width;
            int buttonHeight = mainStationButton.Height;
            int totalButtonWidth = buttonWidth * 2;
            int horizontalSpacing = (formWidth - totalButtonWidth) / 3;
            int verticalSpacing = (formHeight - buttonHeight) / 2;

            mainStationButton.Left = horizontalSpacing;
            mainStationButton.Top = verticalSpacing;
            leaveParkingButton.Left = mainStationButton.Right + horizontalSpacing;
            leaveParkingButton.Top = verticalSpacing;
        }

        private void UserWindow_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }

        private void UserWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mainStationButton_Click(object sender, EventArgs e)
        {
            MainStation mainStation = new MainStation(this, numberPlate, ticketID);
            mainStation.Show();
            this.Hide();
        }

        private void leaveParkingButton_Click(object sender, EventArgs e)
        {
            if(hasSubscription())
            {
                MessageBox.Show("Hvala na korišćenju parkinga!\nDođite nam opet!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearDb();
                insertToHistory();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else if(paidTicket())
            {
                MessageBox.Show("Hvala na korišćenju parkinga!\nDođite nam opet!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearDb();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Molimo platite parking prije nego što napustite parking mjesto!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!isInParking())
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
        private bool hasSubscription()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT datum_vazenja FROM 'Pretplaceni korisnici' WHERE tablice = @numberPlate";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numberPlate", numberPlate);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime datumVazenja = reader.GetDateTime(0);
                            return datumVazenja > DateTime.Now;
                        }
                    }
                }
            }

            return false;
        }

        private bool paidTicket()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT placen, datum FROM 'Racuni' WHERE tiket = @ticketID ORDER BY datum DESC LIMIT 1";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ticketID", ticketID);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isPaid = reader.GetBoolean(0);
                            DateTime datum = reader.GetDateTime(1);
                            if (isPaid && (DateTime.Now - datum).TotalSeconds <= 15)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        private void clearDb()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "DELETE FROM 'Parking trenutno' WHERE tablice = @numberPlate";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numberPlate", numberPlate);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void insertToHistory()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "INSERT INTO 'Parking istorija' (tablice, vrijeme_ulaska, vrijeme_izlaska,pretplata, tiket) VALUES (@numberPlate, @vremeDolaska, @vremeOdlaska, 1, 'pretplata')";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numberPlate", numberPlate);
                    command.Parameters.AddWithValue("@vremeDolaska", entryDate);
                    command.Parameters.AddWithValue("@vremeOdlaska", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }
       
    }
}
