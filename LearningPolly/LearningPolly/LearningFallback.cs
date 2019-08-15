using Polly;
using System;

namespace LearningPolly
{
    class LearningFallback
    {
        private const string PolicyKey = "policy_key";

        private static Policy Resilience =>
           Policy.Wrap(

               Policy
                .Handle<Exception>()
                .WaitAndRetry(5, t => TimeSpan.FromSeconds(1)),

               Policy
                .Handle<Exception>()
                .CircuitBreaker(3, TimeSpan.FromSeconds(10),
                    (e, s, t, c) =>
                    {
                        Console.WriteLine("break");
                    },
                    c =>
                    {
                        Console.WriteLine("reset");
                    },
                    () =>
                    {
                        Console.WriteLine("half open");
                    }
                )
               );

        private static Policy<T> CreatePolicy<T>(Policy<T> fallback, Func<T> previous)
        {
            return Policy<T>
                .Handle<Exception>()
                .Fallback(
                    () =>
                        fallback == null ?
                            previous() :
                            fallback.Execute(previous)
                )
                .Wrap(Resilience);
        }

        public static void Try()
        {
            Policy<UserAvatar> policy = null;

            policy = CreatePolicy(
                policy, previous: () =>
                {
                    Console.WriteLine("in memory");
                    return UserAvatar.InMemory;
                }
            );

            policy = CreatePolicy(
                policy, previous: () =>
                {
                    Console.WriteLine("mysql");
                    return UserAvatar.MySql;
                }
            );

            var avatar = policy.Execute(() =>
            {
                Console.WriteLine("redis");
                return UserAvatar.Redis;
            });

            Console.WriteLine(avatar.Url);
        }
    }

    class UserAvatar
    {
        public string Url { get; private set; }

        public static UserAvatar Redis => throw new Exception("Server Error");

        public static UserAvatar MySql => throw new Exception("Server Error");

        public static UserAvatar InMemory => new UserAvatar { Url = "default.png" };
    }
}
