using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Trip.Api.Common.ExceptionHandling.Abstractions;
using Trip.Api.Common.ExceptionHandling.Models;

namespace Trip.Api.Common.ExceptionHandling
{
    public static class ExceptionHandlingMiddlewareExtensions
    {

        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

    }
}
