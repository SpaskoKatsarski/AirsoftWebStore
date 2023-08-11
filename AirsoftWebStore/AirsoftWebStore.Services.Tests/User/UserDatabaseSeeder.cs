namespace AirsoftWebStore.Services.Tests.User
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class UserDatabaseSeeder
    {
        public static ApplicationUser NormalUser;
        public static ApplicationUser GunsmithUser;

        public static void SeedDatabaseForUser(AirsoftStoreDbContext dbContext)
        {
            NormalUser = new ApplicationUser()
            {
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = false,
                PasswordHash = "testestestestestes1231231232",
                SecurityStamp = "2RC726483DB146C7AB86961EBD8FA68B",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Test",
                LastName = "Testov",
                Money = 0
            };

            GunsmithUser = new ApplicationUser()
            {
                UserName = "test2@test.com",
                NormalizedUserName = "TEST2@TEST.COM",
                Email = "test2@test.com",
                NormalizedEmail = "TEST2@TEST.COM",
                EmailConfirmed = false,
                PasswordHash = "testestestestestes12312312322",
                SecurityStamp = "2RC726483DB146C7AB86961EBD8FA68G",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Test2",
                LastName = "Testov2",
                Money = 0
            };

            Gunsmith gunsmith = new Gunsmith()
            {
                User = GunsmithUser
            };

            dbContext.Users.AddRange(NormalUser, GunsmithUser);
            dbContext.Gunsmiths.Add(gunsmith);
            dbContext.SaveChanges();
        }
    }
}
