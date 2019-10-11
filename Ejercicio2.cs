using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9
{
    class Ejercicio2
    {
        public static int OpcionMenu;
        public static Dictionary<string, Alumno> DiccionarioAlumno = new Dictionary<string, Alumno>();
        public struct Alumno
        {
            public string carnet;
            public string carrera;
            public string nombre;
            private double CUM;

            public void setCum(double CUM)
            {
                if (CUM >= 0 && CUM < +10)
                {
                    this.CUM = CUM;
                } else
                {

                    this.CUM = 0;
                }
            }

            public double getCum()
            {
                return CUM;
            }
        }

        public static void AgregarAlumno()
        {
            Console.WriteLine("¿Cuántos alumnos ingersará?");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cantidad; i++)
            {
                //Toma todos los datos que se escriban y los agrega al diccionario
                Alumno alumno = new Alumno();
                Console.WriteLine("{0})", i + 1);
                Console.Clear();
                //Se toma variable "alumno" toma el dato que se haya ingresado, luego revisa en el diccionario ya existe el carnet, si existe le seguira pidiendo hasta que ingrese uno que no este en la lista
                do
                {
                    
                    Console.WriteLine("Carnet del alumno:");
                    alumno.carnet = Console.ReadLine();
                    
                    if (DiccionarioAlumno.ContainsKey(alumno.carnet.ToLower()))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Este alumno ya existe en la base de datos");
                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------");
                    }
                } while (DiccionarioAlumno.ContainsKey(alumno.carnet.ToLower()));

                Console.WriteLine("\nNombre del alumno: ");
                alumno.nombre = Console.ReadLine();

                Console.WriteLine("\nCarrera del alumno: ");
                alumno.carrera = Console.ReadLine();

                Console.WriteLine("\nCum del alumno: ");
                alumno.setCum(Convert.ToDouble(Console.ReadLine()));
                //Agrega en la lista todos los datos que se tomaron
                DiccionarioAlumno.Add(alumno.carnet.ToLower(), alumno);
            }
        }

        public static void Menu()
        {
            
            Console.WriteLine("Menu de opciones");
            Console.WriteLine("\n1) Agregar datos.");
            Console.WriteLine("\n2) Mostrar alumnos.");
            Console.WriteLine("\n3) Eliminar alumno.");
            Console.WriteLine("\n4) Buscar alumno.");
            Console.WriteLine("\n5) Vaciar diccionario.");
            Console.WriteLine("\n6) Agregar datos.\n");
            OpcionMenu = Convert.ToInt32(Console.ReadLine());
        }

        public static void EliminarAlumno()
        {
            //Toma el dato del alumno que desea eliminar y lo agrega a la lista 
            string Eliminar;
            Console.WriteLine("Ingrese el carnet del alumno que desea eliminar");
            Eliminar = Console.ReadLine();
            //Primero compara si ese dato ya ha sido agregado por la variable "alumno"
            if (DiccionarioAlumno.ContainsKey(Eliminar.ToLower())) 
            {
                //Si esta en la lista lo quita
                DiccionarioAlumno.Remove(Eliminar.ToLower());
            }
            else
            {
                Console.WriteLine("\nEste alumno no se encuentra en la base de datos");
            }
            
        }

        public static void MostrarAlumno()
        {
            
            foreach (KeyValuePair<string, Alumno> datos in DiccionarioAlumno)
            {
                
                Alumno alumno = datos.Value;
                Console.WriteLine("---------------------");
                Console.WriteLine("Datos del alumno:");
                Console.WriteLine("---------------------");
                Console.WriteLine("\nCarten del alumno: {0} ", alumno.carnet);
                Console.WriteLine("\nNombre del alumno: {0} ", alumno.nombre);
                Console.WriteLine("\nCarrerar del alumno: {0} ", alumno.carrera);
                Console.WriteLine("\nCum del alumno: {0} ", alumno.getCum());
                Console.WriteLine("");
            }
            
        }

        public static void BuscarAlumno()
        {

            Console.Clear();
            
            Console.WriteLine("El carnet del alumno que esta buscando");
            //La variable alumno toma el dato del carnet
            string alumno = Console.ReadLine();
            alumno.ToLower();
            //Con el carnet que se ingreso el "ContainsKey" recorre el diccionario buscando ese dato, si existe le dira que si esta en el diccionario, si no lo encuentra le dira que no se encuentra guardado
            if (DiccionarioAlumno.ContainsKey(alumno.ToLower()))
            {
                
                Console.WriteLine("------------------------------------------");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("El alumno se encuentra en la lista.");
                Console.ResetColor();
                Console.WriteLine("------------------------------------------");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("------------------------------------------");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("El alumno no se encuentra en la lista.");
                Console.ResetColor();
                Console.WriteLine("------------------------------------------");
                Console.ResetColor();
            }

        }

        public static void OpcionesMenu()
        {
            Console.Clear();
            switch (OpcionMenu)
            {
                case 1:
                    AgregarAlumno();
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 2:
                    MostrarAlumno();
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;
                case 3:
                    EliminarAlumno();
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 4:
                    BuscarAlumno();
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 5:
                    Console.WriteLine("La lista ha sido vaciada con exito.");
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    DiccionarioAlumno.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 6:
                    Console.Clear();
                    Console.WriteLine("Presionoe <ENTER> para salir.");
                    break;

                default:
                    Console.WriteLine("Esa opcion no se encuetra en el menu");
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;
            }
        }
        

        static void Main(string[] args)
        {
            Menu();
            OpcionesMenu();
            
        }
    }
}
