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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (validateEmail(emailTextBox.Text) && validatePassword(passwordTextBox.Text) && validateNameSurname(nameTextBox.Text) && validateNameSurname(surnameTextBox.Text) && roleBox.SelectedIndex != -1)
            {
                string connectionString = "Data Source=SNP-DB.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string email = emailTextBox.Text;

                    string checkUserQuery = "SELECT COUNT(*) FROM Administrators WHERE Email = @Email";
                    using (SQLiteCommand checkUserCommand = new SQLiteCommand(checkUserQuery, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@Email", email);
                        int userCount = Convert.ToInt32(checkUserCommand.ExecuteScalar());

                        if (userCount == 0)
                        {
                            string insertUserQuery = "INSERT INTO Administrators (email, password, ime, prezime, uloga) VALUES (@Email, @Password, @Name, @Surname, @Role)";
                            using (SQLiteCommand insertUserCommand = new SQLiteCommand(insertUserQuery, connection))
                            {
                                insertUserCommand.Parameters.AddWithValue("@Email", email);
                                insertUserCommand.Parameters.AddWithValue("@Password", passwordTextBox.Text);
                                insertUserCommand.Parameters.AddWithValue("@Name", nameTextBox.Text);
                                insertUserCommand.Parameters.AddWithValue("@Surname", surnameTextBox.Text);
                                insertUserCommand.Parameters.AddWithValue("@Role", roleBox.SelectedItem.ToString());

                                insertUserCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Nalog uspješno kreiran!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nalog sa ovim emailom već postoji u bazi podataka!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Unijeti podaci nisu validni!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool validatePassword(string? password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, pattern))
                return false;
            else
                return true;
        }

        private bool validateNameSurname(string? input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            string pattern = @"^[A-Z][a-zA-Z]*$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            emailTextBox.Focus();
        }
    }
}
