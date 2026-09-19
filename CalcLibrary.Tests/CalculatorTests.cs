using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calc = new Calculator();

        [Fact]
        public void Add_Works()
        {
            Assert.Equal(5, _calc.Add(2, 3));
        }

        [Fact]
        public void Sub_Works()
        {
            Assert.Equal(7, _calc.Sub(10, 3));
        }

        [Fact]
        public void Div_Works()
        {
            Assert.Equal(2.5, _calc.Div(5, 2));
        }

        [Fact]
        public void Div_ByZero_Throws()
        {
            var ex = Assert.Throws<CalculatorException>(() => _calc.Div(10, 0));
            Assert.Equal("Деление на ноль запрещено.", ex.Message);
        }

        [Fact]
        public void Sqrt_Negative_Throws()
        {
            Assert.Throws<CalculatorException>(() => _calc.Sqrt(-4));
        }


        [Fact]
        public void TryCatchFinally_ContinuesWorking()
        {
            string log = "";

            try
            {
                _calc.Div(1, 0);
                log += "не должно выполниться;";
            }
            catch (CalculatorException ex)
            {
                log += $"поймано: {ex.Message};";
            }
            finally
            {
                log += "finally выполнен;";
            }

            double result = _calc.Add(10, 20);
            log += $"результат после ошибки = {result};";

            Assert.Contains("поймано:", log);
            Assert.Contains("finally выполнен", log);
            Assert.Contains("= 30", log);
        }
    }
}
