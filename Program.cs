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
        //Thread.Sleep(50);
        Console.Write(mapBase[i, j]);
    }
    Console.WriteLine();
}

var map = new Dot[xAxis, yAxis];


for (int i = 0; i < xAxis; i++)
{
    for (int j = 0; j < yAxis; j++)
    {
        map[i, j] = mapBase[i, j] == 1 ? new Land(i, j) : new Sea(i, j);
    }
}

Console.WriteLine();

for (int i = 0; i < xAxis; i++)
{
    for (int j = 0; j < yAxis; j++)
    {
        var quees = map[i, j].Draw();
        Console.Write(quees);
    }
    Console.WriteLine();
}

var islands = new List<Island>();

for (int i = 0; i < xAxis; i++)
{
    for (int j = 0; j < yAxis; j++)
    {
        var dot = map[i, j];

        var xTopCoordenate = i - 1;
        var yTopCoordenate = j;

        var xBottomCoordenate = i + 1;
        var yBottomCoordenate = j;

        var xLeftCoordenate = i;
        var yLeftCoordenate = j - 1;

        var xRightCoordenate = i;
        var yRightCoordenate = j + 1;

        if (IsValidCoordinate(xTopCoordenate, yTopCoordenate))
            dot.Top = map[xTopCoordenate, yTopCoordenate];

        if (IsValidCoordinate(xBottomCoordenate, yBottomCoordenate))
            dot.Bottom = map[xBottomCoordenate, yBottomCoordenate];

        if (IsValidCoordinate(xLeftCoordenate, yLeftCoordenate))
            dot.Left = map[xLeftCoordenate, yLeftCoordenate];

        if (IsValidCoordinate(xRightCoordenate, yRightCoordenate))
            dot.Right = map[xRightCoordenate, yRightCoordenate];

        // if the dot is sea, it doesn't care
        if (!dot.IsLand())
            continue;

        var land = (Land)dot;

        if (land.HasBrodi())
        {
            if (land.IsNewDescovery())
            {
                var island = new Island();
                island.Lands.Add(land);
                islands.Add(island);

                land.Island = island;
            }
            else
            {
                land.TakeIslandFromBrodis();
            }
        }
        else
        {
            var island = new Island();
            island.Lands.Add(land);
            islands.Add(island);

            land.Island = island;
        }

    }
}

Console.WriteLine();

var biggestIsland = islands.OrderByDescending(x => x.Lands.Count).ToList().First();

Console.WriteLine($"Hay {islands.Count} islands. The most biggest island has {biggestIsland.Lands.Count} lands");

bool IsValidCoordinate(int x, int y)
{
    return x >= 0 && y >= 0 && x < xAxis && y < yAxis;
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

    public abstract bool IsLand();

    public abstract string Draw();


}

public class Land : Dot
{
    public Island Island { get; set; }

    public Land(int i, int j) : base(i, j)
    {

    }


    public bool HasBrodi()
    {
        var bros = IslandsBros();

        return bros != null ? bros.Any() : false;
    }

    public override bool IsLand() => true;

    public override string Draw() => "█";

    public void TakeIslandFromBrodis()
    {
        var lands = IslandsBros();

        Island = lands!.Where(x => x.Island != null).First().Island;

        Island.Lands.Add(this);
    }

    internal bool IsNewDescovery()
    {
        var lands = IslandsBros();

        // no valido que lands sea null por como arme la solucion,
        // solo pregunto si es nuevo descubrimiento cuando ya se que tiene hermanos

        return !(lands!.Any(x => x.Island != null));
    }

    private List<Land>? IslandsBros()
    {
        var dots = new List<Dot> { Left, Right, Top, Bottom };

        var lands = dots.Where(x => x != null && x.IsLand())?.Select(x => (Land)x).ToList();

        return lands;
    }
}

public class Sea : Dot
{
    public Sea(int i, int j) : base(i, j)
    {
    }

    public override bool IsLand() => false;
    public override string Draw() => "░";

}


public class Island
{
    public IList<Land> Lands { get; set; }

    public Island()
    {
        Lands = new List<Land>();
    }
}