namespace AirsoftWebStore.Services.Tests
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class GunsmithDatabaseSeeder
    {
        public static ApplicationUser GunsmithUser;
        public static ApplicationUser NormalUser;
        public static Gunsmith Gunsmith;

        public static void SeedDatabaseForGunsmith(AirsoftStoreDbContext dbContext)
        {
            // GunsmithService data seeding
            GunsmithUser = new ApplicationUser()
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@gunsmiths.com",
                NormalizedEmail = "PESHO@GUNSMITHS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Petrov"
            };

            NormalUser = new ApplicationUser()
            {
                UserName = "Gosho",
                NormalizedUserName = "GOSHO",
                Email = "gosho@renters.com",
                NormalizedEmail = "GOSHO@RENTERS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
                FirstName = "Gosho",
                LastName = "Goshov"
            };

            Gunsmith = new Gunsmith()
            {
                User = GunsmithUser
            };

            dbContext.Users.AddRange(GunsmithUser, NormalUser);
            dbContext.Gunsmiths.Add(Gunsmith);

            dbContext.SaveChanges();
        }
    }
}
