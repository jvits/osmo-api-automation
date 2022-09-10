using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Security.Cryptography.X509Certificates;

namespace OsmoAutomationExam
{

    public class User
    {

        ApiHelper apiHelper = new ApiHelper();

        string username = "admiral";
        string password = "password1";

        [Test, Order(0)]
        public void InsertUser()
        {
            JObject body = new JObject(
             new JProperty("id", 0),
             new JProperty("username", username),
             new JProperty("firstName", "James"),
             new JProperty("lastName", "2Pac"),
             new JProperty("email", "popopng@yopmail.com"),
             new JProperty("password", password),
             new JProperty("phone", "11111"),
             new JProperty("userStatus", 0)
            );

            apiHelper.Post(body);
            RetrieveUser();

        }

        [Test, Order(1)]
        public void RetrieveUser()
        {
            JObject json_object = JObject.Parse(apiHelper.Get(username).ToString());
            Console.WriteLine(json_object["response"]);
            
        }

        [Test, Order(2)]
        public void UpdateUser()
        {
            JObject json_object = JObject.Parse(apiHelper.Get(username).ToString());

            string code = json_object["code"].ToString();

            if (code == "2")
            {
                JObject body = new JObject(
                     new JProperty("id", Convert.ToInt64(apiHelper.id)),
                     new JProperty("username", username),
                     new JProperty("firstName", "marjorie"),
                     new JProperty("lastName", "macayan"),
                     new JProperty("email", "marj@yopmail.com"),
                     new JProperty("password", "password"),
                     new JProperty("phone", "2222222"),
                     new JProperty("userStatus", 0)
                    );

                apiHelper.Put(body, username);
                RetrieveUser();
            }
            else
            {
                RetrieveUser();
            }
        }

        [Test, Order(3)]
        public void DeleteUser()
        {
            apiHelper.Delete(username);
            RetrieveUser();
        }

    }

    public class ApiHelper
    {
        string base_url = "https://petstore.swagger.io/v2/";

        public string id = "";

        public object Auth(string username, string password)
        {
            RestClient client = new RestClient(base_url + "user/login?username=" + username + "&password=" + password);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            var json_obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            String code = json_obj["code"];

            JObject json_result = new JObject(
                     new JProperty("code", code),
                     new JProperty("json_obj", json_obj),
                     new JProperty("response", response.Content)
                    );

            return json_result;

        }

        public void Post(JObject body)
        {
            RestClient client = new RestClient(base_url + "user");
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body.ToString(), ParameterType.RequestBody);
            client.Post(request);
        }

        public Object Get(string username)
        {
            RestClient client = new RestClient(base_url + "user/" + username);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            var json_obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            id = Convert.ToString(json_obj["id"]);

            String code = json_obj["code"];

            JObject json_result = new JObject(
                     new JProperty("code", code),
                     new JProperty("json_obj", json_obj),
                     new JProperty("response", response.Content)
                    );

            return json_result;
        }

        public void Put(JObject body, string username)
        {
            RestClient client = new RestClient(base_url + "user/" + username);
            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body.ToString(), ParameterType.RequestBody);
            client.Put(request);
        }

        public void Delete(string username)
        {
            var client = new RestClient(base_url + "user/" + username);
            var request = new RestRequest();
            var response = client.Delete(request);
            Console.WriteLine(response.Content);
        }

    }
}