using DeckOfCards;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class CardMain
{
    public CardMain(CardSuit suit, CardRank rank)
    {
        Suit = suit;
        Rank = rank;
    }
    public CardSuit Suit { get; set; }

    public CardRank Rank { get; set; }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }

    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var instance = host.Services.GetService<ICard>();
        CardOperations(instance);
    }

    private static void CardOperations(ICard card)
    {
        ShowMessage();
        ExecuteGame(card);
        Console.WriteLine();
        Console.WriteLine("Do you want to continue. Press Y or N");
        var response = Console.ReadLine();
        if (!String.IsNullOrEmpty(response) && 
            response.ToUpper() == "Y") 
        { 
            CardOperations(card); 
        }
    }

    private static void ExecuteGame(ICard card)
    {
        int selectedOption = Convert.ToInt16(Console.ReadLine());
        switch (selectedOption)
        {
            case 1:
                card.Shuffle();
                break;
            case 2:
                card.CompareCards();
                break;
            case 3:
                card.SortCards();
                break;
            case 4:
                card.SelectedSuit();
                break;
            case 5:
                card.CardsinHand();
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }

    private static void ShowMessage()
    {
        Console.WriteLine(CardOptionMessages.Game1);
        Console.WriteLine(CardOptionMessages.Game2);
        Console.WriteLine(CardOptionMessages.Game3);
        Console.WriteLine(CardOptionMessages.Game4);
        Console.WriteLine(CardOptionMessages.Game5);
        Console.WriteLine(CardOptionMessages.Default);
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory());
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<ICard, CardGame>();
            });

        return hostBuilder;
    }
}