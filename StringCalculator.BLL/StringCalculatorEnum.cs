
namespace StringCalculator.BLL
{
    public class StringCalculatorEnum
    {
        public enum Enum
        {
            [StringCalculatorBLL.EnumDescription("//")]
            SeparateLine,
            [StringCalculatorBLL.EnumDescription("\n")]
            NewLine
        }
    }
}
