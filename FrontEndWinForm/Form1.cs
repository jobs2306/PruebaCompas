using Newtonsoft.Json;
using FrontEndWinForm.Models;

namespace FrontEndWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
            Acceso();
        }

        private void buttAddProd_Click(object sender, EventArgs e)
        {
            using (var productoForm = new ProductoForm())
            {
                if (productoForm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void buttChangeProd_Click(object sender, EventArgs e)
        {
            if (lvProductos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un ID de producto para modificar.");
                return;
            }

            // Obtener el producto seleccionado
            var productoSeleccionado = lvProductos.SelectedItems[0];
            var producto = new Producto
            {
                Id = int.Parse(productoSeleccionado.Text),
                Nombre = productoSeleccionado.SubItems[1].Text,
                Descripcion = productoSeleccionado.SubItems[2].Text,
                Precio = decimal.Parse(productoSeleccionado.SubItems[3].Text),
                Stock = int.Parse(productoSeleccionado.SubItems[4].Text)
            };

            using (var productoForm = new ProductoForm(producto))
            {
                if (productoForm.ShowDialog() == DialogResult.OK)
                {
                    // Recargar la lista de productos después de modificar
                    CargarProductos();
                }
            }
        }

        private async void buttDeleteProd_Click(object sender, EventArgs e)
        {
            // Verificar si hay un producto seleccionado
            if (lvProductos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar la eliminación
            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                "Confirmar Eliminación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
            {
                return; // Cancelar la eliminación si el usuario selecciona "No"
            }

            // Obtener el ID del producto seleccionado
            var productoSeleccionado = lvProductos.SelectedItems[0];
            var productoId = productoSeleccionado.Text; // El texto de la primera columna contiene el ID

            using (var client = new HttpClient())
            {
                // Configurar la autorización con el token
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.AccessToken);

                // Enviar la solicitud DELETE a la API
                string link = Program.APiBaseUrl + "/Productos/" + productoId;
                var response = await client.DeleteAsync(link);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar la lista de productos
                    CargarProductos();
                }
                else
                {
                    // Mostrar un error si la eliminación falla
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar el producto: {response.StatusCode}\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttActProd_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        //Evento para verificar acceso
        private void Acceso()
        {
            // Verificar si el usuario tiene permisos en caso de un fallo de seguridad
            if (Program.HasRole("writter") == false)
            {
                buttAddProd.Visible = false;
                buttChangeProd.Visible = false;
                buttDeleteProd.Visible = false;
            }
            /*
            else if (Program.HasRole("reader") == false)
            {
                panel7.Visible = false;
            }
            */
        }

        //Evento para cargar los productos
        private async void CargarProductos()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.AccessToken);
                string link = Program.APiBaseUrl + "/Productos";
                var response = await client.GetAsync(link);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var productos = JsonConvert.DeserializeObject<List<Producto>>(responseBody);

                    lvProductos.Items.Clear();
                    foreach (var producto in productos)
                    {
                        var item = new ListViewItem(producto.Id.ToString());
                        item.SubItems.Add(producto.Nombre);
                        item.SubItems.Add(producto.Descripcion);
                        item.SubItems.Add(producto.Precio.ToString());
                        item.SubItems.Add(producto.Stock.ToString());
                        lvProductos.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar productos");
                }
            }
        }
    }
}
