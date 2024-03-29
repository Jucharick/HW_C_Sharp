﻿// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементом массива.
// [3 7 22 2 78] -> 76

using System;
using System.Diagnostics; // пространство имен System.Diagnostics предоставляет классы, позволяющие осуществлять взаимодействие с системными процессами, журналами событий и счетчиками производительности.


// первый вариант поиска разницы между максимальным и минимальным элементом массива

Console.WriteLine("Введите длину массива:");
int n = int.Parse(Console.ReadLine());
double[] array = new Double[n];

void FillArrayDouble(double[] array, int from, int to)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = new Random().Next(from, to);
        double rand = new Random().NextDouble(); // Random.NextDouble() Возвращает случайное число с плавающей запятой, которое больше или равно 0,0 и меньше 1,0.
        array[i] = array[i] + rand;
        array[i] = Math.Round(array[i], 1);
    }
}

void PrintArray(double[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write($"{array[i]}   ");
    }
    Console.Write($"{array[array.Length - 1]}");
    Console.WriteLine();
}

void sort(double[] array) // пузырьковая сортировка
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j <= array.Length - 2; j++) // идем до предпоследнего значения для того, чтобы было место для замены последнего и предпоследнего
        {
            if (array[j] > array[j + 1]) 
            {
                double temp = array[j];
                array[j] = array[j+1];
                array[j+1] = temp;
            }
        }
    }
}

void maxMin (double[] array)
{
    double maxMin = Math.Round((array[array.Length-1] - array[0]), 1);
    Console.Write($"Max = {array[array.Length-1]};   Min = {array[0]};    разница max - min = {maxMin}");
}



FillArrayDouble(array, -5, 10);
PrintArray(array);


var stopwatch = new Stopwatch(); // класс Stopwatch() предоставляет набор методов и свойств, которые можно использовать для точного измерения затраченного времени.
stopwatch.Start();

sort(array);
// PrintArray(array);
maxMin(array);


stopwatch.Stop();
Console.WriteLine();
Console.WriteLine($"Time spent: {stopwatch.ElapsedMilliseconds}"); // 99 элементов в массиве - быстрее, чем второй метод



// второй вариант поиска разницы между максимальным и минимальным элементом массива


double findMin (double[] array)
{
    double min = array[0];
    for (int i = 0; i <= array.Length - 1; i++)
    {
        if ( min > array[i]) 
        {
            min = array[i];
        }
    }
    Console.WriteLine($"Min = {min}");
    return min;
}

double findMax (double[] array)
{
    double max = array[0];
    for (int i = 0; i <= array.Length - 1; i++)
    {
        if ( max < array[i]) 
        {
            max = array[i];
        }
    }
    Console.WriteLine($"Max = {max}");
    return max;
}

stopwatch.Restart(); // обнуляем счетчик класса Stopwatch()

Console.WriteLine();
double result = Math.Round((findMax (array) - findMin (array)), 1);
Console.WriteLine($"разница max - min = {result}");

stopwatch.Stop();
Console.WriteLine();
Console.WriteLine($"Time spent: {stopwatch.ElapsedMilliseconds}"); // 99 элементов в массиве - дольше