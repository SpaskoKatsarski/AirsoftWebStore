﻿namespace AirsoftWebStore.Common
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

            public const decimal PriceMin = 50;
            public const decimal PriceMax = 15000;

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

            public const int ImageUrlMaxLength = 2048;

        }

        public static class Equipment
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Consumative
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }
    }
}