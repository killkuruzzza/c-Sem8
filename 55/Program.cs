//Задайте двумерный массив. Напишите программу, 
//которая заменяет строки на столбцы. В случае, 
//если это невозможно, программа должна вывести сообщение для пользователя.
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
PrintArray(ChangeArray1(array));
WriteLine();


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

int[,] ChangeArray1(int[,] array)
{
    int[,] result = new int [array.GetLength(1), array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            result[j, i] = array[i, j];
        }
    }
    return result;
}

void ChangeArray2(int[,] array)
{
    if (rows != columns)
    {
        WriteLine("В данной матрице нельзя заменить элементы!");
        return;
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = i; j < array.GetLength(1); j++)
        {
            int k = array[j, i];
            array[j, i] = array[i, j];
            array[i, j] = k;
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Write($"{array[i, j]} ");
        }
        WriteLine();
    }
}


// /* **Задача 57:**Составить частотный словарь элементов 
// двумерного массива. Частотный словарь содержит информацию о том,
//  сколько раз встречается элемент входных данных.

// { 1, 9, 9, 0, 2, 8, 0, 9 }

// 0 встречается 2 раза

// 1 встречается 1 раз

// 2 встречается 1 раз

// 8 встречается 1 раз

// 9 встречается 3 раза

// 1, 2, 3,4, 6, 1, 2, 1, 6
// 1,1,1,2,2,3,4,6,6

// 1 встречается 3 раза

// 2 встречается 2 раз

// 3 встречается 1 раз

// 4 встречается 1 раз

// 6 встречается 2 раза*\