using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Contracts.Services;
using BethanysPieShop.Model;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Text;
using System.Text.Json;

namespace BethanysPieShop.Services
{
    public class TicketDataService : ITicketDataService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPieRepository _pieRepository;
        private static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        private Kernel _kernel;

        public TicketDataService(ITicketRepository TicketRepository, IPieRepository pieRepository, Kernel kernel)
        {
            _ticketRepository = TicketRepository;
            _pieRepository = pieRepository;
            _kernel = kernel;
        }

        public async Task<Ticket> AddMessageToTicket(int ticketId, TicketMessage ticketMessage)
        {
            Pie p = null;

            Ticket ticket = await _ticketRepository.GetTicketById(ticketId) ?? throw new Exception("Ticket not found");

            if (ticket.PieId != null)
            {
                p = await _pieRepository.GetPieById(ticket.PieId.Value);
            }

            await GetTicketMessageSentiment(ticketMessage);
            await GetTicketLanguage(ticketMessage);

            ticket.TicketMessages.Add(ticketMessage);

            ticket.LastModifiedDate = DateTime.Now;

            await SummarizeTicket(ticket, p);

            return await _ticketRepository.UpdateTicket(ticket);
        }

        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            Pie p = null;

            if (ticket.PieId != null && ticket.PieId != 0)
            {
                p = await _pieRepository.GetPieById(ticket.PieId.Value);
            }

            ticket.CreatedDate = DateTime.Now;
            ticket.LastModifiedDate = DateTime.Now;

            await SummarizeTicket(ticket, p);

            await GetTicketMessageSentiment(ticket.TicketMessages.First());
            await GetTicketLanguage(ticket.TicketMessages.First());

            return await _ticketRepository.AddTicket(ticket);
        }

        public async Task DeleteTicket(int ticketId)
        {
            await _ticketRepository.DeleteTicket(ticketId);
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _ticketRepository.GetAllTickets();
        }

        public async Task<Ticket> GetTicketDetails(int ticketId)
        {
            return await _ticketRepository.GetTicketById(ticketId);
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            await _ticketRepository.UpdateTicket(ticket);
        }

        public async Task<IEnumerable<Ticket>> GetTicketByCustomerId(string customerId)
        {
            return await _ticketRepository.GetTicketByCustomerId(customerId);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatus(TicketStatus ticketStatus)
        {
            return await _ticketRepository.GetTicketsByStatus(ticketStatus);
        }

        private async Task SummarizeTicket(Ticket ticket, Pie pie)
        {
            string[] satisfactionScores = ["Furious", "Unhappy", "Disappointed", "Indifferent", "Happy", "Delighted"];

            var prompt = $$"""
                You are assisting with a customer support ticketing system.
                Your task is to provide summaries of ticket messages to enable the support agent to quickly understand the context of the ticket.

                Below are the details of the current support ticket:

                Pie: {{pie?.Name ?? "Not specified"}}

                The ongoing message log is as follows:

                {{CombineTicketMessages(ticket.TicketMessages)}}

                Generate the following summaries:

                1. A concise summary, limited to 30 words, that captures as much essential information as possible. Avoid repeating the customer or product name, as this is already known. Specifically, highlight any particular questions or details mentioned, rather than just stating that questions or information were given. Summarize key points, such as pending questions or specific responses required, with a focus on the ticket’s current status and what kind of response from the next support agent would be most beneficial.

                2. A short, 8-word summary that acts as the ticket's title. The aim is to emphasize what's unique about this ticket.

                3. Lastly, write a 10-word summary of the most recent message from the CUSTOMER, disregarding any agent responses. Based solely on this, evaluate the customer's satisfaction level using one of these satisfaction scores:
                {{string.Join(", ", satisfactionScores)}}.
                Pay close attention to the customer's tone, as their emotional state is key to this assessment.

                The summaries will be for internal use by customer support agents only.

                Return the result as JSON in the following format: {
                  "summary": "string",
                  "title": "string",
                  "customerSatisfaction": "string"
                }
                Ensure that no markdown or HTML is included in your output.
                """;

            var chatService = _kernel.GetRequiredService<IChatCompletionService>();
            var chatResponse = await chatService.GetChatMessageContentAsync(prompt);

            var responseText = chatResponse.Content;

            var deserializedResponse = DeserializeResponse<ChatResponse>(responseText, SerializerOptions)!;

            var ticketSummary = deserializedResponse.Summary;
            var ticketTitle = deserializedResponse.Title;

            int? sentimentScore = Array.FindIndex(satisfactionScores, score => score == (deserializedResponse.CustomerSatisfaction ?? string.Empty));

            if (sentimentScore == -1)
            {
                sentimentScore = null;
            }

            ticket.CustomerSentimentScore = sentimentScore;
            ticket.Title = ticketTitle;
            ticket.Summary = ticketSummary;
        }


        private static TOutput? DeserializeResponse<TOutput>(string jsonContent, JsonSerializerOptions settings)
        {
            var jsonBytes = Encoding.UTF8.GetBytes(jsonContent);
            var jsonReader = new Utf8JsonReader(jsonBytes.AsSpan());
            return JsonSerializer.Deserialize<TOutput>(ref jsonReader, settings);
        }

        private string CombineTicketMessages(List<TicketMessage> messages)
        {
            var stringBuilder = new StringBuilder();

            foreach (var ticket in messages)
            {
                var role = ticket.IsSupportMessage ? "support" : "customer";
                stringBuilder.AppendLine($"message from role=\"{role}\": {ticket.Message}");
            }

            return stringBuilder.ToString();
        }

        private async Task GetTicketLanguage(TicketMessage ticketMessage)
        {
            var languageDetectionPrompt = $$"""
                You are a language detection model. Given the following text, detect the language and return only the two-letter ISO 639-1 language code (e.g., 'en' for English, 'fr' for French, 'es' for Spanish). Do not include any additional text or explanation, just the code. Text: {{ticketMessage.Message}}
                """;

            var translationPrompt = $$"""
                You are a translation model. Given the following text, translate it to English. Return only the translated text without any additional comments or explanations. 
                Text: {{ticketMessage.Message}}
                """;

            var chatService = _kernel.GetRequiredService<IChatCompletionService>();
            var chatResponse = await chatService.GetChatMessageContentAsync(languageDetectionPrompt);

            var detectedLanguage = chatResponse.Content.ToLower();
            ticketMessage.Language = detectedLanguage;

            if (detectedLanguage != "en")
            {
                chatResponse = await chatService.GetChatMessageContentAsync(translationPrompt);
                ticketMessage.MessageEn = chatResponse.Content;
            }
        }

        private async Task GetTicketMessageSentiment(TicketMessage ticketMessage)
        {
            var template = """
                You are a sentiment analysis model. Analyze the sentiment of the following text and return only one word: positive, neutral, or negative. Do not include any explanations or extra text.
                Text: {{$ticketMessage}}
                """;

            var arguments = new KernelArguments()
            {
                { "ticketMessage", ticketMessage.Message }
            };

            var function = _kernel.CreateFunctionFromPrompt(template);
            var detectedSentiment = await _kernel.InvokeAsync(function, arguments);

            ticketMessage.TicketMessageSentiment = detectedSentiment.ToString() switch
            {
                "positive" => (TicketMessageSentiment?)TicketMessageSentiment.Positive,
                "negative" => (TicketMessageSentiment?)TicketMessageSentiment.Negative,
                _ => (TicketMessageSentiment?)TicketMessageSentiment.Neutral,
            };
        }

        private class ChatResponse
        {
            public required string Summary { get; set; }
            public required string Title { get; set; }
            public string? CustomerSatisfaction { get; set; }
        }
    }
}