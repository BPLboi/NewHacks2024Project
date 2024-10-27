public class MetadataCards : CardType
{
    public MetadataCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Metadata";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a metadata attack against a difficulty {6 - numberLeft} Barbara";
    }

    override public async Task<int> cardAction()
    {
        numberLeft -= 1;
        return 0;
    }
}