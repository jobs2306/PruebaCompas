using FrontEndWinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEndWinForm
{
    public partial class ProductoForm : Form
    {
        private Producto _producto;
        private bool _act = false;
        // Constructor por defecto (para agregar)
        public ProductoForm()
        {
            InitializeComponent();

            buttonCreateProd.Visible = true; //botón para crear productos
            buttActProd.Visible = false;  //botón para actualizar productos
            label1.Text = "Crear producto";
            //de esta manera se recicla el formulario, con los dos constructores se escoge cual botón activar
        }

        // Constructor modificado
        public ProductoForm(Producto producto) : this() // Llama al constructor base
        {
            _producto = producto;
            _act = true;
            // Cargar los datos del producto en los controles del formulario
            txtNombre.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            txtPrecio.Text = producto.Precio.ToString();
            txtStock.Text = producto.Stock.ToString();

            buttActProd.Visible = true;
            buttonCreateProd.Visible = false;
            label1.Text = "Actualizar producto";
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {

        }

        private async void buttonCreateProd_Click(object sender, EventArgs e)
        {
            // Crear un objeto Producto con los datos del formulario
            var producto = new Producto
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };

            // Enviar el producto a la API
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.AccessToken);
                string link = Program.APiBaseUrl + "/Productos";
                var response = await client.PostAsJsonAsync(link, producto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto agregado correctamente");
                    this.DialogResult = DialogResult.OK; // Indica al formulario principal que fue exitoso
                    this.Close(); // Cierra el formulario
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al agregar producto: {error}");
                }
            }
        }

        private async void buttActProd_Click(object sender, EventArgs e)
        {
            // Validar datos del formulario
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                !decimal.TryParse(txtPrecio.Text, out var precio) ||
                !int.TryParse(txtStock.Text, out var stock))
            {
                MessageBox.Show("Por favor, llena todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el objeto producto para actualizar
            var producto = new Producto
            {
                Id = _producto.Id, // Suponiendo que tienes un campo txtId para el ID
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = precio,
                Stock = stock
            };

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.AccessToken);
                var response = await client.PutAsJsonAsync($"{Program.APiBaseUrl}/Productos/{producto.Id}", producto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK; // Cierra el formulario y devuelve OK
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, coma, y tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquear cualquier otra tecla
            }

            // Solo permitir una coma
            if (e.KeyChar == ',' && txtPrecio.Text.Contains(","))
            {
                e.Handled = true; // Bloquear si ya hay una coma
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquear cualquier otra tecla
            }
        }
    }
}
