//                                Задача 58: 
//  Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//  Например, даны 2 матрицы:
//  2 4 | 3 4
//  3 2 | 3 3
//  Результирующая матрица будет:
//  18 20
//  15 18

int InputNum(string message) // Метод запроса размера строк и столбцов от пользователя.
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] Create2DArray(int rows, int cols) // Метод создания массива.
{
    return new int[rows, cols];
}

void Fill2DArray(int[,] array) // метод заполнения массива Random.
{
    Random rnd = new Random(); // создание экземпляра класса Random.
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = rnd.Next(0,100);
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

int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2) // Метод умножения матриц.
{
    int rows1 = matrix1.GetLength(0);
    int cols1 = matrix1.GetLength(1);
    int rows2 = matrix2.GetLength(0);
    int cols2 = matrix2.GetLength(1);

    if (cols1 != rows2)
    {
        throw new ArgumentException("Количество столбцов в первой матрице должно быть равно количеству строк во второй матрице.");
    }

    int[,] result = new int[rows1, cols2];

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < cols2; j++)
        {
            for (int k = 0; k < cols1; k++)
            {
                result[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }

    return result;
}

int rows1 = InputNum("Введите количество строк первой матрицы: ");
int columns1 = InputNum("Введите количество столбцов первой матрицы: ");
int rows2 = InputNum("Введите количество строк второй матрицы: ");
int columns2 = InputNum("Введите количество столбцов второй матрицы: ");

if (columns1 != rows2)
{
    Console.WriteLine("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
    return;
}

int[,] matrix1 = Create2DArray(rows1, columns1);
int[,] matrix2 = Create2DArray(rows2, columns2);

Console.WriteLine("Заполните первую матрицу:");
Fill2DArray(matrix1);
Console.WriteLine("Заполните вторую матрицу:");
Fill2DArray(matrix2);

Console.WriteLine("Первая матрица:");
Print2DArray(matrix1);
Console.WriteLine("Вторая матрица:");
Print2DArray(matrix2);

int[,] resultMatrix = MultiplyMatrices(matrix1, matrix2);
Console.WriteLine("Результирующая матрица:");
Print2DArray(resultMatrix);


