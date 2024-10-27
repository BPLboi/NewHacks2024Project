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

    override public async Task<int> cardAction()
    {
        string answer = "";
        string availableInfo = "";
        string question = "";
        Random rn = new Random(Guid.NewGuid().GetHashCode());
        switch (difficulty)
        {
            case 1:
                //Generates a 'random name'
                question = "What is the recipient's name?";
                string[] names = ["Olivia", "Noah", "Emma", "Liam", "Ava", "Ethan", "Sophia", "Mason", "Isabella", "Jacob", "Charlotte", "William", "Mia", "Michael", "Evelyn", "Alexander", "Emily", "James", "Abigail", "Benjamin"];
                answer = names[rn.Next(20)];
                availableInfo = $"Hey {answer}, you busy rn?";

                break;
            case 2:
                //generates a random DOB
                question = "Can you figure out John's date of birth? (Answer in mm/dd/yyyy format)";
                int year = rn.Next(40) + 1960;
                int month = rn.Next(12) + 1;
                int day = rn.Next(28) + 1;
                int offset = rn.Next(10) + 10;
                answer = (month).ToString() + "/" + (day).ToString() + "/" + year.ToString();
                availableInfo = $"Happy {ordinal_suffix_of(offset)} birthday John!\nSent on {(month).ToString() + "/" + (day).ToString() + "/" + (year + offset).ToString()} at 4:13pm";
                break;
            case 3 or 4:
                question = "Can you find out which address John is going to?";
                GeminiRequester req = new GeminiRequester();
                string coords = await req.message("pick a random latitude and longitude in north america and respond in EXACTLY the format [latitude],[longitude]");
                availableInfo = @$"Some sick new flowers just grew near my house:
[photo of flowers]
By the way, want to grab lunch at the Starbucks near me tomorrow?
---------------------------------
Image Name: IMG_5481
File Size: 5.6 MB
File Type: JPG
Image Location: {coords}
Image Size: 1284 x 2778
Created: September 15th, 2024, 15:09";
                answer = await req.message($"Return the address of the Starbucks nearest to the latitude,longitude coordinates of {coords} in EXACTLY the format [address]");
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
                numberLeft -= 1;
                difficulty++;
                return 1;
            }
        }

        Console.WriteLine($"Unfortunately, you could not figure out the correct answer, which was: {answer}");
        numberLeft -= 1;
        return 0;
    }
}