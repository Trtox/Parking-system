using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Sistem_za_naplatu_parkinga
{
    public partial class PriceChange : Form
    {
        public PriceChange()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            zonePicker.SelectedIndex = 0;
            LoadPrices(0);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PriceChange_Load(object sender, EventArgs e)
        {

        }

        private void zonePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (zonePicker.SelectedIndex)
            {
                case 0:
                    LoadPrices(0);
                    break;
                case 1:
                    LoadPrices(1);
                    break;
                case 2:
                    LoadPrices(2);
                    break;

            }
        }

        private void LoadPrices(int zone)
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT sat, dnevna, mjesecna, od_datum, do_datum FROM Cjenovnik WHERE zona = @zone";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@zone", zone);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hour.Value = reader.GetDecimal(reader.GetOrdinal("sat"));                      
                            day.Value = reader.GetDecimal(reader.GetOrdinal("dnevna"));
                            month.Value = reader.GetDecimal(reader.GetOrdinal("mjesecna"));
                            string startDateString = reader.GetString(reader.GetOrdinal("od_datum"));
                            string endDateString = reader.GetString(reader.GetOrdinal("do_datum"));
                            DateTime startDate = DateTime.Parse(startDateString);
                            DateTime endDate = DateTime.Parse(endDateString);
                            startDatePicker.Value = startDate;
                            endDatePicker.Value = endDate;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri čitanju podataka iz baze: " + ex.Message, "Greška");
                }
            }
        }

        private void activateZoneButton_Click(object sender, EventArgs e)
        {
            int selectedZone = zonePicker.SelectedIndex;
            string connectionString = "Data Source=SNP-DB.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deactivateAllQuery = "UPDATE Cjenovnik SET validan = 0";
                    using (SQLiteCommand deactivateAllCommand = new SQLiteCommand(deactivateAllQuery, connection))
                    {
                        deactivateAllCommand.ExecuteNonQuery();
                    }

                    string activateSelectedQuery = "UPDATE Cjenovnik SET validan = 1 WHERE zona = @zone";
                    using (SQLiteCommand activateSelectedCommand = new SQLiteCommand(activateSelectedQuery, connection))
                    {
                        activateSelectedCommand.Parameters.AddWithValue("@zone", selectedZone);
                        activateSelectedCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Zona je uspješno aktivirana.", "Obavještenje");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri ažuriranju podataka u bazi: " + ex.Message, "Greška");
                }
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int selectedZone = zonePicker.SelectedIndex;
            string connectionString = "Data Source=SNP-DB.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE Cjenovnik SET sat = @sat, dnevna = @dnevna, mjesecna = @mjesecna, od_datum = @od_datum, do_datum = @do_datum WHERE zona = @zone";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@sat", hour.Value);
                        updateCommand.Parameters.AddWithValue("@dnevna", day.Value);
                        updateCommand.Parameters.AddWithValue("@mjesecna", month.Value);
                        updateCommand.Parameters.AddWithValue("@od_datum", startDatePicker.Value.ToString("yyyy-MM-dd HH:MM:ss"));
                        updateCommand.Parameters.AddWithValue("@do_datum", endDatePicker.Value.ToString("yyyy-MM-dd HH:MM:ss"));
                        updateCommand.Parameters.AddWithValue("@zone", selectedZone);

                        updateCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Podaci su uspješno ažurirani.", "Obavještenje");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri ažuriranju podataka u bazi: " + ex.Message, "Greška");
                }
            }
        }
    }
}
