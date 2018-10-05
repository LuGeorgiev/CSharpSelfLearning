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
        public const int PropertyAreaMinLength = 10;
        public const int PropertyAreaMaxLength = 1000000;
        public const int PropertyDescriptionMaxLength = 500;

        public const decimal PropertyRentMinPrice = 0;
        public const decimal PropertyRentMaxPrice = 100000000;

        public const decimal ParkingSlotMinPrice = 0;
        public const decimal ParkingSlotMaxPrice = 5000;

        public const int ClientNameMinLength = 2;
        public const int ClientNameMaxLength = 100;
        public const int ClientTelephoneMinLength = 6;
        public const int ClientTelephoneMaxLength = 15;
        public const int ClientContactNameMinLength = 2;
        public const int ClientContactNameMaxLength = 200;
                
        public const int RentDescriptionMaxLength = 1000;

        public const long ContractsFileMaxSize = 5 * 1024 * 1024;
    }
}
