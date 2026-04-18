using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturación_28_03_drabeg
{
    public class Factura
    {
        // Atributos según UML
        public int idFactura { get; set; }
        // En el UML se sugiere total como atributo, pero es mejor calcularlo dinámicamente
        // para asegurar que siempre esté actualizado.
        public decimal total { get; set; }

        // Relaciones necesarias no especificadas explícitamente en el UML 
        // pero obligatorias para que funcione el sistema de facturación
        public Cliente clienteAsociado { get; set; }
        public List<Producto> listaProductos { get; set; } = new List<Producto>();

        // Constructores
        public Factura() { }
        public Factura(int id, Cliente cli)
        {
            this.idFactura = id;
            this.clienteAsociado = cli;
        }

        // Métodos específicos
        public void GenerarFactura()
        {
            // Lógica para calcular el total
            this.total = listaProductos.Sum(p => p.precio * p.cantidad);
        }

        // Polimorfismo/Sobrecarga sugerida por el form de facturas
        public string MostrarDatos()
        {
            if (clienteAsociado == null) return $"Factura #{idFactura}";
            return $"Factura #{idFactura} - Cliente: {clienteAsociado.nombre}";
        }
    }
}
