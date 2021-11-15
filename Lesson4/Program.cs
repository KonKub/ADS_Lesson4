using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson4
{
        //1. Протестируйте поиск строки в HashSet и в массиве
        //Заполните массив и HashSet случайными строками, не менее 10 000 строк.Строки можно сгенерировать.
        //Потом выполните замер производительности проверки наличия строки в массиве и HashSet.
        //Выложите код и результат замеров.

    public class Program
    {


        [MemoryDiagnoser]
        [RankColumn]
        public class ArrHashTest
        {
            const int Size = 10000;
            string[] StringArr = new string[Size];
            HashSet<string> StringHash = new HashSet<string>();
            const string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random rnd = new Random();

            private string GenerateString(int Length)
            {
                StringBuilder result = new StringBuilder(Length);
                for (int i = 0; i < Length; i++)
                {
                    result.Append(characters[rnd.Next(characters.Length)]);
                }
                return result.ToString();
            }

            public void GenerateArrHash()
            {
                for (int i = 0; i < Size; i++)
                {
                    StringArr[i] = GenerateString(10);
                    StringHash.Add(GenerateString(10));
                }
            }

            [Benchmark]
            public void FindInArr()
            {
                for (int i = 0; i < Size; i++)
                {
                    if (StringArr[i] == "ecerverrve") break;
                }
            }

            [Benchmark]
            public void FindInHash()
            {
                StringHash.Contains("kljwlekjfw");
            }

        }

        static void Main(string[] args)
        {

            ArrHashTest aht = new ArrHashTest();

            aht.GenerateArrHash();

            BenchmarkRunner.Run<ArrHashTest>();
        }
    }
}
