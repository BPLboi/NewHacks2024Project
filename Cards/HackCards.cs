public class HackCards : CardType
{
    int increment;
    public HackCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Hack";
        increment = 1;
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a hacking attack.";
    }

    override public async Task<int> cardAction()
    {
        Console.WriteLine("Imagine a scenario where you are in a party and a person came up to you with small talk and mini chatter.");
        Console.WriteLine("They then start to know about you, you start to know about them, and overall you exchange names.");
        Console.WriteLine("But, this is when they decide to ask for your phone in response to connecting with each other through online communications.");
        Console.WriteLine("What Would You Do? (A: Don't give the phone to them, and quietly walk away. B: Give them the phone number! We exchanged personal interests!)");
        string input = Console.ReadLine();
        if (input.Equals("A"))
        {
            Console.WriteLine("Correct! Although they seem gullible enough to start conversations, you never trust someone else with your phone.");
            return 1;
        }
        else if (input.Equals("B"))
        {
            Console.WriteLine("Ooh, that's incorrect. This is a common form of hacking in which the hacker tries to steal personal information from your phone after getting the password (can be through just skimming information to implementing any software while giving contact information).");
        }
        else
        {
            Console.WriteLine("Error.");
        }
        numberLeft -= 1;
        increment++;
        return 0;
    }
}