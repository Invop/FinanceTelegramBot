namespace FinanceTelegramBot.Models;

public class Budget
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PaymentCategoryId { get; set; }
}