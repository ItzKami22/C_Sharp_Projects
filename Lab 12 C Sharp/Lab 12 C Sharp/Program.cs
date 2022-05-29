using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Камиль\source\repos\Lab 12 C Sharp\Lab 12 C Sharp\ФИО.txt";
            List<Personality> FIO = new List<Personality>();
            string s;
            using (StreamReader f = new StreamReader(path))
            {
                while ((s = f.ReadLine()) != null)
                {
                    string[] temp = s.Split(' ');
                    FIO.Add(new Personality(temp[1], temp[0], Convert.ToInt32(temp[2])));
                }
            }

            //Задание 1
            var letters = new[] { "А", "У", "О", "И", "Э", "Ы", "Я", "Ю", "Е", "Ё" };
            var task1 = FIO.Where(t => t.age >= 18).Where(a => letters.Any(l => a.lastname.StartsWith(l)));
            foreach (var x in task1)
            {
                Console.WriteLine("Задание 1:\n" + x.lastname + " " + x.age);
            }

            //Задание 2
            Console.WriteLine();
            var task2 = FIO.Select(x => new
            {
                FirstName = x.name,
                SecondName = x.lastname,
                NewAge = x.age
            });
            Console.WriteLine("Задание 2:");
            foreach (var x in task2)
            {
                Console.WriteLine(x.FirstName + " " + x.SecondName + " " + x.NewAge);
            }

            //Задание 3
            Console.WriteLine();
            var task3 = FIO.OrderBy(x => x.lastname);
            Console.WriteLine("Задание 3(по фамилии):");
            foreach (var x in task3)
            {
                Console.WriteLine(x.lastname + " " + x.age);
            }
            var task31 = FIO.OrderBy(x => x.age);
            Console.WriteLine("\nЗадание 3(по возрасту):");
            foreach (var x in task31)
            {
                Console.WriteLine(x.lastname + " " + x.age);
            }

            //Задание 4
            var task4 = FIO.GroupBy(x => x.lastname);
            Console.WriteLine("\nЗадание 4:");
            foreach (var x in task4)
            {
                Console.WriteLine(x.Key);
                foreach (var t in x)
                {
                    Console.WriteLine(t.name + " " + t.lastname);
                }
            }

            //Задание 5
            int task5 = FIO.Count(x => x.age >= 18);
            Console.WriteLine("\nЗадание 5:\n" + task5);

            //Задание 6
            var task6 = FIO.Take(8);
            Console.WriteLine("\nЗадание 6:");
            foreach (var x in task6)
            {
                Console.WriteLine(x.name + " " + x.lastname + " " + x.age);
            }

            //Задание 7
            bool task7 = FIO.Any(x => x.age < 18);
            Console.WriteLine("\nЗадание 7:");
            if (task7)
                Console.WriteLine("В списке есть несовершеннолетние");
            else Console.WriteLine("В списке нет несовершеннолетних");

            
            //Задание 8
            Console.WriteLine();
            var task8 = FIO.OrderBy(x => x.name).ThenBy(x => x.lastname);

            Console.WriteLine("Задание 8(по имени, фамилии):");
            foreach (var x in task8)
            {
                Console.WriteLine(x.name + " " + x.lastname + " "+ x.age);
            }
        }
    }
}
