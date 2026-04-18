using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturación_28_03_drabeg
{
    public class Proveedor : Persona
    {
        // Atributos específicos según UML
        public int idProveedor { get; set; }
        public string empresa { get; set; }

        // Constructores
        public Proveedor() { }
        public Proveedor(int id, string nom, string tel, string emp, string dir = "N/A") : base(nom, dir)
        {
            this.idProveedor = id;
            this.empresa = emp;
            this.telefono = tel; 
        }
        public string telefono { get; set; }

        // Métodos específicos
        public void RegistrarProveedor()
        {
            // Lógica para registrar 
        }

        // Polimorfismo: Sobrescribir MostrarDatos
        public override string MostrarDatos()
        {
            return $"[{idProveedor}] {empresa} - Contacto: {nombre}";
        }
    }
}
