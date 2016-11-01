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
    public partial class AdministrationForm : Form
    {
        static String spreadsheetId = "1XW9N0Q0nEspvkKHvgj5mmSDajtBDmMBB_weaEZQxICw";
        static String rangeTeams = "TeamList!A2:D";
        public string _teamTag;
        SpreadsheetsResource.ValuesResource.GetRequest request;
        ValueRange response;
        IList<IList<Object>> values;

        public AdministrationForm(string TeamTag)
        {
            _teamTag = TeamTag;
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            CC ConCredential = new CC();

            #region Team List Combo box filling
            request = ConCredential.service.Spreadsheets.Values.Get(spreadsheetId, rangeTeams);
            // Gets the Heroes from spreadsheet:

            response = request.Execute();
            values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row[0].ToString() == _teamTag)
                    {
                        labelTeamName.Text = _teamTag;
                        labelSSID.Text = row[1].ToString();
                        labelAdminPass.Text = row[2].ToString();
                        labelMemberPass.Text = row[3].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Team Data Found", "", MessageBoxButtons.OK);
            }
            #endregion Team List Combo box filling

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label member = new Label();
            member.Text = textBox1.Text;
            member.Name = textBox1.Text;
            member.Click += Member_Click;
            flowLayoutPanel1.Controls.Add(member);
            comboBox1.Items.Add(member.Text);
        }

        private void Member_Click(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string member = comboBox1.Text;
            flowLayoutPanel1.Controls.RemoveByKey(member);
            comboBox1.Items.Remove(member);
            comboBox1.ResetText();
        }
    }
}
