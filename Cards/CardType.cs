public abstract class CardType
{
    public string cardName = "";
    public int numberLeft;
    public abstract Task<int> cardAction(); //Plays out the events specified by the card
    public abstract string displayCard();
}