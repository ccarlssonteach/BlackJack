using BlackJack;

Game game = new Game();


game.IsInitialDealDone = false;
game.PlayerDraw();
game.DealerDraw();
game.PlayerDraw();
game.DealerDraw();
game.IsInitialDealDone = true;

PrintCards();

HandlePlayer();

HandleDealer();

PrintResult();

void PrintResult()
{
    PrintCards(true);
    switch (game.Status)
    {
        case GameStatus.BlackJack:
            Console.WriteLine("Black Jack! Grattis, du vann!");
            break;
        case GameStatus.Won:
            Console.WriteLine("Grattis du vann...");
            break;
        case GameStatus.Lost:
            Console.WriteLine("Dealern vann");
            break;
        case GameStatus.Tie:
            Console.WriteLine("Det blev oavgjort");
            break;
        default:
            Console.WriteLine("Något gick fel..");
            break;
    }
}

void HandlePlayer()
{
    while (game.Status == GameStatus.Playing)
    {
        Console.WriteLine("Do you want another card? [Y/n]");
        bool draw = Console.ReadKey(true).Key != ConsoleKey.N;
        if (draw)
        {
            game.PlayerDraw();
        }
        else
        {
            break;
        }
        Console.Clear();
        PrintCards();
    }

}


void HandleDealer()
{
    while (game.Status == GameStatus.Playing)
    {
        game.DealerDraw();
        Thread.Sleep(1000);
        PrintCards(true);
    }
}


void PrintCards(bool includeDealerHand = false)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"You got: {game.Player.BestValue}");
    Console.WriteLine(game.Player);
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;

    if (includeDealerHand)
    {
        Console.WriteLine($"Dealer got: {game.Dealer.BestValue} ");
        Console.WriteLine(game.Dealer);
    }
    else
    {
        Console.WriteLine($"Dealer got: ");
        Console.WriteLine(game.Dealer.LastDrawnCard);
    }
    Console.ResetColor();
}
