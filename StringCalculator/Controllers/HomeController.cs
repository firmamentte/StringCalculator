using System;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.BLL;

namespace StringCalculator.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Add(string numbers)
        {
            try
            {
                #region RequestValidation

                ModelState.Clear();

                if (!string.IsNullOrWhiteSpace(numbers))
                {
                    numbers = numbers.Replace("\\n", "\n");

                    string[] _numbers;

                    if (numbers.Substring(0, 2) == StringCalculatorBLL.EnumHelper.GetEnumDescription(StringCalculatorEnum.Enum.SeparateLine))
                    {
                        string _delimiter = numbers.Substring(2, 1);

                        _numbers = numbers.Substring(numbers.IndexOf(StringCalculatorBLL.EnumHelper.GetEnumDescription(StringCalculatorEnum.Enum.NewLine)) + 1).Split(_delimiter);

                        ControllerHelper.ValidateAddInput(numbers, _numbers, ModelState);
                    }
                    else
                    {
                        _numbers = numbers.Split(StringCalculatorBLL.Separates, StringSplitOptions.RemoveEmptyEntries);

                        ControllerHelper.ValidateAddInput(numbers, _numbers, ModelState);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ControllerHelper.ConstructClientError(ModelState));
                }

                #endregion

                return Json(StringCalculatorBLL.Add(numbers));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
