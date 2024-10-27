
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;


public class Deck
{
    CardType[] cards;
    CardType[] inHand;
    Dictionary<CardType, int> numCardLeft; //the number of each cardtype left in the deck (and not in the hand)
    int cardsInHand;

    public Deck(CardType[] cards, int startingInHand)
    {
        this.cards = cards;
        cardsInHand = 0;

        //Counts
        numCardLeft = new Dictionary<CardType, int>();
        foreach (CardType c in cards)
        {
            numCardLeft[c] = c.numberLeft;
        }

        //if the intended number of starting cards is larger than the total number of cards, 
        // limit to the number of cards available
        inHand = new CardType[Math.Min(startingInHand, numCardLeft.Sum(x => x.Value))];
        for (int i = 0; i < inHand.Length; i++)
        {
            inHand[i] = GetCard();
        }
    }

    CardType GetCard()
    {
        Random rn = new Random(Guid.NewGuid().GetHashCode());
        int num = rn.Next(numCardLeft.Sum(x => x.Value));

        foreach (CardType c in cards)
        {
            if (num < numCardLeft[c])
            {
                numCardLeft[c] -= 1;
                cardsInHand += 1;
                return c;
            }

            num -= numCardLeft[c];
        }
        return null;
    }

    public async Task<int> selectCard(string choice, NPC npc)
    {
        for (int i = 0; i < inHand.Length; i++)
        {
            if (inHand[i] == null) continue;
            if (inHand[i].cardName.Equals(choice))
            {
                cardsInHand -= 1;
                int result = await inHand[i].cardAction(npc);

                inHand[i] = GetCard();
                return result;
            }
        }
        Console.WriteLine("Could not find that card\n\n");
        return 0;
    }

    public string displayCardsInHand()
    {
        string result = "";
        foreach (CardType c in inHand)
        {
            if (c == null) continue;
            result += c.displayCard();
            result += "\n";
        }

        result.Trim();
        return result;
    }

    public bool isOver()
    {
        return cards.Sum(x => x.numberLeft) == 0;
    }

}