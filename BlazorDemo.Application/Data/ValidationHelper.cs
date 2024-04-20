using BlazorDemo.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Application.Data;

public static class ValidationHelper
{
    public static bool TryValidate<T>(T obj, out List<ValidationResult> results)
    {
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        results = new List<ValidationResult>();
        return Validator.TryValidateObject(obj, context, results, validateAllProperties: true);
    }

    public static void Validate<T>(this T obj) where T : Entity
    {
        var validationSucceeded = TryValidate(obj, out List<ValidationResult> validationResults);

        if (!validationSucceeded && validationResults.Count > 0)
        {
            var errorTexts = validationResults
                .Select(x => x.ErrorMessage)
                .ToArray();

            var errorText = string.Join(", ", errorTexts);

            throw new ValidationException(errorText);
        }
    }
}
