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
using System.ComponentModel.DataAnnotations;

namespace Sistem_za_naplatu_parkinga
{
    public partial class DeleteAccount : Form
    {
        private string? email;
        public DeleteAccount(string? aemail)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            email = aemail;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == email)
                MessageBox.Show("Nije moguće obrisati trenutno prijavljeni nalog!", "Obavještenje");
            else if (validateEmail(textBox1.Text))
            {
                string connectionString = "Data Source=SNP-DB.db;Version=3;";
                string email = textBox1.Text;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Administrators WHERE Email = @Email";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Nalog je uspješno obrisan.", "Obavještenje");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ne postoji nalog sa unijetim emailom!", "Obavještenje");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Unesite ispravan email!", "Obavještenje");
            }
        }

        private bool validateEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
                return false;
            else
                return true;

        }
    }
}
