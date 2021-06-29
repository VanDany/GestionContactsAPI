using Models.Global.Data;
using Models.Global.Mappers;
using Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Models.Global.Services
{
    public class ContactService : IContactRepository
    {
        private HttpClient CreateHttpClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44341/")
            };
        }
        public IEnumerable<Contact> Get(int userId)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"api/Contact/{userId}").Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    IEnumerable<Contact> contacts = JsonSerializer.Deserialize<Contact[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return contacts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public void Insert(Contact contact)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(contact);

                    using (HttpContent httpContent = new StringContent(json))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"api/Contact/", httpContent).Result;
                        httpResponseMessage.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Update(int id, Contact contact)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    string json = JsonSerializer.Serialize(contact);

                    using (HttpContent httpContent = new StringContent(json))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage httpResponseMessage = httpClient.PutAsync($"api/Contact/{id}", httpContent).Result;
                        httpResponseMessage.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(int userId, int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync($"api/Contact/{userId}/{id}").Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public Contact Get(int userId, int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"api/Contact/{userId}/{id}").Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    Contact contact = JsonSerializer.Deserialize<Contact>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return contact;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public IEnumerable<Contact> GetByCategory(int categoryId, int userId)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"api/Contact/ByCategory/{userId}/{categoryId}").Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    IEnumerable<Contact> contacts = JsonSerializer.Deserialize<IEnumerable<Contact>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return contacts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
