namespace AirsoftWebStore.Common
{
    public static class EntityValidationConstants
    {
        public static class Gun
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 150;

            public const int ManufacturerMinLength = 3;
            public const int ManufacturerMaxLength = 50;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 1500;

            public const int YearMin = 1970;
            public const int YearMax = 2023;

            public const string PriceMin = "50";
            public const string PriceMax = "15000";

            public const int QuantityMin = 1;
            public const int QuantityMax = 200;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Part
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int BrandMinLength = 3;
            public const int BrandMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const string PriceMin = "2";
            public const string PriceMax = "10000";

            public const int QuantityMin = 1;
            public const int QuantityMax = 300;

            public const int ImageUrlMaxLength = 2048;

        }

        public static class Equipment
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const string PriceMin = "1";
            public const string PriceMax = "10000";

            public const int QuantityMin = 1;
            public const int QuantityMax = 300;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Consumative
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const string PriceMin = "1";
            public const string PriceMax = "2500";

            public const int QuantityMin = 1;
            public const int QuantityMax = 300;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 20;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 100;
        }

        public static class Gunsmith
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}