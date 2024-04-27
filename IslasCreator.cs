using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islitas;

public static class IslasCreator
{
    public static int[,] MapLevel1()
    {
        var rnd = new Random();

        int[,] mapa = new int[10, 10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                mapa[i, j] = rnd.Next(10, 20) < 15 ? 1 : 0;
            }
        }

        return mapa;
    }
}

