using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Вариант 21
Дана целочисленная квадратная матрица. Определить:
1.сумму элементов в тех строках, которые не содержат отрицательных элементов;
2.минимум среди сумм элементов диагоналей, параллельных главной диагонали
матрицы.*/

namespace _4_1_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                { 1, 2, -3, 4, 8 },
                { 5, 6, 7, 8, 9 },
                { 9, 10, 11, 12, 0 },
                { 13, 14, 15, 16, 1 },
                { 15, 16, 17, 18, 2 },
            };
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);

            // Сумма элементов в тех строках, которые не содержат отрицательных элементов;
            List<int> summ = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                bool flag = true;
                for (int j = 0; j < m; j++)
                {
                    sum += arr[i, j];
                    if (arr[i, j] < 0)
                        flag = false;
                }
                if (flag)
                    summ.Add(sum);
            }
            foreach (int sum in summ)
                Console.WriteLine(sum);
            Console.WriteLine();

            // Cуммs элементов диагоналей, параллельных главной диагонали матрицы.
            List<int> sumD = new List<int>();
            for (int k = 1; k < n; k++)
            {
                int sum = 0;                
                for (int i = 0; i < n; i++)
                {                    
                    for (int j = 0; j < m; j++)
                    {
                        if (j == i + k)
                        {
                            sum += arr[i, j];                            
                        }                            
                    }                                   
                }
                sumD.Add(sum);                
            }
            for (int k = 1; k < n; k++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i == j + k)
                        {
                            sum += arr[i, j];
                        }
                    }
                }
                sumD.Add(sum);
            }
            foreach (int sum in sumD)
                Console.WriteLine(sum);
            Console.WriteLine();

            // Поиск минимума.
            int min = sumD[0];
            for (int i = 1; i < sumD.Count; i++)
                if (sumD[i] < min)
                    min = sumD[i];
            
            Console.WriteLine($"min = {min}");

            Console.ReadKey();
        }
    }
}
