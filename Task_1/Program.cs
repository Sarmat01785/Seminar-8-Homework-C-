// Задача 54:
// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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
void SortingAnArray(int[,] array, int rows, int cols) // Метод сортировки.
{
    // Проходим по каждой строке массива
    for (int i = 0; i < rows; i++)
    {
        // Проходим по каждому элементу строки
        for (int j = 0; j < cols; j++)
        {
            // Сравниваем текущий элемент с каждым элементом строки после него
            for (int k = j + 1; k < cols; k++)
            {
                // Если текущий элемент меньше следующего - меняем их местами
                if (array[i, j] < array[i, k])
                {
                    int temp = array[i, j];
                    array[i, j] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
    }
}

int rows = InputNum("Введите количество строк: ");
int columns = InputNum("Введите количество столбцов: ");
int minValue = InputNum("Введите минимальное значение диапазона: ");
int maxValue = InputNum("Введите максимальное значение диапазона: ");

int[,] myArray = Create2DArray(rows, columns);
Fill2DArray(myArray, minValue, maxValue);
Print2DArray(myArray);
SortingAnArray(myArray, rows, columns);
Console.WriteLine("Отсортированный массив:");
Print2DArray(myArray);
