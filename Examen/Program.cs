using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>();
            List<Ventas> ventas = new List<Ventas>();

            Seed_Productos(productos);
            Seed_Ventas(ventas);

            Boot_Menu(productos, ventas);
            Fin_Programa();

        }

        

        private static void Seed_Productos(List<Producto> productos)
        {
            Producto producto1 = new Producto() { IdProducto = 01, Nombre = "Pan" };
            Producto producto2 = new Producto() { IdProducto = 02, Nombre = "Arroz" };
            Producto producto3 = new Producto() { IdProducto = 03, Nombre = "Soda" };
            Producto producto4 = new Producto() { IdProducto = 04, Nombre = "Dulce" };

            productos.Add(producto1);
            productos.Add(producto2);
            productos.Add(producto3);
            productos.Add(producto4);
        }

        private static void Seed_Ventas(List<Ventas> ventas)
        {
            Ventas venta1 = new Ventas() { IdProducto = 01, Cantidad = 5 };
            Ventas venta2 = new Ventas() { IdProducto = 02, Cantidad = 10 };
            Ventas venta3 = new Ventas() { IdProducto = 03, Cantidad = 6 };
            Ventas venta4 = new Ventas() { IdProducto = 04, Cantidad = 11 };

            ventas.Add(venta1);
            ventas.Add(venta2);
            ventas.Add(venta3);
            ventas.Add(venta4);
        }

        private static void Fin_Programa()
        {
            Console.Clear();
            Console.WriteLine("Gracias presione 'Enter' para terminar...");
            Console.ReadKey();
        }

        static void Boot_Menu(List<Producto> productos, List<Ventas> ventas)
        {
            Console.Clear();
            Console.WriteLine("Seleccione La Opcion Que Desea Realizar");
            Console.WriteLine("1. Registrar Nuevo Producto");
            Console.WriteLine("2. Registrar Nueva Venta");
            Console.WriteLine("3. Mostrar Registro de Ventas");
            Console.WriteLine("4. Mostrar el Producto mas Vendido");
            Console.WriteLine("5. Salir");

            Switch_1(productos, ventas);
        }

        private static void Switch_1(List<Producto> productos, List<Ventas> ventas)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Registrar_Nuevo_Producto(productos);
                    Menu_2(productos, ventas);
                    break;
                case "2":
                    Registrar_Nueva_Venta(ventas);
                    Menu_2(productos, ventas);
                    break;
                case "3":
                    Mostrar_Lista_De_Productos(productos, ventas);
                    Menu_2(productos, ventas);
                    break;
                case "4":
                    Mostrar_Producto_Mas_Vendido(productos, ventas);
                    Menu_2(productos, ventas);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("\nSeleccion invalida, presione 'enter' para continuar...");
                    Console.ReadKey();
                    Boot_Menu(productos, ventas);
                    break;
            }
        }

        private static void Mostrar_Producto_Mas_Vendido(List<Producto> productos, List<Ventas> ventas)
        {
            Ventas ventaMayor = new Ventas();
            for (int i = 0; i < ventas.Count; i++)
            {
                if (ventaMayor.Cantidad < ventas[i].Cantidad)
                    ventaMayor = ventas[i];
            }
            var producto = (from prod in productos
                            where prod.IdProducto == ventaMayor.IdProducto
                            select prod).FirstOrDefault();
            Console.Clear();
            Console.WriteLine("El producto que se vendio mas fue: {0}", producto.Nombre);
            Console.WriteLine("Con una cantidad de: {0}", ventaMayor.Cantidad);
            Console.WriteLine("\nPresione 'enter' para continuar...");
            Console.ReadKey();
        }

        private static void Menu_2(List<Producto> productos, List<Ventas> ventas)
        {
            Console.Clear();
            Console.WriteLine("1. Volver al menu anterior");
            Console.WriteLine("2. Salir");

            Switch_2(productos, ventas);
        }

        private static void Switch_2(List<Producto> productos, List<Ventas> ventas)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Boot_Menu(productos, ventas);
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("\nSeleccion invalida, presione 'enter' para continuar...");
                    Console.ReadKey();
                    Menu_2(productos, ventas);
                    break;
            }
        }

        private static void Mostrar_Lista_De_Productos(List<Producto> productos, List<Ventas> ventas)
        {
            Console.Clear();
            var ListaQuery = from venta in ventas
                             join producto in productos on venta.IdProducto equals producto.IdProducto
                             select new { Nom = producto.Nombre, Can = venta.Cantidad };

            Console.WriteLine("Producto \tCantidad");

            foreach (var item in ListaQuery)
            {
                Console.WriteLine("{0} \t\t{1}", item.Nom, item.Can);
            }
            Console.WriteLine("\nPresione 'enter' para continuar...");
            Console.ReadKey();
        }

        private static void Registrar_Nueva_Venta(List<Ventas> ventas)
        {
            Console.Clear();
            Console.WriteLine("Ingrese Id de Producto:");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Cantidad Venta:");
            int Cantidad =int.Parse(Console.ReadLine());

            var ventaQuery = (from venta in ventas
                              where venta.IdProducto == ID
                              select venta).FirstOrDefault();

            if(ventaQuery!=null)
            {
                ventaQuery.Vender(Cantidad);
            }
            else
            {
                Ventas venta = new Ventas() { IdProducto = ID, Cantidad = Cantidad };
                ventas.Add(venta);
            }
            Console.WriteLine("\nPresione 'enter' para continuar...");
            Console.ReadKey();
        }

        private static void Registrar_Nuevo_Producto(List<Producto> productos)
        {
            Console.Clear();
            Producto producto = new Producto();
            Console.WriteLine("Ingrese Id de Prodducto:");
            producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre de Producto:");
            producto.Nombre = Console.ReadLine();
            productos.Add(producto);
            Console.WriteLine("\nPresione 'enter' para continuar...");
            Console.ReadKey();
        }
    }
}
