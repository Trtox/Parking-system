using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Sistem_za_naplatu_parkinga
{
    public partial class ParkingEntry : Form
    {
        public ParkingEntry()
        {
            InitializeComponent();
            label1.Visible = false;
            CenterItems();
            enterParkingButton.Visible = false;
        }

        string? numberPlate = null;
        string? ticketID = null;


        private void numPlateButton_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string? result = null;
                string filePath = openFileDialog1.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "tablice.exe",
                    Arguments = filePath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                try
                {
                    using (Process process = Process.Start(startInfo))
                    {
                        label1.Visible = true;
                        process.WaitForExit();
                        label1.Visible = false;
                        using (StreamReader reader = process.StandardOutput)
                        {
                            result = reader.ReadLine();
                        }
                    }
                    numberPlate = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Desila se greška: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Molim učitajte sliku ponovo!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    string? imagePath = @"template.jpg";
                    Font fontZaTablice = new Font("FE-Font", 80);
                    Color bojaTeksta = Color.Black;

                    try
                    {
                        using (Bitmap bitmap = (Bitmap)Image.FromFile(imagePath))
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                int imageWidth = bitmap.Width;
                                int imageHeight = bitmap.Height;
                                Point imageCenter = new Point(imageWidth / 2, imageHeight / 2);

                                SizeF textSize = graphics.MeasureString(result, fontZaTablice);
                                Point textLocation = new Point(imageCenter.X - (int)(textSize.Width / 2) + 30, imageCenter.Y - (int)(textSize.Height / 2));

                                graphics.DrawString(result, fontZaTablice, new SolidBrush(bojaTeksta), textLocation);
                            }

                            string? savePath = @result + ".jpg";
                            bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            pictureBox1.ImageLocation = savePath;
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox1.Show();

                            enterParkingButton.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Desila se greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool checkSubscription(string? numberPlate)
        {
            if (numberPlate == null)
                return false;
            string connectionString = "Data Source=SNP-DB.db;Version=3;";
            string query = "SELECT datum_vazenja FROM [Pretplaceni korisnici] WHERE tablice = @numberPlate";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@numberPlate", numberPlate);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime expiryDate = reader.GetDateTime(0);
                                if (expiryDate > DateTime.Now)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Desila se greška prilikom provjere pretplate: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void UserWindow_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }

        private void CenterItems()
        {

            numPlateButton.Top = 40;
            numPlateButton.Left = (this.ClientSize.Width - numPlateButton.Width) / 2;

            label1.Top = numPlateButton.Top + 40;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;

            enterParkingButton.Top = pictureBox1.Top + pictureBox1.Height + 50;
            enterParkingButton.Left = (this.ClientSize.Width - enterParkingButton.Width) / 2;
        }

        private void enterParkingButton_Click(object sender, EventArgs e)
        {
            if (!checkSubscription(numberPlate))
            {
                string ticketPath = @"tiket " + numberPlate + ".jpg";
                Font fontZaTablice = new Font("Arial", 20);
                Font fontZaDatum = new Font("Arial", 12);
                Color bojaTeksta = Color.Black;

                try
                {
                    using (Bitmap bitmap = new Bitmap(300, 600))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.Clear(Color.White);

                            string labelText = "Registarska oznaka vozila:";
                            SizeF labelSize = graphics.MeasureString(labelText, fontZaDatum);
                            Point labelLocation = new Point((bitmap.Width - (int)labelSize.Width) / 2, 30);
                            graphics.DrawString(labelText, fontZaDatum, new SolidBrush(bojaTeksta), labelLocation);

                            string numberPlate = pictureBox1.ImageLocation.Split('\\').Last().Replace(".jpg", "");
                            SizeF textSize = graphics.MeasureString(numberPlate, fontZaTablice);
                            Point textLocation = new Point((bitmap.Width - (int)textSize.Width) / 2, 60);
                            graphics.DrawString(numberPlate, fontZaTablice, new SolidBrush(bojaTeksta), textLocation);

                            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                            string currentTime = DateTime.Now.ToString("HH:mm");
                            string dateLabel = "Datum: " + currentDate;
                            string timeLabel = "Vrijeme: " + currentTime;

                            SizeF dateSize = graphics.MeasureString(dateLabel, fontZaDatum);
                            SizeF timeSize = graphics.MeasureString(timeLabel, fontZaDatum);

                            Point dateLocation = new Point((bitmap.Width - (int)dateSize.Width) / 2, 110);
                            Point timeLocation = new Point((bitmap.Width - (int)timeSize.Width) / 2, 130);

                            graphics.DrawString(dateLabel, fontZaDatum, new SolidBrush(bojaTeksta), dateLocation);
                            graphics.DrawString(timeLabel, fontZaDatum, new SolidBrush(bojaTeksta), timeLocation);

                            ticketID = Guid.NewGuid().ToString().Substring(0, 8);
                            string ticketIdLabel = "ID Tiketa: " + ticketID;
                            SizeF ticketIdSize = graphics.MeasureString(ticketIdLabel, fontZaDatum);
                            Point ticketIdLocation = new Point((bitmap.Width - (int)ticketIdSize.Width) / 2, 150);

                            graphics.DrawString(ticketIdLabel, fontZaDatum, new SolidBrush(bojaTeksta), ticketIdLocation);

                            string qrContent = $"{numberPlate}\n {currentDate} {currentTime}";
                            using (var qrGenerator = new QRCoder.QRCodeGenerator())
                            {
                                var qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCoder.QRCodeGenerator.ECCLevel.Q);
                                using (var qrCode = new QRCoder.QRCode(qrCodeData))
                                {
                                    using (var qrBitmap = qrCode.GetGraphic(20))
                                    {
                                        Bitmap resizedQrBitmap = new Bitmap(qrBitmap, new Size(200, 200));
                                        Point qrLocation = new Point((bitmap.Width - resizedQrBitmap.Width) / 2, bitmap.Height - resizedQrBitmap.Height - 25);
                                        graphics.DrawImage(resizedQrBitmap, qrLocation);
                                    }
                                }
                            }
                        }

                        bitmap.Save(ticketPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Tiket je uspješno generisan!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        Process.Start(new ProcessStartInfo(ticketPath) { UseShellExecute = true });

                        string connectionString = "Data Source=SNP-DB.db;Version=3;";
                        string insertQuery = "INSERT INTO [Parking trenutno] (tablice, datum_ulaska, tiket, racun, racun_placen) VALUES (@numberPlate, @datumUlaska, @tiket, @racun, @racunPlaceno)";

                        try
                        {
                            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                            {
                                connection.Open();
                                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@numberPlate", numberPlate);
                                    command.Parameters.AddWithValue("@datumUlaska", DateTime.Now);
                                    command.Parameters.AddWithValue("@tiket", ticketID);
                                    command.Parameters.AddWithValue("@racun", "0");
                                    command.Parameters.AddWithValue("@racunPlaceno", 0);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Desila se greška prilikom unosa u bazu: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ParkingFunctionality();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Desila se greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Direktan prolaz!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string connectionString = "Data Source=SNP-DB.db;Version=3;";
                string insertQuery = "INSERT INTO [Parking trenutno] (tablice, datum_ulaska, tiket, racun, racun_placen) VALUES (@numberPlate, @datumUlaska, @tiket, @racun, @racunPlaceno)";

                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@numberPlate", numberPlate);
                            command.Parameters.AddWithValue("@datumUlaska", DateTime.Now);
                            command.Parameters.AddWithValue("@tiket", "pretplata");
                            command.Parameters.AddWithValue("@racun", "pretplata");
                            command.Parameters.AddWithValue("@racunPlaceno", 1);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Desila se greška prilikom unosa u bazu: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ParkingFunctionality();
            }
        }

        private void ParkingFunctionality()
        {
            UserWindow userWindow = new UserWindow(numberPlate, ticketID,DateTime.Now);
            userWindow.Show();
            this.Hide();
        }
        private void UserWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
