using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Into
{
    internal class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public int Age { get; set;}
            public DateTime enrty { get; set; }
            public List<int> Scores;
        }
        
        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Age=10, enrty = DateTime.Now, Scores= new List<int> {97, 72, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Age=50,enrty = DateTime.Now,Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Age=40,enrty = DateTime.Now,Scores= new List<int> {99, 89, 91, 95}},
                new Student {First="Cesar", Last="Garcia", ID=114, Age=30,enrty = DateTime.Now,Scores= new List<int> {72, 81, 65, 84}},
                new Student {First="Debra", Last="Garcia", ID=115, Age=20,enrty = DateTime.Now,Scores= new List<int> {97, 89, 85, 82}}
            };

            return students;
        }
        
        
        public static void Main(string[] args)
        {
            string[] words = { "apples", "blueberries", "oranges", "bananas", "apricots"};

            // Create the query.
            var wordGroups1 =
                from w in words
                group w by w[0] into fruitGroup
                where fruitGroup.Count() >= 2
                select new { FirstLetter = fruitGroup.Key, Words = fruitGroup.Count() };

            // Execute the query. Note that we only iterate over the groups,
            // not the items in each group
            foreach (var item in wordGroups1)
            {
                Console.WriteLine(" {0} has {1} elements.", item.FirstLetter, item.Words);
            }

            List<Student> students = GetStudents();
            var booleanGroupQuery =
                from student in students
                where student.Age >= 20 && student.Age <= 40
                select student 
                    into teenStudents
                    where teenStudents.Last.StartsWith("B")
                    select teenStudents;
            
            foreach (var student in students)
            {
                Console.WriteLine(" {0} has {1} elements.", student.First, student.Age);
            }

        }
    }
}