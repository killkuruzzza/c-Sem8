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
int[] rowAr = GetRowArray(array);
SortArray(rowAr);
WriteLine(String.Join(" ", rowAr));
PrintData(rowAr);

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

int[] GetRowArray(int[,] inArray)
{
    int[] result = new int[inArray.GetLength(0) * inArray.GetLength(1)];
    int index = 0;
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            result[index] = inArray[i, j];
            index++;
        }
    }
    return result;
}

void SortArray(int[] inArray)
{
    for (int i = 0; i < inArray.Length; i++)
    {
        for (int j = i + 1; j < inArray.Length; j++)
        {
            if (inArray[i] > inArray[j])
            {
                int k = inArray[i];
                inArray[i] = inArray[j];
                inArray[j] = k;
            }
        }
    }
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

void PrintData(int[] inArray)
{
    int el = inArray[0];
    int count = 1;
    for (int i = 1; i < inArray.Length; i++)
    {
        if (inArray[i] != el)
        {
            WriteLine($"{el} встречается {count}");
            el = inArray[i];
            count = 1;
        }
        else
        {
            count++;
        }
    }
    WriteLine($"{el} встречается {count}");
}
/*
61
Показать треугольник Паскаля. *Сделать вывод в виде равнобедренного треугольника.


59 //Из двумерного массива целых чисел удалить строку и столбец, 
//на пересечении которых расположен первый найденный наименьший элемент.

**Задача 1:** Задайте двумерный массив. 
Напишите программу, которая упорядочит 
по убыванию элементы каждой строки двумерного массива.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

В итоге получается вот такой массив:

1 2 4 7

2 3 5 9

2 4 4 8


**Задача 2:** Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Например, заданы 2 массива:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

и

1 5 8 5

4 9 4 2

7 2 2 6

2 3 4 7

Их произведение будет равно следующему массиву:

1 20 56 10

20 81 8 6

56 8 4 24

10 6 24 49



**Задача 4.** Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
 Напишите программу, которая будет построчно выводить массив, добавляя индексы 
 каждого элемента.

массив размером 2 x 2 x 2
int[,,]

12(0,0,0) 22(0,0,1)

45(1,0,0) 53(1,0,1)

---

**Задача 5**. Заполните спирально массив 4 на 4. 

Например, на выходе получается вот такой массив:

1 2 3 4

12 13 14 5

11 16 15 6

10 9 8 7

*/