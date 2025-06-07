namespace Accounts_Basic_Crud;
internal class Program {
	static void Main(string[] args) {
		AccountManager mainManager = new(new CsvHandler());
		ConsoleUI mainTerminal = new(mainManager);

		mainManager.HandleCsv(Path.Combine(Environment.CurrentDirectory, "../../../accounts.csv"), true);
		mainTerminal.MainMenu();
		mainManager.HandleCsv(Path.Combine(Environment.CurrentDirectory, "../../../accounts.csv"), false);
	}
}