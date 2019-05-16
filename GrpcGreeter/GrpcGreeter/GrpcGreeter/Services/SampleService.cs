using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.JSInterop;
using Sample;

namespace GrpcGreeter
{
    public class SampleService : Simple.SimpleBase
    {
        public override Task<SimpleResponse> DoSimpleThing(SimpleRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SimpleResponse { D = $"do simple thing with {request.Arg}" });
        }

        public override Task<OtherResp> DoOtherThing(OtherReq request, ServerCallContext context)
        {
            return Task.FromResult(new OtherResp
            {
               Code = 0,
               Msg =  "operation succeed",
               Data = Json.Serialize(request)
            });
        }
    }
}
