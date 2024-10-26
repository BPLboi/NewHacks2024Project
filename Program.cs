using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Use this if you installed Newtonsoft.Json
using System.Collections.Generic;

public class WriteContent
{
    public List<WriteContent> parts { get; set; }
}

public class WritePart
{
    public string text { get; set; }
}

public class WriteRoot
{
    public List<WriteContent> contents { get; set; }
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

public class Content
{
    public List<Part> parts { get; set; }
    public string role { get; set; }
}

public class Part
{
    public string text { get; set; }
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


class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "./gemini.json";
        string json = File.ReadAllText(filePath);

        var root = JsonConvert.DeserializeObject<WriteRoot>(json);

        string jsonString = JsonConvert.SerializeObject(root);

        Console.WriteLine(jsonString);

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key=AIzaSyAQ8Wpm67Xf2sWgKHtv5YGaBJVnY0sT2CI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("", content);

            var responseData = await response.Content.ReadAsStringAsync();
            Response responseVariable = JsonConvert.DeserializeObject<Response>(responseData);

            Console.WriteLine(responseVariable.candidates[0].content.parts[0].text);
            // responseData.
            Console.WriteLine("Response: " + responseData);
        }
    }
}
