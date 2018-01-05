using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace Sort_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            List<int> originalList = generateList();

            sw.Start();

            var selectionSortList = selectionSort(originalList);
            //outputList(selectionSortList);

            sw.Stop();
            Console.WriteLine("Selection sort : {0}", sw.Elapsed);

            List<int> originalListAgain = generateList();

            sw.Reset();
            sw.Start();

            var insertionSortList = insertionSort(originalListAgain);
            //outputList(insertionSortList);

            sw.Stop();
            Console.WriteLine("Insertion sort : {0}", sw.Elapsed);

            List<int> originalListYetAgain = generateList();

            sw.Reset();
            sw.Start();

            var mergeSortList = mergeSort(originalListAgain);
            //outputList(mergeSortList);

            sw.Stop();
            Console.WriteLine("Merge sort : {0}", sw.Elapsed);

            Console.ReadLine();
        }

        static List<int> generateList()
        {
            Random rnd = new Random();
            var list = new List<int>();
            for(int i = 0; i < 2000; i++)
            {
                //list.Add(rnd.Next(1, 1000));
                list.Add(i);
            }
            return list;
        }

        static List<int> selectionSort(List<int> originalList)
        {
            var originalLength = originalList.Count();
            List<int> sortList = new List<int>();

            for (int i = 0; i < originalLength; i++)
            {
                var min = 100000;
                foreach (var number in originalList)
                {
                    min = Math.Min(min, number);
                }
                sortList.Add(min);
                originalList.Remove(min);
            }

            return sortList;
        }

        static List<int> insertionSort(List<int> originalList)
        {
            var originalLength = originalList.Count();
            List<int> sortList = new List<int>();

            foreach(var valueToSort in originalList)
            {
                if(sortList.Count() == 0)
                {
                    sortList.Add(valueToSort);
                }
                else if(valueToSort < sortList.First())
                {
                    sortList.Insert(0, valueToSort);
                }
                else if (valueToSort > sortList.Last())
                {
                    sortList.Add(valueToSort);
                }
                else
                {
                    for(int j = 0; j < sortList.Count() - 2; j++)
                    {
                        if (valueToSort >= sortList[j] && valueToSort <= sortList[j + 1])
                        {
                            sortList.Insert(j + 1, valueToSort);
                            break;
                        }
                    }
                }
            }

            return sortList;
        }

        static List<int> mergeSort(List<int> originalList)
        {
            var originalList_FirstHalf = originalList.Take(originalList.Count()/2).ToList();
            var originalList_SecondHalf = originalList.Skip(originalList.Count() / 2).Take(originalList.Count() / 2).ToList();

            var sortedList_FirstHalf = selectionSort(originalList_FirstHalf);
            var sortedList_SecondHalf = selectionSort(originalList_SecondHalf);
            var sortList = new List<int>();

            for (int i = 0; i < originalList.Count(); i++)
            {
                if(sortedList_SecondHalf.Count() == 0)
                {
                    sortList.AddRange(sortedList_FirstHalf);
                    break;
                }
                else if (sortedList_FirstHalf.Count() == 0)
                {
                    sortList.AddRange(sortedList_SecondHalf);
                    break;
                }
                else
                {
                    var min = Math.Min(sortedList_FirstHalf[0], sortedList_SecondHalf[0]);
                    sortList.Add(min);
                    if(min == sortedList_FirstHalf[0])
                    {
                        sortedList_FirstHalf.RemoveAt(0);
                    }
                    else
                    {
                        sortedList_SecondHalf.RemoveAt(0);
                    }
                }
            }

            return sortList;
        }

        static void outputList(List<int> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
