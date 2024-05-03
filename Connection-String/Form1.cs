using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Connection_String
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Test Connection successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Test connection
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("cn", connectionString);
                    MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save connection string: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to construct connection string
        private string GetConnectionString()
        {
            return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
        }

        private void Config_Load(object sender, EventArgs e)
        {
            // Set default server options
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.Items.Add("localhost");
            cboServer.SelectedIndex = 4; // Default
        }
    }
}
