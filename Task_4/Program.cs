//                                Задача 60.
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


using System; // директива препроцессора для подключения пространства имен System.

class Program // определение класса Program.
{
    static void Main() // точка входа в программу.
    {
        // Создание трехмерного массива размером 2x2x2
        int[,,] array = Create3DArray(2, 2, 2);

        // Вывод трехмерного массива на консоль
        Print3DArray(array);
    }

    static int[,,] Create3DArray(int rows, int cols, int depth)
    {
        // Создание трехмерного массива заданного размера
        int[,,] array = new int[rows, cols, depth];

        // Создание объекта для генерации случайных чисел
        Random rnd = new Random();

        // Заполнение трехмерного массива случайными числами
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    int num;
                    do
                    {
                        // Генерация случайного числа от 10 до 99
                        num = rnd.Next(10, 100);
                    } while (IsNumberUsed(array, num));

                    // Присвоение сгенерированного числа элементу массива
                    array[i, j, k] = num;
                }
            }
        }

        // Возвращение заполненного трехмерного массива
        return array;
    }

    static bool IsNumberUsed(int[,,] array, int num)
    {
        // Проверка, встречается ли число в трехмерном массиве
        foreach (int element in array)
        {
            if (element == num)
            {
                return true;
            }
        }

        return false;
    }

    static void Print3DArray(int[,,] array)
    {
        // Вывод трехмерного массива на консоль
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    // Вывод значения элемента массива и его индексов
                    Console.Write($"{array[i, j, k]}({i},{j},{k})\t");
                }
                Console.WriteLine();
            }
            
        }
    }
}


