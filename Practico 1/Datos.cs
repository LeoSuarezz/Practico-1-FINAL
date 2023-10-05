using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    internal class Datos
    {
        private List<string> listaNombres;
        private List<string> listaApellidos;
        private List<string> listaPartidoPolitico;
        private List<string> listaDepartamento;
        private List<bool> listaCasado;
        private List<string> listaVotos;

        public Datos()
        {
            listaNombres = new List<string>();
            listaApellidos = new List<string>();
            listaPartidoPolitico = new List<string>();
            listaDepartamento = new List<string>();
            listaVotos = new List<string>();

            listaDepartamento = new List<string> { "Artigas", "Canelones", "Cerro Largo", "Colonia", "Durazno", "Flores", "Florida", "Lavalleja", 
                "Maldonado", "Montevideo", "Paysandú", "Río Negro", "Rivera", "Rocha", "Salto", "San José", "Soriano", "Tacuarembó", "Treinta y Tres" };
            listaNombres = new List<string> { "María", "Carlos", "Ana", "Pedro", "Laura", "Luis", "Carmen", "Jorge", "Raquel", "Sergio", "Patricia",
                "Miguel", "Isabel", "Alejandro", "Marta", "Daniel", "Carolina", "Pablo", "Sofía", "Oscar", "Gabriela", "Eduardo", "Andrea", "Fernando", 
                "Paula", "Alejandro", "Daniela", "Manuel", "Teresa", "Raúl", "Beatriz", "Mario", "Rosario", "José", "Ana María", "Luis", "Laura", "Carlos",
                "Patricia", "Javier", "Fernanda", "Eduardo", "Mariana", "Alejandro", "Alejandra", "Miguel", "Gabriela", "Manuel", "Valeria", "Pablo", "Fernanda",
                "Juan Carlos", "Sofía", "Antonio", "Andrea", "José Luis", "María", "Javier", "Ana Karen", "Francisco", "Carolina", "Luis", "Daniela", "Juan", 
                "Valentina", "Eduardo", "Mariana", "Alejandro", "Renata", "Raúl", "Jimena", "Mario", "Gabriela", "José", "Ana Paula", "Luis", "Laura", "Carlos",
                "Patricia", "Javier", "Fernanda", "Eduardo", "Mariana", "Alejandro", "Alejandra", "Miguel", "Gabriela", "Manuel", "Valeria", "Pablo", "Fernanda",
                "Juan Carlos", "Sofía", "Antonio", "Andrea", "José Luis", "María" };
            listaApellidos = new List<string> { "García","Rodríguez","López","González","Martínez","Sánchez","Ramírez","Gómez","Torres","Vargas",
                "Jiménez","Castro","Morales","Silva","Ortega","Méndez","Aguilar","Delgado","Paredes","Ríos","Mendoza","Castro","Navarro","Velasco","Rivas","Peña",
                "Cordero","Contreras","Ponce","Morales","Santos","Juárez","Núñez","León","Cervantes","Rangel","Soto","Hernández","Cárdenas","Ibarra","Delgado",
                "Sánchez","Miranda","Guzmán","Valencia","Franco","Vargas","Villarreal","Cordero","Gómez","Castillo","Huerta","Díaz","Guerra","Silva","Cervantes",
                "Ríos","Peña","Cordero","Ibarra","Delgado","Mendoza","Navarro","Velasco","Rivas","Peña","Cordero","Contreras","Ponce","Morales","Santos","Juárez",
                "Núñez","León","Cervantes","Rangel","Soto","Hernández","Cárdenas","Ibarra","Delgado","Sánchez","Miranda","Guzmán","Valencia","Franco","Vargas",
                "Villarreal","Cordero","Gómez","Castillo","Huerta","Díaz","Guerra","Silva","Cervantes","Ríos" };
            listaPartidoPolitico = new List<string> { "Frente Amplio", "Partido Nacional", "Partido Colorado" };
            listaCasado = new List<bool> { true, false };
            listaVotos = new List<string> { "A favor", "En contra" };
        }

        Random Random = new Random();

        public string GetValorAleatorioEnDepartamento()
        {
            int indiceAleatorio = Random.Next(0, listaDepartamento.Count);
            return listaDepartamento[indiceAleatorio];
        }
        public string GetValorAleatorioNombre()
        {
            int indiceAleatorio = Random.Next(0, listaNombres.Count);
            return listaNombres[indiceAleatorio];
        }
        public string GetValorAleatorioEnApellido()
        {
            int indiceAleatorio = Random.Next(0, listaApellidos.Count);
            return listaApellidos[indiceAleatorio];
        }
        public List<string> GetListaPArtidoPolitico()
        {
            return listaPartidoPolitico;
        }
        public string GetValorAleatorioPartidoPolitico()
        {
            int indiceAleatorio = Random.Next(0, listaPartidoPolitico.Count);
            return listaPartidoPolitico[indiceAleatorio];
        }
        public bool GetValorAleatorioCasado()
        {
            int indiceAleatorio = Random.Next(0, listaCasado.Count);
            if (indiceAleatorio == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }
        public List<string> GetListaDepartamento()
        {
            return listaDepartamento;
        }
        public List<string> GetVoto()
        {
            return listaVotos;
        }
    }
}




