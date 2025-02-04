using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace FrontEndWinForm
{
    internal static class Program
    {
        public static string AccessToken { get; set; }

        //Cambiar por la URL local donde se ejecuta la API 
        public static string APiBaseUrl { get; set; } = "http://localhost:5121/api";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar el LoginForm primero
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Si la autenticación es exitosa, abrir el MainForm
                    Application.Run(new Form1());
                }
                else
                {
                    // Si el usuario no se autentica, cerrar la aplicación
                    Application.Exit();
                }
            }
        }

        public static bool HasRole(string role)
        {
            if (string.IsNullOrEmpty(AccessToken)) return false;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(AccessToken);

            // Buscar en resource_access
            var resourceAccessClaim = token.Claims.FirstOrDefault(c => c.Type == "resource_access");

            if (resourceAccessClaim != null)
            {
                // Deserializar resource_access como un objeto dinámico
                var resourceAccess = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(resourceAccessClaim.Value);

                // Verificar si BackEndCompas tiene roles

                if (resourceAccess.ContainsKey("BackEndCompas"))
                {
                    var roles = resourceAccess["BackEndCompas"]["roles"] as IEnumerable<object>;
                    if (roles != null)
                    {
                        foreach (var roleItem in roles)
                        {
                            if (roleItem.ToString() == role) // Comparación explícita
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false; // Si no se encuentra el rol
        }
    }
}