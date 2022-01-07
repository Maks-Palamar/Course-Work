using System;
using System.Text.RegularExpressions;

namespace PL
{
    class Getters
    {
        protected static string UppercaseFirstLetter(string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }

            return value;
        }

        protected static string GetString(string massage, bool whitespace = false, bool required = true)
        {
            string value;
            string pattern;

            if (whitespace == true)
            {
                pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ ]";
            }
            else
            {
                pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ]";
            }

            do
            {
                Console.Write(massage);
                value = Console.ReadLine();

                if (!required && value == "")
                {
                    return "";
                }

            } while (Regex.IsMatch(value, pattern) || value == "");

            return UppercaseFirstLetter(value);
        }

        protected static string GetIdentificationCode(string message = "Ідентифікаційний код робітника: ", bool required = true)
        {
            string IdentificationCode;

            do
            {
                Console.Write(message);
                IdentificationCode = Console.ReadLine();

                if (!required && IdentificationCode == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(IdentificationCode, @"(?:^|\s)(?!0+)([0-9]{10})(?:$|\s|\.|\,)"));

            return IdentificationCode;
        }

        protected static string GetBankCardNumber(string message = "Номер банківської карти: ", bool required = true)
        {
            string IdentificationCode;

            do
            {
                Console.Write(message);
                IdentificationCode = Console.ReadLine();

                if (!required && IdentificationCode == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(IdentificationCode, @"(?<!\d)\d{16}(?!\d)|(?<!\d[ _-])(?<!\d)\d{4}(?:[_ -]\d{4}){3}(?![_ -]?\d)"));

            return IdentificationCode;
        }

        protected static int GetInt(string message, int from = int.MinValue, int to = int.MaxValue, bool required = true)
        {
            string res;
            bool test = true;

            do
            {
                Console.Write(message);
                res = Console.ReadLine();

                if (!required && res == "")
                {
                    return 0;
                }

                if (Regex.IsMatch(res, @"[^0-9]") || res == "")
                {
                    continue;
                }
                else if (int.Parse(res) > to || int.Parse(res) < from)
                {
                    continue;
                }
                else
                {
                    test = false;
                }

            } while (test);

            return int.Parse(res);
        }

        protected static string GetEmail(bool required = true)
        {
            string Email;

            do
            {
                Console.Write("Email: ");

                Email = Console.ReadLine();

                if (!required && Email == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));

            return Email;
        }
    }
}
