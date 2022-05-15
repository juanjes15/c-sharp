int num = 0, num1 = 0, d1 = 0, d2 = 0, d3 = 0;

Console.WriteLine("Ingrese un número de tres dígitos");
num = int.Parse(Console.ReadLine());

d1 = num / 100;
d2 = (num % 100) / 10;
d3 = num % 10;

num1 = d3 * 100 + d2 * 10 + d1;

Console.WriteLine("El número original es: {0} y el nuevo número es: {1}", num, num1);