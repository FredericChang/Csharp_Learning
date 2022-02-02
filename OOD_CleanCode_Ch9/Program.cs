using System;
using System.Collections;
using System.Collections.Generic;

namespace OOD_CleanCode_Ch9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            
        }


    }


    public interface Shape
    {
        void Draw();
    }

    public class Square : Shape
    {
        public void Draw()
        {
            
        }
    }
    
    public class Circle : Shape
    {
        public void Draw()
        {
            
        }

    }
    void voidDrawAllShapes(ArrayList shapes)
    {
        shapes.Sort(new ShapeComparer());
        foreach (Shape shape in shapes)
        {
            shape.Draw();
        }
    }

    public class ShapeComparer : IComparer
    {
        private static Hashtable priorities = new Hashtable();

        static ShapeComparer()
        {
            priorities.Add(typeof(Circle),1 );
            priorities.Add(typeof(Square),2 );

        }

        private int PriorityFor(Type type)
        {
            if (priorities.Contains(type))
                return (int) priorities[type];
            else
            {
                return 0;
            }
        }
        public int Compare(object o1, object o2)
        {
            int priority1 = PriorityFor(o1.GetType());
            int priority2 = PriorityFor(o2.GetType());
            return priority1.CompareTo(priority2);

        }
    }
    

     
}