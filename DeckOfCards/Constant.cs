public enum CardSuit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public enum CardRank
{
    Ace,
    King,
    Queen,
    Jack,
    Ten,
    Nine,
    Eight,
    Seven,
    Six,
    Five,
    Four,
    Three,
    Two
}

public static class CardOptionMessages
{
    public const string Game1 = "1. Shuffle the cards";
    public const string Game2 = "2. Compare two cards";
    public const string Game3 = "3. Sort cards";
    public const string Game4 = "4. Select a suit to view the cards";
    public const string Game5 = "5. Card withdrawal with a count";
    public const string Default = "Select an option";
}