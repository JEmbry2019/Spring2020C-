using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
namespace James.CodeLou.ExerciseProject
/*New Branch Challenge3Solution Monday Feb 24*/
{
    class Program
    {
        //static List<Student> studentsList = new List<Student>();
        static string _studentRepositoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\students.json";
        static List<Student> studentsList = File.Exists(_studentRepositoryPath) ? Read() : new List<Student>();
       
        static void Save() 
        {
             using (var file = File.CreateText(_studentRepositoryPath))
              {
                  file.WriteAsync(JsonSerializer.Serialize(studentsList));
              }
          }
        
        static List<Student> Read() {
            return  JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(_studentRepositoryPath));
        }
        static void Main(string[] args)
        {
            var inputtingStudent = true;
            //var studentRepository = new StudentRepository();  
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
                       DisplayStudents();    /*(studentRepository.Students); /*changed to () case 2,3*/

                        break;
                    case 3:
                        SearchStudents(); //*(studentsList: studentRepository.Students);
                        break;
                    case 4:
                        inputtingStudent = false;
                        break;
                }
            }
        }

        private static void DisplayStudents(List<Student> students)
        {
            if (students.Any())
            {
            Console.WriteLine($"Student Id | Name |  Class ");
            students.ForEach(x =>
            {
                Console.WriteLine(x.StudentDisplay);
            });
        }
        else
        {  
            System.Console.WriteLine("No students found.");
        } 
        } 
                  /*Search Functionality*/
        private static void DisplayStudents() => DisplayStudents(studentsList);

        private static void SearchStudents()
        {
            Console.WriteLine("Search string: Enter first and last name.");
            var searchString = Console.ReadLine();
            var students = studentsList.Where(x => x.FullName.ToLower().Contains(searchString.ToLower()) || x.ClassName.ToLower().Contains(searchString.ToLower()));
            DisplayStudents(students.ToList());
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
            while (true) 
            {      // Prompt user and parse input.
                Console.WriteLine("Enter Student Id");
                var studentIdSuccessful = int.TryParse(Console.ReadLine(), out var studentId);
                if (studentIdSuccessful) 
                {
                    student.StudentId = studentId;   // Add input to the Student object  
                    break;   // Exit the loop
                }          
            }
            Console.WriteLine("Enter First Name");
            var studentFirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            var studentLastName = Console.ReadLine();
            Console.WriteLine("Enter Class Name");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed");
            var lastClass = Console.ReadLine();       
            while (true) {
                Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
                var lastCompletedOnSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var lastClassCompletedOn);
                if (lastCompletedOnSuccessful) {
                    student.LastClassCompletedOn = lastClassCompletedOn;
                    break;
                }
            } 
            while (true) {
                Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
                var startDateSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var startDate);
                if (startDateSuccessful) {
                    student.StartDate = startDate;
                    break;
                }
             
            }

            studentsList.Add(student);  
            Save();            
        }
        //   private static void Save()
        //   {
        //   throw new NotImplementedException();
        //   }
          
           
        
    }
}

//static List<Student> Write() {
 // return  JsonSerializer.Serialize<List<Student>>(File.CreateText(_studentRepositoryPath).Write(serialiedStudentsList);