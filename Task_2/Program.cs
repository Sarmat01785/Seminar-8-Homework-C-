//                                         Задача 56: 
// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int InputNum(string message) // Метод запроса размера строк и столбцов от пользователя. И минимального и максимального значения.
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] Create2DArray(int rows, int cols) // Метод создания массива.
{
    return new int[rows, cols];
}

void Fill2DArray(int[,] array, int min, int max) // метод заполнения массива Random.
{
    Random rnd = new Random(); // создание экземпляра класса Random.
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = rnd.Next(min, max + 1);
}

void Print2DArray(int[,] array) // Метод печати массива.
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]}\t");
        Console.WriteLine();
    }
}

int FindRowWithSmallestSum(int[,] array) // Метод нахождения строки с наименьшей суммой.
{
    int smallestSum = int.MaxValue;
    int smallestSumRow = -1;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }

        if (sum < smallestSum)
        {
            smallestSum = sum;
            smallestSumRow = i;
        }
    }

    return smallestSumRow;
}

int rows = InputNum("Введите количество строк: ");
int columns = InputNum("Введите количество столбцов: ");
int minValue = InputNum("Введите минимальное значение диапазона: ");
int maxValue = InputNum("Введите максимальное значение диапазона: ");

int[,] myArray = Create2DArray(rows, columns);
Fill2DArray(myArray, minValue, maxValue);
Print2DArray(myArray);

int smallestSumRow = FindRowWithSmallestSum(myArray);
Console.WriteLine($"Строка с наименьшей суммой элементов: {smallestSumRow + 1}");
