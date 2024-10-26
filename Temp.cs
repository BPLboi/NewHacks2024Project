// using System;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Text;
// using System.Threading.Tasks;
// using Newtonsoft.Json; // Use this if you installed Newtonsoft.Json

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         var email = @"";

//         var jsonData = new { email, options = "long" };
//         var jsonString = JsonConvert.SerializeObject(jsonData);

//         using (var client = new HttpClient())
//         {
//             client.BaseAddress = new Uri("https://spamcheck.postmarkapp.com/filter");
//             client.DefaultRequestHeaders.Accept.Clear();
//             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//             var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

//             HttpResponseMessage response = await client.PostAsync("", content);

//             // if (response.IsSuccessStatusCode)
//             // {
//             var responseData = await response.Content.ReadAsStringAsync();
//             // responseData.
//             Console.WriteLine("Response: " + responseData);
//             // }
//             // else
//             // {
//             //     Console.WriteLine("Error: " + response.StatusCode);
//             // }
//         }
//     }
// }
