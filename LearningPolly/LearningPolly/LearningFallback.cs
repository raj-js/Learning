using Polly;
using System;
using System.Threading.Tasks;

namespace LearningPolly
{
    class LearningFallback
    {
        public static void Try()
        {
            var avatar = Policy<UserAvatar>
                .Handle<Exception>()
                .FallbackAsync(
                
                // 降级处理
                async (res, c, cancellationToken) => 
                {
                    return await Task<UserAvatar>.Factory.StartNew(() => 
                    {
                        return UserAvatar.Blank;
                    }, cancellationToken);
                }, 

                // 失败时调用
                (res, c) => 
                {
                    Console.WriteLine($"onFallbackAsync called:{res?.Exception?.Message}");
                    return Task.CompletedTask;
                })
                .ExecuteAsync(async () => await Task.FromResult(UserAvatar.FromReal));

            Console.WriteLine($"Get User Avatar: {avatar.Result?.Url}");
        }
    }

    class UserAvatar
    {
        public string Url { get; private set; }

        public static UserAvatar Blank => new UserAvatar { Url = "default.png" };

        public static UserAvatar FromReal => throw new Exception("Server Error");
    }
}
