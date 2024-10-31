namespace FinanceTelegramBot.Models;

public class RecurringPayment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int FrequencyInDays { get; set; }
    public int PaymentCategoryId { get; set; }
}