string codigo, fechaNacString, nick, desicion;
string[] listcod = { "abcdef#a$ghijl", "klmnop#k$tuvwx" };
bool error;
DateTime fechaNacDate, fechaActual;
int edad = 0, nivel1 = 0;

do
{
    Console.WriteLine("Ingrese el código de identificación");
    codigo = Console.ReadLine();
    error = validar(codigo);
    if (!error)
    {
        foreach (string item in listcod)
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
} while (error);

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

do
{
    Console.WriteLine("Ya has jugado el juego ADSO I? (Si-No)");
    desicion = Console.ReadLine();
    if (desicion == "Si" || desicion == "Sí" || desicion == "SI" || desicion == "si" || desicion == "sí" || desicion == "SÍ")
    {
        do
        {
            Console.WriteLine("Hasta que nivel llegaste? (1-100)");
            nivel1 = int.Parse(Console.ReadLine());
            if (nivel1 >= 1 && nivel1 <= 100)
            {
                error = false;
            }
            else
            {
                Console.WriteLine("Nivel no existente");
                error = true;
            }
        } while (error);


        if (edad >= 16)
        {
            if (nivel1 == 99)
            {
                nivel1++;
                Console.WriteLine("usted queda en el nivel: " + nivel1);
                error = false;
            }
            else if (nivel1 == 100)
            {
                Console.WriteLine("usted queda en el nivel: " + nivel1);
                error = false;
            }
            else
            {
                nivel1 += 2;
                Console.WriteLine("usted queda en el nivel: " + nivel1);
                error = false;
            }

        }
        else
        {
            Console.WriteLine("usted queda en el nivel: " + nivel1);
        }
    }
    else if (desicion == "no" || desicion == "No" || desicion == "NO" || desicion == "nO")
    {
        if (edad < 16)
        {
            Console.WriteLine("Usted esta en el nivel 2");
        }
        else
        {
            Console.WriteLine("Usted queda en el nivel 1");
        }
    }
    else
    {
        Console.WriteLine("ERROR NO USO SI O NO");
        error = true;
    }
} while (error);

if (edad <= 20)
{
    if (desicion == "no" || desicion == "No" || desicion == "NO" || desicion == "nO")
    {
        Console.WriteLine("Usted queda en el mundo 1");
    }
    else if (desicion == "Si" || desicion == "Sí" || desicion == "SI" || desicion == "si" || desicion == "sí" || desicion == "SÍ")
    {
        if (nivel1 < 50)
        {
            Console.WriteLine("Usted queda en el mundo 2");
        }
        else
        {
            Console.WriteLine("Usted queda en el mundo 3");
        }
    }
}
else
{
    if (desicion == "no" || desicion == "No" || desicion == "NO" || desicion == "nO")
    {
        Console.WriteLine("Usted queda en el mundo 4");
    }
    else if (desicion == "Si" || desicion == "Sí" || desicion == "SI" || desicion == "si" || desicion == "sí" || desicion == "SÍ")
    {
        if (nivel1 < 50)
        {
            Console.WriteLine("Usted queda en el mundo 5");
        }
        else
        {
            Console.WriteLine("Usted queda en el mundo 6");
        }
    }
}

static bool validar(string codigo)
{
    int errores = 0;

    if (codigo.Length == 14)
    {
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