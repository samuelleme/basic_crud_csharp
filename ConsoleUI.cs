namespace Accounts_Basic_Crud;
internal class ConsoleUI {
	const int SLEEP_TIME_MS = 1000;
	AccountManager AccountManager { get; set; }
	public ConsoleUI(AccountManager linkedManager) {
		AccountManager = linkedManager;
	}

	public void MainMenu() {
		int validOptionCount = 5;
		int selectedOption = 0;
		bool showMainMenu = true;

		do {
			ShowTitle("MAIN MENU");
			ShowOptions();
			SelectOption(ref selectedOption, validOptionCount);
			ExecuteOption(selectedOption, ref showMainMenu);
		} while (showMainMenu);
	}

	public void AddAccountMenu() {
		Account newAccount = new();

		ShowTitle("ADD ACCOUNT");
		GetId(newAccount);
		GetName(newAccount);
		GetBalance(newAccount);
		AccountManager.AddAccount(newAccount);
		Console.WriteLine("\nAccount created successfully!");
		ShowReturnToMainMenuMessage();
	}

	public void DeleteAccountMenu() {
		int idToDelete;

		ShowTitle("DELETE ACCOUNT");
		do {
			Console.Write("Enter the ID of the account to be deleted: ");
			if (!int.TryParse(Console.ReadLine(), out idToDelete)) {
				Console.WriteLine(ErrorMessages.ERROR_INVALID_INTEGER_FORMAT);
			} else {
				try {
					AccountManager.DeleteAccount(idToDelete);
					Console.WriteLine("\nAccount deleted successfully!");
					break;
				} catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException) {
					Console.WriteLine(ex.Message);
				}
			}
		} while (true);

		ShowReturnToMainMenuMessage();
	}

	public void ListAccountsMenu() {
		ShowTitle("LIST ACCOUNTS");
		if (AccountManager.Accounts.Count == 0) {
			Console.WriteLine("No accounts registered.");
		} else {
			foreach (Account account in AccountManager.Accounts) {
				Console.WriteLine(account.ToString());
			}
		}
		ShowReturnToMainMenuMessage();
	}

	public void UpdateBalanceMenu() {
		int accountId = 0;
		double amount = 0;
		string operation = "";

		ShowTitle("UPDATE BALANCE");
		try {
			Console.Write("Enter the account ID: ");
			accountId = int.Parse(Console.ReadLine());
			Console.Write("Enter the amount: ");
			amount = double.Parse(Console.ReadLine());
			do {
				Console.Write("Operation (D for Deposit, W for Withdrawal): ");
				operation = Console.ReadLine().ToUpper();
			} while (operation != "D" && operation != "W");

			AccountManager.UpdateBalance(accountId, amount, operation == "D");
			Console.WriteLine("\nBalance updated successfully!");
		} catch (ArgumentException ex) {
			Console.WriteLine(ex.Message);
		} catch (FormatException) {
			Console.WriteLine(ErrorMessages.ERROR_INVALID_NUMBER_FORMAT);
		}
		ShowReturnToMainMenuMessage();
	}

	private void ExecuteOption(int selectedOption, ref bool keepRunning) {
		switch (selectedOption) {
			case 1: AddAccountMenu(); break;
			case 2: DeleteAccountMenu(); break;
			case 3: ListAccountsMenu(); break;
			case 4: UpdateBalanceMenu(); break;
			case 5: Console.WriteLine("Exiting."); keepRunning = false; break;
			default: break;
		}
	}

	private static void SelectOption(ref int selectedOption, int validOptionCount) {
		try {
			selectedOption = int.Parse(Console.ReadLine());
			if (selectedOption < 1 || selectedOption > validOptionCount) {
				Console.WriteLine(ErrorMessages.ERROR_NONEXISTENT_OPTION);
				Thread.Sleep(SLEEP_TIME_MS);
			}
		} catch (FormatException) {
			Console.WriteLine(ErrorMessages.ERROR_INVALID_FORMAT);
			Thread.Sleep(SLEEP_TIME_MS);
		}
		Console.Clear();
	}

	private static void GetBalance(Account newAccount) {
		do {
			Console.Write("Enter the initial balance: ");
			try {
				newAccount.Balance = double.Parse(Console.ReadLine());
				break;
			} catch (ArgumentException ex) {
				Console.WriteLine(ex.Message);
			} catch (FormatException) {
				Console.WriteLine(ErrorMessages.ERROR_NUMBER_NOT_ENTERED);
			}
		} while (true);
	}

	private static void GetName(Account newAccount) {
		do {
			Console.Write("Enter your name: ");
			try {
				newAccount.Name = Console.ReadLine() ?? throw new ArgumentNullException();
				break;
			} catch (ArgumentException ex) {
				Console.WriteLine(ex.Message);
			}
		} while (true);
	}

	private void GetId(Account newAccount) {
		do {
			Console.Write("Enter an ID for the account: ");
			try {
				int newId = int.Parse(Console.ReadLine());
				if (AccountManager.Accounts.Any(c => c.Id == newId)) {
					Console.WriteLine(ErrorMessages.ERROR_ID_ALREADY_EXISTS);
					continue;
				}
				newAccount.Id = newId;
				break;
			} catch (ArgumentException ex) {
				Console.WriteLine(ex.Message);
			} catch (FormatException) {
				Console.WriteLine(ErrorMessages.ERROR_INVALID_INTEGER_FORMAT);
			}
		} while (true);
	}

	private static void ShowTitle(string title) {
		Console.WriteLine($"####### {title} #######\n");
	}

	private static void ShowOptions() {
		Console.WriteLine("Choose one of the options below:\n");
		Console.WriteLine("(1) Add account");
		Console.WriteLine("(2) Delete account");
		Console.WriteLine("(3) List accounts");
		Console.WriteLine("(4) Update balance");
		Console.WriteLine("(5) Exit");
		Console.Write("\nChoose: ");
	}

	private static void ShowReturnToMainMenuMessage() {
		Console.WriteLine("\nPress any key to return to the main menu.");
		Console.ReadKey();
		Console.Clear();
	}
}