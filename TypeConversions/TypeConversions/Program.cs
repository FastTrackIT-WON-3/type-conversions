using System;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            // [X=10,Y=20]
            // Conversions
            // Point => string: "[X=10,Y=20]"
            // string => Point: new Point { X = 10, Y = 20 }
            Point p = new Point
            {
                X = 10,
                Y = 20
            };
            Console.WriteLine(p);

            Point otherPoint = (Point)"[X=50,Y=70]";
            Console.WriteLine(otherPoint);

            Point sumPoint = p + otherPoint;
            Console.WriteLine(sumPoint);
            /*
            string someOtherPoint = "[X=50,Y=70]";
            if (Point.TryParse(someOtherPoint, out Point otherPoint))
            {
                Console.WriteLine("Converted Point=" + otherPoint.ToString());
            }
            else
            {
                Console.WriteLine($"'{someOtherPoint}' cannot be converted to Point");
            }
            */
        }
    }
}
