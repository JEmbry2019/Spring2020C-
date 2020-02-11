using System;
using System.Collections.Generic;
using System.IO;

 
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
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, students);
            }
        }
        
        public List<Student> Read() {
            return  JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(_studentRepositoryPath));
        }
    }
}