public class PhishingCards : CardType
{
    public PhishingCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Phishing";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a phishing attack.";
    }

    override public async Task<int> cardAction(NPC npc)
    {
        numberLeft -= 1;
        Console.WriteLine($"Write a message that convinces {npc.npcName} to give you 5,000 USD!\n");
        GeminiRequester requester = new GeminiRequester();

        string textAI = @$"You are {npc.npcName}, a person whose susceptibility to scams is {9 - npc.defenses.Count} on a scale of 0 to 10. After this message, you will recieve a series of emails.\n
As {npc.npcName}, reply to them in email format. Also provide a score from 0-10 on how likely you are to give the sender of this message $5,000.\n
Provide it in EXACTLY the following format. You do not chat with the user, you only reply with the response and score and nothing else in the same line.\n
[{npc.npcName}'s response in email format]|
[score from 0-10]";

        await requester.message(textAI);

        string outputMsg;
        int spamLevel = 0;
        int tries = 5;

        for (int i = 0; i < tries && spamLevel < 5; i++)
        {
            string inputMsg = Console.ReadLine();
            string geminiMsg = await requester.message(inputMsg);

            String[] responseLines = geminiMsg.Split(['|']);
            try
            {
                (outputMsg, spamLevel) = (responseLines[0].Trim(), Int32.Parse(responseLines[1].Trim()));
            }
            catch
            {
                Console.WriteLine("Out of bounds error in phishing attack. Message resieved was: \n" + geminiMsg);
                return printMoney(false);
            }

            Console.WriteLine($"-----------------------\n{outputMsg}\n------------------------\n");
            // Console.WriteLine($"For debugging purposes, spamLevel:{spamLevel}");
            if (spamLevel < 5)
            {
                Console.WriteLine($"Uh-oh. You were a bit too abrupt, and {npc.npcName} got suspicious. Try again!\n");
            }
            else
            {
                Console.WriteLine("Congratulations on getting that dough!");
                return printMoney(5000);
            }
        }

        Console.WriteLine($"{npc.npcName} has stopped responding. Challenge failed.");
        return 0;
    }
}