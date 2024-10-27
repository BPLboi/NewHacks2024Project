using System.Collections;

public class MetadataCards : CardType
{
    int difficulty;
    public MetadataCards(int numCards)
    {
        numberLeft = numCards;
        cardName = "Metadata";
        difficulty = 1;
    }

    override public string displayCard()
    {
        return $"{cardName}: Apply a metadata attack.";
    }

    static string ordinal_suffix_of(int i)
    {
        int j = i % 10,
            k = i % 100;
        if (j == 1 && k != 11)
        {
            return i + "st";
        }
        if (j == 2 && k != 12)
        {
            return i + "nd";
        }
        if (j == 3 && k != 13)
        {
            return i + "rd";
        }
        return i + "th";
    }

    override public async Task<int> cardAction(NPC npc)
    {
        numberLeft -= 1;
        string answer = "";
        string availableInfo = "";
        string question = "";
        Random rn = new Random(Guid.NewGuid().GetHashCode());
        switch (difficulty)
        {
            case 1:
                //generates a random DOB
                question = $"Can you figure out {npc.npcName}'s date of birth? (Answer in mm/dd/yyyy format)";
                int year = rn.Next(40) + 1960;
                int month = rn.Next(12) + 1;
                int day = rn.Next(28) + 1;
                int offset = rn.Next(10) + 10;
                answer = (month).ToString() + "/" + (day).ToString() + "/" + year.ToString();
                availableInfo = $"Happy {ordinal_suffix_of(offset)} birthday {npc.npcName}!\nSent on {(month).ToString() + "/" + (day).ToString() + "/" + (year + offset).ToString()} at 4:13pm";
                break;
            case 2 or 3:
                question = $"Can you find out which city {npc.npcName} lives in?";
                GeminiRequester req = new GeminiRequester();
                string city = (await req.message("Pick a random city and respond in EXACTLY the format [city]")).Trim();
                answer = city.Substring(1, city.Length - 2);
                string coords = await req.message($"Return the latitude and longitude coordinates of {city} in EXACTLY the format\n[latitude],[longitude]");
                availableInfo = @$"Some sick new flowers just grew near my house:
[photo of flowers]
By the way, want to grab lunch at the Starbucks near me tomorrow?
- {npc.npcName}
---------------------------------
Image Name: IMG_5481
File Size: 5.6 MB
File Type: JPG
Image Location: {coords}
Image Size: 1284 x 2778
Created: September 15th, 2024, 15:09";
                break;
        }

        Console.WriteLine(availableInfo);
        Console.WriteLine("-----------------------------");
        Console.WriteLine(question);

        for (int trials = 0; trials < 5; trials++)
        {
            string input = Console.ReadLine();
            if (input.Equals(answer))
            {
                Console.WriteLine("-----------------------------------\nCongratulations on finding the correct answer!");
                difficulty++;
                return printMoney(true);
            }
        }

        Console.WriteLine($"Unfortunately, you could not figure out the correct answer, which was: {answer}");
        return printMoney(false);
    }
}