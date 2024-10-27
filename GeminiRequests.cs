using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

public class GeminiRequester
{
    HttpClient client;
    WriteRoot conversation;
    public GeminiRequester()
    {
        //Sets up the client to make requests
        client = new HttpClient();
        client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key=AIzaSyAQ8Wpm67Xf2sWgKHtv5YGaBJVnY0sT2CI");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //Sets up the conversation log
        string filePath = "./gemini.json";
        string json = File.ReadAllText(filePath);
        conversation = JsonConvert.DeserializeObject<WriteRoot>(json);

        conversation.contents.RemoveAt(0);
    }


    public async Task<string> message(string inputMsg)
    {
        //Adds the message to the json request
        Part msg = new Part();
        msg.text = inputMsg;
        Content roleMsg = new Content();
        roleMsg.role = "user";
        roleMsg.parts = [msg];

        conversation.contents.Add(roleMsg);
        string jsonString = JsonConvert.SerializeObject(conversation);


        //Sends an HTTP request
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("", content);

        //Gets a response
        var responseData = await response.Content.ReadAsStringAsync();


        //Returns the response text
        try
        {
            Response responseVariable = JsonConvert.DeserializeObject<Response>(responseData);
            Content responseContent = responseVariable.candidates[0].content;

            //Stores the response in the conversation
            conversation.contents.Add(responseContent);
            return responseContent.parts[0].text;
        }
        catch
        {
            Console.WriteLine("Request produced an error. Raw response data: \n" + responseData);
            return null;
        }
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