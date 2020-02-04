using System;
using System.Collections.Generic;
using System.Linq;

namespace James.CodeLou.ExerciseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputtingStudent = true;
            var studentsList = new List<Student>();
            var studentsDictionary = new Dictionary<string, Student>();
            while (inputtingStudent) 
            {
               /* InputStudent();
                Console.WriteLine("Would you like to continue inputting students? [Y/N]");
                inputtingStudent = Console.ReadLine().ToLower() == "y";
                */
                DisplayMenu();
                    var option = Console.ReadLine();

                    switch (int.Parse(option))
                    {
                        case 1:
                            InputStudent(studentsDictionary, studentsList);
                            break;
                        case 2:
                            DisplayStudents(studentsList);

                            break;
                        case 3:
                            SearchStudents(studentsList);
                            break;
                        case 4:
                            inputtingStudent = false;
                            break;
                }   
            }
        }

 private static void DisplayStudents(List<Student> studentsList)
        {
            Console.WriteLine($"Student Id | Name |  Class ");
            studentsList.ForEach(x =>
            {
                Console.WriteLine(x.StudentDisplay);
            });
        }

        private static void SearchStudents(List<Student> studentsList)
        {
            Console.WriteLine("Search string:");
            var searchString = Console.ReadLine();
            var students = studentsList.Where(x => x.FullName.Contains(searchString)).ToList();
            if (students.Any())
            {
                Console.WriteLine($"Student Id | Name |  Class ");
                students.ForEach(x =>
                {
                    Console.WriteLine(x.StudentDisplay);
                });
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

        static void InputStudent(Dictionary<string, Student> studentsDictionary, List<Student> studentsList)
        {     /*static Student InputStudent()   {*/
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

    var studentRecord = new Student();   /*May be var student = new student*/
    studentRecord.StudentId = studentId;
    studentRecord.FirstName = studentFirstName;
    studentRecord.LastName = studentLastName;
    studentRecord.ClassName = className;
    studentRecord.StartDate = startDate;
    studentRecord.LastClassCompleted = lastClass;
    studentRecord.LastClassCompletedOn = lastCompletedOn;
    Console.WriteLine($"Student Id | Name |  Class ");
   /* Console.WriteLine($"{studentRecord.StudentId} | {studentRecord.FirstName} {studentRecord.LastName} | {studentRecord.ClassName} "); */
    Console.WriteLine(student.StudentDisplay);
    Console.ReadKey();
    /*return studentRecord;*/
    studentsDictionary.Add(student.FullName, student);
    studentsList = studentsDictionary.Select(s => s.Value).ToList();

        }
    }
}
