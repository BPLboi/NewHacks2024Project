public class FingerprintingCards : CardType
{
    public FingerprintingCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Fingerprinting";
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a fingerprinting attack.";
    }

    override public async Task<int> cardAction()
    {
        Console.WriteLine("You are a hacker that is trying to determine a specific person's ad and video watch time based on the topic of interest, to find your next victim.");
        Console.WriteLine("There is information given about the technical details of the topic of interest pertaining to the ad, as well as how many minutes of ads per video.");
        string[] topics = ["Music", "Comedy", "Vlogs", "Education", "Video Games", "Music", "Vlogs", "Video Games", "Education", "Comedy"];
        double[] minutes = [3.19, 1.05, 0.30, 2.47, 3.58, 3.01, 0.48, 4.22, 2.41, 2.28];
        for (int i = 0; i < Math.Max(topics.Length, minutes.Length); i++)
        {
            Console.WriteLine(topics[i] + ": " + minutes[i]);
        }
        Console.WriteLine("Based on the data given above, determine the topic in which the user has watched the most amount of ad content.");
        string input = Console.ReadLine();
        if (input.Equals("Video Games"))
        {
            Console.WriteLine("Yes! You got it correct! The topic Video Games is definetly a topic that this user is interested in.");
        }
        else if (input.Equals("Music") || input.Equals("Comedy") || input.Equals("Vlogs") || input.Equals("Education"))
        {
            Console.WriteLine("Sorry, that is incorrect. Unfortunately, this user does not watch as much of this topic as specified above, and rather watches Video Games a lot.");
        }
        else
        {
            Console.WriteLine("Error.");
        }
        Console.WriteLine("Moving on, let's say that you wanted to communicate to this user in your preferred form of online internet communication in order to get them hooked to your fake message and click on the link. Which topic would you focus on in your communication method?");
        string input2 = Console.ReadLine();
        if (input.Equals("Video Games"))
        {
            Console.WriteLine("Yes! You got it correct! Because of this topic, we can target their interests because we know that they watch a lot of video game content.");
            return printMoney(true);
        }
        else if (input.Equals("Music") || input.Equals("Comedy") || input.Equals("Vlogs") || input.Equals("Education"))
        {
            Console.WriteLine("Sorry, that is incorrect. Unfortunately, this user would not be hooked onto your message because they do not watch as much of this topic as specified above, and rather watches Video Games a lot.");
        }
        else
        {
            Console.WriteLine("Error.");
        }
        numberLeft -= 1;
        return printMoney(false);
    }
}