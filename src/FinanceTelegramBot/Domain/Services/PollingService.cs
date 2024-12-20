using FinanceTelegramBot.Abstract;

namespace FinanceTelegramBot.Domain.Services;
// Compose Polling and ReceiverService implementations

public class PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger)
    : PollingServiceBase<ReceiverService>(serviceProvider, logger);