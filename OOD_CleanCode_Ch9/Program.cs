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
        public void voidDrawAllShapes(Ilist shapes)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
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
    
     
}