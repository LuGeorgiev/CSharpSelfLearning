using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models
{
    class XMLLayout : ILayout
    {        
        const string DateFormat = "HH:mm:ss dd-MMM-yyyy";
        private string Format =
            "< log >" + Environment.NewLine +
             "\t<date >{0}</date>" + Environment.NewLine +
             "\t<level>{1}</level>" + Environment.NewLine +
             "\t<message>{2}t</message>" + Environment.NewLine +
            "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);

            return formattedError;
        }
    }
}
