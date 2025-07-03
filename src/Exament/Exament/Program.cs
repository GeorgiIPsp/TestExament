using System;
using System.IO;
using Exament.Classes;








class Program
{
    static void Main()
    {
        int size = 0;
        while (true)
        {
            Console.Write("Введите количество студентов: ");
            try
            {
                size = 0;
                if (int.TryParse(Console.ReadLine(), out size))
                {
                    if (size > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Количество должно быть больше 0. Попробуйте снова!");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод количества. Поробуйте снова!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        

        StudentManager manager = new StudentManager();
        manager.FillStudents(size);
        manager.SortStudentss();
        manager.SaveToFile();
        manager.ReadToFile();

        Console.WriteLine("Программа завершена. Проверьте файл students.txt.");
        Console.ReadKey();
    }
}