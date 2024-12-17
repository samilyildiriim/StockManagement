using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Controllers.Bases
{
    public abstract class MvcController : Controller
    {
        protected MvcController()
        {
            /*  [PURPOSE]
                The assignment CultureInfo cultureInfo = new CultureInfo("en-US");
            specifies the locale settings to format dates, numbers, and strings
            according to the rules of the U.S. English culture.
            */

            /*  [DATE FORMATTING]
                Example: DateTime.Now.ToString("d", cultureInfo)
                    - In en-US, it would output 12/11/2024, while in tr-TR it would output 11.12.2024,
                    reflecting the date format differences between the U.S. and Turkey
            */

            /*  [CURRENCY FORMATTING]
                Example: decimal amount = 1234.56m; amount.ToString("C", cultureInfo)
                    - In en-US, it would output $1,234.56, while in tr-TR, it would output ₺1.234,56,
                    showing the difference in currency symbols and formatting
                    CultureInfo cultureInfo = new CultureInfo("en-US"); //tr-TR
            */

            /*  [NUMBER FORMATTING]
                Example: double number = 1234.56; number.ToString("N", cultureInfo)
                    - In en-US, the output would be 1,234.56, using commas as thousands separators,
                    while in tr-TR, the output would be 1.234,56, using periods for thousands and commas for decimals
             */

            /* [STRING COMPARISON AND SORTING]
                Example: string.Compare("apple", "banana", false, cultureInfo)
                    - Depending on the cultureInfo, the sorting rules will change (e.g., sorting strings in Turkish
                    may result in different order due to special characters like İ vs. I)
             */

            /*  [TEXT COLLATION]
                Example: string.Compare("çalışma", "calisma", cultureInfo)
                    - This would compare the two strings according to Turkish collation rules,
                    where characters like ç are treated differently than c
             */
            CultureInfo cultureInfo = new CultureInfo("en-US");
            
            // These settings apply to the current thread,ensuring that operations on that thread respect the culture settings,
            // such as formatting or displaying text in the correct language.
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}