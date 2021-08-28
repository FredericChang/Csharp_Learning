using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Group
{
    
    internal class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public DateTime enrty { get; set; }
            public List<int> Scores;
        }
        
        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, enrty = DateTime.Now, Scores= new List<int> {97, 72, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, enrty = DateTime.Now,Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, enrty = DateTime.Now,Scores= new List<int> {99, 89, 91, 95}},
                new Student {First="Cesar", Last="Garcia", ID=114, enrty = DateTime.Now,Scores= new List<int> {72, 81, 65, 84}},
                new Student {First="Debra", Last="Garcia", ID=115, enrty = DateTime.Now,Scores= new List<int> {97, 89, 85, 82}}
            };

            return students;
        }
        public static void Main(string[] args)
        {
            List<Student> students = GetStudents();
            var booleanGroupQuery =
                from student in students
                group student by student.Scores.Average() >= 80;


            foreach (var studentGroup in booleanGroupQuery)
            {
                Console.WriteLine(studentGroup.Key == true ? "High averages" : "Low averages");
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
                }
            }

            var booleanGroupQuery2 =
                from student in students
                let avg = (int)student.Scores.Average()
                group student by (avg / 10) into g
                orderby g.Key
                select g;
            foreach (var studentGroup in booleanGroupQuery2)
            {
                int temp = studentGroup.Key * 10;
                Console.WriteLine("Students with an average between {0} and {1}", temp, temp + 10);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
                }
            }
            

        }
        
        
    }
}