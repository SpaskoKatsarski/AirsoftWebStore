namespace AirsoftWebStore.Services.Contracts
{
    public interface IWalletService
    {
        Task<decimal> GetMoneyForUserByIdAsync(string userId);

        Task DepositToUserAccountAsync(string userId, decimal moneyToDeposit);
    }
}
