
namespace Islitas;

public static class IslasCreator
{
    public static int[,] MapLevel1(int xAxis, int yAxis)
    {
        var rnd = new Random();

        int[,] mapa = new int[xAxis, yAxis];

        for (int i = 0; i < xAxis; i++)
        {
            for (int j = 0; j < yAxis; j++)
            {
                mapa[i, j] = rnd.Next(10, 25) < 15 ? 1 : 0;
            }
        }

        return mapa;
    }
}

