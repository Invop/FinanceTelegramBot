using FinanceTelegramBot.Abstract;
using Telegram.Bot;

namespace FinanceTelegramBot.Domain.Services;

// Compose Receiver and UpdateHandler implementation
public class ReceiverService(
    ITelegramBotClient botClient,
    UpdateHandler updateHandler,
    ILogger<ReceiverServiceBase<UpdateHandler>> logger)
    : ReceiverServiceBase<UpdateHandler>(botClient, updateHandler, logger);