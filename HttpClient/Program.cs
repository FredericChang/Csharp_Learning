﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClient
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
    internal class Program
    {
        public static async Task Main()
        {
            using System.Net.Http.HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            // Get the user information.
            User user = await client.GetFromJsonAsync<User>("users/1");
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");

            // Post a new user.
            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }
    }
}