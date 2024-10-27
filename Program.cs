class Program
{
    static async Task Main(string[] args)
    {
        //Sets up all the different kinds of card attacks
        PhishingCards phish = new PhishingCards(1);
        FingerprintingCards fingerprint = new FingerprintingCards(1);
        HackCards hack = new HackCards(1);
        PITMCards pitm = new PITMCards(1);
        MetadataCards metadata = new MetadataCards(1);

        Deck cardDeck = new Deck([phish, fingerprint, hack, pitm, metadata], 4);

        //Sets up a list of NPCs
        NPC[] npcs = new NPC[3];
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i] = await NPC.CreateNPC();
        }

        int money = 0;

        // initial game
        Console.WriteLine("Welcome to Data Heist!\nYou are a hacker.\nYour goal is to steal data and money from the innocent Barbara-s of this world.");
        Console.WriteLine("Use the attack cards wisely to maximise your profit.");

        //As long as there are cards to choose from, lets the user pick a card to play
        do
        {
            Console.WriteLine("--------------------------------");
            if (money < 0)
            {
                Console.WriteLine($"You currently have -${-money}");
            }
            else
            {
                Console.WriteLine($"You currently have ${money}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Choose your target:");
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].DisplayNPC();
            }
            Console.WriteLine("--------------------------------");
            string npcSelected = Console.ReadLine().Trim();
            NPC npc = null;
            bool npcMatched = false;
            for (int i = 0; i < npcs.Length; ++i)
            {
                if (npcs[i].npcName == npcSelected)
                {
                    npc = npcs[i];
                    npcMatched = true;
                }
            }
            if (!npcMatched)
            {
                Console.WriteLine("Could not find your victim");
                continue;
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Pick one of the following cyber attack cards:");
            Console.WriteLine(cardDeck.displayCardsInHand().Trim('\n'));
            Console.WriteLine("--------------------------------");
            string cardSelected = Console.ReadLine().Trim();
            Console.WriteLine("--------------------------------");
            money += await cardDeck.selectCard(cardSelected, npc);
        } while (!cardDeck.isOver());

        // game over
        Console.WriteLine("Out of cards!");
        Console.WriteLine($"You finished the game with ${money}\n\n");
        if (money > 0)
        {
            Console.WriteLine("Congratulations, you've exploited the system and walked away with a profit.\n");
        }
        else
        {
            Console.WriteLine("The tables have turned. You've run out of funds, and it looks like this hacking journey has come to a costly end.\n");
        }
        Console.WriteLine("Today, you've walked the path of a hacker, exploiting weaknesses and cashing in on the innocent. But remember, for every attack, there are real-world consequences. Every vulnerability you exposed today reminds us of the importance of cybersecurity. In a world driven by data, even small breaches can have massive repercussions. Through this game, you've seen firsthand the power of security measures—how even a single password manager or an input filter can prevent an attack and save millions. The takeaway? Cybersecurity isn't just a layer; it's a lifeline. So, whether you're on the offense or defense, consider what you've learned, and recognize the critical role you play in a digital society.");
        Console.WriteLine("Thank you for playing. Stay vigilant, and remember: the internet is only as secure as we make it.\nGame over.");
    }
}
