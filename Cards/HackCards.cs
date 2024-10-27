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
        return $"{cardName}: Apply a hacking attack against a difficulty {Math.Pow(increment, 2)} Barbara";
    }

    override public async Task<int> cardAction()
    {
        numberLeft -= 1;
        increment++;
        return 0;
    }
}