using DeckOfCards;

public class CardGame: ICard
{
    public List<CardMain> cardSet;

    public Random randomNo;
    public CardGame()
    {
        cardSet = new List<CardMain>();
        for (var i = 0; i < Enum.GetValues(typeof(CardSuit)).Length; i++)
        {
            for (var j = 0; j < Enum.GetValues(typeof(CardRank)).Length; j++)
            {
                var card = new CardMain((CardSuit)i, (CardRank)j);
                cardSet.Add(card);
            }
        }
        randomNo = new Random();
    }

    public void Shuffle()
    {
        for (int firstCard = 0; firstCard < cardSet.Count; firstCard++)
        {
            int secondCard = randomNo.Next(cardSet.Count);
            CardMain temp = cardSet[firstCard];
            cardSet[firstCard] = cardSet[secondCard];
            cardSet[secondCard] = temp;
        }
        ShowCards();
    }

    public void ShowCards()
    {
        for (int count = 0; count < cardSet.Count; count++)
        {
            Console.Write("{0,-20}", cardSet[count]);
            if ((count + 1) % 4 == 0)
            {
                Console.WriteLine();
            }
        }
    }

    public void CompareCards()
    {
        List<CardMain> selectedCards = new List<CardMain>();
        for (int count = 0; count < 2; count++)
        {
            int selectedCard = randomNo.Next(cardSet.Count);
            selectedCards.Add(cardSet[selectedCard]);
        }
        foreach (var card in selectedCards)
        {
            Console.WriteLine(card);
        }
        var compareCards = from cards in selectedCards
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
        return cardSet
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
        List<CardMain> selectedCards = new List<CardMain>();
        if(cardCount> 52 || cardCount <0)
        {
            Console.WriteLine("Invalid input. Enter a valid number");
            return;
         }
        for (int count = 0; count < cardCount; count++)
        {
            int SelectedCard = randomNo.Next(cardSet.Count);
            selectedCards.Add(cardSet[SelectedCard]);
        }
        foreach (var card in selectedCards)
        {
            Console.WriteLine(card);
        }
    }
}
