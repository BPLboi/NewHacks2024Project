// using System.Collections;
// using System.Collections.Generic;


// public class NPC
// {
//     public string[] defensesArray = {
//         "Uses a VPN",
//         "Low digital footprint",
//         "Two-factor authentication",
//         "Uses antivirus software",
//         "Uses end-to-end encryption",
//         "Uses password manager",
//         "Installs security updates"
//     };
//     public string npcName = "Name A";
//     public string npcDesc = "I like gardening";
//     // generate using Gemini API calls
//     public List<string> defenses = new List<string>();

//     void Start()
//     {
//         for (int i = 0; i < defensesArray.Length; ++i)
//         {
//             int addDefense = Random.Range(0, 3);
//             if (addDefense == 1)
//             { // 1/3 chance of adding each defense
//                 defenses.Add(defensesArray[i]);
//             }
//         }
//     }

//     // On mouse click, show the card
//     void OnMouseDown()
//     {
//         FindObjectOfType<CardManager>().ShowNPCCard(npcName, npcDesc);
//     }
// }
