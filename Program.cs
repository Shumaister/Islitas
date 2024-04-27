// See https://aka.ms/new-console-template for more information

using Islitas;

Console.WriteLine("Hello, World!");

var map = IslasCreator.MapLevel1();

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        Console.Write(map[i, j]);
    }
    Console.WriteLine();
}