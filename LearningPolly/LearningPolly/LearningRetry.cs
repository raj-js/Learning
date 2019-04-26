using Polly;
using System;

namespace LearningPolly
{
    class LearningRetry
    {
        public static void Retry()
        {
            var random = new Random();

            // Policy<> 泛型定义返回值类型, 如若不需要返回值， 可直接使用 Policy
            var obj = Policy<object>

                // Handle<> 可指定需要处理的异常类型
                .Handle<Exception>()

                //也可以使用重载对Exception 进行再次过滤
                //.Handle<Exception>(e => e is NotSupportedException)                

                .Retry(3, (res, i, c) =>
                {
                    //当委托的代码块执行失败时会进入此 Action, 
                    //这里可以对抛出的异常进行日志或其他处理
                    Console.WriteLine($"retry {i}th times, ex: {res.Exception?.Message}");
                })
                .Execute(() =>
                {
                    var val = random.Next(0, 100);
                    switch (val % 3)
                    {
                        case 0:
                            return "Success";
                        default:
                            throw new Exception($"random val: {val}");
                    }
                });

            Console.WriteLine(obj);
        }

        public static void RetryForever()
        {
            var random = new Random();

            // Policy<> 泛型定义返回值类型, 如若不需要返回值， 可直接使用 Policy
            var obj = Policy<object>

                // Handle<> 可指定需要处理的异常类型
                .Handle<Exception>()

                //也可以使用重载对Exception 进行再次过滤
                //.Handle<Exception>(e => e is NotSupportedException)                

                .RetryForever((res, i, c) =>
                {
                    //当委托的代码块执行失败时会进入此 Action, 
                    //这里可以对抛出的异常进行日志或其他处理
                    Console.WriteLine($"retry {i}th times, ex: {res.Exception?.Message}");
                })
                .Execute(() =>
                {
                    var val = random.Next(0, 100);
                    switch (val % 999)
                    {
                        case 0:
                            return $"Success, val: {val}";
                        default:
                            throw new Exception($"random val: {val}");
                    }
                });

            Console.WriteLine(obj);
        }

        public static void WaitAndRetry()
        {
            var random = new Random();

            // Policy<> 泛型定义返回值类型, 如若不需要返回值， 可直接使用 Policy
            var obj = Policy<object>

                // Handle<> 可指定需要处理的异常类型
                .Handle<Exception>()

                //也可以使用重载对Exception 进行再次过滤
                //.Handle<Exception>(e => e is NotSupportedException)                

                .WaitAndRetry(5, 
                
                // 设置 Sleep Duration Provider 来提供延迟时间
                retryTimes => TimeSpan.FromSeconds(Math.Pow(2, retryTimes)),

                (res, delay, times, context) =>
                {
                    //当委托的代码块执行失败时会进入此 Action, 
                    //这里可以对抛出的异常进行日志或其他处理
                    Console.WriteLine($"retry {times}th times, sleep: {delay.TotalSeconds}s, ex: {res.Exception?.Message}");
                })
                .Execute(() =>
                {
                    var val = random.Next(0, 100);
                    switch (val % 3)
                    {
                        case 0:
                            return "Success";
                        default:
                            throw new Exception($"random val: {val}");
                    }
                });

            Console.WriteLine(obj);
        }

        public static void WaitAndRetryForever()
        {
            var random = new Random();

            // Policy<> 泛型定义返回值类型, 如若不需要返回值， 可直接使用 Policy
            var obj = Policy<object>

                // Handle<> 可指定需要处理的异常类型
                .Handle<Exception>()

                //也可以使用重载对Exception 进行再次过滤
                //.Handle<Exception>(e => e is NotSupportedException)                

                .WaitAndRetryForever(

                // 设置 Sleep Duration Provider 来提供延迟时间
                (retryTimes, res, context) => TimeSpan.FromSeconds(Math.Pow(2, retryTimes)),

                (res, times, delay, context) =>
                {
                    //当委托的代码块执行失败时会进入此 Action, 
                    //这里可以对抛出的异常进行日志或其他处理
                    Console.WriteLine($"retry {times}th times, sleep: {delay.TotalSeconds}s, ex: {res.Exception?.Message}");
                })
                .Execute(() =>
                {
                    var val = random.Next(0, 100);
                    switch (val % 3)
                    {
                        case 0:
                            return "Success";
                        default:
                            throw new Exception($"random val: {val}");
                    }
                });

            Console.WriteLine(obj);
        }
    }
}
