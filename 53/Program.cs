//Задайте двумерный массив. Напишите программу, 
//которая поменяет местами первую и последнюю строку массива.
using System;
using static System.Console;

Clear();

Write("Введите количество строк массива: ");
int rows = int.Parse(ReadLine());
Write("Введите количество столбцов массива: ");
int columns = int.Parse(ReadLine());
int[,] array = GetArray(rows, columns, 0, 10);
PrintArray(array);
WriteLine();
ChangeRows(array);
PrintArray(array);

int[,] GetArray(int m, int n, int min, int max)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }

    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j]} ");
        }
        WriteLine();
    }
}

void ChangeRows(int[,] inArray)
{
    int rowCount = inArray.GetLength(0) - 1;
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        int k = inArray[0, i];
        inArray[0, i] = inArray[rowCount, i];
        inArray[rowCount, i] = k;
    }
}

