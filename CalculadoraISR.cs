using System;

namespace classIRS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flujo();
        }

        public class CalculadoraISR
        {
            public double SueldoBruto { get; }

            public CalculadoraISR(double sueldoBruto)
            {
                SueldoBruto = sueldoBruto;
            }

            public double CalcularAFP()
            {
                return SueldoBruto * 0.0287;
            }

            public double CalcularSFS()
            {
                return SueldoBruto * 0.0304;
            }

            public double CalcularSueldoNetoMensual()
            {
                return SueldoBruto - (CalcularAFP() + CalcularSFS());
            }

            public double CalcularISR()
            {
                double sueldoAnualImponible = CalcularSueldoNetoMensual() * 12;
                double isrAnual = 0;

                if (sueldoAnualImponible <= 416220.00)
                {
                    isrAnual = 0;
                }
                else if (sueldoAnualImponible <= 624329.00)
                {
                    isrAnual = (sueldoAnualImponible - 416220.00) * 0.15;
                }
                else if (sueldoAnualImponible <= 867123.00)
                {
                    isrAnual = 31216.00 + ((sueldoAnualImponible - 624329.00) * 0.20);
                }
                else
                {
                    isrAnual = 79776.00 + ((sueldoAnualImponible - 867123.00) * 0.25);
                }

                return isrAnual / 12;
            }
        }

        public static void Flujo()
        {
            int opcion = 0;
            double sueldoCapturado = 0;
            CalculadoraISR calculadora = null!;
            Console.WriteLine("\nBienvenido a la calculadora de ISR\n");
            Console.Write("Ingrese su sueldo bruto: $");
            sueldoCapturado = double.Parse(Console.ReadLine()!);
            
            if (sueldoCapturado <= 0)
            {
                Console.WriteLine("El sueldo bruto debe ser mayor a cero.");
                return;
            }
            
            calculadora = new CalculadoraISR(sueldoCapturado);

            do
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║           Calculadora ISR 1.0          ║");
                Console.WriteLine("╠════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Sueldo bruto                        ║");
                Console.WriteLine("║ 2. Calculo   AFP/SFS                   ║");
                Console.WriteLine("║ 3. Sueldo neto mensual                 ║");
                Console.WriteLine("║ 4. IRS mensual                         ║");
                Console.WriteLine("║ 5. Resumen de nómina                   ║");
                Console.WriteLine("║ 6. Salir                               ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.Write(" >> Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine()!);

                switch (opcion)
                {
                    case 1:
                        Console.Write($"\nSueldo bruto: ${sueldoCapturado}");
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Write($"\nSueldo Bruto: ${sueldoCapturado}\n");
                        Console.Write("AFP: $");
                        double afp = calculadora.CalcularAFP();
                        Console.WriteLine(afp);
                        Console.Write("SFS: $");
                        double sfs = calculadora.CalcularSFS();
                        Console.WriteLine(sfs);
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine($"\nSueldo Bruto: ${sueldoCapturado}");
                        Console.Write("Sueldo neto mensual: $");
                        double sueldoNetoMensual = calculadora.CalcularSueldoNetoMensual();
                        Console.WriteLine(sueldoNetoMensual);
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine($"\nIRS mensual:  ${calculadora.CalcularISR()}");
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 5:
                        double afp1 = calculadora.CalcularAFP();
                        double sfs1 = calculadora.CalcularSFS();
                        double isr = calculadora.CalcularISR();
                        double netoFinal = calculadora.CalcularSueldoNetoMensual() - isr;

                        Console.WriteLine(" ╔════════════════════════════════════════╗");
                        Console.WriteLine(" ║            RESUMEN DE NÓMINA           ║");
                        Console.WriteLine(" ╠════════════════════════════════════════╣");
                        Console.WriteLine($"║ Sueldo Bruto:${sueldoCapturado,15:F2}  ║");
                        Console.WriteLine($"║ AFP:               ${afp1,15:F2}       ║");
                        Console.WriteLine($"║ SFS:               ${sfs1,15:F2}       ║");
                        Console.WriteLine($"║ IRS:               ${isr,15:F2}        ║");
                        Console.WriteLine(" ╠════════════════════════════════════════╣");
                        Console.WriteLine($"║ Sueldo Neto Final: ${netoFinal,15:F2}  ║");
                        Console.WriteLine(" ╚════════════════════════════════════════╝");
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.WriteLine("Saliendo de la calculadora de impuestos...");
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.WriteLine("\nOprima enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            } while (opcion != 6);
        }
    }
}
