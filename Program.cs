int[] n = new int[4];
string[] b = new string[4];
char clase = 'N';
int temp;

for (int i = 0; i < n.Length; i++)
{
    Console.WriteLine("Ingrese el número " + (i + 1) + " de la IP");
    n[i] = int.Parse(Console.ReadLine());
}

if ((n[0] >= 1 && n[0] <= 223) && (n[1] >= 0 && n[1] <= 255) && (n[2] >= 0 && n[2] <= 255) && (n[3] >= 0 && n[3] <= 255))
{
    if (n[0] <= 127)
    {
        clase = 'A';
    }
    else if (n[0] <= 191)
    {
        clase = 'B';
    }
    else if (n[0] <= 223)
    {
        clase = 'C';
    }

    for (int i = 0; i < b.Length; i++)
    {
        temp = n[i];
        for (int j = 0; j < 8; j++)
        {
            b[i] = string.Format("{0}{1}", temp % 2, b[i]);
            temp = temp / 2;
        }
    }
}
else
{
    Console.WriteLine("Número invalido para una IP");
}

Console.WriteLine("La IP es: " + n[0] + "." + n[1] + "." + n[2] + "." + n[3]);
Console.WriteLine(string.Format("La IP en binario es: {0}.{1}.{2}.{3}", b[0], b[1], b[2], b[3]));
Console.WriteLine($"Su clasificación es: {clase}");