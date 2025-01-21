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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Početno vrijeme ne može biti ispred krajnjeg.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker2.Value = dateTimePicker1.Value;
            }
            else
            {
                string connectionString = "Data Source=SNP-DB.db;Version=3;";
                string queryParkingIstorija = "SELECT * FROM [Parking istorija] WHERE vrijeme_izlaska BETWEEN @startDate AND @endDate";
                string queryRacuni = "SELECT * FROM [Racuni] WHERE Datum BETWEEN @startDate AND @endDate";
                usernumLabel.Visible = true;
                earningsLabel.Visible = true;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(queryParkingIstorija, connection))
                    {
                        command.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@endDate", dateTimePicker2.Value);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                            usernumLabel.Text = "Broj korisnika u navedenom periodu: " + dataTable.Rows.Count.ToString();
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(queryRacuni, connection))
                    {
                        command.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@endDate", dateTimePicker2.Value);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView2.DataSource = dataTable;

                            decimal totalEarnings = dataTable.AsEnumerable().Sum(row => Convert.ToDecimal(row.Field<double>("iznos")));
                            earningsLabel.Text = "Zarada u navedenom periodu: " + totalEarnings.ToString("N2") + "BAM";
                        }
                    }
                }
            }
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            usernumLabel.Visible = false;
            earningsLabel.Visible = false;
        }
    }
}
