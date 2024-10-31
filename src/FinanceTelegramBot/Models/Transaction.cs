namespace FinanceTelegramBot.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int PaymentCategoryId { get; set; }
}
