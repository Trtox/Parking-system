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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            CenterItems();
        }

        private void CenterItems()
        {
            
            emailTextBox.Left = (this.ClientSize.Width - emailTextBox.Width) / 2;
            reasonTextBox.Left = (this.ClientSize.Width - reasonTextBox.Width) / 2;
            reasonTextBox.Top = emailTextBox.Bottom + 20;

            emailLabel.Left = emailTextBox.Left - emailLabel.Width - 10;
            emailLabel.Top = emailTextBox.Top + (emailTextBox.Height - emailLabel.Height) / 2;
            reasonLabel.Left = reasonTextBox.Left - reasonLabel.Width - 10;
            reasonLabel.Top = reasonTextBox.Top + (reasonTextBox.Height - reasonLabel.Height) / 2;

            submitButton.Top = reasonTextBox.Bottom + 70;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string reason = reasonTextBox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(reason))
            {
                MessageBox.Show("Molimo popunite sva polja.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection("Data Source=SNP-DB.db;Version=3;"))
                    {
                        conn.Open();
                        string query = "INSERT INTO Zalbe (tekst, email_korisnika, status) VALUES (@tekst, @Email, 'aktivna')";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@tekst", reason);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Žalba uspješno podnesena.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom podnošenja žalbe: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(emailTextBox.Text, emailPattern))
            {
                emailTextBox.Select(0, emailTextBox.Text.Length);
                errorProvider1.SetError(emailTextBox, "Neispravan format email-a.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(emailTextBox, null);
            }
        }
    }
}
