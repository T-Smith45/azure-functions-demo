namespace az_func.demo2;

public record Quote(string author, string message, string category);

public interface IQuoteService
{
    Quote GetRandomQuote();
    Quote GetRandomQuoteWithCategory(string category);
}

public class QuoteService : IQuoteService
{
    private readonly List<Quote> _quotes =
    [
        new("Albert Einstein", "Life is like riding a bicycle. To keep your balance, you must keep moving.",
            "Inspiration"),
        new("Winston Churchill",
            "Success is not final, failure is not fatal: It is the courage to continue that counts.", "Success"),
        new ("Maya Angelou", "You will face many defeats in life, but never let yourself be defeated.",
            "Resilience"),
        new ("Steve Jobs", "The only way to do great work is to love what you do.", "Work"),
        new Quote("Nelson Mandela", "It always seems impossible until it’s done.", "Perseverance"),
        new ("Confucius", "It does not matter how slowly you go as long as you do not stop.", "Motivation"),
        new ("Eleanor Roosevelt", "The future belongs to those who believe in the beauty of their dreams.",
            "Dreams"),
        new ("Mark Twain", "The secret of getting ahead is getting started.", "Action"),
        new ("Helen Keller", "Optimism is the faith that leads to achievement.", "Optimism"),
        new ("Aristotle", "We are what we repeatedly do. Excellence, then, is not an act, but a habit.",
            "Excellence"),
        new("Ralph Waldo Emerson", "What lies behind us and what lies before us are tiny matters compared to what lies within us.", "Inspiration"),
        new ("Carl Sagan", "Somewhere, something incredible is waiting to be known.", "Inspiration"),
        new ("Leonardo da Vinci", "Simplicity is the ultimate sophistication.", "Inspiration"),
        new ("Thomas Edison", "Many of life's failures are people who did not realize how close they were to success when they gave up.", "Success"),
        new ("Vince Lombardi", "The only place success comes before work is in the dictionary.", "Success"),
        new ("Tony Robbins", "Success is doing what you want, when you want, where you want, with whom you want, as much as you want.", "Success"),
        new ("Thomas Edison", "Many of life's failures are people who did not realize how close they were to success when they gave up.", "Success"),
        new ("Vince Lombardi", "The only place success comes before work is in the dictionary.", "Success"),
        new ("Tony Robbins", "Success is doing what you want, when you want, where you want, with whom you want, as much as you want.", "Success"),



    ];
    
    public Quote GetRandomQuote()
    {
        var random = new Random();
        return _quotes[random.Next(_quotes.Count)];
    }

    public Quote GetRandomQuoteWithCategory(string category)
    {
       var quotes =  _quotes
           .Where(q => string.Equals(q.category, category, StringComparison.CurrentCultureIgnoreCase))
           .ToList();
       var random = new Random();
       return quotes.Count == 0 
           ? new Quote("None", "No Quote Found", "")
           : quotes[random.Next(quotes.Count)];
    }
}
