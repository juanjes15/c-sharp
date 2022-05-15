int dist = 0;

Console.WriteLine("Ingrese la distancia en metros");
dist = int.Parse(Console.ReadLine());

if (dist >= 1)
{
    if (dist <= 200)
    {
        Console.WriteLine("Peligro de rayo inminente");
    }
    else if (dist <= 600)
    {
        Console.WriteLine("Riesgo alto de caida de rayo");
    }
    else if (dist <= 800)
    {
        Console.WriteLine("Busque protección");
    }
    else if (dist <= 1200)
    {
        Console.WriteLine("Riesgo bajo de caida de rayo");
    }
    else
    {
        Console.WriteLine("No hay riesgo");
    }
}
else
{
    Console.WriteLine("Distancia no valida");
}