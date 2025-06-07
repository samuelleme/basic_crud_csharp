using System.Text;

namespace Accounts_Basic_Crud;
internal class CsvHandler {
	public CsvHandler() { }
	public List<string[]> ReadCsv(string filePath) {
		List<string[]> data = new();
		try {
			using (var streamReader = new StreamReader(filePath)) {
				string line = streamReader.ReadLine();
				while (line != null) {
					string[] fields = line.Split(';');

					if (fields.Length != 3) {
						Console.WriteLine(ErrorMessages.ERROR_CSV_INVALID_LINE_FORMAT);
						Console.WriteLine();
					}
					if (!double.TryParse(fields[2], out double balance)) {
						Console.WriteLine(ErrorMessages.ERROR_INVALID_NUMBER_FORMAT + $" Line: {line}\n");
					}
					data.Add(fields);
					line = streamReader.ReadLine();
				}
			}
		} catch (IOException ex) {
			Console.WriteLine(string.Format(ErrorMessages.ERROR_CSV_READ, ex.Message));
		} catch (FormatException ex) {
			Console.WriteLine(string.Format(ErrorMessages.ERROR_CSV_FORMAT, ex.Message));
		}
		return data;
	}

	public void WriteCsv(string filePath, List<Account> accounts) {
		try {
			using (var writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
				foreach (Account account in accounts) {
					writer.WriteLine($"{account.Id};{account.Name};{account.Balance}");
				}
			}
		} catch (IOException ex) {
			Console.WriteLine(string.Format(ErrorMessages.ERROR_CSV_WRITE, ex.Message));
		}
	}
}
