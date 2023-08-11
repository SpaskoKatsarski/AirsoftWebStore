namespace AirsoftWebStore.Services.Tests.Admin
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class AdminDatabaseSeeder
    {
        public static ApplicationUser UserWithRequest;
        public static ApplicationUser UserWithoutRequest;

        public static void SeedDatabaseForAdmin(AirsoftStoreDbContext dbContext)
        {
            UserWithRequest = new ApplicationUser()
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
                HasGunsmithRequest = true
            };

            UserWithoutRequest = new ApplicationUser()
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
                LastName = "Testov2"
            };

            dbContext.Users.AddRange(UserWithRequest, UserWithoutRequest);
            dbContext.SaveChanges();
        }
    }
}
