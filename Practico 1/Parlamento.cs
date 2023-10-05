using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    internal class Parlamento
    {
        private List<Legislador> listaLegisladores;
        private List<string> listaPropuestasLegislativas;

        public Parlamento() 
        {
            listaLegisladores = new List<Legislador>();
            listaPropuestasLegislativas = new List<string>();
        }

        public List<Legislador> GetListaLegisladores()
        {
            return listaLegisladores;
        }

        public void SetListaLegisladores(List<Legislador> nuevaLista)
        {
            listaLegisladores = nuevaLista;
        }
        public List<string> GetListaPropuestaLegislativa()
        {
            return listaPropuestasLegislativas;
        }

        public void SetListaPropuestaLegislativa(List<string> nuevaLista)
        {
            listaPropuestasLegislativas = nuevaLista;
        }
        public void AgregarDatoString(string dato)
        {
            listaPropuestasLegislativas.Add(dato);
        }

        Random Random = new Random(); 
        Senador Senador = new Senador();
        Diputado Diputado = new Diputado();

        public void RegistrarSenador(string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado, int NumAsientoCamaraAlta)
        {
            Senador Senadores = new Senador();
            Senadores.setPartidoPolitico(PartidoPolitico);
            Senadores.setDepartamentoQueRepresenta(DepartamentoQueRepresenta);
            Senadores.setNumDespacho(NumDespacho);
            Senadores.setNombre(Nombre);
            Senadores.setApellido(Apellido);
            Senadores.setEdad(Edad);
            Senadores.setCasado(Casado);
            Senadores.setNumAsientoCamaraAlta(NumAsientoCamaraAlta);
            listaLegisladores.Add(Senadores);
        }

        public void RegistrarDiputado(string PartidoPolitico, string DepartamentoQueRepresenta, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado, int NumAsientoCamaraBaja)
        {
            Diputado Diputados = new Diputado();
            Diputados.setPartidoPolitico(PartidoPolitico);
            Diputados.setDepartamentoQueRepresenta(DepartamentoQueRepresenta);
            Diputados.setNumDespacho(NumDespacho);
            Diputados.setNombre(Nombre);
            Diputados.setApellido(Apellido);
            Diputados.setEdad(Edad);
            Diputados.setCasado(Casado);
            Diputados.setNumAsientoCamaraBaja(NumAsientoCamaraBaja);
            listaLegisladores.Add(Diputados);
        }

        public void ListarCamaras(List<Legislador> legisladores) 
        {
            Console.Clear();
            Console.WriteLine("Senadores:");
            Console.WriteLine("");

            foreach (Legislador legislador in legisladores.OfType<Senador>())
            {
                Console.WriteLine($"Nombre del Legislador: {legislador.getNombre()}, {legislador.getApellido()}");
                Console.WriteLine($"Partido Político: {legislador.getPartidoPolitico()}");
                Console.WriteLine($"Departamento que representa: {legislador.getDepartamentoQueRepresenta()}");
                Console.WriteLine($"Número de despacho: {legislador.getNumDespacho()}");
                Console.WriteLine($"Número de Asiento de Cámara: {legislador.getAsiento()}");
                Console.WriteLine("");
            }

            Console.WriteLine("Presione ENTER para ver los Diputados:");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Diputados:");
            Console.WriteLine("");

            foreach (Legislador legislador in legisladores.OfType<Diputado>())
            {
                Console.WriteLine($"Nombre del Legislador: {legislador.getNombre()}, {legislador.getApellido()}");
                Console.WriteLine($"Partido Político: {legislador.getPartidoPolitico()}");
                Console.WriteLine($"Departamento que representa: {legislador.getDepartamentoQueRepresenta()}");
                Console.WriteLine($"Número de despacho: {legislador.getNumDespacho()}");
                Console.WriteLine($"Número de Asiento de Cámara: {legislador.getAsiento()}");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        public void MostrarCantidadYDetalle(List<Legislador> legisladores)
        {
            Console.Clear();
            Console.WriteLine("Detalle total de senadores y Diputados");
            Console.WriteLine("");
            Console.WriteLine($"La cantidad actual de Senadores es: {listaLegisladores.OfType<Senador>().Count()} ");
            Console.WriteLine($"La cantidad actual de Diputados es: {listaLegisladores.OfType<Diputado>().Count()} ");
            Console.WriteLine("");
        }

        public void votoLegisladores(List<Legislador> legisladores, List<string> listaVotos)
        {          
            Random random = new Random();

            int contadorVotosPositivos = 0;
            int contadorVotosNegativos = 0;

            foreach (Legislador legislador in legisladores)
            {
                string tipo = legislador.getCamara();
                Console.WriteLine($"Nombre del {tipo} y Partido Político: {legislador.getNombre()},{legislador.getApellido()} - {legislador.getPartidoPolitico()}");
                int indiceAleatorio = random.Next(listaVotos.Count);
                string opcionElegida = listaVotos[indiceAleatorio];

                Console.WriteLine($"Voto: {opcionElegida}");

                if (opcionElegida == "A favor")
                {
                    contadorVotosPositivos++;
                }
                else if (opcionElegida == "En contra")
                {
                    contadorVotosNegativos++;
                }
            }

            string resultadoVotacion = "";

            if (contadorVotosPositivos > contadorVotosNegativos)
            {
                resultadoVotacion = $"Votación aprobada con {contadorVotosPositivos} votos a favor.";
            }
            else if (contadorVotosNegativos > contadorVotosPositivos)
            {
                resultadoVotacion = $"Votación rechazada con {contadorVotosNegativos} votos en contra.";
            }
            else
            {
                resultadoVotacion = "Empate en la votación.";
            }

            Console.WriteLine("");
            Console.WriteLine("Luego de realizados todos los votos, el resultado es el siguiente: ");
            Console.WriteLine(resultadoVotacion);
        }

        public Legislador ElegirLegislador(List<Legislador> legisladores)
        {
            Console.Clear();
            Console.WriteLine("Elija el N° de Despacho del Legislador que desea seleccionar.");
            Console.WriteLine("");

            Console.WriteLine("Lista de Senadores: ");
            foreach (Legislador legislador in GetListaLegisladores().OfType<Senador>())
            {
                Console.WriteLine($"N° Despacho: {legislador.getNumDespacho()} - Nombre: {legislador.getNombre()}, {legislador.getApellido()} -  Partido Político: {legislador.getPartidoPolitico()}");

            }
            Console.WriteLine("");
            Console.WriteLine("Lista de Diputados: ");
            foreach (Legislador legislador in GetListaLegisladores().OfType<Diputado>())
            {
                Console.WriteLine($"N° Despacho: {legislador.getNumDespacho()} - Nombre: {legislador.getNombre()}, {legislador.getApellido()} -  Partido Político: {legislador.getPartidoPolitico()}");

            }
            Legislador legisladorSeleccionado = null;
            int despachoBuscado = 0;
            bool entradaValida = false;
            string entrada = "";

            Console.WriteLine("");

            while (!entradaValida)
            {
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out despachoBuscado))
                {
                    if (despachoBuscado >= 0 && despachoBuscado <= 1000)
                    {
                        List<Legislador> listaLegisladores = GetListaLegisladores();
                        legisladorSeleccionado = listaLegisladores.FirstOrDefault(legislador => legislador.getNumDespacho() == despachoBuscado);

                        if (legisladorSeleccionado != null)
                        {
                            entradaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún legislador con el número de despacho ingresado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La cantidad no puede ser menor a 0 ni mayor a 1000.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                }
            }
            return legisladorSeleccionado;
        }

        public void VerPropuestas(List<string> Lista)
        {
            Console.Clear();
            Console.WriteLine("Elija una propuesta parlamentaria.");
            Console.WriteLine("Lista de Propuestas: ");
            int num = 1;
            foreach (string propuesta in listaPropuestasLegislativas)
            {
                Console.WriteLine($"{num} - {propuesta} ");
                num = num + 1;
            }
            bool entradaValida = false;
            string entrada = "";
            int propuestaElegida;
            while (!entradaValida)
            {
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out propuestaElegida))
                {
                    if (propuestaElegida >= 1 && propuestaElegida <= listaPropuestasLegislativas.Count)
                    {
                        entradaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("La cantidad no puede ser menor a 0 ni mayor a 1000.");
                    }

                }
                else
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                }
            }
        }
    }
}



