﻿/* 
https://acmp.ru/index.asp?main=task&id_task=875
Игра «Жизнь» была придумана английским математиком Джоном Конвейем в 1970 году.
    Впервые описание этой игры опубликовано в октябрьском выпуске (1970) журнала Scientic American,
    в рубрике «Математические игры» Мартина Гарднера.

Место действия этой игры – «вселенная» – это размеченная на клетки поверхность.
    Каждая клетка на этой поверхности может находиться в двух состояниях:
    быть живой или быть мертвой. Клетка имеет восемь соседей.
    Распределение живых клеток в начале игры называется первым поколением. 
    Каждое следующее поколение рассчитывается на основе предыдущего по таким правилам:

1)пустая (мертвая) клетка с ровно тремя живыми клетками-соседями оживает;
2)если у живой клетки есть две или три живые соседки, то эта клетка продолжает жить;
    в противном случае (если соседок меньше двух или больше трех)
    клетка умирает (от «одиночества» или от «перенаселенности»).
В этой задаче рассматривается игра «Жизнь» на торе.
    Представим себе прямоугольник размером n строк на m столбцов.
    Для того, чтобы превратить его в тор мысленно «склеим» его верхнюю сторону с нижней, а левую с правой.

Таким образом, у каждой клетки, даже если она раньше находилась на границе прямоугольника,
    теперь есть ровно восемь соседей.

Ваша задача состоит в том, чтобы найти конфигурацию клеток,
    которая будет через k поколений от заданного.

Входные данные:
    Первая строка cодержит три целых числа: 
    n, m, k (4 ≤ n, m ≤ 100; 0 ≤ k ≤ 100). 
    Последующие n строк содержат по m символов каждая и описывают начальную конфигурацию.
    j-ый символ i-ой строки равен «.» (точка), если соответствующая клетка мертва, 
    и «*» (звездочка) – если жива.

Выходные данные
    Выведите конфигурацию клеток через k поколений после начального в том же формате,
    в каком конфигурация задается во входном файле.
Пример:
	5 5 1
**...       .*.**
..**.       *.*..
.*...       .*.*.
..*..       ..*..
...*.	    .**..

*/
//Функция для ввода начального положения клеток
string[,] InputСonfiguration(int n, int m, int k)
{
    string[,] result = new string[n, m];
    for (int i = 0; i < n; i++)
    {

        //Cчитываем строку перебираем каждый ее элемент и записываем их в массив
        //(когда мы берем один элемент строки он переводится в тип данных char,
        // нам нужно перевести его обратно в строку)
        int j = 0;
        foreach (char s in Console.ReadLine())
        {
            result[i, j] = s.ToString();
            j++;
        }
    }
    return result;
}
//Для вывода двумерного массива
void PrintArray(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}");
            if (array[i, j] == "")
                Console.Write($" ");

        }

        Console.WriteLine("!");
    }

}
//Функция возвращает true если клетка будет жить и false если нет.
bool LiveOrDie(string[,] array, int i, int j)
{
    int count = 0;
    //Count считает живых соседей
    //Перебор всех 8 соседей клетки
    count += array[i, j - 1] == "+" ? 1 : 0;
    count += array[i - 1, j - 1] == "+" ? 1 : 0;
    count += array[i - 1, j] == "+" ? 1 : 0;
    count += array[i - 1, j + 1] == "+" ? 1 : 0;
    count += array[i + 1, j - 1] == "+" ? 1 : 0;
    count += array[i + 1, j] == "+" ? 1 : 0;
    count += array[i + 1, j + 1] == "+" ? 1 : 0;
    count += array[i, j + 1] == "+" ? 1 : 0;
    //По условию если 3 живых клетки либо оживляют мертвую клетку, либо ничего не меняется
    if (count == 3)
        return true;
    //Если у живой клетки 2 соседки, то она будет дальше жить
    if (count == 2 && array[i, j] == "+")
        return true;
    //В любых других случаях клетка умирает
    return false;

}
//Соединяет нижнюю и верхнюю строчку, правый и левый столбец
string[,] AddRowColumm(string[,] array)
{
    //Cоздаем новый массив в котором будет больше на два столбца и две строки
    string[,] result = new string[array.GetLength(0) + 2, array.GetLength(1) + 2];
    //Переписываем изначальный массив начиная с индексов 1 1
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {

            result[i + 1, j + 1] = array[i, j];
        }
    }
    //Записываем в самый верх нового массива нижнюю строку изначального и
    //в самый низ нового маccива верхнюю строчку исходного
    //индексы элементов строки в новом массиве начинаются с 1
    for (int j = 1; j <= array.GetLength(1); j++)
    {
        result[0, j] = array[array.GetLength(0) - 1, j - 1];
        result[result.GetLength(0) - 1, j] = array[0, j - 1];
    }
    //В самый правй столбец нового массива записываем самый левый столбец исходного
    //И  наоборот в самый левый столбец нового записываем самый правый исходного
    //Инекс элементов столбца в новом массиве так же начинаются с 1
    for (int j = 1; j <= array.GetLength(0); j++)
    {
        result[j, 0] = array[j - 1, array.GetLength(1) - 1];
        result[j, result.GetLength(1) - 1] = array[j - 1, 0];
    }
    //Левый верхний угол нового массива равен правому нижнему исходного
    //Левый нижний угол нового массива равен правому верхнему исходного
    //Правый верхний угол нового массива равен левому нижнему исходного
    //Правый нижний угол нового массива равен левому верхнему исходного 
    result[0, 0] = array[array.GetLength(0) - 1, array.GetLength(1) - 1];
    result[0, result.GetLength(1) - 1] = array[array.GetLength(0) - 1, 0];
    result[result.GetLength(0) - 1, 0] = array[0, array.GetLength(1) - 1];
    result[result.GetLength(0) - 1, result.GetLength(1) - 1] = array[0, 0];
    return result;
}
//Симуляция на n циклов
//(Меняем массив array)
void SimNStep(string[,] array, int n)
{
    //Цикл для n циклов
    for (int i = 0; i < n; i++)
    {
        //array2 - массив с добавлеными строчками и стобцами
        //Доп строчки нужны что бы удобно посчитать соседей клеток
        // которые находятся по краям поля
        //На каждом шаге цикла нужно заново добавлять строчки 
        //так как на каждом шаге цикла меняется массив array
        string[,] array2 = AddRowColumm(array);
        //Вложеные циклы для перебора элементов двумерного массива
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int k = 0; k < array.GetLength(1); k++)
            {
                //Если метод LiveOrDie Вернул true клетка жива("*")
                //Если false то мертва(".")
                array[j, k] = LiveOrDie(array2, j + 1, k + 1) ? "+" : ".";
            }
        }

    }
}

int a = int.Parse(Console.ReadLine()), b =int.Parse(Console.ReadLine()), c = int.Parse(Console.ReadLine());
string[,] test = InputСonfiguration(a, b, c);
Console.WriteLine("-------------------------");
PrintArray(test);
Console.WriteLine("-------------------------");
SimNStep(test, c);
PrintArray(test);