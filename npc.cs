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

        GeminiRequester req = new GeminiRequester();
        if (npc.defensesArray.Length == 0) {
            npc.npcDesc = await req.message($"Return a creative, quirky one-sentence bio for {npc.npcName} written from the perspective of {npc.npcName}");
        } else {
            npc.npcDesc = await req.message($"Return a one-sentence bio for {npc.npcName} written from the perspective of {npc.npcName}, a person who {string.Join(", ", npc.defenses)}");
        }
        npc.npcDesc = npc.npcDesc.Trim();
        return npc;
    }

    public void DisplayNPC()
    {
        Console.WriteLine($"{npcName}: {npcDesc}");
    }
}
