# Parallel Bubble Sort in C#

This is a simple implementation of the parallel bubble sort algorithm in C# using the `Task` class for parallelization.

## Overview

Bubble sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. The parallel version of bubble sort parallelizes the comparison and swapping process to improve performance.

## How to Use

1. Clone or download the repository.
2. Open the project in your preferred C# development environment (e.g., Visual Studio).
3. Run the program.

The program will generate a random array of 100,000 elements, perform parallel bubble sort, and print the sorted array.

## Configuration

You can adjust the number of parallel tasks by modifying the `numTasks` variable in the `Main` method of the `Program.cs` file.

```csharp
int numTasks = 4; // Adjust the number of tasks based on your system capabilities


Is this problem able to be parallelized?

Yes, but with limitations: While bubble sort is inherently sequential in nature, the comparison and swapping of elements can be parallelized. However, due to the dependency of each iteration on the results of the previous one, full parallelization is challenging.
How would the problem be partitioned?

Partitioning by indices: The array can be divided into segments, and each segment can be sorted independently by a separate task. In the provided code, the array is divided into segments based on the number of tasks.
Are communications needed?

Minimal communication: Communication is minimal since each task works on its segment of the array independently. However, there may be some coordination required to check if any swaps occurred during the parallel sorting process.
Are there any data dependencies?

Yes: There is a data dependency on the swapped variable, which signals whether any swaps occurred in a particular iteration. Tasks need to coordinate to determine whether further iterations are necessary.
Are synchronization needs?

Yes: Synchronization is required to ensure that the tasks complete their sorting of the array segments before proceeding to the next iteration. In the provided code, Task.WaitAll is used for synchronization.
Will load balancing be a concern?

Yes: Load balancing may be a concern depending on the distribution of the elements in the array. Unevenly distributed elements could lead to some tasks completing their work faster than others, causing an imbalance in the workload.
