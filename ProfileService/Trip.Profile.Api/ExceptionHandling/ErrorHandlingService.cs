using EasyException.Abstractions;
using EasyException.Models;
using System;
using System.Threading.Tasks;
using Trip.Profile.Application.Exceptions;
using Trip.Profile.Domain.Exceptions;

namespace Trip.Profile.Api.ExceptionHandling
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception exception)
        {
            switch (exception)
            {
                case ProfileApiException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "ApiError", Message = exception.Message });

                case ProfileDomainException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "DomainError", Message = exception.Message });

                case ProfileApplicationException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "AppError", Message = exception.Message });

                default:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "InternalError", Message = exception.Message });
            }
        }

    }
}
