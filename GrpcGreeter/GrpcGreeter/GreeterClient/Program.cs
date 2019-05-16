using System;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Greet;
using Grpc.Core;
using Sample;

namespace GreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest {Name = "Raj"});
            Console.WriteLine($"Greeting: {reply.Message}");

            var sampleClient = new Simple.SimpleClient(channel);
            var simpleReply = await sampleClient.DoSimpleThingAsync(new SimpleRequest {Arg = "Raj"});
            Console.WriteLine($"simple reply: {simpleReply.D}");

            var otherReq = new OtherReq
            {
                A = "1",
                B = 2,
                C = false
            };
            otherReq.D.Add("r1");
            otherReq.D.Add("r2");
            otherReq.D.Add("r3");
            var otherReply = await sampleClient.DoOtherThingAsync(otherReq);
            Console.WriteLine($"other reply: {otherReply.Code}, {otherReply.Msg}, {otherReply.Data}");

            await channel.ShutdownAsync();
            Console.ReadKey();
        }
    }
}
