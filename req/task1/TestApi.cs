using System;
using System.Collections.Generic;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;





namespace req.task1
{
    public class TestApi
    {
        private RestClient client;
        private JsonNode data;

        public TestApi(string clientUrl)
        {
            client = new RestClient(clientUrl);
        }

        public void GetData(RestRequest request)
        {
            var response = client.ExecuteGet(request);
            data = JsonSerializer.Deserialize<JsonNode>(response.Content);
        }

        public void PrintSwapiData()
        {
            var films = JsonSerializer.Deserialize<List<string>>(data["films"]);

            foreach (var item in films)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintReqresData()
        {
            var persons = JsonSerializer.Deserialize<List<JsonObject>>(data["data"]);

            for (int i = 0; i < persons.Count; i++)
            {
                var first_name = JsonSerializer.Deserialize<string>(persons[i]["first_name"]);
                var last_name = JsonSerializer.Deserialize<string>(persons[i]["last_name"]);
                var full_name = first_name + " " + last_name;

                if (full_name == "George Edwards")
                {
                    var email = JsonSerializer.Deserialize<string>(persons[i]["email"]);
                    Console.WriteLine(email);
                }
            }
        }
    }
}
