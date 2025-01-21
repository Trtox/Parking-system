using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_za_naplatu_parkinga
{
    public partial class AdminFunction : Form
    {
        string? email, password, ime, prezime;
        ChangePassword? chPass = null;
        PriceChange? priceChange = null;
        CreateAccount? createAccount = null;
        DeleteAccount? deleteAccount = null;
        Statistics? stats = null;
        public AdminFunction(Form adminWindow, string? aemail, string? apassword, string? aime, string? aprezime)
        {
            InitializeComponent();
            email = aemail;
            password = apassword;
            ime = aime;
            prezime = aprezime;
        }

        private void AdminFunction_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = "Dobrodošli, " + ime + " " + prezime + "!";
            LoadAdministratorsData();
            welcomeLabel.Left = (this.ClientSize.Width - welcomeLabel.Width) / 2;
            welcomeLabel.Top = 30;

            dataGridView1.Left = 70;
            dataGridView1.Top = welcomeLabel.Bottom + 50;
            dataGridView1.Width = this.ClientSize.Width - 300;
            dataGridView1.Height = this.ClientSize.Height - dataGridView1.Top - 100;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            userTypeFilter.Left = 70;
            userTypeFilter.Top = dataGridView1.Top - 30;

            deleteAccButton.Top = userTypeFilter.Top;
            deleteAccButton.Left = dataGridView1.Right - createAccButton.Width;

            createAccButton.Top = userTypeFilter.Top;
            createAccButton.Left = deleteAccButton.Left - createAccButton.Width - 10;

            statsButton.Left = dataGridView1.Right + 50;
            statsButton.Top = dataGridView1.Top;

            priceButton.Left = dataGridView1.Right + 50;
            priceButton.Top = statsButton.Bottom + 20;

            refreshButton.Left = dataGridView1.Right + 50;
            refreshButton.Top = priceButton.Bottom + 20;

            logoutButton.Left = dataGridView1.Right + 50;
            logoutButton.Top = dataGridView1.Bottom - logoutButton.Height;

            changePassButton.Left = dataGridView1.Right + 50;
            changePassButton.Top = logoutButton.Top - changePassButton.Height - 10;

        }

        private void LoadAdministratorsData()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Administrators";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridView1.ReadOnly = true;
                }
            }
        }
        private void AdminFunction_Resize(object sender, EventArgs e)
        {
            welcomeLabel.Left = (this.ClientSize.Width - welcomeLabel.Width) / 2;
            welcomeLabel.Top = 30;

            dataGridView1.Left = 70;
            dataGridView1.Top = welcomeLabel.Bottom + 50;
            dataGridView1.Width = this.ClientSize.Width - 300;
            dataGridView1.Height = this.ClientSize.Height - dataGridView1.Top - 100;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            userTypeFilter.Left = 70;
            userTypeFilter.Top = dataGridView1.Top - 30;

            deleteAccButton.Top = userTypeFilter.Top;
            deleteAccButton.Left = dataGridView1.Right - createAccButton.Width;

            createAccButton.Top = userTypeFilter.Top;
            createAccButton.Left = deleteAccButton.Left - createAccButton.Width - 10;

            statsButton.Left = dataGridView1.Right + 50;
            statsButton.Top = dataGridView1.Top;

            priceButton.Left = dataGridView1.Right + 50;
            priceButton.Top = statsButton.Bottom + 20;

            refreshButton.Left = dataGridView1.Right + 50;
            refreshButton.Top = priceButton.Bottom + 20;

            logoutButton.Left = dataGridView1.Right + 50;
            logoutButton.Top = dataGridView1.Bottom - logoutButton.Height;

            changePassButton.Left = dataGridView1.Right + 50;
            changePassButton.Top = logoutButton.Top - changePassButton.Height - 10;

        }


        private void userTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Administrators WHERE uloga = @role";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@role", userTypeFilter.SelectedItem.ToString());
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridView1.ReadOnly = true;
                }
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form adminWindow = new AdminWindow();
            adminWindow.FormClosed += (s, args) => this.Close();
            adminWindow.Show();

        }

        private void AdminFunction_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadAdministratorsData();
        }

        private void changePassButton_Click(object sender, EventArgs e)
        {
            if (chPass == null || chPass.IsDisposed)
            {
                chPass = new ChangePassword(email);
                chPass.FormClosed += (s, args) => chPass = null;
                chPass.Show();
            }
            else
            {
                MessageBox.Show("Prozor za promjenu lozinke je već otvoren!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void priceButton_Click(object sender, EventArgs e)
        {
            if (priceChange == null || priceChange.IsDisposed)
            {
                priceChange = new PriceChange();
                priceChange.FormClosed += (s, args) => priceChange = null;
                priceChange.Show();
            }
            else
            {
                MessageBox.Show("Prozor za promjenu cjenovnika je već otvoren!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void createAccButton_Click(object sender, EventArgs e)
        {
            if (createAccount == null || createAccount.IsDisposed)
            {
                createAccount = new CreateAccount();
                createAccount.FormClosed += (s, args) => createAccount = null;
                createAccount.Show();
            }
            else
            {
                MessageBox.Show("Prozor za kreiranje naloga je već otvoren!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteAccButton_Click(object sender, EventArgs e)
        {
            if (deleteAccount == null || deleteAccount.IsDisposed)
            {
                deleteAccount = new DeleteAccount(email);
                deleteAccount.FormClosed += (s, args) => deleteAccount = null;
                deleteAccount.Show();
            }
            else
            {
                MessageBox.Show("Prozor za brisanje naloga je već otvoren!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void statsButton_Click(object sender, EventArgs e)
        {
            if (stats == null || stats.IsDisposed)
            {
                stats = new Statistics();
                stats.FormClosed += (s, args) => stats = null;
                stats.Show();
            }
            else
            {
                MessageBox.Show("Prozor za prikaz statistike je već otvoren!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
