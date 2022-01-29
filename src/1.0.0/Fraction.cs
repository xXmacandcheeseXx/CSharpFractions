using System;

namespace Fractions
{
    public class Fraction
    {
        public int top;
        public int bottom;

        public Fraction(int top, int bottom)
        {
            this.top = top;

            if (bottom < 0)
            {
                throw new DenominatorCannotBeNegative();
            }

            this.bottom = bottom;
        }
    }

    class DenominatorCannotBeNegative : Exception
    {
        public override string Message
        {
            get
            {
                return "Denominator cannot be negative";
            }
        }
    }
}