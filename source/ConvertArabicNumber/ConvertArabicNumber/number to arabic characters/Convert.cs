using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertArabicNumber
{
    class Convert
    {
        /*
         القيم الخاصة بقيم الآحاد
         وحتى الرقم 12
         * */
        static string[] ones = {
                    "صفر",
                    "واحد",
                    "اثنان",
                    "ثلاثة",
                    "أربعة",
                    "خمسة",
                    "ستة",
                    "سبعة",
                    "ثمانية",
                    "تسعة",
                    "عشرة",
                    "أحد عشر",
                    "اثنى عشر"
                };

        /*
        القيم الخاصة بقيم العشرات
        * */
        static string[] tens = {
                    "عشر",
                    "عشرون",
                    "ثلاثون",
                    "أربعون",
                    "خمسون",
                    "ستون",
                    "سبعون",
                    "ثمانون",
                    "تسعون"
                };


        /*
        القيم الخاصة بقيم المئات
        * */
        static string[] hundreds = {
                    "صفر",
                    "مائة",
                    "مئتان",
                    "ثلاثمائة",
                    "أربعمائة",
                    "خمسمائة",
                    "ستمائة",
                    "سبعمائة",
                    "ثمانمائة",
                    "تسعمائة"
                };

        /*
        القيم الخاصة بقيم الآلاف
        * */
        static string[] thousands = {
                    "ألف",
                    "ألفان",
                    "آلاف",
                    "ألفًا"
                };

        /*
        القيم الخاصة بقيم الملايين
        * */
        static string[] millions = {
                    "مليون",
                    "مليونان",
                    "ملايين",
                    "مليونًا"
                };


        /*
        القيم الخاصة بقيم المليارات
        * */
        static string[] billions = {
                    "مليار",
                    "ملياران",
                    "مليارات",
                    "مليارًا"
                };

        /*
        القيم الخاصة بقيم التريليونات
        * */
        static string[] trillions = {
                    "تريليون",
                    "تريليونان",
                    "تريليونات",
                    "تريليونًا"
                };

        //public static string tafqeetCentimes(string numberStr)
        //{
        //    numberStr = getNthReverse(numberStr, numberStr.Length);

        //    numberStr = Int32.Parse(numberStr).ToString();
        //    numberStr = getNthReverse(numberStr, numberStr.Length);


        //    return tafqeet(numberStr);
        //}
        public static string ConvertToArabic(string nbr)
        {
            string finalResult = "";

            if (nbr == "")
                return "";

            string[] tab;
            if (Function.isDouble(nbr))
            {
                nbr = Double.Parse(nbr).ToString();

                tab = nbr.Replace('.', ',').Split(',');



                if (tab[0] == "1")
                    finalResult = "دينار";
                else
                    if (tab[0] == "2")
                    finalResult = "دينارين";
                else
                    finalResult = Convert.tafqeet(tab[0]) + " دينار";

                if (nbr.Contains(","))

                    if (tab[1] == "1")
                        finalResult += " و سنتيم";
                    else
                if (tab[1] == "2")
                        finalResult += " و سنتمين";
                    else
                        finalResult += " و " + Convert.tafqeet(tab[1]) + " سنتيم";


            }

            return finalResult;
        }
        public static string tafqeet(string numberStr)
        {

            /**
             * متغير لتخزين النص المفقط بداخله
             */

            string value = "";
            //التحقق من أن المتغير يحتوي أرقامًا فقط، وأقل من تسعة وتسعين تريليون
            //if (numberStr.match(/^[0 - 9] +$/) != null && numberStr.Length <= 14)
            if (Function.isInt(numberStr) && numberStr.Length <= 14)
            {
                int number = Int32.Parse(numberStr);
                numberStr = number.ToString();
                switch (numberStr.Length)
                {
                    /**
                     * إذا كان العدد من 0 إلى 99
                     */
                    case 1:
                    case 2:
                        value = oneTen(numberStr);
                        break;

                    /**
                     * إذا كان العدد من 100 إلى 999
                     */
                    case 3:
                        value = hundred(numberStr);
                        break;

                    /**
                     * إذا كان العدد من 1000 إلى 999999
                     * أي يشمل الآلاف وعشرات الألوف ومئات الألوف
                     */
                    case 4:
                    case 5:
                    case 6:
                        value = thousand(numberStr);
                        break;

                    /**
                     * إذا كان العدد من 1000000 إلى 999999999
                     * أي يشمل الملايين وعشرات الملايين ومئات الملايين
                     */
                    case 7:
                    case 8:
                    case 9:
                        value = million(numberStr);
                        break;

                    /**
                     * إذا كان العدد من 1000000000 إلى 999999999999
                     * أي يشمل المليارات وعشرات المليارات ومئات المليارات
                     */
                    case 10:
                    case 11:
                    case 12:
                        value = billion(numberStr);
                        break;

                    /**
                     * إذا كان العدد من 100000000000 إلى 9999999999999
                     * أي يشمل التريليونات وعشرات التريليونات
                     */
                    case 13:
                    case 14:
                    case 15:
                        value = trillion(numberStr);
                        break;

                }

            }
            /**
             * هذا السطر يقوم فقط بإزالة بعض الزوائد من النص الأخير
             * تظهر هذه الزوائد نتيجة بعض الفروق في عملية التفقيط
             * ولإزالتها يتم استخدام هذا السطر
             */
            return value
                .Replace("وصفر", "")
                .Replace("صفر و", "")
                .Replace("مئتان  أ", "مئتا  أ")
                .Replace("مئتان  م", "مئتا  م")
                //.Replace("", "")
                .Trim();

            // javascript code :
            //return value.replace(/ وصفر / g, "")
            //.replace(/ وundefined / g, "")
            //.replace(/ +(?= ) / g, '')
            //.replace(/ صفر و / g, "")
            //.replace(/ صفر / g, "")
            //.replace(/ مئتان أ /, "مائتا أ")
            //.replace(/ مئتان م /, "مائتا م");
        }

        /**************************/
        public static string oneTen(string numberStr)
        {
            int number = Int32.Parse(numberStr);
            /** 
             * القيم الافتراضية
            */
            string value = "صفر";

            //من 0 إلى 12
            if (number <= 12)
            {
                switch (number)
                {
                    case 0:
                        value = ones[0];
                        break;
                    case 1:
                        value = ones[1];
                        break;
                    case 2:
                        value = ones[2];
                        break;
                    case 3:
                        value = ones[3];
                        break;
                    case 4:
                        value = ones[4];
                        break;
                    case 5:
                        value = ones[5];
                        break;
                    case 6:
                        value = ones[6];
                        break;
                    case 7:
                        value = ones[7];
                        break;
                    case 8:
                        value = ones[8];
                        break;
                    case 9:
                        value = ones[9];
                        break;
                    case 10:
                        value = ones[10];
                        break;

                    case 11:
                        value = ones[11];
                        break;

                    case 12:
                        value = ones[12];
                        break;


                }
            }
            /**
                 * إذا كان العدد أكبر من12 وأقل من 99
                 * يقوم بجلب القيمة الأولى من العشرات
                 * والثانية من الآحاد
                 */
            else
            {
                int first = getNth(numberStr, 0, 0);

                int second = getNth(numberStr, 1, 1);

                if (tens[first - 1] == "عشر")
                {
                    value = ones[second] + " " + tens[first - 1];
                }
                else
                {
                    value = ones[second] + " و" + tens[first - 1];
                }

            }
            return value;
        }


        /**************************/

        /**
         * 
         * @param {*} number
         * الدالة الخاصة بالمئات 
         */
        public static string hundred(string numberStr)
        {
            int number = Int32.Parse(numberStr);
            string value = "";

            /**
             * إذا كان الرقم لا يحتوي على ثلاث منازل
             * سيتم إضافة أصفار إلى يسار الرقم
             */
            while (numberStr.Length != 3)
            {
                numberStr = "0" + numberStr;
            }

            int first = getNth(numberStr, 0, 0);

            /**
             * تحديد قيمة الرقم الأول
             */
            switch (first)
            {
                case 0:
                    value = hundreds[0];
                    break;
                case 1:
                    value = hundreds[1];
                    break;
                case 2:
                    value = hundreds[2];
                    break;
                case 3:
                    value = hundreds[3];
                    break;
                case 4:
                    value = hundreds[4];
                    break;
                case 5:
                    value = hundreds[5];
                    break;
                case 6:
                    value = hundreds[6];
                    break;
                case 7:
                    value = hundreds[7];
                    break;
                case 8:
                    value = hundreds[8];
                    break;
                case 9:
                    value = hundreds[9];
                    break;
            }

            /**
             * إضافة منزلة العشرات إلى الرقم المفقط
             * باستخدام دالة العشرات السابقة
             */
            value = value + " و" + oneTen(getNth(numberStr, 1, 2).ToString());
            return value;
        }

        /**************************/
        /**
             * دالة لجلب أجزاء من الرقم المراد تفقيطه
             */
        public static int getNth(string number, int first, int end)
        {
            string finalNumber = "";
            string numberStr = number.ToString();
            for (int i = first; i <= end; i++)
            {
                finalNumber = finalNumber + numberStr[i];
                //finalNumber = finalNumber + String(number).charAt(i);
            }
            return Int32.Parse(finalNumber);
        }

        /**
         * دالة تجلب أجزاء من الرقم بالعكس
         * @param {*} number 
         * @param {*} limit 
         */
        public static string getNthReverse(string number, int limit)
        {
            string finalNumber = "";
            string numberStr = number.ToString();
            int x = 1;
            while (x != limit)
            {
                finalNumber = numberStr[numberStr.Length - x] + finalNumber;
                //finalNumber = String(number).charAt(number.toString().length - x) + finalNumber;
                x++;
            }

            return finalNumber;
        }

        /**************************/
        /**
 * 
 * @param {*} number 
 * الدالة الخاصة بالآلاف
 */
        public static string thousand(string number)
        {
            return thousandsTrillions(thousands[0], thousands[1], thousands[2], thousands[3], 0, number, (getNthReverse(number, 4)));
            //return thousandsTrillions(thousands[1], thousands[2], thousands[39], thousands[1199], 0, number, (getNthReverse(number, 4)));
        }

        /**
         * 
         * @param {*} number
         * الدالة الخاصة بالملايين 
         */
        public static string million(string number)
        {
            return thousandsTrillions(millions[0], millions[1], millions[2], millions[3], 3, number, (getNthReverse(number, 7)));
        }


        /**
         * 
         * @param {*} number
         * الدالة الخاصة بالمليارات 
         */
        public static string billion(string number)
        {
            return thousandsTrillions(billions[0], billions[1], billions[2], billions[3], 6, number, (getNthReverse(number, 10)));
        }



        /**
         * 
         * @param {*} number
         * الدالة الخاصة بالترليونات 
         */
        public static string trillion(string number)
        {
            return thousandsTrillions(trillions[0], trillions[1], trillions[2], trillions[3], 9, number, (getNthReverse(number, 13)));
        }

        /**************************/

        /**
         * هذه الدالة هي الأساسية بالنسبة للأرقام
         * من الآلاف وحتى التريليونات
         * تقوم هذه الدالة بنفس العملية للمنازل السابقة مع اختلاف
         * زيادة عدد المنازل في كل مرة
         * @param {*} one 
         * @param {*} two 
         * @param {*} three 
         * @param {*} eleven 
         * @param {*} diff 
         * @param {*} number 
         * @param {*} other 
         */
        public static string thousandsTrillions(string one, string two, string three, string eleven, int diff, string numberStr, string other)
        {
            /**
             * جلب المنازل المتبقية
             */
            other = tafqeet(other);

            /**
             * إذا كان المتبقي يساوي صفر
             */
            if (other == "")
            {
                other = "صفر";
            }

            string value = "";

            int number = Int32.Parse(numberStr);

            /**
             * التحقق من طول الرقم
             * لاكتشاف إلى أي منزلة ينتمي
             */
            //switch (numberStr.Length)
            //{
            /**
             * ألوف، أو ملايين، أو مليارات، أو تريليونات
             */
            //case (4 + diff):
            if (numberStr.Length == 4 + diff)
            {
                int ones = getNth(numberStr, 0, 0);
                switch (ones)
                {
                    case 1:
                        //System.Windows.MessageBox.Show(one);
                        value = one + " و" + (other);
                        break;
                    case 2:
                        value = two + " و" + (other);
                        break;
                    default:
                        value = oneTen(ones.ToString()) + " " + three + " و" + (other);
                        break;
                }
            }

            /**
             * عشرات الألوف، أو عشرات الملايين، أو عشرات المليارات، أو عشرات التريليونات
             */
            //case (5 + diff):
            else if (numberStr.Length == 5 + diff)
            {

                int tens = getNth(numberStr, 0, 1);
                switch (tens)
                {
                    case 10:
                        value = oneTen(tens.ToString()) + " " + three + " و" + (other);
                        break;
                    default:
                        value = oneTen(tens.ToString()) + " " + eleven + " و" + (other);
                        break;
                }
                //break;
            }

            /**
             *مئات الألوف، أو مئات الملايين، أو مئات المليارات
             */
            //case (6 + diff):
            else if (numberStr.Length == 6 + diff)
            {

                int hundreds = getNth(numberStr, 0, 2);
                int tenss = getNth(numberStr, 0, 1);
                int twoVal = getNth(numberStr, 1, 2);
                var th = "";
                switch (twoVal)
                {
                    case 0:
                        th = one;
                        break;

                    default:
                        th = eleven;
                        break;
                }
                if (tenss >= 100 && tenss <= 199)
                    value = hundred(hundreds.ToString()) + " " + th + " و" + (other);
                else
                if (tenss >= 200 && tenss <= 299)
                    value = hundred(hundreds.ToString()) + " " + th + " و" + (other);
                else
                    value = hundred(hundreds.ToString()) + " " + th + " و" + (other);
                //break;
            }
            //}

            return value;

        }

    }

}