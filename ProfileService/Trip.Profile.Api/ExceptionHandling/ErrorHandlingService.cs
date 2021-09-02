using System;
using System.Threading.Tasks;
using Trip.Api.Common.ExceptionHandling.Abstractions;
using Trip.Api.Common.ExceptionHandling.Models;

namespace Trip.Profile.Api.ExceptionHandling
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception exception)
        {
            switch (exception)
            {
                case TripProfileApiException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "InternalError", Message = exception.Message });

                default:
                    break;
            }
            return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "Wah Wah" });
        }
    }
}
