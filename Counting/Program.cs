using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Counting
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sv = new Stopwatch();
            sv.Start();
            Console.WriteLine("Ingresa El Rango De Numeros: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Random r = new Random();
            StreamWriter sw = new StreamWriter("D:\\sample.txt");
            for (int i = 0; i < num; i++)
            {
                sw.WriteLine(r.Next(-1000,999 ));
            }
            Console.WriteLine("Datos Guadados En EL Archivo De Texto");
            sw.Close();
            sv.Stop();
            Console.WriteLine("Tiempo De Ejecucion Para Guardar Datos: {0}", sv.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));
            bool salir = false;

            while (!salir)
            {

                Console.WriteLine("1. Abir Documento De Texto");
                Console.WriteLine("2. Ordenar Datos");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Has elegido la opción 1");
                        break;

                    case 2:
                        Console.WriteLine("Has elegido la opción 2");
                        Stopwatch sb = new Stopwatch();
                        sv.Start();
                        List<int> numList = new List<int>();
                        
                        StreamReader sr = new StreamReader("D:\\sample.txt");
                        {
                            while (!sr.EndOfStream)
                            {
                                int x = Convert.ToInt32(sr.ReadLine());
                                numList.Add(x);
                            }
                        }
                        Console.WriteLine("\n" + "Array Original :");
                        foreach (int aa in numList)
                            Console.Write(aa + " ");

                        int[] sortednumList = new int[numList.Count];
                        int minVal = numList[0];
                        int maxVal = numList[0];
                        for (int i = 1; i < numList.Count; i++)
                        {
                            if (numList[i] < minVal) minVal = numList[i];
                            else if (numList[i] > maxVal) maxVal = numList[i];
                        }
                        int[] counts = new int[maxVal - minVal + 1];
                        for (int i = 0; i < numList.Count; i++)
                        {
                            counts[numList[i] - minVal]++;
                        }
                        counts[0]--;
                        for (int i = 1; i < counts.Length; i++)
                        {
                            counts[i] = counts[i] + counts[i - 1];
                        }
                        for (int i = numList.Count - 1; i >= 0; i--)
                        {
                            sortednumList[counts[numList[i] - minVal]--] = numList[i];
                        }

                        Console.WriteLine("\n" + "Array Ordenada :");
                        foreach (int aa in sortednumList)
                            Console.Write(aa + " ");
                        Console.Write("\n");
                        sb.Stop();
                        Console.WriteLine("Tiempo De Ejecucion Trancurrido: {0}", sb.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));
                        break;

                        case 3:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
                        break;
                }

            }
        }
    }

}                   