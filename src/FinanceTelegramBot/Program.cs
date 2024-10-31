using Microsoft.Extensions.Options;
using Telegram.Bot;
using FinanceTelegramBot.Configuration;
using FinanceTelegramBot.Database;
using FinanceTelegramBot.Services;
using FinanceTelegramBot.Services.Messaging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSystemd();
var configuration = builder.Configuration;

builder.Services.Configure<BotConfiguration>(configuration.GetSection("BotConfiguration"));

builder.Services.AddHttpClient("telegram_bot_client").AddTypedClient<ITelegramBotClient>(
    (httpClient, serviceProvider) =>
    {
        BotConfiguration? botConfiguration = serviceProvider.GetService<IOptions<BotConfiguration>>()?.Value;
        ArgumentNullException.ThrowIfNull(botConfiguration);
        TelegramBotClientOptions options = new(botConfiguration.BotToken);
        return new TelegramBotClient(options, httpClient);
    });
builder.Services.AddSingleton<IDbConnectionFactory>(_ => 
    new SqliteConnectionFactory(configuration.GetConnectionString("DefaultConnection")!));
builder.Services.AddSingleton<DbInitializer>();
builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<MessageProcessor>();

builder.Services.AddScoped<UpdateHandler>();
builder.Services.AddScoped<ReceiverService>();
builder.Services.AddHostedService<PollingService>();
var host = builder.Build();
var dbInitializer = host.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();
host.Run();