using System;

namespace EgnValidator.Constants
{
    public static class Global
    {
        public const string INVALID_REGEX = "Please insert ten digits where first represents your birthdate";
        public const string INVALID_DATE = "Please insert valid date";
        public const string INVALID_CONTROL_SUM = "Please insert valid EGN";
        //public const string INVALID_IN_FUTURE = "This date if from future!";
        //public const string INVALID_LEAP = "Pay attention please, this year is not leap";
        public const string VALID_ID = "valid";

        public const string PATTERN = "^[0-9]{2}[0-5]{1}[0-9]{1}[0-3]{1}[0-9]{5}$";
        public const int EGN_DATE_LENGTH = 6;
        public const string EGN_DATE_FORMAT = "yyyy-MM-dd hh:mm tt";

    }
}
