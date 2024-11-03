namespace FinanceTelegramBot.Domain.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public int PaymentCategoryId { get; set; }
    public int TransactionTypeId { get; set; }
}
public class TransactionType
{
    public int Id { get; set; }
    public string Name { get; set; }
}