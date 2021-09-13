using EasyException.Abstractions;
using EasyException.Models;
using System;
using System.Threading.Tasks;
using Trip.Creator.Application.Exceptions;
using Trip.Creator.Domain.Exceptions;

namespace Trip.Creator.Api.ExceptionHandling
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception exception)
        {
            switch (exception)
            {
                case CreatorApiException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "ApiError", Message = exception.Message });

                case CreatorDomainException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "DomainError", Message = exception.Message });

                case CreatorApplicationException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "AppError", Message = exception.Message });

                default:
                    {
                        var details = new Error();
                        details.Code = exception.Source;
                        details.Message = exception.StackTrace;
                        var response = new ErrorResponse()
                        {
                            Code = "InternalError",
                            Message = exception.Message,
                        };
                        response.Target = exception.TargetSite.ToString();
                        response.Details = new Error[1];
                        response.Details[0] = details;
                        return Task.FromResult<ErrorResponse>(response);
                    }
            }
        }

    }
}
