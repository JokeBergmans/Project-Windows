﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelList.Models;

namespace TravelList.Services
{
    public class ApiService
    {
        private static readonly string URL = "https://localhost:44317/api/";
        private static string _token;
        private static readonly HttpClient _client = new HttpClient();

        public async static Task<IList<Trip>> GetTrips()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = await _client.GetAsync(URL + "Trips");
            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                System.Diagnostics.Debug.WriteLine(JsonConvert.DeserializeObject<IList<Trip>>(response.Content.ReadAsStringAsync().Result).Count());
                return JsonConvert.DeserializeObject<IList<Trip>>(response.Content.ReadAsStringAsync().Result);

            }
            else
                return null;

        }

        public async static Task<bool> Register(RegistrationRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = await _client.PostAsync(URL + "Account/register", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                _token = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        public async static Task<bool> Login(LoginRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = await _client.PostAsync(URL + "Account", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            System.Diagnostics.Debug.WriteLine("Login status: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
                _token = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        public async static Task<Trip> AddTrip(TripRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = await _client.PostAsync(URL + "Trips", new StringContent(requestJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Trip>(response.Content.ReadAsStringAsync().Result);
            else
                return null;
        }
    }
}