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
using QRCoder;

namespace Sistem_za_naplatu_parkinga
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
            CenterItems();
            this.KeyPreview = true;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
        }

        public bool valid1 = false, valid2 = false;

        private void AdminWindow_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }

        private void CenterItems()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int textBoxWidth = textBox1.Width;
            int textBoxHeight = textBox1.Height;

            int xPosition = (formWidth - textBoxWidth) / 2;
            int yPosition = (formHeight - textBoxHeight) / 2;

            textBox1.Location = new Point(xPosition, yPosition);
            textBox2.Location = new Point(xPosition, yPosition + textBoxHeight + 10);

            label1.Location = new Point(xPosition - 70, yPosition);
            label2.Location = new Point(xPosition - 70, yPosition + textBoxHeight + 10);

            loginButton.Location = new Point(xPosition + textBoxWidth / 3, yPosition + 2 * (textBoxHeight + 10) + 100);
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (valid1 && valid2)
                systemLogin();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword();
        }

        private void ValidateEmail()
        {
            string email = textBox1.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                errorProvider1.SetError(textBox1, "Nevazeci oblik emaila.");
                valid1 = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                valid1 = true;
            }

            updateLoginButtonState();
        }

        private void ValidatePassword()
        {
            string password = textBox2.Text;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, pattern))
            {
                errorProvider1.SetError(textBox2, "Lozinka mora imati najmanje 8 znakova, sadržati veliko slovo, malo slovo i broj.");
                valid2 = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                valid2 = true;
            }

            updateLoginButtonState();
        }

        private void updateLoginButtonState()
        {
            loginButton.Enabled = valid1 && valid2;
        }

        private void AdminWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (valid1 && valid2)
                    systemLogin();
            }
        }

        private void systemLogin()
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string email = textBox1.Text;
            string password = textBox2.Text;

            string query = "SELECT * FROM Administrators WHERE email = @Email AND password = @Password";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                string? uloga = reader["uloga"].ToString();

                                if (uloga == "administrator")
                                {
                                    AdminFunctionality(email, password, reader["ime"].ToString(), reader["prezime"].ToString());
                                }
                                else if (uloga == "operater")
                                {
                                    OperaterFunctionality(email, password, reader["ime"].ToString(), reader["prezime"].ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Greška u bazi podataka: Nalog nema definisanu ulogu.\nPristup odbijen!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("U bazi podataka ne postoji nalog sa datim podacima.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desila se greska: " + ex.Message);
            }
        }

        private void AdminFunctionality(string email, string password, string ime, string prezime)
        {
            AdminFunction adminFunction = new AdminFunction(this, email, password, ime, prezime); 
            adminFunction.Show();
            this.Hide();
        }

        private void OperaterFunctionality(string email, string password, string ime, string prezime)
        {
            OperaterFunction operaterFunction = new OperaterFunction(this, email, password, ime, prezime); 
            operaterFunction.Show();
            this.Hide();
        }

        private void AdminWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
