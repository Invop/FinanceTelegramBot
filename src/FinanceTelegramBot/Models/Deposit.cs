namespace FinanceTelegramBot.Models;

public class Deposit
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddYears(1);
    public string BankName { get; set; }
}