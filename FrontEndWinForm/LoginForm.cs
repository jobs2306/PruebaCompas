using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;

namespace FrontEndWinForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool Band = false;

        private async void ButLog_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

            using (var client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                    { "client_id", "BackEndCompas" },
                    { "client_secret", clientSecret },
                    { "grant_type", "password" },
                    { "username", username },
                    { "password", password }
                };

                var content = new FormUrlEncodedContent(parameters);
                var response = await client.PostAsync("http://localhost:8080/realms/ApiProductosRealm/protocol/openid-connect/token", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonSerializer.Deserialize<JsonElement>(responseBody);

                    // Almacenar el token
                    Program.AccessToken = tokenData.GetProperty("access_token").GetString();

                    // Autenticación exitosa
                    MessageBox.Show("Inicio de sesión exitoso.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Inténtalo de nuevo.");
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButLog_Click(sender, e);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButLog_Click(sender, e);
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (Band != false)
            {
                if (txtUsername.Text == "Username")
                {
                    txtUsername.Text = string.Empty;
                }
            }
            Band = true;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtUsername.Text == null)
            {
                txtUsername.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = string.Empty;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == null)
            {
                txtPassword.Text = "Password";
            }
        }
    }
}
