class Program
{
    static async Task Main(string[] args)
    {
        //Sets up all the different kinds of card attacks
        PhishingCards phish = new PhishingCards(3);
        FingerprintingCards fingerprint = new FingerprintingCards(2);
        HackCards hack = new HackCards(2);
        PITMCards pitm = new PITMCards(2);
        MetadataCards metadata = new MetadataCards(3);

        Deck cardDeck = new Deck([phish, fingerprint, hack, pitm, metadata], 4);
        
        //Sets up a list of NPCs
        NPC[] npcs = new NPC[5];
        for(int i = 0; i< npcs.Length; i++){
            npcs[i] = await NPC.CreateNPC();
            npcs[i].DisplayNPC();
        }

        int money = 0;

        // initial game
        Console.WriteLine("Welcome.\nYou are a hacker.\nYour goal is to steal data and money from the innocent Barbaras of this world.");
        Console.WriteLine("Use the attack cards wisely to maximise your profit.\n\n");

        //As long as there are cards to choose from, lets the user pick a card to play
        do
        {
             Console.WriteLine($"You currently have ${money}\n\n");
            Console.WriteLine("Pick one of the following cyber attack cards:");
            Console.WriteLine(cardDeck.displayCardsInHand());
            Console.WriteLine("--------------------------------");
            string cardSelected = Console.ReadLine();
            money += await cardDeck.selectCard(cardSelected);

        } while (!cardDeck.isOver());

        // game over
        Console.WriteLine("Out of cards!");
         Console.WriteLine($"You finished the game with ${money}\n\n");
    }
}
