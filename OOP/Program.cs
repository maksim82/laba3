using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class DataProcesor <T> where T : Work
    {
        public List<T> list;
        public int x; //нижний порог отбора
        public int y; //верхний порог отбора

        public DataProcesor (List<T> list) //конструктор
        {
            this.list = list;
        }

        public void Select(int x, int y) //выборка двух элементов из диапозона
        {
            if (x > y) throw new Exception("не правильное указывание диапозона");//создание ошибки

            var massForTask1 = from i in list
                               where (i.time > x) && (i.time < y)
                               orderby i.time descending
                               select i;

            var massForTask2 = massForTask1.Take(2); //КАК СДЕЛАТЬ В ОДНУ ВЫБОРКУ?

            foreach (Work i in massForTask2)
            {
                Console.WriteLine(i.Output());
            }
        }

        public void Search(int timeInput) //поиск задачи по трудазатратности на неё (time - трудозатротность)
        {
                var output = from i in list
                             where i.time == timeInput
                             select i;

                if (output.Count() == 0) throw new Exception("задачи с данной трудоёмкостью нет");

                
                foreach (Work i in output)
                {
                    Console.WriteLine(i.Output());
                }
               
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            #region ВВЫВОД ДАННЫХ

            List<Work> work = new List<Work>()
            {
                new Work(1, 8), //должен вывести вторым
                new Work(2, 3),
                new Work(3, 32),
                new Work(4, 5),
                new Work(5, 2),
                new Work(6, 14),
                new Work(7, 9), //должен вывести первым
                new Work(8, 32),
            };

            List<Human> worker = new List<Human>()
            {
                new Worker(1, 2),
                new Worker(2, 2),
                new TeamLead (3, 2)
            };

            #endregion

            #region ПРОГРАММА

            //Вывод всех введенёх задач
            foreach (Work i in work)
            {
                Console.WriteLine(i.Output());
            }

            DataProcesor<Work> myList = new DataProcesor<Work>(work);
            //Вывести задачи, где трудозатраты больше x, но меньше y, отсортированный по уменьшению трудоемкости максимумом в 2 элемента
            Console.WriteLine("\nвведите два числа диапозона: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            try
            {
                myList.Select(x, y);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Сделать поиск по трудозатратам
            Console.WriteLine("\nвведите трудозатрату для поиска: ");
            int timeInput = Convert.ToInt32(Console.ReadLine());

            try
            {
                myList.Search(timeInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

        }
    }
}
