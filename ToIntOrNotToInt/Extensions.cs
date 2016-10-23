using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToIntOrNotToInt
{
    public static class Extensions
    {
        public static bool IsEvenPositiveInteger(this string str)
        {
            if (str[0] == '-')
                return false; //negative
            if (str[0] == '+')
                str = str.Substring(1, str.Length - 1);

            if (str.Contains('e')) //exponential 
            {
                int eCount = str.Count(ch => ch == 'e');
                int pointCount = str.Count(ch => ch == '.');
                int plusCount = str.Count(ch => ch == '+');
                int minusCount = str.Count(ch => ch == '-');

                if (str.IndexOf('e') == 0 || str.IndexOf('e') == str.Length-1 
                                          || eCount > 1 || pointCount>1 ||plusCount>1 ||minusCount>1)
                    return false;

                if (pointCount ==1) //with point
                {
                    if (minusCount == 0 && plusCount == 0) //после e есть цифры, нет минуса и плюса
                    {
                        if (str.IndexOf('.') > str.IndexOf('e')-2)
                            return false;
                        string charsAfterPoint = new string(str.Substring(str.IndexOf('.') + 1).TakeWhile(s => s != 'e').ToArray());
                        string charsAferE = str.Substring(str.IndexOf('e') + 1);
                        int power = ToInt(charsAferE);
                        if (charsAfterPoint.Length >= power)
                            return false;
                    }
                    else if (minusCount == 0 && plusCount == 1) //если есть один плюс - должен стоять после e, но не последний
                    {
                        if (str.IndexOf('.') > str.IndexOf('e')-2)
                            return false;

                        if (str.IndexOf('+') != str.IndexOf('e') + 1 || str.IndexOf('+') == str.Length - 1)
                            return false;

                        string charsAfterPoint = new string(str.Substring(str.IndexOf('.') + 1).TakeWhile(s => s != 'e').ToArray());
                        string charsAferE = str.Substring(str.IndexOf('+') + 1);
                        int power = ToInt(charsAferE);
                        if (charsAfterPoint.Length >= power)
                            return false;
                    }
                    else
                        return false;

                }
                else //without point
                {
                    if (minusCount == 0 && plusCount == 0) //после e есть цифры, нет минуса и плюса
                    {
                        if (str.IndexOf('e') == (str.Length - 1))
                            return false;
                    }
                    else if (minusCount == 0 && plusCount == 1) //если есть один плюс - должен стоять после e, но не последний
                    {
                        if (str.IndexOf('+') != str.IndexOf('e') + 1 || str.IndexOf('+') == str.Length - 1)
                            return false;
                    }
                    else if (minusCount == 1 && plusCount == 0) //если есть один минус - должен стоять после e, но не последний
                    {
                        if (str.IndexOf('-') != str.IndexOf('e') + 1 || str.IndexOf('-') == str.Length - 1)
                            return false;

                        string charsAfterPoint = new string(str.Substring(str.IndexOf('.') + 1).TakeWhile(s => s != 'e').ToArray());
                        string charsAferE = str.Substring(str.IndexOf('-') + 1);
                        int power = ToInt(charsAferE);
                        int number = ToInt(charsAfterPoint);

                        int pow10 = 0;
                        while (number > 1)
                        {
                            if (number % 10 != 0)
                                return false;
                            number = number / 10;
                            pow10++;
                        }
                        if (power >= pow10)
                            return false;
                    }
                    else
                        return false;
                }

                str = str.Replace("+", string.Empty);
                str = str.Replace("-", string.Empty);
                str = str.Replace(".", string.Empty);
                str = str.Replace("e", string.Empty);

                return IsAllDigit(str);
            }
            return IsAllDigit(str);           
        }


        private static bool IsAllDigit(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                    return false;
            }
            return true;
        }


        public static int ToInt(string str)
        {
            str = new string(str.Reverse().ToArray());
            int integer = 0;
            int power = 1;

            foreach (var ch in str)
            {
                if (!char.IsDigit(ch))
                    throw new ArgumentException("Invalid argument", nameof(str));
                int n;
                switch ((int)ch)
                {
                    case 48:
                        n = 0;
                        break;
                    case 49:
                        n = 1;
                        break;
                    case 50:
                        n = 2;
                        break;
                    case 51:
                        n = 3;
                        break;
                    case 52:
                        n = 4;
                        break;
                    case 53:
                        n = 5;
                        break;
                    case 54:
                        n = 6;
                        break;
                    case 55:
                        n = 7;
                        break;
                    case 56:
                        n = 8;
                        break;
                    default:
                        n = 9;
                        break;
                }
                integer += n * power;
                power *= 10;
            }
            return integer;
        }
    }
}
