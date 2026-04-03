using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        var stopwatch = Stopwatch.StartNew();   // Start measuring time
        var memo = new Dictionary<int, int>();  //Disctionary for memoization
        int result = Fibonacci(40, memo);       // Calculate Fibonacci(40) with memoization
        stopwatch.Stop();

        Console.WriteLine($"Fibonacci(40) = {result}");
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Recursive Fibonacci function with memoization
    static int Fibonacci(int n, Dictionary<int, int> memo)
    {
        // Check if the result is already computed and stored in the memoization dictionary
        if (memo.ContainsKey(n))
            return memo[n];
        // Base cases for Fibonacci sequence
        if (n <= 1)
            return n;
        // Compute the Fibonacci value recursively and store it in the memoization dictionary
        memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
        return memo[n];
    }
}