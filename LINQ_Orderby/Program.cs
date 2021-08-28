using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LINQ_Orderby
{
    internal class Program
    {
        public class Gun
        {
            public string Owner { get; set; }
            public string Name { get; set; }
            public int ID { get; set; }
            public int Year { get; set; }
            public string Nation { get; set; }
        }

        public static List<Gun> GetGuns()
        {
            List<Gun> guns = new List<Gun>()
            {
                new Gun {Owner="a", Name="Daewoo-Precision-Industries-K1A", ID=111, Year=1980, Nation="South Korean"},
                new Gun {Owner="b", Name="AK-47", ID=112, Year=1948, Nation="Russian"},
                new Gun {Owner="c", Name="KRISS-Vector", ID=113, Year=2006, Nation="United States"},
                new Gun {Owner="d", Name="SC-2005", ID=114, Year=2005, Nation="Peru"},
                new Gun {Owner="e", Name="Winchester-Model-1200/1300", ID=115, Year=1968, Nation="United States"},

            };
            return guns;
        }
        
        public static void Main(string[] args)
        {
            string[] fruits = { "cherry", "apple", "blueberry" };

            var sortAscendingQuery = from fruit in fruits orderby fruit select fruit;

            foreach (var fruit in sortAscendingQuery)
            {
                Console.WriteLine(fruit);
            }
            
            var sortAscendingQuery2 = from fruit in fruits orderby fruit descending select fruit;
            foreach (var fruit in sortAscendingQuery2)
            {
                Console.WriteLine(fruit);
            }
            
            var sortAscendingQuery3 = from fruit in fruits orderby fruit ascending select fruit;
            foreach (var fruit in sortAscendingQuery3)
            {
                Console.WriteLine(fruit);
            }
            
            List<Gun> guns = GetGuns();
            var sortedGuns =
                from gun in guns
                orderby  gun.Owner ascending,gun.Name ascending
                select gun;

            foreach (var gun in guns)
            {

                Console.WriteLine(gun.Name + gun.Owner);  
            }
            
            var sortedGuns2 =
                from gun in guns
                orderby  gun.Name, gun.Owner
                group gun by gun.Name[0]  into newGroup
                orderby newGroup.Key
                select newGroup;
            foreach (var studentGroup in sortedGuns2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var gun in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", gun.Name, gun.Owner);
                }
            }

        }
    }
}