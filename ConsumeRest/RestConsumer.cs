using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsumeRest
{
    class RestConsumer
    {
        public void Start()
        {
            RestData data = new RestData(1, 75, "Testen", true);

            //foreach (var getData in GetAll())
            //{
            //    Console.WriteLine(getData);
            //}

            Console.WriteLine("\n" + GetOne(75) + "\n");

            RestData data2 = new RestData(10, 75, "Ændringen", true);
            Console.WriteLine("\n" + Put(data2, 75) + "\n");

            Console.WriteLine("\n" + Post(data) + "\n");
            Console.WriteLine("\n" + GetOne(75) + "\n");
            
            Console.WriteLine("\n" + GetOne(3) + "\n");

            Console.WriteLine("\n" + Delete(75) + "\n");

            Console.WriteLine("\n" + GetOne(75) + "\n");

            //RestData data2 = new RestData(1, 3, "Ændringen", false);

            //Console.WriteLine("\n" + Put(data2, 3) + "\n");


            //foreach (var getData in GetAll())
            //{
            //    Console.WriteLine(getData);
            //}
        }

        public IList<RestData> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/").Result;
                IList <RestData> cList = JsonConvert.DeserializeObject<IList<RestData>>(content);
                return cList;
            }
        }

        public RestData GetOne(int nummer)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/" + nummer).Result;
                RestData cData = JsonConvert.DeserializeObject<RestData>(content);
                return cData;
            }
        }

        public RestData Post(RestData restData)
        {
            String json = JsonConvert.SerializeObject(restData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //Man kan enten tilføje Encoding.UTF8, "application/json" ovenfor, eller skrive nedenstående linje.
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.PostAsync("https://jsonplaceholder.typicode.com/todos/", content).Result;
                // optional if any result to unpack
                //string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                //var result = JsonConvert.DeserializeObject<bool>(jsonResult);

                return GetOne(restData.ID);
            }
        }

        public RestData Put(RestData restData, int nummer)
        {
            String json = JsonConvert.SerializeObject(restData);
            StringContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.PutAsync("https://jsonplaceholder.typicode.com/todos/" + nummer, content).Result;
                // optional if any result to unpack
                //string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                //var result = JsonConvert.DeserializeObject<bool>(jsonResult);

                return GetOne(nummer);
            }
        }

        public bool Delete(int nummer)
        {
            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.DeleteAsync("https://jsonplaceholder.typicode.com/todos/" + nummer).Result;
                // optional if any result to unpack
                //string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                //var result = JsonConvert.DeserializeObject<RestData>(jsonResult);

                return true;
            }
        }
    }
}
