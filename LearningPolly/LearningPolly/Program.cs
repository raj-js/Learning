using System;

namespace LearningPolly
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine(nameof(LearningRetry.Retry));
            //Console.WriteLine("---------------------------------------");
            //LearningRetry.Retry();

            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine(nameof(LearningRetry.RetryForever));
            //Console.WriteLine("---------------------------------------");
            //LearningRetry.RetryForever();

            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine(nameof(LearningRetry.WaitAndRetry));
            //Console.WriteLine("---------------------------------------");
            //LearningRetry.WaitAndRetry();

            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine(nameof(LearningRetry.WaitAndRetryForever));
            //Console.WriteLine("---------------------------------------");
            //LearningRetry.WaitAndRetryForever();

            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine(nameof(LearningCircuitBreaker.TryBasic));
            //Console.WriteLine("---------------------------------------");
            //LearningCircuitBreaker.TryBasic();

            //Console.WriteLine("---------------------------------------");
            //Console.WriteLine(nameof(LearningCircuitBreaker.TryAdvanced));
            //Console.WriteLine("---------------------------------------");
            //LearningCircuitBreaker.TryAdvanced();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(nameof(LearningFallback.Try));
            Console.WriteLine("---------------------------------------");
            LearningFallback.Try();

            Console.ReadKey();
        }
    }
}
