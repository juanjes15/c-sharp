menu();

static void menu()
{
    Console.WriteLine("=====MENU DE OPCIONES=====");
    Console.WriteLine();
    Console.WriteLine("1. Llenar un vector");
    Console.WriteLine("2. Imprimir vector");
    Console.WriteLine("3. Menor elemento vector");
    Console.WriteLine("4. Mayor elemento vector");
    Console.WriteLine("5. Sumar elementos vector");
    Console.WriteLine("6. Convertir binario a decimal");
    Console.WriteLine("7. Convertir decimal a binario");
    Console.WriteLine("8. Salir");
    Console.WriteLine();
    Console.WriteLine("Ingrese una opcion: ");
    op = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            llenarvector();
            break;
        case 2:
            imprimirvector();
            break;
        case 3:
            menorelementovector();
            break;
        case 4:
            mayorelementovector();
            break;
        case 5:
            sumarelementosvector();
            break;
        case 6:
            binariodecimal();
            break;
        case 7:
            decimalbinario();
            break;
        case 8:
            salir();
            break;
        default:
            Console.WriteLine("Ingrese una opcion valida...");
            limpiar();
            menu();
            break;
    }
}
static void llenarvector()
{
    cont++;
    Console.WriteLine("Ingrese el tamaño del vector");
    int tam = int.Parse(Console.ReadLine());
    vect = new int[tam];
    for (int i = 0; i < vect.Length; i++)
    {
        Console.WriteLine("Ingrese el valor de la posicion " + i);
        vect[i] = int.Parse(Console.ReadLine());
    }
    imprimirvector();
    if (op == 1)
    {
        menu();
    }
}
static void imprimirvector()
{
    if (cont == 0)
    {
        llenarvector();
    }
    Console.WriteLine();
    for (int i = 0; i < vect.Length; i++)
    {
        Console.WriteLine(vect[i]);
    }
    limpiar();
    if (op == 2)
    {
        menu();
    }
}
static void menorelementovector()
{
    llenarvector();
    int menor = vect[0];
    for (int i = 0; i < vect.Length; i++)
    {
        if (vect[i] < menor)
        {
            menor = vect[i];
        }
    }
    Console.WriteLine("El menor elemento del vector es: " + menor);
    limpiar();
    menu();
}
static void mayorelementovector()
{
    llenarvector();
    int mayor = vect[0];
    for (int i = 0; i < vect.Length; i++)
    {
        if (vect[i] > mayor)
        {
            mayor = vect[i];
        }
    }
    Console.WriteLine("El mayor elemento del vector es: " + mayor);
    limpiar();
    menu();
}
static void sumarelementosvector()
{
    llenarvector();
    int suma = 0;
    for (int i = 0; i < vect.Length; i++)
    {
        suma += vect[i];
    }
    Console.WriteLine("La suma de los elementos del vector es: " + suma);
    limpiar();
    menu();
}
static void binariodecimal()
{
    decimalbinario();
    for (int i = 0; i < vects.Length; i++)
    {
        vect[i] = Convert.ToInt32(vects[i], 2);
        Console.WriteLine(vects[i] + " = " + vect[i]);
    }
    limpiar();
    menu();
}
static void decimalbinario()
{
    llenarvector();
    vects = new string[vect.Length];
    for (int i = 0; i < vect.Length; i++)
    {
        vects[i] = Convert.ToString(vect[i], 2);
        Console.WriteLine(vect[i] + " = " + vects[i]);
    }
    limpiar();
    if (op == 7)
    {
        menu();
    }
}
static void salir()
{

}
static void limpiar()
{
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadLine();
    Console.Clear();
}

public partial class Program
{
    public static int[] vect;
    public static string[] vects;
    public static int cont = 0;
    public static int op = 0;
}