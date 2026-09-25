
namespace Bank;

    internal class BankAccount
    {
        private List<Transaction> _allTransactions = new List<Transaction>();
        public string Owner { get; private set; } 
        public string Number { get;  }
        public decimal Balance 
        { get
            {
                decimal balance = 0;
                foreach (var transactions in _allTransactions)
                { 
                    balance += transactions.Amount;
                }
                return balance;
            }
    
        }
        private static int s_accauntNumberS = 1000000000;
        public BankAccount(string name, decimal initialBalance)
        {
            
            MakeDeposite(initialBalance,DateTime.UtcNow, "initial balance"); // this.Balance = initialBalance;
            Owner = name;
            Number = s_accauntNumberS.ToString();

            s_accauntNumberS++;
        }

        public void MakeDeposite  (decimal amount, DateTime date, string note)
        {
            if(amount<=0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposite must be positive");
        }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

    public void MakeWithdrawal (decimal amount, DateTime date, string note)
        {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance < amount)
        {
            throw new InvalidOperationException("Not sufficient money for thid withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }

}

