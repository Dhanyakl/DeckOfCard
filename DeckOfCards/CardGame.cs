using DeckOfCards;

public class CardGame: ICard
{
    public List<CardMain> CardSet;

    public Random RandomNo;
    public CardGame()
    {
        CardSet = new List<CardMain>();
        for (var i = 0; i < Enum.GetValues(typeof(CardSuit)).Length; i++)
        {
            for (var j = 0; j < Enum.GetValues(typeof(CardRank)).Length; j++)
            {
                var card = new CardMain((CardSuit)i, (CardRank)j);
                CardSet.Add(card);
            }
        }
        RandomNo = new Random();
    }

    public void Shuffle()
    {
        for (int FirstCard = 0; FirstCard < CardSet.Count; FirstCard++)
        {
            int SecondCard = RandomNo.Next(CardSet.Count);
            CardMain temp = CardSet[FirstCard];
            CardSet[FirstCard] = CardSet[SecondCard];
            CardSet[SecondCard] = temp;
        }

        ShowCards();
    }

    public void ShowCards()
    {
        for (int count = 0; count < CardSet.Count; count++)
        {
            Console.Write("{0,-20}", CardSet[count]);
            if ((count + 1) % 4 == 0)
            {
                Console.WriteLine();
            }
        }

    }

    public void CompareCards()
    {
        List<CardMain> selectedcards = new List<CardMain>();
        for (int count = 0; count < 2; count++)
        {
            int SelectedCard = RandomNo.Next(CardSet.Count);
            selectedcards.Add(CardSet[SelectedCard]);
        }

        foreach (var card in selectedcards)
        {
            Console.WriteLine(card);
        }

        var compareCards = from cards in selectedcards
                           orderby cards.Rank ascending
                          select cards;
        var highestCard = compareCards.FirstOrDefault();
        var lowestCard = compareCards.LastOrDefault();
        Console.WriteLine($"{ highestCard} beats {lowestCard}");
    }

    public void SortCards()
    {
        var tempSuit = string.Empty;
        var currentSuit = string.Empty;
        List<CardMain> sorted = GetSortedList();
        for (int count = 0; count < sorted.Count; count++)
        {
            currentSuit = Convert.ToString(sorted[count].Suit);
            if (currentSuit != string.Empty &&
                tempSuit != string.Empty &&
                currentSuit != tempSuit)
            {
                Console.WriteLine();
            }
            Console.Write(sorted[count]);
            Console.WriteLine();
            tempSuit = Convert.ToString(sorted[count].Suit);
        }
    }

    private List<CardMain> GetSortedList()
    {
        return CardSet
                        .GroupBy(l => l.Suit)
                        .OrderByDescending(g => g.Count())
                        .SelectMany(g => g.OrderByDescending(c => c.Rank)).ToList();
    }

    public void SelectedSuit()
    {
        Console.WriteLine("Select a suit");
        Console.WriteLine("0. Clubs");
        Console.WriteLine("1. Diamonds");
        Console.WriteLine("2. Hearts");
        Console.WriteLine("3. Spades");
        int selectedSuit = Convert.ToInt16(Console.ReadLine());
        List<CardMain> selectedSuiteCards = new List<CardMain>();
        var selectedSuiteName = Enum.GetName(typeof(CardSuit), selectedSuit);
        for (var i = 0; i < Enum.GetValues(typeof(CardRank)).Length; i++)
         {
            var card = new CardMain((CardSuit)selectedSuit, (CardRank)i);
            selectedSuiteCards.Add(card);
         }
        foreach(var card in selectedSuiteCards)
        {
            Console.WriteLine(card);
        }
    }

    public void CardsinHand()
    {
        Console.WriteLine("Input the number of cards wish to draw");
        int cardCount = Convert.ToInt16(Console.ReadLine());
        List<CardMain> selectedcards = new List<CardMain>();
        if(cardCount> 52 || cardCount <0)
        {
            Console.WriteLine("Invalid input. Enter a valid number");            
        }
        for (int count = 0; count < cardCount; count++)
        {
            int SelectedCard = RandomNo.Next(CardSet.Count);
            selectedcards.Add(CardSet[SelectedCard]);
        }

        foreach (var card in selectedcards)
        {
            Console.WriteLine(card);
        }
       
    }
}