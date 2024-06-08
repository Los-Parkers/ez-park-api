using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ez_park_platform.Shared.Infrastructure.Interfaces.Persistence.EPC.Configuration.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessage(this ModelStateDictionary dictionary)
        {
            return dictionary
                .SelectMany(m => m.Value!.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
