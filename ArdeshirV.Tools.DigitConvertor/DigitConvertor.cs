#region Header

// Assembly Information
// AssemblyInfo.cs : Provides Information of Assembly
// Copyright© 2010-2021 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Text;
using System.Drawing;
using ArdeshirV.Tools.DigitConvertor.Properties;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Tools.DigitConvertor
{
	public class DigitConvertorType {}
	
    public static class DigitConvertor
    {
        #region Variables

        private const string m_strSpace = " ";
        private const string m_strZero = "صفر";
        private const string m_strNegative = "منفي";
        private const string m_strArabicDigits  = "٠١٢٣٤٥٦٧٨٩";
        private const string m_strPersianDigits = "۰۱۲۳۴۵۶۷۸۹";
        private const string m_strWesternDigits = "0123456789";
        private static readonly string m_strO = "فُ"[1].ToString();
        private const string m_strExp = "The number is too large on DigitConvertor";
        private static readonly string[] m_strDigits1 = { "يك", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
        private static readonly string[] m_strDigitsX = { "هزار", "ميليون", "ميليارد", "تريليون", "كاتاتريليون", "سنكتريليون" };
        private static readonly string[] m_strDigits11 = { "يازده", "دوازده", "سيزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
        private static readonly string[] m_strDigits10 = { "ده", "بيست", "سي", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        private static readonly string[] m_strDigits100 = { "صد", "دويست", "سيصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };

        #endregion
        //---------------------------------------------------------------------
        #region Static Methods

        public static string ConvertDigitalNumberToPersian(decimal decNumber)
        {
            decimal D1, D2, D3;
            decimal Digits = 0;
            decimal decLastMul = 1, decMul = 1;
            StringBuilder l_strResult = new StringBuilder();
            bool blnNegative = (decNumber < 0);

            if (blnNegative)
                decNumber = -decNumber;
            else if (decNumber == 0)
            {
                l_strResult.Append(m_strZero);
                goto end_ConvertDigitalNumberToPersian;
            }

            for (int intCounter = 0; decMul <= decNumber; intCounter++)
            {
                if (intCounter > 6) throw new Exception(m_strExp);
                decMul = (decimal)Math.Pow(1000, intCounter + 1);
                Digits = Math.Truncate(decNumber % decMul / decLastMul);

                if (Digits == 0)
                {
                    decLastMul = decMul;
                    continue;
                }

                if (intCounter >= 1)
                {
                    l_strResult.Insert(0, m_strDigitsX[(int)intCounter - 1]);
                    l_strResult.Insert(0, m_strSpace);
                }

                D1 = Math.Truncate(Digits % 10 / 1);
                D2 = Math.Truncate(Digits % 100 / 10);
                D3 = Math.Truncate(Digits % 1000 / 100);

                if (D2 == 1 && D1 != 0)
                {
                    l_strResult.Insert(0, m_strDigits11[(int)D1 - 1]);
                    l_strResult.Insert(0, m_strSpace);
                }
                else
                {
                    if (D1 >= 1)
                    {
                        l_strResult.Insert(0, m_strDigits1[(int)D1 - 1]);
                        l_strResult.Insert(0, m_strSpace);
                    }

                    if (D2 >= 1)
                    {
                        l_strResult.Insert(0, m_strDigits10[(int)D2 - 1]);
                        l_strResult.Insert(0, m_strSpace);
                    }
                }

                if (D3 >= 1)
                {
                    l_strResult.Insert(0, m_strDigits100[(int)D3 - 1]);
                    l_strResult.Insert(0, m_strSpace);
                }

                decLastMul = decMul;
            }

            if (blnNegative)
                l_strResult.Insert(0, m_strNegative);

        end_ConvertDigitalNumberToPersian:
            return l_strResult.ToString();
        }
        //---------------------------------------------------------------------
        private static string ToDestinationLanguage(
            string strStringContentNumbers, string[] strArrSource, string strArrDest)
        {
            char l_chrTemp;
            StringBuilder l_sbdTemp = new StringBuilder(strStringContentNumbers.Length);

            foreach (char c in strStringContentNumbers)
            {
                l_chrTemp = c;

                for (int l_intIndex = 0; l_intIndex < strArrDest.Length; l_intIndex++)
                {
                    foreach (string strLanguage in strArrSource)
                    {
                        if (c == strLanguage[l_intIndex])
                        {
                            l_chrTemp = strArrDest[l_intIndex];
                            goto break_for;
                        }
                    }
                }

            break_for:
                l_sbdTemp.Append(l_chrTemp);
            }

            return l_sbdTemp.ToString();
        }
        //---------------------------------------------------------------------
        public static bool IsArabicDigit(char chrNumber)
        {
            foreach (char c in m_strArabicDigits)
                if (chrNumber == c)
                    return false;

            return true;
        }
        //---------------------------------------------------------------------
        public static bool IsPersianDigit(char chrNumber)
        {
            foreach (char c in m_strPersianDigits)
                if (chrNumber == c)
                    return false;

            return true;
        }
        //---------------------------------------------------------------------
        public static bool IsWesternDigit(char chrNumber)
        {
            foreach (char c in m_strWesternDigits)
                if (chrNumber == c)
                    return false;

            return true;
        }
        //---------------------------------------------------------------------
        public static bool IsContentsOnlyWesternDigits(string strNumbers)
        {
            foreach (char c in strNumbers)
            {
                foreach (char n in m_strPersianDigits)
                    if (c == n)
                        return false;

                foreach (char n in m_strArabicDigits)
                    if (c == n)
                        return false;
            }

            return true;
        }
        //---------------------------------------------------------------------
        public static bool IsContentsOnlyPersianDigits(string strNumbers)
        {
            foreach (char c in strNumbers)
            {
                foreach (char n in m_strWesternDigits)
                    if (c == n)
                        return false;

                foreach (char n in m_strArabicDigits)
                    if (c == n)
                        return false;
            }

            return true;
        }
        //---------------------------------------------------------------------
        public static bool IsContentsOnlyArabicDigits(string strNumbers)
        {
            foreach (char c in strNumbers)
            {
                foreach (char n in m_strPersianDigits)
                    if (c == n)
                        return false;

                foreach (char n in m_strWesternDigits)
                    if (c == n)
                        return false;
            }

            return true;
        }
        //---------------------------------------------------------------------
        public static string ArabicToWestern(string strArabicNumbers)
        {
            return ToDestinationLanguage(strArabicNumbers,
                new string[] { m_strArabicDigits }, m_strWesternDigits);
        }
        //---------------------------------------------------------------------
        public static string ArabicToPersian(string strArabicNumbers)
        {
            return ToDestinationLanguage(strArabicNumbers,
                new string[] { m_strArabicDigits }, m_strPersianDigits);
        }
        //---------------------------------------------------------------------
        public static string PersianToArabic(string strPersianNumbers)
        {
            return ToDestinationLanguage(strPersianNumbers,
                new string[] { m_strPersianDigits }, m_strArabicDigits);
        }
        //---------------------------------------------------------------------
        public static string PersianToWestern(string strPersianNumbers)
        {
            return ToDestinationLanguage(strPersianNumbers,
                new string[] { m_strPersianDigits }, m_strWesternDigits);
        }
        //---------------------------------------------------------------------
        public static string EnglishToArabic(string strEnglishNumbers)
        {
            return ToDestinationLanguage(strEnglishNumbers,
                new string[] { m_strWesternDigits }, m_strArabicDigits);
        }
        //---------------------------------------------------------------------
        public static string EnglishToPersian(string strEnglishNumbers)
        {
            return ToDestinationLanguage(strEnglishNumbers,
                new string[] { m_strWesternDigits }, m_strPersianDigits);
        }
        //---------------------------------------------------------------------
        public static string ToArabic(string strContentNumbers)
        {
            return ToDestinationLanguage(strContentNumbers,
                new string[] { m_strPersianDigits, m_strWesternDigits },
                m_strArabicDigits);
        }
        //---------------------------------------------------------------------
        public static string ToWestern(string strContentNumbers)
        {
            return ToDestinationLanguage(strContentNumbers,
                new string[] { m_strPersianDigits, m_strArabicDigits },
                m_strWesternDigits);
        }
        //---------------------------------------------------------------------
        public static string ToPersian(string strContentNumbers)
        {
            return ToDestinationLanguage(strContentNumbers,
                new string[] { m_strWesternDigits, m_strArabicDigits },
                m_strPersianDigits);
        }
        //---------------------------------------------------------------------
        public static Image Logo {
        	get { return Resource.DigitConvertorLogo; }
        }

        #endregion Static Methods
    }
}

