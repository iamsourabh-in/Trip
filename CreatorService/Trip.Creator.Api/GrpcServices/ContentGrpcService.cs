using Grpc.Core;
using System.Threading.Tasks;
using Trip.Creator.Api.Protos;

namespace Trip.Creator.Api.GrpcServices
{
    public class ContentGrpcService : Content.ContentBase
    {
        public ContentGrpcService()
        {

        }

        public async override Task GetContent(GetContentRequest request, IServerStreamWriter<GetContentReply> response, ServerCallContext serverCallContext)
        {
            await response.WriteAsync(new GetContentReply() { Message = "Hi from Grpc" });
        }
    }
}
