using Newtonsoft.Json;
using ProjectNehaPalace.Models.HotelViewModels;
using ProjectNehaPalace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectNehaPalace.Models
{
    public class RoomClient
    {
        public System.Net.HttpStatusCode AddRoom(RoomModel room)
        {
            using (var client = CreateActionClient("Post01"))
            {
                HttpResponseMessage response = null;
                try
                {
                    //response = client.PostAsJsonAsync(client.BaseAddress, company).Result;
                    var output = JsonConvert.SerializeObject(room);
                    HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                    response = client.PostAsync(client.BaseAddress, contentPost).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return response.StatusCode;
            }
        }
        string _hostUri;

        public RoomClient(string hostUri)
        {
            _hostUri = hostUri;
        }

        HttpClient client;
        public HttpClient CreateSingletonClient()
        {
            if (client == null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/");
            return client;
        }
        public HttpClient CreateSingletonActionClient(string action)
        {
            if (client == null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/" + action);
            return client;
        }
        public HttpClient CreateClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/");
            return client;
        }
        public HttpClient CreateActionClient(string action)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/" + action);
            return client;
        }


        public async Task<IEnumerable<RoomModel>> GetRoomsAsync()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response;
                response = client.GetAsync(client.BaseAddress).Result;

                //var result = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                if (response.IsSuccessStatusCode)
                {
                    var avail = await response.Content.ReadAsStringAsync()
                        .ContinueWith<IEnumerable<RoomModel>>(postTask =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<RoomModel>>(postTask.Result);
                        });
                    return avail;
                }
                else
                {
                    return null;
                }
            }
            //return result;
        }

        public async Task<IEnumerable<RoomModel>> GetRoomsAsync(RoomType roomType)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response;
                response = client.GetAsync(new Uri(client.BaseAddress, roomType.ToString())).Result;
                //var result = response.Content.ReadAsAsync<string>().Result;
                if (response.IsSuccessStatusCode)
                {
                    var avail = await response.Content.ReadAsStringAsync()
                        .ContinueWith<IEnumerable<RoomModel>>(postTask =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<RoomModel>>(postTask.Result);
                        });
                    return avail;
                }
                else
                {
                    return null;
                }
            }
            //return result;
        }

        

        public System.Net.HttpStatusCode UpdateRoom(RoomModel room)
        {
            using (var client = CreateActionClient("Put01"))
            {
                HttpResponseMessage response;
                //response = client.PutAsJsonAsync(client.BaseAddress, company).Result;
                var output = JsonConvert.SerializeObject(room);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = client.PostAsync(client.BaseAddress, contentPost).Result;
                return response.StatusCode;
            }
        }

        public async Task<System.Net.HttpStatusCode> UpdateRoomAsync(RoomModel room)
        {
            using (var client = CreateActionClient("Post01"))
            {
                HttpResponseMessage response;
                //response = client.PutAsJsonAsync(client.BaseAddress, company).Result;
                var output = JsonConvert.SerializeObject(room);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync(client.BaseAddress, contentPost);
                return response.StatusCode;
            }
        }

        public System.Net.HttpStatusCode DeleteRoom(int id)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response;
                response = client.DeleteAsync(new Uri(client.BaseAddress, id.ToString())).Result;
                response = client.DeleteAsync(new Uri(client.BaseAddress, id.ToString())).Result;
                return response.StatusCode;
            }
        }
    }
}
