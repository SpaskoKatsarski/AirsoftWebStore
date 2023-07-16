namespace AirsoftWebStore.Services
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;

    public class WalletService : IWalletService
    {
        private readonly AirsoftStoreDbContext context;

        public WalletService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task DepositToUserAccountAsync(string userId, decimal moneyToDeposit)
        {
            ApplicationUser? user = await this.context.Users
                .FindAsync(Guid.Parse(userId));

            user!.Money += moneyToDeposit;

            await this.context.SaveChangesAsync();
        }

        public async Task<decimal> GetMoneyForUserByIdAsync(string userId)
        {
            ApplicationUser? user = await this.context.Users
                .FindAsync(Guid.Parse(userId));

            return user!.Money;
        }
    }
}
