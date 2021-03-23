using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucketsort_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Bucketsort_2
    {
        class Program
        {
            static void BucketSort(int[] a)
            {
                // Примем, что количество корзин равно количеству элементов в массиве-источнике.
                // Тогда:
                // массив корзин
                List<int>[] aux = new List<int>[a.Length];

                // каждую корзину проинициализировать
                for (int i = 0; i < aux.Length; ++i)
                    aux[i] = new List<int>();

                // найти диапазон значений в массиве-источнике
                int minValue = a[0];
                int maxValue = a[0];

                for (int i = 1; i < a.Length; ++i)
                {
                    if (a[i] < minValue)
                        minValue = a[i];
                    else if (a[i] > maxValue)
                        maxValue = a[i];
                }

                // эта величина будет использоваться a.Length раз, поэтому имеет смысл её сохранить.
                double numRange = maxValue - minValue;

                for (int i = 0; i < a.Length; ++i)
                {
                    // вычисление индекса корзины
                    int bcktIdx = (int)Math.Floor((a[i] - minValue) / numRange * (aux.Length - 1));

                    // добавление элемента в соответствующую корзину
                    aux[bcktIdx].Add(a[i]);
                }

                // сортировка корзин. Здесь я, для упрощения себе писанины, использую библиотечную сортировку
                for (int i = 0; i < aux.Length; ++i)
                    aux[i].Sort();

                // собираем отсортированные элементы обратно в массив-источник
                int idx = 0;

                for (int i = 0; i < aux.Length; ++i)
                {
                    for (int j = 0; j < aux[i].Count; ++j)
                        a[idx++] = aux[i][j];
                }
            }

            static void Main()
            {
                int[] arr = new int[15];
                Random rnd = new Random();

                for (int i = 0; i < arr.Length; ++i)
                    arr[i] = rnd.Next(-99, 100);

                Console.WriteLine(String.Join(" ", arr));
                Console.WriteLine();
                BucketSort(arr);
                Console.WriteLine(String.Join(" ", arr));
                Console.ReadKey();
            }
        }
    }

}
