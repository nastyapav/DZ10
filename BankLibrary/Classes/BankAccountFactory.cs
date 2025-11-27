namespace DZ10.Chapter11
{
    public class BankAccountFactory
    {
        private static readonly Dictionary<Guid, BankAccount> _accounts = new Dictionary<Guid, BankAccount>();
        public static Guid CreateAccount()
        {
            Guid newID = Guid.NewGuid();
            var account = new BankAccount(newID);
            _accounts[newID] = account;
            return newID;
        }
        public static Guid CreateAccount(decimal initializeBalance)
        {
            Guid newID = Guid.NewGuid();
            var account = new BankAccount(newID, initializeBalance);
            _accounts[newID] = account;
            return newID;
        }
        public static bool CloseAccount(Guid accountID)
        {
            return _accounts.Remove(accountID);
        }
    }
}
