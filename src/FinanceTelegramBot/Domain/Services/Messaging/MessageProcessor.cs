using FinanceTelegramBot.Configuration;
using Telegram.Bot.Types;

namespace FinanceTelegramBot.Domain.Services.Messaging;

public class MessageProcessor(IMessageHandler messageHandler)
{
    public async Task<Message> ProcessMessageAsync(string messageText, Message msg)
    {
        var command = messageText.Split(' ')[0];
        return await (command switch
        {
            Commands.InlineButtons => messageHandler.SendInlineKeyboard(msg),
            Commands.Keyboard => messageHandler.SendReplyKeyboard(msg),
            Commands.Remove => messageHandler.RemoveKeyboard(msg),
            Commands.Poll => messageHandler.SendPoll(msg),
            Commands.Throw => messageHandler.FailingHandler(msg),
            Commands.Start => messageHandler.Start(msg),
            _ => Task.FromResult(msg)
        });
    }
}