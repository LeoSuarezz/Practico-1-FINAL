using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Datos Datos = new Datos();

            Parlamento parlamento = new Parlamento();
            Senador Senador = new Senador();
            Diputado Diputado = new Diputado();

            string nombre = "";
            string apellido = "";
            int edad = 0;
            bool casado = false;
            string partidoPolitico = "";
            int departamento;
            int despacho = 0;
            int camara = 0;
            int opcion1;
            string departamentoSeleccionado = "";
            string entrada;
            bool entradaValida = false;
            string opcion;

            Random Random = new Random();

            Console.WriteLine("Bienvenido al Parlamento Uruguayo.");
            Console.WriteLine("1- Ingresar Diputado\n2- Ingresar Senador\n3- Completar Cámaras" +
                "\n4- Listar Cámaras\n5- Presentar Propuesta Legislativa\n6- Votar\n7- Participar del Debate\n8- Salir"); 
            opcion = Console.ReadLine();
            do
            { 
                if (opcion == "1" || opcion == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el Nombre: ");
                    nombre = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Ingrese el Apellido: ");
                    apellido = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Ingrese la Edad: ");
                    while (!entradaValida)
                    {
                        entrada = Console.ReadLine();

                        if (int.TryParse(entrada, out edad))

                        {
                            if (edad >= 18 && edad <= 100)
                            {
                                entradaValida = true;
                            }
                            else
                            {
                                Console.WriteLine("La edad no puede ser menor a 35 años ni mayor a 100 años.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Ingrese el Estado civil: \n1. Casado \n2. Soltero");
                    entradaValida = false;
                    while (!entradaValida)
                    {
                        entrada = Console.ReadLine();

                        if (int.TryParse(entrada, out opcion1))
                        {
                            if (opcion1 == 1)
                            {
                                casado = true;
                                entradaValida = true;
                            }
                            else if (opcion1 == 2)
                            {
                                casado = false;
                                entradaValida = true;
                            }
                            else
                            {
                                Console.WriteLine("El número ingresado no puede ser negativo ni mayor a 2.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Ingrese el Partido Político: ");
                    partidoPolitico = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Elija el Departamento que representa: ");
                    int num1 = 1;
                    foreach (string depa in Datos.GetListaDepartamento())
                    {
                        Console.WriteLine($"{num1} - {depa}");
                        num1 += 1;
                    }
                    entradaValida = false;
                    while (!entradaValida)
                    {
                        entrada = Console.ReadLine();
                        if (int.TryParse(entrada, out departamento))
                        {
                            if (departamento >= 1 && departamento <= 19)
                            {
                                entradaValida = true;
                                Console.WriteLine("Departamento elegido: " + Datos.GetListaDepartamento().ToArray()[departamento - 1].ToString());
                                departamentoSeleccionado = Datos.GetListaDepartamento().ToArray()[departamento - 1].ToString();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Ingrese el N° de despacho: ");
                    entradaValida = false;

                    while (!entradaValida)
                    {
                        entrada = Console.ReadLine();

                        if (int.TryParse(entrada, out despacho))
                        {
                            if (despacho > 0 && despacho < 1000)
                            {
                                bool numeroDespachoDisponible = true;

                                foreach (Legislador legislador in parlamento.GetListaLegisladores())
                                {
                                    if (legislador.getNumDespacho() == despacho)
                                    {
                                        Console.WriteLine("El número de despacho ya está en uso por otro legislador.");
                                        numeroDespachoDisponible = false;
                                        break;
                                    }
                                }

                                if (numeroDespachoDisponible)
                                {
                                    entradaValida = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("El número ingresado no puede ser negativo ni mayor a 1000.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Ingrese un número entero: ");
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Ingrese el N° de asiento de Cámara Alta/Baja del Legislador: ");
                    entradaValida = false;
                    bool asientoDisponible = true;

                    while (!entradaValida)
                    {
                        entrada = Console.ReadLine();

                        if (int.TryParse(entrada, out camara))
                        {
                            if (camara > 0 && camara < 1000)
                            {
                                asientoDisponible = true;

                                if (opcion == "1")
                                {
                                    foreach (Legislador legislador in parlamento.GetListaLegisladores().OfType<Diputado>())
                                    {
                                        if (legislador.getAsiento() == camara)
                                        {
                                            Console.WriteLine("El número de asiento ya está en uso por otro Diputado.");
                                            asientoDisponible = false;
                                            break;
                                        }
                                    }
                                }
                                else if (opcion == "2")
                                {
                                    foreach (Legislador legislador in parlamento.GetListaLegisladores().OfType<Senador>())
                                    {
                                        if (legislador.getAsiento() == camara)
                                        {
                                            Console.WriteLine("El número de asiento ya está en uso por otro Senador.");
                                            asientoDisponible = false;
                                            break;
                                        }
                                    }
                                }
                                if (asientoDisponible)
                                {
                                    entradaValida = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("El número ingresado no puede ser negativo ni mayor a 1000.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Ingrese un número entero:");
                        }
                    }
                }


                switch (opcion)
                {
                    case "1":
                        parlamento.RegistrarDiputado(partidoPolitico, departamentoSeleccionado, despacho, nombre, apellido, edad, casado, camara);
                        break;
                    case "2":
                        parlamento.RegistrarSenador(partidoPolitico, departamentoSeleccionado, despacho, nombre, apellido, edad, casado, camara);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("¿Cuántos Senadores desea agregar a la Cámara de Senadores de forma aleatoria?");
                        int cantSenadoresAleatorios = 0;
                        entradaValida = false;

                        while (!entradaValida)
                        {
                            entrada = Console.ReadLine();
                            if (int.TryParse(entrada, out cantSenadoresAleatorios))

                            {
                                if (cantSenadoresAleatorios >= 0 && cantSenadoresAleatorios <= 100)
                                {
                                    entradaValida = true;
                                }
                                else
                                {
                                    Console.WriteLine("La cantidad no puede ser menor a 0 ni mayor a 100.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("¿Cuántos Diputados desea agregar a la Cámara de Diputados de forma aleatoria?");
                        int cantDiputadosAleatorios = 0;
                        entradaValida = false;

                        while (!entradaValida)
                        {
                            entrada = Console.ReadLine();
                            if (int.TryParse(entrada, out cantDiputadosAleatorios))

                            {
                                if (cantDiputadosAleatorios >= 0 && cantDiputadosAleatorios <= 100)
                                {
                                    entradaValida = true;
                                }
                                else
                                {
                                    Console.WriteLine("La cantidad no puede ser menor a 0 ni mayor a 100.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                            }
                        }
                        for (int i = 0; i < cantSenadoresAleatorios; i++) 
                        {
                            parlamento.RegistrarSenador(Datos.GetValorAleatorioPartidoPolitico(), Datos.GetValorAleatorioEnDepartamento(), Random.Next(1, 1000), Datos.GetValorAleatorioNombre(), Datos.GetValorAleatorioEnApellido(), Random.Next(35, 100), Datos.GetValorAleatorioCasado(), Random.Next(1, 1000));
                        }

                        for (int i = 0; i < cantDiputadosAleatorios; i++) 
                        {
                            parlamento.RegistrarDiputado(Datos.GetValorAleatorioPartidoPolitico(), Datos.GetValorAleatorioEnDepartamento(), Random.Next(1, 1000), Datos.GetValorAleatorioNombre(), Datos.GetValorAleatorioEnApellido(), Random.Next(35, 100), Datos.GetValorAleatorioCasado(), Random.Next(1, 1000));
                        }
                        break;
                    case "4":
                        parlamento.ListarCamaras(parlamento.GetListaLegisladores());                     
                        parlamento.MostrarCantidadYDetalle(parlamento.GetListaLegisladores());
                        Console.ReadLine();
                        break;
                    case "5":
                        Legislador legisladorSeleccionado = parlamento.ElegirLegislador(parlamento.GetListaLegisladores());

                        string propuestaPresentada = "";
                        if (legisladorSeleccionado is Senador)
                        {
                            Console.WriteLine($"El/La Senador/a {legisladorSeleccionado.getNombre()} {legisladorSeleccionado.getApellido()} presentará la siguiente Propuesta Legislativa:");
                            Console.Write("Ingrese la propuesta: ");
                            propuestaPresentada = Senador.presentarPropuestaLegislativa();
                            Console.WriteLine($"El/la Senador/a {legisladorSeleccionado.getNombre()} {legisladorSeleccionado.getApellido()} presentó la propuesta: {propuestaPresentada}");

                            parlamento.AgregarDatoString(propuestaPresentada);
                            Console.ReadLine();


                        }
                        else if (legisladorSeleccionado is Diputado)
                        {
                            Console.WriteLine($"El/La Diputado/a {legisladorSeleccionado.getNombre()} {legisladorSeleccionado.getApellido()} presentará la siguiente Propuesta Legislativa:");
                            Console.Write("Ingrese la propuesta: ");
                            propuestaPresentada = Diputado.presentarPropuestaLegislativa();
                            Console.WriteLine($"El/la Diputado/a {legisladorSeleccionado.getNombre()} {legisladorSeleccionado.getApellido()} presentó la propuesta: {propuestaPresentada} ");

                            parlamento.AgregarDatoString(propuestaPresentada);
                            Console.ReadLine();
                        }
                        break;
                    case "6":
                        Console.WriteLine("¿Desea que voten todos los legisladores voten o solo uno?");
                        Console.WriteLine("1. Todos \n2. Uno");
                        entradaValida = false;
                        int votoManual = 0;
                        while (!entradaValida)
                        {
                            entrada = Console.ReadLine();

                            if (int.TryParse(entrada, out votoManual))
                            {
                                if (votoManual == 1)
                                {
                                    parlamento.VerPropuestas(parlamento.GetListaPropuestaLegislativa());
                                    Console.WriteLine("");
                                    parlamento.votoLegisladores(parlamento.GetListaLegisladores(), Datos.GetVoto());
                                    Console.ReadLine();
                                    entradaValida = true;
                                }
                                else if (votoManual == 2)
                                {
                                    Legislador legisladorSeleccionado1 = parlamento.ElegirLegislador(parlamento.GetListaLegisladores());

                                    if (legisladorSeleccionado1 is Senador)
                                    {
                                        parlamento.VerPropuestas(parlamento.GetListaPropuestaLegislativa());
                                        Console.WriteLine($"El/La Senador/a {legisladorSeleccionado1.getNombre()} {legisladorSeleccionado1.getApellido()} presentará su voto.");
                                        Console.Write("Ingrese el voto: ");
                                        Senador.Votar();
                                        Console.ReadLine();

                                    }
                                    else if (legisladorSeleccionado1 is Diputado)
                                    {
                                        Console.WriteLine($"El/La Diputado/a {legisladorSeleccionado1.getNombre()} {legisladorSeleccionado1.getApellido()} presentará su voto.");
                                        Console.Write("Ingrese el voto: ");
                                        Diputado.Votar();
                                        Console.ReadLine();
                                    }
                                    entradaValida = true;
                                }
                                else
                                {
                                    Console.WriteLine("El número ingresado no puede ser negativo ni mayor a 2.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Entrada no válida. Ingrese un número entero.");
                            }
                        }                      
                        break;
                    case "7":
                        Legislador legisladorSeleccionado2 = parlamento.ElegirLegislador(parlamento.GetListaLegisladores());

                        if (legisladorSeleccionado2 is Senador)
                        {
                            Console.WriteLine($"El/La Senador/a {legisladorSeleccionado2.getNombre()} {legisladorSeleccionado2.getApellido()} participa del debate.");
                            Console.Write("Ingrese la opinión: ");
                            Senador.ParticiparDebate();
                            Console.ReadLine();
                        }
                        else if (legisladorSeleccionado2 is Diputado)
                        {
                            Console.WriteLine($"El/La Diputado/a {legisladorSeleccionado2.getNombre()} {legisladorSeleccionado2.getApellido()} participa del debate.");
                            Console.Write("Ingrese la opinión: ");
                            Diputado.ParticiparDebate();
                            Console.ReadLine();
                        }
                        break;
                    case "8":
                        //Salir
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;

                }

                if (opcion != "8")
                {
                    Console.Clear();
                    Console.WriteLine("¿Desea realizar otra acción?");
                    Console.WriteLine("1- Ingresar Diputado\n2- Ingresar Senador\n3- Completar Cámaras\n4- Listar Cámaras\n5- Presentar Propuesta Legislativa\n6- Votar\n7- Participar del Debate\n8- Salir");
                    opcion = Console.ReadLine();
                }
            } while (opcion != "8");
        }
    }
}



