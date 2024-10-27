public class PITMCards : CardType // Person in the middle
{
    public PITMCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Person in the middle";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a person in the middle attack.";
    }

    override public async Task<int> cardAction()
    {
        Console.WriteLine("Determine if this message contains any personal information relevant to the text message below (write answer as 'Y' or 'N'):");

        GeminiRequester requester = new GeminiRequester();

        string textAI = @$"You are Nathan, a person who is susceptible to blurting out information. You are sending an online message through your choice of either email or text message to another friend in which you MAY or MAY NOT send any personal information (also through your choice of topic). 

As Nathan, please write the exact online message you are writing, provide whether or not you are sending any personal information on the message, and if you are including personal information, please include what specific category it may pertain to. For the blank parts of the message, I want you to fill out random generated names for the specificed topic (including the person who you are talking to, this can be any random name). 
Provide it in EXACTLY the following format. You do not chat with the user, you only reply with the response and score and nothing else.
Online Message: [Nathan's Online Message]|
Data or No Data? (Y/N) [Yes or No Answer]|
What Category of Personal Information? [Category Written Here]";

        string geminiMsg = await requester.message(textAI);
        await requester.message(textAI);
        String[] responseLines = geminiMsg.Split(['|']);

        string outputMsg;
        string yorN;
        string whySo;
        try
        {
            (outputMsg, yorN, whySo) = (responseLines[0].Trim(), responseLines[1].Trim(), responseLines[2].Trim());
        }
        catch
        {
            Console.WriteLine("Out of bounds error in person in the middle attach. message reseived was: \n" + geminiMsg);
            numberLeft -= 1;
            return 0;
        }
        Console.WriteLine($"-----------------------\n{outputMsg}\n------------------------\n");
        int tries = 5;
        for (int i = 0; i < tries; i++)
        {
            string inputMsg = Console.ReadLine();
            if (inputMsg.Contains("Y") && yorN.Contains("Y"))
            {
                Console.WriteLine("Yes! This does contain personal information. This is because of: " + whySo + ".");
                return 1;
            }
            else if (inputMsg.Contains("N") && yorN.Contains("N"))
            {
                Console.WriteLine("Yes! This does NOT contain personal information. There is no relevant information given from the text above that shows there is something related to the person.");
                return 1;
            }
            else if (inputMsg.Contains("N") && yorN.Contains("Y"))
            {
                Console.WriteLine("Whoa, be careful of how you analyze the online message! This contains personal information as it falls under the category of: " + whySo + ".");
            }
            else if (inputMsg.Contains("Y") && yorN.Contains("N"))
            {
                Console.WriteLine("You might have taken this prompt too seriously! This does NOT contain any information relevant to the person.");
            }
            else
            {
                Console.WriteLine("Error.");
            }
        }
        Console.WriteLine("Nathan has stopped responding. Challenge Failed.");
        numberLeft -= 1;
        return 0;
    }
}