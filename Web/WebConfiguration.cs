namespace Web
{
    using Domain.Common;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            return services;
        }

        public static IApplicationBuilder UseExceptionsHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;

                var error = exception.Message;
                if (exception is BaseDomainException baseDomainException)
                {
                    error = baseDomainException.Error;
                }
                var response = new { error };
                await context.Response.WriteAsJsonAsync(response);
            }));

            return app;
        }
    }
}
