using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] array = GenerateRandomArray(100000);
        int numTasks = 6; // You can adjust the number of tasks based on your system capabilities

        Console.WriteLine($"Sorting array using parallel bubble sort with {numTasks} tasks...");
        var watch = System.Diagnostics.Stopwatch.StartNew();
        int[] sortedArray = ParallelBubbleSort(array, numTasks);
        watch.Stop();

        Console.WriteLine("\nSorted array:");
        PrintArray(sortedArray);

        Console.WriteLine($"\nSorted in {watch.ElapsedMilliseconds} ms");
    }

    static int[] ParallelBubbleSort(int[] array, int numTasks)
    {
        int n = array.Length;
        bool swapped;

        do
        {
            swapped = false;

            Task[] tasks = new Task[numTasks];

            for (int i = 0; i < numTasks; i++)
            {
                int taskIndex = i; // Capture the loop variable
                tasks[i] = Task.Run(() =>
                {
                    for (int k = taskIndex; k < n - 1; k += numTasks)
                    {
                        if (array[k] > array[k + 1])
                        {
                            // Swap elements if they are in the wrong order
                            int temp = array[k];
                            array[k] = array[k + 1];
                            array[k + 1] = temp;
                            swapped = true;
                        }
                    }
                });
            }

            Task.WaitAll(tasks);

        } while (swapped);

        return array;
    }

    static int[] GenerateRandomArray(int length)
    {
        int[] array = new int[length];
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(1000000); // Adjust the range based on your requirements
        }

        return array;
    }

    static void PrintArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }
}