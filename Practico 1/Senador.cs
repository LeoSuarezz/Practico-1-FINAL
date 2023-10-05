using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    internal class Senador : Legislador
    {
        private int NumAsientoCamaraAlta;

        public Senador() { }
        public Senador(string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho,
        string Nombre, string Apellido, int Edad, bool Casado, int NumAsientoCamaraAlta) 
        : base(PartidoPolitico, DepartamentoQueRepresenta, NumDespacho, Nombre, Apellido, Edad, Casado)
        {
            this.NumAsientoCamaraAlta = NumAsientoCamaraAlta;
        }

        public int getNumAsientoCamaraAlta() => NumAsientoCamaraAlta;

        public void setNumAsientoCamaraAlta(int NumAsientoCamaraAlta) => this.NumAsientoCamaraAlta = NumAsientoCamaraAlta;

        public override string getCamara() => "Senador";

        public override int getAsiento() => NumAsientoCamaraAlta;

        public override string presentarPropuestaLegislativa()
        {
            string propuesta = Console.ReadLine();
            return propuesta;
        }
        public override string ParticiparDebate()
        {
            string participacion = Console.ReadLine();
            return participacion;   
        }

        public override string Votar()
        {
            string voto = Console.ReadLine();
            return voto;
        }
    }
}
