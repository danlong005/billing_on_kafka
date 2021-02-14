using System;

namespace billing_callbacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"command: {args[0]}");
            Console.WriteLine($"job name: {args[1]}");
            Console.WriteLine($"job count: {args[2]}");
            
            // start the correct background job based on args[0]
            
        }
    }
}
