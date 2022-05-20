int hora = 0, min = 0, dist = 0;
int mint = 0, res = 0;

Console.WriteLine("Ingrese las horas");
hora = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese los minutos");
min = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese la distancia");
dist = int.Parse(Console.ReadLine());

mint = (hora * 60) + min;
res = (int)(dist / mint);

Console.WriteLine("El tiempo medio es: " + res);