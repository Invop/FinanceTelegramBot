namespace FinanceTelegramBot.Models;

public class RecurringIncome
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Source { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int FrequencyInDays { get; set; }
}