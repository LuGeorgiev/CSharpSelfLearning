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
        public const string RegexEGN = @"^[0-9]{10}$";

        public const string DisplayCompanyName = "Име на фирма";
        public const string DisplayClientName = "Име на клиент";
        public const string DisplayAcountablePerson = "МОЛ";
        public const string DisplayAddress = "Адрес";
        public const string DisplayBulstat = "Булстат";
        public const string DisplayEGN = "ЕГН";
        public const string DisplayContactName = "Лице за контакти";
        public const string DisplayTelephone = "Телефон";
        public const string DisplayNotes = "Бележки";
        public const string DisplayIsDeletedClient = "Изтрит клиент";
        public const string DisplayPropertyName = "Недвижимост";
        public const string DisplayArea = "Площ";
        public const string DisplayDescription = "Описание";
        public const string DisplayPropertyType = "Вид на имота";
        public const string DisplayIsActual = "Актуалност";
        public const string DisplayStartDate = "Начална дата";
        public const string DisplayEndDate = "Крайна Дата";
        public const string DisplayParkingDecription = "Описание на паркоместата";
        public const string DisplayParkingSlotType = "Тип паркомясто";
        public const string DisplayPrice = "Месечен наем";
        public const string DisplayQuantity = "Броя";
        public const string DisplayClients = "Клиенти";
        public const string DisplayFreeProperties = "Свободни Недвижимости";
        public const string DisplayCarSlots = "Паркоместа  коли";
        public const string DisplayBusSlots = "Паркоместа рейсове";
        public const string DisplayTruckSlots = "Паркоместа камиони";
        public const string DisplayBigTruckSlots = "Паркоместа голями камиони";
        public const string DisplayCarCageSlots = "Паркоместа авто-клетки";
        public const string DisplayOtherSlots = "Други";
        public const string DisplaySlotPrice = "Еденична цена";
        public const string DisplayDeadLine = "Краен срок";
        public const string DisplayTotalPayment = "Оставащо плащане";
        public const string DisplayApplyVat = "Сложи ДДС";
        public const string DisplayWaterPayment = "Сметка за вода";
        public const string DisplayElectricityPayment = "Сметка за ток";
        public const string DisplayWaterReport = "Изразходвана вода";
        public const string DisplayElectricityDay = "Разход дневна тарифа";
        public const string DisplayElectricityNight = "Разход нощна тарифа";
        public const string DisplayElectricityPeak = "Разход върхова тарифа";
        public const string DisplayPaidOn = "Дата на плащане";
        public const string DisplayAmount = "Сума";
        public const string DisplayCashPayment = "В брой";
        public const string DisplayPayment = "Платащане";
        public const string DisplayCreatNextMonth = "Следващ месец";
        public const string DisplayTotalConsumablesMonthlyPrice = "Месечни консумативи";


        public const string ErrorMessageCompanyName = "Да съдържа букви на кирилица, латиница, цифри и знаците: !., ? ";
        public const string ErrorMessageBulstat = "Да започва с или без BG последван от 9 до 15 цифри";
        public const string ErrorMessageEGN = "Точно 10 цифри";
        public const string ErrorMessageLatinNames = "Само букви на кирилица или латиница";
        public const string ErrorMessageTelephone = "С или без '+' в началото последван от цифри,интервали и тирета";
        public const string ErrorMessagePayment = "Плащането трябва да е положитено и НЕ по-голямо от дължимата сума";
    }
}
