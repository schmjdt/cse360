using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamijo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.ChartComboBox.SelectedIndex = 0;
            this.StatTypeComboBox.SelectedIndex = 0;

            // Load list of users
            if (File.Exists("./users.txt"))
            {
                string Line;
                StreamReader Reader = new StreamReader("./users.txt");
                while ((Line = Reader.ReadLine()) != null)
                {
                    UserComboBox.Items.Add(Line);
                }
                Reader.Close();
            }
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            string username = AddUserTextBox.Text.ToString();
            if (username.Trim().Length != 0 && !UserComboBox.Items.Contains(username))
            {
                UserComboBox.Items.Add(username);
                AddUserTextBox.Text = "";
                Directory.CreateDirectory("./" + username + "/");
            }
            UserComboBox.SelectedIndex = UserComboBox.Items.IndexOf(username);
        }

        private void AddUserTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Return))
            {
                AddUserButton_Click(sender, e);
            }
        }

        private void StatTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Activities"))
            {
                TypeColumn.Items.Clear();
                TypeColumn.Items.AddRange(new object[] {
                    "Leisure",
                    "Exercise",
                    "Sleep",
                    "Eating",
                    "Transportation"});
                HoursColumn.HeaderText = "Hours";
            }
            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Health Statistics"))
            {
                TypeColumn.Items.Clear();
                TypeColumn.Items.AddRange(new object[] {
                    "Calories",
                    "Height",
                    "Weight",
                    "Blood Pressure",
                    "Heart Rate"});
                HoursColumn.HeaderText = "Units";
            }
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // TO-DO
        }

        private void ChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ChartComboBox.SelectedText == "Daily")
            {
                // TO-DO
            }
            if (ChartComboBox.SelectedText == "Weekly")
            {
                // TO-DO
            }
            if (ChartComboBox.SelectedText == "Monthly")
            {
                // TO-DO
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save list of users
            StreamWriter Writer = new StreamWriter("./users.txt");
            for (int count = 0; count < UserComboBox.Items.Count; count++)
            {
                Writer.WriteLine(UserComboBox.Items[count].ToString());
            }
            Writer.Close();
        }

    }
}
