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
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
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


            #region Team List Combo box filling
            request = service.Spreadsheets.Values.Get(spreadsheetId, rangeTeams);
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
    }
}
