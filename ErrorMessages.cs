namespace Accounts_Basic_Crud;
public static class ErrorMessages {
	public const string ERROR_INVALID_FORMAT = "Invalid format. Please try again.";
	public const string ERROR_NONEXISTENT_OPTION = "Please choose an option from the list.";
	public const string ERROR_NAME_MINIMUM_CHARACTERS = "The name must have at least {0} characters.";
	public const string ERROR_NAME_NUMBER_SPECIAL_CHARS = "The name cannot contain numbers or special characters.";
	public const string ERROR_ID_NOT_FOUND = "Account with ID {0} not found.";
	public const string ERROR_ID_LESS_THAN_ZERO = "The ID must be greater than zero.";
	public const string ERROR_ID_ALREADY_EXISTS = "An account with this ID already exists.";
	public const string ERROR_BALANCE_NOT_ZERO_FOR_DELETION = "The account balance must be zero to be deleted.";
	public const string ERROR_NEGATIVE_BALANCE = "The balance must be greater than or equal to zero.";
	public const string ERROR_NEGATIVE_TRANSACTION_AMOUNT = "The amount to be {0} must be greater than zero.";
	public const string ERROR_INSUFFICIENT_FUNDS = "Insufficient funds to perform the withdrawal.";
	public const string ERROR_INVALID_NUMBER_FORMAT = "Invalid numeric value.";
	public const string ERROR_INVALID_INTEGER_FORMAT = "Please enter an integer number.";
	public const string ERROR_NUMBER_NOT_ENTERED = "Please enter a number.";
	public const string ERROR_CSV_INVALID_LINE_FORMAT = "Invalid line format in the CSV file.";
	public const string ERROR_CSV_READ = "Error reading the CSV: {0}.";
	public const string ERROR_CSV_WRITE = "Error writing the CSV: {0}.";
	public const string ERROR_CSV_FORMAT = "Error in CSV format: {0}.";
}