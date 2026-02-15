namespace Assignment_4
{
    internal class Program
    {
     
        struct Point
        {
            double x;
            double y;
            public void setX(double x)
            {
                this.x = x;
            }
            public void setY(double y)
            {
                this.y = y;
            }
            public double getX()
            {
                return x;
            }
            public double getY()
            {
                return y;
            }

        }
        static void Main(string[] args)
        {
            Point a = new Point();
            Point b = new Point();
            double x, y;
            Console.Write("Enter the x coordinate of the point A: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Invalid input for x coordinate.");
                Console.Write("Enter the x coordinate of the point A: ");
            }
            a.setX(x);
            Console.Write("Enter the y coordinate of the point A: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Invalid input for y coordinate.");
                Console.Write("Enter the y coordinate of the point A: ");
            }
            a.setY(y);
            Console.Write("Enter the x coordinate of the point B: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Invalid input for x coordinate.");
                Console.Write("Enter the x coordinate of the point B: ");
            }
            b.setX(x);
            Console.Write("Enter the y coordinate of the point B: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Invalid input for y coordinate.");
                Console.Write("Enter the y coordinate of the point B: ");
            }
            b.setY(y);
            double distance = Math.Sqrt(Math.Pow(b.getX() - a.getX(), 2) + Math.Pow(b.getY() - a.getY(), 2));
            Console.WriteLine($"The distance between point A and point B is: {distance}");

        }
    }
}

    

