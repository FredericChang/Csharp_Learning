using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Basic
{
    internal class Program
    {
        public class Teacher
        {
            public string LastName { get; set; }
            public List<int> scores { get; set; }
        }

        public static void Main(string[] args)
        {
            // Data source.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

            // Query Expression.
            IEnumerable<int> scoreQuery = //query variable
                from score in scores //required
                where score > 80 // optional
                orderby score descending // optional
                select score; //must end with select or group
            IEnumerable<int> scoreQuery2 =
                from score in scores
                where score < 85
                orderby score descending
                select score;

            // Execute the query to produce the results
            foreach (int testScore in scoreQuery)
            {
                Console.WriteLine(testScore);
                
            }

            int scoreCount = scoreQuery.Count();
            Console.WriteLine("ScoreCount = " + scoreCount);
                
            foreach (int testScore in scoreQuery2)
            {
                Console.WriteLine(testScore);
            }
            
            int scoreCount2 = scoreQuery.Count();
            Console.WriteLine("ScoreCount = " + scoreCount2);

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher {LastName="A", scores = new List<int>{97,79,61,16}},
                new Teacher {LastName="B", scores = new List<int>{81,88,77,0}},
                new Teacher {LastName="C", scores = new List<int>{55,79,77,16}},
                new Teacher {LastName="D", scores = new List<int>{97,66,61,88}},
            };

            var scoreQueryTest =
                from teacher in teachers
                from score in teacher.scores
                where score > 90
                select new {Last = teacher.LastName, score};
            Console.WriteLine("print Scores");
            foreach (var teacher in scoreQueryTest)
            {
                Console.WriteLine("{0} Score: {1}", teacher.Last, teacher.score);
            }
            
        }
        

    }
}