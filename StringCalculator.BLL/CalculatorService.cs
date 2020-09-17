using System;
using System.Collections.Generic;

namespace StringCalculator.BLL
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(string numbers)
        {
            try
            {
                int _answer = 0;

                if (string.IsNullOrWhiteSpace(numbers))
                    return _answer;

                if (numbers.Substring(0, 2) == StringCalculatorBLL.EnumHelper.GetEnumDescription(StringCalculatorEnum.Enum.SeparateLine))
                {
                    string _delimiter = numbers.Substring(2, 1);

                    string[] _numbers = numbers.Substring(numbers.IndexOf(StringCalculatorBLL.EnumHelper.GetEnumDescription(StringCalculatorEnum.Enum.NewLine)) + 1).Split(_delimiter);

                    foreach (var number in _numbers)
                    {
                        _answer += Convert.ToInt32(number);
                    }
                }
                else
                {
                    string[] _numbers = numbers.Split(StringCalculatorBLL.Separates, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var number in _numbers)
                    {
                        _answer += Convert.ToInt32(number);
                    }
                }

                return _answer;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
