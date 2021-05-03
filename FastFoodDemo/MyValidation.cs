using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class MyValidation
    {
        public static bool validLength(string txt, int min, int max)
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txt))
                ok = false;
            else if (txt.Length < min || txt.Length > max)
                ok = false;

            return ok;
        }

        public static bool validChar(Char txt, Char min, Char max)
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(Char.ToString(txt)))
                ok = false;
            else if (Char.ToUpper(txt) != 'F' && Char.ToUpper(txt) != 'M')
                ok = false;

            return ok;
        }

        public static bool validNumber(string txt)
        {
            bool ok = true;
            //string pattern = " ^ *[0-9/.]+$";

            if (Regex.IsMatch(txt, @"^[0-9]+$"))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        public static bool validDigit(string txt)
        {
            bool ok = true;
            int size = txt.Length;
            string pattern = " ^ *[0-9/.]+$"; //^[0-9\.]+$ 


            if ( Regex.IsMatch(txt, @"^\d+\.[0-9]\d*$"))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            
            return ok;
        }

        public static bool validLetter(string txt) //allows alphabetic characters
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validLetterWhiteSpace(string txt) //allows alphabetic characters + whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validLetterNumberWhiteSpace(string txt)//allows alphanumeric characters + whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(char.IsNumber(txt[x])))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validForename(string txt)//allows alphabetic, dash and whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-') && char.IsPunctuation(txt[x])))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validSurname(string txt)//allows alphabetic characters + whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-') && char.IsPunctuation(txt[x])))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validEmail(string txt)//allows alphabetic characters + whitespace
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsNumber(txt[x])) && !((txt[x].Equals('@'))) && !((txt[x].Equals('-'))) && !((txt[x].Equals('_'))) && !((txt[x].Equals('.'))))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validDogColour(string txt) //allows alphabetic characters + whitespace
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !((txt[x].Equals('-'))) && !((txt[x].Equals('/'))) && !((txt[x].Equals('&'))) && !((txt[x].Equals(' '))))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validDOB(string txt)
        {
            DateTime currentDate = DateTime.Now;
            DateTime DOB = Convert.ToDateTime(txt);

            TimeSpan t = currentDate - DOB;
            double noOfDays = t.TotalDays;

            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                if (noOfDays <= 5848)
                    ok = false;
            }
            return ok;
        }
        public static bool validStartWeek(string txt)
        {
            DateTime currentDate = DateTime.Now;
            DateTime DOB = Convert.ToDateTime(txt);

            TimeSpan t = currentDate - DOB;
            double noOfDays = t.TotalDays;

            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                if (noOfDays <= 5848)
                    ok = false;
            }
            return ok;
        }

        public static bool validDays(string txt, int Min)
        {
            DateTime currentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime DOB = Convert.ToDateTime(txt);

            TimeSpan t = DOB -currentDate ;
            double noOfDays = t.TotalDays;

            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                if (noOfDays < Min)
                    ok = false;
            }
            return ok;
        }

        public static Boolean validTimespan(DateTime txt)
        {
            //DateTime currentDate = DateTime.Now;
            //DateTime DOB = Convert.ToDateTime(txt);
            String str = txt.ToLongTimeString();
            DateTime temp = DateTime.Parse(str);
            //TimeSpan t = DOB - currentDate;
            //double noOfDays = t.TotalDays;

            bool ok = true;
            if(temp != null)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            
            return ok;
        }

        public static Boolean validTimespan1(string txt)
        {
            //DateTime currentDate = DateTime.Now;
            //DateTime DOB = Convert.ToDateTime(txt);
            String str = Convert.ToString(txt);
          //  DateTime temp = DateTime.Parse(str);
            string pattern = "\\d{1,2}:\\d{2}";

            //TimeSpan t = temp.TimeOfDay;
            //string tempTime = t.ToString();
            ////double noOfDays = t.TotalDays;
            
            bool ok = true;
            if (Regex.IsMatch(str, pattern, RegexOptions.CultureInvariant))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }


        public static Boolean validPCode(string txt)
        {
            Boolean ok = true;
            String str = Convert.ToString(txt);
          
            string pattern = "\\d{1,2}:\\d{2}";

            if (Regex.IsMatch(txt, @"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})"))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;

            
        }
        public static String firstLetterEachWordToUpper(string word) // not working
        {
            Char[] array = word.ToCharArray();

            if (Char.IsLower(array[0]))
            {
                array[0] = Char.ToUpper(array[0]);
            }
            //checks for space

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (Char.IsLower(array[i]))
                    {
                        array[i] = Char.ToUpper(array[i]);
                    }

                }
                else
                {
                    array[i] = Char.ToLower(array[i]);
                }
            }
            return new string(array);
        }

        public static String EachLetterToUpper(String word)
        {
            Char[] array = word.ToCharArray();

            for (int x = 0; x < array.Length; x++)
            {
                if (Char.IsLower(array[x]))
                {
                    array[x] = Char.ToUpper(array[x]);
                }
            }
            return new String(array);
        }



        public static bool validEmailNew(string txt)//allows alphabetic characters + whitespace
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                if(!(txt.Contains('@')) || !(txt.Contains('.')))
                {
                    ok = false;
                }
            }
            return ok;
        }
    }
}
