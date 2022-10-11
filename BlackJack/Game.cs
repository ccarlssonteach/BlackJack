namespace BlackJack;

public class Game
{
    public Player Player { get; set; } 
    public Player Dealer { get; set; }
    public Deck Deck { get; set; }
    public GameStatus Status { get; set; }
    public bool IsInitialDealDone { get; set; } = false;

    public Game()
    {
        Player = new Player();
        Dealer = new Player();
        Deck = new Deck(1);
        Deck.ResetAndShuffle();
        Status = GameStatus.Playing;
    }

    public void Reset()
    {
        Player.Reset();
        Dealer.Reset();
        Status = GameStatus.Playing;
    }

    public void PlayerDraw()
    {
        Player.Hand.Add(Deck.Draw());
        if(Player.BestValue == 21 && Player.Hand.Count == 2)
        {
            Status = GameStatus.BlackJack;
        }
        if(Player.BestValue > 21)
        {
            Status = GameStatus.Lost;
        }
    }

    public void DealerDraw()
    {
        Dealer.Hand.Add(Deck.Draw());

        if (!IsInitialDealDone)
            return;

        if (Dealer.BestValue > 16)
        {
            if (Dealer.BestValue > 21)
                Status = GameStatus.Won;
            else if (Dealer.BestValue == Player.BestValue)
                Status = GameStatus.Tie;
            else if (Dealer.BestValue < Player.BestValue)
                Status = GameStatus.Won;
            else if (Player.BestValue < Dealer.BestValue)
                Status = GameStatus.Lost;
        }
    }
}