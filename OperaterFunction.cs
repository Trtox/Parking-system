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
    public partial class OperaterFunction : Form
    {
        private string? email;
        private string? password;
        private string? ime;
        private string? prezime;
        AdminWindow? adminWindow;

        public OperaterFunction(AdminWindow novi, string? a_email, string? a_password, string? a_ime, string? a_prezime)
        {
            adminWindow = novi;
            email = a_email;
            password = a_password;
            ime = a_ime;
            prezime = a_prezime;
            InitializeComponent();
            label1.Text = "Dobrodošli, " + ime + " " + prezime + "!";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=SNP-DB.db";
            string query = "SELECT * FROM [Parking istorija]";
            dataGridView1.Show();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                   
                    int totalHeight = dataTable.Rows.Count * dataGridView1.RowTemplate.Height;
                    int totalWidth = dataTable.Columns.Count * dataGridView1.Columns[0].Width;
                    dataGridView1.Size = new Size(totalWidth, totalHeight);

                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=SNP-DB.db";
            string query = "SELECT * FROM Zalbe";
            dataGridView1.Show();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Refresh();

                    Form idForm = new Form();
                    idForm.Text = "Žalbe";
                    idForm.Size = new Size(300, 200);

                    ComboBox idComboBox = new ComboBox();
                    idComboBox.Location = new Point(10, 10);
                    idComboBox.Width = 250;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        idComboBox.Items.Add(row["ID"].ToString());
                    }

                    idComboBox.SelectedIndexChanged += (s, args) =>
                    {
                        idForm.Close();
                        string selectedId = idComboBox.SelectedItem.ToString();
                        Form responseForm = new Form();
                        responseForm.Text = "Unesi odgovor";
                        responseForm.Size = new Size(800, 600);

                        Label responseLabel = new Label();
                        responseLabel.Height = 300;
                        responseLabel.Width = 500;
                        responseLabel.Text = "Odgovor:";
                        responseLabel.Location = new Point(10, 20);
                        responseLabel.AutoSize = true;

                        TextBox responseTextBox = new TextBox();
                        responseTextBox.Location = new Point(80, 20);
                        responseTextBox.Width = 200;
                        responseTextBox.Height = 100;
                        responseTextBox.Multiline = true;

                        Button submitButton = new Button();
                        submitButton.Width = 100;
                        submitButton.Height = 80;
                        submitButton.Text = "Pošalji";
                        submitButton.Location = new Point(300, 300);
                        submitButton.Click += (submitSender, submitArgs) =>
                        {
                            string responseText = responseTextBox.Text;
                            string updateQuery = "UPDATE Zalbe SET Odgovor = @Odgovor, status = 'Rijesena' WHERE ID = @ID";

                            using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Odgovor", responseText);
                                updateCommand.Parameters.AddWithValue("@ID", selectedId);
                                updateCommand.ExecuteNonQuery();
                            }

                            responseForm.Close();
                           // dataGridView1.Hide();
                        };

                        responseForm.Controls.Add(responseLabel);
                        responseForm.Controls.Add(responseTextBox);
                        responseForm.Controls.Add(submitButton);
                        responseForm.ShowDialog();
                        dataAdapter.Fill(dataTable);

                        DataTable dataTable1 = new DataTable();
                        dataAdapter.Fill(dataTable1);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dataTable1;
                        dataGridView1.Refresh();

                       
                    };

                    idForm.Controls.Add(idComboBox);
                    idForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void CenterItems()
        {
            int formWidth = this.Width;
            int formHeight = this.Height;

            int buttonWidth = 150;
            int buttonHeight = 100;

            int xPosition = (formWidth - (5 * buttonWidth)) / 6;
            int yPosition = (formHeight - buttonHeight) / 2;

            button1.Size = new Size(buttonWidth, buttonHeight);
            button2.Size = new Size(buttonWidth, buttonHeight);
            button3.Size = new Size(buttonWidth, buttonHeight);
            button4.Size = new Size(buttonWidth, buttonHeight);

            button1.Location = new Point(xPosition, yPosition);
            button2.Location = new Point(xPosition + buttonWidth + xPosition, yPosition);
            button3.Location = new Point(xPosition + 2 * (buttonWidth + xPosition), yPosition);
            button4.Location = new Point(xPosition + 3 * (buttonWidth + xPosition), yPosition);
            button5.Size = new Size(buttonWidth, buttonHeight);
             button5.Location = new Point(xPosition + 4 * (buttonWidth + xPosition), yPosition);

            int labelXPosition = (formWidth - label1.Width) / 2;
            int labelYPosition = 10;
            label1.Location = new Point(labelXPosition, labelYPosition);

            dataGridView1.Location = new Point(xPosition, yPosition + buttonHeight+20 );
            dataGridView1.Size = new Size(formWidth - 2 * xPosition, formHeight - (yPosition + 2 * buttonHeight + 30));
        }




        private void button6_Click(object sender, EventArgs e)
        {
          
            Form plateForm = new Form();
            plateForm.Text = "Unesi tablicu vozila";
            plateForm.Size = new Size(400, 200);

          
            Label plateLabel = new Label();
            plateLabel.Text = "Tablica vozila:";
            plateLabel.Location = new Point(10, 20);
            plateLabel.AutoSize = true;

            TextBox plateTextBox = new TextBox();
            plateTextBox.Location = new Point(120, 20);
            plateTextBox.Width = 250;

      
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Size = new Size(100, 30);
            okButton.Location = new Point(150, 60);
            okButton.Click += (s, args) =>
            {
                string plateNumber = plateTextBox.Text;
                string connectionString = @"Data Source=SNP-DB.db";
                string query = "SELECT * FROM [Parking trenutno] WHERE tablice = @tablice";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@tablice", plateNumber);
                            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                               
                                Form infoForm = new Form();
                                infoForm.Text = "Informacije o vozilu";
                                infoForm.Size = new Size(400, 300);

                                DataGridView dataGridView = new DataGridView();
                                dataGridView.DataSource = dataTable;
                                dataGridView.Dock = DockStyle.Fill;
                                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                                infoForm.Controls.Add(dataGridView);
                                infoForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Nema informacija za unetu tablicu vozila.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            };

            // Add controls to the form
            plateForm.Controls.Add(plateLabel);
            plateForm.Controls.Add(plateTextBox);
            plateForm.Controls.Add(okButton);

       
            plateForm.ShowDialog();
        }
        private void OperaterFunction_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            CenterItems();
          
            button1.Size = new Size(200, 100);
            button2.Size = new Size(200, 100);
            button3.Size = new Size(200, 100);
            button4.Size = new Size(200, 100);
            button5.Size = new Size(200, 100);
        
        }

        private void OperaterFunction_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }
        private string GetAdminEmail()
        {
            string connectionString = @"Data Source=SNP-DB.db";
            string query = "SELECT email FROM Administrators LIMIT 1"; // Adjust the query as needed

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            return string.Empty;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string adminEmail = GetAdminEmail();

            Form emailForm = new Form();
            emailForm.Text = "Prijava nepravilnosti";
            emailForm.Size = new Size(400, 400);

            Label emailLabel = new Label();
            emailLabel.Text = "E-mail adresa:";
            emailLabel.Location = new Point(10, 20);
            emailLabel.AutoSize = true;

            TextBox emailTextBox = new TextBox();
            emailTextBox.Location = new Point(120, 20);
            emailTextBox.Width = 250;
            emailTextBox.Text = adminEmail;

            Label messageLabel = new Label();
            messageLabel.Text = "Poruka:";
            messageLabel.Location = new Point(10, 60);
            messageLabel.AutoSize = true;

            TextBox messageTextBox = new TextBox();
            messageTextBox.Location = new Point(120, 60);
            messageTextBox.Width = 250;
            messageTextBox.Height = 200;
            messageTextBox.Multiline = true;
            messageTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Button sendButton = new Button();
            sendButton.Text = "Pošalji";
            sendButton.Size = new Size(150, 70);
            sendButton.Location = new Point(125, 280);
            sendButton.Click += (s, args) =>
            {
                try
                {
                    string email = emailTextBox.Text;
                    string message = messageTextBox.Text;

                    if (!IsValidEmail(email))
                    {
                        MessageBox.Show("Unesite validnu email adresu.");
                        return;
                    }

                    emailForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            };

            emailForm.Controls.Add(emailLabel);
            emailForm.Controls.Add(emailTextBox);
            emailForm.Controls.Add(messageLabel);
            emailForm.Controls.Add(messageTextBox);
            emailForm.Controls.Add(sendButton);

            emailForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form adminWindow = new AdminWindow();
            adminWindow.FormClosed += (s, args) => this.Close();
            adminWindow.Show();
        }
        private void OperaterFunction_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=SNP-DB.db";
            string query = "SELECT * FROM Zalbe";
            dataGridView1.Show();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            groupBox1.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            Form plateForm = new Form();
            plateForm.Text = "Unesi tablicu vozila";
            plateForm.Size = new Size(400, 200);

          
            Label plateLabel = new Label();
            plateLabel.Text = "Tablica vozila:";
            plateLabel.Location = new Point(10, 20);
            plateLabel.AutoSize = true;

            TextBox plateTextBox = new TextBox();
            plateTextBox.Location = new Point(120, 20);
            plateTextBox.Width = 250;

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Size = new Size(100, 30);
            okButton.Location = new Point(150, 60);
            okButton.Click += (s, args) =>
            {
                string plateNumber = plateTextBox.Text;
                string connectionString = @"Data Source=SNP-DB.db";
                string query = "SELECT * FROM [Parking trenutno] WHERE tablice = @tablice";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@tablice", plateNumber);
                            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                
                                Form infoForm = new Form();
                                infoForm.Text = "Informacije o vozilu";
                                infoForm.Size = new Size(400, 300);

                                DataGridView dataGridView = new DataGridView();
                                dataGridView.DataSource = dataTable;
                                dataGridView.Dock = DockStyle.Fill;
                                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                                infoForm.Controls.Add(dataGridView);
                                infoForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Nema informacija za unetu tablicu vozila.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nema informacija za unetu tablicu vozila.");
                    }
                }
            };

            plateForm.Controls.Add(plateLabel);
            plateForm.Controls.Add(plateTextBox);
            plateForm.Controls.Add(okButton);

           
            plateForm.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}
