using System.Runtime.Intrinsics.X86;

namespace CSAssignment_3;

public class Color
{
    public int red { get; set; }
    public int green { get; set; }
    public int blue { get; set; }
    public int trans { get; set; }

    public Color(int r, int g, int b)
    {
        this.red = r;
        this.green = g;
        this.blue = b;
    }
    public Color(int r, int g, int b, int alpha)
    {
        this.red = r;
        this.green = g;
        this.blue = b;
        this.trans = alpha;
    }

    public int grayScale()
    {
        int gray = (red + green + blue) / 3;
        Console.WriteLine($"The gray scale is {gray}");
        return gray;
    }
}

public class Ball
{
    private int times;
    public Color color { get; set; }
    private double size;

    public Ball()
    {
        times = 0;
        size = 1;
    }

    public void Pop()
    {
        this.size = 0;
        Console.WriteLine("the ball has been popped");
    }

    public int thrown()
    {
        if (this.size != 0)
        {
            this.times++;
        }
        Console.WriteLine($"this ball has been thrown {this.times} times");
        return this.times;
    }
}