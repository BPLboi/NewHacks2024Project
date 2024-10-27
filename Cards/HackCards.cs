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
        Console.WriteLine("Imagine a scenario where you are in a party as a hacker and waned to start small talk and mini chatter.");
        Console.WriteLine("Once you got someone to start talking to you, they then start to know about you, you start to know about them, and overall you exchange names.");
        Console.WriteLine("Suppose you had the chance to be able to get their phone through asking them to exchange contacts and they trade phones with you.");
        Console.WriteLine("What Would You Do? (A: Use the phone to try and get access to the apps/telecommunications for personal information. B: Exhange each other's phone numbers! We exchanged personal interests!)");
        string input = Console.ReadLine();
        if (input.Equals("A"))
        {
            Console.WriteLine("Correct! Although they seem gullible enough to start conversations, these scenarios explain why you never trust someone else with your phone.");
            return printMoney(true);
        }
        else if (input.Equals("B"))
        {
            Console.WriteLine("Ooh, that's incorrect. This is a common form of hacking in which the hacker tries to steal personal information from your phone after getting the password through the hacker's perspective (can be through just skimming information to implementing any software while giving contact information).");
        }
        else
        {
            Console.WriteLine("Error.");
        }
        numberLeft -= 1;
        increment++;
        return printMoney(false);
    }
}