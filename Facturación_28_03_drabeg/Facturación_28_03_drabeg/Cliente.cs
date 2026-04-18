using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturación_28_03_drabeg
{
    public class Cliente : Persona
    {
        // Atributos específicos según UML
        public int idCliente { get; set; }
        public string telefono { get; set; }

        // Constructores
        public Cliente() { }
        public Cliente(int id, string nom, string tel, string dir) : base(nom, dir)
        {
            this.idCliente = id;
            this.telefono = tel;
        }

        // Métodos específicos
        public void RegistrarCliente()
        {
            // Lógica para registrar (ya implementada en el formulario)
        }

        // Polimorfismo: Sobrescribir MostrarDatos
        public override string MostrarDatos()
        {
            return $"[{idCliente}] {nombre} - Tel: {telefono} - Dir: {direccion}";
        }
    }
}
