using req.task1;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;


//3 задание звучит просто но не понимаю какие поля именно нужно передавать поэтому не преступил 
//для 1 и 2 создал класс testapi он с точки зрения ооп не совсем правильный но для первых двух номеров данные выводятся верно

//1 task
var request = new RestRequest("people/1");

var swapiApi = new TestApi("https://swapi.dev/api");
swapiApi.GetData(request);
swapiApi.PrintSwapiData();

Console.WriteLine();

//2 task
request = new RestRequest("users?page=2");

var reqresApi = new TestApi("https://reqres.in/api");
reqresApi.GetData(request);
reqresApi.PrintReqresData();

Console.WriteLine();

//3task