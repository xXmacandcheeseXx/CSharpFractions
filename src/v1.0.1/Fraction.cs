using System;

namespace Fractions
{
    public sealed class Fraction
    {
        public int top;
        public int bottom;

        public Fraction(int top, int bottom)
        {
            this.top = top;

            if (bottom < 0)
            {
                throw new DenominatorUnderOne();
            }

            this.bottom = bottom;
        }
    }

    class DenominatorUnderOne : Exception
    {
        public override string Message
        {
            get
            {
                return "Denominator must be greater than or equal to one";
            }
        }
    }
}