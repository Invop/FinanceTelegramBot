namespace FinanceTelegramBot.Models;

public class Deposit
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string BankName { get; set; }
}