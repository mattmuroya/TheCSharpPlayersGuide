namespace TheColor;

class Program
{
    static void Main(string[] args)
    {
        var red = new Color(4, 0, 0);
        var green = Color.Green;

        red.Print();
        green.Print();
    }
}

class Color
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White => new Color(255, 255, 255);
    public static Color Black => new Color(0, 0, 0);
    public static Color Red => new Color(255, 0, 0);
    public static Color Orange => new Color(255, 165, 0);
    public static Color Yellow => new Color(255, 255, 0);
    public static Color Green => new Color(0, 128, 0);
    public static Color Blue => new Color(0, 0, 255);
    public static Color Purple => new Color(128, 0, 128);

    public void Print()
    {
        Console.WriteLine($"({R}, {G}, {B})");
    }
}

