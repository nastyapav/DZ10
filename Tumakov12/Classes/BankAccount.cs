namespace Tumakov12.Classes;
public class BankAccount
{
    public Guid AccountID { get; set; }
    public decimal Balance { get; set; }
    public BankAccount(Guid accountID, decimal balance)
    {
        AccountID = accountID;
        Balance = balance;
    }
    public static bool operator ==(BankAccount a, BankAccount b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.AccountID == b.AccountID && a.Balance == b.Balance;
    }
    public static bool operator !=(BankAccount a, BankAccount b)
    {
        return !(a == b);
    }
    public override bool Equals(object obj)
    {
        if (obj is BankAccount other)
            return this == other;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(AccountID, Balance);
    }
    public override string ToString()
    {
        return $"Счёт {AccountID}: баланс {Balance:C}";
    }
}