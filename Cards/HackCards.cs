public class HackCards : CardType
{
    int increment;
    public HackCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Hack";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a hacking attack.";
    }

    override public async Task<int> cardAction(NPC npc)
    {
        numberLeft -= 1;
        if (npc.defenses.Contains("Installs security updates"))
        {
            Console.WriteLine($"Uh-oh. {npc.npcName}'s security updates were too strong for your hacks.");
            return printMoney(false);
        }

        Console.WriteLine($"You approach {npc.npcName} at a party and make small talk and mini chatter.");
        Console.WriteLine("You ask to borrow their phone to make a phone call, and secretly send a virus to their device.");
        return printMoney(true);
    }
}