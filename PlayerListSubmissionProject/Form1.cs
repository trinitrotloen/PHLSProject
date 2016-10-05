using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace PlayerListSubmissionProject
{
    public partial class Form1 : Form
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        static String spreadsheetId = null; 
        static String rangeHeroes = "Heroes List!H2:H";
        static String rangePlayers = "Player List!A5:A35";

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string _spreadsheetID)
        {
            spreadsheetId = _spreadsheetID;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.ReadWrite))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            SpreadsheetsResource.ValuesResource.GetRequest request;
            ValueRange response;
            IList<IList<Object>> values;
            // Define request parameters.

            #region Player List Combo box filling
            request = service.Spreadsheets.Values.Get(spreadsheetId, rangePlayers);
            // Gets the Heroes from spreadsheet:

            response = request.Execute();
            values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboUsername.Items.Add(row[0]);
                }
            }
            else
            {
                MessageBox.Show("No Data Found", "", MessageBoxButtons.OK);
            }
            #endregion Player List Combo box filling

            #region Heroes Combo box filling
            request = service.Spreadsheets.Values.Get(spreadsheetId, rangeHeroes);
            // Gets the Heroes from spreadsheet:

            response = request.Execute();
            values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    comboHeroList1.Items.Add(row[0]);
                    comboHeroList2.Items.Add(row[0]);
                    comboHeroList3.Items.Add(row[0]);
                    comboHeroList4.Items.Add(row[0]);
                    comboHeroList5.Items.Add(row[0]);
                    comboHeroList6.Items.Add(row[0]);
                    comboHeroList7.Items.Add(row[0]);
                    comboHeroList8.Items.Add(row[0]);
                    comboHeroList9.Items.Add(row[0]);
                    comboHeroList10.Items.Add(row[0]);
                    comboHeroList11.Items.Add(row[0]);
                }
            }
            else
            {
                MessageBox.Show("No Data Found", "", MessageBoxButtons.OK);
            }
            #endregion Heroes Combo box filling

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.ReadWrite))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            
            var values = new List<Object> { };

            values.Add(DateTime.UtcNow.Ticks);
            values.Add(comboUsername.Text);
            values.Add(comboHeroList1.Text + " " + comboBox1.Text + " " + numericUpDown1.Value);
            values.Add(comboHeroList2.Text + " " + comboBox2.Text + " " + numericUpDown2.Value);
            values.Add(comboHeroList3.Text + " " + comboBox3.Text + " " + numericUpDown3.Value);
            values.Add(comboHeroList4.Text + " " + comboBox4.Text + " " + numericUpDown4.Value);
            values.Add(comboHeroList5.Text + " " + comboBox5.Text + " " + numericUpDown5.Value);
            values.Add(comboHeroList6.Text + " " + comboBox6.Text + " " + numericUpDown6.Value);
            values.Add(comboHeroList7.Text + " " + comboBox7.Text + " " + numericUpDown7.Value);
            values.Add(comboHeroList8.Text + " " + comboBox8.Text + " " + numericUpDown8.Value);
            values.Add(comboHeroList9.Text + " " + comboBox9.Text + " " + numericUpDown9.Value);
            values.Add(comboHeroList10.Text + " " + comboBox10.Text + " " + numericUpDown10.Value);
            values.Add(comboHeroList11.Text + " " + comboBox11.Text + " " + numericUpDown11.Value);

            var valuesFromForm = new List<IList<Object>> { };
            valuesFromForm.Add(values);

            var valueRangebody = new ValueRange();
            valueRangebody.Range = "abidik!A1:M1";
            valueRangebody.MajorDimension = "ROWS";
            valueRangebody.Values = valuesFromForm;

            SpreadsheetsResource.ValuesResource.AppendRequest app = service.Spreadsheets.Values.Append(valueRangebody, spreadsheetId, "abidik!A1:M1");
            app.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
            var response = app.Execute();

        }

    }
}

