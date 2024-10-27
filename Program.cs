class Program
{
    static async Task Main(string[] args)
    {
        //Sets up all the different kinds of card attacks
        PhishingCards phish = new PhishingCards(2);
        FingerprintingCards fingerprint = new FingerprintingCards(2);
        HackCards hack = new HackCards(2);
        PITMCards pitm = new PITMCards(2);
        MetadataCards metadata = new MetadataCards(4);

        Deck cardDeck = new Deck([phish, fingerprint, hack, pitm, metadata], 4);
        int score = 0;

        //As long as there are cards to choose from, lets the user pick a card to play
        do
        {
            Console.WriteLine($"Your score is {score}\n\n");
            Console.WriteLine("Pick one of the following cyber attack cards:");
            Console.WriteLine(cardDeck.displayCardsInHand());
            Console.WriteLine("--------------------------------");
            string cardSelected = Console.ReadLine();
            score += await cardDeck.selectCard(cardSelected);

        } while (!cardDeck.isOver());
    }
}
