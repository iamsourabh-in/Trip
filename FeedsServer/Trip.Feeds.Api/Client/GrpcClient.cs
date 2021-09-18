using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Threading;
using Trip.Creator.Api.Protos;

namespace Trip.Feeds.Api.Client
{
    public static class GrpcClient
    {

        public static async void Get()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpHandler);
            var channel = GrpcChannel.ForAddress("https://localhost:7443", new GrpcChannelOptions() { HttpClient = httpClient });
            var client = new Content.ContentClient(channel);

            try
            {
                using (var call = client.GetContent(new GetContentRequest() { }))
                {
                    while (await call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        var content = call.ResponseStream.Current;
                        Console.WriteLine(content);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
