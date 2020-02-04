using System;

namespace James.CodeLou.ExerciseProject
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset LastClassCompletedOn { get; set; }


        /*New Code*/
        public string FullName => $"{FirstName} {LastName}";
        public string StudentDisplay => $"{StudentId} | {FirstName} {LastName} | {ClassName} ";

    }
}