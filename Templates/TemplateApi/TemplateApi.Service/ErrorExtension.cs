using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TemplateApi.Srevice.Extensions
{
    public static class ErrorExtension
    {
        public static IMvcBuilder AddCustom404ErrorMessages(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var modelState = actionContext.ModelState.Values;
                    return new BadRequestObjectResult(actionContext);
                };
            });

            return builder;
        }
    }
}
