public class PITMCards : CardType // Person in the middle
{
    public PITMCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Person in the middle";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a person in the middle attack against a difficulty {6 - numberLeft} Barbara";
    }

    override public async Task<int> cardAction()
    {
        numberLeft -= 1;
        return 0;
    }
}