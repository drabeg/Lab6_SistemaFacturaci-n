using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturación_28_03_drabeg
{
    public partial class Form1 : Form
    {
        // Listas con los nombres de clase/propiedades del UML
        List<Cliente> clientes = new List<Cliente>();
        List<Proveedor> proveedores = new List<Proveedor>();
        List<Producto> productos = new List<Producto>();
        List<Factura> facturas = new List<Factura>();

        public Form1()
        {
            InitializeComponent();

            // ESTO EVITA LAS COLUMNAS DUPLICADAS
            dgvClientes.AutoGenerateColumns = false;
            dgvProveedores.AutoGenerateColumns = false;
            dgvProductos.AutoGenerateColumns = false;
            dgvFacturas.AutoGenerateColumns = false;
        }

        private void btnAgregarCliente_Click_1(object sender, EventArgs e)
                    // ------- Botón Agregar Cliente --------
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text)) { MessageBox.Show("Ingrese nombre"); return; }

            Cliente c = new Cliente(
                clientes.Count + 1,
                txtNombreCliente.Text,
                txtTelefonoCliente.Text,
                txtDireccionCliente.Text
            );

            clientes.Add(c);
            c.RegistrarCliente();

            // Refrescar Grid
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes;
        }

        private void btnAgregarProveedor_Click_1(object sender, EventArgs e)
        {
                    // ---- Botón Agregar Proveedores --
            if (string.IsNullOrWhiteSpace(txtNombreProveedor.Text)) { MessageBox.Show("Ingrese nombre de contacto"); return; }

            Proveedor p = new Proveedor(
                proveedores.Count + 1,
                txtNombreProveedor.Text,
                txtTelefonoProveedor.Text,
                txtEmpresaProveedor.Text,
                "Ciudad" // Dirección por defecto ya que no hay campo en el form
            );

            proveedores.Add(p);
            p.RegistrarProveedor();

            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = proveedores;
        }

        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            // 1. Validaciones de seguridad
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precioDecimal;
            // Intentar convertir el texto a decimal de forma segura
            if (!decimal.TryParse(txtPrecioProducto.Text, out precioDecimal))
            {
                MessageBox.Show("Por favor, ingrese un precio válido (ej: 100.00).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar convertir la cantidad a entero de forma segura
            int cantidadIngresada;
            if (!int.TryParse(txtCantidadProducto.Text, out cantidadIngresada) || cantidadIngresada <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Crear el objeto Producto usando el constructor compatible con UML
            Producto p = new Producto(
                productos.Count + 1,
                txtNombreProducto.Text,
                precioDecimal,
                cantidadIngresada // Pasamos la cantidad ingresada al constructor
            );

            // 3. Agregar a la lista
            productos.Add(p);
            p.RegistrarProducto(); // Llamada al método UML

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;

            // Opcional: Limpiar campos de texto para el siguiente ingreso
            txtNombreProducto.Clear();
            txtPrecioProducto.Clear();
            txtCantidadProducto.Clear();
            txtNombreProducto.Focus();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            // Verificamos que haya al menos un cliente y productos para facturar
            if (clientes.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un cliente primero.");
                return;
            }
            if (productos.Count == 0)
            {
                MessageBox.Show("Debe agregar productos para generar la factura.");
                return;
            }

            // Tomamos el último cliente ingresado
            Cliente clienteActual = clientes.Last();

            // Creamos la factura
            Factura f = new Factura(facturas.Count + 1, clienteActual);

            // Le pasamos TODOS los productos que están en la lista a esta factura
            f.listaProductos.AddRange(productos);

            // Calculamos el total usando el método del UML
            f.GenerarFactura();

            // Guardamos la factura en la lista
            facturas.Add(f);

            // Refrescamos la tabla de facturas
            dgvFacturas.DataSource = null;

            // Creamos una vista anónima rápida 
            dgvFacturas.DataSource = facturas.Select(fac => new {
                Id = fac.idFactura,
                Cliente = fac.clienteAsociado.nombre
            }).ToList();

            // MOSTRAMOS EL TOTAL EN EL LABEL 
            lblTotal.Text = $"Total: Q {f.total}";
        }

    }
}
