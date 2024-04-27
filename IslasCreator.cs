using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                mapa[i, j] = rnd.Next(10, 40) < 15 ? 1 : 0;
            }
        }

        return mapa;
    }
}

