namespace FinanceTelegramBot.Models;

public class BotUser
{
    public long TelegramId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}