using Snake;

Console.Title = "Snake";
while(true)
{
    Game newGame = new Game();
    newGame.Run();
    while(true)
    {
        ConsoleKeyInfo input = Console.ReadKey(true);
        
        if (input.Key == ConsoleKey.Escape)
        {
            Environment.Exit(0);
        }
        else if (input.Key == ConsoleKey.Enter)
        {
            break;
        }
    }
}
