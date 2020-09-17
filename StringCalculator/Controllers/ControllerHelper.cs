using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StringCalculator.Controllers
{
    public static class ControllerHelper
    {
        public static void ValidateAddInput(string inputNumbers, string[] numbers, ModelStateDictionary modelState)
        {
            try
            {
                if (numbers.Length < 2)
                {
                    modelState.AddModelError("InvalidInput", $"Invalid input {inputNumbers}");
                }
                else
                {
                    foreach (var item in numbers)
                    {
                        if (int.TryParse(item, out int number))
                        {
                            if (number < 0)
                            {
                                modelState.AddModelError($"{item}", $"Negatives not allowed {item}");
                            }
                        }
                        else
                        {
                            modelState.AddModelError($"{item}", $"Invalid input {inputNumbers}");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConstructClientError(ModelStateDictionary modelState)
        {
            try
            {
                string _errorMessage = "<br />";

                foreach (string error in modelState.Values.SelectMany(modelErrorCollection => modelErrorCollection.Errors).Select(modelError => modelError.ErrorMessage))
                {
                    _errorMessage += $"→ {error}.<br />";
                }

                return _errorMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
