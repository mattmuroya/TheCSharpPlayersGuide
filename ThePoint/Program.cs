namespace ThePoint;

class Program
{
    static void Main(string[] args)
    {
        var a = new Point(2, 3);
        var b = new Point(-4, 0);
        var c = new Point();
        
        a.Print();
        b.Print();
        c.Print();
    }
}

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point()
    {
        X = Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Print()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}