class Program
{
    static async Task Main(string[] args)
    {
        PhishingCards phish = new PhishingCards(2);
        FingerprintingCards fingerprint = new FingerprintingCards(2);
        HackCards hack = new HackCards(2);
        PITMCards pitm = new PITMCards(2);
        MetadataCards metadata = new MetadataCards(2);

        Deck cardDeck = new Deck([phish, fingerprint, hack, pitm, metadata], 4);
        int score = 0;

        do
        {
            Console.WriteLine($"Your score is {score}");
            Console.WriteLine("Pick one of the following cards:");
            Console.WriteLine(cardDeck.displayCardsInHand());
            Console.WriteLine("--------------------------------");
            string cardSelected = Console.ReadLine();
            score += await cardDeck.selectCard(cardSelected);

        } while (!cardDeck.isOver());
    }
}
