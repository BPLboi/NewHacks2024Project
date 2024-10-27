using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

public class GeminiRequester
{
    HttpClient client;
    WriteRoot conversation;
    public GeminiRequester()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key=AIzaSyAQ8Wpm67Xf2sWgKHtv5YGaBJVnY0sT2CI");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        string filePath = "./gemini.json";
        string json = File.ReadAllText(filePath);
        conversation = JsonConvert.DeserializeObject<WriteRoot>(json);

        conversation.contents[0].parts.RemoveAt(0);
        // conversation.contents[1].parts.RemoveAt(0);
    }


    public async Task<string> message(string inputMsg)
    {
        //Adds the message to the json request
        Part msg = new Part();
        msg.text = inputMsg;
        conversation.contents[0].parts.Insert(0, msg);
        string jsonString = JsonConvert.SerializeObject(conversation);

        Console.WriteLine(jsonString);

        //Sends an HTTP request
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("", content);

        //Gets a response
        var responseData = await response.Content.ReadAsStringAsync();
        Response responseVariable = JsonConvert.DeserializeObject<Response>(responseData);
        Console.WriteLine(responseData);

        Part responseMsg = responseVariable.candidates[0].content.parts[0];

        //Stores the response in the conversation
        if (conversation.contents[1].parts[0].Equals(""))
        {
            conversation.contents[1].parts[0] = responseMsg;
        }
        else
        {
            conversation.contents[1].parts.Insert(0, responseMsg);
        }

        //Returns the response text
        return responseMsg.text;
    }
}
public class WriteRoot
{
    public List<Content> contents { get; set; }
}
public class Content
{
    public string role { get; set; }
    public List<Part> parts { get; set; }
}

public class Part
{
    public string text { get; set; }
}



public class Response
{
    public List<Candidate> candidates { get; set; }
    public UsageMetadata usageMetadata { get; set; }
    public string modelVersion { get; set; }
}

public class Candidate
{
    public Content content { get; set; }
    public string finishReason { get; set; }
    public int index { get; set; }
    public List<SafetyRating> safetyRatings { get; set; }
}

public class SafetyRating
{
    public string category { get; set; }
    public string probability { get; set; }
}

public class UsageMetadata
{
    public int promptTokenCount { get; set; }
    public int candidatesTokenCount { get; set; }
    public int totalTokenCount { get; set; }
}

public class ShortResponse
{
    public string response { get; set; }
    public int score { get; set; }
}