namespace Accounts_Basic_Crud;
internal class Account {
	private int id;
	private string name;
	private double balance;

	public int Id {
		get { return id; }
		set {
			if (value <= 0) throw new ArgumentException(ErrorMessages.ERROR_ID_LESS_THAN_ZERO);
			id = value;
		}
	}

	public string Name {
		get { return name; }
		set {
			int minimumCharacters = 3;
			if (string.IsNullOrWhiteSpace(value) || value.Length < minimumCharacters)
				throw new ArgumentException(string.Format(null, ErrorMessages.ERROR_NAME_MINIMUM_CHARACTERS, minimumCharacters));
			if (!value.All(c => char.IsLetter(c) || c == ' '))
				throw new ArgumentException(ErrorMessages.ERROR_NAME_NUMBER_SPECIAL_CHARS);
			name = value;
		}
	}

	public double Balance {
		get { return balance; }
		set {
			if (value < 0) throw new ArgumentException(ErrorMessages.ERROR_NEGATIVE_BALANCE);
			balance = value;
		}
	}

	public Account() { }
	public Account(int id, string name, double balance) {
		Id = id;
		Name = name;
		Balance = balance;
	}

	public void Deposit(double amount) {
		if (amount <= 0) throw new ArgumentException(string.Format(null, ErrorMessages.ERROR_NEGATIVE_TRANSACTION_AMOUNT, "deposited"));
		Balance += amount;
	}

	public void Withdraw(double amount) {
		if (amount <= 0) throw new ArgumentException(string.Format(null, ErrorMessages.ERROR_NEGATIVE_TRANSACTION_AMOUNT, "withdrawn"));
		if (Balance - amount < 0) throw new ArgumentException(ErrorMessages.ERROR_INSUFFICIENT_FUNDS);
		Balance -= amount;
	}

	public override string ToString() {
		return $"ID: {Id}\tName: {Name}\t\t\tBalance: ${Balance:F2}";
	}
}