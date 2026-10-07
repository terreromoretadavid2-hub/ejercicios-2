using System;
using System.Collections.Generic;

namespace Ejercicio3
{
    class Estudiante
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double[] Notas { get; set; }

        public double Promedio
        {
            get
            {
                double suma = 0;
                foreach (double nota in Notas)
                {
                    suma += nota;
                }
                return suma / Notas.Length;
            }
        }

        public string Literal
        {
            get
            {
                double p = Promedio;
                if (p >= 90) return "A";
                if (p >= 80) return "B";
                if (p >= 70) return "C";
                return "F";
            }
        }
    }

    class Program
    {
        static string LeerTexto(string mensaje)
        {
            string texto;
            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine().Trim();
            } while (texto.Length == 0);
            return texto;
        }

        static double LeerNota(string mensaje)
        {
            double nota;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 100)
            {
                Console.Write("Nota invalida (0-100). " + mensaje);
            }
            return nota;
        }

        static bool DeseaContinuar()
        {
            string respuesta;
            do
            {
                Console.Write("Desea ingresar otro estudiante? (S/N): ");
                respuesta = Console.ReadLine().Trim().ToUpper();
            } while (respuesta != "S" && respuesta != "N");
            return respuesta == "S";
        }

        static void MostrarReporte(List<Estudiante> estudiantes)
        {
            estudiantes.Sort((x, y) =>
            {
                int resultado = string.Compare(x.Apellido, y.Apellido, StringComparison.CurrentCultureIgnoreCase);
                if (resultado == 0)
                {
                    resultado = string.Compare(x.Nombre, y.Nombre, StringComparison.CurrentCultureIgnoreCase);
                }
                return resultado;
            });

            int totalA = 0, totalB = 0, totalC = 0, totalReprobados = 0;

            Console.WriteLine();
            Console.WriteLine("Colegio Dios es bueno.");
            Console.WriteLine("Calificaciones del cuatrimestre");
            Console.WriteLine(new string('=', 90));
            Console.WriteLine("{0,-15}{1,-15}{2,7}{3,7}{4,7}{5,7}{6,10}{7,8}",
                "Nombre", "Apellido", "Nota1", "Nota2", "Nota3", "Nota4", "Promedio", "Literal");
            Console.WriteLine(new string('=', 90));

            foreach (Estudiante e in estudiantes)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,7}{3,7}{4,7}{5,7}{6,10:F2}{7,8}",
                    e.Nombre, e.Apellido, e.Notas[0], e.Notas[1], e.Notas[2], e.Notas[3], e.Promedio, e.Literal);

                switch (e.Literal)
                {
                    case "A":
                        totalA++;
                        break;
                    case "B":
                        totalB++;
                        break;
                    case "C":
                        totalC++;
                        break;
                    default:
                        totalReprobados++;
                        break;
                }
            }

            Console.WriteLine(new string('=', 90));
            Console.WriteLine("Estudiantes en A: " + totalA);
            Console.WriteLine("Estudiantes en B: " + totalB);
            Console.WriteLine("Estudiantes en C: " + totalC);
            Console.WriteLine("Estudiantes en Reprobados: " + totalReprobados);
        }

        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine();
                Estudiante e = new Estudiante();
                e.Nombre = LeerTexto("Nombre: ");
                e.Apellido = LeerTexto("Apellido: ");
                e.Notas = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    e.Notas[i] = LeerNota("Nota " + (i + 1) + ": ");
                }
                estudiantes.Add(e);
                continuar = DeseaContinuar();
            }

            MostrarReporte(estudiantes);

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}