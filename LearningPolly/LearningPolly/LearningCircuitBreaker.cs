using Polly;
using System;

namespace LearningPolly
{
    class LearningCircuitBreaker
    {
        public static void TryBasic()
        {
            var breaker = Policy
                // 设置熔断器处理的异常类型
                .Handle<Exception>()
                
                // 设置异常阈值 3 ，熔断持续时间 5.5 秒
                .CircuitBreaker(3, TimeSpan.FromSeconds(5.5), 
                (e, state, tspan, context)=> 
                {
                    Console.WriteLine($"OnBreak: state: {state} \r\n ex: {e.Message}");
                }, 
                context => 
                {
                    Console.WriteLine("onReset");
                },
                ()=> 
                {
                    Console.WriteLine("onHalfOpen");
                });


            var random = new Random();
            var obj = Policy<object>
                .Handle<Exception>()
                .WaitAndRetryForever(
                (times, tspan) => TimeSpan.FromSeconds(1),
                (res, times, tspan, c) =>
                {
                    Console.WriteLine($"retry: {times}, breaker state: {breaker.CircuitState}");
                })

                // 组合重试与熔断策略
                .Wrap(breaker)

                .Execute(() =>
                {
                    var val = random.Next(1, 100);
                    Console.WriteLine($"called:{val}");
                    switch (val % 9)
                    {
                        case 0:
                            return "Success";
                        default:
                            throw new Exception($"error val: {val}");
                    }
                });

            Console.WriteLine(obj);
        }

        public static void TryAdvanced()
        {
            var breaker = Policy
                .Handle<Exception>()

                // 设置高级熔断器
                .AdvancedCircuitBreaker(
                
                // 设置超过30%的失败率则熔断
                failureThreshold: 0.8,

                // 10 秒做一次采样
                samplingDuration: TimeSpan.FromSeconds(10),

                // 在采样时间内最小吞吐量
                minimumThroughput: 5,

                // 熔断持续时间
                durationOfBreak: TimeSpan.FromSeconds(10),
                onBreak: (e, state, tspan, context) => 
                {
                    Console.WriteLine($"OnBreak: state: {state} \r\n ex: {e.Message}");
                },
                onReset: context => 
                {
                    Console.WriteLine("onReset");
                },
                onHalfOpen: () => 
                {
                    Console.WriteLine("onHalfOpen");
                });


            var random = new Random();
            var obj = Policy<object>
                .Handle<Exception>()
                .WaitAndRetryForever(
                (times, tspan) => TimeSpan.FromSeconds(1),
                (res, times, tspan, c) =>
                {
                    Console.WriteLine($"retry: {times}, breaker state: {breaker.CircuitState}");
                })
                .Wrap(breaker)
                .Execute(() =>
                {
                    var val = random.Next(1, 100);
                    Console.WriteLine($"called:{val}");
                    switch (val % 9)
                    {
                        case 0:
                            return "Success";
                        default:
                            throw new Exception($"error val: {val}");
                    }
                });

            Console.WriteLine(obj);
        }
    }
}
