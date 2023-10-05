using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    internal class Legislador
    {
        protected string PartidoPolitico;
        protected string DepartamentoQueRepresenta;
        protected int NumDespacho;
        protected string Nombre;
        protected string Apellido;
        protected int Edad;
        protected bool Casado;

        public Legislador()
        {
        }
        public Legislador(string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado)
        {
            this.PartidoPolitico = PartidoPolitico;
            this.DepartamentoQueRepresenta = DepartamentoQueRepresenta;
            this.NumDespacho = NumDespacho;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Edad = Edad;
            this.Casado = Casado;
        }

        public string getPartidoPolitico() => PartidoPolitico;

        public void setPartidoPolitico(string PartidoPolitico) => this.PartidoPolitico = PartidoPolitico;

        public string getDepartamentoQueRepresenta() => DepartamentoQueRepresenta;

        public void setDepartamentoQueRepresenta(string DepartamentoQueRepresenta) => this.DepartamentoQueRepresenta = DepartamentoQueRepresenta;

        public int getNumDespacho() => NumDespacho;

        public void setNumDespacho(int NumDespacho) => this.NumDespacho = NumDespacho;

        public string getNombre() => Nombre;

        public void setNombre(string Nombre) => this.Nombre = Nombre;

        public string getApellido() => Apellido;

        public void setApellido(string Apellido) => this.Apellido = Apellido;

        public int getEdad() => Edad;

        public void setEdad(int Edad) => this.Edad = Edad;

        public bool getCasado() => Casado;

        public void setCasado(bool Casado) => this.Casado = Casado;

        public virtual string getCamara() => "";

        public virtual int getAsiento() => 0;

        public virtual string presentarPropuestaLegislativa()
        {
            Console.WriteLine("Propuesta legislativa");
            return "";
        }

        public virtual string ParticiparDebate()
        {
            Console.WriteLine("Y depende, viste como es la cosa");
            return "";
        }

        public virtual string Votar()
        {
            Console.WriteLine("Ha votado.");
            return "";
        }




    }
}
