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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.ComponentModel.DataAnnotations;

namespace Sistem_za_naplatu_parkinga
{
    public partial class ChangePassword : Form
    {
        private string? email;
        private bool valid;
        public ChangePassword(string? aemail)
        {
            InitializeComponent();
            email = aemail;
            this.KeyPreview = true;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox2.KeyDown += textBox2_KeyDown;
            textBox3.KeyDown += textBox3_KeyDown;
            valid = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword1(textBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword1(textBox1);
        }

        private void ValidatePassword1(TextBox tb)
        {
            string password = tb.Text;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, pattern))
            {
                errorProvider1.SetError(tb, "Lozinka mora imati najmanje 8 znakova, sadržati veliko slovo, malo slovo i broj.");
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(tb, "");

            }

        }

        private bool ValidatePassword(TextBox tb)
        {
            string password = tb.Text;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, pattern))
            {
                errorProvider1.SetError(tb, "Lozinka mora imati najmanje 8 znakova, sadržati veliko slovo, malo slovo i broj.");
                return false;
            }
            else
            {
                errorProvider1.SetError(tb, "");
                return true;

            }

        }

        bool isPasswordCorrect(string? pw)
        {
            if (string.IsNullOrEmpty(pw))
            {
                return false;
            }

            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT * FROM Administrators WHERE Email = @Email AND Password = @Password";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", pw);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            return true;
                        else
                            return false;
                    }
                }
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidatePassword(textBox1);
                if (string.IsNullOrEmpty(errorProvider1.GetError(textBox1)))
                {
                    if (isPasswordCorrect(textBox1.Text))
                    {
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox2.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "Pogrešna lozinka");
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                    }
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text == textBox3.Text && ValidatePassword(textBox2) && ValidatePassword(textBox3))
                {
                    UpdatePassword(email, textBox3.Text);
                    MessageBox.Show("Lozinka je uspješno promijenjena!", "Obavještenje");
                }
                else
                {
                    MessageBox.Show("Lozinke se ne podudaraju ili su nevalidne!", "Obavještenje");
                }
            }
        }

        private void UpdatePassword(string? email, string newPassword)
        {
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "UPDATE Administrators SET Password = @Password WHERE Email = @Email";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword(textBox2);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword(textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidatePassword(textBox3);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword(textBox3);
        }
    }
}
