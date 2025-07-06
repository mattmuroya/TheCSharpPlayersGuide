// Init distance
int manticoreDistance = ValidateDistanceInput(
    "Player 1, how far away from the city do you want to station the Manticore (0–100)? ");

Console.Clear();

// Init game values
int round = 1;
int manticoreHealth = 10;
int consolasHealth = 15;
bool gameover = false;
string winner = null;

Console.WriteLine("Player 2, it is your turn.");

// Game loop
while (!gameover)
{
    Console.Write(
        $"-----------------------------------------------------------\n" +
        $"STATUS: Round {round}  City: {consolasHealth}/15  Manticore: {manticoreHealth}/10\n" +
        $"The cannon is expected to deal ");

    int roundDamage = GetRoundDamageAndSetForegroundColor(round);
    Console.Write($"{roundDamage} damage ");

    Console.ResetColor();
    Console.WriteLine("this round.");
    Console.Write("Enter desired cannon range: ");

    // Get player input
    int launchDistance = ValidateDistanceInput(
        "Enter desired cannon range (0-100): ");

    // Measure strike accuracy
    if (launchDistance == manticoreDistance)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= roundDamage;
    }
    else if (launchDistance < manticoreDistance)
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }
    else if (launchDistance > manticoreDistance)
    {
        Console.WriteLine("That round OVERSHOT the target.");
    }
    
    // Check win conditions
    if (manticoreHealth <= 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        gameover = true;
    }
    else
    {
        consolasHealth--;
    }

    // Check city health
    if (consolasHealth <= 0)
    {
        Console.WriteLine("The city of Consolas has been destroyed. GAME OVER.");
        gameover = true;
    }
    else round++;
}

int ValidateDistanceInput(string promptText, int min=0, int max=100)
{
    int distance = -1;
    while (distance < min || distance > max)
    {
        Console.Write(promptText);
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            distance = input;
        }
    }
    return distance;
}

int GetRoundDamageAndSetForegroundColor(int round)
{
    int damage = 1;
    if (round % 5 == 0 && round % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        damage = 10;
    }
    else if (round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        damage = 3;
    }
    else if (round % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        damage = 3;
    }
    return damage;
}
