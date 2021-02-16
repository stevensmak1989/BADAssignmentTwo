﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodDemo
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

            for (int x = 0; x < txt.Length; x++)
            {
                if (!(char.IsNumber(txt[x])))
                {
                    ok = false;
                }


            }
            return ok;
        }

        public static bool validDigit(string txt)
        {
            bool ok = true;

            for (int x = 0; x < txt.Length; x++)
            {
                if (!(char.IsDigit(txt[x])) || char.IsPunctuation('.') == true)
                {
                    ok = false;
                }


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
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
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
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
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
    }
}