using System;
using Nest;

namespace LearningEs
{
    class Program
    {
        private static ElasticClient _esClient;

        static void Main(string[] args)
        {
            Initialize();

            // _esClient.Update()
        }

        static void Initialize()
        {
            _esClient = new ElasticClient(new Uri("http://es:9200/"));
            _esClient.CreateIndex("_doc",
                s => s
                    .Index("model_v1")
                    .Aliases(selector => selector.Alias("file"))
                    .Mappings(m => m.Map(typeof(Model).Name, descriptor => descriptor.AutoMap()))
            );
        }

        class Model { }
    }
}
