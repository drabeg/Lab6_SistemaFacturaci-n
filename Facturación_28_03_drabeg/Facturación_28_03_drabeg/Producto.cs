using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturación_28_03_drabeg
{
    public class Producto
    {
        // Atributos según UML
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }

        // Constructores
        public Producto() { }
        public Producto(int id, string nom, decimal prec, int cant)
        {
            this.idProducto = id;
            this.nombre = nom;
            this.precio = prec;
            this.cantidad = cant;
        }

        // Métodos específicos
        public void RegistrarProducto()
        {
            // Lógica para registrar (ya implementada en el formulario)
        }

        public string MostrarDatos()
        {
            return $"[{idProducto}] {nombre} - Cant: {cantidad} - Q.{precio}";
        }
    }
}
