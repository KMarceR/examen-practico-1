using System.Data;


//Declaracion de variables
bool continuar = true;
int opcion = 0;
double[,] tablaPrecios = {
            {12, 2},
            {15, 2.2},
            {18, 4.5},
            {19, 3.5},
            {23, 6}
        };


string[][] tablaLibros = new string[][]
{
    new string[] {"libro 1", "9783161484100", "03-09-2023", "autor"},
    new string[] {"libro 2", "9783161484100", "03-09-2023", "autor"},
    new string[] {"libro 3", "9783161484100", "03-09-2023", "autor"}
};
int[] tablaCodigoLibros = { 1, 2, 3 };




// menu principal
while (continuar)
{
    Console.WriteLine("----------------------- PRIMER EXAMEN PRACTICO -----------------------");
    Console.WriteLine("1. Ver Ejercicio 1");
    Console.WriteLine("2. Ver Ejercicio 2");
    Console.WriteLine("3. Salir");
    Console.Write("Elija una opción: ");

    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            AdministrarCostoLlamada();
            break;
        case 2:
            AdministrarBiblioteca();
            break;
        case 3:
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
            break;
    }
}

// metodo que administra el primer ejercicio
void AdministrarCostoLlamada()
{
    Console.Clear();
    Console.WriteLine("-----------------------  Calculo de costos para llamadas Internacionales -----------------------");

    while (continuar)
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("1. Calcular costo de llamada");
        Console.WriteLine("2. Salir");
        Console.Write("Elija una opción: ");

        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                CalcularCostoLlamada();
                break;
            case 2:
                continuar = false;
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                break;
        }
    }
}

// metodo que calcula el costo de la llamada internacional
void CalcularCostoLlamada()
{
    Console.Clear();
    Console.WriteLine("Ingrese la clave de la zona: ");
    Console.WriteLine("12: América del norte, 15: América central, 18: América del sur, 19: Europa, 23: Asia");
    int claveZona = int.Parse(Console.ReadLine());

    double precioPorMinuto = -1;
    for (int i = 0; i < tablaPrecios.GetLength(0); i++)
    {
        if (claveZona == tablaPrecios[i, 0])
        {
            precioPorMinuto = tablaPrecios[i, 1];
            break;
        }
    }

    if (precioPorMinuto != -1)
    {
        Console.WriteLine("Ingrese el número de minutos hablados: ");
        double minutosHablados = double.Parse(Console.ReadLine());

        double costoTotal = precioPorMinuto * minutosHablados;

        Console.WriteLine($"El costo de la llamada es: ${costoTotal}");
    }
    else
    {
        Console.WriteLine("Clave de zona no válida. Por favor, ingrese una clave válida.");
    }
}



//metodo que administra el segundo ejercicio 
void AdministrarBiblioteca()
{
    Console.Clear();
    Console.WriteLine("-----------------------  Sistema de biblioteca -----------------------");

    while (continuar)
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("1. Agregar un libro");
        Console.WriteLine("2. Ver listado de libros");
        Console.WriteLine("3. Buscar libro por codigo");
        Console.WriteLine("4. Salir");
        Console.Write("Elija una opción: ");

        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                AgregarLibro();
                break;
            case 2:
                VerLibro();
                break;
            case 3:
                BuscarLibroPorCodigo();
                break;
            case 4:
                continuar = false;
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                break;
        }
    }
}

//metodo que agrega la libros a la biblioteca
void AgregarLibro()
{
    Console.Clear();
    Console.WriteLine("-----------------------  Agregar nuevo libro -----------------------");
    Console.Write("Ingrese el título del libro: ");
    string titulo = Console.ReadLine();
    Console.Write("Ingrese el ISBN: ");
    string isbn = Console.ReadLine();
    Console.Write("Ingrese la fecha de edicion (dd-MM-yyyy): ");
    string fecha = Console.ReadLine();
    Console.Write("Ingrese el autor: ");
    string autor = Console.ReadLine();

    int nuevoCodigo = tablaCodigoLibros.Max() + 1;



    Array.Resize(ref tablaLibros, tablaLibros.Length + 1);
    tablaLibros[tablaLibros.Length - 1] = new string[] { titulo, isbn, fecha, autor };

    Array.Resize(ref tablaCodigoLibros, tablaCodigoLibros.Length + 1);
    tablaCodigoLibros[tablaCodigoLibros.Length - 1] = nuevoCodigo;

    Console.WriteLine($"Libro agregado con código {nuevoCodigo}.");
}

//metodo que permite ver la biblioteca
void VerLibro()
{
    Console.Clear();
    Console.WriteLine("-----------------------  Lista de libros -----------------------");
    //                  -12345678901234567890---12345678901234567890---12345678901234---12345678901---1234567890--
    Console.WriteLine("+----------------------+----------------------+----------------+-------------+------------+");
    Console.WriteLine("| Código               | Título               | ISBN           | Fecha       | Autor      |");
    Console.WriteLine("+----------------------+----------------------+----------------+-------------+------------+");
    Console.WriteLine("+----------------------+----------------------+----------------+-------------+------------+");

    for (int i = 0; i < tablaCodigoLibros.Length && i < tablaLibros.Length; i++)
    {
        string[] libro = tablaLibros[i];
        Console.WriteLine($"| {ImprimirItemTable(tablaCodigoLibros[i].ToString(), 20)} | {ImprimirItemTable(libro[0], 20)} | {ImprimirItemTable(libro[1], 14)} | {ImprimirItemTable(libro[2], 11)} | {ImprimirItemTable(libro[3], 10)} |");
        Console.WriteLine("+----------------------+----------------------+----------------+-------------+------------+");
    }
}

//metodo que imprimir tabla
string ImprimirItemTable(string text, int length)
{
    return text.Length <= length
      ? text.PadRight(length, ' ')
      : (text.Substring(0, length - 3) + "...");
}


//metodo que permite buscarun libro por codigo de la biblioteca
void BuscarLibroPorCodigo()
{
    Console.Clear();
    Console.WriteLine("-----------------------  Buscar libro -----------------------");
    Console.Write("Ingrese el código del libro a buscar: ");
    int codigo = int.Parse(Console.ReadLine());



    int indice = Array.IndexOf(tablaCodigoLibros, codigo);

    if (indice != -1)
    {
        Console.WriteLine("Información del libro encontrado:");
        Console.WriteLine($"Código: {codigo}");
        Console.WriteLine($"Título: {tablaLibros[indice][0]}");
        Console.WriteLine($"ISBN: {tablaLibros[indice][1]}");
        Console.WriteLine($"Fecha: {tablaLibros[indice][2]}");
        Console.WriteLine($"Autor: {tablaLibros[indice][3]}");
    }
    else
    {
        Console.WriteLine("Código de libro no encontrado.");
    }
}
