﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace James.CodeLou.ExerciseProject
/*New Branch Challenge2Solution Tuesday*/
{
    class Program
    {
        static List<Student> studentsList = new List<Student>();

        static void Main(string[] args)
        {
            var inputtingStudent = true;

            /* var studentRepository = new StudentRepository();  */

            while (inputtingStudent)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (int.Parse(option))
                {
                    case 1:
                        InputStudent();  /*(studentRepository); changed to () case 1*/
                        break;
                    case 2:
                       DisplayStudents();/*(studentRepository.Student); changed to () case 2,3*/

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
        private static void DisplayStudents() /*New LINQ Code*/
        {
                DisplayStudents(studentsList);
        }
        private static void DisplayStudents(List<Student> studentsList)
        {
            if (studentsList.Any())
            {
            Console.WriteLine($"Student Id | Name |  Class ");
            studentsList.ForEach(x =>
            {
                Console.WriteLine(x.StudentDisplay);
            });
        }
        else
        {  System.Console.WriteLine("No students found.");
        } 
        } 
        /*private static void DisplayStudents() => DisplayStudents(studentsList);*/
          /*Search Functionality*/
        private static void SearchStudents(List<Student> studentsList) 
        {
            Console.WriteLine("Search string: Enter first and last name.");
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

        private static void InputStudent()   /*Old Code static void InputStudent(StudentRepository studentRepository)*/
        {
            var student = new Student();
            
            /*Console.WriteLine("Enter Student Id");
            var studentId = Convert.ToInt32(Console.ReadLine());*/
            /*New Code*/
                        // Continue prompting the user for input until it is valid
            while (true) 
            {
                // Prompt user
                Console.WriteLine("Enter Student Id");
                // Try to parse the user input 
                var studentIdSuccessful = int.TryParse(Console.ReadLine(), out var studentId);
                // If the input is valid 
                if (studentIdSuccessful) 
                {
                    // Add input to the Student object 
                    student.StudentId = studentId;    
                    // Exit the loop
                    break;
                }

                
            }
            
            /*End New Code*/
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

            /*var student = new Student  Moved to line 77*/
            
            /*student.StudentId = studentId;  Moved to line 96*/
            student.FirstName = studentFirstName;
            student.LastName = studentLastName;
            student.ClassName = className;
            student.StartDate = startDate;
            student.LastClassCompleted = lastClass;
            student.LastClassCompletedOn = lastCompletedOn;
            

           /* studentRepository.Add(student);
            DisplayStudents(studentRepository.Students);
                /*New Code*/
            studentsList.Add(student);  /*(studentRecord);*/
        }
    }
}