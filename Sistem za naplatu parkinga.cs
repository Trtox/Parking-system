using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;

namespace Sistem_za_naplatu_parkinga
{


    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            CenterItems();
            this.Resize += new EventHandler(MainWindow_Resize);

        }

        private void CenterItems()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int buttonWidth = controlParkingButton.Width;
            int buttonHeight = controlParkingButton.Height;

            int xPosition = (formWidth - (2 * buttonWidth)) / 3;
            int yPosition = (formHeight - buttonHeight) / 2;

            controlParkingButton.Location = new Point(xPosition, yPosition);
            useParkingButton.Location = new Point(xPosition + buttonWidth + xPosition, yPosition);

            int labelXPosition = formWidth - label1.Width - 10;
            int labelYPosition = formHeight - label1.Height - 10;
            label1.Location = new Point(labelXPosition, labelYPosition);

         
            int welcomeLabelXPosition = (formWidth - welcomeLabel.Width) / 2;
            int welcomeLabelYPosition = 80;
            welcomeLabel.Location = new Point(welcomeLabelXPosition, welcomeLabelYPosition);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            CenterItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParkingEntry userWindow = new ParkingEntry();
            userWindow.Show();
            this.Hide();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
