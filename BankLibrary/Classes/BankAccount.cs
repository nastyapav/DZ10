namespace DZ10.Chapter11
{
    public class BankAccount
    {
        public readonly Guid AccountID;
        public decimal Balance;
        internal BankAccount(Guid AccountID)
        {
            this.AccountID = AccountID;
            Balance = 0;
        }
        internal BankAccount(Guid AccountID, decimal initializeBalance)
        {
            this.AccountID = AccountID;
            Balance = initializeBalance;
        }
    }
}