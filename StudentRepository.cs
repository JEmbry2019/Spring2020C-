using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//using Newtonsoft.Json;


 
namespace James.CodeLou.ExerciseProject
{
    public class StudentRepository
    {
        string _studentRepositoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\students.json";
        
        public List<Student> Students => File.Exists(_studentRepositoryPath) ? Read() : new List<Student>();

        public void Add(Student student)
        {
            var students = Students;
            students.Add(student);
            Save(students);
        }
        
        public void Save(List<Student> students)
        {
            using (var file = File.CreateText(_studentRepositoryPath))
            {
                //var serializer = new JsonSerializer();
                //serialize object directly into file stream
                var studentString = JsonSerializer.Serialize(students);
                file.Write(studentString);
            }
        }
        
        public List<Student> Read() {
            return  JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(_studentRepositoryPath));
        }
    }
}