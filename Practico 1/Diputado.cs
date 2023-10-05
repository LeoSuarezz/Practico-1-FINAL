using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    internal class Diputado : Legislador
    {
        private int NumAsientoCamaraBaja;

        public Diputado() { }
        public Diputado (string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, 
        string Apellido, int Edad, bool Casado, int NumAsientoCamaraBaja)
        : base(PartidoPolitico, DepartamentoQueRepresenta, NumDespacho, Nombre, Apellido, Edad, Casado)
        {
            this.NumAsientoCamaraBaja = NumAsientoCamaraBaja;
        }

        Random Random = new Random();

        public int getNumAsientoCamaraBaja() => NumAsientoCamaraBaja;

        public void setNumAsientoCamaraBaja(int NumAsientoCamaraBaja) => this.NumAsientoCamaraBaja = NumAsientoCamaraBaja;

        public override string getCamara() => "Diputado";

        public override int getAsiento() => NumAsientoCamaraBaja;

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

