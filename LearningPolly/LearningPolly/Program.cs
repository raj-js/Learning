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

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(nameof(LearningRetry.WaitAndRetry));
            Console.WriteLine("---------------------------------------");
            LearningRetry.WaitAndRetry();

            Console.ReadKey();
        }
    }
}
