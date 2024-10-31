namespace FinanceTelegramBot.Models;
public class PaymentCategory
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string Name { get; set; }

    public int Ordering { get; set; }
}