// See https://aka.ms/new-console-template for more information

using Islitas;

Console.WriteLine("Hello, World!");

int xAxis = 10;
int yAxis = 10;


var mapBase = IslasCreator.MapLevel1(xAxis, yAxis);

for (int i = 0; i < xAxis; i++)
{
    for (int j = 0; j < yAxis; j++)
    {
        Thread.Sleep(50);
        Console.Write(mapBase[i, j]);
    }
    Console.WriteLine();
}

var map = new Dot[xAxis, yAxis];


for (int i = 0; i < xAxis; i++)
{
    for (int j = 0; j < yAxis; j++)
    {
        map[i, j] = mapBase[i, j] == 1 ? new Island(i, j) : new Sea(i, j);
    }
}

for (int i = 0; i < xAxis; i++)
{
    for (int j = 0; j < yAxis; j++)
    {
        Thread.Sleep(50);
        var quees = map[i, j].Nombre();
        Console.Write(quees);
    }
    Console.WriteLine();
}


public abstract class Dot
{
    public Dot Left { get; set; }
    public Dot Right { get; set; }
    public Dot Top { get; set; }
    public Dot Bottom { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Dot(int i, int j)
    {
        X = i;
        Y = j;
    }

    public abstract bool ImAIslita();


    public abstract string Nombre();
}

public class Island : Dot
{
    public Island(int i, int j) : base(i, j)
    {
    }

    public bool HasBrodi()
    {
        if (Left.ImAIslita() || Right.ImAIslita() || Top.ImAIslita() || Bottom.ImAIslita())
            return true;

        return false;
    }

    public override bool ImAIslita() => true;

    public override string Nombre() => "█";
}

public class Sea : Dot
{
    public Sea(int i, int j) : base(i, j)
    {
    }

    public override bool ImAIslita() => false;
    public override string Nombre() => "░";

}