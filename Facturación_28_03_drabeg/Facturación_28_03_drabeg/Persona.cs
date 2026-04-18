using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturación_28_03_drabeg
{
    // Se usa para definir una base común que no se puede usar
    // directamente, pero que sirve para que otras clases hereden
    // su estructura y comportamiento, obligando a implementar
    // lo que se declare como abstracto.
    public abstract class Persona
    {
        // Encapsulamiento 
        public string nombre { get; set; }
        public string direccion { get; set; }

        // Constructores
        public Persona() { }
        public Persona(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
        }

        // Métodos según diagrama UML
        public string ObtenerNombre()
        {
            return nombre;
        }

        // Método abstracto para Polimorfismo
        public abstract string MostrarDatos();
    }
}
