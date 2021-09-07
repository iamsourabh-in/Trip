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
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "InternalError", Message = exception.Message });
            }
        }

    }
}
