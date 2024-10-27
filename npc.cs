public class NPC
{
    string[] defensesArray = {
        "Uses a VPN",
        "Low digital footprint",
        "Two-factor authentication",
        "Uses antivirus software",
        "Uses end-to-end encryption",
        "Uses password manager",
        "Installs security updates"
    };
    string npcName = "";
    string npcDesc = "";
    // generate using Gemini API calls
    List<string> defenses = new List<string>();

    public static async Task<NPC> CreateNPC(){
        NPC npc = new NPC();
        GeminiRequester req = new GeminiRequester();
        npc.npcName = await req.message(@"Produce a name like in the following example:
Michelle
Reply with JUST THIS INFORMATION. The formatting must match.");

        Random rn = new Random(Guid.NewGuid().GetHashCode());

        for (int i = 0; i < npc.defensesArray.Length; ++i)
        {
            int addDefense = rn.Next(3);
            if (addDefense == 1)
            { // 1/3 chance of adding each defense
                npc.defenses.Add(npc.defensesArray[i]);
            }
        }

        npc.npcDesc = await req.message($"Return a short bio for {npc.npcName} written from the perspective of {npc.npcName}, a person who {string.Join(", ", npc.defenses)}");
        return npc;
    }

    public void DisplayNPC(){
        Console.WriteLine($"{npcName}: {npcDesc}");
    }
}
