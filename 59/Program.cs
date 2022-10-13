//Из двумерного массива целых чисел удалить строку и столбец, 
//на пересечении которых расположен первый найденный наименьший элемент.
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
WriteLine($"Минимальный элемент находится -> {String.Join(" ",GetIndexMinEl(array))}" );
WriteLine();
PrintArray(GetResultArray(array, GetIndexMinEl(array)));

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
// Функция для поиска идекса минимального элемента
int[] GetIndexMinEl(int[,] inArray)
{
    int[] result = new int[]{0,0};
    int min=inArray[0,0];
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if(min>inArray[i,j])
            {
                min=inArray[i,j];
                result[0]=i;
                result[1]=j;
            }
        }
    }
    return result;
}
//Функция для финального массива,без строчки и стобца.В ней мы 
//ничего не удаляем,просто создаем новый массив и записываем в него все кроме стобца и строки 
//которые нужно удалить
int[,] GetResultArray(int[,] inArray, int[] indexes) // indexes[0] = 2, indexes[1] = 2 
{
    int[,] result = new int[inArray.GetLength(0) - 1, inArray.GetLength(1) - 1];
    int row = 0;
    int column = 0;
    for (int i = 0; i < inArray.GetLength(0); i++)// перебор строк 
    {
        if (i == indexes[0]) continue;
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if (j == indexes[1]) continue;
            result[row, column] = inArray[i, j];
            column++;
        }
        column = 0;
        row++;
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

