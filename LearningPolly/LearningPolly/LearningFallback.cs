using Polly;
using System;

namespace LearningPolly
{
    class LearningFallback
    {
        public static void Fallback()
        {
            //Policy
            //   .Handle<Exception>()
            //   .Fallback()
        }
    }
}
