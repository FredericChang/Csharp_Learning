namespace TwoInterface
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Box box1 = new Box(30.0f, 20.0f);
            IEnglishDimensions eDimensions = box1;
            IMetricDimensions mDimensions = box1;
            System.Console.WriteLine("Length(in): {0}", eDimensions.Length);
            System.Console.WriteLine("Width (in): {0}", eDimensions.Width);

            // Print dimensions in metric units:
            System.Console.WriteLine("Length(cm): {0}", mDimensions.Length);
            System.Console.WriteLine("Width (cm): {0}", mDimensions.Width);

        }
    }
}