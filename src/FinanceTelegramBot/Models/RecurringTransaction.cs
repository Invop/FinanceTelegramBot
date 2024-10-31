namespace FinanceTelegramBot.Models;

public class RecurringTransaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddYears(1);
    public int FrequencyInDays { get; set; }
    public int TransactionTypeId { get; set; }
}
public class RecurringIncome : RecurringTransaction
{
    public string Source { get; set; }
}
public class RecurringPayment : RecurringTransaction
{
    public string Description { get; set; }
    public int PaymentCategoryId { get; set; }
}