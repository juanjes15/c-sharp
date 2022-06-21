string codigo, fechaNacString, nick; //variable donde guardamos el código ingresado por el usuario
string[] listcod = { "abcdef#a$ghijl", "klmnop#k$tuvwx" }; //Lista de códigos ya registrados en el sistema (por el administrador)
bool error; //booleano para guardar si hay errores o no hay errores
DateTime fechaNacDate, fechaActual;
int edad;

do //ciclo que va a repetirse hasta que se cumplan las condiciones
{
    Console.WriteLine("Ingrese el código de identificación");
    codigo = Console.ReadLine();
    error = validar(codigo); //llamamos a la función validar, retorna verdadero (que hay errores), falso (no hay errores)
    if (!error) //si no hay errores
    {
        foreach (string item in listcod) //bucle para comparar el código ingresado con los ya registrados en el sistema
        {
            if (item == codigo)
            {
                Console.WriteLine("ERROR: El código ya está registrado en el sistema");
                error = true;
            }
        }
    }
    if (!error)
    {
        Console.WriteLine("Ingrese la fecha de nacimiento en formato AAAA/MM/DD");
        fechaNacString = Console.ReadLine();
        fechaNacDate = DateTime.ParseExact(fechaNacString, "yyyy/MM/dd", null);
        fechaActual = DateTime.Now;
        edad = fechaActual.Year - fechaNacDate.Year;
        if (fechaNacDate.AddYears(edad) > fechaActual)
        {
            edad--;
        }
        if (edad <= 12)
        {
            Console.WriteLine("ERROR: Este juego es para mayores de 12 años");
            error = true;
        }
    }
} while (error); //si verdadero (hay errores) se repite el ciclo, si es falso sale del ciclo

do
{
    Console.WriteLine("Ingrese un nickname (o alias de jugador)");
    nick = Console.ReadLine();
    if (nick.Length >= 4 && nick.Length <= 6 && !nick.Contains(" "))
    {
        error = false;
    }
    else
    {
        Console.WriteLine("ERROR: El nick debe estar entre 4 a 6 caracteres y no contener espacios");
        error = true;
    }
} while (error);

static bool validar(string codigo) //Función que va a revisar si el código ingresado cumple los requerimientos
{
    int errores = 0; //variable que va a contar el número de errores que se vayan encontrando

    //IMPORTANTE: Algunos condicionales estan negados (con !) ya que nos interesa es saber directamente si hay error
    //entonces podemos validar la condicion, negarla y poner lo que queremos hacer en caso de error

    if (codigo.Length == 14) //Para saber si codigo tiene 14 caracteres
    {
        //Los siguientes dos condicionales solo se evaluan si el código tiene 14 caracteres (por eso están anidados), ya que si no
        //es así y por ejemplo es un string de 2 caracteres, podemos estar pidiendole al sistema que acceda a la posición 8 o 7
        //y esto nos va a dar error (accediendo a memoria inexistente)
        if (!(codigo[codigo.Length - 8] == '#')) //Condicional que pregunta si en la posición 7 NO está #
        {
            Console.WriteLine("ERROR: El caracter en la posición 7 debe ser #");
            errores++;
        }
        if (!(codigo[codigo.Length - 7] == codigo[codigo.Length - 14])) //Se pregunta si el caracter 1 y 8 NO son iguales
        {
            Console.WriteLine("ERROR: El caracter en la primera y octava posición deben ser iguales");
            errores++;
        }
    }
    else //si el codigo NO tiene 14 caracteres
    {
        Console.WriteLine("ERROR: El código debe ser de 14 caracteres");
        errores++;
    }
    if (codigo.Any(char.IsDigit)) //si el codigo tiene algun numero
    {
        Console.WriteLine("ERROR: El código NO debe contener números");
        errores++;
    }
    if (!(codigo.Contains("$"))) //si el codigo NO contiene $
    {
        Console.WriteLine("ERROR: El código debe contener el caracter $");
        errores++;
    }
    string[] cantp; //lineas para contar cuantas p hay en codigo
    cantp = codigo.Split("p");
    if (!(cantp.Length - 1 <= 4)) //si en codigo hay 5 o más p
    {
        Console.WriteLine("ERROR: El código NO debe contener más de 4 veces la letra p");
        errores++;
    }

    if (errores != 0) //si hay errores
    {
        Console.WriteLine("Revisa el código, hay " + errores + " errores");
        return true;
    }
    else //si no hay errores
    {
        return false;
    }
}