using System;

namespace Fractions
{
    public sealed class Fraction
    {
        public int top;
        public int bottom;

        public Fraction(int top, int bottom)
        {
            if (bottom < 1)
            {
                throw new ArgumentNullException("Denominator must be greater than or equal to one");
            }

            this.top = top;
            this.bottom = bottom;
        }
    }
}