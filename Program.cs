using System.Data.Common;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

int countTasks = 3;
int task;

string[] tasks = new string[countTasks];
tasks[0] = "1. Задайте двумерный массив. Программа, которая упорядочит по убыванию элементы каждой строки двумерного массива.";
tasks[1] = "2. Задайте прямоугольный двумерный массив. Программа, которая будет находить строку с наименьшей суммой элементов.";
tasks[2] = "3. Задайте две матрицы. Программа, которая будет находить произведение двух матриц.";


int SelectionTask(string[] tasks, int countTasks)
{
    for (int i = 0; i < countTasks; i++)
    {
        Console.WriteLine(tasks[i]);
    }

    Console.Write($"Выберите задачу (от 1 до {countTasks}): ");
    if (!int.TryParse(Console.ReadLine(), out int task) || task > countTasks || task < 1)
    {
        Console.Clear();
        task = SelectionTask(tasks, countTasks);
    }
    return task;
}

int SetNumber(string greet)
{
    Console.Write(greet);
    if (!int.TryParse(Console.ReadLine(), out int number)) number = SetNumber(greet);
    return number;
}

void Ordering(int minValue, int maxValue)
{
    if (minValue > maxValue)
    {
        int temp = minValue;
        minValue = maxValue;
        maxValue = temp;
    }
}

int[,] CreateRandomInt2DArray(int row, int column, int minValue, int maxValue)
{
    int[,] array = new int[row, column];

    Ordering(minValue, maxValue);

    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return array;
}

void PrintIntArray2D(int[,] array, int widthColumn)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0," + -widthColumn + "}", array[i, j]));
        }
        Console.WriteLine();

    }
}

void PrintIntArray3DWithIndex(int[,,] array, int widthColumn)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write(String.Format("{0," + -widthColumn + "}", array[i, j, k] + $"({i},{j},{k})"));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


// Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1.

void PrintNumbers(int n)
{
    if (n == 0) return;
    Console.Write(n + " ");
    PrintNumbers(n - 1);
}


// Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.

int SumSequence(int m, int n)
{
    if (m > n) return 0;
    return m + SumSequence(m + 1, n);
}

// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int MultiplicationElement(int[,] array1, int[,] array2, int row, int column)
{
    int count = array1.GetLength(1);
    int mult = 0;
    for (int i = 0; i < count; i++)
    {
        mult += array1[row, i] * array2[i, column];
    }
    return mult;
}

int[,] MultiplicationMatrix(int[,] array1, int[,] array2)
{
    if (array1.GetLength(0) == array2.GetLength(1) && array1.GetLength(1) == array2.GetLength(0))
    {
        int count = array1.GetLength(0);
        int[,] multArray = new int[count, count];
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                multArray[i, j] = MultiplicationElement(array1, array2, i, j);
            }
        }
        return multArray;
    }
    else return new int[1, 1];
}



//--------------------------------------------
string? working = "Y";
while (working.ToLower() == "Y".ToLower())
{
    Console.Clear();
    task = SelectionTask(tasks, countTasks);
    switch (task)
    {
        case 1:
            PrintNumbers(SetNumber("Введите натуральное число: "));
            break;
        case 2:
            Console.WriteLine("Сумма последовательности: " + SumSequence(SetNumber("Введите начальное число последовательности: "), SetNumber("Введите конечное число последовательности: ")));
            break;
        case 3:
            int countRow = SetNumber("Введите количество строк в 1-м массиве (столбцов во 2-м соответственно): ");
            int countColumn = SetNumber("Введите количество столбцов в 1-м массиве (строк во 2-м ссоответственно): ");

            int[,] array1 = CreateRandomInt2DArray(countRow, countColumn, 0, 5);
            Console.WriteLine("Матрица 1:");
            PrintIntArray2D(array1, 4);

            int[,] array2 = CreateRandomInt2DArray(countColumn, countRow, 0, 5);
            Console.WriteLine("Матрица 2:");
            PrintIntArray2D(array2, 4);

            int[,] multArray = MultiplicationMatrix(array1, array2);
            Console.WriteLine("Результат перемножения матриц:");
            PrintIntArray2D(multArray, 6);
            break;
    }
    Console.WriteLine("\r\nВведите 'Y' для продолжения или любой другой символ для закрытия...");
    working = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(working))
    {
        working = "n";
    }
}
