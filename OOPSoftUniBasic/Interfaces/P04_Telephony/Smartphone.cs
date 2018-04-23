using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P04_Telephony
{
    

    public class Smartphone : ICallable, IBrowsable
    {
        public const string callPattern = @"^[0-9]+$";
        public const string browsePattern = @"^[\D]+$";

        public string Model { get; set; }

        public Smartphone()
        {
        }

        public string Browse(string siteToBrowse)
        {
            var rgx = new Regex(browsePattern);

            if (rgx.IsMatch(siteToBrowse))
            {
                return $"Browsing: {siteToBrowse}!";
            }
            else
            {
                return "Invalid URL!";
            }
        }

        public string Call(string numberToCall)
        {
            var rgx = new Regex(callPattern);

            if (rgx.IsMatch(numberToCall))
            {
                return $"Calling... {numberToCall}";
            }
            else
            {
                return $"Invalid number!";
            }
        }
    }
}
