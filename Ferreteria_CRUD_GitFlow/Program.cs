/* Yostin S. Sanchez Rosario
 Matricula: 2024-1722 */

/*NOTA: Maestro, no es escusa solo queria informarle que el github me daba erroes a la hora de subir el codigo a otras ramas,
solo me dejo subir dos. Subire el codigo completo en la rama "main" y me abstengo a las consecuencias de no aplicar 
la metodologia Git Flow correctamente.*/

namespace CRUD_Ferreteria
{
    class Program
    {
        class Product
        {
            public string nombre;
            public string descripcion;
            public int cantidad;
            public double precio;

            private static List<Product> inventario = new List<Product>();

            public Product(string nombre, string descripcion, int cantidad, double precio)
            {
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.cantidad = cantidad;
                this.precio = precio;
            }

            public static void AddProduct()
            {
                Console.WriteLine("Ingrese el nombre del producto:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la descripcion del producto:");
                string descripcion = Console.ReadLine();

                Console.WriteLine("Ingrese la cantidad del producto:");
                int cantidad = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el precio del producto:");
                double precio = double.Parse(Console.ReadLine());

                Product newProduct = new Product(nombre, descripcion, cantidad, precio);
                inventario.Add(newProduct);
                Console.WriteLine("Producto agregado exitosamente.");
            }

            public static void ViewProduct()
            {
                Console.WriteLine("\n--- Lista de Productos ---");
                if (inventario.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                int index = 1;
                foreach (var p in inventario)
                {
                    Console.WriteLine($"{index}. Nombre: {p.nombre} | Descripción: {p.descripcion} | Cantidad: {p.cantidad} | Precio: {p.precio:C}");
                    index++;
                }

            }

            public static void UpdateProduct()
            {
                if (inventario.Count == 0)
                {
                    Console.WriteLine("No hay productos para actualizar.");
                    return;
                }

                ViewProduct();
                Console.WriteLine("\nIngrese el número del producto que desea actualizar:");
                int index = 0;
                index = int.Parse(Console.ReadLine());

                if (index < 1 || index > inventario.Count)
                {
                    Console.WriteLine("Numero incorrecto.");
                    return;
                }
                if (index == null) {
                    Console.WriteLine("No se aceptan valores nulos");
                }

                    var producto = inventario[index - 1];

                Console.WriteLine($"Editando producto: {producto.nombre}");
                Console.WriteLine("Ingrese el nuevo nombre (o presione Enter para mantener):");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre)) producto.nombre = nuevoNombre;

                Console.WriteLine("Ingrese la nueva descripción (o Enter para mantener):");
                string nuevaDescripcion = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevaDescripcion)) producto.descripcion = nuevaDescripcion;

                Console.WriteLine("Ingrese la nueva cantidad (o Enter para mantener):");
                string nuevaCantidad = Console.ReadLine();
                if (int.TryParse(nuevaCantidad, out int cant)) producto.cantidad = cant;

                Console.WriteLine("Ingrese el nuevo precio (o Enter para mantener el anterior):");
                string nuevoPrecio = Console.ReadLine();
                if (double.TryParse(nuevoPrecio, out double pre)) producto.precio = pre;

                Console.WriteLine("Producto actualizado correctamente.");
            }

            public static void DeleteProduct()
            {
                if (inventario.Count == 0)
                {
                    Console.WriteLine("No hay productos para eliminar.");
                    return;
                }

                Console.WriteLine("\n--------------------------------------------------------------------------");
                ViewProduct();
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("\nIngrese el número del producto que desea eliminar:");
                Console.WriteLine("--------------------------------------------------------------------------");
                int index = int.Parse(Console.ReadLine());

                if (index < 1 || index > inventario.Count)
                {
                    Console.WriteLine("\n--------------------------------------------------------------------------");
                    Console.WriteLine("Numero invalido.");
                    return;
                }

                var producto = inventario[index - 1];
                inventario.RemoveAt(index - 1);
                Console.WriteLine($"Producto '{producto.nombre}' eliminado correctamente.");
            }


        }
        private static void home_screen()
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("\n--------------------------------------------------------------------------");
                Console.WriteLine("                        Bienvenido a la Ferreteria  ");
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("| 1. Ingresar nuevo producto | 2. Ver productos | 3. Actualizar producto |");
                Console.WriteLine("|   4. Eliminar producto     | 5. Leer manual   |        6. Salir        |");
                Console.WriteLine("Seleccione una opcion (1-6): ");
                Console.WriteLine("--------------------------------------------------------------------------");

                int answer;
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    switch (answer)
                    {
                        case 0: 
                            
                            Console.WriteLine("Opcion invalida.");
                            break;
                        case 1:

                            Product.AddProduct();
                            break;
                        case 2:

                            Product.ViewProduct();
                            break;
                        case 3:

                            Product.UpdateProduct();
                            break;
                        case 4:

                            Product.DeleteProduct();
                            break;
                        case 5:

                            manual();
                            break;
                        case 6:

                            Console.WriteLine("Cerrando programa......");
                            exit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada invalida. Por favor ingresa un numero.");
                }

            }



        }
        private static void manual()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                             Manual de Usuario:");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Debe de responder solo con numeros enteros en el menu principal.");
            Console.WriteLine("1. Ingresar nuevo producto: Permite agregar un nuevo producto a la base de datos.");
            Console.WriteLine("2. Ver productos: Muestra una lista de todos los productos disponibles.");
            Console.WriteLine("3. Actualizar producto: Permite modificar la información de un producto existente.");
            Console.WriteLine("4. Eliminar producto: Permite eliminar un producto de la base de datos.");
            Console.WriteLine("5. Leer manual: Muestra este manual de usuario.");
            Console.WriteLine("6. Salir: Cierra la aplicación.");
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        static void Main(string[] args)
        {
            home_screen();


            Console.ReadKey();
        }


    }

}
