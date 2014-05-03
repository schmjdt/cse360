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
            this.StatTypeComboBox.Text = "Activities";

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

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear DataGrid for new user
            DataGridView.Rows.Clear();

            // Update DataGridView
            if (UserComboBox.Text == string.Empty)
                return;
            string FileName = "./" + UserComboBox.Text + "/";

            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Activities")) {
                FileName += MonthCalendar.SelectionRange.Start.ToString("dd-MM-yyyy-")
                    + "activities.txt";
            } else {
                FileName += MonthCalendar.SelectionRange.Start.ToString("dd-MM-yyyy-")
                    + "healthstatistics.txt";
            }

            if (File.Exists(FileName)) {
                StreamReader Reader = new StreamReader(FileName);

                string Line;
                int counter = 0;
                while ((Line = Reader.ReadLine()) != null) {
                    if ((Line.Split('|')[0].Contains("NULL")) && (Line.Split('|')[1].Contains("NULL")) && (Line.Split('|')[2].Contains("NULL")))
                        continue;
                    DataGridView.Rows.Add();
                    if (!Line.Split('|')[0].Contains("NULL")) DataGridView.Rows[counter].Cells[0].Value = Line.Split('|')[0];
                    if (!Line.Split('|')[1].Contains("NULL")) DataGridView.Rows[counter].Cells[1].Value = Line.Split('|')[1];
                    if (!Line.Split('|')[2].Contains("NULL")) DataGridView.Rows[counter].Cells[2].Value = Line.Split('|')[2];
                    counter++;
                }

                Reader.Close();
            }

            // Update Chart
            ChartListBox_SelectedIndexChanged(sender, e);
            
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            string username = AddUserTextBox.Text.ToString();
            if (username.Trim().Length != 0)
            {
                if (!UserComboBox.Items.Contains(username))
                    UserComboBox.Items.Add(username);
                if (!Directory.Exists("./" + username + "/"))
                    Directory.CreateDirectory("./" + username + "/");
            }
            AddUserTextBox.Text = string.Empty;
            UserComboBox.SelectedIndex = UserComboBox.Items.IndexOf(username);
        }

        private void AddUserTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                AddUserButton_Click(sender, e);
            }
        }

        private void StatTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView.Rows.Clear();
            TypeColumn.Items.Clear();
            ChartListBox.Items.Clear();

            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Activities"))
            {
                ChartListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
                Chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                TypeColumn.Items.AddRange(new object[] {
                    "Leisure",
                    "Exercise",
                    "Sleep",
                    "Eating",
                    "Transportation"});
                ChartListBox.Items.AddRange(new object[] {
                    "Leisure",
                    "Exercise",
                    "Sleep",
                    "Eating",
                    "Transportation"});
            }
            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Health Statistics"))
            {
                ChartListBox.SelectionMode = System.Windows.Forms.SelectionMode.One;
                Chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                TypeColumn.Items.AddRange(new object[] {
                    "Calories",
                    "Height",
                    "Weight",
                    "Blood Pressure",
                    "Heart Rate"});
                ChartListBox.Items.AddRange(new object[] {
                    "Calories",
                    "Height",
                    "Weight",
                    "Blood Pressure",
                    "Heart Rate"});
            }
            

            // Update DataGridView
            UserComboBox_SelectedIndexChanged(sender, e);
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            UserComboBox_SelectedIndexChanged(sender, e);
        }

        private void ChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChartComboBox.SelectedText == "Daily")
            {
                UserComboBox_SelectedIndexChanged(sender, e);
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

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (UserComboBox.Text == string.Empty)
                return;
            double totalHours = 0;


            string FileName = "./" + UserComboBox.Text + "/";

            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Activities"))
            {

                for (int row = 0; row < DataGridView.Rows.Count - 1; row++)
                {
                    totalHours += Convert.ToDouble(DataGridView.Rows[row].Cells[1].Value);


                    if (Convert.ToDouble(DataGridView.Rows[row].Cells[1].Value) < 0)
                    {
                        DataGridView.Rows[row].Cells[1].Value = 0;
                        MessageBox.Show("Hours below 0 changed to 0");
                    }

                    if (Convert.ToDouble(DataGridView.Rows[row].Cells[1].Value) > 24)
                    {
                        DataGridView.Rows[row].Cells[1].Value = 24;
                        MessageBox.Show("Hours above 24 changed to 24");
                    }

                    if (totalHours > 24)
                    {
                        totalHours -= Convert.ToDouble(DataGridView.Rows[e.RowIndex].Cells[1].Value);
                        DataGridView.Rows[e.RowIndex].Cells[1].Value = 0;
                        MessageBox.Show("Hours are above 24");
                    }
                }
                FileName += MonthCalendar.SelectionRange.Start.ToString("dd-MM-yyyy-")
                    + "activities.txt";
            }
            else
            {

                for (int row = 0; row < DataGridView.Rows.Count - 1; row++)
                {
                    if (Convert.ToDouble(DataGridView.Rows[row].Cells[1].Value) < 0)
                    {
                        DataGridView.Rows[row].Cells[1].Value = 0;
                        MessageBox.Show("Units below 0 changed to 0");
                    }
                }
                FileName += MonthCalendar.SelectionRange.Start.ToString("dd-MM-yyyy-")
                    + "healthstatistics.txt";
            }

            StreamWriter Writer = new StreamWriter(FileName);
            for (int row = 0; row < DataGridView.Rows.Count; row++)
            {
                string Line = string.Empty;

                if ((DataGridView.Rows[row].Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString() != string.Empty)
                {
                    Line += (DataGridView.Rows[row].Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString() + "|";
                }
                else
                {
                    Line += "NULL|";
                }

                if (DataGridView.Rows[row].Cells[1].FormattedValue.ToString() != string.Empty)
                {
                    Line += DataGridView.Rows[row].Cells[1].FormattedValue.ToString() + "|";
                }
                else
                {
                    Line += "NULL|";
                }

                if (DataGridView.Rows[row].Cells[2].FormattedValue.ToString() != string.Empty)
                {
                    Line += DataGridView.Rows[row].Cells[2].FormattedValue.ToString();
                }
                else
                {
                    Line += "NULL";
                }

                Writer.WriteLine(Line);
            }
            Writer.Close();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (UserComboBox.Text == string.Empty)
                return;
            string FileName = "./" + UserComboBox.Text + "/";

            if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Activities"))
            {
                FileName += MonthCalendar.SelectionRange.Start.ToString("dd-MM-yyyy-")
                    + "activities_print.txt";
            }
            else
            {
                FileName += MonthCalendar.SelectionRange.Start.ToString("dd-MM-yyyy-")
                    + "healthstatistics_print.txt";
            }

            StreamWriter Writer = new StreamWriter(FileName);
            for (int row = 0; row < DataGridView.Rows.Count; row++)
            {
                string Line = string.Empty;


                if ((DataGridView.Rows[row].Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString() != string.Empty)
                {
                    Line += "Type: " + (DataGridView.Rows[row].Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString() + " \n";
                }
                else
                {
                    Line += "\n";
                }

                if (DataGridView.Rows[row].Cells[1].FormattedValue.ToString() != string.Empty)
                {
                    if (StatTypeComboBox.SelectedIndex == StatTypeComboBox.Items.IndexOf("Activities"))
                        Line += "Hours: " + DataGridView.Rows[row].Cells[1].FormattedValue.ToString() + " \n";
                    else
                        Line += "Units: " + DataGridView.Rows[row].Cells[1].FormattedValue.ToString() + " \n";
                }
                else
                {
                    Line += "\n";
                }

                if (DataGridView.Rows[row].Cells[2].FormattedValue.ToString() != string.Empty)
                {
                    Line += "Comments: " + DataGridView.Rows[row].Cells[2].FormattedValue.ToString() + "\n";
                }
                else
                {
                    Line += "\n";
                }

                Writer.WriteLine(Line);
            }
            Writer.Close();

            MessageBox.Show("Printed the document to a text file!");
        }

        private void ChartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update Chart
            foreach (var series in Chart.Series)
            {
                series.Points.Clear();
            }


            for (int row = 0; row < DataGridView.Rows.Count - 1; row++)
            {
                //if (DataGridView.Rows[row].Cells[0].FormattedValue.ToString() == string.Empty)
                //    Chart.Series[0].Points.AddXY("Uncategorized", Convert.ToDouble(DataGridView.Rows[row].Cells[1].Value));
                //else
                    if (ChartListBox.SelectedItems.Contains(DataGridView.Rows[row].Cells[0].FormattedValue.ToString()))
                            Chart.Series[0].Points.AddXY(DataGridView.Rows[row].Cells[0].FormattedValue.ToString(), Convert.ToDouble(DataGridView.Rows[row].Cells[1].Value));
                    
            }
            Chart.DataBind();
        }

    }
}