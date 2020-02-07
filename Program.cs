using System;
using System.Collections.Generic;
using System.Linq;

namespace James.CodeLou.ExerciseProject

{
    class Program
    {
        static List<Student> studentsList = new List<Student>();

        static void Main(string[] args)
        {
            var inputtingStudent = true;

            while (inputtingStudent)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (int.Parse(option))
                {
                    case 1:
                        InputStudent();
                        break;
                    case 2:
                        DisplayStudents();

                        break;
                    case 3:
                        SearchStudents();
                        break;
                    case 4:
                        inputtingStudent = false;
                        break;
                }
            }
        }

        private static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine($"Student Id | Name |  Class ");
            studentsList.ForEach(x =>
            {
                Console.WriteLine(x.StudentDisplay);
            });
        }

        private static void DisplayStudents() 
        {
            DisplayStudents(studentsList);
        }


        private static void SearchStudents()
        {
            Console.WriteLine("Search string: Enter first and last name.");
            var searchString = Console.ReadLine();
            var students = studentsList.Where(x => x.FullName.Contains(searchString)).ToList();
            if (students.Any())
            {
                DisplayStudents(students);
            }
            else 
            {
                System.Console.WriteLine("No students found which match this criteria.");
                System.Console.WriteLine("Press 3 to Continue or press 4 to Exit.\n");
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Select from the following operations:");
            Console.WriteLine("1: Enter new student");
            Console.WriteLine("2: List all students");
            Console.WriteLine("3: Search for student by name");
            Console.WriteLine("4: Exit");
        }

        static void InputStudent()
        {
            Console.WriteLine("Enter Student Id");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name");
            var studentFirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            var studentLastName = Console.ReadLine();
            Console.WriteLine("Enter Class Name");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed");
            var lastClass = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
            var lastCompletedOn = DateTimeOffset.Parse(Console.ReadLine());
            Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
            var startDate = DateTimeOffset.Parse(Console.ReadLine());

            var student = new Student();
            student.StudentId = studentId;
            student.FirstName = studentFirstName;
            student.LastName = studentLastName;
            student.ClassName = className;
            student.StartDate = startDate;
            student.LastClassCompleted = lastClass;
            student.LastClassCompletedOn = lastCompletedOn;
            Console.WriteLine($"Student Id | Name |  Class ");
            Console.WriteLine(student.StudentDisplay);
            Console.ReadKey();
            studentsList.Add(student);
        }
    }
}