using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace PlayerListSubmissionProject
{
    public partial class SpreadsheetSelectionForm : Form
    {
        static String spreadsheetId = "1XW9N0Q0nEspvkKHvgj5mmSDajtBDmMBB_weaEZQxICw";
        static String rangeTeams = "TeamList!A2:B";

        SpreadsheetsResource.ValuesResource.GetRequest request;
        ValueRange response;
        IList<IList<Object>> values;
        // Define request parameters.

        public SpreadsheetSelectionForm()
        {
            InitializeComponent();
        }

        private void spreadsheetSubmit(object sender, EventArgs e)
        {
            var sheetid = findSheetID(comboBox1.Text);
            this.Hide();
            Form phls = new Form1(sheetid);
            phls.ShowDialog();
            foreach (var openform in Application.OpenForms)
            {
                this.Show();
            }
        }

        private void SpreadsheetSelectionForm_Load(object sender, EventArgs e)
        {
            CC ConCredentials = new CC();
            
            #region Team List Combo box filling
            request = ConCredentials.service.Spreadsheets.Values.Get(spreadsheetId, rangeTeams);
            // Gets the Heroes from spreadsheet:

            response = request.Execute();
            values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboBox1.Items.Add(row[0]);
                }
            }
            else
            {
                MessageBox.Show("No Data Found", "", MessageBoxButtons.OK);
            }
            #endregion Team List Combo box filling
        }

        private string findSheetID (string teamTAG)
        {
            values = response.Values;
            for (int i = 0; i < values.Count; i++) {
                    if (values[i].Contains(teamTAG))
                    {
                        return values[i][1].ToString();
                    }
                }
            return "";
        }

        private void button_TeamManage_Click(object sender, EventArgs e)
        {
            var teamTag = comboBox1.Text;
            this.Hide();
            Form adminf = new AdministrationForm(teamTag);
            adminf.ShowDialog();
            foreach (var openform in Application.OpenForms)
            {
                this.Show();
            }
        }
    }
}
