namespace AirsoftWebStore.Services.Tests.Wallet
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class WalletDatabaseSeeder
    {
        public static ApplicationUser User;

        public static void SeedDatabaseForWallet(AirsoftStoreDbContext dbContext)
        {
            User = new ApplicationUser()
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

            dbContext.Users.Add(User);
            dbContext.SaveChanges();
        }
    }
}
