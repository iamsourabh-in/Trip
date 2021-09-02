using System;
using System.Threading.Tasks;
using Trip.Api.Common.ExceptionHandling.Models;

namespace Trip.Api.Common.ExceptionHandling.Abstractions
{
    public interface IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception context);
    }
}
