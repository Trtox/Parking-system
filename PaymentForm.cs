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
    public partial class PaymentForm : Form
    {
        MainStation? owner;
        string? numberPlate, ticketID;
        double amount;
        bool method;
        bool cnValid = false, edValid = false, cvvValid = false;
        public PaymentForm(MainStation? owner, string? numberPlate, string? ticketID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.owner = owner;
            this.numberPlate = numberPlate;
            this.ticketID = ticketID;
            amount = calculateAmount();
            paymentAmountLabel.Text = amount.ToString("0.00") + " BAM";

            cashAmountLabel.Visible = false;
            cashAmountBox.Visible = false;

            paymentButton.Visible = false;

            cardNumberLabel.Visible = false;
            cardNumberBox.Visible = false;
            expiryDateLabel.Visible = false;
            expiryDateBox.Visible = false;
            cvvLabel.Visible = false;
            cvvBox.Visible = false;

        }

        private double calculateAmount()
        {

            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            DateTime entryTime;
            double hourPrice = 0, dayPrice = 0, specialPrice = 0;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query1 = "SELECT datum_ulaska FROM 'Parking trenutno' WHERE tablice = @numberPlate";
                using (var command = new SQLiteCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@numberPlate", numberPlate);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entryTime = reader.GetDateTime(0);
                        }
                        else
                        {
                            entryTime = DateTime.Now;
                           MessageBox.Show("Već ste platili parking!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            owner.Show();
                          //  throw new Exception("Korisnik sa ovim tablicama nije na parkingu.");
                        }
                    }
                }


                string query2 = "SELECT sat, dnevna FROM 'Cjenovnik' WHERE validan = 1";
                using (var command = new SQLiteCommand(query2, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hourPrice = reader.GetDouble(0);
                            dayPrice = reader.GetDouble(1);                      
                        }
                        else
                        {
                            throw new Exception("Cijene nisu pronadjene u bazi podataka!");
                        }
                    }
                }
            }


            DateTime currentTime = DateTime.Now;
            TimeSpan parkedDuration = currentTime - entryTime;
            double totalAmount = 0;

            if (daySpecial(DateTime.Now))
                totalAmount = 0.00;
            else if (parkedDuration.TotalMinutes < 60)
                totalAmount = hourPrice;
            else if (parkedDuration.TotalHours < 24)
                totalAmount = parkedDuration.TotalHours * hourPrice;
            else
            {
                int fullDays = (int)parkedDuration.TotalDays;
                double remainingHours = parkedDuration.TotalHours - (fullDays * 24);

                totalAmount = (fullDays * dayPrice) + (remainingHours * hourPrice);
            }

            return totalAmount;

        }

        private bool daySpecial(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM 'Specijalni dani' WHERE dan = @day AND mjesec = @month";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@day", date.Day);
                    command.Parameters.AddWithValue("@month", date.Month);

                    long count = (long)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void cashButton_Click(object sender, EventArgs e)
        {
            cashAmountLabel.Visible = true;
            cashAmountBox.Visible = true;
            paymentButton.Visible = true;

            cardNumberLabel.Visible = false;
            cardNumberBox.Visible = false;
            expiryDateLabel.Visible = false;
            expiryDateBox.Visible = false;
            cvvLabel.Visible = false;
            cvvBox.Visible = false;

            method = false;

        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (owner != null && !owner.IsDisposed)
            {
                owner.Show();
            }
        }

        private void cardButton_Click(object sender, EventArgs e)
        {
            cardNumberLabel.Visible = true;
            cardNumberBox.Visible = true;
            expiryDateLabel.Visible = true;
            expiryDateBox.Visible = true;
            cvvLabel.Visible = true;
            cvvBox.Visible = true;
            paymentButton.Visible = true;

            cashAmountLabel.Visible = false;
            cashAmountBox.Visible = false;

            method = true;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            if (method == false)
            {
                if (double.TryParse(cashAmountBox.Text, out double cashAmount) && cashAmount >= amount)
                {
                    string connectionString = "Data Source=SNP-DB.db;Version=3;";
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO 'Racuni' (tiket, iznos, datum, placen, metod) VALUES (@ticketID, @amount, @date, 1, 0)";
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@date", DateTime.Now);
                            command.Parameters.AddWithValue("@amount", amount);
                            command.Parameters.AddWithValue("@numberPlate", numberPlate);
                            command.Parameters.AddWithValue("@ticketID", ticketID);

                            command.ExecuteNonQuery();
                        }

                        DateTime entryTime;
                        string queryz = "SELECT datum_ulaska FROM 'Parking trenutno' WHERE tablice = @numberPlate";
                        using (var command = new SQLiteCommand(queryz, connection))
                        {
                            command.Parameters.AddWithValue("@numberPlate", numberPlate);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    entryTime = reader.GetDateTime(0);
                                }
                                else
                                {
                                    throw new Exception("Korisnik sa ovim tablicama nije na parkingu.");
                                }
                            }
                        }

                        string query1 = "INSERT INTO 'Parking istorija' (tablice, vrijeme_ulaska, vrijeme_izlaska, pretplata, tiket) VALUES (@numberPlate, @entryTime, @exitTime, 0, @ticketID)";
                        using (var command = new SQLiteCommand(query1, connection))
                        {
                            command.Parameters.AddWithValue("@numberPlate", numberPlate);
                            command.Parameters.AddWithValue("@entryTime", entryTime);
                            command.Parameters.AddWithValue("@exitTime", DateTime.Now);
                            command.Parameters.AddWithValue("@ticketID", ticketID);

                            command.ExecuteNonQuery();
                        }

                        string query2 = "DELETE FROM 'Parking trenutno' WHERE tablice = @numberPlate";
                        using (var command = new SQLiteCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@numberPlate", numberPlate);
                            command.ExecuteNonQuery();
                        }
                    }
                     if(double.Parse(cashAmountBox.Text) > amount)
                        MessageBox.Show("Vaš kusur iznosi: " + (double.Parse(cashAmountBox.Text) - amount).ToString("0.00") + " BAM", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    paymentSuccessful();
                }
                else
                {
                    MessageBox.Show("Iznos gotovine nije dovoljan za plaćanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(cnValid && edValid && cvvValid)
            {
                string connectionString = "Data Source=SNP-DB.db;Version=3;";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO 'Racuni' (tiket, iznos, datum, placen, metod) VALUES (@ticketID, @amount, @date, 1, 1)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@numberPlate", numberPlate);
                        command.Parameters.AddWithValue("@ticketID", ticketID);

                        command.ExecuteNonQuery();
                    }

                    DateTime entryTime;
                    string queryz = "SELECT datum_ulaska FROM 'Parking trenutno' WHERE tablice = @numberPlate";
                    using (var command = new SQLiteCommand(queryz, connection))
                    {
                        command.Parameters.AddWithValue("@numberPlate", numberPlate);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                entryTime = reader.GetDateTime(0);
                            }
                            else
                            {
                                throw new Exception("Korisnik sa ovim tablicama nije na parkingu.");
                            }
                        }
                    }

                    string query1 = "INSERT INTO 'Parking istorija' (tablice, vrijeme_ulaska, vrijeme_izlaska, pretplata, tiket) VALUES (@numberPlate, @entryTime, @exitTime, 0, @ticketID)";
                    using (var command = new SQLiteCommand(query1, connection))
                    {
                        command.Parameters.AddWithValue("@numberPlate", numberPlate);
                        command.Parameters.AddWithValue("@entryTime", entryTime);
                        command.Parameters.AddWithValue("@exitTime", DateTime.Now);
                        command.Parameters.AddWithValue("@ticketID", ticketID);

                        command.ExecuteNonQuery();
                    }

                    string query2 = "DELETE FROM 'Parking trenutno' WHERE tablice = @numberPlate";
                    using (var command = new SQLiteCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@numberPlate", numberPlate);
                        command.ExecuteNonQuery();
                    }
                }
                paymentSuccessful();
            }
            
        }

        private void paymentSuccessful()
        {   
            if (!this.IsDisposed)
            {
                generateBill();
                MessageBox.Show("Plaćanje uspješno izvršeno. Imate rok od 15 sekundi da napustite parking.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                owner.Show();
                this.Close();
            }
        }

        private void generateBill()
        {
            string fileName = "tiket " + numberPlate + ".jpg";
            Bitmap bitmap = new Bitmap(fileName);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen blackPen = new Pen(Color.Black, 3);
                int textY = bitmap.Height / 2 - 10;
                int lineY = textY + 70;
                g.DrawLine(blackPen, 0, lineY, bitmap.Width, lineY);

                string paymentInfo = $"Plaćeno: {amount.ToString("0.00")} BAM\nDatum: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
                Font font = new Font("Arial", 12);
                Brush brush = new SolidBrush(Color.Black);
                SizeF textSize = g.MeasureString(paymentInfo, font);
                PointF textPosition = new PointF((bitmap.Width - textSize.Width) / 2, textY);
                g.DrawString(paymentInfo, font, brush, textPosition);

                string thankYouText = "Hvala što koristite naš parking!";
                SizeF thankYouTextSize = g.MeasureString(thankYouText, font);
                PointF thankYouTextPosition = new PointF((bitmap.Width - thankYouTextSize.Width) / 2, lineY + 10);
                g.DrawString(thankYouText, font, brush, thankYouTextPosition);
            }

            string billFileName = "racun_" + numberPlate + ".jpg";
            bitmap.Save(billFileName);
            bitmap.Dispose();
        
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = billFileName,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        private void cardNumberBox_Validating(object sender, CancelEventArgs e)
        {
            string cardNumber = cardNumberBox.Text;
            string pattern = @"^\d{4}-\d{4}-\d{4}-\d{4}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, pattern))
            {
                e.Cancel = true;
                cardNumberBox.Focus();
                errorProvider1.SetError(cardNumberBox, "Broj kartice mora biti unesen u formatu XXXX-XXXX-XXXX-XXXX i sadržati 16 cifara.");
                cnValid = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cardNumberBox, "");
                cnValid = true;
            }
        }

        private void expiryDateBox_Validating(object sender, CancelEventArgs e)
        {
            string expiryDate = expiryDateBox.Text;
            string pattern = @"^(0[1-9]|1[0-2])\/\d{2}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(expiryDate, pattern))
            {
                e.Cancel = true;
                expiryDateBox.Focus();
                errorProvider1.SetError(expiryDateBox, "Datum isteka mora biti u formatu MM/YY.");
                edValid = false;
            }
            else
            {
                string[] parts = expiryDate.Split('/');
                int month = int.Parse(parts[0]);
                int year = int.Parse(parts[1]) + 2000;

                DateTime expiry = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
                if (expiry < DateTime.Now)
                {
                    e.Cancel = true;
                    expiryDateBox.Focus();
                    errorProvider1.SetError(expiryDateBox, "Datum isteka ne može biti u prošlosti.");
                    edValid = false;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(expiryDateBox, "");
                    edValid = true;
                }
            }
        }

        private void cvvBox_Validating(object sender, CancelEventArgs e)
        {
            string cvv = cvvBox.Text;
            string pattern = @"^\d{3,4}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(cvv, pattern))
            {
                e.Cancel = true;
                cvvBox.Focus();
                errorProvider1.SetError(cvvBox, "CVV/CVC2 broj mora sadržati 3 ili 4 cifre.");
                cvvValid = false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cvvBox, "");
                cvvValid = true;
            }
        }
    }
}
