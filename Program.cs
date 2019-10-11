using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9
{
    class Program
    {
        public static string nombre;
        public static List<string> ListaProductos = new List<string>();
        public static int Opcion;
        //Leer Datos
        public static void TomarLista()
        {
            Console.WriteLine("Cuantos productos ingresara en la lista");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("\n{0}) \nNombre del producto:", i + 1);
                nombre = Console.ReadLine();
                ListaProductos.Add(nombre);
            }
        }
        //Imprimir Datos
        public static void MostrarLista()
        {
          

            foreach (string Producto in ListaProductos)
            {
                int indice = 0;
                Console.WriteLine("\n{0}) {1}", indice +1, Producto);
            }
        }

        public static void AgregarNuevosDatos()
        {
            int Posicion;
            string ProductoNuevo;
            Console.WriteLine("Ingrese la posicion del nuevo producto");
            Posicion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo producto");
            ProductoNuevo = Console.ReadLine();
            ListaProductos.Insert(Posicion, ProductoNuevo);
        }

        public static void EliminarDato()
        {
            Console.Clear();
            int Posicion;
            Console.WriteLine("Ingrese el numero de la fruta que desea eliminar");
            Posicion = Convert.ToInt32(Console.ReadLine());

            ListaProductos.RemoveAt(Posicion);
            Console.Clear();    
        }

        public static void BuscarDato()
        {

            Console.Clear();
            string Producto;
            Console.WriteLine("Ingrese la fruta que desea buscar");
            Producto = Console.ReadLine();
            Producto.ToLower();
            if (ListaProductos.Contains(Producto.ToLower()))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("La fruta se encuentra en la lista.");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("La fruta no se encuentra en la lista.");
                Console.ResetColor();
            }
            
        }

        public static void VaciarLista()
        {
           
            ListaProductos.Clear();
        }

        public static void Menu()
        {
            Console.WriteLine("Menu de opciones: ");
            Console.WriteLine("\n1) Agregar datos. ");
            Console.WriteLine("\n2) Mostrar lista. ");
            Console.WriteLine("\n3) Insertar nuevo producto. ");
            Console.WriteLine("\n4) Eliminar de la lista. ");
            Console.WriteLine("\n5) Buscar en la lista. ");
            Console.WriteLine("\n6) Vaciar lista. ");
            Console.WriteLine("\n7) Salir. ");
            Console.WriteLine("");
            Opcion = Convert.ToInt32(Console.ReadLine());
        }
        public static void OpcionesMenu()
        {
            Console.Clear();
            switch (Opcion)
            {
                case 1:
                    TomarLista();
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 2:
                    
                    MostrarLista();
                    Console.WriteLine("Presione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    
                    break;
                case 3:
                    AgregarNuevosDatos();
                    Menu();
                    OpcionesMenu();
                    break;

                case 4:
                    EliminarDato();
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 5:
                    BuscarDato();
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    Menu();
                    OpcionesMenu();
                    break;

                case 6:
                    Console.WriteLine("La lista ha sido vaciada con exito.");
                    Console.WriteLine("\nPresione <ENTER> para volver al menu.");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.Clear();
                    VaciarLista();
                    Menu();
                    OpcionesMenu();
                    break;

                case 7:
                    Console.Clear();
                    Console.WriteLine("Presionoe <ENTER> para salir.");
                    Console.ReadKey();
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
