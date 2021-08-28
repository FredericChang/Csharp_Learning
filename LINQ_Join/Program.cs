﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Join
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
        
        #region Data

        class Product
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }
        }

        class Category
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        // Specify the first data source.
        List<Category> categories = new List<Category>()
        {
            new Category {Name="Beverages", ID=001},
            new Category {Name="Condiments", ID=002},
            new Category {Name="Vegetables", ID=003},
            new Category {Name="Grains", ID=004},
            new Category {Name="Fruit", ID=005}
        };

        // Specify the second data source.
        List<Product> products = new List<Product>()
        {
            new Product {Name="Cola",  CategoryID=001},
            new Product {Name="Tea",  CategoryID=001},
            new Product {Name="Mustard", CategoryID=002},
            new Product {Name="Pickles", CategoryID=002},
            new Product {Name="Carrots", CategoryID=003},
            new Product {Name="Bok Choy", CategoryID=003},
            new Product {Name="Peaches", CategoryID=005},
            new Product {Name="Melons", CategoryID=005},
        };
        #endregion
        
        void InnerJoin()
        {
            // Create the query that selects
            // a property from each element.
            var innerJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID
                select new { Category = category.ID, Product = prod.Name };

            Console.WriteLine("InnerJoin:");
            // Execute the query. Access results
            // with a simple foreach statement.
            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine("{0,-10}{1}", item.Product, item.Category);
            }
            Console.WriteLine("InnerJoin: {0} items in 1 group.", innerJoinQuery.Count());
            Console.WriteLine(System.Environment.NewLine);
        }
        void GroupInnerJoin()
        {
            var groupJoinQuery2 =
                from category in categories
                orderby category.ID
                join prod in products on category.ID equals prod.CategoryID into prodGroup
                select new
                {
                    Category = category.Name,
                    Products = from prod2 in prodGroup
                        orderby prod2.Name
                        select prod2
                };

            //Console.WriteLine("GroupInnerJoin:");
            int totalItems = 0;

            Console.WriteLine("GroupInnerJoin:");
            foreach (var productGroup in groupJoinQuery2)
            {
                Console.WriteLine(productGroup.Category);
                foreach (var prodItem in productGroup.Products)
                {
                    totalItems++;
                    Console.WriteLine("  {0,-10} {1}", prodItem.Name, prodItem.CategoryID);
                }
            }
            Console.WriteLine("GroupInnerJoin: {0} items in {1} named groups", totalItems, groupJoinQuery2.Count());
            Console.WriteLine(System.Environment.NewLine);
        }

        void GroupJoin()
        {
            var groupJoinQuery = 
                from Category in categories
                join prod in products on Category.ID equals prod.CategoryID into prodGroup
                select prodGroup;
            // Store the count of total items (for demonstration only).
            int totalItems = 0;
            Console.WriteLine("Simple GroupJoin:");
            foreach (var prodGrouping  in groupJoinQuery)
            {
                Console.WriteLine("Group:");
                foreach (var item in prodGrouping)
                {
                    totalItems++;
                    Console.WriteLine("   {0,-10}{1}", item.Name, item.CategoryID);
                }
            }
            Console.WriteLine("Unshaped GroupJoin: {0} items in {1} unnamed groups", totalItems, groupJoinQuery.Count());
            Console.WriteLine(System.Environment.NewLine);
            
        }
        public static void Main(string[] args)
        {
            Program app = new Program();

            app.InnerJoin();
            app.GroupJoin();
            app.GroupInnerJoin();

            // List<Gun> guns = GetGuns();
            //
            // var sortedGuns2 =
            //     from gun in guns
            //     orderby  gun.Name, gun.Owner
            //     group gun by gun.Name[0]  into newGroup
            //     orderby newGroup.Key
            //     select newGroup;
            // foreach (var studentGroup in sortedGuns2)
            // {
            //     Console.WriteLine(studentGroup.Key);
            //     foreach (var gun in studentGroup)
            //     {
            //         Console.WriteLine("   {0}, {1}", gun.Name, gun.Owner);
            //     }
            // }
        }
    }
}