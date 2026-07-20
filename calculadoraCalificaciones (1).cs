using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Estudiante[] estudiantes = new Estudiante[100];
        int contador = 0;
        string respuesta;

        Console.WriteLine("\n===============SISTEMA DE CALIFICACIÓN NOTAS=================");
        do
        {
            Console.WriteLine("\n--- Estudiante #" + (contador + 1) + " ---");


            Estudiante e = new Estudiante();

            Console.Write("Ingrese el nombre: ");
            e.nombre = Console.ReadLine();

            // Pedimos las 4 notas
            Console.Write("Ingrese Nota 1: ");
            e.nota1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese Nota 2: ");
            e.nota2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese Nota 3: ");
            e.nota3 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese Nota 4: ");
            e.nota4 = Convert.ToDouble(Console.ReadLine());

            e.CalcularPromedio();
            e.DeterminarEstatus();

       
            estudiantes[contador] = e;
            contador++;

            Console.Write("\n¿Desea agregar otro estudiante? S/N: ");
            respuesta = Console.ReadLine();

        } while (respuesta == "S" || respuesta == "s");


        MostrarResultados(estudiantes, contador);

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
    static void MostrarResultados(Estudiante[] lista, int total)
    {
        Console.Clear();
        Console.WriteLine("\n======================== RESULTADOS ===========================");
        Console.WriteLine("Estudiante\tN1\tN2\tN3\tN4\tProm\tEstatus");
        Console.WriteLine("---------------------------------------------------------------");


        for (int i = 0; i < total; i++)
        {
            Console.Write(lista[i].nombre + "\t");
            Console.Write(lista[i].nota1 + "\t");
            Console.Write(lista[i].nota2 + "\t");
            Console.Write(lista[i].nota3 + "\t");
            Console.Write(lista[i].nota4 + "\t");
            Console.Write(lista[i].promedio.ToString("F2") + "\t");
            Console.WriteLine(lista[i].estatus);
        }
    }
}

class Estudiante
{
    public string nombre;
    public double nota1;
    public double nota2;
    public double nota3;
    public double nota4;
    public double promedio;
    public string estatus;

    public void CalcularPromedio()
    {
        promedio = (nota1 + nota2 + nota3 + nota4) / 4;
    }

    public void DeterminarEstatus()
    {
        if (promedio >= 70)
        {
            estatus = "Aprobado";
        }
        else
        {
            estatus = "Reprobado";
        }
    }
}