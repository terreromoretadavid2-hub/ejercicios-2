using System;
 
namespace Ejercicio1
{
    class Program
    {
        static double LeerNumero(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Valor invalido. " + mensaje);
            }
            return valor;
        }
 
        static string RaizCuadrada(double valor)
        {
            if (valor < 0)
            {
                return "No existe en los numeros reales";
            }
            return Math.Sqrt(valor).ToString();
        }
 
        static void Main(string[] args)
        {
            double a = LeerNumero("Ingrese el primer valor: ");
            double b = LeerNumero("Ingrese el segundo valor: ");
 
            Console.WriteLine();
            Console.WriteLine("Suma: " + (a + b));
            Console.WriteLine("Resta: " + (a - b));
            Console.WriteLine("Multiplicacion: " + (a * b));
 
            if (b == 0)
            {
                Console.WriteLine("Division: No se puede dividir entre cero");
            }
            else
            {
                Console.WriteLine("Division: " + (a / b));
            }
 
            Console.WriteLine("Raiz cuadrada del primer valor: " + RaizCuadrada(a));
            Console.WriteLine("Raiz cuadrada del segundo valor: " + RaizCuadrada(b));
 
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
 