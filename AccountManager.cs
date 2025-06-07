namespace Accounts_Basic_Crud;
internal class AccountManager {
	public List<Account> Accounts { get; set; }
	public CsvHandler CsvHandler { get; set; }

	public AccountManager(CsvHandler csvHandler) {
		Accounts = new List<Account>();
		CsvHandler = csvHandler;
	}

	public void AddAccount(Account account) {
		Accounts.Add(account);
	}

	public void DeleteAccount(int id) {
		if (id <= 0) throw new ArgumentException(ErrorMessages.ERROR_ID_LESS_THAN_ZERO);
		Account accountToDelete = Accounts.FirstOrDefault(c => c.Id == id)
		  ?? throw new ArgumentNullException(null, string.Format(ErrorMessages.ERROR_ID_NOT_FOUND, id));
		if (accountToDelete.Balance != 0) throw new ArgumentException(ErrorMessages.ERROR_BALANCE_NOT_ZERO_FOR_DELETION);
		Accounts.Remove(accountToDelete);
	}

	public void ListAccounts() {
		foreach (Account account in Accounts) account.ToString();
	}

	public void UpdateBalance(int id, double amount, bool isDeposit) {
		Account accountToUpdate = Accounts.FirstOrDefault(c => c.Id == id)
		  ?? throw new ArgumentNullException(null, string.Format(ErrorMessages.ERROR_ID_NOT_FOUND, id));
		if (id <= 0) throw new ArgumentException(ErrorMessages.ERROR_ID_LESS_THAN_ZERO);
		if (isDeposit) accountToUpdate.Deposit(amount);
		else accountToUpdate.Withdraw(amount);
	}

	public void HandleCsv(string filePath, bool isImport) {
		if (isImport) {
			List<string[]> accountsData = CsvHandler.ReadCsv(filePath);
			foreach (var accountData in accountsData) {
				Accounts.Add(new Account(int.Parse(accountData[0]), accountData[1], double.Parse(accountData[2])));
			}
		} else CsvHandler.WriteCsv(filePath, Accounts);
	}
}