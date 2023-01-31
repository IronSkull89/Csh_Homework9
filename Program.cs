using System.Data.Common;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

int countTasks = 3;
int task;

string[] tasks = new string[countTasks];
tasks[0] = "1. Задайте значение N. Программа, которая выведет все натуральные числа в промежутке от N до 1.";
tasks[1] = "2. Задайте значения M и N. Программа, которая найдёт сумму натуральных элементов в промежутке от M до N.";
tasks[2] = "3. Программа вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.";


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

int SetNaturalNumber(string greet)
{
    Console.Write(greet);
    if (!int.TryParse(Console.ReadLine(), out int number) || number <= 0) number = SetNaturalNumber(greet);
    return number;
}

int SetNonNegativeNumber(string greet)
{
    Console.Write(greet);
    if (!int.TryParse(Console.ReadLine(), out int number) || number < 0) number = SetNonNegativeNumber(greet);
    return number;
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


// Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.

int FuncAccerman(int m, int n)
{
    if (m == 0) return n + 1;
    if (m > 0 && n == 0) return FuncAccerman(m - 1, 1);
    return FuncAccerman(m - 1, FuncAccerman(m, n - 1));
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
            PrintNumbers(SetNaturalNumber("Введите натуральное число: "));
            break;
        case 2:
            Console.WriteLine("Сумма последовательности: " + SumSequence(SetNaturalNumber("Введите натуральное начальное число последовательности: "),
                                                                         SetNaturalNumber("Введите натуральное конечное число последовательности: ")));
            break;
        case 3:
            Console.WriteLine("A(m,n) = " + FuncAccerman(SetNonNegativeNumber("Введите неотрицательный пареметр M функции Аккемана: "),
                                                         SetNonNegativeNumber("Введите неотрицательный пареметр N функции Аккемана: ")));
            break;
    }
    Console.WriteLine("\r\nВведите 'Y' для продолжения или любой другой символ для закрытия...");
    working = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(working))
    {
        working = "n";
    }
}
