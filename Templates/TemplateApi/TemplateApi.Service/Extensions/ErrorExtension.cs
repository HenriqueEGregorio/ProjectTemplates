using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using TemplateApi.Domain.Exceptions;

namespace TemplateApi.Service.Extensions;

public static class ErrorExtension
{
    public static IMvcBuilder AddCustom400ErrorMessages(this IMvcBuilder builder)
    {
        builder.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                return new BadRequestObjectResult(actionContext.ConstructErrorMessages());
            };
        });

        return builder;
    }

    public static CustomError ConstructErrorMessages(this ActionContext context)
    {
        var customError = new CustomError();

        foreach (var keyModelStatePair in context.ModelState)
        {
            var key = keyModelStatePair.Key;
            var errors = keyModelStatePair.Value.Errors;
            if (errors != null && errors.Count > 0)
            {
                var errorMessages = new List<string>();
                for (var i = 0; i < errors.Count; i++)
                {
                    errorMessages.Add(GetErrorMessage(errors[i]));
                }

                customError.Errors.Add(key, errorMessages);
            }
        }
        return customError;
    }

    private static string GetErrorMessage(ModelError error)
    {
        return string.IsNullOrEmpty(error.ErrorMessage) ?
            "Valor inválido." :
            error.ErrorMessage;
    }
}
