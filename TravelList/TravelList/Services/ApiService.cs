﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelList.Models;
using TravelList.Models.Domain;

namespace TravelList.Services
{
    public class ApiService
    {
        private static readonly string URL = "https://localhost:44317/api/";
        //private static string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqb2tlYmVyZ21hbnNAbWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6Impva2ViZXJnbWFuc0BtYWlsLmNvbSIsImV4cCI6MTYwOTI0NjYxNn0.7viU4vG4ub3LNI5I9mw1Ybu7857zakh103PFTiTJga4";
        private static readonly HttpClient _client = new HttpClient();

        public async static Task<IList<Trip>> GetTrips()
        {
            if (SessionManager.token == "")
                return null;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.token);
            HttpResponseMessage response = await _client.GetAsync(URL + "Trips");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IList<Trip>>(response.Content.ReadAsStringAsync().Result);
            else
                return null;

        }

        public async static Task<string> Register(RegistrationRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = await _client.PostAsync(URL + "Account/register", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                return token;
            }
            else
                return "";
        }

        public async static Task<string> Login(LoginRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = await _client.PostAsync(URL + "Account", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                return token;
            }
            else
                return "";


        }

        public async static Task<Trip> AddTrip(TripRequest request)
        {
            if (SessionManager.token == "")
                return null;
            string requestJson = JsonConvert.SerializeObject(request);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.token);
            HttpResponseMessage response = await _client.PostAsync(URL + "Trips", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Trip>(response.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public async static Task<bool> UpdateTrip(Trip trip)
        {
            if (SessionManager.token == "")
                return false;
            string requestJson = JsonConvert.SerializeObject(trip);
            System.Diagnostics.Debug.WriteLine(requestJson);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.token);
            HttpResponseMessage response = await _client.PutAsync(URL + "Trips/" + trip.Id, new StringContent(requestJson, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async static Task<IList<Item>> GetItems()
        {
            if (SessionManager.token == "")
                return null;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.token);
            HttpResponseMessage response = await _client.GetAsync(URL + "Items");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IList<Item>>(response.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public async static Task<Item> AddItem(Item request)
        {
            if (SessionManager.token == "")
                return null;
            string requestJson = JsonConvert.SerializeObject(request);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.token);
            HttpResponseMessage response = await _client.PostAsync(URL + "Items", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Item>(response.Content.ReadAsStringAsync().Result);
            else
                return null;
        }
    }
}
