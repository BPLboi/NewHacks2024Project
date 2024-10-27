public abstract class CardType
{
    public string cardName = "";
    public int numberLeft;
    public abstract Task<int> cardAction(); //Plays out the events specified by the card
    public abstract string displayCard();
    public int printMoney(bool earning) {
        int num;
        if (earning) {
            Random rn = new Random(Guid.NewGuid().GetHashCode());
            num = rn.Next(500);
            Console.WriteLine($"You maliciously earned ${num}!\n");
        } else {
            num = -30;
            Console.WriteLine($"You wasted ${num} on that attack :(");
        }
        return num;
    }
    public int printMoney(int num) {
        Console.WriteLine($"You maliciously earned ${num}!\n");
        return num;
    }
}