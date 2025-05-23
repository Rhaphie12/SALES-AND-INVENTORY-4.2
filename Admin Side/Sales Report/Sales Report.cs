﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Admin_Side.Sales_Report
{
    public partial class Sales_Report : Form
    {
        public Sales_Report()
        {
            InitializeComponent();
        }

        private void Sales_Report_Load(object sender, EventArgs e)
        {
            CoffeeSales();
            NonCoffeeSales();
            HotCoffeeSales();
        }

        public void CoffeeSales()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM productsales_coffee";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;

                    // Fill the DataTable with data from the "stocks" table
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Use the embedded Crystal Report
                    sims.CoffeeSales stocksReport = new sims.CoffeeSales();

                    // Set the DataTable as the data source for the report
                    stocksReport.SetDataSource(dt);

                    // Assign the report to the CrystalReportViewer
                    CoffeeSalesViewer.ReportSource = stocksReport;
                    CoffeeSalesViewer.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void NonCoffeeSales()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM productsales_noncoffee";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;

                    // Fill the DataTable with data from the "stocks" table
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Use the embedded Crystal Report
                    sims.NonCoffeeSales stocksReport = new sims.NonCoffeeSales();

                    // Set the DataTable as the data source for the report
                    stocksReport.SetDataSource(dt);

                    // Assign the report to the CrystalReportViewer
                    NonCoffeeSalesViewer.ReportSource = stocksReport;
                    NonCoffeeSalesViewer.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void HotCoffeeSales()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM productsales_hotcoffee";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;

                    // Fill the DataTable with data from the "stocks" table
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Use the embedded Crystal Report
                    sims.HotCoffeeSales stocksReport = new sims.HotCoffeeSales();

                    // Set the DataTable as the data source for the report
                    stocksReport.SetDataSource(dt);

                    // Assign the report to the CrystalReportViewer
                    HotCoffeeSalesViewer.ReportSource = stocksReport;
                    HotCoffeeSalesViewer.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}