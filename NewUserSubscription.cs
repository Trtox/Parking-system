using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_za_naplatu_parkinga
{
    public partial class NewUserSubscription : Form
    {
        MainStation? owner;
        string? numberPlate;
        public NewUserSubscription(MainStation? owner, string? numberPlate)
        {
            InitializeComponent();
            CenterItems();
            this.owner = owner;
            this.numberPlate = numberPlate;
        }

        private void CenterItems()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int spacing = 40;
            int startY = 80;

            emailLabel.Location = new Point((formWidth - emailLabel.Width) / 2, startY);
            emailBox.Location = new Point((formWidth - emailBox.Width) / 2, startY + spacing);
            nameLabel.Location = new Point((formWidth - nameLabel.Width) / 2, startY + 2 * spacing);
            nameBox.Location = new Point((formWidth - nameBox.Width) / 2, startY + 3 * spacing);
            surnameLabel.Location = new Point((formWidth - surnameLabel.Width) / 2, startY + 4 * spacing);
            surnameBox.Location = new Point((formWidth - surnameBox.Width) / 2, startY + 5 * spacing);
            registerButton.Location = new Point((formWidth - registerButton.Width) / 2, startY + 6 * spacing);
        }

        private bool validateTextBoxes()
        {
            bool isValid = true;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string namePattern = @"^[A-Z][a-zA-Z]*$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(emailBox.Text, emailPattern))
            {
                isValid = false;
                MessageBox.Show("Nevažeći format emaila!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nameBox.Text, namePattern))
            {
                isValid = false;
                MessageBox.Show("Ime mora početi sa velikim slovom i sadržati isključivo slova!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(surnameBox.Text, namePattern))
            {
                isValid = false;
                MessageBox.Show("Prezime mora početi sa velikim slovom i sadržati isključivo slova!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (validateTextBoxes())
            {
                string name = nameBox.Text;
                string surname = surnameBox.Text;
                string email = emailBox.Text;
                SubscriptionPayment subscriptionPayment = new SubscriptionPayment(owner, true, email, name, surname, numberPlate);
                subscriptionPayment.Show();
                this.Close();

            }
        }

        private void NewUserSubscription_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
