namespace AirsoftWebStore.Services.Contracts
{
    public interface IWalletService
    {
        Task<decimal> GetMoneyForUserByIdAsync(string userId);

        Task ReduceMoneyFromUserByIdAsync(string userId, decimal moneyToReduce);

        Task DepositToUserAccountAsync(string userId, decimal moneyToDeposit);
    }
}
