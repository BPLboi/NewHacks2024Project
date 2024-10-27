public class HackCards : CardType
{
    public HackCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Hack";
    }

    override public string displayCard()
    {
        return $"\u001b[1;33m{cardName}\u001b[0m: Attempt to hack someone's device.";
    }

    override public async Task<int> cardAction(NPC npc)
    {
        numberLeft -= 1;
        if (npc.defenses.Contains("Installs security updates"))
        {
            Console.WriteLine($"Uh-oh. {npc.npcName}'s security updates were too strong for your hacks.");
            return printMoney(false);
        }
        if (npc.defenses.Contains("Uses antivirus software"))
        {
            Console.WriteLine($"Uh-oh. {npc.npcName}'s antivirus software deleted your malware.");
            return printMoney(false);
        }

        Console.WriteLine($"You approach {npc.npcName} at a party and make small talk and mini chatter.");
        Console.WriteLine("You ask to borrow their phone to make a phone call, and secretly send a virus to their device.");
        return printMoney(true);
    }
}