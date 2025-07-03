using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exament.Classes
{
    public class StudentManager
    {
        List<Student> listStudent = new List<Student>();
        string name;
        int age;
        double averageGrade = 0;
        public void FillStudents(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Введите данные студента {i + 1}:");
                while (true)
                {
                    Console.Write("Имя: ");
                    try
                    {
                        name = Console.ReadLine();
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Пустая строка. Попробуйте снова!");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Ошибка: " + e.Message);
                    }
                    
                    
                }
                while (true)
                {
                    Console.Write("Возраст: ");
                    
                    try
                    {
                       
                        if(int.TryParse(Console.ReadLine(), out age))
                        {
                            if (age > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Возраст должен быть больше 0!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод. Попробуйте снова!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка: " + e.Message);
                    }
                }
                while(true)
                {
                    Console.Write("Средний балл: ");
                    
                    try
                    {

                        if (double.TryParse(Console.ReadLine(), out averageGrade))
                        {
                            if (averageGrade > 0 && averageGrade < 6)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Средний балл должен быть от 1 до 5. Попробуйте снова!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод. Попробуйте снова!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка: " + e.Message);
                    }
                }
                
                Student students = new Student { Name = name, Age = age, AverageGrade = averageGrade };
                listStudent.Add(students);
                Console.WriteLine();


            }
        }


        public void SortStudentss()
        {
            for(int i = 0; i < listStudent.Count; i++)
            {
                for(int j = 0; j < listStudent.Count - i - 1; j++)
                {
                    bool needSwap = false;
                    int compareName = string.Compare(listStudent[j].Name, listStudent[j + 1].Name);
                    if (compareName > 0)
                    {
                        needSwap = true;
                    }
                    else if (compareName == 0 && listStudent[j].AverageGrade < listStudent[j + 1].AverageGrade)
                    {
                        needSwap = true;
                    }
                    else if(compareName == 0 && listStudent[j].AverageGrade == listStudent[j + 1].AverageGrade)
                    {
                        if (listStudent[j].Age > listStudent[j+ 1].Age)
                        {
                            needSwap = true;
                        }
                    }

                    if(needSwap)
                    {
                        Student temp = listStudent[j];
                        listStudent[j] = listStudent[j + 1];
                        listStudent[j + 1] = temp;
                    }

                }
            }
        }

        public void SaveToFile()
        {
            string filePath = "students.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var student in listStudent)
                {
                    writer.WriteLine($"{student.Name} - {student.Age}");
                }

            }
            Console.WriteLine($"Данные сохранены в файл: {filePath}");
        }
        public void ReadToFile()
        {
            string filePath = "students.txt";
            using(StreamReader reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
