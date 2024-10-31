namespace FinanceTelegramBot.Models;

public class Budget
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);
    public int PaymentCategoryId { get; set; }
}