namespace EstateManagment.Data
{
    public static class DataConstants
    {
        public const int CompanyNameMinLength = 2;
        public const int CompanyNameMaxLength = 100;
        public const int CompanyBulstatMinLength = 8;
        public const int CompanyBulstatMaxLength = 15;

        public const int PropertyNameMinLength = 2;
        public const int PropertyNameMaxLength = 40;
        public const int PropertyAddressMinLength = 2;
        public const int PropertyAddressMaxLength = 200;
        public const int PropertyMinArea = 1;
        public const int PropertyMaxArea = 1000000;
        public const decimal PropertyRentMinPrice = 0;
        public const decimal PropertyRentMaxPrice = 100000000;

        public const int DescriptionMaxLength = 500;

        public const decimal ParkingSlotMinPrice = 0;
        public const decimal ParkingSlotMaxPrice = 5000;

        public const decimal PaymentMinAmount = 0;
        public const decimal PaymentMaxAmount = 500000;

        public const int ClientNameMinLength = 2;
        public const int ClientNameMaxLength = 100;
        public const int ClientTelephoneMinLength = 6;
        public const int ClientTelephoneMaxLength = 15;
        public const int ClientContactNameMinLength = 2;
        public const int ClientContactNameMaxLength = 200;
                
        public const int RentDescriptionMaxLength = 1000;

        public const int ContractsFileMaxSize = 2 * 1024 * 1024;

        public const string MinPayment = "0";
        public const string MaxPayment = "1000000";

        public const string RegexLatinNames = @"^[A-za-z\u0400-\u044F\ ]+$";
        public const string RegexLatinCompanyNames = @"^[A-za-z\u0400-\u044F\ 0-9\?\!\.,]+$";
        public const string RegexTelephone = @"^\+?[0-9\ -]{5,20}$";
        public const string RegexBulstat = @"^(BG|bg)?[0-9]{9,15}$";
    }
}
