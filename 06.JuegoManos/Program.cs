using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.JuegoManos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Opcion1;
            int Opcion2;
            Console.WriteLine("Programa que simula el juego de manos piedra, papel, tijeras, lagarto, spock.");
            Dictionary<string, string> reglas = ReglasDelJuego();
            do
            {
                Opcion1 = VerificarOpcionValida("¿Quieres jugar? \n 1- Si \n 2- No", new int[] {1,2});
                if (Opcion1 == 2)
                {
                    break;
                }
                Opcion2 = VerificarOpcionValida("¿Cuál será la modalidad del juego? \n 1- Jugador contra Jugador \n 2- Jugador contra Computador \n 3- Computador contra computador", new int[] {1,2,3});              
                switch (Opcion2)
                {
                    case 1:
                        JuegoPvP(reglas);
                        break;
                    case 2:
                        JuegoPvC(reglas);
                        break;
                    case 3:
                        JuegoCvC(reglas);
                        break;
                    default:
                        break;
                }

            } while (Opcion1 != 2);
        }

        static Dictionary<string, string> ReglasDelJuego()
        {
            Dictionary<string, string> reglas = new Dictionary<string, string>()
            {
                { "piedra-tijeras", "gana" },
                { "tijeras-papel", "gana" },
                { "papel-piedra", "gana" },
                { "spock-tijeras", "gana" },
                { "piedra-lagarto", "gana" },
                { "lagarto-spock", "gana" },
                { "tijeras-lagarto", "gana" },
                { "papel-spock", "gana" },
                { "spock-piedra", "gana" },
                { "lagarto-papel", "gana" }
            };
            return reglas;
        }


        static int VerificarOpcionValida(string mensaje ,int[] opcionesValidas)
        {
            int opcion;
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out opcion) && opcionesValidas.Contains(opcion);
                if (!esValido)
                {
                    Console.WriteLine("Carácter inválido, por favor, elige otra opción.");
                }
            }
            while (!esValido);
            return opcion;
        }

        static void JuegoPvP(Dictionary<string, string> reglas)
        {
            try
            {
                Console.WriteLine("Jugador 1, ¿Qué eliges?");
                string eleccionP1 = Console.ReadLine().ToLower();
                Console.WriteLine("Jugador 2, ¿Qué eliges?");
                string eleccionP2 = Console.ReadLine().ToLower();
                if (eleccionP1 == eleccionP2)
                {
                    Console.WriteLine("Empate.");
                }
                else
                {
                    string clave = eleccionP1 + "-" + eleccionP2;
                    string claveInversa = eleccionP2 + "-" + eleccionP1;
                    if (reglas.ContainsKey(clave))
                    {
                        Console.WriteLine("Jugador 1 gana.");
                    }
                    else if (reglas.ContainsKey(claveInversa))
                    {
                        Console.WriteLine("Jugador 2 gana.");
                    }
                    else
                    {
                        Console.WriteLine("¡Error en las reglas!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            Console.ReadLine();
        }

        static void JuegoPvC(Dictionary<string, string> reglas)
        {
            try
            {
                Console.WriteLine("Jugador 1, ¿Qué eliges?");
                string eleccionP1 = Console.ReadLine().ToLower();
                Random random = new Random();
                string eleccionC = reglas.Keys.ElementAt(random.Next(reglas.Count));
                string[] opciones = eleccionC.Split('-');
                string eleccionCo = opciones[0];
                Console.WriteLine("La elección del computador es: " + eleccionCo);
                if (eleccionP1 == eleccionCo)
                {
                    Console.WriteLine("Empate.");
                }
                else
                {
                    string clave = eleccionP1 + "-" + eleccionCo;
                    string claveInversa = eleccionCo + "-" + eleccionP1;                    
                    if (reglas.ContainsKey(clave))
                    {
                        Console.WriteLine("Jugador 1 gana.");
                    }
                    else if (reglas.ContainsKey(claveInversa))
                    {
                        Console.WriteLine("Computador gana.");
                    }
                    else
                    {
                        Console.WriteLine("¡Error en las reglas!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            Console.ReadLine();
        }

        static void JuegoCvC(Dictionary<string, string> reglas)
        {
            try
            {
                Random random = new Random();
                string eleccionC1 = reglas.Keys.ElementAt(random.Next(reglas.Count));
                string eleccionC2 = reglas.Keys.ElementAt(random.Next(reglas.Count));
                string[] opciones1 = eleccionC1.Split('-');
                string eleccionCo1 = opciones1[0];
                string[] opciones2 = eleccionC2.Split('-');
                string eleccionCo2 = opciones2[0];
                Console.WriteLine("La eleeción del computador 1 es: " + eleccionCo1);
                Console.WriteLine("La eleeción del computador 2 es: " + eleccionCo2);
                if (eleccionCo1 == eleccionCo2)
                {
                    Console.WriteLine("Empate.");
                }
                else
                {
                    string clave = eleccionCo1 + "-" + eleccionCo2;
                    string claveInversa = eleccionCo2 + "-" + eleccionCo1;
                    if (reglas.ContainsKey(clave))
                    {
                        Console.WriteLine("Computador 1 gana.");
                    }
                    else if (reglas.ContainsKey(claveInversa))
                    {
                        Console.WriteLine("Computador 2 gana.");
                    }
                    else
                    {
                        Console.WriteLine("¡Error en las reglas!");
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}