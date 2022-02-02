namespace Fractions
{
    public static class FractionOperations
    {
        public static Fraction GetReciprocal(Fraction fraction)
        {
            return new Fraction(fraction.bottom, fraction.top);
        }

        public static int GetLCM(Fraction f1, Fraction f2)
        {
            int FirstNum = f1.bottom;
            int SecondNum = f2.bottom;

            int temp1 = FirstNum;
            int temp2 = SecondNum;

            while (temp1 != temp2)
            {
                if (temp1 > temp2)
                {
                    temp1 -= temp2;
                }
                else
                {
                    temp2 -= temp1;
                }
            }

            return FirstNum * SecondNum / temp1;
        }

        public static Fraction[] EvenFractions(Fraction f1, Fraction f2)
        {
            Fraction[] NewFractions = new Fraction[2];

            NewFractions[0] = new Fraction(f1.top * (GetLCM(f1, f2) / f1.bottom), GetLCM(f1, f2));
            NewFractions[1] = new Fraction(f2.top * (GetLCM(f1, f2) / f2.bottom), GetLCM(f1, f2));

            return NewFractions;
        }

        public static Fraction Add(Fraction f1, Fraction f2, bool Simplify = true)
        {
            if (f1.bottom != f2.bottom)
            {
                Fraction[] TempFractions = EvenFractions(f1, f2);
                f1 = TempFractions[0];
                f2 = TempFractions[1];
            }

            return new Fraction(f1.top + f2.top, f1.bottom);
        }

        public static Fraction Subtract(Fraction f1, Fraction f2, bool Simplify = true)
        {
            if (f1.bottom != f2.bottom)
            {
                Fraction[] TempFractions = EvenFractions(f1, f2);
                f1 = TempFractions[0];
                f2 = TempFractions[1];
            }

            return new Fraction(f1.top - f2.top, f1.bottom);
        }

        public static Fraction Multiply(Fraction f1, Fraction f2, bool Simplify = true)
        {
            if (Simplify == true)
            {
                return SimplifyFraction(new Fraction(f1.top * f2.top, f1.bottom * f2.bottom));
            }
            else
            {
                return new Fraction(f1.top * f2.top, f1.bottom * f2.bottom);
            }
        }

        public static Fraction Divide(Fraction f1, Fraction f2, bool Simplify = true)
        {
            if (Simplify == true)
            {
                return SimplifyFraction(new Fraction(f1.top * f2.bottom, f1.bottom * f2.top));
            }
            else
            {
                return new Fraction(f1.top * f2.bottom, f1.bottom * f2.top);
            }
        }

        public static double ToDecimal(Fraction fraction)
        {
            return (double)fraction.top / (double)fraction.bottom;
        }

        public static Fraction SimplifyFraction(Fraction fraction)
        {
            if (fraction.top == 0)
            {
                return new Fraction(0, 1);
            }

            bool LessThanOne = false;

            int TopPositive = 0;
            int BottomPositive = 0;

            if (fraction.top < 0)
            {
                TopPositive = fraction.top / -1;
            }
            else
            {
                TopPositive = fraction.top;
            }

            BottomPositive = fraction.bottom;

            if (TopPositive == BottomPositive && TopPositive != 0 && BottomPositive != 0)
            {
                if (fraction.top < 0 && fraction.bottom > 0)
                {
                    return new Fraction(-1, 1);
                }

                return new Fraction(1, 1);
            }

            if (fraction.top > fraction.bottom)
            {
                LessThanOne = false;
            }
            else if (fraction.bottom > fraction.top)
            {
                LessThanOne = true;
            }

            if (LessThanOne == false)
            {
                if (fraction.top > 0)
                {
                    for (int i = fraction.top; i > 0; i--)
                    {
                        if (fraction.top % i == 0 && fraction.bottom % i == 0)
                        {
                            return new Fraction(fraction.top / i, fraction.bottom / i); // POSITIVE GREATER THAN 1 FRACTIONS
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////
                else if (fraction.top < 0)
                {
                    for (int i = fraction.top; i < 0; i++)
                    {
                        if (fraction.top % i == 0 && fraction.bottom % i == 0)
                        {
                            return new Fraction(fraction.top / (i * -1), fraction.bottom / i); // NEGATIVE GREATER THAN 1 FRACTIONS
                        }
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////
            else if (LessThanOne == true)
            {
                if (fraction.bottom > 0)
                {
                    for (int i = fraction.bottom; i > 0; i--)
                    {
                        if (fraction.top % i == 0 && fraction.bottom % i == 0)
                        {
                            return new Fraction(fraction.top / i, fraction.bottom / i); // POSITIVE LESS THAN 1 FRACTIONS
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////
                else if (fraction.bottom < 0)
                {
                    for (int i = fraction.bottom; i < 0; i++)
                    {
                        if (fraction.top % i == 0 && fraction.bottom % i == 0)
                        {
                            return new Fraction(fraction.top / (i * -1), fraction.bottom / i); // NEGATIVE LESS THAN 1 FRACTIONS
                        }
                    }
                }
            }

            return new Fraction(fraction.top, fraction.bottom);
        }
    }
}