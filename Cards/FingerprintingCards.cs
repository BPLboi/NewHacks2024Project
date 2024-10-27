public class FingerprintingCards : CardType
{
    public FingerprintingCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Fingerprinting";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a fingerprinting attack against a difficulty {6 - numberLeft} Barbara";
    }

    override public async Task<int> cardAction()
    {
        numberLeft -= 1;
        return 0;
    }
}