using EasyException.Abstractions;
using EasyException.Models;
using System;
using System.Threading.Tasks;

namespace Trip.Feeds.Api.ExceptionHandling
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
