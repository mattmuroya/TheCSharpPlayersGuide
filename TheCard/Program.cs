namespace TheCard;

class Program
{
    static void Main(string[] args)
    {
        Card[] deck = new Card[56];
         
        int i = 0;
        foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                deck[i] = new Card(color, rank);
                i++;
            }
        }

        foreach (var card in deck)
        {
            card.Print();
        }
    }
}

class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
    }

    public void Print()
    {
        Console.WriteLine($"The {Color} {Rank}");
    }
}

enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow,
}

enum CardRank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Caret,
    Ampersand
}