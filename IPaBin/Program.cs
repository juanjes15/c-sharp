int n1 = 0, n2 = 0, n3 = 0, n4 = 0, temp = 0;
string b1 = null, b2 = null, b3 = null, b4 = null;
char clase = 'N';

Console.WriteLine("Ingrese el primer número de la IP");
n1 = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el segundo número de la IP");
n2 = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el tercer número de la IP");
n3 = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el último número de la IP");
n4 = int.Parse(Console.ReadLine());

if ((n1 >= 1 && n1 <= 223) && (n2 >= 0 && n2 <= 255) && (n3 >= 0 && n3 <= 255) && (n4 >= 0 && n4 <= 255))
{
    if (n1 <= 127)
    {
        clase = 'A';
    }
    else if (n1 <= 191)
    {
        clase = 'B';
    }
    else if (n1 <= 223)
    {
        clase = 'C';
    }

    temp = n1;
    for (int i = 0; i < 8; i++)
    {
        b1 = string.Format("{0}{1}", temp % 2, b1);
        temp = temp / 2;
    }

    temp = n2;
    for (int i = 0; i < 8; i++)
    {
        b2 = string.Format("{0}{1}", temp % 2, b2);
        temp = temp / 2;
    }

    temp = n3;
    for (int i = 0; i < 8; i++)
    {
        b3 = string.Format("{0}{1}", temp % 2, b3);
        temp = temp / 2;
    }

    temp = n4;
    for (int i = 0; i < 8; i++)
    {
        b4 = string.Format("{0}{1}", temp % 2, b4);
        temp = temp / 2;
    }
}
else
{
    Console.WriteLine("Número invalido para una IP");
}

Console.WriteLine("La IP es: " + n1 + "." + n2 + "." + n3 + "." + n4);
Console.WriteLine(string.Format("La IP en binario es: {0}.{1}.{2}.{3}", b1, b2, b3, b4));
Console.WriteLine($"Su clasificación es: {clase}");