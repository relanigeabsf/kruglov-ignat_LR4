using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public class Calculator : ICalculator
    {
        public double Add(double a, double b) => a + b;

        public double Sub(double a, double b) => a - b;

        public double Mul(double a, double b) => a * b;

        public double Div(double a, double b)
        {
            if (b == 0)
                throw new CalculatorException("Деление на ноль запрещено.");

            return a / b;
        }

        public double Sqrt(double x)
        {
            if (x < 0)
                throw new CalculatorException($"Нельзя извлечь корень из отрицательного числа: {x}");

            return Math.Sqrt(x);
        }
    }
}
