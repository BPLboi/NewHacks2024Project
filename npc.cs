using System.Runtime.InteropServices;

public class NPC
{
    static List<string> names = ["Barbara", "Ethan", "Ava", "Liam", "Sophia", "Noah", "Mia", "Mason", "Charlotte", "Jacob", "Amelia", "William", "Evelyn", "Michael", "Harper", "Benjamin", "Ella", "James", "Avery", "Logan"];
    string[] defensesArray = {
        "Uses a VPN",
        "Low digital footprint",
        "Two-factor authentication",
        "Uses antivirus software",
        "Uses end-to-end encryption",
        "Uses password manager",
        "Installs security updates"
    };

    static List<string> randInterests = ["Photography", "Hiking", "Cooking", "Gardening", "Reading",
     "Traveling", "Painting", "Knitting", "Yoga", "Gaming", "Birdwatching", "Astronomy", "Volunteering",
      "Writing", "Music production", "Surfing", "Martial arts", "Cycling", "Collecting stamps", "Baking",
       "Fishing", "Stand-up comedy", "Woodworking", "Pottery", "History", "Meditation", "Dancing", "Scuba diving",
        "Fashion design", "Rock climbing", "Journaling", "Language learning", "Theater", "Podcasting", "Coding",
         "Calligraphy", "Vintage cars", "Home brewing", "Magic tricks", "Sports analytics", "Sculpting"];

    public string npcName = "";
    string npcDesc = "";
    // generate using Gemini API calls
    public List<string> defenses = new List<string>();

    public static async Task<NPC> CreateNPC()
    {
        NPC npc = new NPC();

        Random rn = new Random(Guid.NewGuid().GetHashCode());
        npc.npcName = names[rn.Next(names.Count)];
        names.Remove(npc.npcName);

        for (int i = 0; i < npc.defensesArray.Length; ++i)
        {
            int addDefense = rn.Next(3);
            if (addDefense == 1)
            { // 1/3 chance of adding each defense
                npc.defenses.Add(npc.defensesArray[i]);
            }
        }

        while (npc.defenses.Count < 3)
        {
            string interest = randInterests[rn.Next(randInterests.Count)];
            randInterests.Remove(interest);
            npc.defenses.Add(interest);
        }

        GeminiRequester req = new GeminiRequester();
        npc.npcDesc = await req.message($"Return a one-sentence bio for {npc.npcName} written from the perspective of {npc.npcName}, a person who {string.Join(", ", npc.defenses)}.");
        npc.npcDesc = npc.npcDesc.Trim();
        return npc;
    }

    public void DisplayNPC()
    {
        Console.WriteLine($"\u001b[4m{npcName}\u001b[0m: {npcDesc}");
    }
}
