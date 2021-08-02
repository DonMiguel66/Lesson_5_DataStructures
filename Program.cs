using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task2();
            Task3();
            Task4();
        }
        #region Task_1
        /// <summary>
        /// Реализовать метод расширения для поиска количество символов в строке
        /// </summary>
        public static void Task2()
        {
            string strExample = "We will we will rock you";
            char searchedSymbol = 'e';

            //Метод расширения реализован в статическом классе StringExtention
            int count = strExample.CharCount(searchedSymbol);
            Console.WriteLine(count);
        }
        #endregion

        #region Task_3
        /// <summary>
        /// Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
        /// 
        /// A. для целых чисел;
        /// B. * для обобщенной коллекции;
        /// C. ** используя Linq.
        /// </summary>
        public static void Task3()
        {
            // Список целых цисел
            List<int> integerList = new List<int>()
            {
                4,6,1,3,7,5,6,7,9,1,2,4,7,9,1,3,4,5,7,8,4,3,5
            };
            // Список строковых данных
            List<string> strList= new List<string>()
            {
                "Bob", "Micke", "Ann", "John", "Bob", "Jack", "Helen", "Ann", "Peter", "Ivan", "Jack", "Ivan", "Mickle", "Ann", "Micke", "John", "Margaret"
            };

            Dictionary<int, int> countOfIntegerElements = new Dictionary<int, int>();
            Dictionary<string, int> countOfStringElements = new Dictionary<string, int>();

            Console.WriteLine("Task_3 \'A\':");
            countOfIntegerElements = elementsCountDict(integerList);
            PrintDict(countOfIntegerElements);

            Console.WriteLine("Task_3 \'B\':");
            countOfStringElements = elementsCountDict(strList);
            PrintDict(countOfStringElements);

            //Подсчёт элементов через Linq
            Console.WriteLine("Task_3 \'C\':");
            countOfIntegerElements = integerList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            PrintDict(countOfIntegerElements);
        }

        //Подсчёт элементов для коллекции, содержащей целые числа
        static Dictionary<int, int> elementsCountDict(List<int> list)
        {
            Dictionary<int, int> countOfElements = new Dictionary<int, int>();

            foreach (var value in list)
            {
                if (countOfElements.ContainsKey(value))
                {
                    countOfElements[value]++;
                }
                else
                {
                    countOfElements.Add(value, 1);
                }
            }
            return countOfElements;
        }

        //Подсчёт элементов для обощённой коллекции
        static Dictionary<T, int> elementsCountDict<T>(List<T> list)
        {
            Dictionary<T, int> countOfElements = new Dictionary<T, int>();

            foreach (var value in list)
            {
                if (countOfElements.ContainsKey(value))
                {
                    countOfElements[value]++;
                }
                else
                {
                    countOfElements.Add(value, 1);
                }
            }
            return countOfElements;
        }

        static void PrintDict<T>(Dictionary<T, int> d)
        {
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        #endregion

        #region Task_4
        /// <summary>
        /// * Дан фрагмент программы:Dictionary<string, int> dict = new Dictionary<string, int>()
        /// {
        /// {"four",4 },
        /// {"two",2 },
        /// { "one",1 },
        /// {"three",3 },
        /// };
        /// var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
        /// foreach (var pair in d)
        /// {
        /// Debug.Log($"{pair.Key} - {pair.Value}");
        /// }
        /// 
        /// Задачи:
        /// а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
        /// b. * Развернуть обращение к OrderBy с использованием делегата
        /// 
        /// </summary>
public static void Task4()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            // Изначальный фаргмент программы
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            // A. Обращение, свёрнутое с использование лямбда-выражения
            var d1 = dict.OrderBy(x => x.Value);
            foreach (var pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

        }
        #endregion
    }
}
