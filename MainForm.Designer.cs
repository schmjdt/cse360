namespace Jamijo
{
    partial class MainForm
    {
        /// <Jamijo>
        /// Required designer variable.
        /// </Jamijo>
        private System.ComponentModel.IContainer components = null;

        /// <Jamijo>
        /// Clean up any resources being used.
        /// </Jamijo>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <Jamijo>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </Jamijo>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HoursColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartComboBox = new System.Windows.Forms.ComboBox();
            this.StatTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.ChartListBox = new System.Windows.Forms.ListBox();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.AddUserTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeColumn,
            this.HoursColumn,
            this.CommentsColumn});
            this.DataGridView.Location = new System.Drawing.Point(25, 86);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 98;
            this.DataGridView.Size = new System.Drawing.Size(500, 162);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Items.AddRange(new object[] {
            "Leisure",
            "Exercise",
            "Sleep",
            "Eating",
            "Transportation"});
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // HoursColumn
            // 
            this.HoursColumn.HeaderText = "Hours";
            this.HoursColumn.Name = "HoursColumn";
            // 
            // CommentsColumn
            // 
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            this.CommentsColumn.Width = 200;
            // 
            // Chart
            // 
            this.Chart.BorderlineColor = System.Drawing.Color.Black;
            this.Chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(25, 278);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Activities";
            series1.Name = "Series1";
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(500, 200);
            this.Chart.TabIndex = 1;
            this.Chart.Text = "chart1";
            // 
            // ChartComboBox
            // 
            this.ChartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChartComboBox.FormattingEnabled = true;
            this.ChartComboBox.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.ChartComboBox.Location = new System.Drawing.Point(537, 457);
            this.ChartComboBox.Name = "ChartComboBox";
            this.ChartComboBox.Size = new System.Drawing.Size(96, 21);
            this.ChartComboBox.TabIndex = 2;
            this.ChartComboBox.SelectedValueChanged += new System.EventHandler(this.ChartComboBox_SelectedIndexChanged);
            // 
            // StatTypeComboBox
            // 
            this.StatTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatTypeComboBox.FormattingEnabled = true;
            this.StatTypeComboBox.Items.AddRange(new object[] {
            "Activities",
            "Health Statistics"});
            this.StatTypeComboBox.Location = new System.Drawing.Point(414, 43);
            this.StatTypeComboBox.Name = "StatTypeComboBox";
            this.StatTypeComboBox.Size = new System.Drawing.Size(111, 21);
            this.StatTypeComboBox.TabIndex = 3;
            this.StatTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.StatTypeComboBox_SelectedIndexChanged);
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Location = new System.Drawing.Point(537, 86);
            this.MonthCalendar.MaxSelectionCount = 1;
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 6;
            this.MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateSelected);
            // 
            // ChartListBox
            // 
            this.ChartListBox.FormattingEnabled = true;
            this.ChartListBox.Items.AddRange(new object[] {
            "Leisure",
            "Exercise",
            "Sleeping",
            "Eating",
            "Transportation",
            "Calories",
            "Height",
            "Weight",
            "Blood Pressure",
            "Heart Rate"});
            this.ChartListBox.Location = new System.Drawing.Point(537, 278);
            this.ChartListBox.Name = "ChartListBox";
            this.ChartListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ChartListBox.Size = new System.Drawing.Size(227, 160);
            this.ChartListBox.TabIndex = 7;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(136, 40);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(100, 23);
            this.AddUserButton.TabIndex = 8;
            this.AddUserButton.Text = "Add User";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(664, 457);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(100, 23);
            this.PrintButton.TabIndex = 9;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            // 
            // UserComboBox
            // 
            this.UserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(25, 42);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(100, 21);
            this.UserComboBox.TabIndex = 12;
            this.UserComboBox.SelectedIndexChanged += new System.EventHandler(this.UserComboBox_SelectedIndexChanged);
            // 
            // AddUserTextBox
            // 
            this.AddUserTextBox.Location = new System.Drawing.Point(250, 43);
            this.AddUserTextBox.Name = "AddUserTextBox";
            this.AddUserTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddUserTextBox.TabIndex = 13;
            this.AddUserTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddUserTextBox_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 502);
            this.Controls.Add(this.AddUserTextBox);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.ChartListBox);
            this.Controls.Add(this.MonthCalendar);
            this.Controls.Add(this.StatTypeComboBox);
            this.Controls.Add(this.ChartComboBox);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.DataGridView);
            this.Name = "MainForm";
            this.Text = "Personal Tracking Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.ComboBox ChartComboBox;
        private System.Windows.Forms.ComboBox StatTypeComboBox;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.ListBox ChartListBox;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.TextBox AddUserTextBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;
    }
}

