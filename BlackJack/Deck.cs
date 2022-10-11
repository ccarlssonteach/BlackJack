namespace BlackJack;
public class Deck
{
    private int _nrOfDecks;
    private List<Card> _cards = new List<Card>();
    private readonly Random rng = new();

    public Deck(int nrOfDecks)
    {
        _nrOfDecks = nrOfDecks;
 
    }

    public void ResetAndShuffle()
    {
        _cards = CreateDecks();
        Shuffle();
    }

    public void Shuffle()
    {
        List<Card> tmpDeck = new List<Card>();
        while (_cards.Count > 0)
        {
            Card card = _cards[rng.Next(_cards.Count)];
            tmpDeck.Add(card);
            _cards.Remove(card);
        }
        _cards = tmpDeck;
    }

    public Card Draw()
    {
        Card card = _cards[0];
        _cards.Remove(card);
        return card;
    }

    private List<Card> CreateDecks()
    {
        List<Card> cards = new List<Card>();
        for (int decks = 0; decks < _nrOfDecks; decks++)
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    cards.Add(new Card(value, (SuitType)suit));
                }
            }
        }
        return cards;
    }
}
